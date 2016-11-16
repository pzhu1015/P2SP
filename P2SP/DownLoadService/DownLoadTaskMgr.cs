/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-19
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Net;
using System.Drawing;

using Helper;

namespace DownLoadService
{
	/// <summary>
	/// Description of DownLoadTaskMgr.
	/// </summary>
	public class DownLoadTaskMgr
	{
		private static DownLoadTaskMgr instance = new DownLoadTaskMgr();
		private static object taskListLocker = new object();
		private List<DownLoadTask> taskWaitList = new List<DownLoadTask>();
		private List<DownLoadTask> taskStartList = new List<DownLoadTask>();
		private List<DownLoadTask> taskList = new List<DownLoadTask>();
		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		private Dictionary<string, Image> extIconList = new Dictionary<string, Image>();
		private bool isStart = false;
		
		#region 属性
		
		public Dictionary<string, Image> ExtIconList {
			get { return extIconList; }
			set { extIconList = value; }
		}
		
		public Configuration AppConfig {
			get { return appConfig; }
			set { appConfig = value; }
		}
		
//		public TaskCaller FrmCaller {
//			get { return frmCaller; }
//			set { frmCaller = value; }
//		}
				
		public bool IsStart {
			get { return isStart; }
			set { isStart = value; }
		}
		
		public List<DownLoadTask> TaskList {
			get { return taskList; }
			set { taskList = value; }
		}
		
		#endregion
		
		public event TaskMgrMonitorEventHandler TaskMgrMonitor;
		
		protected virtual void OnTaskMgrMonitor(TaskMgrMonitorEventArgs e)
		{
			if (this.TaskMgrMonitor != null)
			{
				this.TaskMgrMonitor(this, e);
			}
		}
		
		public static DownLoadTaskMgr Instance {
			get {
				return instance;
			}
		}
		
		private DownLoadTaskMgr()
		{
		}
		
		public string GetTaskId()
		{
			System.Guid guid = new Guid();
			guid = Guid.NewGuid();
			return guid.ToString();
		}
		
