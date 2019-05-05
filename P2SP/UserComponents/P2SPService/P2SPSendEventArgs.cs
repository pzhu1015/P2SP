/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of SendEventArgs.
	/// </summary>
	public delegate void P2SPSendEventHandler(object sender, P2SPSendEventArgs args);
	public class P2SPSendEventArgs : EventArgs
	{
		public P2SPSendEventArgs()
			:
			base()
		{
		}
	}
}
