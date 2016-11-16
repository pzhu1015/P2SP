/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-3
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of WriteBufferEventArgs.
	/// </summary>
	public delegate void WriteBufferHandler(object sender, WriteBufferEventArgs e);
	public class WriteBufferEventArgs : EventArgs
	{		
		private long writeSize;
		
		public long WriteSize {
			get { return writeSize; }
			set { writeSize = value; }
		}
		public WriteBufferEventArgs(long _writeSize)
			:
			base()
		{
			this.writeSize = _writeSize;
		}
	}
}
