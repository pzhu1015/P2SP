/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-12
 * Time: 23:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

using Helper;
using ExtendControl;
using DownLoadService;
using DevComponents.DotNetBar;

namespace DownLoad.UI
{
    class TaskItem
	{
		private DownLoadTask task;
		
		public DownLoadTask Task {
			get { return task; }
			set { task = value; }
		}
		private EXListViewItem item;
		
		public EXListViewItem Item {
			get { return item; }
			set { item = value; }
		}
	}
	/// <summary>
	/// Description of DownLoadForm.
	/// </summary>
	public partial class DownLoadForm : Office2007Form
	{  
		#region 代理
		
		private delegate void StartTaskDelegate(EXStatusListViewSubItem statusItem);
		private delegate void FinishTaskDelegate(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem, EXListViewSubItem sizeItem, TSmartProgressBar pgBar, string length);
		private delegate void FailTaskDelegate(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem);
		private delegate void StopTaskDelegate(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem);
		private delegate void GetHeaderDelegate(bool success);
		private delegate void MonitorTaskDelegate(DownLoadStatus status, EXListViewSubItem speedItem, EXListViewSubItem sizeItem, TSmartProgressBar pgBar, string crtSize, string length, int progress, string speed);
		private delegate void TotalSpeedMonitorDelegate(string speed);
		private delegate void UpdateItemDelegate(EXListViewSubItem nameItem, EXStatusListViewSubItem extItem, string name, string ext);
		
		private StartTaskDelegate start;
		private FinishTaskDelegate finish;
		private FailTaskDelegate fail;
		private StopTaskDelegate stop;
		private MonitorTaskDelegate monitor;
		private TotalSpeedMonitorDelegate totalSpeed;
		private UpdateItemDelegate updateItem;
		
		#endregion
		
		[DllImport("user32.dll")]
        public static extern int SetClipboardViewer(int windowHandle);
        const int WM_DRAWCLIPBOARD = 0x308;
        IntPtr NextClipHwnd;
    
        #region 成员变量
        
        private ConfigForm configFrm;
		private NewTaskForm newTaskFrm;
		private NewTaskInfoForm newTaskInfoFrm;
		private DeleteConfirmForm deleteConfirmFrm;
		private AboutForm aboutFrm;
		private bool isHide = false;
		private int hideWidth = 0;
		private Hashtable taskItemMap = new Hashtable();
		
		public Hashtable TaskItemMap {
			get { return taskItemMap; }
			set { taskItemMap = value; }
		}
		private static object listItemLocker = new object();
		
		#endregion
		
		#region 属性
		
		public ConfigForm ConfigFrm {
			get { return configFrm; }
			set { configFrm = value; }
		}
		
		public NewTaskForm NewTaskFrm {
			get { return newTaskFrm; }
			set { newTaskFrm = value; }
		}
		
		public NewTaskInfoForm NewTaskInfoFrm {
			get { return newTaskInfoFrm; }
			set { newTaskInfoFrm = value; }
		}
		
		public DeleteConfirmForm DeleteConfirmFrm {
			get { return deleteConfirmFrm; }
			set { deleteConfirmFrm = value; }
		}
		
		public AboutForm AboutFrm {
			get { return aboutFrm; }
			set { aboutFrm = value; }
		}
		
		#endregion
		
		#region 初始化
		
		private void InitListMain()
		{
			ImageList colImgLst = new ImageList();
			colImgLst.Images.Add("up", MainIcon.up as Image);
			colImgLst.Images.Add("down", MainIcon.down as Image);
			colImgLst.ColorDepth = ColorDepth.Depth32Bit;
			colImgLst.ImageSize = new Size(20, 40);
			this.lstViewMain.MySortBrush = SystemBrushes.ControlLight;
			this.lstViewMain.MyHighlightBrush = Brushes.DeepSkyBlue;
			this.lstViewMain.GridLines = false;
			this.lstViewMain.ControlPadding = 12;
			this.lstViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.lstViewMain.SmallImageList = colImgLst;
			
			//创建表头
			this.lstViewMain.Columns.Add(new EXColumnHeader("*", 0));
			this.lstViewMain.Columns.Add(new EXStatusColumnHeader("状态", MainIcon.ResourceManager, 100));
			this.lstViewMain.Columns.Add(new EXColumnHeader("文件名", 250));
			this.lstViewMain.Columns.Add(new EXStatusColumnHeader("文件类型", DownLoadTaskMgr.Instance.ExtIconList, 100));
			this.lstViewMain.Columns.Add(new EXColumnHeader("文件大小", 150));
			this.lstViewMain.Columns.Add(new EXColumnHeader("进度", 150));
			this.lstViewMain.Columns.Add(new EXColumnHeader("速度", 100));
		}
		
