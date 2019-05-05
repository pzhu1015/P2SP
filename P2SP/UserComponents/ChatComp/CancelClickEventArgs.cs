/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-23
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of CancelClickEventArgs.
	/// </summary>
	
	public delegate void CancelClickEventHandler(object sender, CancelClickEventArgs e);
	
	public class CancelClickEventArgs : EventArgs
	{
		private object sendRecveFileControl;
		
		public object SendRecveFileControl {
			get { return sendRecveFileControl; }
			set { sendRecveFileControl = value; }
		}
		
		public CancelClickEventArgs(object o)
			:
			base()
		{
			this.sendRecveFileControl = o;
		}
	}
}
