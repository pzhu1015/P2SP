/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-4-21
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Trans;
using Chat;

namespace ChatTrans
{
	/// <summary>
	/// Description of LoginFailTrans.
	/// </summary>
	[Serializable]
	public class LoginFailTrans : BaseTrans
	{
		private int errno;
		
		public int Errno {
			get { return errno; }
			set { errno = value; }
		}
		
		public LoginFailTrans(int _errno)
			:
			base(NetCommand.eLoginFail)
		{
			this.errno = _errno;
		}
	}
}
