/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-29
 * Time: 16:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of OfflineTrans.
	/// </summary>
	[Serializable]
	public class OfflineTrans : BaseTrans
	{
		public OfflineTrans(string _toUserId, string _fromUserId)
			:
			base(NetCommand.eOffline, new TransId(_toUserId, _fromUserId, NetCommand.eOffline))
		{
		}
	}
}
