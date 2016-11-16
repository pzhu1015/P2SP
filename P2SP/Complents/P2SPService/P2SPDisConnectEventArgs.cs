/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPDisConnectEventArgs.
	/// </summary>
	public delegate void P2SPDisConnectHandler(object sender, P2SPDisConnectEventArgs args);
	public class P2SPDisConnectEventArgs : EventArgs
	{
		private TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		public P2SPDisConnectEventArgs(TcpClient _client)
			:
			base()
		{
			this.client = _client;
		}
	}
}
