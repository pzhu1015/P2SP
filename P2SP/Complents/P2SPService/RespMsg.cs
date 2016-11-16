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
	public class RespMsg : BaseMsg
	{
		private MsgId reqId;
		
		public MsgId ReqId {
			get { return reqId; }
			set { reqId = value; }
		}
		
		private BaseMsg msg;
		
		public BaseMsg Msg {
			get { return msg; }
			set { msg = value; }
		}
	
		public RespMsg(MsgId _msgId, BaseMsg _msg)
			:
			base(MsgType.eResp, new MsgId(_msgId.FromId, _msgId.ToId, MsgType.eResp))
		{
			this.reqId = _msgId;
			this.msg = _msg;
		}

        public override void OnMsgProcess(P2SPClient _client)
        {
            base.OnMsgProcess(_client);
            _client.RecveResp(this);
        }
    }
}
