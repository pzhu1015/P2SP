/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-25
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UserComponents.ChatComp
{
	partial class LoginUserPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUserPanel));
            this.panelMain = new CCWin.SkinControl.SkinPanel();
            this.panelList = new CCWin.SkinControl.SkinPanel();
            this.panelItem = new CCWin.SkinControl.SkinPanel();
            this.txtUserId = new CCWin.SkinControl.SkinTextBox();
            this.msUserId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.btnUserId = new CCWin.SkinControl.SkinButtom();
            this.txtPassword = new CCWin.SkinControl.SkinTextBox();
            this.skinButtom3 = new CCWin.SkinControl.SkinButtom();
            this.btnRegist = new CCWin.SkinControl.SkinButtom();
            this.btnCancel = new CCWin.SkinControl.SkinButtom();
            this.btnOK = new CCWin.SkinControl.SkinButtom();
            this.btnRight = new CCWin.SkinControl.SkinButtom();
            this.btnLeft = new CCWin.SkinControl.SkinButtom();
            this.btnLogin = new CCWin.SkinControl.SkinButtom();
            this.btnAdd = new CCWin.SkinControl.SkinButtom();
            this.loginUserControl = new UserComponents.ChatComp.LoginUserControl();
            this.panelList.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelMain.DownBack = null;
            this.panelMain.Location = new System.Drawing.Point(46, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.MouseBack = null;
            this.panelMain.Name = "panelMain";
            this.panelMain.NormlBack = null;
            this.panelMain.Size = new System.Drawing.Size(321, 110);
            this.panelMain.TabIndex = 6;
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.Transparent;
            this.panelList.Controls.Add(this.btnRight);
            this.panelList.Controls.Add(this.btnLeft);
            this.panelList.Controls.Add(this.btnLogin);
            this.panelList.Controls.Add(this.btnAdd);
            this.panelList.Controls.Add(this.panelMain);
            this.panelList.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelList.DownBack = null;
            this.panelList.Location = new System.Drawing.Point(0, 233);
            this.panelList.Margin = new System.Windows.Forms.Padding(2);
            this.panelList.MouseBack = null;
            this.panelList.Name = "panelList";
            this.panelList.NormlBack = null;
            this.panelList.Size = new System.Drawing.Size(418, 175);
            this.panelList.TabIndex = 9;
            this.panelList.Visible = false;
            this.panelList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelList_MouseDown);
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.loginUserControl);
            this.panelItem.Controls.Add(this.btnUserId);
            this.panelItem.Controls.Add(this.txtUserId);
            this.panelItem.Controls.Add(this.txtPassword);
            this.panelItem.Controls.Add(this.skinButtom3);
            this.panelItem.Controls.Add(this.btnRegist);
            this.panelItem.Controls.Add(this.btnCancel);
            this.panelItem.Controls.Add(this.btnOK);
            this.panelItem.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelItem.DownBack = null;
            this.panelItem.Location = new System.Drawing.Point(0, 82);
            this.panelItem.Margin = new System.Windows.Forms.Padding(2);
            this.panelItem.MouseBack = null;
            this.panelItem.Name = "panelItem";
            this.panelItem.NormlBack = null;
            this.panelItem.Size = new System.Drawing.Size(418, 151);
            this.panelItem.TabIndex = 10;
            this.panelItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelItem_MouseDown);
            // 
            // txtUserId
            // 
            this.txtUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUserId.BackColor = System.Drawing.Color.Transparent;
            this.txtUserId.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtUserId.Icon = null;
            this.txtUserId.IconIsButton = true;
            this.txtUserId.IsPasswordChat = '\0';
            this.txtUserId.IsSystemPasswordChar = false;
            this.txtUserId.Lines = new string[0];
            this.txtUserId.Location = new System.Drawing.Point(120, 34);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserId.MaxLength = 32767;
            this.txtUserId.MinimumSize = new System.Drawing.Size(0, 26);
            this.txtUserId.MouseBack = null;
            this.txtUserId.Multiline = false;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.NormlBack = null;
            this.txtUserId.Padding = new System.Windows.Forms.Padding(4);
            this.txtUserId.ReadOnly = false;
            this.txtUserId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserId.Size = new System.Drawing.Size(218, 28);
            this.txtUserId.TabIndex = 155;
            this.txtUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserId.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtUserId.WaterText = "QQ号码/手机/邮箱";
            this.txtUserId.WordWrap = true;
            // 
            // msUserId
            // 
            this.msUserId.Arrow = System.Drawing.Color.Black;
            this.msUserId.AutoSize = false;
            this.msUserId.Back = System.Drawing.Color.White;
            this.msUserId.BackRadius = 4;
            this.msUserId.Base = System.Drawing.Color.White;
            this.msUserId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msUserId.Fore = System.Drawing.Color.Black;
            this.msUserId.HoverFore = System.Drawing.Color.White;
            this.msUserId.ItemAnamorphosis = false;
            this.msUserId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.msUserId.ItemBorderShow = true;
            this.msUserId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.msUserId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.msUserId.ItemRadius = 4;
            this.msUserId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.msUserId.ItemSplitter = System.Drawing.Color.White;
            this.msUserId.Name = "msUserId";
            this.msUserId.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.msUserId.Size = new System.Drawing.Size(250, 71);
            this.msUserId.TitleAnamorphosis = true;
            this.msUserId.TitleColor = System.Drawing.Color.White;
            this.msUserId.TitleRadius = 4;
            this.msUserId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.msUserId.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.msUserId_Closing);
            // 
            // btnUserId
            // 
            this.btnUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUserId.BackColor = System.Drawing.Color.White;
            this.btnUserId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUserId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnUserId.DownBack = global::UserComponents.ChatCompResource.login_inputbtn_down;
            this.btnUserId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnUserId.Location = new System.Drawing.Point(315, 37);
            this.btnUserId.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserId.MouseBack = global::UserComponents.ChatCompResource.login_inputbtn_highlight;
            this.btnUserId.Name = "btnUserId";
            this.btnUserId.NormlBack = global::UserComponents.ChatCompResource.login_inputbtn_normal;
            this.btnUserId.Size = new System.Drawing.Size(20, 22);
            this.btnUserId.TabIndex = 154;
            this.btnUserId.UseVisualStyleBackColor = false;
            this.btnUserId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUserId_MouseDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPassword.Icon = global::UserComponents.ChatCompResource.pass_keyboard;
            this.txtPassword.IconIsButton = true;
            this.txtPassword.IsPasswordChat = '●';
            this.txtPassword.IsSystemPasswordChar = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(120, 71);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(0, 22);
            this.txtPassword.MouseBack = null;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NormlBack = null;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(4, 4, 21, 4);
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.Size = new System.Drawing.Size(218, 28);
            this.txtPassword.TabIndex = 153;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPassword.WaterText = "密码";
            this.txtPassword.WordWrap = true;
            this.txtPassword.IconClick += new System.EventHandler(this.txtPassword_IconClick);
            // 
            // skinButtom3
            // 
            this.skinButtom3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skinButtom3.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinButtom3.DownBack = global::UserComponents.ChatCompResource.mima_press;
            this.skinButtom3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButtom3.Location = new System.Drawing.Point(357, 78);
            this.skinButtom3.Margin = new System.Windows.Forms.Padding(2);
            this.skinButtom3.MouseBack = global::UserComponents.ChatCompResource.mima_hover;
            this.skinButtom3.Name = "skinButtom3";
            this.skinButtom3.NormlBack = global::UserComponents.ChatCompResource.mima;
            this.skinButtom3.Size = new System.Drawing.Size(38, 13);
            this.skinButtom3.TabIndex = 152;
            this.skinButtom3.UseVisualStyleBackColor = true;
            // 
            // btnRegist
            // 
            this.btnRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegist.BackColor = System.Drawing.Color.Transparent;
            this.btnRegist.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegist.DownBack = global::UserComponents.ChatCompResource.zhuce_press;
            this.btnRegist.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRegist.Location = new System.Drawing.Point(357, 41);
            this.btnRegist.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegist.MouseBack = global::UserComponents.ChatCompResource.zhuce_hover;
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.NormlBack = global::UserComponents.ChatCompResource.zhuce;
            this.btnRegist.Size = new System.Drawing.Size(38, 13);
            this.btnRegist.TabIndex = 151;
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = global::UserComponents.ChatCompResource.btnDownBack;
            this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(247, 107);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.MouseBack = global::UserComponents.ChatCompResource.btnMouseBack;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = global::UserComponents.ChatCompResource.btnNormlBack;
            this.btnCancel.Size = new System.Drawing.Size(59, 27);
            this.btnCancel.TabIndex = 150;
            this.btnCancel.Text = "取    消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.DownBack = global::UserComponents.ChatCompResource.btnDownBack;
            this.btnOK.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(163, 107);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.MouseBack = global::UserComponents.ChatCompResource.btnMouseBack;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = global::UserComponents.ChatCompResource.btnNormlBack;
            this.btnOK.Size = new System.Drawing.Size(66, 27);
            this.btnOK.TabIndex = 149;
            this.btnOK.Text = "确定添加";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRight.DownBack = global::UserComponents.ChatCompResource.right_40;
            this.btnRight.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRight.Location = new System.Drawing.Point(365, 35);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.MouseBack = global::UserComponents.ChatCompResource.right_40;
            this.btnRight.Name = "btnRight";
            this.btnRight.NormlBack = global::UserComponents.ChatCompResource.right_40;
            this.btnRight.Size = new System.Drawing.Size(15, 34);
            this.btnRight.TabIndex = 10;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Visible = false;
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLeft.DownBack = global::UserComponents.ChatCompResource.left_40;
            this.btnLeft.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLeft.Location = new System.Drawing.Point(38, 35);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.MouseBack = global::UserComponents.ChatCompResource.left_40;
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.NormlBack = global::UserComponents.ChatCompResource.left_40;
            this.btnLeft.Size = new System.Drawing.Size(15, 34);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLogin.DownBack = global::UserComponents.ChatCompResource.button_login_down;
            this.btnLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLogin.Location = new System.Drawing.Point(120, 124);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.MouseBack = global::UserComponents.ChatCompResource.button_login_hover;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = global::UserComponents.ChatCompResource.button_login_normal;
            this.btnLogin.Size = new System.Drawing.Size(184, 39);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "登        录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAdd.DownBack = global::UserComponents.ChatCompResource.btnAdd;
            this.btnAdd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnAdd.Location = new System.Drawing.Point(378, 37);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.MouseBack = global::UserComponents.ChatCompResource.btnAdd;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NormlBack = global::UserComponents.ChatCompResource.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(30, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // loginUserControl
            // 
            this.loginUserControl.BackColor = System.Drawing.Color.Transparent;
            this.loginUserControl.Head = ((System.Drawing.Image)(resources.GetObject("loginUserControl.Head")));
            this.loginUserControl.IsShowCheckBox = false;
            this.loginUserControl.IsShowRemove = false;
            this.loginUserControl.Location = new System.Drawing.Point(11, 24);
            this.loginUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.loginUserControl.MaximumSize = new System.Drawing.Size(100, 110);
            this.loginUserControl.MinimumSize = new System.Drawing.Size(80, 80);
            this.loginUserControl.Name = "loginUserControl";
            this.loginUserControl.NickName = null;
            this.loginUserControl.PassWord = null;
            this.loginUserControl.Size = new System.Drawing.Size(100, 110);
            this.loginUserControl.TabIndex = 156;
            this.loginUserControl.UserId = null;
            // 
            // LoginUserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelItem);
            this.Controls.Add(this.panelList);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(750, 480);
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "LoginUserPanel";
            this.Size = new System.Drawing.Size(418, 408);
            this.panelList.ResumeLayout(false);
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.ResumeLayout(false);

		}

        private CCWin.SkinControl.SkinPanel panelMain;
        private CCWin.SkinControl.SkinButtom btnAdd;
        private CCWin.SkinControl.SkinButtom btnLogin;
        private CCWin.SkinControl.SkinPanel panelList;
        private CCWin.SkinControl.SkinButtom btnOK;
        private CCWin.SkinControl.SkinButtom btnCancel;
        private CCWin.SkinControl.SkinButtom btnRegist;
        private CCWin.SkinControl.SkinButtom skinButtom3;
        private CCWin.SkinControl.SkinTextBox txtPassword;
        private CCWin.SkinControl.SkinTextBox txtUserId;
        private CCWin.SkinControl.SkinButtom btnUserId;
        private CCWin.SkinControl.SkinPanel panelItem;
        private CCWin.SkinControl.SkinButtom btnLeft;
        private CCWin.SkinControl.SkinButtom btnRight;
        private LoginUserControl loginUserControl;
        private CCWin.SkinControl.SkinContextMenuStrip msUserId;
    }
}
