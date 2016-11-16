/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-9
 * Time: 11:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.ChatComp
{
	/// <summary>
	/// Description of EmptyControlsEventArgs.
	/// </summary>
	public delegate void EmptyControlsHandler(object sender, EmptyControlsEventArgs args);
	public class EmptyControlsEventArgs : EventArgs
	{
		public EmptyControlsEventArgs()
			:
			base()
		{
		}
	}
}
