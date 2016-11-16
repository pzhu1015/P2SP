/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;
using Chat;

namespace ChatTrans
{
	/// <summary>
	/// Description of OnlineTrans.
	/// </summary>
	[Serializable]
	public class OnlineTrans : BaseTrans
	{
		private ChatFriend friend;
		
		public ChatFriend Friend {
			get { return friend; }
			set { friend = value; }
		}

		public OnlineTrans(ChatFriend _friend, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eOnline, new TransId(_toUserId, _fromUserId, NetCommand.eOnline))
		{
			this.friend = _friend;
		}
	}
}
