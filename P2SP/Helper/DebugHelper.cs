/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-18
 * Time: 11:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
	

namespace Helper
{
	/// <summary>
	/// Description of DebugHelper.
	/// </summary>
	public class DebugHelper
	{
		public DebugHelper()
		{
		}
		
		public static void Console(string msg, StackFrame sf)
		{
			//[xxx.cs:100] msg
			string date = System.DateTime.Now.ToString();
			string filename = sf.GetFileName();
			int line = sf.GetFileLineNumber() + 2;
			int idx = filename.LastIndexOf("\\") + 1;
			string name = filename.Substring(idx, filename.Length - idx);
			string thrd_id = Thread.CurrentThread.GetHashCode().ToString();
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("<{0}:{1}:{2}:{3}> {4}", thrd_id, date, name, line, msg);
			System.Diagnostics.Trace.WriteLine(sb.ToString());
		}
		
		public static void Error(Exception ex, StackFrame sf)
		{
			//****************************************error****************************************
			//  DateTime : 2013-03-09 00:00:00
			//  FileName : xxxx.cs
			//LineNumber : xxxx
			//	Error : xxxx
			//*************************************************************************************
			string filename = sf.GetFileName();
			int line = sf.GetFileLineNumber();
			int idx = filename.LastIndexOf("\\") + 1;
			string name = filename.Substring(idx, filename.Length - idx);
			StringBuilder sb = new StringBuilder();
			sb.Append("\r\n********************* error *********************\r\n");
			sb.AppendFormat("  DateTime : {0}\r\n", System.DateTime.Now.ToString());
			sb.AppendFormat("  FileName : {0}\r\n", name);
			sb.AppendFormat("LineNumber : {0}\r\n", line + 2);
			sb.AppendFormat("  Error : {0}\r\n", ex.ToString());
			sb.Append("\r\n********************* error *********************\r\n");
			System.Diagnostics.Trace.WriteLine(sb.ToString());
		}
		
		public static void Assert(bool condtion)
		{
			System.Diagnostics.Trace.Assert(condtion);
		}
		
		public static void Assert(bool condtion, string msg)
		{
			System.Diagnostics.Trace.Assert(condtion, msg);
		}
	}
}
