/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-24
 * Time: 12:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using Trans;

namespace P2PService
{
	/// <summary>
	/// Description of ServerRecveEventArgs.
	/// </summary>
	
	
	public delegate void TcpRecveEventHandler(object sender, TcpRecveEventArgs e);
	
	public class TcpRecveEventArgs : EventArgs
	{		
		private TcpClient client;
		
		public TcpClient Client {
			get { return client; }
			set { client = value; }
		}
		
		private BaseTrans trans;
		
		public BaseTrans Trans {
			get { return trans; }
			set { trans = value; }
		}
		
		
		public TcpRecveEventArgs()
		{
		}
		
		public TcpRecveEventArgs(BaseTrans _trans, TcpClient _client)
		{
			this.trans = _trans;
			this.client = _client;
		}
	}
}
