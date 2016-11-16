/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-10
 * Time: 17:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Threading;
using Microsoft.DirectX.DirectSound;

using Helper;

namespace AudioService
{
    /// <summary>
    /// Description of VoiceCapture.
    /// </summary>
    public class VoiceCapture : IDisposable
	{
		private bool isStart = false;
		private int notifySize = 0;
        private int bufferSize = 0; 
        private int notifyNum =0;
        private int bufferOffset =0;
		private MemoryStream stream;
        private SecondaryBuffer secondBuffer;
        private CaptureBuffer captureBuffer;
		private BufferDescription bufferDesc;
        
        private Notify notify;
        private Capture capture;
        private Device playDev;
        
        private AutoResetEvent notifyEvent;
        
        private IntPtr intptr;
        
		public IntPtr Intptr {
			get { return intptr; }
			set { intptr = value; }
		}
        
        private int intPosWrite = 0;
        private int intPosPlay = 0;
        private int intNotifySize = 5000;//设置通知大小
        
		public VoiceCapture()
		{
		}
		
		public VoiceCapture(int _notifyNum, int _notifySize, IntPtr _intPtr)
		{
			this.notifyNum = _notifyNum;
			this.notifySize = _notifySize;
			this.intptr = _intPtr;
		}
		
		public bool Init()
        {
            if (!CreateCaputerDevice())
            {
                return false;
            }
            if (!CreatePlayDevice())
            {
                return false;
            }
            CreateCaptureBuffer();
            CreateSecondaryBuffer();
            return true;
        }
		
		public event RecordVoiceHandler RecordVoice;
		
		protected virtual void OnRecordVoice(RecordVoiceEventArgs e)
		{
			if (this.RecordVoice != null)
			{
				this.RecordVoice(this, e);
			}
		}

        private bool CreatePlayDevice()
        {
        	try
        	{
	            DevicesCollection dc = new DevicesCollection();
	            Guid g;
	            if (dc.Count > 0)
	            {
	                g = dc[0].DriverGuid;
	            }
	            else
	            { 
	            	return false; 
	            }
	            this.playDev = new Device(g);
	            this.playDev.SetCooperativeLevel(this.intptr, CooperativeLevel.Normal);
	            return true;
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
        		return false;
        	}
        }
        
        private bool CreateCaputerDevice()
        {
        	try
        	{
	            CaptureDevicesCollection capturedev = new CaptureDevicesCollection();
	            Guid devguid;
	            if (capturedev.Count > 0)
	            {
	                devguid = capturedev[0].DriverGuid;
	            }
	            else
	            {
	                return false;
	            }
	            this.capture = new Capture(devguid);
	            return true;
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return false;
        	}
        }
        
        private void CreateSecondaryBuffer()
        {
        	try
        	{
	            this.bufferDesc = new BufferDescription();
	            WaveFormat wf = SetWaveFormat();
	            this.bufferDesc.Format = wf;
	            this.notifySize = wf.AverageBytesPerSecond / this.notifyNum;
	            this.bufferSize = this.notifyNum * this.notifySize;
	            this.bufferDesc.BufferBytes = this.bufferSize;
	            this.bufferDesc.ControlPan = true;
	            this.bufferDesc.ControlFrequency = true;
	            this.bufferDesc.ControlVolume = true;
	            this.bufferDesc.GlobalFocus = true;
	            this.secondBuffer = new SecondaryBuffer(this.bufferDesc, this.playDev);
	            byte[] bytMemory = new byte[100000];
	            this.stream = new MemoryStream(bytMemory, 0, 100000, true, true);
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
        	}
        }

        private void CreateCaptureBuffer()
        {
        	try
        	{
	        	WaveFormat wf = SetWaveFormat();
	            CaptureBufferDescription desc = new CaptureBufferDescription();
	            desc.Format = wf;
	            this.notifySize = wf.AverageBytesPerSecond / this.notifyNum;
	            this.bufferSize = this.notifyNum * this.notifySize;
	            desc.BufferBytes = this.bufferSize;
	            desc.ControlEffects = true;
	            desc.WaveMapped = true;
	            this.captureBuffer = new CaptureBuffer(desc, this.capture);
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
        	}
        }
        
        private WaveFormat SetWaveFormat()
        {
        	WaveFormat format = new WaveFormat();
	        format.FormatTag = WaveFormatTag.Pcm;
	        format.SamplesPerSecond = 11025;
	        format.BitsPerSample = 16;
	        format.Channels = 1;
	        format.BlockAlign = (short)(format.Channels * (format.BitsPerSample / 8));
	        format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;
	        return format;
        }
        
