/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-28
 * Time: 11:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendFolderTrans.
	/// </summary>
	[Serializable]
	public class SendFolderTrans : BaseTrans
	{
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}
		
		public SendFolderTrans(string _fileId, string _subName, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFolder, new TransId(_toUserId, _fromUserId, NetCommand.eSendFolder))
		{
			this.fileId = _fileId;
			this.subName = _subName;
		}
	}
}
