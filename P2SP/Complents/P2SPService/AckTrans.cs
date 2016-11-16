/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-16
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of AckTrans.
	/// </summary>
	[Serializable]
	public class AckTrans : BaseTrans
	{
		private TransId reqId;
		
		public TransId ReqId {
			get { return reqId; }
			set { reqId = value; }
		}
		public AckTrans(TransId _transId)
			:
			base(TransType.eAck, new TransId(_transId.FromId, _transId.ToId, TransType.eAck))
		{
			this.reqId = _transId;
		}
	}
}
