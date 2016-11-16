/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 16:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of KickOffTrans.
	/// </summary>
	[Serializable]
	public class KickOffTrans : BaseTrans
	{
		private int errno;
		
		public int Errno {
			get { return errno; }
			set { errno = value; }
		}
		
		private string errmsg;
		
		public string Errmsg {
			get { return errmsg; }
			set { errmsg = value; }
		}
		public KickOffTrans(string _errmsg)
			:
			base(NetCommand.eKickOff)
		{
			this.errmsg = _errmsg;
		}
		
		public KickOffTrans(int _errno)
			:
			base(NetCommand.eKickOff)
		{
			this.errno = _errno;
		}
	}
}
