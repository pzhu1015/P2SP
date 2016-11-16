/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-24
 * Time: 15:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace P2PService
{
	/// <summary>
	/// Description of TcpAcceptEventArgs.
	/// </summary>
	
	public delegate void TcpAcceptEventHandler(object sender, TcpAcceptEventArgs e);
	
	public class TcpAcceptEventArgs : EventArgs
	{
		private TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		public TcpAcceptEventArgs()
			:
			base()
		{
		}
		
		public TcpAcceptEventArgs(TcpClient _client)
			:
			base()
		{
			this.client = _client;
		}
	}
}
