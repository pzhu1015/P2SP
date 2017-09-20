/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-23
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using Complents;
namespace ChatClientUI
{
	partial class MainForm
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
            CCWin.SkinControl.ChatListItem chatListItem4 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem5 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem6 = new CCWin.SkinControl.ChatListItem();
            this.chatListBoxBuddy = new CCWin.SkinControl.ChatListBox();
            this.labelSignature = new CCWin.SkinControl.SkinLabel();
            this.skinToolStrip5 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.我在线上ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.离开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.忙碌ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.隐身ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.离线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSystemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMineInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tslblUserName = new System.Windows.Forms.ToolStripLabel();
            this.skinToolStrip4 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.tsBottomMenuOne = new CCWin.SkinControl.SkinToolStrip();
            this.tsBottomMenuTwo = new CCWin.SkinControl.SkinToolStrip();
            this.tsbtnmainMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.检测升级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExitMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnSysSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.skinContextMenuStripMain = new CCWin.SkinControl.SkinContextMenuStrip();
            this.我在线上ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.忙碌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐身ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.离线ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.skinContextMenuStripFriend = new CCWin.SkinControl.SkinContextMenuStrip();
            this.头像显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名称显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.skinContextMenuStripGroup = new CCWin.SkinControl.SkinContextMenuStrip();
            this.图标显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表显示ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.skpWeather = new CCWin.SkinControl.SkinPanel();
            this.userHeader = new Complents.ChatComp.UserHeaderControl();
            this.skinToolStrip5.SuspendLayout();
            this.skinToolStrip4.SuspendLayout();
            this.tsBottomMenuTwo.SuspendLayout();
            this.skinContextMenuStripMain.SuspendLayout();
            this.skinTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.skinContextMenuStripFriend.SuspendLayout();
            this.skinContextMenuStripGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatListBoxBuddy
            // 
            this.chatListBoxBuddy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.chatListBoxBuddy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatListBoxBuddy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatListBoxBuddy.ForeColor = System.Drawing.Color.Black;
            chatListItem4.Bounds = new System.Drawing.Rectangle(0, 1, 334, 25);
            chatListItem4.IsTwinkleHide = false;
            chatListItem4.OwnerChatListBox = this.chatListBoxBuddy;
            chatListItem4.Text = "我的好友";
            chatListItem4.TwinkleSubItemNumber = 0;
            chatListItem5.Bounds = new System.Drawing.Rectangle(0, 27, 334, 25);
            chatListItem5.IsTwinkleHide = false;
            chatListItem5.OwnerChatListBox = this.chatListBoxBuddy;
            chatListItem5.Text = "陌生人";
            chatListItem5.TwinkleSubItemNumber = 0;
            chatListItem6.Bounds = new System.Drawing.Rectangle(0, 53, 334, 25);
            chatListItem6.IsTwinkleHide = false;
            chatListItem6.OwnerChatListBox = this.chatListBoxBuddy;
            chatListItem6.Text = "黑名单";
            chatListItem6.TwinkleSubItemNumber = 0;
            this.chatListBoxBuddy.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem4,
            chatListItem5,
            chatListItem6});
            this.chatListBoxBuddy.ListSubItemMenu = null;
            this.chatListBoxBuddy.Location = new System.Drawing.Point(0, 0);
            this.chatListBoxBuddy.Margin = new System.Windows.Forms.Padding(0);
            this.chatListBoxBuddy.Name = "chatListBoxBuddy";
            this.chatListBoxBuddy.Size = new System.Drawing.Size(334, 544);
            this.chatListBoxBuddy.SubItemMenu = null;
            this.chatListBoxBuddy.TabIndex = 131;
            this.chatListBoxBuddy.DoubleClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.ChatListBoxBuddyDoubleClickSubItem);
            this.chatListBoxBuddy.MouseEnterHead += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.ChatListBoxBuddyMouseEnterHead);
            this.chatListBoxBuddy.MouseLeaveHead += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.ChatListBoxBuddyMouseLeaveHead);
            // 
            // labelSignature
            // 
            this.labelSignature.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.labelSignature.AutoEllipsis = true;
            this.labelSignature.BackColor = System.Drawing.Color.Transparent;
            this.labelSignature.BorderColor = System.Drawing.Color.White;
            this.labelSignature.BorderSize = 4;
            this.labelSignature.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelSignature.ForeColor = System.Drawing.Color.Black;
            this.labelSignature.Location = new System.Drawing.Point(80, 51);
            this.labelSignature.Name = "labelSignature";
            this.labelSignature.Size = new System.Drawing.Size(150, 17);
            this.labelSignature.TabIndex = 132;
            this.labelSignature.Text = "站在巨人肩膀上才能看得更远";
            // 
            // skinToolStrip5
            // 
            this.skinToolStrip5.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip5.AutoSize = false;
            this.skinToolStrip5.Back = System.Drawing.Color.White;
            this.skinToolStrip5.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BackRadius = 4;
            this.skinToolStrip5.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip5.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip5.BaseForeAnamorphosis = true;
            this.skinToolStrip5.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip5.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip5.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip5.BaseItemAnamorphosis = true;
            this.skinToolStrip5.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skinToolStrip5.BaseItemBorderShow = true;
            this.skinToolStrip5.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.skinToolStrip5.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip5.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.skinToolStrip5.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BaseItemRadius = 2;
            this.skinToolStrip5.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip5.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip5.CanOverflow = false;
            this.skinToolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip5.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip5.Fore = System.Drawing.Color.Black;
            this.skinToolStrip5.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip5.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip5.ItemAnamorphosis = false;
            this.skinToolStrip5.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip5.ItemBorderShow = false;
            this.skinToolStrip5.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip5.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip5.ItemRadius = 3;
            this.skinToolStrip5.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tslblUserName});
            this.skinToolStrip5.Location = new System.Drawing.Point(80, 29);
            this.skinToolStrip5.Name = "skinToolStrip5";
            this.skinToolStrip5.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip5.Size = new System.Drawing.Size(116, 24);
            this.skinToolStrip5.TabIndex = 131;
            this.skinToolStrip5.Text = "skinToolStrip5";
            this.skinToolStrip5.TitleAnamorphosis = false;
            this.skinToolStrip5.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip5.TitleRadius = 4;
            this.skinToolStrip5.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我在线上ToolStripMenuItem1,
            this.离开ToolStripMenuItem1,
            this.忙碌ToolStripMenuItem1,
            this.隐身ToolStripMenuItem1,
            this.离线ToolStripMenuItem1,
            this.toolStripSeparator3,
            this.tsmiSystemSetting,
            this.tsmiMineInfo});
            this.toolStripDropDownButton1.Image = global::ChatClientUI.ResourceStatus.imonline;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(25, 21);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // 我在线上ToolStripMenuItem1
            // 
            this.我在线上ToolStripMenuItem1.Image = global::ChatClientUI.ResourceStatus.imonline;
            this.我在线上ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.我在线上ToolStripMenuItem1.Name = "我在线上ToolStripMenuItem1";
            this.我在线上ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.我在线上ToolStripMenuItem1.Text = "我在线上";
            // 
            // 离开ToolStripMenuItem1
            // 
            this.离开ToolStripMenuItem1.Image = global::ChatClientUI.ResourceStatus.away_;
            this.离开ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离开ToolStripMenuItem1.Name = "离开ToolStripMenuItem1";
            this.离开ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.离开ToolStripMenuItem1.Text = "离开";
            // 
            // 忙碌ToolStripMenuItem1
            // 
            this.忙碌ToolStripMenuItem1.Image = global::ChatClientUI.ResourceStatus.busy_;
            this.忙碌ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.忙碌ToolStripMenuItem1.Name = "忙碌ToolStripMenuItem1";
            this.忙碌ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.忙碌ToolStripMenuItem1.Text = "忙碌";
            // 
            // 隐身ToolStripMenuItem1
            // 
            this.隐身ToolStripMenuItem1.Image = global::ChatClientUI.ResourceStatus.invisible_;
            this.隐身ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.隐身ToolStripMenuItem1.Name = "隐身ToolStripMenuItem1";
            this.隐身ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.隐身ToolStripMenuItem1.Text = "隐身";
            // 
            // 离线ToolStripMenuItem1
            // 
            this.离线ToolStripMenuItem1.Image = global::ChatClientUI.ResourceStatus.imoffline_;
            this.离线ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离线ToolStripMenuItem1.Name = "离线ToolStripMenuItem1";
            this.离线ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.离线ToolStripMenuItem1.Text = "离线";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmiSystemSetting
            // 
            this.tsmiSystemSetting.Name = "tsmiSystemSetting";
            this.tsmiSystemSetting.Size = new System.Drawing.Size(144, 26);
            this.tsmiSystemSetting.Text = "系统设置";
            this.tsmiSystemSetting.Click += new System.EventHandler(this.TsbtnSysSettingClick);
            // 
            // tsmiMineInfo
            // 
            this.tsmiMineInfo.Name = "tsmiMineInfo";
            this.tsmiMineInfo.Size = new System.Drawing.Size(144, 26);
            this.tsmiMineInfo.Text = "我的资料";
            this.tsmiMineInfo.Click += new System.EventHandler(this.TsmiMineInfoClick);
            // 
            // tslblUserName
            // 
            this.tslblUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tslblUserName.Name = "tslblUserName";
            this.tslblUserName.Size = new System.Drawing.Size(71, 21);
            this.tslblUserName.Text = "龙腾虎跃";
            // 
            // skinToolStrip4
            // 
            this.skinToolStrip4.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip4.AutoSize = false;
            this.skinToolStrip4.Back = System.Drawing.Color.White;
            this.skinToolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BackRadius = 4;
            this.skinToolStrip4.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip4.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip4.BaseForeAnamorphosis = true;
            this.skinToolStrip4.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip4.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip4.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip4.BaseItemAnamorphosis = true;
            this.skinToolStrip4.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skinToolStrip4.BaseItemBorderShow = true;
            this.skinToolStrip4.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.skinToolStrip4.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip4.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.skinToolStrip4.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BaseItemRadius = 2;
            this.skinToolStrip4.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip4.CanOverflow = false;
            this.skinToolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip4.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip4.Fore = System.Drawing.Color.Black;
            this.skinToolStrip4.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip4.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip4.ItemAnamorphosis = false;
            this.skinToolStrip4.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemBorderShow = false;
            this.skinToolStrip4.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemRadius = 3;
            this.skinToolStrip4.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9});
            this.skinToolStrip4.Location = new System.Drawing.Point(80, 75);
            this.skinToolStrip4.Name = "skinToolStrip4";
            this.skinToolStrip4.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.Size = new System.Drawing.Size(164, 22);
            this.skinToolStrip4.TabIndex = 131;
            this.skinToolStrip4.Text = "skinToolStrip4";
            this.skinToolStrip4.TitleAnamorphosis = false;
            this.skinToolStrip4.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip4.TitleRadius = 4;
            this.skinToolStrip4.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ChatClientUI.ResourceMainForm._1;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::ChatClientUI.ResourceMainForm._2;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::ChatClientUI.ResourceMainForm._3;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::ChatClientUI.ResourceMainForm._4;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::ChatClientUI.ResourceMainForm._5;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::ChatClientUI.ResourceMainForm._6;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::ChatClientUI.ResourceMainForm._7;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(24, 19);
            this.toolStripButton9.Text = "toolStripButton9";
            // 
            // tsBottomMenuOne
            // 
            this.tsBottomMenuOne.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsBottomMenuOne.AutoSize = false;
            this.tsBottomMenuOne.Back = System.Drawing.Color.White;
            this.tsBottomMenuOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.tsBottomMenuOne.BackRadius = 4;
            this.tsBottomMenuOne.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsBottomMenuOne.Base = System.Drawing.Color.Transparent;
            this.tsBottomMenuOne.BaseFore = System.Drawing.Color.Black;
            this.tsBottomMenuOne.BaseForeAnamorphosis = true;
            this.tsBottomMenuOne.BaseForeAnamorphosisBorder = 4;
            this.tsBottomMenuOne.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsBottomMenuOne.BaseHoverFore = System.Drawing.Color.Black;
            this.tsBottomMenuOne.BaseItemAnamorphosis = true;
            this.tsBottomMenuOne.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.tsBottomMenuOne.BaseItemBorderShow = true;
            this.tsBottomMenuOne.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.tsBottomMenuOne.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsBottomMenuOne.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.tsBottomMenuOne.BaseItemPressed = System.Drawing.Color.Transparent;
            this.tsBottomMenuOne.BaseItemRadius = 2;
            this.tsBottomMenuOne.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsBottomMenuOne.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.tsBottomMenuOne.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottomMenuOne.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsBottomMenuOne.Fore = System.Drawing.Color.Black;
            this.tsBottomMenuOne.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.tsBottomMenuOne.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBottomMenuOne.HoverFore = System.Drawing.Color.White;
            this.tsBottomMenuOne.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBottomMenuOne.ItemAnamorphosis = false;
            this.tsBottomMenuOne.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuOne.ItemBorderShow = false;
            this.tsBottomMenuOne.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuOne.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuOne.ItemRadius = 3;
            this.tsBottomMenuOne.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.tsBottomMenuOne.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsBottomMenuOne.Location = new System.Drawing.Point(1, 639);
            this.tsBottomMenuOne.Name = "tsBottomMenuOne";
            this.tsBottomMenuOne.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.tsBottomMenuOne.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsBottomMenuOne.Size = new System.Drawing.Size(342, 24);
            this.tsBottomMenuOne.TabIndex = 130;
            this.tsBottomMenuOne.Text = "skinToolStrip2";
            this.tsBottomMenuOne.TitleAnamorphosis = false;
            this.tsBottomMenuOne.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsBottomMenuOne.TitleRadius = 4;
            this.tsBottomMenuOne.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsBottomMenuTwo
            // 
            this.tsBottomMenuTwo.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsBottomMenuTwo.AutoSize = false;
            this.tsBottomMenuTwo.Back = System.Drawing.Color.White;
            this.tsBottomMenuTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.tsBottomMenuTwo.BackRadius = 4;
            this.tsBottomMenuTwo.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsBottomMenuTwo.Base = System.Drawing.Color.Transparent;
            this.tsBottomMenuTwo.BaseFore = System.Drawing.Color.Black;
            this.tsBottomMenuTwo.BaseForeAnamorphosis = true;
            this.tsBottomMenuTwo.BaseForeAnamorphosisBorder = 4;
            this.tsBottomMenuTwo.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsBottomMenuTwo.BaseHoverFore = System.Drawing.Color.Black;
            this.tsBottomMenuTwo.BaseItemAnamorphosis = true;
            this.tsBottomMenuTwo.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.tsBottomMenuTwo.BaseItemBorderShow = true;
            this.tsBottomMenuTwo.BaseItemDown = global::ChatClientUI.ResourceControl.btnState_DownBack;
            this.tsBottomMenuTwo.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsBottomMenuTwo.BaseItemMouse = global::ChatClientUI.ResourceControl.btnState_MouseBack;
            this.tsBottomMenuTwo.BaseItemPressed = System.Drawing.Color.Transparent;
            this.tsBottomMenuTwo.BaseItemRadius = 2;
            this.tsBottomMenuTwo.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsBottomMenuTwo.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.tsBottomMenuTwo.CanOverflow = false;
            this.tsBottomMenuTwo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottomMenuTwo.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsBottomMenuTwo.Fore = System.Drawing.Color.Black;
            this.tsBottomMenuTwo.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.tsBottomMenuTwo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBottomMenuTwo.HoverFore = System.Drawing.Color.White;
            this.tsBottomMenuTwo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBottomMenuTwo.ItemAnamorphosis = false;
            this.tsBottomMenuTwo.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuTwo.ItemBorderShow = false;
            this.tsBottomMenuTwo.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuTwo.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsBottomMenuTwo.ItemRadius = 3;
            this.tsBottomMenuTwo.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.tsBottomMenuTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnmainMenu,
            this.tsbtnSysSetting,
            this.toolStripButton2,
            this.toolStripButton19});
            this.tsBottomMenuTwo.Location = new System.Drawing.Point(1, 663);
            this.tsBottomMenuTwo.Name = "tsBottomMenuTwo";
            this.tsBottomMenuTwo.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.tsBottomMenuTwo.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsBottomMenuTwo.Size = new System.Drawing.Size(342, 24);
            this.tsBottomMenuTwo.TabIndex = 129;
            this.tsBottomMenuTwo.Text = "skinToolStrip2";
            this.tsBottomMenuTwo.TitleAnamorphosis = false;
            this.tsBottomMenuTwo.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsBottomMenuTwo.TitleRadius = 4;
            this.tsBottomMenuTwo.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsbtnmainMenu
            // 
            this.tsbtnmainMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnmainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检测升级ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.toolStripSeparator2,
            this.修改密码ToolStripMenuItem,
            this.tsmiExitMain});
            this.tsbtnmainMenu.Image = global::ChatClientUI.ResourceMainForm.menu_btn_normal;
            this.tsbtnmainMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnmainMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnmainMenu.Name = "tsbtnmainMenu";
            this.tsbtnmainMenu.ShowDropDownArrow = false;
            this.tsbtnmainMenu.Size = new System.Drawing.Size(25, 21);
            this.tsbtnmainMenu.Text = "toolStripDropDownButton1";
            // 
            // 检测升级ToolStripMenuItem
            // 
            this.检测升级ToolStripMenuItem.Name = "检测升级ToolStripMenuItem";
            this.检测升级ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.检测升级ToolStripMenuItem.Text = "软件升级";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            // 
            // tsmiExitMain
            // 
            this.tsmiExitMain.Name = "tsmiExitMain";
            this.tsmiExitMain.Size = new System.Drawing.Size(144, 26);
            this.tsmiExitMain.Text = "退出";
            this.tsmiExitMain.Click += new System.EventHandler(this.TsmiExitClick);
            // 
            // tsbtnSysSetting
            // 
            this.tsbtnSysSetting.AutoSize = false;
            this.tsbtnSysSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSysSetting.Image = global::ChatClientUI.ResourceChatForm.settings_20;
            this.tsbtnSysSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSysSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSysSetting.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.tsbtnSysSetting.Name = "tsbtnSysSetting";
            this.tsbtnSysSetting.Size = new System.Drawing.Size(24, 24);
            this.tsbtnSysSetting.ToolTipText = "打开系统设置";
            this.tsbtnSysSetting.Click += new System.EventHandler(this.TsbtnSysSettingClick);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ChatClientUI.ResourceChatForm.messages_20;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton3";
            this.toolStripButton2.ToolTipText = "打开消息管理器";
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.Image = global::ChatClientUI.ResourceChatForm.find_20;
            this.toolStripButton19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton19.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(63, 21);
            this.toolStripButton19.Text = "查找";
            this.toolStripButton19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton19.ToolTipText = "查找联系人";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipText = "聊天工具2013 V1.0";
            this.notifyIconMain.ContextMenuStrip = this.skinContextMenuStripMain;
            this.notifyIconMain.Icon = global::ChatClientUI.ResourceMainForm.logo_xp_16;
            this.notifyIconMain.Text = "聊天工具2013 V1.0";
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMainMouseDoubleClick);
            // 
            // skinContextMenuStripMain
            // 
            this.skinContextMenuStripMain.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStripMain.Back = System.Drawing.Color.White;
            this.skinContextMenuStripMain.BackRadius = 4;
            this.skinContextMenuStripMain.Base = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripMain.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStripMain.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStripMain.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinContextMenuStripMain.ItemAnamorphosis = false;
            this.skinContextMenuStripMain.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripMain.ItemBorderShow = false;
            this.skinContextMenuStripMain.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripMain.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripMain.ItemRadius = 2;
            this.skinContextMenuStripMain.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我在线上ToolStripMenuItem,
            this.离开ToolStripMenuItem,
            this.忙碌ToolStripMenuItem,
            this.隐身ToolStripMenuItem,
            this.tsmiShow,
            this.离线ToolStripMenuItem2,
            this.toolStripSeparator1,
            this.tsmiShowMain,
            this.tsmiExit});
            this.skinContextMenuStripMain.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripMain.Name = "skinContextMenuStripMain";
            this.skinContextMenuStripMain.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripMain.Size = new System.Drawing.Size(160, 218);
            this.skinContextMenuStripMain.TitleAnamorphosis = false;
            this.skinContextMenuStripMain.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStripMain.TitleRadius = 4;
            this.skinContextMenuStripMain.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 我在线上ToolStripMenuItem
            // 
            this.我在线上ToolStripMenuItem.Image = global::ChatClientUI.ResourceStatus.imonline;
            this.我在线上ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.我在线上ToolStripMenuItem.Name = "我在线上ToolStripMenuItem";
            this.我在线上ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.我在线上ToolStripMenuItem.Text = "我在线上";
            // 
            // 离开ToolStripMenuItem
            // 
            this.离开ToolStripMenuItem.Image = global::ChatClientUI.ResourceStatus.away_;
            this.离开ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离开ToolStripMenuItem.Name = "离开ToolStripMenuItem";
            this.离开ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.离开ToolStripMenuItem.Text = "离开";
            // 
            // 忙碌ToolStripMenuItem
            // 
            this.忙碌ToolStripMenuItem.Image = global::ChatClientUI.ResourceStatus.busy_;
            this.忙碌ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.忙碌ToolStripMenuItem.Name = "忙碌ToolStripMenuItem";
            this.忙碌ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.忙碌ToolStripMenuItem.Text = "忙碌";
            // 
            // 隐身ToolStripMenuItem
            // 
            this.隐身ToolStripMenuItem.Image = global::ChatClientUI.ResourceStatus.invisible_;
            this.隐身ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.隐身ToolStripMenuItem.Name = "隐身ToolStripMenuItem";
            this.隐身ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.隐身ToolStripMenuItem.Text = "隐身";
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(159, 26);
            this.tsmiShow.Text = "打开主面版";
            this.tsmiShow.Click += new System.EventHandler(this.TsmiShowClick);
            // 
            // 离线ToolStripMenuItem2
            // 
            this.离线ToolStripMenuItem2.Image = global::ChatClientUI.ResourceStatus.imoffline_;
            this.离线ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离线ToolStripMenuItem2.Name = "离线ToolStripMenuItem2";
            this.离线ToolStripMenuItem2.Size = new System.Drawing.Size(159, 26);
            this.离线ToolStripMenuItem2.Text = "离线";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // tsmiShowMain
            // 
            this.tsmiShowMain.Name = "tsmiShowMain";
            this.tsmiShowMain.Size = new System.Drawing.Size(159, 26);
            this.tsmiShowMain.Text = "打开主面版";
            this.tsmiShowMain.Click += new System.EventHandler(this.TsmiShowMainClick);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(159, 26);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExitClick);
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.skinTabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.skinTabControl1.Controls.Add(this.tabPage1);
            this.skinTabControl1.Controls.Add(this.tabPage2);
            this.skinTabControl1.Controls.Add(this.tabPage3);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 35);
            this.skinTabControl1.Location = new System.Drawing.Point(1, 100);
            this.skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.skinTabControl1.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(342, 587);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 132;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage1.ContextMenuStrip = this.skinContextMenuStripFriend;
            this.tabPage1.Controls.Add(this.chatListBoxBuddy);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(334, 544);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "好友";
            this.tabPage1.ToolTipText = "我的好友";
            // 
            // skinContextMenuStripFriend
            // 
            this.skinContextMenuStripFriend.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStripFriend.Back = System.Drawing.Color.White;
            this.skinContextMenuStripFriend.BackRadius = 4;
            this.skinContextMenuStripFriend.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStripFriend.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStripFriend.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStripFriend.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStripFriend.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinContextMenuStripFriend.ItemAnamorphosis = true;
            this.skinContextMenuStripFriend.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripFriend.ItemBorderShow = true;
            this.skinContextMenuStripFriend.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripFriend.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripFriend.ItemRadius = 4;
            this.skinContextMenuStripFriend.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripFriend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.头像显示ToolStripMenuItem,
            this.名称显示ToolStripMenuItem,
            this.列表显示ToolStripMenuItem});
            this.skinContextMenuStripFriend.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripFriend.Name = "skinContextMenuStripFriend";
            this.skinContextMenuStripFriend.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripFriend.Size = new System.Drawing.Size(145, 82);
            this.skinContextMenuStripFriend.TitleAnamorphosis = true;
            this.skinContextMenuStripFriend.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStripFriend.TitleRadius = 4;
            this.skinContextMenuStripFriend.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 头像显示ToolStripMenuItem
            // 
            this.头像显示ToolStripMenuItem.Name = "头像显示ToolStripMenuItem";
            this.头像显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.头像显示ToolStripMenuItem.Text = "头像显示";
            // 
            // 名称显示ToolStripMenuItem
            // 
            this.名称显示ToolStripMenuItem.Name = "名称显示ToolStripMenuItem";
            this.名称显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.名称显示ToolStripMenuItem.Text = "名称显示";
            // 
            // 列表显示ToolStripMenuItem
            // 
            this.列表显示ToolStripMenuItem.Name = "列表显示ToolStripMenuItem";
            this.列表显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.列表显示ToolStripMenuItem.Text = "列表显示";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage2.ContextMenuStrip = this.skinContextMenuStripGroup;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(334, 540);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群组";
            // 
            // skinContextMenuStripGroup
            // 
            this.skinContextMenuStripGroup.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStripGroup.Back = System.Drawing.Color.White;
            this.skinContextMenuStripGroup.BackRadius = 4;
            this.skinContextMenuStripGroup.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStripGroup.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStripGroup.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStripGroup.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStripGroup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinContextMenuStripGroup.ItemAnamorphosis = true;
            this.skinContextMenuStripGroup.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripGroup.ItemBorderShow = true;
            this.skinContextMenuStripGroup.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripGroup.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripGroup.ItemRadius = 4;
            this.skinContextMenuStripGroup.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图标显示ToolStripMenuItem,
            this.列表显示ToolStripMenuItem1});
            this.skinContextMenuStripGroup.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStripGroup.Name = "skinContextMenuStripGroup";
            this.skinContextMenuStripGroup.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStripGroup.Size = new System.Drawing.Size(145, 56);
            this.skinContextMenuStripGroup.TitleAnamorphosis = true;
            this.skinContextMenuStripGroup.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStripGroup.TitleRadius = 4;
            this.skinContextMenuStripGroup.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 图标显示ToolStripMenuItem
            // 
            this.图标显示ToolStripMenuItem.Name = "图标显示ToolStripMenuItem";
            this.图标显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.图标显示ToolStripMenuItem.Text = "图标显示";
            // 
            // 列表显示ToolStripMenuItem1
            // 
            this.列表显示ToolStripMenuItem1.Name = "列表显示ToolStripMenuItem1";
            this.列表显示ToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.列表显示ToolStripMenuItem1.Text = "列表显示";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(334, 540);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "历史";
            // 
            // skpWeather
            // 
            this.skpWeather.BackColor = System.Drawing.Color.Transparent;
            this.skpWeather.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skpWeather.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skpWeather.DownBack = null;
            this.skpWeather.Location = new System.Drawing.Point(234, 24);
            this.skpWeather.MouseBack = null;
            this.skpWeather.Name = "skpWeather";
            this.skpWeather.NormlBack = null;
            this.skpWeather.Size = new System.Drawing.Size(64, 43);
            this.skpWeather.TabIndex = 134;
            this.skpWeather.MouseEnter += new System.EventHandler(this.SkpWeatherMouseEnter);
            this.skpWeather.MouseLeave += new System.EventHandler(this.SkpWeatherMouseLeave);
            // 
            // userHeader
            // 
            this.userHeader.Location = new System.Drawing.Point(13, 44);
            this.userHeader.Margin = new System.Windows.Forms.Padding(0);
            this.userHeader.Name = "userHeader";
            this.userHeader.Size = new System.Drawing.Size(50, 50);
            this.userHeader.TabIndex = 136;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackLayout = false;
            this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
            this.BorderRectangle = new System.Drawing.Rectangle(1, 1, 1, 1);
            this.BorderWidth = 1;
            this.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 100;
            this.ClientSize = new System.Drawing.Size(344, 688);
            this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
            this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
            this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.userHeader);
            this.Controls.Add(this.skpWeather);
            this.Controls.Add(this.tsBottomMenuOne);
            this.Controls.Add(this.tsBottomMenuTwo);
            this.Controls.Add(this.labelSignature);
            this.Controls.Add(this.skinToolStrip5);
            this.Controls.Add(this.skinTabControl1);
            this.Controls.Add(this.skinToolStrip4);
            this.EffectWidth = 4;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 800);
            this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
            this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
            this.MinimumSize = new System.Drawing.Size(300, 600);
            this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
            this.Name = "MainForm";
            this.Radius = 1;
            this.Shadow = false;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SysBottomDown = global::ChatClientUI.ResourceForm.btn_Skin_down;
            this.SysBottomMouse = global::ChatClientUI.ResourceForm.btn_Skin_highlight;
            this.SysBottomNorml = global::ChatClientUI.ResourceForm.btn_Skin_normal;
            this.SysBottomVisibale = true;
            this.Text = "局域网聊天程序";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.skinToolStrip5.ResumeLayout(false);
            this.skinToolStrip5.PerformLayout();
            this.skinToolStrip4.ResumeLayout(false);
            this.skinToolStrip4.PerformLayout();
            this.tsBottomMenuTwo.ResumeLayout(false);
            this.tsBottomMenuTwo.PerformLayout();
            this.skinContextMenuStripMain.ResumeLayout(false);
            this.skinTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.skinContextMenuStripFriend.ResumeLayout(false);
            this.skinContextMenuStripGroup.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private Complents.ChatComp.UserHeaderControl userHeader;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowMain;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 离线ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 隐身ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 忙碌ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 离开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 我在线上ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 列表显示ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 图标显示ToolStripMenuItem;
		private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStripGroup;
		private System.Windows.Forms.ToolStripMenuItem 列表显示ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 名称显示ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 头像显示ToolStripMenuItem;
		private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStripFriend;
		private CCWin.SkinControl.SkinPanel skpWeather;
		private System.Windows.Forms.ToolStripMenuItem tsmiExitMain;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private CCWin.SkinControl.SkinTabControl skinTabControl1;
		private System.Windows.Forms.ToolStripMenuItem tsmiMineInfo;
		private System.Windows.Forms.ToolStripMenuItem tsmiSystemSetting;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem 离线ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 隐身ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 忙碌ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 离开ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 我在线上ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 检测升级ToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton tsbtnmainMenu;
		private CCWin.SkinControl.SkinToolStrip tsBottomMenuOne;
		private CCWin.SkinControl.SkinToolStrip tsBottomMenuTwo;
		private System.Windows.Forms.ToolStripButton tsbtnSysSetting;
		private CCWin.SkinControl.SkinLabel labelSignature;
		private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStripMain;
		private System.Windows.Forms.ToolStripMenuItem tsmiShow;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.NotifyIcon notifyIconMain;
		private CCWin.SkinControl.ChatListBox chatListBoxBuddy;
		private System.Windows.Forms.ToolStripLabel tslblUserName;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private CCWin.SkinControl.SkinToolStrip skinToolStrip5;
		private CCWin.SkinControl.SkinToolStrip skinToolStrip4;
		private System.Windows.Forms.ToolStripButton toolStripButton19;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
	}
}
