/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendMsgTrans.
	/// </summary>
	[Serializable]
	public class SendMsgTrans : BaseTrans
	{
		private string date;
		
		public string Date {
			get { return date; }
			set { date = value; }
		}
		
		public byte[] buff;
		
		public byte[] Buff {
			get { return buff; }
			set { buff = value; }
		}
		
		private string msg;
		
		public string Msg {
			get { return msg; }
			set { msg = value; }
		}
	
		public SendMsgTrans(string _date, string _msg, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendMsg, new TransId(_toUserId, _fromUserId, NetCommand.eSendMsg))
		{
			this.date = _date;
			this.msg = _msg;
		}
	}
}
