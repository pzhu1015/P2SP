/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-4
 * Time: 10:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
namespace DownLoadService
{
	/// <summary>
	/// Description of TaskMonitorEventArgs.
	/// </summary>
	
	public delegate void TaskMonitorEventHandler(object sender, TaskMonitorEventArgs e);
	
	public class TaskMonitorEventArgs : EventArgs
	{
		private DownLoadStatus status;
		
		public DownLoadStatus Status {
			get { return status; }
			set { status = value; }
		}
			
		private long speed;
		
		public long Speed {
			get { return speed; }
			set { speed = value; }
		}
		
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		private long crtLength;
		
		public long CrtLength {
			get { return crtLength; }
			set { crtLength = value; }
		}
		
		private int progress;
		
		public int Progress {
			get { return progress; }
			set { progress = value; }
		}
		
		public TaskMonitorEventArgs()
		{
		}
		
		public TaskMonitorEventArgs(DownLoadStatus _status, long _speed, long _length, long _crtLength, int _progress)
		{
			this.status = _status;
			this.speed =_speed;
			this.length = _length;
			this.crtLength = _crtLength;
			this.progress = _progress;
		}
	}
}
