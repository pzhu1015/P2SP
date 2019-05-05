/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-8-21
 * Time: 17:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of UserControlRemoveEventArgs.
	/// </summary>
	public delegate void UserControlRemoveHandler(object sender, UserControlRemoveEventArgs args);
	public class UserControlRemoveEventArgs : EventArgs
	{
		public UserControlRemoveEventArgs()
			:
			base()
		{
		}
	}
}
