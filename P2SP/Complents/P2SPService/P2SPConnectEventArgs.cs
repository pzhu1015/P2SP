/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 10:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of P2SPConnectEventArgs.
	/// </summary>
	public delegate void P2SPConnectHandler(object sender, P2SPConnectEventArgs args);
	public class P2SPConnectEventArgs : EventArgs
	{
		private TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		public P2SPConnectEventArgs(TcpClient _client)
			:
			base()
		{
			this.client = _client;
		}
	}
}
