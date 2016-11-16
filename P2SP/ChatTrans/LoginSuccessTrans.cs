/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-4-21
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Trans;
using Chat;

namespace ChatTrans
{
	/// <summary>
	/// Description of LoginSuccessTrans.
	/// </summary>
	[Serializable]
	public class LoginSuccessTrans : BaseTrans
	{
		private ChatUser user;
		
		public ChatUser User {
			get { return user; }
			set { user = value; }
		}
		
		public LoginSuccessTrans(ChatUser _user)
			:
			base(NetCommand.eLoginSuccess, new TransId(_user.UserId, "_server_", NetCommand.eLoginSuccess))
		{
			this.user = _user;
		}
	}
}
