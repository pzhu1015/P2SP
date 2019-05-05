/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-23
 * Time: 17:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;

using Helper;

namespace DownLoadService
{
	/// <summary>
	/// Description of HeaderInfo.
	/// </summary>
	public abstract class DownLoadTask
	{
		private static object attributeLocker = new object();
		private static object fileLocker = new object();
		protected int blocks;
		protected long speed;
		protected bool isRange;
		protected bool isFrist;
		protected long length;
		protected long takeTime;
		protected string url;
		protected string name;
		protected string fullName;
		protected string taskId;
		protected string userName;
		protected string passWord;
		protected CountDownLatch latch;
		protected List<Block> blockList;
		protected XmlNode infoNode;
		protected XmlDocument infoDoc;
		protected FileStream fStream;
		protected DownLoadStatus status;
		protected int hashCode;
		
		public int HashCode {
			get { return hashCode; }
			set { hashCode = value; }
		}
		
		public int Blocks {
			get { return blocks; }
			set { blocks = value; }
		}
		
		public bool IsRange {
			get { return isRange; }
			set { isRange = value; }
		}
		
		public bool IsFrist {
			get { return isFrist; }
			set { isFrist = value; }
		}
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		public long Speed {
			get { return speed; }
			set { speed = value; }
		}
		
		public long TakeTime {
			get { return takeTime; }
			set { takeTime = value; }
		}
		
