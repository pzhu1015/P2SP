/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-22
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class LoginForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new CCWin.SkinControl.SkinButtom();
            this.imgLoadding = new System.Windows.Forms.PictureBox();
            this.txtPassword = new CCWin.SkinControl.SkinTextBox();
            this.panelId = new CCWin.SkinControl.SkinPanel();
            this.btnUserId = new CCWin.SkinControl.SkinButtom();
            this.txtUserId = new CCWin.SkinControl.WaterTextBox();
            this.btnRegist = new CCWin.SkinControl.SkinButtom();
            this.skinButtom3 = new CCWin.SkinControl.SkinButtom();
            this.menuStripId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.btnCancel = new CCWin.SkinControl.SkinButtom();
            this.btnOK = new CCWin.SkinControl.SkinButtom();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.menueStripMain = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelList = new System.Windows.Forms.Panel();
            this.loginUserPanelMain = new UserComponents.ChatComp.LoginUserPanel();
            this.panelItem = new System.Windows.Forms.Panel();
            this.loginItem = new UserComponents.ChatComp.LoginUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.panelId.SuspendLayout();
            this.menueStripMain.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLogin.DownBack = global::ChatClientUI.ResourceLoginForm.button_login_down;
            this.btnLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLogin.Location = new System.Drawing.Point(82, 115);
            this.btnLogin.MouseBack = global::ChatClientUI.ResourceLoginForm.button_login_hover;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = global::ChatClientUI.ResourceLoginForm.button_login_normal;
            this.btnLogin.Size = new System.Drawing.Size(258, 49);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登        录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
            // 
            // imgLoadding
            // 
            this.imgLoadding.BackColor = System.Drawing.Color.Transparent;
            this.imgLoadding.Image = global::ChatClientUI.ResourceLoginForm.imgLoadding_Image;
            this.imgLoadding.Location = new System.Drawing.Point(0, 117);
            this.imgLoadding.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadding.Name = "imgLoadding";
            this.imgLoadding.Size = new System.Drawing.Size(377, 2);
            this.imgLoadding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoadding.TabIndex = 18;
            this.imgLoadding.TabStop = false;
            this.imgLoadding.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPassword.Icon = global::ChatClientUI.ResourceLoginForm.imgRjp_BackgroundImage;
            this.txtPassword.IconIsButton = true;
            this.txtPassword.IsPasswordChat = '●';
            this.txtPassword.IsSystemPasswordChar = true;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(123, 48);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPassword.MouseBack = null;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NormlBack = null;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.Size = new System.Drawing.Size(185, 28);
            this.txtPassword.TabIndex = 20;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPassword.WaterText = "密码";
            this.txtPassword.WordWrap = true;
            this.txtPassword.IconClick += new System.EventHandler(this.TxtPasswordIconClick);
            // 
            // panelId
            // 
            this.panelId.BackColor = System.Drawing.Color.Transparent;
            this.panelId.BackgroundImage = global::ChatClientUI.ResourceLoginForm.panelBackgroundImage;
            this.panelId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelId.Controls.Add(this.btnUserId);
            this.panelId.Controls.Add(this.txtUserId);
            this.panelId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelId.DownBack = global::ChatClientUI.ResourceLoginForm.inputbox_hover;
            this.panelId.Location = new System.Drawing.Point(118, 3);
            this.panelId.MouseBack = global::ChatClientUI.ResourceLoginForm.inputbox_hover;
            this.panelId.Name = "panelId";
            this.panelId.NormlBack = global::ChatClientUI.ResourceLoginForm.inputbox;
            this.panelId.Palace = true;
            this.panelId.Size = new System.Drawing.Size(185, 28);
            this.panelId.TabIndex = 21;
            // 
            // btnUserId
            // 
            this.btnUserId.BackColor = System.Drawing.Color.Transparent;
            this.btnUserId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUserId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnUserId.DownBack = global::ChatClientUI.ResourceLoginForm.login_inputbtn_down;
            this.btnUserId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnUserId.Location = new System.Drawing.Point(161, 2);
            this.btnUserId.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserId.MouseBack = global::ChatClientUI.ResourceLoginForm.login_inputbtn_highlight;
            this.btnUserId.Name = "btnUserId";
            this.btnUserId.NormlBack = global::ChatClientUI.ResourceLoginForm.login_inputbtn_normal;
            this.btnUserId.Size = new System.Drawing.Size(22, 24);
            this.btnUserId.TabIndex = 23;
            this.btnUserId.UseVisualStyleBackColor = false;
            this.btnUserId.Click += new System.EventHandler(this.btnUserId_Click);
            this.btnUserId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnUserIdMouseDown);
            // 
            // txtUserId
            // 
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserId.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtUserId.Location = new System.Drawing.Point(5, 3);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(156, 18);
            this.txtUserId.TabIndex = 22;
            this.txtUserId.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtUserId.WaterText = "QQ号码/手机/邮箱";
            this.txtUserId.WordWrap = false;
            // 
            // btnRegist
            // 
            this.btnRegist.BackColor = System.Drawing.Color.Transparent;
            this.btnRegist.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRegist.DownBack = global::ChatClientUI.ResourceLoginForm.zhuce_press;
            this.btnRegist.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRegist.Location = new System.Drawing.Point(301, 11);
            this.btnRegist.MouseBack = global::ChatClientUI.ResourceLoginForm.zhuce_hover;
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.NormlBack = global::ChatClientUI.ResourceLoginForm.zhuce;
            this.btnRegist.Size = new System.Drawing.Size(51, 16);
            this.btnRegist.TabIndex = 24;
            this.btnRegist.UseVisualStyleBackColor = true;
            // 
            // skinButtom3
            // 
            this.skinButtom3.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom3.DownBack = global::ChatClientUI.ResourceLoginForm.mima_press;
            this.skinButtom3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButtom3.Location = new System.Drawing.Point(301, 46);
            this.skinButtom3.MouseBack = global::ChatClientUI.ResourceLoginForm.mima_hover;
            this.skinButtom3.Name = "skinButtom3";
            this.skinButtom3.NormlBack = global::ChatClientUI.ResourceLoginForm.mima;
            this.skinButtom3.Size = new System.Drawing.Size(51, 16);
            this.skinButtom3.TabIndex = 25;
            this.skinButtom3.UseVisualStyleBackColor = true;
            // 
            // menuStripId
            // 
            this.menuStripId.Arrow = System.Drawing.Color.Black;
            this.menuStripId.AutoSize = false;
            this.menuStripId.Back = System.Drawing.Color.White;
            this.menuStripId.BackColor = System.Drawing.Color.White;
            this.menuStripId.BackRadius = 4;
            this.menuStripId.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(209)))));
            this.menuStripId.Fore = System.Drawing.Color.Black;
            this.menuStripId.HoverFore = System.Drawing.Color.White;
            this.menuStripId.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStripId.ItemAnamorphosis = false;
            this.menuStripId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemBorderShow = false;
            this.menuStripId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemRadius = 4;
            this.menuStripId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripId.Name = "MenuId";
            this.menuStripId.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Size = new System.Drawing.Size(183, 4);
            this.menuStripId.TitleAnamorphosis = false;
            this.menuStripId.TitleColor = System.Drawing.Color.White;
            this.menuStripId.TitleRadius = 4;
            this.menuStripId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.MenuStripIdClosing);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
            this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(380, 9);
            this.btnCancel.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
            this.btnCancel.Size = new System.Drawing.Size(69, 30);
            this.btnCancel.TabIndex = 132;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
            this.btnOK.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(370, 46);
            this.btnOK.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
            this.btnOK.Size = new System.Drawing.Size(79, 30);
            this.btnOK.TabIndex = 131;
            this.btnOK.Text = "确定添加";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.menueStripMain;
            this.notifyIconMain.Icon = global::ChatClientUI.ResourceMainForm.logo_xp_16;
            this.notifyIconMain.Text = "登录";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMainMouseDoubleClick);
            // 
            // menueStripMain
            // 
            this.menueStripMain.Arrow = System.Drawing.Color.Black;
            this.menueStripMain.Back = System.Drawing.Color.White;
            this.menueStripMain.BackRadius = 4;
            this.menueStripMain.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menueStripMain.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menueStripMain.Fore = System.Drawing.Color.Black;
            this.menueStripMain.HoverFore = System.Drawing.Color.White;
            this.menueStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menueStripMain.ItemAnamorphosis = false;
            this.menueStripMain.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menueStripMain.ItemBorderShow = true;
            this.menueStripMain.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menueStripMain.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menueStripMain.ItemRadius = 4;
            this.menueStripMain.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menueStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.menueStripMain.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menueStripMain.Name = "skinContextMenuStrip1";
            this.menueStripMain.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menueStripMain.Size = new System.Drawing.Size(137, 48);
            this.menueStripMain.TitleAnamorphosis = false;
            this.menueStripMain.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menueStripMain.TitleRadius = 4;
            this.menueStripMain.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(136, 22);
            this.tsmiShow.Text = "打开主面板";
            this.tsmiShow.Click += new System.EventHandler(this.TsmiShowClick);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(136, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExitClick);
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.Transparent;
            this.panelList.Controls.Add(this.loginUserPanelMain);
            this.panelList.Controls.Add(this.btnLogin);
            this.panelList.Controls.Add(this.imgLoadding);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelList.Location = new System.Drawing.Point(3, 156);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(473, 171);
            this.panelList.TabIndex = 33;
            this.panelList.Visible = false;
            // 
            // loginUserPanelMain
            // 
            this.loginUserPanelMain.AutoSize = true;
            this.loginUserPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.loginUserPanelMain.Location = new System.Drawing.Point(77, 3);
            this.loginUserPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.loginUserPanelMain.MaximumSize = new System.Drawing.Size(300, 110);
            this.loginUserPanelMain.MinimumSize = new System.Drawing.Size(300, 110);
            this.loginUserPanelMain.Name = "loginUserPanelMain";
            this.loginUserPanelMain.Size = new System.Drawing.Size(300, 110);
            this.loginUserPanelMain.TabIndex = 32;
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.btnCancel);
            this.panelItem.Controls.Add(this.loginItem);
            this.panelItem.Controls.Add(this.btnOK);
            this.panelItem.Controls.Add(this.panelId);
            this.panelItem.Controls.Add(this.skinButtom3);
            this.panelItem.Controls.Add(this.txtPassword);
            this.panelItem.Controls.Add(this.btnRegist);
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelItem.Location = new System.Drawing.Point(3, 54);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(473, 102);
            this.panelItem.TabIndex = 34;
            this.panelItem.Visible = false;
            this.panelItem.Paint += new System.Windows.Forms.PaintEventHandler(this.panelItem_Paint);
            // 
            // loginItem
            // 
            this.loginItem.BackColor = System.Drawing.Color.Transparent;
            this.loginItem.Head = global::ChatClientUI.ResourceForm.default_head;
            this.loginItem.IsShowCheckBox = false;
            this.loginItem.IsShowNickName = false;
            this.loginItem.IsShowRemove = false;
            this.loginItem.Location = new System.Drawing.Point(0, -1);
            this.loginItem.Margin = new System.Windows.Forms.Padding(0);
            this.loginItem.MaximumSize = new System.Drawing.Size(100, 100);
            this.loginItem.MinimumSize = new System.Drawing.Size(100, 80);
            this.loginItem.Name = "loginItem";
            this.loginItem.NickName = null;
            this.loginItem.PassWord = null;
            this.loginItem.Size = new System.Drawing.Size(100, 100);
            this.loginItem.TabIndex = 30;
            this.loginItem.UserId = null;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::ChatClientUI.ResourceLoginForm.morning;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(127)))), ((int)(((byte)(90)))));
            this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(479, 330);
            this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
            this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
            this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
            this.Controls.Add(this.panelItem);
            this.Controls.Add(this.panelList);
            this.MaximizeBox = false;
            this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
            this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
            this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
            this.Name = "LoginForm";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SysBottomDown = global::ChatClientUI.ResourceForm.btn_set_press;
            this.SysBottomMouse = global::ChatClientUI.ResourceForm.btn_set_hover;
            this.SysBottomNorml = global::ChatClientUI.ResourceForm.btn_set_normal;
            this.SysBottomToolTip = "设置";
            this.SysBottomVisibale = true;
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.LoginFormSysBottomClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginFormFormClosing);
            this.Load += new System.EventHandler(this.LoginFromLoad);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.panelId.ResumeLayout(false);
            this.panelId.PerformLayout();
            this.menueStripMain.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Panel panelList;
		private CCWin.SkinControl.SkinButtom btnOK;
		private CCWin.SkinControl.SkinButtom btnCancel;
		private System.Windows.Forms.Panel panelItem;
		private UserComponents.ChatComp.LoginUserPanel loginUserPanelMain;
		private UserComponents.ChatComp.LoginUserControl loginItem;
		private CCWin.SkinControl.SkinContextMenuStrip menueStripMain;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.ToolStripMenuItem tsmiShow;
		private System.Windows.Forms.NotifyIcon notifyIconMain;
		private CCWin.SkinControl.SkinButtom btnRegist;
		private CCWin.SkinControl.SkinPanel panelId;
		private CCWin.SkinControl.SkinContextMenuStrip menuStripId;
		private CCWin.SkinControl.SkinButtom btnUserId;
		private CCWin.SkinControl.SkinTextBox txtPassword;
		private CCWin.SkinControl.WaterTextBox txtUserId;
		private CCWin.SkinControl.SkinButtom btnLogin;
		private CCWin.SkinControl.SkinButtom skinButtom3;
		private System.Windows.Forms.PictureBox imgLoadding;
	}
}
