/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-1
 * Time: 11:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

using Trans;
using SendFileService;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendFileTrans.
	/// </summary>
	[Serializable]
	public class SendFileTrans : BaseTrans
	{
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		private SendType type;
		
		public SendType Type {
			get { return type; }
			set { type = value; }
		}
		
		private string name;
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		private Image image;
		
		public Image Image {
			get { return image; }
			set { image = value; }
		}
		
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		private int count;
		
		public int Count {
			get { return count; }
			set { count = value; }
		}
		
		
		public SendFileTrans(string _fileId, string _name, Image _image, long _length, int _count, SendType _type, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFile, new TransId(_toUserId, _fromUserId, NetCommand.eSendFile))
		{
			this.fileId = _fileId;
			this.name = _name;
			this.image = _image;
			this.length = _length;
			this.count = _count;
			this.type = _type;
		}
	}
}
