/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-12-23
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of RespTrans.
	/// </summary>
	[Serializable]
	public class RespTrans : BaseTrans
	{
		private TransId reqId;
		
		public TransId ReqId {
			get { return reqId; }
			set { reqId = value; }
		}
		
		private BaseTrans resp;
		
		public BaseTrans Resp {
			get { return resp; }
			set { resp = value; }
		}
	
		public RespTrans(TransId _transId, BaseTrans _trans)
			:
			base(TransType.eResp, new TransId(_transId.FromId, _transId.ToId, TransType.eResp))
		{
			this.reqId = _transId;
			this.resp = _trans;
		}
	}
}
