/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-25
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.ChatComp
{
	partial class LoginUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUserControl));
            this.mainBackground = new CCWin.SkinControl.SkinPanel();
            this.headImage = new CCWin.SkinControl.SkinPanel();
            this.cbIsChecked = new CCWin.SkinControl.SkinCheckBox();
            this.btnState = new CCWin.SkinControl.SkinButtom();
            this.menuStripState = new CCWin.SkinControl.SkinContextMenuStrip();
            this.在线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐身ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.忙碌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemove = new CCWin.SkinControl.SkinButtom();
            this.lblNickName = new CCWin.SkinControl.SkinLabel();
            this.mainBackground.SuspendLayout();
            this.menuStripState.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBackground
            // 
            this.mainBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainBackground.BackColor = System.Drawing.Color.Transparent;
            this.mainBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainBackground.BackgroundImage")));
            this.mainBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainBackground.Controls.Add(this.headImage);
            this.mainBackground.Controls.Add(this.cbIsChecked);
            this.mainBackground.Controls.Add(this.btnState);
            this.mainBackground.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.mainBackground.DownBack = null;
            this.mainBackground.Location = new System.Drawing.Point(13, 6);
            this.mainBackground.Margin = new System.Windows.Forms.Padding(0);
            this.mainBackground.MaximumSize = new System.Drawing.Size(107, 96);
            this.mainBackground.MinimumSize = new System.Drawing.Size(107, 96);
            this.mainBackground.MouseBack = null;
            this.mainBackground.Name = "mainBackground";
            this.mainBackground.NormlBack = null;
            this.mainBackground.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainBackground.Radius = 5;
            this.mainBackground.Size = new System.Drawing.Size(107, 96);
            this.mainBackground.TabIndex = 0;
            this.mainBackground.Click += new System.EventHandler(this.ClickLoginUserControl);
            // 
            // headImage
            // 
            this.headImage.BackColor = System.Drawing.Color.Transparent;
            this.headImage.BackgroundImage = global::Complents.ChatCompResource.default_head;
            this.headImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.headImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.headImage.DownBack = null;
            this.headImage.Location = new System.Drawing.Point(27, 25);
            this.headImage.Margin = new System.Windows.Forms.Padding(0);
            this.headImage.MaximumSize = new System.Drawing.Size(53, 50);
            this.headImage.MouseBack = null;
            this.headImage.Name = "headImage";
            this.headImage.NormlBack = null;
            this.headImage.Size = new System.Drawing.Size(53, 50);
            this.headImage.TabIndex = 0;
            this.headImage.Click += new System.EventHandler(this.ClickLoginUserControl);
            // 
            // cbIsChecked
            // 
            this.cbIsChecked.AutoSize = true;
            this.cbIsChecked.BackColor = System.Drawing.Color.Transparent;
            this.cbIsChecked.Checked = true;
            this.cbIsChecked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsChecked.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cbIsChecked.DefaultCheckButtonWidth = 15;
            this.cbIsChecked.DownBack = global::Complents.ChatCompResource.checkbox_pushed;
            this.cbIsChecked.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbIsChecked.LightEffect = false;
            this.cbIsChecked.LightEffectWidth = 0;
            this.cbIsChecked.Location = new System.Drawing.Point(3, 0);
            this.cbIsChecked.Margin = new System.Windows.Forms.Padding(0);
            this.cbIsChecked.MouseBack = global::Complents.ChatCompResource.checkbox_hightlight;
            this.cbIsChecked.Name = "cbIsChecked";
            this.cbIsChecked.NormlBack = global::Complents.ChatCompResource.checkbox_normal;
            this.cbIsChecked.SelectedDownBack = global::Complents.ChatCompResource.checkbox_tick_pushed;
            this.cbIsChecked.SelectedMouseBack = global::Complents.ChatCompResource.checkbox_tick_highlight;
            this.cbIsChecked.SelectedNormlBack = global::Complents.ChatCompResource.checkbox_tick_pushed;
            this.cbIsChecked.Size = new System.Drawing.Size(35, 24);
            this.cbIsChecked.TabIndex = 3;
            this.cbIsChecked.Text = " ";
            this.cbIsChecked.UseVisualStyleBackColor = true;
            // 
            // btnState
            // 
            this.btnState.BackColor = System.Drawing.Color.Transparent;
            this.btnState.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.btnState.ContextMenuStrip = this.menuStripState;
            this.btnState.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnState.DownBack = global::Complents.ChatCompResource.btnState_DownBack;
            this.btnState.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnState.Image = global::Complents.ChatCompResource.online;
            this.btnState.Location = new System.Drawing.Point(81, 72);
            this.btnState.Margin = new System.Windows.Forms.Padding(0);
            this.btnState.MouseBack = global::Complents.ChatCompResource.btnState_MouseBack;
            this.btnState.Name = "btnState";
            this.btnState.NormlBack = null;
            this.btnState.Size = new System.Drawing.Size(24, 22);
            this.btnState.TabIndex = 2;
            this.btnState.UseVisualStyleBackColor = false;
            this.btnState.Click += new System.EventHandler(this.BtnStateClick);
            // 
            // menuStripState
            // 
            this.menuStripState.Arrow = System.Drawing.Color.Black;
            this.menuStripState.Back = System.Drawing.Color.White;
            this.menuStripState.BackRadius = 4;
            this.menuStripState.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripState.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripState.Fore = System.Drawing.Color.Black;
            this.menuStripState.HoverFore = System.Drawing.Color.White;
            this.menuStripState.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripState.ItemAnamorphosis = false;
            this.menuStripState.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemBorderShow = true;
            this.menuStripState.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemRadius = 4;
            this.menuStripState.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在线ToolStripMenuItem,
            this.离开ToolStripMenuItem,
            this.隐身ToolStripMenuItem,
            this.离线ToolStripMenuItem,
            this.忙碌ToolStripMenuItem});
            this.menuStripState.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.Name = "menuStripState";
            this.menuStripState.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripState.Size = new System.Drawing.Size(115, 134);
            this.menuStripState.TitleAnamorphosis = false;
            this.menuStripState.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStripState.TitleRadius = 4;
            this.menuStripState.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripState.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStripStateItemClicked);
            // 
            // 在线ToolStripMenuItem
            // 
            this.在线ToolStripMenuItem.Image = global::Complents.ChatCompResource.online;
            this.在线ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.在线ToolStripMenuItem.Name = "在线ToolStripMenuItem";
            this.在线ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.在线ToolStripMenuItem.Text = "在线";
            // 
            // 离开ToolStripMenuItem
            // 
            this.离开ToolStripMenuItem.Image = global::Complents.ChatCompResource.away;
            this.离开ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离开ToolStripMenuItem.Name = "离开ToolStripMenuItem";
            this.离开ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.离开ToolStripMenuItem.Text = "离开";
            // 
            // 隐身ToolStripMenuItem
            // 
            this.隐身ToolStripMenuItem.Image = global::Complents.ChatCompResource.invisible;
            this.隐身ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.隐身ToolStripMenuItem.Name = "隐身ToolStripMenuItem";
            this.隐身ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.隐身ToolStripMenuItem.Text = "隐身";
            // 
            // 离线ToolStripMenuItem
            // 
            this.离线ToolStripMenuItem.Image = global::Complents.ChatCompResource.imoffline;
            this.离线ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离线ToolStripMenuItem.Name = "离线ToolStripMenuItem";
            this.离线ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.离线ToolStripMenuItem.Text = "离线";
            // 
            // 忙碌ToolStripMenuItem
            // 
            this.忙碌ToolStripMenuItem.Image = global::Complents.ChatCompResource.busy;
            this.忙碌ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.忙碌ToolStripMenuItem.Name = "忙碌ToolStripMenuItem";
            this.忙碌ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.忙碌ToolStripMenuItem.Text = "忙碌";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BaseColor = System.Drawing.Color.Transparent;
            this.btnRemove.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRemove.Create = true;
            this.btnRemove.DownBack = global::Complents.ChatCompResource.list_remove;
            this.btnRemove.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRemove.ImageWidth = 16;
            this.btnRemove.Location = new System.Drawing.Point(108, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemove.MouseBack = global::Complents.ChatCompResource.list_remove;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.NormlBack = global::Complents.ChatCompResource.list_remove;
            this.btnRemove.Radius = 10;
            this.btnRemove.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnRemove.Size = new System.Drawing.Size(21, 20);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // lblNickName
            // 
            this.lblNickName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblNickName.BackColor = System.Drawing.Color.Transparent;
            this.lblNickName.BorderColor = System.Drawing.Color.White;
            this.lblNickName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNickName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickName.Location = new System.Drawing.Point(0, 109);
            this.lblNickName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(133, 29);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.mainBackground);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(133, 138);
            this.MinimumSize = new System.Drawing.Size(107, 100);
            this.Name = "LoginUserControl";
            this.Size = new System.Drawing.Size(133, 138);
            this.mainBackground.ResumeLayout(false);
            this.mainBackground.PerformLayout();
            this.menuStripState.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private CCWin.SkinControl.SkinButtom btnRemove;
		private CCWin.SkinControl.SkinLabel lblNickName;
		private CCWin.SkinControl.SkinCheckBox cbIsChecked;
		private CCWin.SkinControl.SkinPanel mainBackground;
		private System.Windows.Forms.ToolStripMenuItem 忙碌ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 离线ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 隐身ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 离开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 在线ToolStripMenuItem;
		private CCWin.SkinControl.SkinContextMenuStrip menuStripState;
		private CCWin.SkinControl.SkinButtom btnState;
		private CCWin.SkinControl.SkinPanel headImage;
	}
}
