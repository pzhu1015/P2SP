/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-28
 * Time: 11:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Helper
{
	/// <summary>
	/// Description of UrlParser.
	/// </summary>
	public class UrlHelper
	{
        private const string HttpUrl = @"http://((((((([a-z]|[A-Z])|[0-9])|(([a-z]|[A-Z])|[0-9])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9]))\.)*(([a-z]|[A-Z])|([a-z]|[A-Z])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9])))|([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+))(:([0-9]+)){0,1})(/((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|;|:|@|&|=)*)(/((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|;|:|@|&|=)*))*(\?((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|;|:|@|&|=)*)){0,1}){0,1}";
        private const string FtpUrl = @"ftp://((((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|;|\?|&|=)*)(:((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|;|\?|&|=)*)){0,1}@){0,1}((((((([a-z]|[A-Z])|[0-9])|(([a-z]|[A-Z])|[0-9])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9]))\.)*(([a-z]|[A-Z])|([a-z]|[A-Z])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9])))|([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+))(:([0-9]+)){0,1}))(/(((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|\?|:|@|&|=)*)(/((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|\?|:|@|&|=)*))*)(;type=(A|I|D|a|i|d)){0,1}){0,1}";
        private const string FileUrl = @"file://((((((([a-z]|[A-Z])|[0-9])|(([a-z]|[A-Z])|[0-9])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9]))\.)*(([a-z]|[A-Z])|([a-z]|[A-Z])((([a-z]|[A-Z])|[0-9])|-)*(([a-z]|[A-Z])|[0-9])))|([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+)){0,1}|localhost)/(((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|\?|:|@|&|=)*)(/((((([a-z]|[A-Z])|[0-9]|(\$|-|_|\.|\+)|(!|\*|'|\(|\)|,))|(%([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)([0-9]|A|B|C|D|E|F|a|b|c|d|e|f)))|\?|:|@|&|=)*))*)";
		public UrlHelper()
		{
		}
		
		public static bool IsValidUrl(string _url)
		{
			return Regex.IsMatch(_url, FtpUrl) || Regex.IsMatch(_url, HttpUrl) || Regex.IsMatch(_url, FileUrl) ;
		}
		
		public static string DecodeURL(string uriString) {
            if (Regex.IsMatch(
                HttpUtility.UrlDecode(uriString, Encoding.GetEncoding("iso-8859-1")),
                @"^(?:[\x00-\x7f]|[\xe0-\xef][\x80-\xbf]{2})+$"
            )) {
                return HttpUtility.UrlDecode(uriString, Encoding.GetEncoding("UTF-8"));
            } else {
                return HttpUtility.UrlDecode(uriString, Encoding.GetEncoding("GB2312"));
            }
        }
		
		public static string GetUrl(string url)
		{
			if (!(url.Contains("http://") || url.Contains("https://") || url.Contains("ftp://")))
            {
                url = "http://" + url;
            }
			return url;
		}
	}
}
