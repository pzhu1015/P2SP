using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Helper;
using System.IO;

namespace FlashDownLoad
{
    public partial class ConfigForm : DevExpress.XtraEditors.XtraForm
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            try
            {
                ConfigHelper.LoadConfig();
                this.chkAutoStart.Checked = ConfigHelper.GetAttributeBool(Resource.AutoStart);
                this.chkAutoFinishTask.Checked = ConfigHelper.GetAttributeBool(Resource.AutoFinishTask);
                this.chkQuiteDownLoad.Checked = ConfigHelper.GetAttributeBool(Resource.QuiteDownLoad);
                this.chkUsePreDir.Checked = ConfigHelper.GetAttributeBool(Resource.AutoUsePreDirectory);
                this.btnSelectDir.Text = ConfigHelper.GetAttribute(Resource.DownLoadDirectory);
                this.cmbMaxThreads.Text = ConfigHelper.GetAttribute(Resource.MaxThreads);
                DirectoryInfo dirInfo = new DirectoryInfo(this.btnSelectDir.Text);
                string root = dirInfo.Root.Name;
                this.lblFreeSpace.Text = DiskHelper.GetSize(DiskHelper.GetHardDiskFreeSpace(root));
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void nbItemGeneric_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.nFrame.SelectedPage = this.npGenericConfig;
        }

        private void nbItemDownLoad_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.nFrame.SelectedPage = this.npDownLoadConfig;
        }

        private void chkAutoStart_CheckStateChanged(object sender, EventArgs e)
        {
            bool auto_start = ConfigHelper.GetAttributeBool(Resource.AutoStart);
            if (auto_start != this.chkAutoStart.Checked)
            {
                ConfigHelper.SetAttribute(Resource.AutoStart, this.chkAutoStart.Checked.ToString());
                this.btnApply.Enabled = true;
            }
        }

        private void chkAutoFinishTask_CheckStateChanged(object sender, EventArgs e)
        {
            bool auto_finish_task = ConfigHelper.GetAttributeBool(Resource.AutoFinishTask);
            if (auto_finish_task != this.chkAutoFinishTask.Checked)
            {
                ConfigHelper.SetAttribute(Resource.AutoFinishTask, this.chkAutoFinishTask.Checked.ToString());
                this.btnApply.Enabled = true;
            }
        }

        private void btnSelectDir_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = Resource.FloderBrowserDescription;
            fb.ShowDialog();
            this.btnSelectDir.Text = fb.SelectedPath;
            string download_directory = ConfigHelper.GetAttribute(Resource.DownLoadDirectory);
            if (this.btnSelectDir.Text != download_directory)
            {
                ConfigHelper.SetAttribute(Resource.DownLoadDirectory, this.btnSelectDir.Text);
                DirectoryInfo dirInfo = new DirectoryInfo(this.btnSelectDir.Text);
                string root = dirInfo.Root.Name;
                this.lblFreeSpace.Text = DiskHelper.GetSize(DiskHelper.GetHardDiskFreeSpace(root));
                this.btnApply.Enabled = true;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ConfigHelper.SaveConfig();
            this.btnApply.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfigHelper.SaveConfig();
            this.Hide();
        }

        private void cmbMaxThreads_TextChanged(object sender, EventArgs e)
        {
            int max_threads = ConfigHelper.GetAttributeInt(Resource.MaxThreads, 5);
            if(this.cmbMaxThreads.Text != max_threads.ToString())
            {
                ConfigHelper.SetAttribute(Resource.MaxThreads, this.cmbMaxThreads.Text);
                this.btnApply.Enabled = true;
            }
        }
    }
}