using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using CCWin;
using CCWin.SkinControl;
using Complents.ChatComp;
using Helper;
using System.Diagnostics;

namespace ChatClient
{
    public partial class LoginForm : CCSkinMain
    {
        private string host;
        private int port;
        private bool isShowLoginSettingForm = false;
        private LoginSettingForm loginSettingForm;
        private RegistFrom registFrom;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void MouseDown_MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Helper.DLLHelper.ReleaseCapture();
                Helper.DLLHelper.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public bool IsShowLoginSettingForm
        {
            get
            {
                return isShowLoginSettingForm;
            }

            set
            {
                isShowLoginSettingForm = value;
            }
        }

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        private void LoginForm_SysBottomClick(object sender)
        {
            int x = this.Left;
            int y = this.Top;
            this.Hide();
            if (this.loginSettingForm == null)
            {
                this.loginSettingForm = new LoginSettingForm();
                this.loginSettingForm.LoginForm = this;
            }
            this.Location = new Point(x, y);
            this.loginSettingForm.Show();
            this.IsShowLoginSettingForm = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsShowLoginSettingForm == false)
            {
                this.Show();
            }
            else
            {
                this.loginSettingForm.Show();
            }
        }

        private void loginUserPanel_RegistClick(object sender, RegistClickEventArgs args)
        {
            if (this.registFrom == null)
            {
                this.registFrom = new RegistFrom();
                this.registFrom.LoginForm = this;
            }

            this.registFrom.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.LoadConfig();
            this.LoadBackground();
            this.loginUserPanel.LoadUserIdMenu();
        }

        public void LoadConfig()
        {
            this.Host = ConfigHelper.GetAttribute("host");
            this.Port = ConfigHelper.GetAttributeInt("port", -1);
            this.loginUserPanel.Host = this.Host;
            this.loginUserPanel.Port = this.Port;
        }

        private void LoadBackground()
        {
            string shortDate = DateTime.Now.ToShortDateString();
            string shortTime = DateTime.Now.ToShortTimeString();
            DateTime now = DateTime.Now;
            if (now < DateTime.Parse(shortDate + " 12:00:00"))
            {
                this.Back = FormResource.morning;
            }
            else if (now >= DateTime.Parse(shortDate + " 12:00:00") &&
                     now <= DateTime.Parse(shortDate + " 13:00:00"))
            {
                this.Back = FormResource.noon;
            }
            else if (now > DateTime.Parse(shortDate + " 13:00:00") &&
                     now <= DateTime.Parse(shortDate + " 18:00:00"))
            {
                this.Back = FormResource.afternoon;
            }
            else
            {
                this.Back = FormResource.night;
            }
        }
    }
}
