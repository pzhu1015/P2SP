/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/13 星期四
 * Time: 上午 11:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of P2SPAcceptEventArgs.
	/// </summary>
	public delegate void P2SPAcceptHandler(object sender, P2SPAcceptEventArgs args);
	public class P2SPAcceptEventArgs : EventArgs
	{
		private System.Net.Sockets.TcpClient client;
		
		public System.Net.Sockets.TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		public P2SPAcceptEventArgs(TcpClient _client)
			:
			base()
		{
			this.client = _client;
		}
	}
}
