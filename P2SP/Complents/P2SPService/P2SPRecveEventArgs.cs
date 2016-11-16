/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPRecveEventArgs.
	/// </summary>
	public delegate void P2SPRecveHandler(object sender, P2SPRecveEventArgs args);
	public class P2SPRecveEventArgs : EventArgs
	{
		private BaseTrans trans;
		
		public BaseTrans Trans {
			get { return trans; }
			set { trans = value; }
		}
		
		public P2SPRecveEventArgs(BaseTrans _trans)
			:
			base()
		{
			this.trans = _trans;
		}
	}
}
