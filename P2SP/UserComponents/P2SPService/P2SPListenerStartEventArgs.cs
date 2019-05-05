/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 下午 3:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of P2SPTcpListenerStartEventArgs.
	/// </summary>
	public delegate void P2SPListenerStartHandler(object sender, P2SPListenerStartEventArgs args);
	public class P2SPListenerStartEventArgs : EventArgs
	{
		public P2SPListenerStartEventArgs()
			:
			base()
		{
		}
	}
}
