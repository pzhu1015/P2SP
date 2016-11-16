/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-9
 * Time: 20:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of DownLoadProtocol.
	/// </summary>
	public class DownLoadProtocolStr
	{
		public const string Http = "http";
		public const string Ftp = "ftp";
		public const string Https = "https";
		public const string P2P = "p2p";
		public const string P2SP = "p2sp";
		public DownLoadProtocolStr()
		{
		}
		
		public static DownLoadProtocol toEnum(string str)
		{
			switch(str.ToLower())
			{
				case Http:
					return DownLoadProtocol.eHttp;
				case Ftp:
					return DownLoadProtocol.eFtp;
				case Https:
					return DownLoadProtocol.eHttps;
				case P2P:
					return DownLoadProtocol.eP2P;
				case P2SP:
					return DownLoadProtocol.eP2SP;
				default:
					return DownLoadProtocol.eHttp;
			}
		}
		
		public static string GetName(DownLoadProtocol E)
		{
			switch(E)
			{
				case DownLoadProtocol.eHttp:
					return Http;
				case DownLoadProtocol.eFtp:
					return Ftp;
				case DownLoadProtocol.eHttps:
					return Https;
				case DownLoadProtocol.eP2P:
					return P2P;
				case DownLoadProtocol.eP2SP:
					return P2SP;
				default:
					return Http;
			}
		}
	}
	
	public enum DownLoadProtocol
	{
		eError = 0,
		
		eHttp = 1,
		eFtp = 2,
		eHttps = 3,
		eP2P = 4,
		eP2SP = 5,
		
		eMax
	}
}
