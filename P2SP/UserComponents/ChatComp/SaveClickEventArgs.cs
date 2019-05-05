/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-23
 * Time: 15:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of SaveClickEventArgs.
	/// </summary>
	
	public delegate void SaveClickEventHandler(object sender, SaveClickEventArgs e);
	
	public class SaveClickEventArgs : EventArgs
	{
		private object sendRecveFileControl;
		
		public object SendRecveFileControl {
			get { return sendRecveFileControl; }
			set { sendRecveFileControl = value; }
		}
		
		public SaveClickEventArgs()
		{
		}
		
		public SaveClickEventArgs(object o)
		{
			this.sendRecveFileControl = o;
		}
	}
}
