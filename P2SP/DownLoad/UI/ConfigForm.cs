/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-14
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

using DownLoadService;
using DevComponents;
using DevComponents.DotNetBar;

namespace DownLoad.UI
{
	/// <summary>
	/// Description of ConfigForm.
	/// </summary>
	public partial class ConfigForm : Office2007Form
	{
		private DownLoadForm downLoadFrm;
		
		public DownLoadForm DownLoadFrm {
			get { return downLoadFrm; }
			set { downLoadFrm = value; }
		}
		
		public ConfigForm()
		{
			InitializeComponent();
		}
		
		private void SaveConfig()
		{
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["SaveDir"].Value = this.txtSaveDir.Text;
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["NumThread"].Value = this.nudNumThread.Value.ToString();
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["MaxConnection"].Value = this.nudMaxConnection.Value.ToString();
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["MaxTasks"].Value = this.nudMaxTasks.Value.ToString();
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["StartType"].Value = StartTypeStr.NameToValue(this.cmboxTaskStartType.Text);
			DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["Extensions"].Value = this.txtFileExt.Text;
			DownLoadTaskMgr.Instance.SaveConfig();
		}
		
		void ConfigFormLoad(object sender, EventArgs e)
		{
			Configuration appConfig = DownLoadTaskMgr.Instance.AppConfig;
			this.txtSaveDir.Text = appConfig.AppSettings.Settings["SaveDir"].Value;
			this.nudNumThread.Value = Convert.ToDecimal(appConfig.AppSettings.Settings["NumThread"].Value);
			this.nudMaxConnection.Value = Convert.ToDecimal(appConfig.AppSettings.Settings["MaxConnection"].Value);
			this.nudMaxTasks.Value = Convert.ToDecimal(appConfig.AppSettings.Settings["MaxTasks"].Value);
			this.cmboxTaskStartType.Text = StartTypeStr.ValueToName(appConfig.AppSettings.Settings["StartType"].Value);
			this.txtFileExt.Text = appConfig.AppSettings.Settings["Extensions"].Value;
		}
		
		void BtnSelectClick(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtSaveDir.Text = folderDialog.SelectedPath;
            }
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			this.SaveConfig();
			this.Hide();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		void BtnApplyClick(object sender, EventArgs e)
		{
			this.SaveConfig();
			this.btnApply.Enabled = false;
		}
		
		void TxtSaveDirTextChanged(object sender, EventArgs e)
		{
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["SaveDir"].Value == this.txtSaveDir.Text)
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void NudNumThreadValueChanged(object sender, EventArgs e)
		{
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["NumThread"].Value == this.nudNumThread.Value.ToString())
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void CmboxTaskStartTypeSelectedIndexChanged(object sender, EventArgs e)
		{
//			//start type: Auto | Manual
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["StartType"].Value == this.cmboxTaskStartType.Text)
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void NudMaxTasksValueChanged(object sender, EventArgs e)
		{
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["MaxTasks"].Value == this.nudNumThread.Value.ToString())
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void NudMaxConnectionValueChanged(object sender, EventArgs e)
		{
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["MaxConnection"].Value == this.nudMaxConnection.Value.ToString())
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void TxtFileExtTextChanged(object sender, EventArgs e)
		{
			if (DownLoadTaskMgr.Instance.AppConfig.AppSettings.Settings["Extensions"].Value == this.txtFileExt.Text)
			{
				this.btnApply.Enabled = false;
			}
			else
			{
				this.btnApply.Enabled = true;
			}
		}
		
		void ConfigFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
