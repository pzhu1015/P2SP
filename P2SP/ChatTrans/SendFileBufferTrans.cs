/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-1
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;
using SendFileService;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendFileBufferTrans.
	/// </summary>
	[Serializable]
	public class SendFileBufferTrans : BaseTrans
	{
		private SendType type;
		
		public SendType Type {
			get { return type; }
			set { type = value; }
		}
		
		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}
		
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
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
		
		public SendFileBufferTrans(string _subName, long _length, string _fileId, long _offset, byte[] _buffer, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFileBuffer, new TransId(_toUserId, _fromUserId, NetCommand.eSendFileBuffer))
		{
			this.type = SendType.eFolder;
			this.subName = _subName;
			this.fileId = _fileId;
			this.offset = _offset;
			this.buffer = _buffer;
			this.length = _length;
		}
		
		public SendFileBufferTrans(string _fileId, long _offset, byte[] _buffer, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFileBuffer, new TransId(_toUserId, _fromUserId, NetCommand.eSendFileBuffer))
		{
			this.type = SendType.eFile;
			this.fileId = _fileId;
			this.offset = _offset;
			this.buffer = _buffer;
		}
	}
}
