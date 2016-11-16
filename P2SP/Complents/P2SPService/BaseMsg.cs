/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 15:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Net.Sockets;
using Helper;

namespace Complents.P2SPService
{

    public delegate void MsgProcessHandler(object sender, EventArgs args);

    public enum MsgType
	{
		eInvalid,
		
		eAck,
		eResp,
		
		eMax
	}
	/// <summary>
	/// Description of BaseTrans.
	/// </summary>
	[Serializable]
	public class BaseMsg
	{
		[NonSerialized]
		private object waitLocker;
		
		protected bool isNeedResp = false;
		
		public bool IsNeedResp {
			get { return isNeedResp; }
			set { isNeedResp = value; }
		}
		
		protected MsgId msgId;
		
		public MsgId MsgId {
			get { return msgId; }
			set { msgId = value; }
		}
		
		protected MsgType type;
		
		public MsgType Type {
			get { return type; }
			set { type = value; }
		}
		
		[NonSerialized]
		protected TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		[NonSerialized]
		protected RespMsg resp;
		
		public RespMsg Resp {
			get { return resp; }
			set { resp = value; }
		}

		
		public BaseMsg(MsgType _type, MsgId _msgId)
		{
			this.type = _type;
			this.msgId = _msgId;
			if (this.type != MsgType.eAck)
			{
				this.waitLocker = new object();
			}
		}

        /// <summary>
        /// msg recve then to process it
        /// </summary>
        /// <param name="_client"></param>
        public virtual void OnMsgProcess(P2SPClient _client)
        {
            _client.SendAck(this);
        }
		
		public bool WaitAck()
		{
			if (this.type == MsgType.eAck)
			{
				return true;
			}
			lock(waitLocker)
			{
				bool rslt = Monitor.Wait(waitLocker, 30*1000);
				if (!rslt)
				{
					return false;
				}
			}
			return true;
		}
		
		public RespMsg WaitResp()
		{
			lock(waitLocker)
			{
				Monitor.Wait(waitLocker);
			}
			return this.resp;
		}
		
		public void RecveResp(RespMsg _msg)
		{
			this.resp = _msg;
			lock(waitLocker)
			{
				Monitor.Pulse(waitLocker);
			}
		}
		
		public void RecvAck()
		{
			if (this.type == MsgType.eAck)
			{
				return;
			}
			lock(waitLocker)
			{
				Monitor.Pulse(waitLocker);
			}
		}
		
		public override string ToString()
		{
			if (this.type == MsgType.eAck)
			{
				AckMsg ackMsg = this as AckMsg;
				return ackMsg.msgId.ToString() + " - " + ackMsg.ReqId.ToString();
			}
			return this.msgId.ToString();
		}
	}
}
