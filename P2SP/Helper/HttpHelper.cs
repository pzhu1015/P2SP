/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-11
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Helper
{
	/// <summary>
	/// Description of HttpHelper.
	/// </summary>
	public class HttpHelper
	{
		private const string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
		public HttpHelper()
		{
		}
		
		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
			
        {
            return true; //总是接受  
        }
		
        public static void GetHttpHeader(out WebHeaderCollection head, out Uri uri, string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            uri = null;
            head = null;
            try
            {
            	ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
	            request = WebRequest.Create(url) as HttpWebRequest;
	            request.Method = "HEAD";
	            request.KeepAlive = false;
	            request.UserAgent = DefaultUserAgent;
	            if (!string.IsNullOrEmpty(userAgent))
	            {
	                request.UserAgent = userAgent;
	            }
	            if (timeout.HasValue)
	            {
	                request.Timeout = timeout.Value;
	            }
	            if (cookies != null)
	            {
	                request.CookieContainer = new CookieContainer();
	                request.CookieContainer.Add(cookies);
	            }
	            else
	            {
	                request.CookieContainer = new CookieContainer();
	            }
	            response = request.GetResponse() as HttpWebResponse;
	            if (response == null || response.ContentLength <= 0)
	            {
	            	return;
	            }
	            if (response.StatusCode != HttpStatusCode.OK)
	            {
	            	return;
	            }
	            head = response.Headers;
	            uri = response.ResponseUri;
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
