/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-11
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of AudioCancelTrans.
	/// </summary>
	[Serializable]
	public class AudioCancelTrans : BaseTrans
	{
		public AudioCancelTrans(string _toUserId, string _fromUserId)
			:
			base(NetCommand.eAudioCancel, new TransId(_toUserId, _fromUserId, NetCommand.eAudioCancel))
		{
		}
	}
}
