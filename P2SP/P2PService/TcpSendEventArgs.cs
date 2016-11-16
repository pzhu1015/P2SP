/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-6-24
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace P2PService
{
	/// <summary>
	/// Description of ServerSendEventArgs.
	/// </summary>
	
	public delegate void TcpSendEventHandler(object sender, TcpSendEventArgs e);
	
	public class TcpSendEventArgs : EventArgs
	{
		public TcpSendEventArgs()
		{
		}
	}
}
