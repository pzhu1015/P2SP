/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-11
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace Helper
{
	/// <summary>
	/// Description of InternetHelper.
	/// </summary>
	public class InternetHelper
	{
		public InternetHelper()
		{
		}
		
		[DllImport("wininet.dll")]
        extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        
        public static bool IsConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }
	}
}
