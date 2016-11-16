/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-1
 * Time: 11:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SendFileService
{
	/// <summary>
	/// Description of CompleteWriteEventArgs.
	/// </summary>
	public delegate void CompleteWriteHandler (object sender, CompleteWriteEventArgs e);
	public class CompleteWriteEventArgs : EventArgs
	{		
		public CompleteWriteEventArgs()
			:
			base()
		{
		}
	}
}
