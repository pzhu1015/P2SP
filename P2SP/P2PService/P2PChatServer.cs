/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-6
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections;

using Helper;
using Trans;

namespace P2PService
{
    /// <summary>
    /// Description of P2PChatServer.
    /// </summary>
    public class P2PChatServer
	{
		#region Member
		
		private bool isStart;
		private int tcpPort;
		private TcpListener listener;
		private EventWaitHandle listenAllDone = new EventWaitHandle(false, EventResetMode.ManualReset);
		private static object clientTableLocker = new object();
		private static object sendLocker = new object();
		private Hashtable waitAckMap = new Hashtable();//[TransId, BaseTrans]
		
		#endregion
		
		#region Construct
		
		public P2PChatServer(int _tcpPort)
		{
			this.tcpPort = _tcpPort;
		}
		
		#endregion
		
		#region Event
		
		public event TcpListenerStartEventHandler TcpListenerStart;
		public event TcpListenerStopEventHandler TcpListenerStop;
		public event TcpDisConnectEventHandler TcpDisConnect;
		public event TcpSendEventHandler TcpSend;
		public event TcpRecveEventHandler TcpRecve;
		public event TcpAcceptEventHandler TcpAccept;
		
		protected virtual void OnTcpListenerStart(TcpListenerStartEventArgs e)
		{
			if (this.TcpListenerStart != null)
			{
				this.TcpListenerStart(this, e);
			}
		}
		
		protected virtual void OnTcpListenerStop(TcpListenerStopEventArgs e)
		{
			if (this.TcpListenerStop != null)
			{
				this.TcpListenerStop(this, e);
			}
		}
		
		protected virtual void OnTcpDisConnect(TcpDisConnectEventArgs e)
		{
			if (this.TcpDisConnect != null)
			{
				this.TcpDisConnect(this, e);
			}
		}
		
		protected virtual void OnTcpSend(TcpSendEventArgs e)
		{
			if (this.TcpSend != null)
			{
				this.TcpSend(this, e);
			}
		}
		
		protected virtual void OnTcpRecve(TcpRecveEventArgs e)
		{
			if (this.TcpRecve != null)
			{
				this.TcpRecve(this, e);
			}
		}
		
		protected virtual void OnTcpListenerAccpetClient(TcpAcceptEventArgs e)
		{
			if (this.TcpAccept != null)
			{
				this.TcpAccept(this, e);
			}
		}
		
		#endregion
		
		#region Ack Interface
		
		private void AddToWaitAck(BaseTrans trans)
		{
			return;
			//try
			//{
			//	if (trans.Command == NetCommand.eAck)
			//	{
			//		return;
			//	}
			//	trans.InitAckLocker();
			//	lock(sendLocker)
			//	{
			//		{
			//			System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//			System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//			DebugHelper.Console("AddToWaitAck: " + trans.ToString(), sf);
			//		}
			//		this.waitAckMap[trans.TransId.ToString()] = trans;
			//	}
			//}
			//catch(Exception ex)
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Console(ex.ToString(), sf);
			//}
		}
		
		private void RecvAck(AckTrans ackTrans)
		{
			return;
			//try
			//{
			//	BaseTrans trans = null;
			//	lock(sendLocker)
			//	{
			//		trans = this.waitAckMap[ackTrans.ReqId.ToString()] as BaseTrans;
			//		{
			//			System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//			System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//			DebugHelper.Console("RecvAck: " + trans.ToString(), sf);
			//		}
			//		this.waitAckMap.Remove(trans.TransId.ToString());
			//	}
			//	trans.RecvAck();
			//}
			//catch(Exception ex)
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Console(ex.ToString(), sf);
			//}
		}
		
		private void SendAck(BaseTrans trans, TcpClient client)
		{
			return;
			//try
			//{
			//	BaseTrans ackTrans = new AckTrans(trans.TransId);
			//	this.AsyncSend(ackTrans, client);
			//}
			//catch(Exception ex)
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Console(ex.ToString(), sf);
			//}
		}
		#endregion
		
		#region Pulbic Interface
		
		public void Start(int _port)
		{
			this.tcpPort = _port;
			this.Start();
		}
	
		public void Start()
		{		
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncStartCb);
			ah.BeginInvoke(null, null);
		}
		
		public void Stop()
		{
			this.isStart = false;
			this.listener.Stop();
			this.listenAllDone.Set();
		}
		
