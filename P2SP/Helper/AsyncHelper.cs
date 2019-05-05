/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2014-2-24
 * Time: 23:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Helper
{
	/// <summary>
	/// Description of AsyncHelper.
	/// </summary>
	public class AsyncHelper
	{
		public delegate void AsyncHandler();

        public delegate void AsyncHandlerArgs(object args);
		public AsyncHelper()
		{
		}
	}
}
