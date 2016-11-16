/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-31
 * Time: 15:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of StartTypeStr.
	/// </summary>
	public class StartTypeStr
	{
		public const string Auto = "auto";
		public const string Manual = "manual";
		public StartTypeStr()
		{
		}
		
		public static StartType toEnum(string str)
		{
			switch(str)
			{
				case Auto:
					return StartType.eAuto;
				case Manual:
					return StartType.eManual;
				default:
					return StartType.eAuto;
			}
		}
		
		public static string GetName(StartType E)
		{
			switch(E)
			{
				case StartType.eAuto:
					return Auto;
				case StartType.eManual:
					return Manual;
				default:
					return Auto;
			}
		}
		
		public static string ValueToName(string v)
		{
			switch(v)
			{
				case Auto:
					return "立即下载";
				case Manual:
					return "手动下载";
				default:
					return "立即下载";
			}
		}
		
		public static string NameToValue(string n)
		{
			switch(n)
			{
				case "立即下载":
					return Auto;
				case "手动下载":
					return Manual;
				default:
					return Auto;
						
			}
		}
	}
	
	public enum StartType
	{
		eError = 0,
		
		eAuto = 1,
		eManual = 2,
		
		eMax
	}
}
