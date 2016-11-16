/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-21
 * Time: 16:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of CompleteReadEventArgs.
	/// </summary>
	
	public delegate void CompleteReadHandler(object sender, CompleteReadEventArgs args);
	public class CompleteReadEventArgs : EventArgs
	{	
		private SendType subType;
		
		public SendType SubType {
			get { return subType; }
			set { subType = value; }
		}
		

		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}
		
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
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
		
		public CompleteReadEventArgs(long _offset, byte[] _buffer)
			:
			base()
		{
			this.offset = _offset;
			this.buffer = _buffer;
		}
		
		public CompleteReadEventArgs(string _subName, long _length, long _offset, byte[] _buffer)
			:
			base()
		{
			this.subType = SendType.eFile;
			this.length = _length;
			this.offset = _offset;
			this.buffer = _buffer;
			this.subName = _subName;
		}
		
		public CompleteReadEventArgs(string _subName)
			:
			base()
		{
			this.subType = SendType.eFolder;
			this.subName = _subName;
		}
	}
}
