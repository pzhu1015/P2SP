/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of P2SPStopEventArgs.
	/// </summary>
	public delegate void P2SPStopHandler(object sender, P2SPStopEventArgs args);
	public class P2SPStopEventArgs : EventArgs
	{
		public P2SPStopEventArgs()
			:
			base()
		{
		}
	}
}
