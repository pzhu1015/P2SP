/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-13
 * Time: 23:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DownLoadService
{
	/// <summary>
	/// Description of DownStatus.
	/// </summary>
	public class DownLoadStatusStr
	{

		public const string Start = "start";
		public const string Stop = "stop";
		public const string Fail = "fail";
		public const string Finish = "finish";
		public const string Wait = "wait";
		
		public static DownLoadStatus toEnum(string str)
		{
			switch(str)
			{
				case Start:
					return DownLoadStatus.eStart;
				case Stop:
					return DownLoadStatus.eStop;
				case Fail:
					return DownLoadStatus.eFail;
				case Finish:
					return DownLoadStatus.eFinish;
				case Wait:
					return DownLoadStatus.eWait;
				default: 
					return DownLoadStatus.eStop;
			}
		}
		
		public static string GetName(DownLoadStatus E)
		{
			switch(E)
			{
				case DownLoadStatus.eStart:
					return Start;
				case DownLoadStatus.eStop:
					return Stop;
				case DownLoadStatus.eFail:
					return Fail;
				case DownLoadStatus.eFinish:
					return Finish;
				case DownLoadStatus.eWait:
					return Wait;
				default :
					return Stop;
			}
		}
		
		public static string NameToValue(string n)
		{
			switch(n)
			{
				case Start:
					return "开始";
				case Stop:
					return "停止";
				case Fail:
					return "失败";
				case Finish:
					return "完成";
				case Wait:
					return "等待";
				default: 
					return "停止";
			}
		}

		public DownLoadStatusStr()
		{
		}
	}
	
	public enum DownLoadStatus
	{
		eInvalid = 0,
		
		eStart = 1,
		eStop = 2,
		eFail = 3,
		eFinish = 4,
		eWait = 5,
		
		eMax
	}
}
