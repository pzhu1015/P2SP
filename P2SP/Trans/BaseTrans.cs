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
using Helper;

namespace Trans
{
	public enum NetCommand
	{
		eInvalid,
		
		eAck,
		eSendMsg,
		eKickOff,
		eLogin,
		eLoginSuccess,
		eLoginFail,
		eOnline,
		eOffline,
		eLogout,
		eSendFile,
		eSendFileResponse,
		eSendFileBuffer,
		eSendFileBufferResponse,
		eSendFolder,
		eSendFolderResponse,
		eSendFileCancel,
		eRecveFileCancel,
		eVibration,
		eSendAudio,
		eSendAudioBuffer,
		eSendAudioResponse,
		eAudioCancel,
		eResp,
		
		eMax
	}
	/// <summary>
	/// Description of BaseTrans.
	/// </summary>
	[Serializable]
	public class BaseTrans
	{
		[NonSerialized]
		private object ackLocker;
		
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
		protected NetCommand command;
		
		public NetCommand Command {
			get { return command; }
			set { command = value; }
		}
		
		public BaseTrans(NetCommand _command, TransId _transId)
		{
			this.command = _command;
			this.transId = _transId;
		}
		
		public BaseTrans(NetCommand _command)
		{
			this.command = _command;
		}
		
		public void InitAckLocker()
		{
			if (this.command == NetCommand.eAck)
			{
				return;
			}
			this.ackLocker = new object();
		}
		
		public void WaitAck()
		{
			return;
			//if (this.command == NetCommand.eAck)
			//{
			//	return;
			//}
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Console("WaitAck: " + ackLocker.GetHashCode(), sf);
			//}
			//lock(ackLocker)
			//{
			//	bool rslt = Monitor.Wait(ackLocker, 30*1000);
			//	if (!rslt)
			//	{
			//		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//		System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//		DebugHelper.Console("Alarm wait timeout", sf);
			//	}
			//}
		}
		
		public BaseTrans WaitResp()
		{
			return null;
		}
		
		public void RecvAck()
		{
			return;
			//if (this.command == NetCommand.eAck)
			//{
			//	return;
			//}
			//{
			//	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			//	System.Diagnostics.StackFrame sf = st.GetFrame(0);
			//	DebugHelper.Console("RecvAck: " + ackLocker.GetHashCode(), sf);
			//}
			//lock(ackLocker)
			//{
			//	Monitor.Pulse(ackLocker);
			//}
		}
		
		public override string ToString()
		{
			if (this.command == NetCommand.eAck)
			{
				AckTrans ackTrans = this as AckTrans;
				return ackTrans.transId.ToString() + " - " + ackTrans.ReqId.ToString();
			}
			return this.transId.ToString();
		}
	}
}
