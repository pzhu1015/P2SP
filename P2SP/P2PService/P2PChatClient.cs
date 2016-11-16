/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-6
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

using Helper;
using Trans;

namespace P2PService
{
    /// <summary>
    /// Description of P2PChatClient.
    /// </summary>
    public class P2PChatClient
	{
		#region Member and ProPerty

		private bool isStart;
		private static object sendLocker = new object();
		private Hashtable waitAckMap = new Hashtable();//[TransId.ToString(), BaseTrans]
		private EventWaitHandle listenAllDone = new EventWaitHandle(false, EventResetMode.ManualReset);
		
		private TcpClient serverConnection;	
		public TcpClient ServerConnection {
			get { return serverConnection; }
			set { serverConnection = value; }
		}
		
		private TcpListener localListener;
		public TcpListener LocalListener {
			get { return localListener; }
			set { localListener = value; }
		}

		private IPAddress serverIp;
		public IPAddress ServerIp {
			get { return serverIp; }
			set { serverIp = value; }
		}

		private int serverTcpPort = -1;
		public int ServerTcpPort {
			get { return serverTcpPort; }
			set { serverTcpPort = value; }
		}
		
		private int localTcpPort = -1;
		public int LocalTcpPort {
			get { return localTcpPort; }
			set { localTcpPort = value; }
		}
		
				
		#endregion
			
		#region Construct
		
		public P2PChatClient(string ip, int port)
		{
			this.serverIp = IPAddress.Parse(ip);
			this.serverTcpPort = port;
			this.isStart = true;
		}
		
		public P2PChatClient(IPAddress ip, int port)
		{
			this.serverIp = ip;
			this.serverTcpPort = port;
			this.isStart = true;
		}
		
		#endregion
		
		#region Event

		public event TcpListenerStartEventHandler TcpListenerStart;
		public event TcpListenerStopEventHandler TcpListenerStop;
		public event TcpAcceptEventHandler TcpAccept;
		public event TcpRecveEventHandler TcpRecve;
		public event TcpSendEventHandler TcpSend;
		public event TcpConnectEventHandler TcpConnect;
		public event TcpDisConnectEventHandler TcpDisConnect;
		
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
		
		protected virtual void OnTcpListenerAcceptClient(TcpAcceptEventArgs e)
		{
			if (this.TcpAccept != null)
			{
				this.TcpAccept(this, e);
			}
		}
		
		protected virtual void OnTcpRecve(TcpRecveEventArgs e)
		{
			if (this.TcpRecve != null)
			{
				this.TcpRecve(this, e);
			}
		}
		
		protected virtual void OnTcpSend(TcpSendEventArgs e)
		{
			if (this.TcpSend != null)
			{
				this.TcpSend(this, e);
			}
		}
		
		protected virtual void OnTcpConnect(TcpConnectEventArgs e)
		{
			if (this.TcpConnect != null)
			{
				this.TcpConnect(this, e);
			}
		}
		
		protected virtual void OnTcpDisConnect(TcpDisConnectEventArgs e)
		{
			if (this.TcpDisConnect != null)
			{
				this.TcpDisConnect(this, e);
			}
		}
				
		#endregion
		
		#region Ack Interface
		private void AddToWaitResp(BaseTrans trans)
		{
			
		}
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
			//	DebugHelper.Error(ex, sf);
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
			//	DebugHelper.Error(ex, sf);
			//}
		}
		
		private void SendAck(BaseTrans trans, TcpClient client, ConnectType type)
		{
			return;
			//try
			//{
			//	BaseTrans ackTrans = new AckTrans(trans.TransId);
			//	if (type == ConnectType.eClient)
			//	{
			//		this.AsyncSendToClient(client, ackTrans);
			//	}
			//	else
			//	{
			//		this.AsyncSendToServer(client, ackTrans);
			//	}
			//}
			//catch(Exception ex)
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Error(ex, sf);
			//}
		}
		#endregion
		
		#region Public Interface

		public void Stop()
		{
			this.isStart = false;
			this.localListener.Stop();
			this.listenAllDone.Set();
		}