		public void SaveTaskDoc(XmlDocument doc, string taskId, bool check)
		{
			if (check)
			{
				if (File.Exists(@"task\" + taskId))
				{
					doc.Save(@"task\" + taskId);
				}
			}
			else
			{
				doc.Save(@"task\" + taskId);
			}
		}
		
		#region 初始化
		
		private void InitExtIconMap()
		{
			string str = this.GetExtensions();
			string[] str_exts = str.Split(';');
			foreach(string str_ext in str_exts)
			{
				Icon smallIcon, largeIcon;
				string desc;
				IconHelper.GetExtsIconAndDescription(str_ext, out largeIcon, out smallIcon, out desc);
				this.extIconList.Add(str_ext, largeIcon.ToBitmap() as Image);
			}
		}
		
		public void GetExtImage(string ext_str)
		{
			Image ext = this.extIconList[ext_str];
			if (ext == null)
			{
				string desc;
				Icon smallIcon, largeIcon;
				IconHelper.GetExtsIconAndDescription(ext_str, out largeIcon, out smallIcon, out desc);
				ext = largeIcon.ToBitmap() as Image;
				this.extIconList.Add(ext_str, ext);
			}
		}
		
		public void InitTasks()
		{
			DirectoryInfo dirInfo = null;
			if (!DiskHelper.CheckDirectoryIsExist("task"))
			{
				dirInfo = Directory.CreateDirectory("task");
			}
			else
			{
				dirInfo = new DirectoryInfo("task");
			}
			foreach(FileInfo fileinfo in dirInfo.GetFiles())
			{
				string fullname = "";
				try
				{
					fullname = fileinfo.FullName;
					XmlDocument doc = new XmlDocument();
					doc.Load(fullname);
					DownLoadProtocol protocol = DownLoadTask.GetProtocol(doc);
					DownLoadTask task = DownLoadTask.GetInstance(protocol);
					task.LoadFromDoc(doc);
					this.taskList.Add(task);
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
					File.Delete(fullname);
					continue;
				}
			}
		}
		
		#endregion
		
		#region 配置管理
		
		public void SaveConfig()
		{
			this.appConfig.Save();
			ServicePointManager.DefaultConnectionLimit = Convert.ToInt32(this.appConfig.AppSettings.Settings["MaxConnection"].Value);
		}
		
		public string GetSaveDir()
		{
			if (string.IsNullOrEmpty(this.appConfig.AppSettings.Settings["SaveDir"].Value) ||
			    !DiskHelper.CheckDirectoryIsExist(this.appConfig.AppSettings.Settings["SaveDir"].Value))
			{
				DirectoryInfo dirInfo = Directory.CreateDirectory("DownLoad");
				this.appConfig.AppSettings.Settings["SaveDir"].Value = dirInfo.FullName;
				this.appConfig.Save();
			}
			return this.appConfig.AppSettings.Settings["SaveDir"].Value;
			
		}
		
		public int GetNumThread()
		{
			return Convert.ToInt32(this.appConfig.AppSettings.Settings["NumThread"].Value);
		}
		
		public int GetMaxTasks()
		{
			return Convert.ToInt32(this.appConfig.AppSettings.Settings["MaxTasks"].Value);
		}
		
		public int GetMaxConnection()
		{
			return Convert.ToInt32(this.appConfig.AppSettings.Settings["MaxConnection"].Value);
		}
		
		public StartType GetStartType()
		{
			return StartTypeStr.toEnum(this.appConfig.AppSettings.Settings["StartType"].Value);
		}
		
		public string GetExtensions()
		{
			return this.appConfig.AppSettings.Settings["Extensions"].Value;
		}
		
		#endregion
		
		#region 开始任务管理
	
		private void ThreadFunc()
		{
			while(this.isStart)
			{
				DownLoadTask task;
				lock(taskListLocker)
				{
					if (this.taskWaitList.Count == 0)
					{
						Monitor.Wait(taskListLocker);
						continue;
					}
					if (this.taskStartList.Count >= this.GetMaxTasks())
					{
						Monitor.Wait(taskListLocker);
						continue;
					}
					task = this.taskWaitList[0];
					this.taskWaitList.Remove(task);
					

					if (task.Status == DownLoadStatus.eWait)
					{
						task.Start();
						this.taskStartList.Add(task);
					}
				}
				
			}
		}
		
		private void MonitorThreadFunc()
		{
			while(this.isStart)
			{
				long totalSpeed = 0;
				foreach(DownLoadTask task in this.taskStartList)
				{
					totalSpeed += task.Speed;
				}
//				this.frmCaller.SetTotalSpeedCallBack(new object[]{totalSpeed});
				this.OnTaskMgrMonitor(new TaskMgrMonitorEventArgs(totalSpeed));
				Thread.Sleep(1000);
			}
		}
		
		public void Start()
		{
			this.isStart = true;
			Thread thrd = new Thread(new ThreadStart(ThreadFunc));
			thrd.IsBackground = true;
			thrd.Start();
			
			thrd = new Thread(new ThreadStart(MonitorThreadFunc));
			thrd.IsBackground = true;
			thrd.Start();
		}
		
		#endregion
		
		#region 任务控制管理
		
		public void RemoveTask(DownLoadTask task)
		{
			lock(taskListLocker)
			{
				bool rslt = this.taskList.Remove(task);
				
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("=============RemoveTask : "+ this.taskList.Count, sf);
				
				if (File.Exists(@"task\" + task.TaskId))
				{
					File.Delete(@"task\" + task.TaskId);
				}
			}
		}
		
		private void RemoveStartTask(DownLoadTask task)
		{
			lock(taskListLocker)
			{
				this.taskStartList.Remove(task);
				
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("=============RemoveStartTask : "+ this.taskStartList.Count, sf);
				
				Monitor.Pulse(taskListLocker);
			}
		}
		
		private void RemoveWaitTask(DownLoadTask task)
		{
			lock(taskListLocker)
			{
				this.taskWaitList.Remove(task);
				
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("=============RemoveWaitTask : "+ this.taskWaitList.Count, sf);
				
			}
		}
		
		public void StopTask(DownLoadTask task)
		{
			if (task != null)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("==========" + DownLoadStatusStr.GetName(task.GetStatus()), sf);
				if (task.Status == DownLoadStatus.eWait)
				{
					task.Stop();
					this.RemoveWaitTask(task);
				}
				if (task.Status == DownLoadStatus.eStart)
				{
					task.Stop();
					this.RemoveStartTask(task);
				}
			}
		}
		
		public void StartTask(DownLoadTask task)
		{
			lock(taskListLocker)
			{
				if (!this.taskWaitList.Contains(task) && !this.taskStartList.Contains(task))
				{
					task.Status = DownLoadStatus.eWait;
					this.taskWaitList.Add(task);
					Monitor.Pulse(taskListLocker);
				}
			}
		}
		
		public void FinishTask(DownLoadTask task)
		{
			this.RemoveStartTask(task);
		}
		
		public void FailTask(DownLoadTask task)
		{
			this.RemoveStartTask(task);
		}
		
		public void StopAllTask()
		{
			lock(taskListLocker)
			{
				while(this.taskWaitList.Count > 0)
				{
					this.StopTask(this.taskWaitList[0]);
				}
				while(this.taskStartList.Count > 0)
				{
					this.StopTask(this.taskStartList[0]);
				}
			}
		}	
		
		#endregion
	}
}
