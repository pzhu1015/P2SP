/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-8
 * Time: 16:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of CloseFilePanelEventArgs.
	/// </summary>
	public delegate void CloseFilePanelHandler(object sender, CloseFilePanelEventArgs args);
	public class CloseFilePanelEventArgs : EventArgs
	{
		public CloseFilePanelEventArgs()
			:
			base()
		{
		}
	}
}
