/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 15:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of LoginTrans.
	/// </summary>
	[Serializable]
	public class LoginTrans : BaseTrans
	{
		private string userId;
		private string password;
		
		public string Password {
			get { return password; }
			set { password = value; }
		}
		
		public string UserId {
			get { return userId; }
			set { userId = value; }
		}
		
		public LoginTrans(string _userId, string _password)
			:
			base(NetCommand.eLogin, new TransId("_server_", _userId, NetCommand.eLogin))
		{
			this.userId = _userId;
			this.password = _password;
		}
	}
}
