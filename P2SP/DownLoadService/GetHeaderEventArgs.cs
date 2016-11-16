/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-4
 * Time: 11:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of GetHeaderEventArgs.
	/// </summary>
	
	public delegate void GetHeaderEventHandler(object sender, GetHeaderEventArgs e);
	
	public class GetHeaderEventArgs : EventArgs
	{
		private bool rslt;
		
		public bool Rslt {
			get { return rslt; }
			set { rslt = value; }
		}
		
		public GetHeaderEventArgs()
		{
		}
		
		public GetHeaderEventArgs(bool _rslt)
		{
			this.rslt = _rslt;
		}
	}
}
