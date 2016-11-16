/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-5-8
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatServerUI
{
	partial class ChatServerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatServerForm));
			this.skinMenuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
			this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.rtxtRecve = new System.Windows.Forms.RichTextBox();
			this.btnStop = new CCWin.SkinControl.SkinButtom();
			this.btnStart = new CCWin.SkinControl.SkinButtom();
			this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
			this.scmsNotifyMenu = new CCWin.SkinControl.SkinContextMenuStrip();
			this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.skinMenuStrip1.SuspendLayout();
			this.skinToolStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.scmsNotifyMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// skinMenuStrip1
			// 
			this.skinMenuStrip1.Arrow = System.Drawing.Color.Black;
			this.skinMenuStrip1.Back = System.Drawing.Color.White;
			this.skinMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.skinMenuStrip1.BackRadius = 1;
			this.skinMenuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
			this.skinMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.skinMenuStrip1.BaseFore = System.Drawing.Color.Black;
			this.skinMenuStrip1.BaseForeAnamorphosis = false;
			this.skinMenuStrip1.BaseForeAnamorphosisBorder = 4;
			this.skinMenuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
			this.skinMenuStrip1.BaseHoverFore = System.Drawing.Color.White;
			this.skinMenuStrip1.BaseItemAnamorphosis = true;
			this.skinMenuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.BaseItemBorderShow = true;
			this.skinMenuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemDown")));
			this.skinMenuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemMouse")));
			this.skinMenuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.BaseItemRadius = 4;
			this.skinMenuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinMenuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
			this.skinMenuStrip1.Fore = System.Drawing.Color.Black;
			this.skinMenuStrip1.HoverFore = System.Drawing.Color.White;
			this.skinMenuStrip1.ItemAnamorphosis = true;
			this.skinMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.ItemBorderShow = true;
			this.skinMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinMenuStrip1.ItemRadius = 4;
			this.skinMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.文件FToolStripMenuItem});
			this.skinMenuStrip1.Location = new System.Drawing.Point(3, 24);
			this.skinMenuStrip1.Name = "skinMenuStrip1";
			this.skinMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinMenuStrip1.Size = new System.Drawing.Size(584, 24);
			this.skinMenuStrip1.TabIndex = 4;
			this.skinMenuStrip1.Text = "skinMenuStrip1";
			this.skinMenuStrip1.TitleAnamorphosis = true;
			this.skinMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.skinMenuStrip1.TitleRadius = 1;
			this.skinMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			// 
			// 文件FToolStripMenuItem
			// 
			this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
			this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.文件FToolStripMenuItem.Text = "文件(&F)";
			// 
			// skinToolStrip1
			// 
			this.skinToolStrip1.Arrow = System.Drawing.Color.Black;
			this.skinToolStrip1.Back = System.Drawing.Color.White;
			this.skinToolStrip1.BackRadius = 1;
			this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
			this.skinToolStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
			this.skinToolStrip1.BaseForeAnamorphosis = false;
			this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
			this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
			this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
			this.skinToolStrip1.BaseItemAnamorphosis = true;
			this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.BaseItemBorderShow = true;
			this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
			this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
			this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.BaseItemRadius = 4;
			this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
			this.skinToolStrip1.Fore = System.Drawing.Color.Black;
			this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
			this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
			this.skinToolStrip1.ItemAnamorphosis = true;
			this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.ItemBorderShow = true;
			this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.skinToolStrip1.ItemRadius = 4;
			this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButton1,
									this.toolStripButton2});
			this.skinToolStrip1.Location = new System.Drawing.Point(3, 48);
			this.skinToolStrip1.Name = "skinToolStrip1";
			this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.skinToolStrip1.Size = new System.Drawing.Size(584, 25);
			this.skinToolStrip1.TabIndex = 5;
			this.skinToolStrip1.Text = "skinToolStrip1";
			this.skinToolStrip1.TitleAnamorphosis = true;
			this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
			this.skinToolStrip1.TitleRadius = 4;
			this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
			this.toolStripButton1.Text = "开始";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(49, 22);
			this.toolStripButton2.Text = "停止";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(3, 73);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.rtxtRecve);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnStop);
			this.splitContainer1.Panel2.Controls.Add(this.btnStart);
			this.splitContainer1.Size = new System.Drawing.Size(584, 291);
			this.splitContainer1.SplitterDistance = 235;
			this.splitContainer1.TabIndex = 8;
			// 
			// rtxtRecve
			// 
			this.rtxtRecve.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxtRecve.Location = new System.Drawing.Point(0, 0);
			this.rtxtRecve.Name = "rtxtRecve";
			this.rtxtRecve.Size = new System.Drawing.Size(584, 235);
			this.rtxtRecve.TabIndex = 3;
			this.rtxtRecve.Text = "";
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.BackColor = System.Drawing.Color.Transparent;
			this.btnStop.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnStop.DownBack = ((System.Drawing.Image)(resources.GetObject("btnStop.DownBack")));
			this.btnStop.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStop.Location = new System.Drawing.Point(490, 16);
			this.btnStop.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnStop.MouseBack")));
			this.btnStop.Name = "btnStop";
			this.btnStop.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnStop.NormlBack")));
			this.btnStop.Size = new System.Drawing.Size(75, 24);
			this.btnStop.TabIndex = 137;
			this.btnStop.Text = "停止(&P)";
			this.btnStop.UseVisualStyleBackColor = false;
			this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.BackColor = System.Drawing.Color.Transparent;
			this.btnStart.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnStart.DownBack = ((System.Drawing.Image)(resources.GetObject("btnStart.DownBack")));
			this.btnStart.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStart.Location = new System.Drawing.Point(396, 16);
			this.btnStart.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnStart.MouseBack")));
			this.btnStart.Name = "btnStart";
			this.btnStart.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnStart.NormlBack")));
			this.btnStart.Size = new System.Drawing.Size(75, 24);
			this.btnStart.TabIndex = 136;
			this.btnStart.Text = "开始(&S)";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// niMain
			// 
			this.niMain.BalloonTipText = "聊天服务程序";
			this.niMain.ContextMenuStrip = this.scmsNotifyMenu;
			this.niMain.Icon = global::ChatServerUI.MainResource.logo_xp_16;
			this.niMain.Text = "聊天服务程序";
			this.niMain.Visible = true;
			this.niMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NiMainMouseDoubleClick);
			// 
			// scmsNotifyMenu
			// 
			this.scmsNotifyMenu.Arrow = System.Drawing.Color.Black;
			this.scmsNotifyMenu.Back = System.Drawing.Color.White;
			this.scmsNotifyMenu.BackRadius = 4;
			this.scmsNotifyMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
			this.scmsNotifyMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
			this.scmsNotifyMenu.Fore = System.Drawing.Color.Black;
			this.scmsNotifyMenu.HoverFore = System.Drawing.Color.White;
			this.scmsNotifyMenu.ItemAnamorphosis = false;
			this.scmsNotifyMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.scmsNotifyMenu.ItemBorderShow = false;
			this.scmsNotifyMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.scmsNotifyMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.scmsNotifyMenu.ItemRadius = 4;
			this.scmsNotifyMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.scmsNotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsmiShow,
									this.tsmiExit});
			this.scmsNotifyMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
			this.scmsNotifyMenu.Name = "scmsNotifyMenu";
			this.scmsNotifyMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
			this.scmsNotifyMenu.Size = new System.Drawing.Size(153, 70);
			this.scmsNotifyMenu.TitleAnamorphosis = false;
			this.scmsNotifyMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
			this.scmsNotifyMenu.TitleRadius = 4;
			this.scmsNotifyMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
			// 
			// tsmiShow
			// 
			this.tsmiShow.Name = "tsmiShow";
			this.tsmiShow.Size = new System.Drawing.Size(152, 22);
			this.tsmiShow.Text = "打开主面板";
			this.tsmiShow.Click += new System.EventHandler(this.TsmiShowClick);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(152, 22);
			this.tsmiExit.Text = "退出";
			this.tsmiExit.Click += new System.EventHandler(this.TsmiExitClick);
			// 
			// ChatServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.ClientSize = new System.Drawing.Size(590, 367);
			this.CloseDownBack = global::ChatServerUI.MainResource.btn_close_down;
			this.CloseMouseBack = global::ChatServerUI.MainResource.btn_close_highlight;
			this.CloseNormlBack = global::ChatServerUI.MainResource.btn_close_disable;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.skinToolStrip1);
			this.Controls.Add(this.skinMenuStrip1);
			this.MainMenuStrip = this.skinMenuStrip1;
			this.MaxDownBack = global::ChatServerUI.MainResource.btn_max_down;
			this.MaxMouseBack = global::ChatServerUI.MainResource.btn_max_highlight;
			this.MaxNormlBack = global::ChatServerUI.MainResource.btn_max_normal;
			this.MiniDownBack = global::ChatServerUI.MainResource.btn_mini_down;
			this.MiniMouseBack = global::ChatServerUI.MainResource.btn_mini_highlight;
			this.MiniNormlBack = global::ChatServerUI.MainResource.btn_mini_normal;
			this.Name = "ChatServerForm";
			this.RestoreDownBack = global::ChatServerUI.MainResource.btn_restore_down;
			this.RestoreMouseBack = global::ChatServerUI.MainResource.btn_restore_highlight;
			this.RestoreNormlBack = global::ChatServerUI.MainResource.btn_restore_normal;
			this.ShowDrawIcon = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "P2P聊天服务程序";
			this.Load += new System.EventHandler(this.ChatServerFormLoad);
			this.skinMenuStrip1.ResumeLayout(false);
			this.skinMenuStrip1.PerformLayout();
			this.skinToolStrip1.ResumeLayout(false);
			this.skinToolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.scmsNotifyMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem tsmiShow;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private CCWin.SkinControl.SkinContextMenuStrip scmsNotifyMenu;
		private System.Windows.Forms.NotifyIcon niMain;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
		private CCWin.SkinControl.SkinMenuStrip skinMenuStrip1;
		private System.Windows.Forms.RichTextBox rtxtRecve;
		private CCWin.SkinControl.SkinButtom btnStart;
		private CCWin.SkinControl.SkinButtom btnStop;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
