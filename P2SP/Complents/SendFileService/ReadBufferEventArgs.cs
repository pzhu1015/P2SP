/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-24
 * Time: 12:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of ReadBufferEventArgs.
	/// </summary>
	
	public delegate void ReadBufferHandler(object sender, ReadBufferEventArgs e);
	
	public class ReadBufferEventArgs :EventArgs
	{
		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}

		private long offset;
		
		public long Offset {
			get { return offset; }
			set { offset = value; }
		}
		
		private byte[] buffer;
		
		public byte[] Buffer {
			get { return buffer; }
			set { buffer = value; }
		}
		
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		public ReadBufferEventArgs(string _subName, long _length, long _offset, byte[] _buffer)
			:
			base()
		{
			this.subName = _subName;
			this.length = _length;
			this.offset = _offset;
			this.buffer = _buffer;
		}
		
		public ReadBufferEventArgs(long _offset, byte[] _buffer)
		:
		base()
		{
			this.offset = _offset;
			this.buffer = _buffer;
		}
	}
}
