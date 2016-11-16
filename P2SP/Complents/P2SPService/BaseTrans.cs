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

    public delegate void TransProcessHandler(object sender, EventArgs args);

    public enum TransType
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
	public class BaseTrans
	{

        public event TransProcessHandler TransProcess;
		[NonSerialized]
		private object waitLocker;
		
		protected bool isNeedResp = false;
		
		public bool IsNeedResp {
			get { return isNeedResp; }
			set { isNeedResp = value; }
		}
		
		protected TransId transId;
		
		public TransId TransId {
			get { return transId; }
			set { transId = value; }
		}
		
		protected TransType type;
		
		public TransType Type {
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
		protected BaseTrans resp;
		
		public BaseTrans Resp {
			get { return resp; }
			set { resp = value; }
		}

		
		public BaseTrans(TransType _type, TransId _transId)
		{
			this.type = _type;
			this.transId = _transId;
			if (this.type != TransType.eAck)
			{
				this.waitLocker = new object();
			}
		}

        public virtual void initEvent()
        {
            this.TransProcess += new TransProcessHandler(BaseTrans_TransProcess);
        }

        private void BaseTrans_TransProcess(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTransProcess(EventArgs args)
        {
            this.initEvent();
            if (this.TransProcess != null)
            {
                this.TransProcess(this, args);
            }
        }
		
		public bool WaitAck()
		{
			if (this.type == TransType.eAck)
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
		
		public BaseTrans WaitResp()
		{
			lock(waitLocker)
			{
				Monitor.Wait(waitLocker);
			}
			return this.resp;
		}
		
		public void RecveResp(BaseTrans _trans)
		{
			this.resp = _trans;
			lock(waitLocker)
			{
				Monitor.Pulse(waitLocker);
			}
		}
		
		public void RecvAck()
		{
			if (this.type == TransType.eAck)
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
			if (this.type == TransType.eAck)
			{
				AckTrans ackTrans = this as AckTrans;
				return ackTrans.transId.ToString() + " - " + ackTrans.ReqId.ToString();
			}
			return this.transId.ToString();
		}
	}
}
