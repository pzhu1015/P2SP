/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-11
 * Time: 21:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;

namespace Helper
{
	/// <summary>
	/// Description of FtpHelper.
	/// </summary>
	public class FtpHelper
	{
		public FtpHelper()
		{
		}
		
		public static void GetFtpHeader(out long length, string url, string username, string passwd)
		{
			if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
			length = 0;
			FtpWebRequest request = null;
			FtpWebResponse response = null;
			try
			{
				request = (FtpWebRequest)FtpWebRequest.Create(url);
				request.Method = WebRequestMethods.Ftp.GetFileSize;
				request.KeepAlive = false;
				request.UseBinary = true;
				if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(passwd))
				{
					request.Credentials = new NetworkCredential(username, passwd);
				}
				response = (FtpWebResponse)request.GetResponse();
				length = response.ContentLength;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
            	return;
			}
			finally
			{
				if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
                System.GC.Collect();
			}
		}
	}
}
