/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-4
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of TaskFinishEventArgs.
	/// </summary>
	
	public delegate void TaskFinishEventHandler(object sender, TaskFinishEventArgs e);
	
	public class TaskFinishEventArgs : EventArgs
	{
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		public TaskFinishEventArgs()
		{
		}
		
		public TaskFinishEventArgs(long _length)
		{
			this.length = _length;
		}
	}
}
