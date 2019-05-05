/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-25
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using CCWin.SkinControl;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;



namespace UserComponents.ChatComp
{
	/// <summary>
	/// Description of LoginUserPanel.
	/// </summary>
	public partial class LoginUserPanel : UserControl
	{
        private string host;
        private int port;
        private bool isLogin = false;
        private const int MAXCOUNT = 3;
        private Image btnUserIdImage;

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

        public event RegistClickEventHandler RegistClick;

		public LoginUserPanel()
		{
			InitializeComponent();
		}

        protected virtual void OnRegistClick(RegistClickEventArgs e)
        {
            if (this.RegistClick != null)
            {
                this.RegistClick(this, e);
            }
        }
		
		public void AddLoginUser(Control _control)
		{
			_control.Dock = DockStyle.None;
			_control.Top = 0;
			this.panelMain.Controls.Add(_control);
            this.LayOutItem();
		}
		
		public void LayOutItem()
		{
            if (this.panelMain.Controls.Count > MAXCOUNT)
            {
                this.btnLeft.Visible = true;
            }
            int count = this.panelMain.Controls.Count;
			count = (count > MAXCOUNT) ? MAXCOUNT : count;
			int w = this.panelMain.Width;
			int paddingX = (w - count * LoginUserControl.WIDTH + 1) / (count + 1);
			for(int i = 0; i < this.panelMain.Controls.Count; i++)
			{
				Control c = this.panelMain.Controls[i];
				c.Left = paddingX + i * (LoginUserControl.WIDTH + paddingX);
			}
		}
		

        public void RemoveLoginUser(Control _control)
        {
            if (this.panelMain.Controls.Contains(_control))
            {
                this.panelMain.Controls.Remove(_control);
                this.LayOutItem();
            }
        }

        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void panelList_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void panelItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserId.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
            {
                return;
            }
            this.panelItem.Visible = false;
            this.panelList.Visible = true;
            LoginUserControl loginUserControl = new LoginUserControl();
            loginUserControl.UserId = this.txtUserId.Text;
            loginUserControl.NickName = this.txtUserId.Text;
            loginUserControl.PassWord = this.txtPassword.Text;
            loginUserControl.Head = ChatCompResource.default_head;
            loginUserControl.UserControlRemove += new UserControlRemoveHandler(loginUserControl_UserControlRemove);
            this.AddLoginUser(loginUserControl);
            this.txtPassword.Text = "";
            this.txtUserId.Text = "";
        }

        void loginUserControl_UserControlRemove(object sender, UserControlRemoveEventArgs args)
        {
            LoginUserControl l = sender as LoginUserControl;
            this.RemoveLoginUser(l);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.panelMain.Controls.Count == 0)
            {
                Application.Exit();
            }
            this.panelItem.Visible = false;
            this.panelList.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.panelList.Visible = false;
            this.panelItem.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.isLogin)
            {
                this.btnLogin.Text = "登        录";
                this.panelMain.Enabled = true;
                return;
            }
            this.panelMain.Enabled = false;
            this.isLogin = !this.isLogin;
            this.btnLogin.Text = "取        消";
            Helper.AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(LoginCb);
            ah.BeginInvoke(null, null);
        }

        private void LoginCb()
        {
            List<Control> list = new List<Control>();
            foreach (Control c in this.panelMain.Controls)
            {
                list.Add(c);
            }
            foreach(Control c in list)
            { 
                if (!this.isLogin)
                {
                    break;
                }
                LoginUserControl lc = c as LoginUserControl;
                string args = "-user" + " " + lc.UserId + " " + "-password" + " " + lc.PassWord + " -host" + " " + this.host + " -port" + " " + this.port;
                string fileName = System.Windows.Forms.Application.ExecutablePath;
                Process p = Process.Start(fileName, args);
                p.WaitForInputIdle();
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.RemoveLoginUser(lc);
                }));
            }
            Application.Exit();
        }

        private void txtPassword_IconClick(object sender, EventArgs e)
        {
            int x = this.FindForm().Left + 
                this.panelItem.Left + 
                this.Left + 
                this.txtPassword.Left;
            int y = this.FindForm().Top +
                this.panelItem.Top +
                this.panelMain.Top +
                this.panelList.Top;
            PassKey pass = new PassKey(
                x, 
                y, 
                this.txtPassword);
            pass.Show(this.FindForm());
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            this.OnRegistClick(new RegistClickEventArgs());
        }

        private void btnUserId_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.msUserId.Items.Count == 0)
            {
                return;
            }
            this.msUserId.Show(this.txtUserId, 1, this.txtUserId.Height + 1);
            this.btnUserIdImage = this.btnUserId.NormlBack;
            this.btnUserId.NormlBack = this.btnUserId.DownBack;
            this.btnUserId.Enabled = false;
        }

        private void msUserId_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.btnUserId.Enabled = true;
            this.btnUserId.NormlBack = this.btnUserIdImage;
        }

        public void LoadUserIdMenu()
        {
            this.msUserId.AutoSize = false;
            this.msUserId.Width = this.txtUserId.Width;
            this.msUserId.Height = 4 * 45 + 10;
            for (int i = 0; i < 4; i++)
            {
                ToolStripMenuItem userIdItem = new ToolStripMenuItem();
                userIdItem.AutoSize = false;
                userIdItem.ImageScaling = ToolStripItemImageScaling.None;
                userIdItem.Size = new System.Drawing.Size(this.txtUserId.Width, 45);
                userIdItem.Text = "aaaa" + i;
                userIdItem.Image = ChatHeaderResource.ResourceManager.GetObject("_" + i) as Image;
                userIdItem.Click += new EventHandler(userIdItem_Click);   
                this.msUserId.Items.Add(userIdItem);
            }
        }

        void userIdItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem userIdItem = (ToolStripMenuItem)sender;
            this.txtUserId.Text = "aaaa";
            this.txtPassword.Text = "aaaa";
            this.loginUserControl.Head = userIdItem.Image;
        }
    }
}
