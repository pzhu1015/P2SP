/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-16
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService.Msgs
{
	/// <summary>
	/// Description of AckMsg.
	/// </summary>
	[Serializable]
	public class AckMsg : BaseMsg
	{
		private MsgId reqId;
		
		public MsgId ReqId {
			get { return reqId; }
			set { reqId = value; }
		}
		public AckMsg(MsgId _msgId)
			:
			base(new MsgId(_msgId.FromId, _msgId.ToId, MsgType.eAck), false)
		{
			this.reqId = _msgId;
		}

        public override void OnMsgProcess(P2SPClient _client)
        {
            //base.OnMsgProcess(_client);
            _client.RecveAck(this);
        }
    }
}
