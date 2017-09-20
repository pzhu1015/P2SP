/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Complents.P2SPService.Msgs;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPRecveEventArgs.
	/// </summary>
	public delegate void P2SPRecveHandler(object sender, P2SPRecveEventArgs args);
	public class P2SPRecveEventArgs : EventArgs
	{
		private BaseMsg msg;
		
		public BaseMsg Msg {
			get { return msg; }
			set { msg = value; }
		}
		
		public P2SPRecveEventArgs(BaseMsg _msg)
			:
			base()
		{
			this.msg = _msg;
		}
	}
}
