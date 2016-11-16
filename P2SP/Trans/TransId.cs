/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-7-16
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Trans
{
	/// <summary>
	/// Description of TransId.
	/// </summary>
	[Serializable]
	public class TransId
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
		
		private int seqno;
		
		public int Seqno {
			get { return seqno; }
			set { seqno = value; }
		}
		
		private NetCommand command;
		
		public NetCommand Command {
			get { return command; }
			set { command = value; }
		}
		
		public TransId(string _toId, string _fromId, NetCommand _command)
		{
			this.toId = _toId;
			this.fromId = _fromId;
			this.command = _command;
			this.seqno = TransIdMgr.Instance.GetSeqno();
		}
		
//		public override int GetHashCode()
//		{
//			return (this.toId + "_" + this.seqno.ToString() + "_" + this.fromId).GetHashCode();
//		}
		
		public override string ToString()
		{
			return this.command + "; " + this.toId + "; " + this.fromId + "; " + this.seqno;
		}
		
//		public override bool Equals(object obj)
//		{
//			TransId target = obj as TransId;
//			return (this.toId == target.toId &&
//			    	this.fromId == target.fromId &&
//			    	this.seqno == target.seqno);
//		}
	}
}
