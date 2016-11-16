/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 9:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of CloseAudioPanelEventArgs.
	/// </summary>
	public delegate void CloseAudioPanelHandler(object sender, CloseAudioPanelEventArgs args);
	public class CloseAudioPanelEventArgs : EventArgs
	{
		public CloseAudioPanelEventArgs()
			:
			base()
		{
		}
	}
}
