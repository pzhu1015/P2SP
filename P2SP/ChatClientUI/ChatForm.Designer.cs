/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-24
 * Time: 13:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class ChatForm
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
            this.skToolMenuTop = new CCWin.SkinControl.SkinToolStrip();
            this.tssbVideo = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbAudio = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiStartAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMutilAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.语音设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语音测试向导ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送语音消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssbSendFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSendFloder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCreateGroup = new System.Windows.Forms.ToolStripButton();
            this.tssbRemoteDesktop = new System.Windows.Forms.ToolStripSplitButton();
            this.lblPersonalMsg = new CCWin.SkinControl.SkinLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitBtn = new CCWin.SkinControl.SkinButtom();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtRecve = new CCWin.SkinControl.RtfRichTextBox();
            this.skToolMenuFont = new CCWin.SkinControl.SkinToolStrip();
            this.tscmbFontFamily = new System.Windows.Forms.ToolStripComboBox();
            this.tscmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tsbItalic = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderLine = new System.Windows.Forms.ToolStripButton();
            this.tssbColor = new System.Windows.Forms.ToolStripButton();
            this.txtSend = new CCWin.SkinControl.RtfRichTextBox();
            this.skToolMenuMiddle = new CCWin.SkinControl.SkinToolStrip();
            this.tsbFont = new System.Windows.Forms.ToolStripButton();
            this.tsbFace = new System.Windows.Forms.ToolStripButton();
            this.tsbTwitter = new System.Windows.Forms.ToolStripButton();
            this.tsbSendPic = new System.Windows.Forms.ToolStripButton();
            this.tsbCutPic = new System.Windows.Forms.ToolStripButton();
            this.tsbMsgHistory = new System.Windows.Forms.ToolStripSplitButton();
            this.显示记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示比例ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.放大Ctrl滚轮ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.消息管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSend = new CCWin.SkinControl.SkinButtom();
            this.btnShortKeyDropDown = new CCWin.SkinControl.SkinButtom();
            this.btnClose = new CCWin.SkinControl.SkinButtom();
            this.panelFriendHeadImage = new CCWin.SkinControl.SkinPanel();
            this.lblUserId = new CCWin.SkinControl.SkinLabel();
            this.pnlTx = new CCWin.SkinControl.SkinPanel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.显示消息记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示比例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大Ctrl滚轮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripShortKey = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmiEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCtrlEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.skToolMenuTop.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.skToolMenuFont.SuspendLayout();
            this.skToolMenuMiddle.SuspendLayout();
            this.pnlTx.SuspendLayout();
            this.menuStripShortKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // skToolMenuTop
            // 
            this.skToolMenuTop.Arrow = System.Drawing.Color.White;
            this.skToolMenuTop.AutoSize = false;
            this.skToolMenuTop.Back = System.Drawing.Color.White;
            this.skToolMenuTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skToolMenuTop.BackRadius = 4;
            this.skToolMenuTop.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenuTop.Base = System.Drawing.Color.Transparent;
            this.skToolMenuTop.BaseFore = System.Drawing.Color.Black;
            this.skToolMenuTop.BaseForeAnamorphosis = false;
            this.skToolMenuTop.BaseForeAnamorphosisBorder = 4;
            this.skToolMenuTop.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenuTop.BaseHoverFore = System.Drawing.Color.White;
            this.skToolMenuTop.BaseItemAnamorphosis = true;
            this.skToolMenuTop.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skToolMenuTop.BaseItemBorderShow = true;
            this.skToolMenuTop.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.skToolMenuTop.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenuTop.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.skToolMenuTop.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skToolMenuTop.BaseItemRadius = 2;
            this.skToolMenuTop.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuTop.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skToolMenuTop.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenuTop.Fore = System.Drawing.Color.Black;
            this.skToolMenuTop.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenuTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenuTop.HoverFore = System.Drawing.Color.White;
            this.skToolMenuTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skToolMenuTop.ItemAnamorphosis = false;
            this.skToolMenuTop.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuTop.ItemBorderShow = false;
            this.skToolMenuTop.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuTop.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuTop.ItemRadius = 1;
            this.skToolMenuTop.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skToolMenuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbVideo,
            this.tssbAudio,
            this.tssbSendFile,
            this.tsbCreateGroup,
            this.tssbRemoteDesktop});
            this.skToolMenuTop.Location = new System.Drawing.Point(1, 60);
            this.skToolMenuTop.Name = "skToolMenuTop";
            this.skToolMenuTop.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuTop.Size = new System.Drawing.Size(553, 33);
            this.skToolMenuTop.TabIndex = 134;
            this.skToolMenuTop.TitleAnamorphosis = false;
            this.skToolMenuTop.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenuTop.TitleRadius = 4;
            this.skToolMenuTop.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tssbVideo
            // 
            this.tssbVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbVideo.Image = global::ChatClientUI.ResourceChatForm.video_28;
            this.tssbVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbVideo.Name = "tssbVideo";
            this.tssbVideo.Size = new System.Drawing.Size(44, 30);
            this.tssbVideo.ToolTipText = "开始视频会话";
            // 
            // tssbAudio
            // 
            this.tssbAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbAudio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartAudio,
            this.tsmiMutilAudio,
            this.语音设置ToolStripMenuItem,
            this.语音测试向导ToolStripMenuItem,
            this.发送语音消息ToolStripMenuItem});
            this.tssbAudio.Image = global::ChatClientUI.ResourceChatForm.audio_28;
            this.tssbAudio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbAudio.Name = "tssbAudio";
            this.tssbAudio.Size = new System.Drawing.Size(41, 30);
            this.tssbAudio.Text = "toolStripDropDownButton1";
            this.tssbAudio.ToolTipText = "开始语音通话";
            // 
            // tsmiStartAudio
            // 
            this.tsmiStartAudio.Name = "tsmiStartAudio";
            this.tsmiStartAudio.Size = new System.Drawing.Size(148, 22);
            this.tsmiStartAudio.Text = "开始语音通话";
            this.tsmiStartAudio.Click += new System.EventHandler(this.TsmiStartAudioClick);
            // 
            // tsmiMutilAudio
            // 
            this.tsmiMutilAudio.Name = "tsmiMutilAudio";
            this.tsmiMutilAudio.Size = new System.Drawing.Size(148, 22);
            this.tsmiMutilAudio.Text = "发起多人语音";
            // 
            // 语音设置ToolStripMenuItem
            // 
            this.语音设置ToolStripMenuItem.Name = "语音设置ToolStripMenuItem";
            this.语音设置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.语音设置ToolStripMenuItem.Text = "语音设置";
            // 
            // 语音测试向导ToolStripMenuItem
            // 
            this.语音测试向导ToolStripMenuItem.Name = "语音测试向导ToolStripMenuItem";
            this.语音测试向导ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.语音测试向导ToolStripMenuItem.Text = "语音测试向导";
            // 
            // 发送语音消息ToolStripMenuItem
            // 
            this.发送语音消息ToolStripMenuItem.Name = "发送语音消息ToolStripMenuItem";
            this.发送语音消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.发送语音消息ToolStripMenuItem.Text = "发送语音消息";
            // 
            // tssbSendFile
            // 
            this.tssbSendFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbSendFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSendFile,
            this.tsmiSendFloder});
            this.tssbSendFile.Image = global::ChatClientUI.ResourceChatForm.sendfile_28;
            this.tssbSendFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbSendFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbSendFile.Name = "tssbSendFile";
            this.tssbSendFile.Size = new System.Drawing.Size(41, 30);
            // 
            // tsmiSendFile
            // 
            this.tsmiSendFile.Name = "tsmiSendFile";
            this.tsmiSendFile.Size = new System.Drawing.Size(139, 22);
            this.tsmiSendFile.Text = "发送文件(&S)";
            this.tsmiSendFile.Click += new System.EventHandler(this.TsmiSendFileClick);
            // 
            // tsmiSendFloder
            // 
            this.tsmiSendFloder.Name = "tsmiSendFloder";
            this.tsmiSendFloder.Size = new System.Drawing.Size(139, 22);
            this.tsmiSendFloder.Text = "发送文件夹";
            this.tsmiSendFloder.Click += new System.EventHandler(this.TsmiSendFloderClick);
            // 
            // tsbCreateGroup
            // 
            this.tsbCreateGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateGroup.Image = global::ChatClientUI.ResourceChatForm.create_group_28;
            this.tsbCreateGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCreateGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateGroup.Name = "tsbCreateGroup";
            this.tsbCreateGroup.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsbCreateGroup.Size = new System.Drawing.Size(42, 30);
            this.tsbCreateGroup.ToolTipText = "创建讨论组";
            // 
            // tssbRemoteDesktop
            // 
            this.tssbRemoteDesktop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbRemoteDesktop.Image = global::ChatClientUI.ResourceChatForm.assistance_28;
            this.tssbRemoteDesktop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbRemoteDesktop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbRemoteDesktop.Name = "tssbRemoteDesktop";
            this.tssbRemoteDesktop.Size = new System.Drawing.Size(44, 30);
            this.tssbRemoteDesktop.ToolTipText = "远程桌面";
            // 
            // lblPersonalMsg
            // 
            this.lblPersonalMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonalMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.lblPersonalMsg.AutoSize = true;
            this.lblPersonalMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonalMsg.BorderColor = System.Drawing.Color.White;
            this.lblPersonalMsg.BorderSize = 4;
            this.lblPersonalMsg.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblPersonalMsg.ForeColor = System.Drawing.Color.Black;
            this.lblPersonalMsg.Location = new System.Drawing.Point(58, 34);
            this.lblPersonalMsg.Name = "lblPersonalMsg";
            this.lblPersonalMsg.Size = new System.Drawing.Size(80, 17);
            this.lblPersonalMsg.TabIndex = 139;
            this.lblPersonalMsg.Text = "我的个性签名";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(1, 93);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitBtn);
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.splitContainerMain.Size = new System.Drawing.Size(553, 418);
            this.splitContainerMain.SplitterDistance = 399;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 135;
            // 
            // splitBtn
            // 
            this.splitBtn.BackColor = System.Drawing.Color.Transparent;
            this.splitBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.splitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitBtn.DownBack = null;
            this.splitBtn.Location = new System.Drawing.Point(395, 0);
            this.splitBtn.MouseBack = null;
            this.splitBtn.Name = "splitBtn";
            this.splitBtn.NormlBack = null;
            this.splitBtn.Size = new System.Drawing.Size(4, 418);
            this.splitBtn.TabIndex = 0;
            this.splitBtn.Text = ">";
            this.splitBtn.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer3.Panel1MinSize = 0;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.splitContainer3.Panel2.Controls.Add(this.btnSend);
            this.splitContainer3.Panel2.Controls.Add(this.btnShortKeyDropDown);
            this.splitContainer3.Panel2.Controls.Add(this.btnClose);
            this.splitContainer3.Panel2MinSize = 40;
            this.splitContainer3.Size = new System.Drawing.Size(399, 418);
            this.splitContainer3.SplitterDistance = 377;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel1.Controls.Add(this.txtRecve);
            this.splitContainer4.Panel1.Controls.Add(this.skToolMenuFont);
            this.splitContainer4.Panel1MinSize = 0;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel2.Controls.Add(this.txtSend);
            this.splitContainer4.Panel2.Controls.Add(this.skToolMenuMiddle);
            this.splitContainer4.Panel2MinSize = 0;
            this.splitContainer4.Size = new System.Drawing.Size(399, 377);
            this.splitContainer4.SplitterDistance = 228;
            this.splitContainer4.SplitterWidth = 1;
            this.splitContainer4.TabIndex = 0;
            // 
            // txtRecve
            // 
            this.txtRecve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecve.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtRecve.Location = new System.Drawing.Point(0, 0);
            this.txtRecve.Name = "txtRecve";
            this.txtRecve.ReadOnly = true;
            this.txtRecve.Size = new System.Drawing.Size(399, 228);
            this.txtRecve.TabIndex = 135;
            this.txtRecve.Text = "";
            this.txtRecve.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // skToolMenuFont
            // 
            this.skToolMenuFont.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skToolMenuFont.AutoSize = false;
            this.skToolMenuFont.Back = System.Drawing.Color.White;
            this.skToolMenuFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.skToolMenuFont.BackRadius = 4;
            this.skToolMenuFont.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenuFont.Base = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenuFont.BaseFore = System.Drawing.Color.Black;
            this.skToolMenuFont.BaseForeAnamorphosis = false;
            this.skToolMenuFont.BaseForeAnamorphosisBorder = 4;
            this.skToolMenuFont.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenuFont.BaseHoverFore = System.Drawing.Color.Black;
            this.skToolMenuFont.BaseItemAnamorphosis = true;
            this.skToolMenuFont.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skToolMenuFont.BaseItemBorderShow = true;
            this.skToolMenuFont.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.skToolMenuFont.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenuFont.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.skToolMenuFont.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skToolMenuFont.BaseItemRadius = 2;
            this.skToolMenuFont.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuFont.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skToolMenuFont.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skToolMenuFont.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenuFont.Fore = System.Drawing.Color.Black;
            this.skToolMenuFont.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenuFont.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenuFont.HoverFore = System.Drawing.Color.White;
            this.skToolMenuFont.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skToolMenuFont.ItemAnamorphosis = false;
            this.skToolMenuFont.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuFont.ItemBorderShow = true;
            this.skToolMenuFont.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuFont.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuFont.ItemRadius = 3;
            this.skToolMenuFont.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skToolMenuFont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmbFontFamily,
            this.tscmbFontSize,
            this.tsbBold,
            this.tsbItalic,
            this.tsbUnderLine,
            this.tssbColor});
            this.skToolMenuFont.Location = new System.Drawing.Point(0, 201);
            this.skToolMenuFont.Name = "skToolMenuFont";
            this.skToolMenuFont.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuFont.Size = new System.Drawing.Size(460, 27);
            this.skToolMenuFont.TabIndex = 134;
            this.skToolMenuFont.Text = "skinToolStrip1";
            this.skToolMenuFont.TitleAnamorphosis = false;
            this.skToolMenuFont.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenuFont.TitleRadius = 4;
            this.skToolMenuFont.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuFont.Visible = false;
            // 
            // tscmbFontFamily
            // 
            this.tscmbFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbFontFamily.Name = "tscmbFontFamily";
            this.tscmbFontFamily.Size = new System.Drawing.Size(121, 27);
            this.tscmbFontFamily.SelectedIndexChanged += new System.EventHandler(this.TscmbFontFamilySelectedIndexChanged);
            // 
            // tscmbFontSize
            // 
            this.tscmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbFontSize.Name = "tscmbFontSize";
            this.tscmbFontSize.Size = new System.Drawing.Size(75, 27);
            this.tscmbFontSize.SelectedIndexChanged += new System.EventHandler(this.TscmbFontSizeSelectedIndexChanged);
            // 
            // tsbBold
            // 
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = global::ChatClientUI.ResourceChatForm.Bold_16;
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(24, 24);
            this.tsbBold.ToolTipText = "加粗";
            this.tsbBold.Click += new System.EventHandler(this.TsbBoldClick);
            // 
            // tsbItalic
            // 
            this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItalic.Image = global::ChatClientUI.ResourceChatForm.Italic_16;
            this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItalic.Name = "tsbItalic";
            this.tsbItalic.Size = new System.Drawing.Size(24, 24);
            this.tsbItalic.Text = "toolStripButton10";
            this.tsbItalic.ToolTipText = "倾斜";
            this.tsbItalic.Click += new System.EventHandler(this.TsbItalicClick);
            // 
            // tsbUnderLine
            // 
            this.tsbUnderLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderLine.Image = global::ChatClientUI.ResourceChatForm.underline_16;
            this.tsbUnderLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderLine.Name = "tsbUnderLine";
            this.tsbUnderLine.Size = new System.Drawing.Size(24, 24);
            this.tsbUnderLine.Text = "toolStripButton11";
            this.tsbUnderLine.ToolTipText = "下划线";
            this.tsbUnderLine.Click += new System.EventHandler(this.TsbUnderLineClick);
            // 
            // tssbColor
            // 
            this.tssbColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbColor.Image = global::ChatClientUI.ResourceChatForm.color_16;
            this.tssbColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbColor.Name = "tssbColor";
            this.tssbColor.Size = new System.Drawing.Size(24, 24);
            this.tssbColor.Text = "toolStripButton1";
            this.tssbColor.Click += new System.EventHandler(this.TssbColorClick);
            // 
            // txtSend
            // 
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtSend.Location = new System.Drawing.Point(0, 27);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(399, 121);
            this.txtSend.TabIndex = 134;
            this.txtSend.Text = "";
            this.txtSend.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSendKeyDown);
            // 
            // skToolMenuMiddle
            // 
            this.skToolMenuMiddle.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skToolMenuMiddle.AutoSize = false;
            this.skToolMenuMiddle.Back = System.Drawing.Color.White;
            this.skToolMenuMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.skToolMenuMiddle.BackRadius = 4;
            this.skToolMenuMiddle.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenuMiddle.Base = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenuMiddle.BaseFore = System.Drawing.Color.Black;
            this.skToolMenuMiddle.BaseForeAnamorphosis = false;
            this.skToolMenuMiddle.BaseForeAnamorphosisBorder = 4;
            this.skToolMenuMiddle.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenuMiddle.BaseHoverFore = System.Drawing.Color.Black;
            this.skToolMenuMiddle.BaseItemAnamorphosis = true;
            this.skToolMenuMiddle.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skToolMenuMiddle.BaseItemBorderShow = true;
            this.skToolMenuMiddle.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.skToolMenuMiddle.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenuMiddle.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.skToolMenuMiddle.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skToolMenuMiddle.BaseItemRadius = 2;
            this.skToolMenuMiddle.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuMiddle.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skToolMenuMiddle.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenuMiddle.Fore = System.Drawing.Color.Black;
            this.skToolMenuMiddle.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenuMiddle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenuMiddle.HoverFore = System.Drawing.Color.White;
            this.skToolMenuMiddle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skToolMenuMiddle.ItemAnamorphosis = false;
            this.skToolMenuMiddle.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuMiddle.ItemBorderShow = false;
            this.skToolMenuMiddle.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuMiddle.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenuMiddle.ItemRadius = 3;
            this.skToolMenuMiddle.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skToolMenuMiddle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFont,
            this.tsbFace,
            this.tsbTwitter,
            this.tsbSendPic,
            this.tsbCutPic,
            this.tsbMsgHistory});
            this.skToolMenuMiddle.Location = new System.Drawing.Point(0, 0);
            this.skToolMenuMiddle.Name = "skToolMenuMiddle";
            this.skToolMenuMiddle.Padding = new System.Windows.Forms.Padding(0);
            this.skToolMenuMiddle.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenuMiddle.Size = new System.Drawing.Size(399, 27);
            this.skToolMenuMiddle.TabIndex = 133;
            this.skToolMenuMiddle.Text = "skinToolStrip1";
            this.skToolMenuMiddle.TitleAnamorphosis = false;
            this.skToolMenuMiddle.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenuMiddle.TitleRadius = 4;
            this.skToolMenuMiddle.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsbFont
            // 
            this.tsbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFont.Image = global::ChatClientUI.ResourceChatForm.font_20;
            this.tsbFont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFont.Name = "tsbFont";
            this.tsbFont.Size = new System.Drawing.Size(24, 24);
            this.tsbFont.ToolTipText = "样式";
            this.tsbFont.Click += new System.EventHandler(this.TsbFontClick);
            // 
            // tsbFace
            // 
            this.tsbFace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFace.Image = global::ChatClientUI.ResourceChatForm.face_20;
            this.tsbFace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFace.Name = "tsbFace";
            this.tsbFace.Size = new System.Drawing.Size(24, 24);
            this.tsbFace.Text = "toolStripButton3";
            this.tsbFace.ToolTipText = "表情图";
            this.tsbFace.Click += new System.EventHandler(this.TsbFaceClick);
            // 
            // tsbTwitter
            // 
            this.tsbTwitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTwitter.Image = global::ChatClientUI.ResourceChatForm.twitter_20;
            this.tsbTwitter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTwitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTwitter.Name = "tsbTwitter";
            this.tsbTwitter.Size = new System.Drawing.Size(24, 24);
            this.tsbTwitter.ToolTipText = "抖动窗口";
            this.tsbTwitter.Click += new System.EventHandler(this.TsbTwitterClick);
            // 
            // tsbSendPic
            // 
            this.tsbSendPic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSendPic.Image = global::ChatClientUI.ResourceChatForm.sendpic_20;
            this.tsbSendPic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSendPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSendPic.Name = "tsbSendPic";
            this.tsbSendPic.Size = new System.Drawing.Size(24, 24);
            this.tsbSendPic.Text = "tsbSendPic";
            // 
            // tsbCutPic
            // 
            this.tsbCutPic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCutPic.Image = global::ChatClientUI.ResourceChatForm.cutscreen_20;
            this.tsbCutPic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCutPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCutPic.Name = "tsbCutPic";
            this.tsbCutPic.Size = new System.Drawing.Size(24, 24);
            this.tsbCutPic.ToolTipText = "截图";
            // 
            // tsbMsgHistory
            // 
            this.tsbMsgHistory.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbMsgHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示记录ToolStripMenuItem,
            this.显示比例ToolStripMenuItem1,
            this.tsmiClear,
            this.消息管理器ToolStripMenuItem});
            this.tsbMsgHistory.Image = global::ChatClientUI.ResourceChatForm.aio_quickbar_register;
            this.tsbMsgHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMsgHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMsgHistory.Name = "tsbMsgHistory";
            this.tsbMsgHistory.Size = new System.Drawing.Size(92, 24);
            this.tsbMsgHistory.Text = "消息记录";
            // 
            // 显示记录ToolStripMenuItem
            // 
            this.显示记录ToolStripMenuItem.Name = "显示记录ToolStripMenuItem";
            this.显示记录ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示记录ToolStripMenuItem.Text = "显示记录";
            // 
            // 显示比例ToolStripMenuItem1
            // 
            this.显示比例ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大Ctrl滚轮ToolStripMenuItem1,
            this.缩小ToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem7,
            this.toolStripMenuItem12,
            this.toolStripMenuItem15});
            this.显示比例ToolStripMenuItem1.Name = "显示比例ToolStripMenuItem1";
            this.显示比例ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.显示比例ToolStripMenuItem1.Text = "显示比例";
            // 
            // 放大Ctrl滚轮ToolStripMenuItem1
            // 
            this.放大Ctrl滚轮ToolStripMenuItem1.Name = "放大Ctrl滚轮ToolStripMenuItem1";
            this.放大Ctrl滚轮ToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.放大Ctrl滚轮ToolStripMenuItem1.Text = "放大 Ctrl+滚轮";
            // 
            // 缩小ToolStripMenuItem1
            // 
            this.缩小ToolStripMenuItem1.Name = "缩小ToolStripMenuItem1";
            this.缩小ToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.缩小ToolStripMenuItem1.Text = "缩小";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem2.Text = "400%";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem3.Text = "200%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem4.Text = "150%";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem5.Text = "125%";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem7.Text = "100%";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem12.Text = "75%";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem15.Text = "50%";
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(136, 22);
            this.tsmiClear.Text = "清屏";
            this.tsmiClear.Click += new System.EventHandler(this.TsmiClearClick);
            // 
            // 消息管理器ToolStripMenuItem
            // 
            this.消息管理器ToolStripMenuItem.Name = "消息管理器ToolStripMenuItem";
            this.消息管理器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.消息管理器ToolStripMenuItem.Text = "消息管理器";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSend.DownBack = global::ChatClientUI.ResourceControl.btnSend_DownBack;
            this.btnSend.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(312, 1);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.MouseBack = global::ChatClientUI.ResourceControl.btnSend_MouseBack;
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = global::ChatClientUI.ResourceControl.btnSend_NormlBack;
            this.btnSend.Size = new System.Drawing.Size(61, 24);
            this.btnSend.TabIndex = 131;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // btnShortKeyDropDown
            // 
            this.btnShortKeyDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShortKeyDropDown.BackColor = System.Drawing.Color.Transparent;
            this.btnShortKeyDropDown.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnShortKeyDropDown.DownBack = global::ChatClientUI.ResourceControl.btnShortKeyDropDown_DownBack;
            this.btnShortKeyDropDown.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnShortKeyDropDown.Location = new System.Drawing.Point(373, 1);
            this.btnShortKeyDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnShortKeyDropDown.MouseBack = global::ChatClientUI.ResourceControl.btnShortKeyDropDown_MouseBack;
            this.btnShortKeyDropDown.Name = "btnShortKeyDropDown";
            this.btnShortKeyDropDown.NormlBack = global::ChatClientUI.ResourceControl.btnShortKeyDropDown_NormlBack;
            this.btnShortKeyDropDown.Size = new System.Drawing.Size(20, 24);
            this.btnShortKeyDropDown.TabIndex = 132;
            this.btnShortKeyDropDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShortKeyDropDown.UseVisualStyleBackColor = false;
            this.btnShortKeyDropDown.Click += new System.EventHandler(this.BtnShortKeyDropDownClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
            this.btnClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(233, 1);
            this.btnClose.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
            this.btnClose.Size = new System.Drawing.Size(69, 24);
            this.btnClose.TabIndex = 130;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // panelFriendHeadImage
            // 
            this.panelFriendHeadImage.BackColor = System.Drawing.Color.Transparent;
            this.panelFriendHeadImage.BackgroundImage = global::ChatClientUI.ResourceForm.default_head;
            this.panelFriendHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFriendHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelFriendHeadImage.DownBack = null;
            this.panelFriendHeadImage.Location = new System.Drawing.Point(3, 3);
            this.panelFriendHeadImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelFriendHeadImage.MouseBack = null;
            this.panelFriendHeadImage.Name = "panelFriendHeadImage";
            this.panelFriendHeadImage.NormlBack = null;
            this.panelFriendHeadImage.Size = new System.Drawing.Size(40, 40);
            this.panelFriendHeadImage.TabIndex = 137;
            // 
            // lblUserId
            // 
            this.lblUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserId.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.lblUserId.AutoSize = true;
            this.lblUserId.BackColor = System.Drawing.Color.Transparent;
            this.lblUserId.BorderColor = System.Drawing.Color.White;
            this.lblUserId.BorderSize = 4;
            this.lblUserId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserId.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblUserId.ForeColor = System.Drawing.Color.Black;
            this.lblUserId.Location = new System.Drawing.Point(58, 5);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(88, 25);
            this.lblUserId.TabIndex = 138;
            this.lblUserId.Text = "我的好友";
            // 
            // pnlTx
            // 
            this.pnlTx.BackColor = System.Drawing.Color.Transparent;
            this.pnlTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTx.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.pnlTx.Controls.Add(this.panelFriendHeadImage);
            this.pnlTx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTx.DownBack = null;
            this.pnlTx.Location = new System.Drawing.Point(6, 5);
            this.pnlTx.MouseBack = null;
            this.pnlTx.Name = "pnlTx";
            this.pnlTx.NormlBack = null;
            this.pnlTx.Size = new System.Drawing.Size(46, 46);
            this.pnlTx.TabIndex = 141;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(6, 5);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(46, 46);
            this.skinPanel1.TabIndex = 142;
            // 
            // 显示消息记录ToolStripMenuItem
            // 
            this.显示消息记录ToolStripMenuItem.Name = "显示消息记录ToolStripMenuItem";
            this.显示消息记录ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.显示消息记录ToolStripMenuItem.Text = "显示消息记录";
            // 
            // 显示比例ToolStripMenuItem
            // 
            this.显示比例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大Ctrl滚轮ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.显示比例ToolStripMenuItem.Name = "显示比例ToolStripMenuItem";
            this.显示比例ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.显示比例ToolStripMenuItem.Text = "显示比例";
            // 
            // 放大Ctrl滚轮ToolStripMenuItem
            // 
            this.放大Ctrl滚轮ToolStripMenuItem.Name = "放大Ctrl滚轮ToolStripMenuItem";
            this.放大Ctrl滚轮ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.放大Ctrl滚轮ToolStripMenuItem.Text = "放大 Ctrl+滚轮";
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem8.Text = "400%";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem9.Text = "200%";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem10.Text = "150%";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem11.Text = "125%";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem13.Text = "75%";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem14.Text = "50%";
            // 
            // menuStripShortKey
            // 
            this.menuStripShortKey.Arrow = System.Drawing.Color.Black;
            this.menuStripShortKey.Back = System.Drawing.Color.White;
            this.menuStripShortKey.BackRadius = 4;
            this.menuStripShortKey.Base = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(209)))));
            this.menuStripShortKey.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripShortKey.Fore = System.Drawing.Color.Black;
            this.menuStripShortKey.HoverFore = System.Drawing.Color.White;
            this.menuStripShortKey.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripShortKey.ItemAnamorphosis = false;
            this.menuStripShortKey.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(209)))));
            this.menuStripShortKey.ItemBorderShow = false;
            this.menuStripShortKey.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(209)))));
            this.menuStripShortKey.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(209)))));
            this.menuStripShortKey.ItemRadius = 2;
            this.menuStripShortKey.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripShortKey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnter,
            this.tsmiCtrlEnter});
            this.menuStripShortKey.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(145)))), ((int)(((byte)(209)))));
            this.menuStripShortKey.Name = "scmsShortKey";
            this.menuStripShortKey.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripShortKey.Size = new System.Drawing.Size(208, 48);
            this.menuStripShortKey.TitleAnamorphosis = false;
            this.menuStripShortKey.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStripShortKey.TitleRadius = 4;
            this.menuStripShortKey.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsmiEnter
            // 
            this.tsmiEnter.Checked = true;
            this.tsmiEnter.CheckOnClick = true;
            this.tsmiEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiEnter.Name = "tsmiEnter";
            this.tsmiEnter.Size = new System.Drawing.Size(207, 22);
            this.tsmiEnter.Text = "按Enter键发送消息";
            this.tsmiEnter.Click += new System.EventHandler(this.TsmiEnterClick);
            // 
            // tsmiCtrlEnter
            // 
            this.tsmiCtrlEnter.CheckOnClick = true;
            this.tsmiCtrlEnter.Name = "tsmiCtrlEnter";
            this.tsmiCtrlEnter.Size = new System.Drawing.Size(207, 22);
            this.tsmiCtrlEnter.Text = "按Ctrl+Enter键发送消息";
            this.tsmiCtrlEnter.Click += new System.EventHandler(this.TsmiCtrlEnterClick);
            // 
            // ChatForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
            this.BorderWidth = 1;
            this.CaptionHeight = 60;
            this.ClientSize = new System.Drawing.Size(555, 512);
            this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
            this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
            this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.lblPersonalMsg);
            this.Controls.Add(this.pnlTx);
            this.Controls.Add(this.skToolMenuTop);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.lblUserId);
            this.EffectBack = System.Drawing.Color.Transparent;
            this.EffectCaption = false;
            this.EffectWidth = 0;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = global::ChatClientUI.ResourceMainForm.logo_xp_16;
            this.MaxDownBack = global::ChatClientUI.ResourceForm.btn_max_down;
            this.MaxMouseBack = global::ChatClientUI.ResourceForm.btn_max_highlight;
            this.MaxNormlBack = global::ChatClientUI.ResourceForm.btn_max_normal;
            this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
            this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
            this.Name = "ChatForm";
            this.RestoreDownBack = global::ChatClientUI.ResourceForm.btn_restore_down;
            this.RestoreMouseBack = global::ChatClientUI.ResourceForm.btn_restore_highlight;
            this.RestoreNormlBack = global::ChatClientUI.ResourceForm.btn_restore_normal;
            this.ShowDrawIcon = false;
            this.SysBottomDown = global::ChatClientUI.ResourceForm.AIO_SetBtn_down;
            this.SysBottomMouse = global::ChatClientUI.ResourceForm.AIO_SetBtn_highlight;
            this.SysBottomNorml = global::ChatClientUI.ResourceForm.AIO_SetBtn_normal;
            this.SysBottomVisibale = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatFormFormClosing);
            this.Load += new System.EventHandler(this.ChatFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ChatFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ChatFormDragEnter);
            this.skToolMenuTop.ResumeLayout(false);
            this.skToolMenuTop.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.skToolMenuFont.ResumeLayout(false);
            this.skToolMenuFont.PerformLayout();
            this.skToolMenuMiddle.ResumeLayout(false);
            this.skToolMenuMiddle.PerformLayout();
            this.pnlTx.ResumeLayout(false);
            this.menuStripShortKey.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private CCWin.SkinControl.SkinButtom splitBtn;
		private System.Windows.Forms.ToolStripMenuItem 发送语音消息ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 语音测试向导ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 语音设置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmiMutilAudio;
		private System.Windows.Forms.ToolStripMenuItem tsmiStartAudio;
		private CCWin.SkinControl.RtfRichTextBox txtSend;
		private CCWin.SkinControl.RtfRichTextBox txtRecve;
		private System.Windows.Forms.ToolStripComboBox tscmbFontFamily;
		private System.Windows.Forms.ToolStripComboBox tscmbFontSize;
		private System.Windows.Forms.ToolStripMenuItem tsmiEnter;
		private System.Windows.Forms.ToolStripMenuItem tsmiCtrlEnter;
		private CCWin.SkinControl.SkinContextMenuStrip menuStripShortKey;
		private CCWin.SkinControl.SkinButtom btnShortKeyDropDown;
		private CCWin.SkinControl.SkinLabel lblPersonalMsg;
		private CCWin.SkinControl.SkinLabel lblUserId;
		private System.Windows.Forms.ToolStripMenuItem tsmiClear;
		private System.Windows.Forms.ToolStripMenuItem tsmiSendFloder;
		private System.Windows.Forms.ToolStripMenuItem tsmiSendFile;
		private System.Windows.Forms.ToolStripButton tsbCreateGroup;
		private System.Windows.Forms.ToolStripSplitButton tssbRemoteDesktop;
		private System.Windows.Forms.ToolStripDropDownButton tssbSendFile;
		private System.Windows.Forms.ToolStripDropDownButton tssbAudio;
		private System.Windows.Forms.ToolStripSplitButton tssbVideo;
		private System.Windows.Forms.ToolStripSplitButton tsbMsgHistory;
		private System.Windows.Forms.ToolStripButton tsbSendPic;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.ToolStripButton tsbFace;
		private System.Windows.Forms.ToolStripButton tsbTwitter;
		private System.Windows.Forms.ToolStripButton tsbCutPic;
		private System.Windows.Forms.ToolStripButton tsbBold;
		private System.Windows.Forms.ToolStripButton tsbItalic;
		private System.Windows.Forms.ToolStripButton tsbUnderLine;
		private System.Windows.Forms.ToolStripButton tssbColor;
		private CCWin.SkinControl.SkinToolStrip skToolMenuTop;
		private CCWin.SkinControl.SkinToolStrip skToolMenuFont;
		private CCWin.SkinControl.SkinToolStrip skToolMenuMiddle;
		private System.Windows.Forms.ToolStripButton tsbFont;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 放大Ctrl滚轮ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 消息管理器ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 显示比例ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 显示记录ToolStripMenuItem;
		private CCWin.SkinControl.SkinButtom btnClose;
		private CCWin.SkinControl.SkinButtom btnSend;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 放大Ctrl滚轮ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 显示比例ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 显示消息记录ToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private CCWin.SkinControl.SkinPanel skinPanel1;
		private CCWin.SkinControl.SkinPanel pnlTx;
		private CCWin.SkinControl.SkinPanel panelFriendHeadImage;
	}
}
