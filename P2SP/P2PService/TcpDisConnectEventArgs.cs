/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-24
 * Time: 13:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;

namespace P2PService
{
	/// <summary>
	/// Description of ClientDisConnectEventArgs.
	/// </summary>
	
	public delegate void TcpDisConnectEventHandler(object sender, TcpDisConnectEventArgs e);
	
	public class TcpDisConnectEventArgs : EventArgs
	{
		private ReadWriteObject readWriteObj;
		
		public ReadWriteObject ReadWriteObj {
			get { return readWriteObj; }
			set { readWriteObj = value; }
		}
		
		public TcpDisConnectEventArgs()
		{
		}
		
		public TcpDisConnectEventArgs(ReadWriteObject _readWriteObject)
		{
			this.readWriteObj = _readWriteObject;
		}
	}
}