		public string Url {
			get { return url; }
			set { url = value; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public string FullName {
			get { return fullName; }
			set { fullName = value; }
		}
		
		public string TaskId {
			get { return taskId; }
			set { taskId = value; }
		}
		
		public string UserName {
			get { return userName; }
			set { userName = value; }
		}
		
		public string PassWord {
			get { return passWord; }
			set { passWord = value; }
		}
		
		public CountDownLatch Latch {
			get { return latch; }
			set { latch = value; }
		}
		
		public List<Block> BlockList {
			get { return blockList; }
			set { blockList = value; }
		}
		
		public XmlNode InfoNode {
			get { return infoNode; }
			set { infoNode = value; }
		}
		
		public XmlDocument InfoDoc {
			get { return infoDoc; }
			set { infoDoc = value; }
		}
		
		public FileStream FStream {
			get { return fStream; }
			set { fStream = value; }
		}
		
		public DownLoadStatus Status {
			get { return status; }
			set { status = value; }
		}
		
		public event TaskMonitorEventHandler TaskMonitor;
		public event GetHeaderEventHandler GetHeader;
		public event TaskStartEventHandler TaskStart;
		public event TaskStopEventHandler TaskStop;
		public event TaskFailEventHandler TaskFail;
		public event TaskFinishEventHandler TaskFinish;
		
		protected virtual void OnTaskMonitor(TaskMonitorEventArgs e)
		{
			if (this.TaskMonitor != null)
			{
				this.TaskMonitor(this, e);
			}
		}
		
		protected virtual void OnGetHeader(GetHeaderEventArgs e)
		{
			if (this.GetHeader != null)
			{
				this.GetHeader(this, e);
			}
		}
		
		protected virtual void OnTaskStart(TaskStartEventArgs e)
		{
			if (this.TaskStart != null)
			{
				this.TaskStart(this, e);
			}
		}
		
		protected virtual void OnTaskStop(TaskStopEventArgs e)
		{
			if (this.TaskStop != null)
			{
				this.TaskStop(this, e);
			}
		}
		
		protected virtual void OnTaskFail(TaskFailEventArgs e)
		{
			if (this.TaskFail != null)
			{
				this.TaskFail(this, e);
			}
		}
		
		protected virtual void OnTaskFinish(TaskFinishEventArgs e)
		{
			if (this.TaskFinish != null)
			{
				this.TaskFinish(this, e);
			}
		}
		
		
		private void InitBaseProperties()
		{
			this.status = DownLoadStatus.eStop;
			this.isFrist = true;
			this.url = "";
			this.name = "";
			this.length = 0;
			this.fullName = "";
			this.blockList = new List<Block>();
			this.infoDoc = null;
			this.infoNode = null;
			this.taskId = DownLoadTaskMgr.Instance.GetTaskId();
		}
		
		public DownLoadTask()
		{
			this.InitBaseProperties();
		}
		
		public void LoadFromUrl(string _url)
		{
			try
			{
				this.url = _url;
				Uri uri = new Uri(this.url);
				string tmpname = uri.Segments[uri.Segments.Length - 1];
				if (tmpname[tmpname.Length - 1] == '/')
				{
					tmpname = "index.html";
				}
				string saveDir = DownLoadTaskMgr.Instance.GetSaveDir();	
				this.name = this.GetUsedName(saveDir, tmpname);
System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("=================== " + this.name, sf);
				this.fullName = saveDir + "\\" + this.name;
				if (!string.IsNullOrEmpty(uri.UserInfo))
				{
					string[] userinfo = uri.UserInfo.Split(':');
					this.userName = userinfo[0];
					this.passWord = userinfo[1];
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public abstract bool GetHeaderInfo();
		
		public abstract void DownLoadThreadFunc(object o);
		
		public static DownLoadProtocol GetProtocol(string _url)
		{
			Uri uri = new Uri(_url);
			string protocol = uri.Scheme;
			return DownLoadProtocolStr.toEnum(protocol);
		}
		
		public static DownLoadProtocol GetProtocol(XmlDocument doc)
		{
			XmlNode node = doc.SelectSingleNode("file");
			string _url = ((XmlElement)node).GetAttribute("url");
			return GetProtocol(_url);
		}
		
		public static DownLoadTask GetInstance(DownLoadProtocol protocol)
		{
			switch(protocol)
			{
				case DownLoadProtocol.eHttp:
					return new HttpDownLoadTask();
				case DownLoadProtocol.eFtp:
					return new FtpDownLoadTask();
				default:
					return null;
			}
		}
		
		public void LoadFromDoc(XmlDocument doc)
		{
			try
			{
				this.infoDoc = doc;
				this.infoNode = this.infoDoc.SelectSingleNode("file");
				XmlElement el = (XmlElement)this.infoNode;
				this.taskId = el.GetAttribute("taskId");
				this.name = el.GetAttribute("name");
				this.fullName = el.GetAttribute("fullName");
				this.length = Convert.ToInt64(el.GetAttribute("length"));
				this.isRange = Convert.ToBoolean(el.GetAttribute("isRange"));
				this.url = el.GetAttribute("url");	
				this.isFrist = Convert.ToBoolean(el.GetAttribute("isFirst"));
				this.userName = el.GetAttribute("userName");
				this.passWord = el.GetAttribute("passWord");
				this.InitBlocks();
				this.status = this.GetStatus();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void SetDocInfo()
		{
			try
			{
				XmlElement el = (XmlElement)this.infoNode;
				el.SetAttribute("taskId", this.taskId);
				el.SetAttribute("name", this.name);
				el.SetAttribute("fullName", this.fullName);
				el.SetAttribute("length", this.length.ToString());
				el.SetAttribute("isRange", this.isRange.ToString().ToLower());
				el.SetAttribute("url", this.url);
				el.SetAttribute("isFirst", this.isFrist.ToString().ToLower());
				el.SetAttribute("userName", this.userName);
				el.SetAttribute("passWord", this.passWord);
				DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, false);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void CreateDocInfo()
		{
			try
			{
				this.infoDoc = new XmlDocument();
				this.infoDoc.LoadXml("<file/>");
				this.infoNode = this.infoDoc.SelectSingleNode("file");
				XmlElement el = (XmlElement)this.infoNode;
				el.SetAttribute("taskId", this.taskId);
				el.SetAttribute("name", this.name);
				el.SetAttribute("fullName", this.fullName);
				el.SetAttribute("length", this.length.ToString());
				el.SetAttribute("isRange", this.isRange.ToString().ToLower());
				el.SetAttribute("url", this.url);
				el.SetAttribute("isFirst", this.isFrist.ToString().ToLower());
				el.SetAttribute("userName", this.userName);
				el.SetAttribute("passWord", this.passWord);
				DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, false);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void CreateBlocks()
		{
			try
			{
				int blocks = this.GetBlocks();
				if (this.length == 0 || blocks == 0)
				{
					return;
				}
				long size = this.length;
		        long perSize = size/blocks;
	            long start = 0;
	            long end = 0;
	            for (int i=0; i<blocks; i++)
	            {
	            	if (i == 0)
	            	{
	            		start = perSize * i;
	            	}
	            	if (i == blocks -1)
	            	{
	            		end = size -1;
	            	}
	            	else
	            	{
	            		end = start + perSize;
	            	}
	            	XmlElement newEl = this.infoDoc.CreateElement("block");
	            	newEl.SetAttribute("start", start.ToString());
	            	newEl.SetAttribute("end", end.ToString());
	                newEl.SetAttribute("pos", start.ToString());
	                this.infoNode.AppendChild(newEl);
	                start = end + 1;
	            }
	            DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, false);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void InitBlocks()
		{
			try
			{
				this.blockList.Clear();
				XmlNodeList nodes = this.infoNode.ChildNodes;
				foreach(XmlNode node in nodes)
				{
					Block block = new Block(node);
					this.blockList.Add(block);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void SetBlocks(int _v)
		{
			this.blocks = _v;
			XmlElement el = (XmlElement)this.infoNode;
			el.SetAttribute("blocks", this.blocks.ToString());
			DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, false);
		}
		
		public void SetIsFirst(bool _v)
		{
			this.isFrist = _v;
			XmlElement el = (XmlElement)this.infoNode;
			el.SetAttribute("isFirst", this.isFrist.ToString().ToLower());
			DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, false);
		}
		
		public void Update(Block block, long pos)
		{
			lock(attributeLocker)
			{
				block.Pos = pos;
				XmlElement el = (XmlElement)block.BlockNode;
				el.SetAttribute("pos", pos.ToString());
				DownLoadTaskMgr.Instance.SaveTaskDoc(this.infoDoc, this.taskId, true);
			}
		}
		
		public int GetProgress()
		{
			if (this.length == 0)
			{
				return 0;
			}
			return (int)(100f * this.GetCrtBytes() / this.Length);
		}
		
		private int GetBlocks()
		{
			if (this.isRange)
			{
				if (this.blocks != 0 && this.blocks != DownLoadTaskMgr.Instance.GetNumThread())
				{
					return this.blocks;
				}
				return DownLoadTaskMgr.Instance.GetNumThread();
			}
			else
			{
				return 1;
			}
		}
		
		public long GetCrtBytes()
		{
			lock(attributeLocker)
			{
				long bytes = 0;
				foreach(Block block in this.blockList)
				{
					bytes += (block.Pos - block.Start);
				}
				return bytes;
			}
		}
		
		public string GetExtension()
		{
			string ext = ".未知";
			if (this.name.Contains("."))
			{
				int idx = this.name.LastIndexOf(".");
				ext = this.name.Substring(idx, this.name.Length - idx);
			}			
			return ext;
		}
		
		public string GetTmpFileName()
		{
			return this.fullName + ".pzh";
		}	
		
		public DownLoadStatus GetStatus()
		{
			long crtBytes = this.GetCrtBytes();
			if (crtBytes < this.length && crtBytes > 0)
			{
				if (!File.Exists(this.GetTmpFileName()))
				{
					return DownLoadStatus.eFail;
				}
				return DownLoadStatus.eStop;
			}
			else if (crtBytes == 0)
			{
				return DownLoadStatus.eStop;
			}
			else if (crtBytes == this.length)
			{
				if (!File.Exists(this.fullName))
				{
					return DownLoadStatus.eFail;
				}
				return DownLoadStatus.eFinish;
			}
			else
			{
				return DownLoadStatus.eFail;
			}
		}
		
		public string GetCrtBytesAndTotalBytes()
		{
			if (this.length == 0)
			{
				return "--/--";
			}
			else
			{
				return DiskHelper.GetSize(this.GetCrtBytes()) + "/" + DiskHelper.GetSize(this.length);
			}
		}
		
		protected void WriteToFile(long pos, byte[] buff, int readbytes)
		{
			lock(fileLocker)
			{
				if (this.fStream != null)
				{
					this.fStream.Seek(pos, SeekOrigin.Begin);
					this.fStream.Write(buff, 0, readbytes);
					this.fStream.Flush();
				}
			}
		}
		
		protected void MonitorThreadFunc()
		{
			System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
			System.Diagnostics.StackFrame sf = st.GetFrame(0);
			DebugHelper.Console("monitor start", sf);
			long crt = 0, pre = this.GetCrtBytes();
			while(this.status == DownLoadStatus.eStart)
			{
				crt = this.GetCrtBytes();
				DebugHelper.Console("current bytes: " + crt, sf);
				if (crt == this.Length)
				{
					break;
				}
				
				this.speed = crt - pre;
				pre = crt;
				this.OnTaskMonitor(new TaskMonitorEventArgs(this.status, this.speed, this.length, crt, this.GetProgress()));
				Thread.Sleep(1000);
			}
			crt = this.GetCrtBytes();
			DebugHelper.Console("current bytes: " + crt, sf);
			this.speed = crt - pre;
			this.OnTaskMonitor(new TaskMonitorEventArgs(this.status, this.speed, this.length, crt, this.GetProgress()));
			DebugHelper.Console("monitor stop", sf);
		}
		
		private void StartTaskThreadFunc()
		{
			try
			{
				if (!InternetHelper.IsConnected())
	            {
					this.Fail();
	            	return;
	            }
				if (this.IsFrist)
				{
                    bool success = false;// DiskHelper.AllocateSpace(this.GetTmpFileName(), this.Length);
					if (!success)
					{
						this.Fail();
						return;
					}
					this.SetIsFirst(false);
				}
				lock(fileLocker)
				{
					if (this.fStream == null)
					{
						this.fStream = new FileStream(this.GetTmpFileName(), FileMode.Open, FileAccess.Write, FileShare.Write);
					}
				}
				this.latch = new CountDownLatch(this.blockList.Count);
				for (int i = 0; i<this.blockList.Count; i++)
				{
					if (this.blockList[i].Pos > this.blockList[i].End)
					{
						this.latch.CountDown();
						continue;
					}
					ThreadPool.QueueUserWorkItem(new WaitCallback(DownLoadThreadFunc), i);
				}
				this.latch.Await();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.Fail();
			}
			finally
			{
				lock(fileLocker)
				{
					if (this.fStream != null)
					{
						this.fStream.Close();
						this.fStream = null;
					}
				}
				if (this.status == DownLoadStatus.eStart)
				{
					if (this.GetCrtBytes() == this.Length)
					{	
						File.Move(this.GetTmpFileName(), this.FullName);
						this.Finish();
					}
					else
					{
						this.Fail();
					}
				}
				else if (this.status == DownLoadStatus.eStop)
				{
					//stop 
				}
			}
		}
		
		private void GetHeaderThreadFunc()
		{
			bool success = this.GetHeaderInfo();
			this.OnGetHeader(new GetHeaderEventArgs(success));
		}
		
		public void StartDownLoadThread()
		{
			this.InitBlocks();
			Thread downLoadMinitorThrd = new Thread(new ThreadStart(MonitorThreadFunc));
	        downLoadMinitorThrd.IsBackground = true;
	        downLoadMinitorThrd.Start();
	        	
			Thread downLoadMainThrd = new Thread(new ThreadStart(StartTaskThreadFunc));
			downLoadMainThrd.IsBackground = true;
			downLoadMainThrd.Start();
		}
		
		private void StartGetHeaderThread()
		{
			Thread getHeaderThrd = new Thread(new ThreadStart(GetHeaderThreadFunc));
			getHeaderThrd.IsBackground = true;
			getHeaderThrd.Start();
		}
					
		public bool Start()
		{
			try
			{
				this.status = DownLoadStatus.eStart;
				this.OnTaskStart(new TaskStartEventArgs());
				this.InitBlocks();
				if (this.blockList.Count == 0)
				{
					this.StartGetHeaderThread();
					return true;
				}
				this.StartDownLoadThread();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				this.Fail();
				return false;
			}
			return true;
		}
		
		public bool Fail()
		{
			this.status = DownLoadStatus.eFail;
			DownLoadTaskMgr.Instance.FailTask(this);
			this.OnTaskFail(new TaskFailEventArgs());
			return true;
		}
		
		public bool Stop()
		{
			this.status = DownLoadStatus.eStop;
			//wait all the started sub thread exit
			this.OnTaskStop(new TaskStopEventArgs());
			return true;
		}
		
		public bool Finish()
		{
			this.status = DownLoadStatus.eFinish;
			DownLoadTaskMgr.Instance.FinishTask(this);
			this.OnTaskFinish(new TaskFinishEventArgs(this.length));
			return true;
		}
		
		private bool CheckExistFile(string _f, string _t)
		{
			foreach(DownLoadTask task in DownLoadTaskMgr.Instance.TaskList)
			{
				XmlDocument doc = task.infoDoc;
				XmlElement el = (XmlElement)doc.SelectSingleNode("file");
				string _taskId = el.GetAttribute("taskId");
				if (_taskId == this.taskId)
				{
					continue;
				}
				string fullName = el.GetAttribute("fullName");
				string tmpFileName = fullName + ".pzh";
				if (fullName == _f || tmpFileName == _t)
				{
					return true;
				}
				fullName = task.fullName;
				tmpFileName = task.GetTmpFileName();
				if (fullName == _f || tmpFileName == _t)
				{
					return true;
				}
			}
			if (File.Exists(_f) || File.Exists(_t))
			{
				return true;
			}
			return false;
		}

		protected string GetUsedName(string _saveDir, string _name)
		{
			_name = UrlHelper.DecodeURL(_name);
			int i = 1;
			string usedname = _name;
			string fullname = _saveDir + "\\" + _name;
			while(this.CheckExistFile(fullname, fullname + ".pzh"))
			{
				int idx = _name.LastIndexOf(".");
				usedname = _name.Substring(0, idx) + "(" + (i++) + ")" + _name.Substring(idx, _name.Length - idx);
				fullname = _saveDir + "\\" + usedname;
			}
			return usedname;
		}
		
		private void DeleteFileThreadFunc(object o)
		{
			while(true)
			{
				lock(fileLocker)
				{
					if (this.fStream != null)
					{
						Thread.Sleep(1000);
						continue;
					}
					if (File.Exists(this.fullName))
					{
						File.Delete(this.fullName);
						break;
					}
					if (File.Exists(this.GetTmpFileName()))
					{
						File.Delete(this.GetTmpFileName());
						break;
					}
				}
			}
		}
		
		public void DeleteFile()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(DeleteFileThreadFunc), null);
		}
	}
}
