/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-4
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of TaskStartEventArgs.
	/// </summary>
	
	public delegate void TaskStartEventHandler(object sender, TaskStartEventArgs e);
	
	public class TaskStartEventArgs : EventArgs
	{	
		public TaskStartEventArgs()
		{
		}
	}
}
