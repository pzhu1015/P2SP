/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-28
 * Time: 17:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of RecveFileCancelTrans.
	/// </summary>
	[Serializable]
	public class RecveFileCancelTrans : BaseTrans
	{
		private string fileId;
		
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}
		
		public RecveFileCancelTrans(string _fileId, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eRecveFileCancel, new TransId(_toUserId, _fromUserId, NetCommand.eRecveFileCancel))
		{
			this.fileId = _fileId;
		}
	}
}
