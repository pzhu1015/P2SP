/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-26
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace P2PService
{
	/// <summary>
	/// Description of TcpConnectEventArgs.
	/// </summary>
	public delegate void TcpConnectEventHandler(object sender, TcpConnectEventArgs e);
	
	public class TcpConnectEventArgs : EventArgs
	{
		private ReadWriteObject readWriteObj;
		
		public ReadWriteObject ReadWriteObj {
			get { return readWriteObj; }
			set { readWriteObj = value; }
		}
		
		public TcpConnectEventArgs()
		{
		}
		
		public TcpConnectEventArgs(ReadWriteObject _readWriteObj)
		{
			this.readWriteObj = _readWriteObj;
		}
	}
}
