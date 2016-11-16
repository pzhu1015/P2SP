/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-1
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendFileResponseTrans.
	/// </summary>
	[Serializable]
	public class SendFileResponseTrans : BaseTrans
	{
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		public SendFileResponseTrans(string _fileId, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFileResponse, new TransId(_toUserId, _fromUserId, NetCommand.eSendFileResponse))
		{
			this.fileId = _fileId;
		}
	}
}
