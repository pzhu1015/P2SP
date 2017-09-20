/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-10-14
 * Time: 16:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Complents.P2SPService
{
	/// <summary>
	/// Description of TransIdMgr.
	/// </summary>
	public sealed class MsgIdMgr
	{
		private static MsgIdMgr instance = new MsgIdMgr();
		
		private long id = 0;
		
		public static MsgIdMgr Instance {
			get {
				return instance;
			}
		}
		
		private MsgIdMgr()
		{
		}
		
		public long GetSeqno()
		{
			long nextId = System.Threading.Interlocked.Increment(ref this.id);
			return nextId;
		}
	}
}
