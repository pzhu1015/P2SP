using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Helper;
using CCWin;
using CCWin.SkinControl;

namespace ChatClient
{
    public partial class LoginSettingForm : CCSkinMain
    {
        private LoginForm loginForm;
        public LoginSettingForm()
        {
            InitializeComponent();
        }

        public LoginForm LoginForm
        {
            get
            {
                return loginForm;
            }

            set
            {
                loginForm = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ChangeForm();
        }

        private void LoginSettingForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.loginForm.Left, this.loginForm.Top);
            this.txtHost.Text = ConfigHelper.GetAttribute("host");
            this.txtPort.Text = ConfigHelper.GetAttribute("port");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.ChangeForm();
        }

        private void ChangeForm()
        {
            int x = this.Left;
            int y = this.Top;
            this.Hide();
            this.loginForm.Location = new Point(x, y);
            this.loginForm.Show();
            this.loginForm.IsShowLoginSettingForm = false;
            ConfigHelper.SetAttribute("host", this.txtHost.Text);
            ConfigHelper.SetAttribute("port", this.txtPort.Text);
            ConfigHelper.SaveConfig();
            this.loginForm.LoadConfig();
        }
    }
}
