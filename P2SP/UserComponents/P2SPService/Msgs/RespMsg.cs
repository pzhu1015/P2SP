/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-12-23
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService.Msgs
{
	/// <summary>
	/// Description of RespTrans.
	/// </summary>
	[Serializable]
	public class RespMsg : BaseMsg
	{
		private MsgId reqId;
		
		public MsgId ReqId {
			get { return reqId; }
			set { reqId = value; }
		}
	
		public RespMsg(MsgId _msgId)
			:
			base(new MsgId(_msgId.FromId, _msgId.ToId, MsgType.eResp), false)
		{
			this.reqId = _msgId;
		}

        public override void OnMsgProcess(P2SPClient _client)
        {
            base.OnMsgProcess(_client);
            _client.RecveResp(this);
        }
    }
}