		public void Start()
		{
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(AsyncStartCb);
			ah.BeginInvoke(null, null);
		}
		
		public void AsyncSendToClient(TcpClient client, BaseTrans trans)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("AsyncSendToClient: " + trans.ToString(), sf);
			}
			ReadWriteObject readWriteObject = null;
			try
			{
				this.AddToWaitAck(trans);
				AsyncCallback callback = new AsyncCallback(AsyncSendCb);
				readWriteObject = new ReadWriteObject(client, ConnectType.eClient);
				SendCell cell = new SendCell(trans);
				readWriteObject.SetSendBuff(cell.ToBuffer());
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.BeginWrite(readWriteObject.SendBuff, 0, readWriteObject.SendBuff.Length, callback, readWriteObject);
					readWriteObject.NetStream.Flush();
					trans.WaitAck();
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
				
		public BaseTrans AsyncSendToClientWithResp(TcpClient client, BaseTrans trans)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("AsyncSendToClient: " + trans.ToString(), sf);
			}
			ReadWriteObject readWriteObject = null;
			try
			{
				this.AddToWaitResp(trans);
				AsyncCallback callback = new AsyncCallback(AsyncSendCb);
				readWriteObject = new ReadWriteObject(client, ConnectType.eClient);
				SendCell cell = new SendCell(trans);
				readWriteObject.SetSendBuff(cell.ToBuffer());
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.BeginWrite(readWriteObject.SendBuff, 0, readWriteObject.SendBuff.Length, callback, readWriteObject);
					readWriteObject.NetStream.Flush();
					return trans.WaitResp();
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
					return null;
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.DisConnectClient(readWriteObject);
				return null;
			}
		}
		
		public void AsyncSendToServer(TcpClient client, BaseTrans trans)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("AsyncSendToServer: " + trans.ToString(), sf);
			}
			ReadWriteObject readWriteObject = null;
			try
			{
				this.AddToWaitAck(trans);
				AsyncCallback callback = new AsyncCallback(AsyncSendCb);
				readWriteObject = new ReadWriteObject(client, ConnectType.eServer);
				SendCell cell = new SendCell(trans);
				readWriteObject.SetSendBuff(cell.ToBuffer());
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.BeginWrite(readWriteObject.SendBuff, 0, readWriteObject.SendBuff.Length, callback, readWriteObject);
					readWriteObject.NetStream.Flush();
					trans.WaitAck();
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
		
		public BaseTrans AsyncSendToServerWithResp(TcpClient client, BaseTrans trans)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("AsyncSendToServer: " + trans.ToString(), sf);
			}
			ReadWriteObject readWriteObject = null;
			try
			{
				this.AddToWaitAck(trans);
				AsyncCallback callback = new AsyncCallback(AsyncSendCb);
				readWriteObject = new ReadWriteObject(client, ConnectType.eServer);
				SendCell cell = new SendCell(trans);
				readWriteObject.SetSendBuff(cell.ToBuffer());
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.BeginWrite(readWriteObject.SendBuff, 0, readWriteObject.SendBuff.Length, callback, readWriteObject);
					readWriteObject.NetStream.Flush();
					return trans.WaitResp();
				}
				else
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("Alarm", sf);
					return null;
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.DisConnectClient(readWriteObject);
				return null;
			}
		}
		
		public void Connect(IPAddress ip, int port, ConnectType type, string userId)
		{
			try
			{
				TcpClient client = new TcpClient(AddressFamily.InterNetwork);
				client.Client.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReuseAddress, true);
				ReadWriteObject readWriteObject = new ReadWriteObject(
					client,
					new EventWaitHandle(false, EventResetMode.ManualReset),
					type,
					userId);
				readWriteObject.EventWait.Reset();
				client.BeginConnect(ip, port, new AsyncCallback(ConnectCb), readWriteObject);
				readWriteObject.EventWait.WaitOne();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
				
		#endregion
		
		#region Handle CallBack

		private void AsyncStartCb()
		{
			if (this.localTcpPort == -1)
			{
				this.OnTcpListenerStart(new TcpListenerStartEventArgs(this.localTcpPort));
			}
			this.isStart = true;
			IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
			this.localListener = new TcpListener(ip[0] ,this.localTcpPort);
			this.localListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			this.localListener.Start();
			this.OnTcpListenerStart(new TcpListenerStartEventArgs(this.localTcpPort));
			while(this.isStart)
			{
				try
				{
					this.listenAllDone.Reset();
					AsyncCallback callback = new AsyncCallback(AcceptTcpClientCb);
					IAsyncResult iar = this.localListener.BeginAcceptTcpClient(callback, this.localListener);
					{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(this.GetHashCode() + "===============begin" + iar.GetHashCode(), sf);
					}
					this.listenAllDone.WaitOne();
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
			}
			this.OnTcpListenerStop(new TcpListenerStopEventArgs(this.localTcpPort));
		}
		
		private void AcceptTcpClientCb(IAsyncResult iar)
		{
			TcpListener lst = null;
			try
			{
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(this.GetHashCode() + "===============end" + iar.GetHashCode(), sf);
				}
				this.listenAllDone.Set();
				lst = (TcpListener)iar.AsyncState;
				if (lst == null || !this.isStart)
				{
					return;
				}
				TcpClient client = lst.EndAcceptTcpClient(iar);
				this.OnTcpListenerAcceptClient(new TcpAcceptEventArgs(client));
				ReadWriteObject readWriteObject = new ReadWriteObject(client, ConnectType.eClient);
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
		
		private void AsyncSendCb(IAsyncResult iar)
		{
			ReadWriteObject readWriteObject = null;
			try
			{
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("AsyncSendCb: ", sf);
				}	
				readWriteObject = (ReadWriteObject)iar.AsyncState;	
				if (readWriteObject.NetStream != null && readWriteObject.NetStream.CanWrite)
				{
					readWriteObject.NetStream.EndWrite(iar);
					this.OnTcpSend(new TcpSendEventArgs());
					readWriteObject = new ReadWriteObject(readWriteObject.Client, readWriteObject.ConnType);
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
				this.DisConnectClient(readWriteObject);
			}
		}	
		
		private void ConnectCb(IAsyncResult iar)
		{
			ReadWriteObject readWriteObject = null;
			try
			{
				readWriteObject = (ReadWriteObject)iar.AsyncState;
				readWriteObject.EventWait.Set();
				if (readWriteObject.Client.Connected)
				{
					readWriteObject.Client.EndConnect(iar);
				}
				this.OnTcpConnect(new TcpConnectEventArgs(readWriteObject));
//				if (readWriteObject.Client.Connected)
//				{
//					readWriteObject.InitNetWorkStream();
//					readWriteObject.SetReadBuff(readWriteObject.HeaderBuff);
//					this.Recve(readWriteObject);
//				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.DisConnectClient(readWriteObject);
			}
		}
		
		private void DisConnectClient(ReadWriteObject readWriteObject)
		{
			if (readWriteObject != null && readWriteObject.NetStream != null)
			{
				readWriteObject.NetStream.Close();
				readWriteObject.NetStream = null;
				if (readWriteObject.Client != null)
				{
					this.OnTcpDisConnect(new TcpDisConnectEventArgs(readWriteObject));
				}
			}
		}
		
		private void Recve(ReadWriteObject readWriteObject)
		{
			try
			{
				if (!this.isStart)
				{
					return;
				}
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
					//Error
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
							if (!trans.IsNeedResp)
							{
								this.SendAck(trans, readWriteObject.Client, readWriteObject.ConnType);
								this.OnTcpRecve(new TcpRecveEventArgs(trans, readWriteObject.Client));
								readWriteObject.IsHeader = true;	
								this.Recve(readWriteObject);
							}
							else
							{
								this.OnTcpRecve(new TcpRecveEventArgs(trans, readWriteObject.Client));
							}
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
				this.DisConnectClient(readWriteObject);
			}
		}
		
		#endregion
	}
}
