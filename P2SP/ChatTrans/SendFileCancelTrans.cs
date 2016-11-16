/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-8
 * Time: 20:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendFileCancelTrans.
	/// </summary>
	[Serializable]
	public class SendFileCancelTrans : BaseTrans
	{
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		public SendFileCancelTrans(string _fileId, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendFileCancel, new TransId(_toUserId, _fromUserId, NetCommand.eSendFileCancel))
		{
			this.fileId = _fileId;
		}
	}
}
