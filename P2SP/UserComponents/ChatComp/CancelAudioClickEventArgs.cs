/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of CancelAudioClickEventArgs.
	/// </summary>
	public delegate void CancelAudioClickHandler(object sender, CancelAudioClickEventArgs args);
	public class CancelAudioClickEventArgs : EventArgs
	{
		public CancelAudioClickEventArgs()
			:
			base()
		{
		}
	}
}