		private void InitDelegate()
		{
			this.start = new DownLoadForm.StartTaskDelegate(StartRslt);
			this.finish = new DownLoadForm.FinishTaskDelegate(FinishRslt);
			this.fail = new DownLoadForm.FailTaskDelegate(FailRslt);
			this.stop = new DownLoadForm.StopTaskDelegate(StopRslt);
			this.monitor = new DownLoadForm.MonitorTaskDelegate(MonitorRslt);
			this.totalSpeed = new DownLoadForm.TotalSpeedMonitorDelegate(TotalSpeedRslt);
			this.updateItem = new DownLoadForm.UpdateItemDelegate(UpdateItemRslt);
			
		}
		
		private void InitTasks()
		{
			try
			{
				DownLoadTaskMgr.Instance.InitTasks();
				foreach(DownLoadTask task in DownLoadTaskMgr.Instance.TaskList)
				{
					this.AddItem(task);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		#endregion
		
		private void InitTracer()
		{
			System.Diagnostics.Trace.Listeners.Clear();
            System.Diagnostics.Trace.AutoFlush = true;
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener("app.log"));
		}
		
		public DownLoadForm()
		{
			InitializeComponent();
			this.InitTracer();
			this.InitDelegate();
			Clipboard.Clear();
			this.NextClipHwnd = (IntPtr)SetClipboardViewer(this.Handle.ToInt32());
			this.InitListMain();
			this.hideWidth = this.splitContainerRight.Panel2.Width - this.rightSplitter.Width - 4;
		}
		
		protected override void WndProc(ref Message m) 
		{
			try
			{
				switch(m.Msg)
	    		{
	           		case WM_DRAWCLIPBOARD:
	                // act on Clipboard changes
	                if (Clipboard.ContainsText()) 
	                {
	                    string url = Clipboard.GetText();
	                    if (UrlHelper.IsValidUrl(url))
	                    {
	                    	this.ShowNewTaskForm();
	                    	this.newTaskFrm.SetText(url);
	                    }
	                }
	                break;
	                default :
	                base.WndProc(ref m);
	                break;
	            }
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
        }
		
		public void StartRslt(EXStatusListViewSubItem statusItem)
		{
			statusItem.Status = DownLoadStatusStr.Start;
			this.lstViewMain.Invalidate(statusItem.Bounds);
		}
		
		public void FinishRslt(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem, EXListViewSubItem sizeItem, TSmartProgressBar pgBar, string length)
		{
			statusItem.Status = DownLoadStatusStr.Finish;
			sizeItem.Text = length + "/" + length;
			speedItem.Text = "";
			pgBar.Value = 100;
			this.lstViewMain.Invalidate(statusItem.Bounds);
		}
		
		public void FailRslt(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem)
		{
			statusItem.Status = DownLoadStatusStr.Fail;
			speedItem.Text = "";
			this.lstViewMain.Invalidate(statusItem.Bounds);
		}
		
		public void StopRslt(EXStatusListViewSubItem statusItem, EXListViewSubItem speedItem)
		{
			statusItem.Status = DownLoadStatusStr.Stop;
			speedItem.Text = "";
			this.lstViewMain.Invalidate(statusItem.Bounds);
		}
		
		public void MonitorRslt(DownLoadStatus status, EXListViewSubItem speedItem, EXListViewSubItem sizeItem, TSmartProgressBar pgBar, string crtSize, string length, int progress, string speed)
		{
			if (status == DownLoadStatus.eStart)
			{
				speedItem.Text = speed + "/s";
				sizeItem.Text = crtSize + "/" + length;
			}
			pgBar.Value = progress;
		}
		
		public void TotalSpeedRslt(string speed)
		{
			this.btnDownLoadSpeed.Text = speed + "/s";
		}
	
		public void UpdateItemRslt(EXListViewSubItem nameItem, EXStatusListViewSubItem extItem, string name, string ext)
		{
			nameItem.Text = name;
			extItem.Status = ext;
			this.lstViewMain.Invalidate(extItem.Bounds);
		}
		
		
		#region 显示子窗口
		
		private void ShowDeleteConfirmForm()
		{
			if (this.deleteConfirmFrm == null)
			{
				this.deleteConfirmFrm = new DeleteConfirmForm();
				this.deleteConfirmFrm.DownLoadFrm = this;
			}
			if (!this.deleteConfirmFrm.Visible)
			{
				this.deleteConfirmFrm.ShowDialog(this);
			}
		}
		
		public void ShowNewTaskInfoForm(string url)
		{
			if (this.newTaskInfoFrm == null)
			{
				this.newTaskInfoFrm = new NewTaskInfoForm();
			}
			this.newTaskInfoFrm.Url = url;
			this.newTaskInfoFrm.DownLoadFrm = this;
			this.newTaskInfoFrm.ShowDialog(this);
		}	
		
		private void ShowNewTaskForm()
		{
			if (this.newTaskFrm == null)
			{
				this.newTaskFrm = new NewTaskForm();
				this.newTaskFrm.DownLoadFrm = this;
			}
			if (!this.newTaskFrm.Visible)
			{
				this.newTaskFrm.ShowDialog(this);
			}
		}
		
		private void ShowConfigForm()
		{
			if (this.configFrm == null)
			{
				this.configFrm = new ConfigForm();
				this.configFrm.DownLoadFrm = this;
			}
			this.configFrm.ShowDialog(this);
		}
		
		private void ShowAboutForm()
		{
			if (this.aboutFrm == null)
			{
				this.aboutFrm = new AboutForm();
			}
			this.aboutFrm.ShowDialog(this);
		}
		
		#endregion		
		
		#region 其它
		
		public EXListViewItem AddItem(DownLoadTask task)
		{
			this.lstViewMain.BeginUpdate();
			EXListViewItem item = new EXListViewItem("*");
			EXStatusListViewSubItem statusItem = new EXStatusListViewSubItem(DownLoadStatusStr.GetName(task.GetStatus()));
			item.SubItems.Add(statusItem);
			EXListViewSubItem nameItem = new EXListViewSubItem(task.Name);
			item.SubItems.Add(nameItem);
			EXStatusListViewSubItem extItem = new EXStatusListViewSubItem(task.GetExtension());
			item.SubItems.Add(extItem);
			EXListViewSubItem sizeItem = new EXListViewSubItem(task.GetCrtBytesAndTotalBytes());
			item.SubItems.Add(sizeItem);
			EXControlListViewSubItem progressItem = new EXControlListViewSubItem();
			TSmartProgressBar progressBar = new TSmartProgressBar();
			progressBar.MouseDown += new MouseEventHandler(progressBar_MouseDown);
			progressBar.Tag = item;
			progressBar.Height = 17;
			progressBar.ProgressBarBlockSpace = 0;
			progressBar.ProgressBarMarginOffset = false;
			progressBar.ForeColor = Color.Black;
			progressBar.ProgressBarFillColor = Color.DodgerBlue;
			progressBar.ProgressBarBlockWidth = 1;
			progressBar.Value = task.GetProgress();
			this.lstViewMain.AddControlToSubItem(progressBar, progressItem);
			item.SubItems.Add(progressItem);
			EXListViewSubItem speedItem = new EXListViewSubItem("");
			item.SubItems.Add(speedItem);
			item.Tag = task;
			this.lstViewMain.Items.Add(item);
			this.lstViewMain.EndUpdate();
			task.TaskFinish += new TaskFinishEventHandler(task_TaskFinish);
			task.TaskFail += new TaskFailEventHandler(task_TaskFail);
			task.TaskStart += new TaskStartEventHandler(task_TaskStart);
			task.TaskStop += new TaskStopEventHandler(task_TaskStop);
			task.TaskMonitor += new TaskMonitorEventHandler(task_TaskMonitor);
			task.GetHeader += new GetHeaderEventHandler(task_GetHeader);
			int hashCode = item.GetHashCode();
			task.HashCode = hashCode;
			TaskItem taskItem = new TaskItem();
			taskItem.Task = task;
			taskItem.Item = item;
			this.taskItemMap.Add(hashCode, taskItem);
			DownLoadTaskMgr.Instance.TaskList.Add(task);
			return item;
		}

		void task_GetHeader(object sender, GetHeaderEventArgs e)
		{
			DownLoadTask task = sender as DownLoadTask;
			if (!e.Rslt)
			{
				task.Fail();
			}
			else
			{
				task.SetDocInfo();
				task.CreateBlocks();
				EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
				EXListViewSubItem nameItem = item.SubItems[2] as EXListViewSubItem;
				EXStatusListViewSubItem extItem = item.SubItems[3] as EXStatusListViewSubItem;
				this.BeginInvoke(this.updateItem, new object[]{nameItem, extItem, task.Name, task.GetExtension()});
				task.StartDownLoadThread();
			}
		}

		void task_TaskMonitor(object sender, TaskMonitorEventArgs e)
		{	
			DownLoadTask task = (DownLoadTask)sender;
			EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
			EXStatusListViewSubItem statusItem = item.SubItems[1] as EXStatusListViewSubItem;
			EXListViewSubItem speedItem = item.SubItems[6] as EXListViewSubItem;
			EXListViewSubItem sizeItem = item.SubItems[4] as EXListViewSubItem;
			EXControlListViewSubItem pgbItem = item.SubItems[5] as EXControlListViewSubItem;
			TSmartProgressBar pgb = pgbItem.MyControl as TSmartProgressBar;
			string length = DiskHelper.GetSize(e.Length);
			string crtSize = DiskHelper.GetSize(e.CrtLength);
			DownLoadStatus status = e.Status;
			int progress = e.Progress;
			string speed = DiskHelper.GetSize(e.Speed);
			this.BeginInvoke(this.monitor, new object[] {status, speedItem, sizeItem, pgb, crtSize, length, progress, speed});
		}

		void task_TaskStop(object sender, TaskStopEventArgs e)
		{
			DownLoadTask task = (DownLoadTask)sender;
			EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
			EXStatusListViewSubItem statusItem = item.SubItems[1] as EXStatusListViewSubItem;
			EXListViewSubItem speedItem = item.SubItems[6] as EXListViewSubItem;
			this.BeginInvoke(this.stop, new object[] {statusItem, speedItem});
		}

		void task_TaskStart(object sender, TaskStartEventArgs e)
		{
			DownLoadTask task = (DownLoadTask)sender;
			EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
			EXStatusListViewSubItem statusItem = item.SubItems[1] as EXStatusListViewSubItem;
			this.BeginInvoke(this.start, new object[] {statusItem});
		}

		void task_TaskFail(object sender, TaskFailEventArgs e)
		{
			DownLoadTask task = (DownLoadTask)sender;
			EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
			EXStatusListViewSubItem statusItem = item.SubItems[1] as EXStatusListViewSubItem;
			EXListViewSubItem speedItem = item.SubItems[6] as EXListViewSubItem;
			this.BeginInvoke(this.fail, new object[] {statusItem, speedItem});
		}

		void task_TaskFinish(object sender, TaskFinishEventArgs e)
		{
			DownLoadTask task = (DownLoadTask)sender;
			EXListViewItem item = (this.taskItemMap[task.HashCode] as TaskItem).Item;
			EXStatusListViewSubItem statusItem = item.SubItems[1] as EXStatusListViewSubItem;
			EXListViewSubItem speedItem = item.SubItems[6] as EXListViewSubItem;
			EXListViewSubItem sizeItem = item.SubItems[4] as EXListViewSubItem;
			EXControlListViewSubItem pgbItem = item.SubItems[5] as EXControlListViewSubItem;
			TSmartProgressBar pgb = pgbItem.MyControl as TSmartProgressBar;
			string length = DiskHelper.GetSize(e.Length);
			this.BeginInvoke(this.finish, new object[] {statusItem, speedItem, sizeItem, pgb, length });
		}
		
		private void DealTask(EXListViewItem item, bool? isToStart)
		{
			if (item == null) return;
			DownLoadTask task = (this.taskItemMap[item.GetHashCode()] as TaskItem).Task;
			if (task.Status == DownLoadStatus.eFinish)
			{
				return;
			}
			if (isToStart.HasValue)
			{
				if (isToStart.Value)
				{
		            if (task.Status == DownLoadStatus.eStop || task.Status == DownLoadStatus.eFail)
		            {
		            	this.StartDownLoadTask(item);
		            }
				}
				else
				{
		            if (task.Status == DownLoadStatus.eStart || task.Status == DownLoadStatus.eWait)
		            {
		            	this.StopDownLoadTask(item);
		            }
				}
			}
			else
			{
				if (task.Status == DownLoadStatus.eStop || task.Status == DownLoadStatus.eFail)
		        {
					this.StartDownLoadTask(item);
					this.tsbStart.Enabled = false;
					this.tsbStop.Enabled = true;
				}
				else if (task.Status == DownLoadStatus.eStart || task.Status == DownLoadStatus.eWait)
		        {
					this.StopDownLoadTask(item);
					this.tsbStart.Enabled = true;
					this.tsbStop.Enabled = false;
				}
			}
		}
		
		public void AddItemAndStartTask(DownLoadTask task)
		{
			EXListViewItem item = this.AddItem(task);
			this.StartDownLoadTask(item);
		}
		
		public void DeleteTask(bool isDeleteFile)
		{
			if (isDeleteFile)
			{
				foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
				{
					TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
					this.taskItemMap.Remove(item.GetHashCode());
					DownLoadTask task = taskItem.Task;
					this.DeleteDownLoadTask(item);
					task.DeleteFile();
				}
			}
			else
			{
				foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
				{
					this.taskItemMap.Remove(item.GetHashCode());
					this.DeleteDownLoadTask(item);
				}
			}
		}
		
		#endregion
				
		#region 开始, 停止, 删除任务
		
		private void StartDownLoadTask(EXListViewItem item)
		{
			lock(listItemLocker)
			{
				if (item == null) return;
				TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
				DownLoadTask task = taskItem.Task;
				EXStatusListViewSubItem statusItem = taskItem.Item.SubItems[1] as EXStatusListViewSubItem;
	            statusItem.Status = DownLoadStatusStr.Wait;
	            this.lstViewMain.Invalidate(statusItem.Bounds);
	            DownLoadTaskMgr.Instance.StartTask(task);
			}
		}
		
		private void StopDownLoadTask(EXListViewItem item)
		{
			lock(listItemLocker)
			{
				if (item == null) return;
				TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
				DownLoadTask task = taskItem.Task;
	            DownLoadTaskMgr.Instance.StopTask(task);
			}
		}
		
		private void DeleteDownLoadTask(EXListViewItem item)
		{
			lock(listItemLocker)
			{
				if (item == null) return;
				try
				{
					TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
					DownLoadTask task = taskItem.Task;
					DownLoadTaskMgr.Instance.StopTask(task);
		            DownLoadTaskMgr.Instance.RemoveTask(task);
		            this.lstViewMain.BeginUpdate();
					this.lstViewMain.Items.Remove(item);
					this.lstViewMain.EndUpdate();
				}
				catch(Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
			}
		}
		
		#endregion
				
		#region 窗体事件

		void progressBar_MouseDown(object sender, MouseEventArgs e)
		{
			TSmartProgressBar p = sender as TSmartProgressBar;
			EXListViewItem item = p.Tag as EXListViewItem;
			item.ListView.Focus();
			if (Control.ModifierKeys == Keys.Control)
			{
				item.Selected = !item.Selected;
			}
			else
			{
				foreach(EXListViewItem it in this.lstViewMain.SelectedItems)
				{
					it.Selected = !it.Selected;
				}
				item.Selected = true;
				item.UseItemStyleForSubItems = true;
			}
		}
		
		void DownLoadFormLoad(object sender, EventArgs e)
		{
			DownLoadTaskMgr.Instance.TaskMgrMonitor += new TaskMgrMonitorEventHandler(DownLoadTaskMgr_Instance_TaskMgrMonitor);
			DownLoadTaskMgr.Instance.Start();
			this.tsbStop.Enabled = false;
			this.tsbStart.Enabled = false;
			this.tsbDelete.Enabled = false;
			this.InitTasks();
		}

		void DownLoadTaskMgr_Instance_TaskMgrMonitor(object sender, TaskMgrMonitorEventArgs e)
		{
			this.BeginInvoke(this.totalSpeed, new object[]{DiskHelper.GetSize(e.Speed)});
		}
		
		void TsbAddClick(object sender, EventArgs e)
		{
			this.ShowNewTaskForm();
		}
		
		void LstViewMainItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.lstViewMain.SelectedItems.Count == 1)
			{
				EXListViewItem item = (EXListViewItem)this.lstViewMain.SelectedItems[0];
				TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
				DownLoadTask task = taskItem.Task;
				if (task.Status ==  DownLoadStatus.eStop || task.Status == DownLoadStatus.eFail)
				{
					this.tsbStop.Enabled = false;
					this.tsbStart.Enabled = true;
				}
				if (task.Status == DownLoadStatus.eStart || task.Status == DownLoadStatus.eWait)
				{
					this.tsbStop.Enabled = true;
					this.tsbStart.Enabled = false;
				}
				this.tsbDelete.Enabled = true;
			}
			else if (this.lstViewMain.SelectedItems.Count > 1)
			{
				foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
				{
					TaskItem taskItem = this.taskItemMap[item.GetHashCode()] as TaskItem;
					DownLoadTask task = taskItem.Task;
					if (task.Status == DownLoadStatus.eStop)
					{
						this.tsbStart.Enabled = true;
					}
					if (task.Status == DownLoadStatus.eStart)
					{
						this.tsbStop.Enabled = true;
					}
				}
			}
			else if (this.lstViewMain.SelectedItems.Count == 0)
			{
				this.tsbStop.Enabled = false;
				this.tsbStart.Enabled = false;
				this.tsbDelete.Enabled = false;
			}
		}
		
		private void ReSizeListView()
		{
			int list_main_w = this.splitContainerRight.Panel1.Width;//this.lstViewMain.Width;
			if (list_main_w < 650)
			{
				return;
			}
			int col0_main_w = this.lstViewMain.Columns[0].Width;
			int col1_main_w = this.lstViewMain.Columns[1].Width;
			int col2_main_w = this.lstViewMain.Columns[2].Width;
			int col3_main_w = this.lstViewMain.Columns[3].Width;
			int col4_main_w = this.lstViewMain.Columns[4].Width;
			int col5_main_w = this.lstViewMain.Columns[5].Width;
			int col6_main_w = this.lstViewMain.Columns[6].Width;
			this.lstViewMain.Columns[0].Width = 0; 
			this.lstViewMain.Columns[2].Width = list_main_w 
												- col0_main_w 
												- col1_main_w
												- col3_main_w
												- col4_main_w
												- col5_main_w
												- col6_main_w - 10;
		}
		
		void DownLoadFormResize(object sender, EventArgs e)
		{
			this.ReSizeListView();
		}
		
		void LstViewMainMouseDoubleClick(object sender, MouseEventArgs e)
		{	
			EXListViewItem item = this.lstViewMain.GetItemAt(e.X, e.Y) as EXListViewItem;
			this.DealTask(item, null);
		}
		
		void TsbStartClick(object sender, EventArgs e)
		{
			foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
			{
				this.DealTask(item, true);
			}
			this.tsbStart.Enabled = false;
			this.tsbStop.Enabled = true;
		}
		
		void TsbStopClick(object sender, EventArgs e)
		{
			foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
			{
				this.DealTask(item, false);
			}
			this.tsbStop.Enabled = false;
			this.tsbStart.Enabled = true;
		}
		
		void TsbDeleteClick(object sender, EventArgs e)
		{
			if (Control.ModifierKeys == Keys.Shift)
			{
				this.ShowDeleteConfirmForm();
			}
			else
			{
				foreach(EXListViewItem item in this.lstViewMain.SelectedItems)
				{
					this.DeleteDownLoadTask(item);
				}
			}
		}
		
		void TsbOptionsClick(object sender, EventArgs e)
		{
			this.ShowConfigForm();
		}
	
		void TsbOpenClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe",DownLoadTaskMgr.Instance.GetSaveDir());
		}	
				
		void DownLoadFormFormClosing(object sender, FormClosingEventArgs e)
		{
			DownLoadTaskMgr.Instance.StopAllTask();
		}

		void DownLoadFormSizeChanged(object sender, EventArgs e)
		{
			this.ReSizeListView();
		}	

		void BtnItemAboutClick(object sender, EventArgs e)
		{
			this.ShowAboutForm();
		}
		
		void RightSplitterClick(object sender, EventArgs e)
		{
			if (!this.isHide)
			{
				this.splitContainerRight.SplitterDistance += this.hideWidth;
			}
			else
			{
				this.splitContainerRight.SplitterDistance -= this.hideWidth;
			}
			this.isHide = !this.isHide;
		}
		
		#endregion
		
		
	}
}
