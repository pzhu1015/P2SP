/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-4
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of TaskMgrMonitorEventArgs.
	/// </summary>
	
	public delegate void TaskMgrMonitorEventHandler(object sender, TaskMgrMonitorEventArgs e);
	
	public class TaskMgrMonitorEventArgs : EventArgs 
	{
		private long speed;
		
		public long Speed {
			get { return speed; }
			set { speed = value; }
		}
		
		public TaskMgrMonitorEventArgs()
		{
		}
		
		public TaskMgrMonitorEventArgs(long _speed)
		{
			this.speed = _speed;
		}
	}
}
