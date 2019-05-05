/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-22
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;
using Chat;
using Helper;
using UserComponents.ChatComp;


namespace ChatClientUI
{
	/// <summary>
	/// Description of LoginForm.
	/// </summary>
	public partial class LoginForm : CCSkinMain
	{
		private int count = 0;
		public int Count {
			get { return count; }
			set { count = value; }
		}
		private Image buttonIdImage = null;
		private LoginSettingFrom loginSettingFrm = null;
		private bool isLogin = false;
		private MainForm crtMainForm = null;
        
		public LoginForm()
		{
			InitializeComponent();
			this.InitTracer();
		}
		
		private void InitTracer()
		{
			System.Diagnostics.Trace.Listeners.Clear();
            System.Diagnostics.Trace.AutoFlush = true;
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Application.StartupPath + @"\app.log"));
		}
		
		public void CheckClosing()
		{
			try
			{
				this.count--;
				if (this.count == 0)
				{
					Application.Exit();
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		public void LoginSuccess(string userId)
		{
			try
			{
				if (!this.isLogin)
				{
					return;
				}
				this.count++;
				this.BeginInvoke(new MethodInvoker(delegate()
				{
				    //this.loginUserPanelMain.RemoveLoginUser(userId);
				    this.crtMainForm.LoadUser();
				    this.crtMainForm.ShowMainForm();
					this.Login();
				}));
			}
			catch (Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void Login()
		{
			try
			{
    //            System.Windows.Forms.Control.ControlCollection userList = this.loginUserPanelMain.GetLoginUser();
    //            if (userList.Count == 0)
				//{
				//	this.notifyIconMain.Visible = false;
				//	this.Hide();
				//	return;
				//}
				//LoginUserControl control = userList[0] as LoginUserControl;
				//if (!control.IsCheck)
				//{
				//	//this.loginUserPanelMain.RemoveLoginUser(control.UserId);
				//	this.Login();
				//	return;
				//}
				//string userId = control.UserId;
				//string password = control.PassWord;
				//this.crtMainForm = new MainForm();
				//this.crtMainForm.LoginFrm = this;
				//this.crtMainForm.Login(control.UserId, control.PassWord);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		private void ShowLoginSettingForm()
		{
			if (this.loginSettingFrm == null)
			{
				this.loginSettingFrm = new LoginSettingFrom();
				this.loginSettingFrm.LoginFrm = this;
			}
			DebugHelper.Assert(this.loginSettingFrm != null);
			this.loginSettingFrm.Show(this);
		}
		
		private void ShowLoginForm()
		{
			this.Show();
			this.Focus();
			this.TopMost = true;
		}
		
		private void LoadPutDownMenu()
		{
			try
			{
				string homeDir = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.HomeDir, Application.StartupPath + @"\AllUser");
				if (Directory.Exists(homeDir))
				{
					DirectoryInfo dirInfo = new DirectoryInfo(homeDir);
					foreach(DirectoryInfo d in dirInfo.GetDirectories())
					{
						byte[] buff = File.ReadAllBytes(d.FullName + @"\" + FileName.User);
						ChatUser user = BufferHelper.Deserialize(buff, 0) as ChatUser;
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.AutoSize = false;
						item.Size = new System.Drawing.Size(182, 45);
						item.Text = user.UserId;
						Image head = Program.GetHeadImage(user.Head);
						item.Image = head;
						item.Tag = user;
		                item.Click += new EventHandler(item_Click);
		                menuStripId.Height += 45;
		                menuStripId.Items.Add(item);
					}
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
				
		void BtnLoginClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.isLogin)
				{
					this.imgLoadding.Visible = true;
					this.btnLogin.Text = "取     消";
					this.loginUserPanelMain.Enabled = false;
					this.isLogin = !this.isLogin;
					this.Login();
				}
				else
				{
					this.btnLogin.Text = "登     录";
					this.imgLoadding.Visible = false;
					this.loginUserPanelMain.Enabled = true;
					this.isLogin = !this.isLogin;
				}
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
			}
		}
		
		void BtnUserIdMouseDown(object sender, MouseEventArgs e)
		{
			if (this.menuStripId.Items.Count == 0)
			{
				return;
			}
			this.menuStripId.Show(this.panelId, 1, this.panelId.Height + 1);
            this.buttonIdImage = this.btnUserId.NormlBack;
            this.btnUserId.NormlBack = this.btnUserId.DownBack;
            this.btnUserId.Enabled = false;
		}
		
		void MenuStripIdClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			this.btnUserId.Enabled = true;
            this.btnUserId.NormlBack = buttonIdImage;
            this.panelId.ControlState = ControlState.Normal;
		}
		
		void TxtPasswordIconClick(object sender, EventArgs e)
		{
			PassKey pass = new PassKey(this.Left + txtPassword.Left - 25, this.Top + txtPassword.Bottom, txtPassword);
            pass.Show(this);
		}
		
		void LoginFromLoad(object sender, EventArgs e)
		{
			this.panelList.Left = this.panelItem.Left;
			this.panelList.Top = this.panelItem.Top;
			string shortDate = DateTime.Now.ToShortDateString();
			string shortTime = DateTime.Now.ToShortTimeString();
			DateTime now = DateTime.Now;
			if (now < DateTime.Parse(shortDate + " 12:00:00"))
			{
			    this.Back = ResourceLoginForm.morning;
			}
			else if (now >= DateTime.Parse(shortDate + " 12:00:00") && 
			         now <= DateTime.Parse(shortDate + " 13:00:00"))
			{
				this.Back = ResourceLoginForm.noon;
			}
			else if (now > DateTime.Parse(shortDate + " 13:00:00") &&
			         now <= DateTime.Parse(shortDate + " 18:00:00"))
			{
				this.Back = ResourceLoginForm.afternoon;
			}
			else
			{
				this.Back = ResourceLoginForm.night;
			}
			        
			string homeDir = AppConfigMgr.Instance.GetAttribute(AppConfigMgr.HomeDir, Application.StartupPath + @"\AllUser");
			if (Directory.Exists(homeDir))
			{
				DirectoryInfo dirInfo = new DirectoryInfo(homeDir);
				foreach(DirectoryInfo d in dirInfo.GetDirectories())
				{
					byte[] buff = File.ReadAllBytes(d.FullName + @"\" + FileName.User);
					ChatUser user = BufferHelper.Deserialize(buff, 0) as ChatUser;
	                LoginUserControl loginUserC = new LoginUserControl();
	                loginUserC.UserId = user.UserId;
	                loginUserC.PassWord = user.Password;
	                loginUserC.NickName = string.IsNullOrEmpty(user.NickName)? user.UserId: user.NickName;
	                loginUserC.Head = Program.GetHeadImage(user.Head);
	                loginUserC.UserControlClick += new UserControlClickHandler(loginUserC_UserControlClick);
	                loginUserC.UserControlRemove += new UserControlRemoveHandler(loginUserC_UserControlRemove);
	                this.loginUserPanelMain.AddLoginUser(loginUserC);
				}
				this.loginUserPanelMain.LayOutItem();
				this.panelList.Visible = true;
			}
			//this.loginUserPanelMain.EmptyControl += new EmptyControlsHandler(LoginForm_EmptyControl);
		}

		void LoginForm_EmptyControl(object sender, EmptyControlsEventArgs args)
		{
			this.panelList.Visible = false;
			this.panelItem.Visible = true;
		}

		void loginUserC_UserControlClick(object sender, UserControlClickEventArgs args)
		{
			this.panelList.Visible = false;
			this.panelItem.Visible = true;
			this.LoadPutDownMenu();
		}

		void item_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ChatUser user = item.Tag as ChatUser;
            this.txtUserId.Text = user.UserId;
            this.txtPassword.Text = user.Password;
            this.loginItem.Head = item.Image;
		}

		void LoginFormSysBottomClick(object sender)
		{
			this.Hide();
			this.ShowLoginSettingForm();
		}
		
		void TsmiShowClick(object sender, EventArgs e)
		{
			this.ShowLoginForm();
		}
		
		void TsmiExitClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void NotifyIconMainMouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.ShowLoginForm();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.panelItem.Visible = false;
			this.panelList.Visible = true;
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			this.panelItem.Visible = false;
			this.panelList.Visible = true;
			LoginUserControl loginUserC = new LoginUserControl();
	        loginUserC.UserId = this.txtUserId.Text;
	        loginUserC.NickName = this.txtUserId.Text;
	        loginUserC.PassWord = this.txtPassword.Text;
	        loginUserC.Head = ResourceForm.default_head;
	        loginUserC.UserControlClick += new UserControlClickHandler(loginUserC_UserControlClick);
	        loginUserC.UserControlRemove += new UserControlRemoveHandler(loginUserC_UserControlRemove);
	        this.loginUserPanelMain.AddLoginUser(loginUserC);
		}

		void loginUserC_UserControlRemove(object sender, UserControlRemoveEventArgs args)
		{
			//LoginUserControl l = sender as LoginUserControl;
			//this.loginUserPanelMain.RemoveLoginUser(l.UserId);
		}
		
		void LoginFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.count != 0)
			{
				e.Cancel = true;
				this.notifyIconMain.Visible = false;
				this.Hide();
			}
		}

        private void panelItem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUserId_Click(object sender, EventArgs e)
        {

        }
    }
}
