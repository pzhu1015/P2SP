/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-12
 * Time: 23:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class DownLoadForm
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
			this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.mainBarManager = new DevComponents.DotNetBar.DotNetBarManager(this.components);
			this.dockSite4 = new DevComponents.DotNetBar.DockSite();
			this.dockSite1 = new DevComponents.DotNetBar.DockSite();
			this.dockSite2 = new DevComponents.DotNetBar.DockSite();
			this.dockSite8 = new DevComponents.DotNetBar.DockSite();
			this.dockSite5 = new DevComponents.DotNetBar.DockSite();
			this.dockSite6 = new DevComponents.DotNetBar.DockSite();
			this.dockSite7 = new DevComponents.DotNetBar.DockSite();
			this.bar3 = new DevComponents.DotNetBar.Bar();
			this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem17 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem18 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem19 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem15 = new DevComponents.DotNetBar.ButtonItem();
			this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
			this.btnItemAbout = new DevComponents.DotNetBar.ButtonItem();
			this.dockSite3 = new DevComponents.DotNetBar.DockSite();
			this.barStatusMain = new DevComponents.DotNetBar.Bar();
			this.btnDownLoadSpeed = new DevComponents.DotNetBar.ButtonItem();
			this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
			this.splitContainerRight = new System.Windows.Forms.SplitContainer();
			this.lstViewMain = new ExtendControl.EXListView();
			this.bar2 = new DevComponents.DotNetBar.Bar();
			this.tsbAdd = new DevComponents.DotNetBar.ButtonItem();
			this.tsbStart = new DevComponents.DotNetBar.ButtonItem();
			this.tsbStop = new DevComponents.DotNetBar.ButtonItem();
			this.tsbDelete = new DevComponents.DotNetBar.ButtonItem();
			this.tsbOpen = new DevComponents.DotNetBar.ButtonItem();
			this.tsbOptions = new DevComponents.DotNetBar.ButtonItem();
			this.rightSplitter = new DevComponents.DotNetBar.ExpandableSplitter();
			this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
			this.labelX7 = new DevComponents.DotNetBar.LabelX();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.dockSite7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barStatusMain)).BeginInit();
			this.splitContainerLeft.Panel2.SuspendLayout();
			this.splitContainerLeft.SuspendLayout();
			this.splitContainerRight.Panel1.SuspendLayout();
			this.splitContainerRight.Panel2.SuspendLayout();
			this.splitContainerRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
			this.expandablePanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainNotifyIcon
			// 
			this.mainNotifyIcon.Icon = global::DownLoad.MainIcon.notify_32;
			this.mainNotifyIcon.Text = "下载程序";
			this.mainNotifyIcon.Visible = true;
			// 
			// mainBarManager
			// 
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
			this.mainBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
			this.mainBarManager.BottomDockSite = this.dockSite4;
			this.mainBarManager.DefinitionName = "";
			this.mainBarManager.EnableFullSizeDock = false;
			this.mainBarManager.LeftDockSite = this.dockSite1;
			this.mainBarManager.ParentForm = this;
			this.mainBarManager.RightDockSite = this.dockSite2;
			this.mainBarManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.mainBarManager.ToolbarBottomDockSite = this.dockSite8;
			this.mainBarManager.ToolbarLeftDockSite = this.dockSite5;
			this.mainBarManager.ToolbarRightDockSite = this.dockSite6;
			this.mainBarManager.ToolbarTopDockSite = this.dockSite7;
			this.mainBarManager.TopDockSite = this.dockSite3;
			// 
			// dockSite4
			// 
			this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
			this.dockSite4.Location = new System.Drawing.Point(0, 660);
			this.dockSite4.Name = "dockSite4";
			this.dockSite4.Size = new System.Drawing.Size(1010, 0);
			this.dockSite4.TabIndex = 13;
			this.dockSite4.TabStop = false;
			// 
			// dockSite1
			// 
			this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
			this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
			this.dockSite1.Location = new System.Drawing.Point(0, 25);
			this.dockSite1.Name = "dockSite1";
			this.dockSite1.Size = new System.Drawing.Size(0, 635);
			this.dockSite1.TabIndex = 10;
			this.dockSite1.TabStop = false;
			// 
			// dockSite2
			// 
			this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
			this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
			this.dockSite2.Location = new System.Drawing.Point(1010, 25);
			this.dockSite2.Name = "dockSite2";
			this.dockSite2.Size = new System.Drawing.Size(0, 635);
			this.dockSite2.TabIndex = 11;
			this.dockSite2.TabStop = false;
			// 
			// dockSite8
			// 
			this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dockSite8.Location = new System.Drawing.Point(0, 660);
			this.dockSite8.Name = "dockSite8";
			this.dockSite8.Size = new System.Drawing.Size(1010, 0);
			this.dockSite8.TabIndex = 17;
			this.dockSite8.TabStop = false;
			// 
			// dockSite5
			// 
			this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
			this.dockSite5.Location = new System.Drawing.Point(0, 25);
			this.dockSite5.Name = "dockSite5";
			this.dockSite5.Size = new System.Drawing.Size(0, 635);
			this.dockSite5.TabIndex = 14;
			this.dockSite5.TabStop = false;
			// 
			// dockSite6
			// 
			this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
			this.dockSite6.Location = new System.Drawing.Point(1010, 25);
			this.dockSite6.Name = "dockSite6";
			this.dockSite6.Size = new System.Drawing.Size(0, 635);
			this.dockSite6.TabIndex = 15;
			this.dockSite6.TabStop = false;
			// 
			// dockSite7
			// 
			this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite7.Controls.Add(this.bar3);
			this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
			this.dockSite7.Location = new System.Drawing.Point(0, 0);
			this.dockSite7.Name = "dockSite7";
			this.dockSite7.Size = new System.Drawing.Size(1010, 25);
			this.dockSite7.TabIndex = 16;
			this.dockSite7.TabStop = false;
			// 
			// bar3
			// 
			this.bar3.AccessibleDescription = "DotNetBar Bar (bar3)";
			this.bar3.AccessibleName = "DotNetBar Bar";
			this.bar3.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
			this.bar3.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
			this.bar3.DockSide = DevComponents.DotNetBar.eDockSide.Top;
			this.bar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.buttonItem6,
									this.buttonItem11,
									this.buttonItem12,
									this.buttonItem13});
			this.bar3.Location = new System.Drawing.Point(0, 0);
			this.bar3.MenuBar = true;
			this.bar3.Name = "bar3";
			this.bar3.Size = new System.Drawing.Size(1010, 24);
			this.bar3.Stretch = true;
			this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar3.TabIndex = 0;
			this.bar3.TabStop = false;
			this.bar3.Text = "bar3";
			// 
			// buttonItem6
			// 
			this.buttonItem6.ImagePaddingHorizontal = 8;
			this.buttonItem6.Name = "buttonItem6";
			this.buttonItem6.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.buttonItem5,
									this.buttonItem7,
									this.buttonItem8,
									this.buttonItem9,
									this.buttonItem10,
									this.buttonItem4});
			this.buttonItem6.Text = "文件(&F)";
			// 
			// buttonItem5
			// 
			this.buttonItem5.Image = global::DownLoad.MainIcon.button_new_16;
			this.buttonItem5.ImagePaddingHorizontal = 8;
			this.buttonItem5.Name = "buttonItem5";
			this.buttonItem5.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
			this.buttonItem5.Text = "新建(&N)";
			// 
			// buttonItem7
			// 
			this.buttonItem7.Image = global::DownLoad.MainIcon.button_start_16;
			this.buttonItem7.ImagePaddingHorizontal = 8;
			this.buttonItem7.Name = "buttonItem7";
			this.buttonItem7.Text = "开始(&S)";
			// 
			// buttonItem8
			// 
			this.buttonItem8.Image = global::DownLoad.MainIcon.button_stop_16;
			this.buttonItem8.ImagePaddingHorizontal = 8;
			this.buttonItem8.Name = "buttonItem8";
			this.buttonItem8.Text = "停止(&P)";
			// 
			// buttonItem9
			// 
			this.buttonItem9.Image = global::DownLoad.MainIcon.button_delete_16;
			this.buttonItem9.ImagePaddingHorizontal = 8;
			this.buttonItem9.Name = "buttonItem9";
			this.buttonItem9.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
			this.buttonItem9.Text = "删除(&D)";
			// 
			// buttonItem10
			// 
			this.buttonItem10.Image = global::DownLoad.MainIcon.button_open_16;
			this.buttonItem10.ImagePaddingHorizontal = 8;
			this.buttonItem10.Name = "buttonItem10";
			this.buttonItem10.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlO);
			this.buttonItem10.Text = "打开(&O)";
			// 
			// buttonItem4
			// 
			this.buttonItem4.ImagePaddingHorizontal = 8;
			this.buttonItem4.Name = "buttonItem4";
			this.buttonItem4.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
			this.buttonItem4.Text = "退出(&E)";
			// 
			// buttonItem11
			// 
			this.buttonItem11.ImagePaddingHorizontal = 8;
			this.buttonItem11.Name = "buttonItem11";
			this.buttonItem11.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.buttonItem16,
									this.buttonItem17,
									this.buttonItem18,
									this.buttonItem19});
			this.buttonItem11.Text = "编辑(&E)";
			// 
			// buttonItem16
			// 
			this.buttonItem16.ImagePaddingHorizontal = 8;
			this.buttonItem16.Name = "buttonItem16";
			this.buttonItem16.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF);
			this.buttonItem16.Text = "查找(&F)";
			// 
			// buttonItem17
			// 
			this.buttonItem17.ImagePaddingHorizontal = 8;
			this.buttonItem17.Name = "buttonItem17";
			this.buttonItem17.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
			this.buttonItem17.Text = "全选(&A)";
			// 
			// buttonItem18
			// 
			this.buttonItem18.ImagePaddingHorizontal = 8;
			this.buttonItem18.Name = "buttonItem18";
			this.buttonItem18.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlI);
			this.buttonItem18.Text = "反选(&I)";
			// 
			// buttonItem19
			// 
			this.buttonItem19.ImagePaddingHorizontal = 8;
			this.buttonItem19.Name = "buttonItem19";
			this.buttonItem19.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
			this.buttonItem19.Text = "属性(&P)";
			// 
			// buttonItem12
			// 
			this.buttonItem12.ImagePaddingHorizontal = 8;
			this.buttonItem12.Name = "buttonItem12";
			this.buttonItem12.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.buttonItem15});
			this.buttonItem12.Text = "工具(&T)";
			// 
			// buttonItem15
			// 
			this.buttonItem15.Image = global::DownLoad.MainIcon.button_options_16;
			this.buttonItem15.ImagePaddingHorizontal = 8;
			this.buttonItem15.Name = "buttonItem15";
			this.buttonItem15.Text = "配置中心(&O)";
			// 
			// buttonItem13
			// 
			this.buttonItem13.ImagePaddingHorizontal = 8;
			this.buttonItem13.Name = "buttonItem13";
			this.buttonItem13.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.btnItemAbout});
			this.buttonItem13.Text = "帮助(&H)";
			// 
			// btnItemAbout
			// 
			this.btnItemAbout.ImagePaddingHorizontal = 8;
			this.btnItemAbout.Name = "btnItemAbout";
			this.btnItemAbout.Text = "关于(&A)";
			this.btnItemAbout.Click += new System.EventHandler(this.BtnItemAboutClick);
			// 
			// dockSite3
			// 
			this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
			this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
			this.dockSite3.Location = new System.Drawing.Point(0, 25);
			this.dockSite3.Name = "dockSite3";
			this.dockSite3.Size = new System.Drawing.Size(1010, 0);
			this.dockSite3.TabIndex = 12;
			this.dockSite3.TabStop = false;
			// 
			// barStatusMain
			// 
			this.barStatusMain.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
			this.barStatusMain.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barStatusMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.btnDownLoadSpeed});
			this.barStatusMain.Location = new System.Drawing.Point(0, 635);
			this.barStatusMain.Name = "barStatusMain";
			this.barStatusMain.Size = new System.Drawing.Size(1010, 25);
			this.barStatusMain.Stretch = true;
			this.barStatusMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.barStatusMain.TabIndex = 19;
			this.barStatusMain.TabStop = false;
			// 
			// btnDownLoadSpeed
			// 
			this.btnDownLoadSpeed.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.btnDownLoadSpeed.FixedSize = new System.Drawing.Size(200, 0);
			this.btnDownLoadSpeed.Image = global::DownLoad.MainIcon.download_16;
			this.btnDownLoadSpeed.ImagePaddingHorizontal = 8;
			this.btnDownLoadSpeed.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
			this.btnDownLoadSpeed.Name = "btnDownLoadSpeed";
			this.btnDownLoadSpeed.Text = "00.00KB/s";
			// 
			// splitContainerLeft
			// 
			this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerLeft.IsSplitterFixed = true;
			this.splitContainerLeft.Location = new System.Drawing.Point(0, 25);
			this.splitContainerLeft.Name = "splitContainerLeft";
			// 
			// splitContainerLeft.Panel2
			// 
			this.splitContainerLeft.Panel2.Controls.Add(this.splitContainerRight);
			this.splitContainerLeft.Size = new System.Drawing.Size(1010, 610);
			this.splitContainerLeft.SplitterDistance = 230;
			this.splitContainerLeft.SplitterWidth = 1;
			this.splitContainerLeft.TabIndex = 20;
			// 
			// splitContainerRight
			// 
			this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerRight.IsSplitterFixed = true;
			this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
			this.splitContainerRight.Name = "splitContainerRight";
			// 
			// splitContainerRight.Panel1
			// 
			this.splitContainerRight.Panel1.Controls.Add(this.lstViewMain);
			this.splitContainerRight.Panel1.Controls.Add(this.bar2);
			// 
			// splitContainerRight.Panel2
			// 
			this.splitContainerRight.Panel2.Controls.Add(this.rightSplitter);
			this.splitContainerRight.Panel2.Controls.Add(this.expandablePanel1);
			this.splitContainerRight.Panel2MinSize = 0;
			this.splitContainerRight.Size = new System.Drawing.Size(779, 610);
			this.splitContainerRight.SplitterDistance = 551;
			this.splitContainerRight.SplitterWidth = 1;
			this.splitContainerRight.TabIndex = 0;
			// 
			// lstViewMain
			// 
			this.lstViewMain.ControlPadding = 4;
			this.lstViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstViewMain.FullRowSelect = true;
			this.lstViewMain.Location = new System.Drawing.Point(0, 41);
			this.lstViewMain.MinimumSize = new System.Drawing.Size(100, 100);
			this.lstViewMain.Name = "lstViewMain";
			this.lstViewMain.OwnerDraw = true;
			this.lstViewMain.Size = new System.Drawing.Size(551, 569);
			this.lstViewMain.TabIndex = 23;
			this.lstViewMain.UseCompatibleStateImageBehavior = false;
			this.lstViewMain.View = System.Windows.Forms.View.Details;
			this.lstViewMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstViewMainMouseDoubleClick);
			this.lstViewMain.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LstViewMainItemSelectionChanged);
			// 
			// bar2
			// 
			this.bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
			this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
			this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.tsbAdd,
									this.tsbStart,
									this.tsbStop,
									this.tsbDelete,
									this.tsbOpen,
									this.tsbOptions});
			this.bar2.ItemSpacing = 5;
			this.bar2.Location = new System.Drawing.Point(0, 0);
			this.bar2.Name = "bar2";
			this.bar2.Size = new System.Drawing.Size(551, 41);
			this.bar2.Stretch = true;
			this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.bar2.TabIndex = 22;
			this.bar2.TabStop = false;
			this.bar2.Text = "bar2";
			// 
			// tsbAdd
			// 
			this.tsbAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbAdd.Image = global::DownLoad.MainIcon.button_new_32;
			this.tsbAdd.ImagePaddingHorizontal = 8;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Text = "新建";
			this.tsbAdd.Click += new System.EventHandler(this.TsbAddClick);
			// 
			// tsbStart
			// 
			this.tsbStart.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbStart.Image = global::DownLoad.MainIcon.button_start_32;
			this.tsbStart.ImagePaddingHorizontal = 8;
			this.tsbStart.Name = "tsbStart";
			this.tsbStart.Text = "开始";
			this.tsbStart.Click += new System.EventHandler(this.TsbStartClick);
			// 
			// tsbStop
			// 
			this.tsbStop.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbStop.Image = global::DownLoad.MainIcon.button_stop_32;
			this.tsbStop.ImagePaddingHorizontal = 8;
			this.tsbStop.Name = "tsbStop";
			this.tsbStop.Text = "停止";
			this.tsbStop.Click += new System.EventHandler(this.TsbStopClick);
			// 
			// tsbDelete
			// 
			this.tsbDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbDelete.Image = global::DownLoad.MainIcon.button_delete_32;
			this.tsbDelete.ImagePaddingHorizontal = 8;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Text = "删除";
			this.tsbDelete.Click += new System.EventHandler(this.TsbDeleteClick);
			// 
			// tsbOpen
			// 
			this.tsbOpen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbOpen.Image = global::DownLoad.MainIcon.button_open_32;
			this.tsbOpen.ImagePaddingHorizontal = 8;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Text = "打开";
			this.tsbOpen.Click += new System.EventHandler(this.TsbOpenClick);
			// 
			// tsbOptions
			// 
			this.tsbOptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
			this.tsbOptions.Image = global::DownLoad.MainIcon.button_options_32;
			this.tsbOptions.ImagePaddingHorizontal = 8;
			this.tsbOptions.Name = "tsbOptions";
			this.tsbOptions.Text = "设置";
			this.tsbOptions.Click += new System.EventHandler(this.TsbOptionsClick);
			// 
			// rightSplitter
			// 
			this.rightSplitter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.rightSplitter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.rightSplitter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.rightSplitter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rightSplitter.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.rightSplitter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.rightSplitter.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.rightSplitter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.rightSplitter.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.rightSplitter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.rightSplitter.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.rightSplitter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.rightSplitter.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
			this.rightSplitter.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
			this.rightSplitter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
			this.rightSplitter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
			this.rightSplitter.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.rightSplitter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.rightSplitter.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.rightSplitter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.rightSplitter.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.rightSplitter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.rightSplitter.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.rightSplitter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.rightSplitter.Location = new System.Drawing.Point(0, 0);
			this.rightSplitter.Name = "rightSplitter";
			this.rightSplitter.Size = new System.Drawing.Size(4, 610);
			this.rightSplitter.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.rightSplitter.TabIndex = 21;
			this.rightSplitter.TabStop = false;
			this.rightSplitter.Click += new System.EventHandler(this.RightSplitterClick);
			// 
			// expandablePanel1
			// 
			this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.expandablePanel1.ColorScheme.ItemDesignTimeBorder = System.Drawing.Color.Black;
			this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.expandablePanel1.Controls.Add(this.labelX7);
			this.expandablePanel1.Controls.Add(this.labelX6);
			this.expandablePanel1.Controls.Add(this.labelX5);
			this.expandablePanel1.Controls.Add(this.labelX4);
			this.expandablePanel1.Controls.Add(this.labelX3);
			this.expandablePanel1.Controls.Add(this.labelX2);
			this.expandablePanel1.Controls.Add(this.labelX1);
			this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.expandablePanel1.Location = new System.Drawing.Point(2, 0);
			this.expandablePanel1.Margin = new System.Windows.Forms.Padding(0);
			this.expandablePanel1.Name = "expandablePanel1";
			this.expandablePanel1.Size = new System.Drawing.Size(225, 610);
			this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandablePanel1.Style.GradientAngle = 90;
			this.expandablePanel1.TabIndex = 20;
			this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
			this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expandablePanel1.TitleStyle.GradientAngle = 90;
			this.expandablePanel1.TitleText = "属性信息";
			// 
			// labelX7
			// 
			this.labelX7.Location = new System.Drawing.Point(4, 211);
			this.labelX7.Name = "labelX7";
			this.labelX7.Size = new System.Drawing.Size(65, 23);
			this.labelX7.TabIndex = 7;
			this.labelX7.Text = "下载用时:";
			this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX6
			// 
			this.labelX6.Location = new System.Drawing.Point(4, 182);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(65, 23);
			this.labelX6.TabIndex = 6;
			this.labelX6.Text = "完成时间:";
			this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX5
			// 
			this.labelX5.Location = new System.Drawing.Point(4, 153);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(65, 23);
			this.labelX5.TabIndex = 5;
			this.labelX5.Text = "创建时间:";
			this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX4
			// 
			this.labelX4.Location = new System.Drawing.Point(4, 124);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(65, 23);
			this.labelX4.TabIndex = 4;
			this.labelX4.Text = "存储目录:";
			this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX3
			// 
			this.labelX3.Location = new System.Drawing.Point(4, 95);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(65, 23);
			this.labelX3.TabIndex = 3;
			this.labelX3.Text = "文件大小:";
			this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX2
			// 
			this.labelX2.Location = new System.Drawing.Point(4, 66);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(65, 23);
			this.labelX2.TabIndex = 2;
			this.labelX2.Text = "下载状态:";
			this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX1
			// 
			this.labelX1.Location = new System.Drawing.Point(3, 36);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(65, 23);
			this.labelX1.TabIndex = 1;
			this.labelX1.Text = "文件名称:";
			this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// DownLoadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1010, 660);
			this.Controls.Add(this.splitContainerLeft);
			this.Controls.Add(this.barStatusMain);
			this.Controls.Add(this.dockSite1);
			this.Controls.Add(this.dockSite2);
			this.Controls.Add(this.dockSite3);
			this.Controls.Add(this.dockSite4);
			this.Controls.Add(this.dockSite5);
			this.Controls.Add(this.dockSite6);
			this.Controls.Add(this.dockSite7);
			this.Controls.Add(this.dockSite8);
			this.Icon = global::DownLoad.MainIcon.notify_32;
			this.MinimumSize = new System.Drawing.Size(900, 500);
			this.Name = "DownLoadForm";
			this.Text = "下载";
			this.Load += new System.EventHandler(this.DownLoadFormLoad);
			this.SizeChanged += new System.EventHandler(this.DownLoadFormSizeChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownLoadFormFormClosing);
			this.Resize += new System.EventHandler(this.DownLoadFormResize);
			this.dockSite7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barStatusMain)).EndInit();
			this.splitContainerLeft.Panel2.ResumeLayout(false);
			this.splitContainerLeft.ResumeLayout(false);
			this.splitContainerRight.Panel1.ResumeLayout(false);
			this.splitContainerRight.Panel2.ResumeLayout(false);
			this.splitContainerRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
			this.expandablePanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private DevComponents.DotNetBar.ButtonItem btnDownLoadSpeed;
		private DevComponents.DotNetBar.Bar barStatusMain;
		private System.Windows.Forms.SplitContainer splitContainerLeft;
		private System.Windows.Forms.SplitContainer splitContainerRight;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.LabelX labelX6;
		private DevComponents.DotNetBar.LabelX labelX7;
		private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
		private DevComponents.DotNetBar.ExpandableSplitter rightSplitter;
		private DevComponents.DotNetBar.ButtonItem tsbOptions;
		private DevComponents.DotNetBar.ButtonItem tsbOpen;
		private DevComponents.DotNetBar.ButtonItem tsbDelete;
		private DevComponents.DotNetBar.ButtonItem tsbStop;
		private DevComponents.DotNetBar.ButtonItem tsbStart;
		private DevComponents.DotNetBar.ButtonItem tsbAdd;
		private DevComponents.DotNetBar.Bar bar2;
		private ExtendControl.EXListView lstViewMain;
		private DevComponents.DotNetBar.ButtonItem btnItemAbout;
		private DevComponents.DotNetBar.ButtonItem buttonItem19;
		private DevComponents.DotNetBar.ButtonItem buttonItem18;
		private DevComponents.DotNetBar.ButtonItem buttonItem17;
		private DevComponents.DotNetBar.ButtonItem buttonItem16;
		private DevComponents.DotNetBar.ButtonItem buttonItem13;
		private DevComponents.DotNetBar.ButtonItem buttonItem15;
		private DevComponents.DotNetBar.ButtonItem buttonItem12;
		private DevComponents.DotNetBar.ButtonItem buttonItem11;
		private DevComponents.DotNetBar.ButtonItem buttonItem10;
		private DevComponents.DotNetBar.ButtonItem buttonItem9;
		private DevComponents.DotNetBar.ButtonItem buttonItem8;
		private DevComponents.DotNetBar.ButtonItem buttonItem7;
		private DevComponents.DotNetBar.ButtonItem buttonItem5;
		private DevComponents.DotNetBar.DockSite dockSite8;
		private DevComponents.DotNetBar.ButtonItem buttonItem6;
		private DevComponents.DotNetBar.Bar bar3;
		private DevComponents.DotNetBar.DockSite dockSite7;
		private DevComponents.DotNetBar.DockSite dockSite6;
		private DevComponents.DotNetBar.DockSite dockSite5;
		private DevComponents.DotNetBar.DockSite dockSite3;
		private DevComponents.DotNetBar.DockSite dockSite2;
		private DevComponents.DotNetBar.DockSite dockSite1;
		private DevComponents.DotNetBar.DockSite dockSite4;
		private DevComponents.DotNetBar.DotNetBarManager mainBarManager;
		private System.Windows.Forms.NotifyIcon mainNotifyIcon;
		private DevComponents.DotNetBar.ButtonItem buttonItem4;
	}
}
