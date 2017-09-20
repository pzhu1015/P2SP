/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 15:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService.Msgs
{
	/// <summary>
	/// Description of LoginMsg.
	/// </summary>
	[Serializable]
	public class LoginMsg : BaseMsg
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
		
		public LoginMsg(string _userId, string _password)
			:
			base(new MsgId("_server_", _userId, MsgType.eLogin), true)
		{
			this.userId = _userId;
			this.password = _password;
		}

        public override void OnMsgProcess(P2SPClient _client)
        {
            base.OnMsgProcess(_client);
        }
    }
}
