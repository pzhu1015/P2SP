/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-13
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text;

using Helper;
using ExtendControl;
using DownLoadService;
using DevComponents;
using DevComponents.DotNetBar;

namespace DownLoad.UI
{
	/// <summary>
	/// Description of NewTaskForm.
	/// </summary>
	public partial class NewTaskForm : Office2007Form
	{
		private DownLoadForm downLoadFrm;
		private NewTaskInfoForm newTaskInfoFrm;
		
		public NewTaskInfoForm NewTaskInfoFrm {
			get { return newTaskInfoFrm; }
			set { newTaskInfoFrm = value; }
		}
		
		public DownLoadForm DownLoadFrm {
			get { return downLoadFrm; }
			set { downLoadFrm = value; }
		}
		
		public NewTaskForm()
		{
			InitializeComponent();
		}
		
		public void SetText(string _url)
		{
			this.txtUrl.Text = _url;
		}
		
		void NewTaskFormLoad(object sender, EventArgs e)
		{
			this.txtUrl.Clear();
			this.lblError.Text = "";
			if (Clipboard.ContainsText())
			{
				string str = Clipboard.GetText();
				if (UrlHelper.IsValidUrl(str))
				{
					this.txtUrl.Text = str;
				}
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void NewTaskFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
		
		
		void BtnDownLoadClick(object sender, EventArgs e)
		{
			string url = this.txtUrl.Text.Trim(new char[]{'\n', '\r', ' '});
			url = UrlHelper.GetUrl(url);
			if (!UrlHelper.IsValidUrl(url))
			{
				this.lblError.Text = "输入的Url不合法";
				return;
			}
			DownLoadProtocol protocol = DownLoadTask.GetProtocol(url);
			DownLoadTask task = DownLoadTask.GetInstance(protocol);
			task.LoadFromUrl(url);
			task.CreateDocInfo();
			this.Hide();
			this.downLoadFrm.AddItemAndStartTask(task);
		}
		
		void SptBtnContinueClick(object sender, EventArgs e)
		{
			string url = this.txtUrl.Text.Trim(new char[]{'\n', '\r', ' '});
			url = UrlHelper.GetUrl(url);
			if (!UrlHelper.IsValidUrl(url))
			{
				this.lblError.Text = "输入的Url不合法";
				return;
			}
			this.Hide();
			this.downLoadFrm.ShowNewTaskInfoForm(url);
		}
	}
}
