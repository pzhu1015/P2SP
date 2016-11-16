/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-11
 * Time: 16:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of SendAudioResponseTrans.
	/// </summary>
	[Serializable]
	public class SendAudioResponseTrans : BaseTrans
	{
		public SendAudioResponseTrans(string _toUserId, string _fromUserId)
			:
			base(NetCommand.eSendAudioResponse, new TransId(_toUserId, _fromUserId, NetCommand.eSendAudioResponse))
		{
		}
	}
}
