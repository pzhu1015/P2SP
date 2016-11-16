/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-12-23
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Trans
{
	/// <summary>
	/// Description of RespTrans.
	/// </summary>
	[Serializable]
	public class RespTrans : BaseTrans
	{
		private BaseTrans resp;
		
		public BaseTrans Resp {
			get { return resp; }
			set { resp = value; }
		}
	
		public RespTrans(string _toUserId, string _fromUserId)
			:
			base(NetCommand.eResp, new TransId(_toUserId, _fromUserId, NetCommand.eResp))
		{
		}
	}
}
