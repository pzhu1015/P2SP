/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-11
 * Time: 16:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendAudioBufferTrans.
	/// </summary>
	[Serializable]
	public class SendAudioBufferTrans : BaseTrans
	{
		private byte[] buffer;
		
		public byte[] Buffer {
			get { return buffer; }
			set { buffer = value; }
		}
		public SendAudioBufferTrans(byte[] _buff, string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendAudioBuffer, new TransId(_toUserId, _fromUserId, NetCommand.eSendAudioBuffer))
		{
			this.buffer = _buff;
		}
	}
}
