/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 15:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of LogoutTrans.
	/// </summary>
	[Serializable]
	public class LogoutTrans : BaseTrans
	{
		private string userId;
		
		public string UserId {
			get { return userId; }
			set { userId = value; }
		}
		public LogoutTrans(string _userId)
			:
			base(NetCommand.eLogout)
		{
		}
	}
}
