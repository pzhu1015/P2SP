/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPStartEventArgs.
	/// </summary>
	public delegate void P2SPStartHandler(object sender, P2SPStartEventArgs args);
	public class P2SPStartEventArgs : EventArgs
	{
		private int port;
		
		public int Port {
			get { return port; }
			set { port = value; }
		}
		public P2SPStartEventArgs(int _port)
			:
			base()
		{
			this.port = _port;
		}
	}
}
