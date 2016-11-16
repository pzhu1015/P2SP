/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of AccecptAudioClickEventArgs.
	/// </summary>
	public delegate void AccecptAudioClickHandler(object sender, AccecptAudioClickEventArgs args);
	public class AccecptAudioClickEventArgs : EventArgs
	{
		public AccecptAudioClickEventArgs()
			:
			base()
		{
		}
	}
}

