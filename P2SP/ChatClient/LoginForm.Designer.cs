namespace ChatClient
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStripId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.loginUserPanel = new UserComponents.ChatComp.LoginUserPanel();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "P2SP通信程序";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "P2SP通信程序";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // menuStripId
            // 
            this.menuStripId.Arrow = System.Drawing.Color.Black;
            this.menuStripId.Back = System.Drawing.Color.White;
            this.menuStripId.BackRadius = 4;
            this.menuStripId.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripId.Fore = System.Drawing.Color.Black;
            this.menuStripId.HoverFore = System.Drawing.Color.White;
            this.menuStripId.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripId.ItemAnamorphosis = true;
            this.menuStripId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemBorderShow = true;
            this.menuStripId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemRadius = 4;
            this.menuStripId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripId.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.Name = "menuStripId";
            this.menuStripId.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripId.Size = new System.Drawing.Size(61, 4);
            this.menuStripId.TitleAnamorphosis = true;
            this.menuStripId.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStripId.TitleRadius = 4;
            this.menuStripId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // loginUserPanel
            // 
            this.loginUserPanel.AutoSize = true;
            this.loginUserPanel.BackColor = System.Drawing.Color.White;
            this.loginUserPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginUserPanel.Location = new System.Drawing.Point(1, 134);
            this.loginUserPanel.Margin = new System.Windows.Forms.Padding(0);
            this.loginUserPanel.MaximumSize = new System.Drawing.Size(1000, 600);
            this.loginUserPanel.MinimumSize = new System.Drawing.Size(400, 200);
            this.loginUserPanel.Name = "loginUserPanel";
            this.loginUserPanel.Size = new System.Drawing.Size(430, 200);
            this.loginUserPanel.TabIndex = 1;
            this.loginUserPanel.RegistClick += new UserComponents.ChatComp.RegistClickEventHandler(this.loginUserPanel_RegistClick);
            this.loginUserPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPalace = global::ChatClient.FormResource.BackPalace;
            this.BorderWidth = 1;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(432, 335);
            this.CloseDownBack = global::ChatClient.FormResource.btn_close_down;
            this.CloseMouseBack = global::ChatClient.FormResource.btn_close_mouse;
            this.CloseNormlBack = global::ChatClient.FormResource.btn_close_normal;
            this.Controls.Add(this.loginUserPanel);
            this.MaximizeBox = false;
            this.MiniDownBack = global::ChatClient.FormResource.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.FormResource.btn_mini_mouse;
            this.MiniNormlBack = global::ChatClient.FormResource.btn_mini_normal;
            this.Name = "LoginForm";
            this.Shadow = false;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SysBottomDown = global::ChatClient.FormResource.btn_set_down;
            this.SysBottomMouse = global::ChatClient.FormResource.btn_set_mouse;
            this.SysBottomNorml = global::ChatClient.FormResource.btn_set_normal;
            this.SysBottomVisibale = true;
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.LoginForm_SysBottomClick);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private CCWin.SkinControl.SkinContextMenuStrip menuStripId;
        private UserComponents.ChatComp.LoginUserPanel loginUserPanel;
    }
}