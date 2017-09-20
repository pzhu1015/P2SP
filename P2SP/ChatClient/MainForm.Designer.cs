namespace ChatClient
{
    partial class MainForm
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
            CCWin.SkinControl.ChatListItem chatListItem1 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem2 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem3 = new CCWin.SkinControl.ChatListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chatListBox1 = new CCWin.SkinControl.ChatListBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.软件升级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerHeadList = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeftHead = new System.Windows.Forms.SplitContainer();
            this.userHeaderControl1 = new Complents.ChatComp.UserHeaderControl();
            this.splitContainerRightWeather = new System.Windows.Forms.SplitContainer();
            this.skinToolStrip4 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.skinToolStrip3 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripTextBoxMotto = new System.Windows.Forms.ToolStripTextBox();
            this.skinToolStrip2 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.我在线上ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.忙碌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我的资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picWeather = new System.Windows.Forms.PictureBox();
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.skinToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHeadList)).BeginInit();
            this.splitContainerHeadList.Panel1.SuspendLayout();
            this.splitContainerHeadList.Panel2.SuspendLayout();
            this.splitContainerHeadList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftHead)).BeginInit();
            this.splitContainerLeftHead.Panel1.SuspendLayout();
            this.splitContainerLeftHead.Panel2.SuspendLayout();
            this.splitContainerLeftHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightWeather)).BeginInit();
            this.splitContainerRightWeather.Panel1.SuspendLayout();
            this.splitContainerRightWeather.Panel2.SuspendLayout();
            this.splitContainerRightWeather.SuspendLayout();
            this.skinToolStrip4.SuspendLayout();
            this.skinToolStrip3.SuspendLayout();
            this.skinToolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            this.skinTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatListBox1
            // 
            this.chatListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatListBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatListBox1.ForeColor = System.Drawing.Color.Black;
            chatListItem1.Bounds = new System.Drawing.Rectangle(0, 1, 296, 25);
            chatListItem1.IsTwinkleHide = false;
            chatListItem1.OwnerChatListBox = this.chatListBox1;
            chatListItem1.Text = "我的好友";
            chatListItem1.TwinkleSubItemNumber = 0;
            chatListItem2.Bounds = new System.Drawing.Rectangle(0, 27, 296, 25);
            chatListItem2.IsTwinkleHide = false;
            chatListItem2.OwnerChatListBox = this.chatListBox1;
            chatListItem2.Text = "陌生人";
            chatListItem2.TwinkleSubItemNumber = 0;
            chatListItem3.Bounds = new System.Drawing.Rectangle(0, 53, 296, 25);
            chatListItem3.IsTwinkleHide = false;
            chatListItem3.OwnerChatListBox = this.chatListBox1;
            chatListItem3.Text = "黑名单";
            chatListItem3.TwinkleSubItemNumber = 0;
            this.chatListBox1.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem1,
            chatListItem2,
            chatListItem3});
            this.chatListBox1.ListSubItemMenu = null;
            this.chatListBox1.Location = new System.Drawing.Point(3, 3);
            this.chatListBox1.Name = "chatListBox1";
            this.chatListBox1.Size = new System.Drawing.Size(296, 394);
            this.chatListBox1.SubItemMenu = null;
            this.chatListBox1.TabIndex = 0;
            this.chatListBox1.Text = "chatListBox1";
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackColor = System.Drawing.Color.White;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.White;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = global::ChatClient.ControlResource.btnState_DownBack;
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemMouse = global::ChatClient.ControlResource.btnState_MouseBack;
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemRadius = 4;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip1.ItemAnamorphosis = true;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = true;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 4;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.skinToolStrip1.Location = new System.Drawing.Point(3, 570);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(310, 27);
            this.skinToolStrip1.TabIndex = 0;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.skinToolStrip1.TitleAnamorphosis = true;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.软件升级ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.修改密码ToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::ChatClient.ToolStripResource.menu_btn_normal;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // 软件升级ToolStripMenuItem
            // 
            this.软件升级ToolStripMenuItem.Name = "软件升级ToolStripMenuItem";
            this.软件升级ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.软件升级ToolStripMenuItem.Text = "软件升级";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出EToolStripMenuItem.Text = "退出";
            // 
            // splitContainerHeadList
            // 
            this.splitContainerHeadList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHeadList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerHeadList.IsSplitterFixed = true;
            this.splitContainerHeadList.Location = new System.Drawing.Point(3, 24);
            this.splitContainerHeadList.Name = "splitContainerHeadList";
            this.splitContainerHeadList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHeadList.Panel1
            // 
            this.splitContainerHeadList.Panel1.Controls.Add(this.splitContainerLeftHead);
            // 
            // splitContainerHeadList.Panel2
            // 
            this.splitContainerHeadList.Panel2.Controls.Add(this.skinTabControl1);
            this.splitContainerHeadList.Size = new System.Drawing.Size(310, 546);
            this.splitContainerHeadList.SplitterDistance = 101;
            this.splitContainerHeadList.SplitterWidth = 1;
            this.splitContainerHeadList.TabIndex = 2;
            // 
            // splitContainerLeftHead
            // 
            this.splitContainerLeftHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeftHead.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLeftHead.IsSplitterFixed = true;
            this.splitContainerLeftHead.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeftHead.Name = "splitContainerLeftHead";
            // 
            // splitContainerLeftHead.Panel1
            // 
            this.splitContainerLeftHead.Panel1.Controls.Add(this.userHeaderControl1);
            this.splitContainerLeftHead.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // splitContainerLeftHead.Panel2
            // 
            this.splitContainerLeftHead.Panel2.Controls.Add(this.splitContainerRightWeather);
            this.splitContainerLeftHead.Size = new System.Drawing.Size(310, 101);
            this.splitContainerLeftHead.SplitterDistance = 88;
            this.splitContainerLeftHead.SplitterWidth = 1;
            this.splitContainerLeftHead.TabIndex = 1;
            // 
            // userHeaderControl1
            // 
            this.userHeaderControl1.Location = new System.Drawing.Point(7, 8);
            this.userHeaderControl1.Margin = new System.Windows.Forms.Padding(0);
            this.userHeaderControl1.Name = "userHeaderControl1";
            this.userHeaderControl1.Size = new System.Drawing.Size(66, 64);
            this.userHeaderControl1.TabIndex = 0;
            // 
            // splitContainerRightWeather
            // 
            this.splitContainerRightWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRightWeather.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerRightWeather.IsSplitterFixed = true;
            this.splitContainerRightWeather.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRightWeather.Name = "splitContainerRightWeather";
            // 
            // splitContainerRightWeather.Panel1
            // 
            this.splitContainerRightWeather.Panel1.Controls.Add(this.skinToolStrip4);
            this.splitContainerRightWeather.Panel1.Controls.Add(this.skinToolStrip3);
            this.splitContainerRightWeather.Panel1.Controls.Add(this.skinToolStrip2);
            this.splitContainerRightWeather.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // splitContainerRightWeather.Panel2
            // 
            this.splitContainerRightWeather.Panel2.Controls.Add(this.picWeather);
            this.splitContainerRightWeather.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            this.splitContainerRightWeather.Size = new System.Drawing.Size(221, 101);
            this.splitContainerRightWeather.SplitterDistance = 144;
            this.splitContainerRightWeather.SplitterWidth = 1;
            this.splitContainerRightWeather.TabIndex = 0;
            // 
            // skinToolStrip4
            // 
            this.skinToolStrip4.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip4.Back = System.Drawing.Color.White;
            this.skinToolStrip4.BackRadius = 4;
            this.skinToolStrip4.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip4.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip4.BaseForeAnamorphosis = false;
            this.skinToolStrip4.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip4.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip4.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip4.BaseItemAnamorphosis = true;
            this.skinToolStrip4.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.BaseItemBorderShow = true;
            this.skinToolStrip4.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip4.BaseItemDown")));
            this.skinToolStrip4.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip4.BaseItemMouse")));
            this.skinToolStrip4.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.BaseItemRadius = 4;
            this.skinToolStrip4.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinToolStrip4.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip4.Fore = System.Drawing.Color.Black;
            this.skinToolStrip4.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip4.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip4.ItemAnamorphosis = true;
            this.skinToolStrip4.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemBorderShow = true;
            this.skinToolStrip4.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemRadius = 4;
            this.skinToolStrip4.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.skinToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.skinToolStrip4.Location = new System.Drawing.Point(0, 74);
            this.skinToolStrip4.Name = "skinToolStrip4";
            this.skinToolStrip4.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.Size = new System.Drawing.Size(144, 27);
            this.skinToolStrip4.TabIndex = 2;
            this.skinToolStrip4.Text = "skinToolStrip4";
            this.skinToolStrip4.TitleAnamorphosis = true;
            this.skinToolStrip4.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip4.TitleRadius = 4;
            this.skinToolStrip4.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ChatClient.ToolStripResource._1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ChatClient.ToolStripResource._2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ChatClient.ToolStripResource._3;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::ChatClient.ToolStripResource._4;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::ChatClient.ToolStripResource._5;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // skinToolStrip3
            // 
            this.skinToolStrip3.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip3.Back = System.Drawing.Color.White;
            this.skinToolStrip3.BackRadius = 4;
            this.skinToolStrip3.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip3.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseForeAnamorphosis = false;
            this.skinToolStrip3.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip3.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip3.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip3.BaseItemAnamorphosis = true;
            this.skinToolStrip3.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.BaseItemBorderShow = true;
            this.skinToolStrip3.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemDown")));
            this.skinToolStrip3.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemMouse")));
            this.skinToolStrip3.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.BaseItemRadius = 4;
            this.skinToolStrip3.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip3.Fore = System.Drawing.Color.Black;
            this.skinToolStrip3.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip3.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip3.ItemAnamorphosis = true;
            this.skinToolStrip3.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemBorderShow = true;
            this.skinToolStrip3.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemRadius = 4;
            this.skinToolStrip3.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxMotto});
            this.skinToolStrip3.Location = new System.Drawing.Point(0, 25);
            this.skinToolStrip3.Name = "skinToolStrip3";
            this.skinToolStrip3.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.Size = new System.Drawing.Size(144, 25);
            this.skinToolStrip3.TabIndex = 1;
            this.skinToolStrip3.Text = "skinToolStrip3";
            this.skinToolStrip3.TitleAnamorphosis = true;
            this.skinToolStrip3.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip3.TitleRadius = 4;
            this.skinToolStrip3.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // toolStripTextBoxMotto
            // 
            this.toolStripTextBoxMotto.AutoToolTip = true;
            this.toolStripTextBoxMotto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.toolStripTextBoxMotto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxMotto.Name = "toolStripTextBoxMotto";
            this.toolStripTextBoxMotto.ReadOnly = true;
            this.toolStripTextBoxMotto.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxMotto.Text = "站在巨人肩膀上才能看得更远";
            this.toolStripTextBoxMotto.Leave += new System.EventHandler(this.toolStripTextBoxMotto_Leave);
            this.toolStripTextBoxMotto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripTextBoxMotto_MouseDown);
            // 
            // skinToolStrip2
            // 
            this.skinToolStrip2.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip2.Back = System.Drawing.Color.White;
            this.skinToolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinToolStrip2.BackRadius = 4;
            this.skinToolStrip2.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip2.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip2.BaseForeAnamorphosis = false;
            this.skinToolStrip2.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip2.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip2.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip2.BaseItemAnamorphosis = true;
            this.skinToolStrip2.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.BaseItemBorderShow = true;
            this.skinToolStrip2.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemDown")));
            this.skinToolStrip2.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemMouse")));
            this.skinToolStrip2.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.BaseItemRadius = 4;
            this.skinToolStrip2.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip2.Fore = System.Drawing.Color.Black;
            this.skinToolStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip2.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip2.ItemAnamorphosis = true;
            this.skinToolStrip2.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemBorderShow = true;
            this.skinToolStrip2.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemRadius = 4;
            this.skinToolStrip2.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2});
            this.skinToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip2.Name = "skinToolStrip2";
            this.skinToolStrip2.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.Size = new System.Drawing.Size(144, 25);
            this.skinToolStrip2.TabIndex = 0;
            this.skinToolStrip2.Text = "skinToolStrip2";
            this.skinToolStrip2.TitleAnamorphosis = true;
            this.skinToolStrip2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip2.TitleRadius = 4;
            this.skinToolStrip2.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_MoveForm);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我在线上ToolStripMenuItem,
            this.离开ToolStripMenuItem,
            this.忙碌ToolStripMenuItem,
            this.离线ToolStripMenuItem,
            this.离线ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.系统设置ToolStripMenuItem,
            this.我的资料ToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::ChatClient.ToolStripResource.imonline;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(80, 22);
            this.toolStripDropDownButton2.Text = "龙腾虎跃";
            this.toolStripDropDownButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // 我在线上ToolStripMenuItem
            // 
            this.我在线上ToolStripMenuItem.Image = global::ChatClient.ToolStripResource.imonline;
            this.我在线上ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.我在线上ToolStripMenuItem.Name = "我在线上ToolStripMenuItem";
            this.我在线上ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.我在线上ToolStripMenuItem.Text = "我在线上";
            // 
            // 离开ToolStripMenuItem
            // 
            this.离开ToolStripMenuItem.Image = global::ChatClient.ToolStripResource.away;
            this.离开ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离开ToolStripMenuItem.Name = "离开ToolStripMenuItem";
            this.离开ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.离开ToolStripMenuItem.Text = "离开";
            // 
            // 忙碌ToolStripMenuItem
            // 
            this.忙碌ToolStripMenuItem.Image = global::ChatClient.ToolStripResource.busy;
            this.忙碌ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.忙碌ToolStripMenuItem.Name = "忙碌ToolStripMenuItem";
            this.忙碌ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.忙碌ToolStripMenuItem.Text = "忙碌";
            // 
            // 离线ToolStripMenuItem
            // 
            this.离线ToolStripMenuItem.Image = global::ChatClient.ToolStripResource.invisible;
            this.离线ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离线ToolStripMenuItem.Name = "离线ToolStripMenuItem";
            this.离线ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.离线ToolStripMenuItem.Text = "隐身";
            // 
            // 离线ToolStripMenuItem1
            // 
            this.离线ToolStripMenuItem1.Image = global::ChatClient.ToolStripResource.imoffline;
            this.离线ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.离线ToolStripMenuItem1.Name = "离线ToolStripMenuItem1";
            this.离线ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.离线ToolStripMenuItem1.Text = "离线";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 我的资料ToolStripMenuItem
            // 
            this.我的资料ToolStripMenuItem.Name = "我的资料ToolStripMenuItem";
            this.我的资料ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.我的资料ToolStripMenuItem.Text = "我的资料";
            // 
            // picWeather
            // 
            this.picWeather.Image = global::ChatClient.WeatherResource.b_0;
            this.picWeather.Location = new System.Drawing.Point(4, 9);
            this.picWeather.Name = "picWeather";
            this.picWeather.Padding = new System.Windows.Forms.Padding(10);
            this.picWeather.Size = new System.Drawing.Size(72, 72);
            this.picWeather.TabIndex = 0;
            this.picWeather.TabStop = false;
            this.picWeather.MouseEnter += new System.EventHandler(this.picWeather_MouseEnter);
            this.picWeather.MouseLeave += new System.EventHandler(this.picWeather_MouseLeave);
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.BaseColor = System.Drawing.Color.White;
            this.skinTabControl1.BorderColor = System.Drawing.Color.White;
            this.skinTabControl1.Controls.Add(this.tabPage1);
            this.skinTabControl1.Controls.Add(this.tabPage2);
            this.skinTabControl1.Controls.Add(this.tabPage3);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(0, 0);
            this.skinTabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.Padding = new System.Drawing.Point(1, 1);
            this.skinTabControl1.PageColor = System.Drawing.Color.White;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(310, 444);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.chatListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(302, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "联系人";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(302, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群聊";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage3.Size = new System.Drawing.Size(302, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "会话";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackPalace = global::ChatClient.FormResource.BackPalace;
            this.ClientSize = new System.Drawing.Size(316, 600);
            this.CloseDownBack = global::ChatClient.FormResource.btn_close_down;
            this.CloseMouseBack = global::ChatClient.FormResource.btn_close_mouse;
            this.CloseNormlBack = global::ChatClient.FormResource.btn_close_normal;
            this.Controls.Add(this.splitContainerHeadList);
            this.Controls.Add(this.skinToolStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 1000);
            this.MiniDownBack = global::ChatClient.FormResource.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.FormResource.btn_mini_mouse;
            this.MinimumSize = new System.Drawing.Size(300, 600);
            this.MiniNormlBack = global::ChatClient.FormResource.btn_mini_normal;
            this.Name = "MainForm";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.SysBottomDown = global::ChatClient.FormResource.btn_Skin_down;
            this.SysBottomMouse = global::ChatClient.FormResource.btn_Skin_mouse;
            this.SysBottomNorml = global::ChatClient.FormResource.btn_Skin_normal;
            this.SysBottomVisibale = true;
            this.Text = "P2SP通信程序";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.splitContainerHeadList.Panel1.ResumeLayout(false);
            this.splitContainerHeadList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHeadList)).EndInit();
            this.splitContainerHeadList.ResumeLayout(false);
            this.splitContainerLeftHead.Panel1.ResumeLayout(false);
            this.splitContainerLeftHead.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeftHead)).EndInit();
            this.splitContainerLeftHead.ResumeLayout(false);
            this.splitContainerRightWeather.Panel1.ResumeLayout(false);
            this.splitContainerRightWeather.Panel1.PerformLayout();
            this.splitContainerRightWeather.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRightWeather)).EndInit();
            this.splitContainerRightWeather.ResumeLayout(false);
            this.skinToolStrip4.ResumeLayout(false);
            this.skinToolStrip4.PerformLayout();
            this.skinToolStrip3.ResumeLayout(false);
            this.skinToolStrip3.PerformLayout();
            this.skinToolStrip2.ResumeLayout(false);
            this.skinToolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            this.skinTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.SplitContainer splitContainerHeadList;
        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CCWin.SkinControl.ChatListBox chatListBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件升级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private Complents.ChatComp.UserHeaderControl userHeaderControl1;
        private System.Windows.Forms.SplitContainer splitContainerLeftHead;
        private System.Windows.Forms.SplitContainer splitContainerRightWeather;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 我在线上ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 离开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 忙碌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 离线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 离线ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我的资料ToolStripMenuItem;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip3;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMotto;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox picWeather;
    }
}