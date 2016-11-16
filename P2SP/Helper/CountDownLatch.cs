/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-15
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Threading;

namespace Helper
{
	/// <summary>
	/// Description of CountDownLatch.
	/// </summary>
	public class CountDownLatch
	{
		private static object locker = new object();
		private int count;
		
		public int Count {
			get { return count; }
			set { count = value; }
		}
		
		public CountDownLatch(int _count)
		{
			this.count = _count;
		}
		
		public void Await()
		{
			lock(locker)
			{
				while(count > 0)
				{
					Monitor.Wait(locker);
				}
			}
　　　 }

　　　 public void CountDown()
　　　 {
　　　 		lock(locker)
　　　 		{
　　　 			count--;
　　　 			Monitor.PulseAll(locker);
　　　 		}
　　　 }
	}
}
