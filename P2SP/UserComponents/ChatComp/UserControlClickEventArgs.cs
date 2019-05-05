/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-26
 * Time: 9:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of UserControlClickEventArgs.
	/// </summary>
	public delegate void UserControlClickHandler(object sender, UserControlClickEventArgs args);
	public class UserControlClickEventArgs : EventArgs
	{
		public UserControlClickEventArgs()
			:
			base()
		{
		}
	}
}
