/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-1-16
 * Time: 10:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;

using Helper;
namespace Chat
{
	/// <summary>
	/// Description of AppConfigMgr.
	/// </summary>
	public sealed class AppConfigMgr
	{
		public const string ServerIp = "ServerIp";
		public const string ServerTcpPort = "ServerTcpPort";
		public const string FontSize = "FontSize";
		public const string FontFamily = "FontFamily";
		public const string ForeColor = "ForeColor";
		public const string Bold = "Bold";
		public const string Italic = "Italic";
		public const string UnderLine = "UnderLine";
		public const string RecveDirectroy = "RecveDirectroy";
		public const string ScreenCaptureKey = "ScreenCaptureKey";
		public const string SendKey = "SendKey";
		public const string HomeDir = "HomeDir";
		
		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		
		public Configuration AppConfig {
			get { return appConfig; }
			set { appConfig = value; }
		}
		
		private static AppConfigMgr instance = new AppConfigMgr();
		
		public static AppConfigMgr Instance {
			get {
				return instance;
			}
		}
		
		private AppConfigMgr()
		{
		}
		
		public void SaveConfig()
		{
			this.appConfig.Save();
		}
		
		public bool GetAttributeBool(string n)
		{
			try
			{
				string str = this.appConfig.AppSettings.Settings[n].Value;
				if (string.IsNullOrEmpty(str))
				{
					return false;
				}
				return Convert.ToBoolean(str);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return false;
			}
		}
		
		public int GetAttributeInt(string n, int i)
		{
			try
			{
				string str = this.appConfig.AppSettings.Settings[n].Value;
				if (string.IsNullOrEmpty(str))
				{
					return i;
				}
				return Convert.ToInt32(str);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return i;
			}
		}
		
		public double GetAttributeDouble(string n, double d)
		{
			try
			{
				string str = this.appConfig.AppSettings.Settings[n].Value;
				if (string.IsNullOrEmpty(str))
				{
					return d;
				}
				return Convert.ToDouble(str);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return d;
			}
		}
		
		public string GetAttribute(string n, string s)
		{
			try
			{
				string str = this.appConfig.AppSettings.Settings[n].Value;
				if (string.IsNullOrEmpty(str))
				{
					return s;
				}
				return str;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return s;
			}
		}
		
		public string GetAttribute(string n)
		{
			try
			{
				string str = this.appConfig.AppSettings.Settings[n].Value;
				if (string.IsNullOrEmpty(str))
				{
					return "";
				}
				return str;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return "";
			}
		}
		
		public void SetAttribute(string n, string v)
		{
			try
			{
				this.appConfig.AppSettings.Settings[n].Value = v;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
			finally
			{
				this.SaveConfig();
			}
		}
		
		public void SetAttribute(string n, bool v)
		{
			try
			{
				this.appConfig.AppSettings.Settings[n].Value = v.ToString().ToLower();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
			finally
			{
				this.SaveConfig();
			}
		}
		
		public void SetAttribute(string n, float v)
		{
			try
			{
				this.appConfig.AppSettings.Settings[n].Value = v.ToString();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
			finally
			{
				this.SaveConfig();
			}
		}
	}
}
