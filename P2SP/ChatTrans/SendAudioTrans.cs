/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 9:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendAudioTrans.
	/// </summary>
	[Serializable]
	public class SendAudioTrans : BaseTrans
	{
		public SendAudioTrans(string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendAudio, new TransId(_toUserId, _fromUserId, NetCommand.eSendAudio))
		{
		}
	}
}
