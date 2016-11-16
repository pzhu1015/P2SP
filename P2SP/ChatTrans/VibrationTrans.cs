/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-13
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Trans;

namespace ChatTrans
{
	/// <summary>
	/// Description of VibrationTrans.
	/// </summary>
	[Serializable]
	public class VibrationTrans : BaseTrans
	{
		public VibrationTrans(string _toUserId, string _fromUserId)
			:base(NetCommand.eVibration, new TransId(_toUserId, _fromUserId, NetCommand.eVibration))
		{
		}
	}
}
