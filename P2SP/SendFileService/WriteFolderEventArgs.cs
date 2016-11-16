/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-28
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SendFileService
{
	/// <summary>
	/// Description of WriteFolderEventArgs.
	/// </summary>
	
	public delegate void WriteFolderHandler(object sender, WriteFolderEventArgs args);
	public class WriteFolderEventArgs : EventArgs
	{
		public WriteFolderEventArgs()
			:
			base()
		{
		}
	}
}
