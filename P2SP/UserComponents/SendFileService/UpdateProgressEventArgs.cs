/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-13
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.SendFileService
{
	/// <summary>
	/// Description of UpdateProgressEventArgs.
	/// </summary>
	public delegate void UpdateProgressHandler(object sender, UpdateProgressEventArgs args);
	public class UpdateProgressEventArgs : EventArgs
	{
		private long size;
		
		public long Size {
			get { return size; }
			set { size = value; }
		}
		
		public UpdateProgressEventArgs(long _size)
			:
			base()
		{
			this.size = _size;
		}
	}
}
