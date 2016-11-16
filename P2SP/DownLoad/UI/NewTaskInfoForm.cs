/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-17
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

using Helper;
using ExtendControl;
using DownLoadService;
using DevComponents;
using DevComponents.DotNetBar;

namespace DownLoad.UI
{
	/// <summary>
	/// Description of NewTaskInfoForm.
	/// </summary>
	public partial class NewTaskInfoForm : Office2007Form
	{
		private delegate void GetHeaderDelegate();
		private static object headerLocker = new object();
		private bool success;
		private DownLoadForm downLoadFrm;
		private DownLoadTask task;
		private bool isHide = true;
		private int hideHeight = 0;
		
		public DownLoadTask Task {
			get { return task; }
			set { task = value; }
		}
		
		private string url;
		
		public string Url {
			get { return url; }
			set { url = value; }
		}
		
		public DownLoadForm DownLoadFrm {
			get { return downLoadFrm; }
			set { downLoadFrm = value; }
		}
		
		private void SetSuccess(bool s)
		{
			lock(headerLocker)
			{
				this.success = s;
			}
		}
		
		private bool GetSuccess()
		{
			lock(headerLocker)
			{
				return this.success;
			}
		}
		
		private void GetHeadersResult()
		{
			try
			{
				string des;
				Icon largeIcon, smallIcon;
				IconHelper.GetExtsIconAndDescription(task.GetExtension(), out largeIcon, out smallIcon, out des);
				this.pboxFileIcon.Image = largeIcon.ToBitmap() as Image;
				this.lblSize.Text = DiskHelper.GetSize(this.task.Length);
				this.lblName.Text = this.task.Name;
				this.txtUserName.Text = this.task.UserName;
				this.txtPassWord.Text = this.task.PassWord;
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void GetHeaderThreadFunc()
		{
			try
			{
				this.SetSuccess(this.task.GetHeaderInfo());
				if (this.Visible)
				{
					GetHeaderDelegate gd = new NewTaskInfoForm.GetHeaderDelegate(GetHeadersResult);
					this.BeginInvoke(gd, null);
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void StartGetHeaderThread(string url)
		{
			Thread thread = new Thread(new ThreadStart(GetHeaderThreadFunc));
			thread.IsBackground = true;
			thread.Start();
		}
		
		public NewTaskInfoForm()
		{
			InitializeComponent();
			this.hideHeight = this.scExTop.Panel2.Height;
			this.Height = this.Height - this.hideHeight;
		}
		
		private void ButtonOk(bool isStart)
		{
			try
			{
				if (string.IsNullOrEmpty(this.txtSaveDir.Text))
				{
					this.lblError.Text = "文件保存目录不能为空,请选择文件保存路径";
					return;
				}
				if (!this.GetSuccess() || this.task.Length == 0)
				{
					this.Hide();
					this.task.CreateDocInfo();
					this.task.SetBlocks(Convert.ToInt32(this.nudNumThread.Value));
					if (isStart)
					{			
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("立即开始", sf);
						}
						this.downLoadFrm.AddItemAndStartTask(this.task);
					}
					else
					{
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("创建但不开始", sf);
						}
						this.downLoadFrm.AddItem(this.task);
					}
				}
				else
				{
					if (!DiskHelper.CheckDiskSpace(this.task.Length, this.txtSaveDir.Text))
					{
						this.lblError.Text = "磁盘空间不足,请重新选择文件保存目录";
						return;
					}
					this.task.CreateDocInfo();
					this.task.SetBlocks(Convert.ToInt32(this.nudNumThread.Value));
					this.task.CreateBlocks();
					if (isStart)
					{
						this.downLoadFrm.AddItemAndStartTask(task);
					}
					else
					{
						this.downLoadFrm.AddItem(task);
					}
				}
				this.Hide();
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void NewTaskInfoFormLoad(object sender, EventArgs e)
		{
			StartType starType = DownLoadTaskMgr.Instance.GetStartType();
			if (starType == StartType.eAuto)
			{
				this.spBtnDownLoad.Text = StartTypeStr.ValueToName(StartTypeStr.Auto);
				this.btnManual.Text = StartTypeStr.ValueToName(StartTypeStr.Manual);
			}
			else if (starType == StartType.eManual)
			{
				this.spBtnDownLoad.Text = StartTypeStr.ValueToName(StartTypeStr.Manual);
				this.btnManual.Text = StartTypeStr.ValueToName(StartTypeStr.Auto);
			}
			DownLoadProtocol protocol = DownLoadTask.GetProtocol(this.url);
			this.task = DownLoadTask.GetInstance(protocol);
			this.task.LoadFromUrl(this.url);
			string ext = this.task.GetExtension();
			if (!DownLoadTaskMgr.Instance.ExtIconList.ContainsKey(ext))
            {
	            Icon smallIcon, largeIcon;
				string desc;
				IconHelper.GetExtsIconAndDescription(ext, out largeIcon, out smallIcon, out desc);
				DownLoadTaskMgr.Instance.ExtIconList.Add(ext, largeIcon.ToBitmap() as Image);
            }
			this.pboxFileIcon.Image = DownLoadTaskMgr.Instance.ExtIconList[ext];
			this.txtUrl.Visible = false;
			this.txtName.Visible = false;
			this.lblUrl.Text = this.task.Url;
			this.lblName.Text = this.task.Name;
			this.lblSize.Text = DiskHelper.GetSize(this.task.Length);
			this.txtSaveDir.Text = DownLoadTaskMgr.Instance.GetSaveDir();
			this.nudNumThread.Value = DownLoadTaskMgr.Instance.GetNumThread();
			this.lblError.Text = "";
			this.StartGetHeaderThread(this.url);
		}
		
		void BtnSelectClick(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
            	this.txtSaveDir.Text = folderDialog.SelectedPath;
            }
		}
		
		void LblNameClick(object sender, EventArgs e)
		{
			this.txtName.Visible = true;
			this.lblName.Visible = !this.txtName.Visible;
			this.txtName.Text = this.lblName.Text;
			this.txtName.Focus();
		}
		
		void LblUrlClick(object sender, EventArgs e)
		{
			this.txtUrl.Visible = true;
			this.lblUrl.Visible = !this.txtUrl.Visible;
			this.txtUrl.Text = this.lblUrl.Text;
			this.txtUrl.Focus();
		}
		
		void TxtUrlLeave(object sender, EventArgs e)
		{
			this.txtUrl.Visible = false;
			this.lblUrl.Visible = !this.txtUrl.Visible;
			this.lblUrl.Text = this.txtUrl.Text;
		}
		
		void TxtNameLeave(object sender, EventArgs e)
		{
			this.txtName.Visible = false;
			this.lblName.Visible = !this.txtName.Visible;
			this.lblName.Text = this.txtName.Text;
		}
		
		void NewTaskInfoFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
		
		void TxtSaveDirTextChanged(object sender, EventArgs e)
		{
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["SaveDir"].Value = this.txtSaveDir.Text;
			DownLoadTaskMgr.Instance.SaveConfig();
		}
		
		void NewTaskInfoFormMouseClick(object sender, MouseEventArgs e)
		{
			if (this.txtUrl.Visible)
			{
				this.txtUrl.Visible = false;
				this.lblUrl.Visible = !this.txtUrl.Visible;
				this.lblUrl.Text = this.txtUrl.Text;
			}
			
			if (this.txtName.Visible)
			{
				this.txtName.Visible = false;
				this.lblName.Visible = !this.txtName.Visible;
				this.lblName.Text = this.txtName.Text;
			}
		}

		
		void SpBtnDownLoadClick(object sender, EventArgs e)
		{
			StartType startType = StartTypeStr.toEnum(StartTypeStr.NameToValue(this.spBtnDownLoad.Text));
			if (startType == StartType.eAuto)
			{
				this.ButtonOk(true);
			}
			else if (startType == StartType.eManual)
			{
				this.ButtonOk(false);
			}
		}
		
		void BtnManualClick(object sender, EventArgs e)
		{
			StartType startType = StartTypeStr.toEnum(StartTypeStr.NameToValue(this.btnManual.Text));
			if (startType == StartType.eAuto)
			{
				this.ButtonOk(true);
			}
			else if (startType == StartType.eManual)
			{
				this.ButtonOk(false);
			}
		}
		
		void SpliterTopClick(object sender, EventArgs e)
		{
			if (this.isHide)
			{
				this.Height = this.Height + this.hideHeight;
			}
			else
			{
				this.Height = this.Height - this.hideHeight;	
			}
			this.isHide = !this.isHide;
		}
	}
}
