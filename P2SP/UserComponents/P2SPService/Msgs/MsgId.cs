/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-16
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService.Msgs
{
	/// <summary>
	/// Description of TransId.
	/// </summary>
	[Serializable]
	public class MsgId
	{
		private string toId;
		
		public string ToId {
			get { return toId; }
			set { toId = value; }
		}
		private string fromId;
		
		public string FromId {
			get { return fromId; }
			set { fromId = value; }
		}
		
		private long seqno;
		
		public long Seqno {
			get { return seqno; }
			set { seqno = value; }
		}
		
		private MsgType type;
		
		public MsgType Type {
			get { return type; }
			set { type = value; }
		}
        
        private string clientId;

        public string ClientId{
            get { return clientId; }
            set { clientId = value; }
        }


		public MsgId(string _toId, string _fromId, MsgType _type)
		{
			this.toId = _toId;
			this.fromId = _fromId;
			this.type = _type;
			this.seqno = MsgIdMgr.Instance.GetSeqno();
            this.clientId = this.fromId;
		}
		
		public override string ToString()
		{
			return this.type + "; " + this.toId + "; " + this.fromId + "; " + this.seqno;
		}
	}
}
