/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-10-14
 * Time: 16:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Trans
{
	/// <summary>
	/// Description of TransIdMgr.
	/// </summary>
	public sealed class TransIdMgr
	{
		private static TransIdMgr instance = new TransIdMgr();
		
		private int id = 0;
		
		public static TransIdMgr Instance {
			get {
				return instance;
			}
		}
		
		private TransIdMgr()
		{
		}
		
		public int GetSeqno()
		{
			int nextId = System.Threading.Interlocked.Increment(ref this.id);
			return nextId;
		}
	}
}