        public void Start()
        {
        	try
        	{
	            BufferPositionNotify[] bpn = new BufferPositionNotify[this.notifyNum];
	            this.notifyEvent = new AutoResetEvent(false);
	            for (int i = 0; i < this.notifyNum; i++)
	            {
	                bpn[i].Offset = this.notifySize + i * this.notifySize - 1;
	                //bpn[i].EventNotifyHandle = this.notifyEvent.Handle;
	                bpn[i].EventNotifyHandle = this.notifyEvent.SafeWaitHandle.DangerousGetHandle();
	            }
	            this.notify = new Notify(this.captureBuffer);
	            this.notify.SetNotificationPositions(bpn);
	            AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(CaptureData);
	            ah.BeginInvoke(null, null);
	            this.isStart = true;
        		this.captureBuffer.Start(true);
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
        	}

        }
        
        private void CaptureData()
        {
            while (this.isStart)
            {
            	try
            	{
	                this.notifyEvent.WaitOne(Timeout.Infinite, true);
		            byte[] buff = null;
		            int readpos = 0, capturepos = 0, locksize = 0;
		            this.captureBuffer.GetCurrentPosition(out capturepos, out readpos);
		            locksize = readpos - this.bufferOffset;
		            if (locksize == 0)
		            {
		                return;
		            }
		            if (locksize < 0)
		            {
		            	locksize += this.bufferSize;
		            }
		            buff = (byte[])this.captureBuffer.Read(this.bufferOffset, typeof(byte), LockFlag.FromWriteCursor, locksize);
		            this.OnRecordVoice(new RecordVoiceEventArgs(buff));
		            this.bufferOffset += buff.Length;
		            this.bufferOffset %= this.bufferSize;
            	}
            	catch(Exception ex)
            	{
            		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
            	}
            }
        }
        
        public void RecveVoice(byte[] buff)
        {
        	try
        	{
	        	int length = buff.Length;
	            if (intPosWrite + length <= this.stream.Capacity)
	            {
	            	if ((intPosWrite - intPosPlay >= 0 && intPosWrite - intPosPlay < intNotifySize) || (intPosWrite - intPosPlay < 0 && intPosWrite - intPosPlay + this.stream.Capacity < intNotifySize))
	                {
	                    this.stream.Write(buff, 0, length);
	                    intPosWrite += length;
	                }
	                else if (intPosWrite - intPosPlay >= 0)
	                {
	                    this.bufferDesc.BufferBytes = intPosWrite - intPosPlay;
	                    SecondaryBuffer sec = new SecondaryBuffer(this.bufferDesc, this.playDev);
	                    this.stream.Position = intPosPlay;
	                    sec.Write(0, this.stream, intPosWrite - intPosPlay, LockFlag.FromWriteCursor);
	                    sec.Play(0, BufferPlayFlags.Default);
	                    this.stream.Position = intPosWrite;
	                    intPosPlay = intPosWrite;
	                }
	                else if (intPosWrite - intPosPlay < 0)
	                {
	                    this.bufferDesc.BufferBytes = intPosWrite - intPosPlay + this.stream.Capacity;
	                    SecondaryBuffer sec = new SecondaryBuffer(this.bufferDesc, this.playDev);
	                    this.stream.Position = intPosPlay;
	                    sec.Write(0, this.stream, this.stream.Capacity - intPosPlay, LockFlag.FromWriteCursor);
	                    this.stream.Position = 0;
	                    sec.Write(this.stream.Capacity - intPosPlay, this.stream, intPosWrite, LockFlag.FromWriteCursor);
	                    sec.Play(0, BufferPlayFlags.Default);
	                    this.stream.Position = intPosWrite;
	                    intPosPlay = intPosWrite;
	                }
	            }
	            else
	            {
	                int irest = this.stream.Capacity - intPosWrite;
	                this.stream.Write(buff, 0, irest);
	                this.stream.Position = 0;
	                this.stream.Write(buff, irest, length - irest);
	                intPosWrite = length - irest;
	            }
        	}
        	catch(Exception ex)
        	{
        		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
        	}
        }
        
        public void Stop()
        {
            this.captureBuffer.Stop();
            if (this.notifyEvent != null)
            {
                this.notifyEvent.Set();
            }
			this.isStart = false;
        }
        
        public void Dispose()
        {
        	if (this.stream != null)
        	{
	        	this.stream.Close();
	        	this.stream = null;
        	}
        }
	}
}
