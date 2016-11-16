/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-13
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using CCWin;
using CCWin.SkinControl;
using Chat;

namespace ChatClientUI
{
	/// <summary>
	/// Description of SystemSettingForm.
	/// </summary>
	public partial class SystemSettingForm : CCWin.CCSkinMain
	{
		private Dictionary<string, string> config = new Dictionary<string, string>();
		private MainForm mainFrm;
		
		public MainForm MainFrm {
			get { return mainFrm; }
			set { mainFrm = value; }
		}
		
		public SystemSettingForm()
		{
			InitializeComponent();
		}
		
		private void SaveChanges()
		{
			foreach(KeyValuePair<string, string> entry in this.config)
			{
				AppConfigMgr.Instance.SetAttribute(entry.Key, entry.Value);
			}
		}
		
		void BtnChangeRecveDirClick(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				txtRecveDir.Text = folderDialog.SelectedPath;
				this.config[AppConfigMgr.RecveDirectroy] = txtRecveDir.Text;
			}
		}
		
		void BtnOpenRecveDirClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer.exe", this.txtRecveDir.Text);
		}
		
		void TxtScreenCaptureKeyKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers.ToString() != "None")
			{
				return;
			}
			this.txtScreenCaptureKey.Text = "Ctrl + Alt + " + e.KeyCode.ToString();
			this.config[AppConfigMgr.ScreenCaptureKey] = e.KeyCode.ToString();
		}
		
		void SystemSettingFormFormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveChanges();
			this.mainFrm.SystemSettingFrm = null;
		}
		
		void SystemSettingFormLoad(object sender, EventArgs e)
		{
			this.txtScreenCaptureKey.Text = "Ctrl + Alt + " + AppConfigMgr.Instance.GetAttribute(AppConfigMgr.ScreenCaptureKey, "A");
			this.txtRecveDir.Text = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.RecveDirectroy, Application.StartupPath + "\\RecveFile");
		}
		
		void RbtnCtrlEnterClick(object sender, EventArgs e)
		{
			this.config[AppConfigMgr.SendKey] = "false";
		}
		
		void RbtnEnterClick(object sender, EventArgs e)
		{
			this.config[AppConfigMgr.SendKey] = "true";
		}
	}
}