		public void AsyncSend(BaseTrans trans, TcpClient client)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("AsyncSend: " + trans.ToString(), sf);
			}
			ReadWriteObject readWriteObject = null;
			try
			{
				//this.AddToWaitAck(trans);
				AsyncCallback callback = new AsyncCallback(AsyncSendCb);
				readWriteObject = new ReadWriteObject(client, ConnectType.eServer);
				SendCell cell = new SendCell(trans);
				readWriteObject.SetSendBuff(cell.ToBuffer());
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.BeginWrite(readWriteObject.SendBuff, 0, readWriteObject.SendBuff.Length, callback, readWriteObject);
					readWriteObject.NetStream.Flush();
					//trans.WaitAck();
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.DisConnectClient(readWriteObject);
			}
		}
		
		#endregion
		
		#region Handle CallBack
		
		private void AsyncStartCb()
		{
			if (this.tcpPort == -1)
			{
				this.OnTcpListenerStart(new TcpListenerStartEventArgs(this.tcpPort));
				return;
			}
			this.isStart = true;
            //IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            //this.listener = new TcpListener(ip[0], this.tcpPort);
            this.listener = new TcpListener(IPAddress.Parse("192.168.0.103"), this.tcpPort);
            this.listener.Start();
			this.OnTcpListenerStart(new TcpListenerStartEventArgs(this.tcpPort));
			while(this.isStart)
			{
				try
				{
					this.listenAllDone.Reset();
					AsyncCallback callback = new AsyncCallback(AcceptTcpClientCb);
					this.listener.BeginAcceptTcpClient(callback, this.listener);
					this.listenAllDone.WaitOne();
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
			}
			this.OnTcpListenerStop(new TcpListenerStopEventArgs(this.tcpPort));
		}
		
		private void AcceptTcpClientCb(IAsyncResult iar)
		{
			TcpListener lst = null;
			try
			{
				this.listenAllDone.Set();
				lst = (TcpListener)iar.AsyncState;
				if (lst == null || !this.isStart)
				{
					return;
				}
				TcpClient client = lst.EndAcceptTcpClient(iar);
				this.OnTcpListenerAccpetClient(new TcpAcceptEventArgs(client));
				ReadWriteObject readWriteObject = new ReadWriteObject(client, ConnectType.eServer);
				readWriteObject.SetReadBuff(readWriteObject.HeaderBuff);
				this.Recve(readWriteObject);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				if (lst != null)
				{
					lst.Stop();
				}
			}
		}
		
		private void DisConnectClient(ReadWriteObject readWriteObject)
		{
			try
			{
				if (readWriteObject != null && readWriteObject.NetStream != null)
				{
					if (readWriteObject.Client != null)
					{
						this.OnTcpDisConnect(new TcpDisConnectEventArgs(readWriteObject));
					}
					readWriteObject.NetStream.Close();
					readWriteObject.NetStream = null;
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void Recve(ReadWriteObject readWriteObject)
		{
			try
			{
				AsyncCallback callback = new AsyncCallback(RecveCb);
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanRead)
				{
					if (readWriteObject.IsHeader)
					{
						readWriteObject.NetStream.BeginRead(
							readWriteObject.ReadBuff, 
							0, 
							readWriteObject.ReadBuff.Length, 
							callback, 
							readWriteObject);
					}
					else
					{
						readWriteObject.NetStream.BeginRead(
							readWriteObject.ReadBuff, 
							readWriteObject.TotalReadLength, 
							readWriteObject.ReadBuff.Length-readWriteObject.TotalReadLength, 
							callback, 
							readWriteObject);
					}
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.DisConnectClient(readWriteObject);
			}
		}	
		
		private void RecveCb(IAsyncResult iar)
		{

			ReadWriteObject readWriteObject = null;
			try
			{
				readWriteObject = (ReadWriteObject)iar.AsyncState;
				int count = 0;
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanRead)
				{
					count = readWriteObject.NetStream.EndRead(iar);
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
				}
				if (count < 1)
				{
					this.DisConnectClient(readWriteObject);
					return;
				}
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("RecvCb , readWriteObject.IsHeader: " + readWriteObject.IsHeader.ToString(), sf);
				}
				if (readWriteObject.IsHeader)
				{	
					DebugHelper.Assert(count == sizeof(Int32));
					int len = BitConverter.ToInt32(readWriteObject.ReadBuff, 0);
					readWriteObject.SetReadBuff(new byte[len]);
					readWriteObject.TotalReadLength = 0;
					readWriteObject.IsHeader = false;
					this.Recve(readWriteObject);
				}
				else
				{
					readWriteObject.TotalReadLength += count;
					if (readWriteObject.TotalReadLength < readWriteObject.ReadBuff.Length)
					{
						this.Recve(readWriteObject);
						return;
					}
					else
					{
						DebugHelper.Assert(readWriteObject.ReadBuff.Length == readWriteObject.TotalReadLength);
						SendCell cell = new SendCell();
						cell.FromBuffer(readWriteObject.ReadBuff);
						BaseTrans trans = (BaseTrans)(cell.Data);
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("RecvCb: " + trans.ToString(), sf);
						}
						if (trans.Command != NetCommand.eAck)
						{
//							Thread.Sleep(2000);
							this.SendAck(trans, readWriteObject.Client);
							this.OnTcpRecve(new TcpRecveEventArgs(trans, readWriteObject.Client));
							readWriteObject.IsHeader = true;	
							this.Recve(readWriteObject);
						}
						else
						{
							this.RecvAck(trans as AckTrans);
						}
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				//Error
				this.DisConnectClient(readWriteObject);
			}
		}	
		
		private void AsyncSendCb(IAsyncResult iar)
		{
			ReadWriteObject readWriteObject = (ReadWriteObject)iar.AsyncState;
			try
			{
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("AsyncSendCb: ", sf);
				}	
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.EndWrite(iar);
					this.OnTcpSend(new TcpSendEventArgs());
					readWriteObject = new ReadWriteObject(readWriteObject.Client, ConnectType.eServer);
					readWriteObject.SetReadBuff(readWriteObject.HeaderBuff);
					this.Recve(readWriteObject);
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
				}	
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				//Error
				this.DisConnectClient(readWriteObject);
			}
		}
		
		#endregion
	}
}
