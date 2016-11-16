/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 下午 3:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPTcpListenerStopEventArgs.
	/// </summary>
	public delegate void P2SPListenerStopHandler(object sender, P2SPListenerStopEventArgs args);
	public class P2SPListenerStopEventArgs : EventArgs
	{
		public P2SPListenerStopEventArgs()
			:
			base()
		{
		}
	}
}
