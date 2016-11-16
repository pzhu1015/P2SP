/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2016/10/20 星期四
 * Time: 下午 4:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
 
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Helper
{
	/// <summary>
	/// Description of AutoLog.
	/// </summary>
	public class AutoLog
	{
		private static AutoLog instance = new AutoLog(AutoLog.instance.GetType());
		
		public static AutoLog Instance {
			get { 
				return instance;
			}
		}
		private Logger logger;
		
		public AutoLog(Type this_getType)
		{		
			//config the log4net to output the file
			ILayout layout = new PatternLayout("%d[Thread:%t]%-5p %c [Line:%L] - %m%n");
			IAppender fileAppender = new FileAppender(layout, "log.txt");
			IAppender consoleAppender = new ConsoleAppender(layout);
			BasicConfigurator.Configure(fileAppender);
			//error it print the number is up !
			BasicConfigurator.Configure(consoleAppender);
			
			//init the log object to output
			ILog iLog = LogManager.GetLogger(this_getType);
			logger = (Logger)iLog.Logger;
			
			logger.AddAppender(consoleAppender);
			logger.AddAppender(fileAppender);
			logger.Additivity = false;
		}
		
		public void Info(Object message)
		{
			logger.Log(Level.Info,message, null);
		}
		
		public void Info(Object message, Exception exception)
		{
			logger.Log(Level.Info, message, exception);
		}
		
		public void Debug(Object message)
		{
			logger.Log(Level.Debug, message, null);
		}
		
		public void Debug(Object message, Exception exception)
		{
			logger.Log(Level.Debug, message, exception);
		}
		
		public void Warning(Object message)
		{
			logger.Log(Level.Warn, message, null);
		}
		
		public void Warning(Object message, Exception exception)
		{
			logger.Log(Level.Warn, message, exception);
		}
		
		public void Error(Object message)
		{
			logger.Log(Level.Error, message, null);
		}
		
		public void Error(Object message, Exception exception)
		{
			logger.Log(Level.Error, message, exception);
		}
		
		public void Fatal(Object message)
		{
			logger.Log(Level.Fatal, message, null);
		}
		
		public void Fatal(Object message, Exception exception)
		{
			logger.Log(Level.Fatal, message, exception);
		}
	}
}
