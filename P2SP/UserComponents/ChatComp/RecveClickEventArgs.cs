/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-23
 * Time: 15:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of RecveClickEventArgs.
	/// </summary>
	
	public delegate void RecveClickEventHandler(object sender, RecveClickEventArgs e);
	
	public class RecveClickEventArgs : EventArgs
	{
		private object sendRecveFileControl;
		
		public object SendRecveFileControl {
			get { return sendRecveFileControl; }
			set { sendRecveFileControl = value; }
		}
		public RecveClickEventArgs()
		{
		}
		
		public RecveClickEventArgs(object o)
		{
			this.sendRecveFileControl = o;
		}
	}
}
