/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-14
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class ConfigForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
			this.txtFileExt = new System.Windows.Forms.TextBox();
			this.nudNumThread = new System.Windows.Forms.NumericUpDown();
			this.nudMaxTasks = new System.Windows.Forms.NumericUpDown();
			this.nudMaxConnection = new System.Windows.Forms.NumericUpDown();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new DevComponents.DotNetBar.TabControl();
			this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
			this.cmboxTaskStartType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.comboItem1 = new DevComponents.Editors.ComboItem();
			this.comboItem2 = new DevComponents.Editors.ComboItem();
			this.btnSelect = new DevComponents.DotNetBar.ButtonX();
			this.txtSaveDir = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
			this.btnOk = new DevComponents.DotNetBar.ButtonX();
			this.btnApply = new DevComponents.DotNetBar.ButtonX();
			this.btnCancel = new DevComponents.DotNetBar.ButtonX();
			((System.ComponentModel.ISupportInitialize)(this.nudNumThread)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTasks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxConnection)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabControlPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtFileExt
			// 
			this.txtFileExt.Location = new System.Drawing.Point(178, 162);
			this.txtFileExt.Multiline = true;
			this.txtFileExt.Name = "txtFileExt";
			this.txtFileExt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtFileExt.Size = new System.Drawing.Size(199, 135);
			this.txtFileExt.TabIndex = 9;
			this.txtFileExt.Text = resources.GetString("txtFileExt.Text");
			// 
			// nudNumThread
			// 
			this.nudNumThread.Location = new System.Drawing.Point(178, 47);
			this.nudNumThread.Maximum = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.nudNumThread.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudNumThread.Name = "nudNumThread";
			this.nudNumThread.Size = new System.Drawing.Size(199, 21);
			this.nudNumThread.TabIndex = 0;
			this.nudNumThread.Value = new decimal(new int[] {
									5,
									0,
									0,
									0});
			this.nudNumThread.ValueChanged += new System.EventHandler(this.NudNumThreadValueChanged);
			// 
			// nudMaxTasks
			// 
			this.nudMaxTasks.Location = new System.Drawing.Point(178, 106);
			this.nudMaxTasks.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudMaxTasks.Name = "nudMaxTasks";
			this.nudMaxTasks.Size = new System.Drawing.Size(199, 21);
			this.nudMaxTasks.TabIndex = 0;
			this.nudMaxTasks.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.nudMaxTasks.ValueChanged += new System.EventHandler(this.NudMaxTasksValueChanged);
			// 
			// nudMaxConnection
			// 
			this.nudMaxConnection.Location = new System.Drawing.Point(178, 76);
			this.nudMaxConnection.Maximum = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			this.nudMaxConnection.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudMaxConnection.Name = "nudMaxConnection";
			this.nudMaxConnection.Size = new System.Drawing.Size(199, 21);
			this.nudMaxConnection.TabIndex = 0;
			this.nudMaxConnection.Value = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.nudMaxConnection.ValueChanged += new System.EventHandler(this.NudMaxConnectionValueChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnOk);
			this.splitContainer1.Panel2.Controls.Add(this.btnApply);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
			this.splitContainer1.Size = new System.Drawing.Size(425, 389);
			this.splitContainer1.SplitterDistance = 338;
			this.splitContainer1.TabIndex = 3;
			// 
			// tabControl1
			// 
			this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
			this.tabControl1.CanReorderTabs = true;
			this.tabControl1.Controls.Add(this.tabControlPanel1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
			this.tabControl1.SelectedTabIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(425, 338);
			this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
			this.tabControl1.Tabs.Add(this.tabItem1);
			this.tabControl1.TabsVisible = false;
			this.tabControl1.Text = "tabControl1";
			this.tabControl1.ThemeAware = true;
			// 
			// tabControlPanel1
			// 
			this.tabControlPanel1.Controls.Add(this.cmboxTaskStartType);
			this.tabControlPanel1.Controls.Add(this.btnSelect);
			this.tabControlPanel1.Controls.Add(this.txtFileExt);
			this.tabControlPanel1.Controls.Add(this.txtSaveDir);
			this.tabControlPanel1.Controls.Add(this.labelX6);
			this.tabControlPanel1.Controls.Add(this.labelX5);
			this.tabControlPanel1.Controls.Add(this.labelX4);
			this.tabControlPanel1.Controls.Add(this.labelX3);
			this.tabControlPanel1.Controls.Add(this.labelX2);
			this.tabControlPanel1.Controls.Add(this.nudMaxTasks);
			this.tabControlPanel1.Controls.Add(this.nudNumThread);
			this.tabControlPanel1.Controls.Add(this.labelX1);
			this.tabControlPanel1.Controls.Add(this.nudMaxConnection);
			this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
			this.tabControlPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tabControlPanel1.Name = "tabControlPanel1";
			this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel1.Size = new System.Drawing.Size(425, 313);
			this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
			this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
			this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
			this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
									| DevComponents.DotNetBar.eBorderSide.Bottom)));
			this.tabControlPanel1.Style.GradientAngle = 90;
			this.tabControlPanel1.TabIndex = 1;
			this.tabControlPanel1.TabItem = this.tabItem1;
			// 
			// cmboxTaskStartType
			// 
			this.cmboxTaskStartType.DisplayMember = "Text";
			this.cmboxTaskStartType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmboxTaskStartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmboxTaskStartType.FormattingEnabled = true;
			this.cmboxTaskStartType.Items.AddRange(new object[] {
									this.comboItem1,
									this.comboItem2});
			this.cmboxTaskStartType.Location = new System.Drawing.Point(178, 134);
			this.cmboxTaskStartType.Name = "cmboxTaskStartType";
			this.cmboxTaskStartType.Size = new System.Drawing.Size(199, 22);
			this.cmboxTaskStartType.TabIndex = 4;
			this.cmboxTaskStartType.SelectedIndexChanged += new System.EventHandler(this.CmboxTaskStartTypeSelectedIndexChanged);
			// 
			// comboItem1
			// 
			this.comboItem1.Text = "立即下载";
			// 
			// comboItem2
			// 
			this.comboItem2.Text = "手动下载";
			// 
			// btnSelect
			// 
			this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSelect.Location = new System.Drawing.Point(383, 16);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(32, 20);
			this.btnSelect.TabIndex = 10;
			this.btnSelect.Text = "...";
			this.btnSelect.Click += new System.EventHandler(this.BtnSelectClick);
			// 
			// txtSaveDir
			// 
			// 
			// 
			// 
			this.txtSaveDir.Border.Class = "TextBoxBorder";
			this.txtSaveDir.Location = new System.Drawing.Point(178, 16);
			this.txtSaveDir.Name = "txtSaveDir";
			this.txtSaveDir.Size = new System.Drawing.Size(199, 21);
			this.txtSaveDir.TabIndex = 6;
			// 
			// labelX6
			// 
			this.labelX6.BackColor = System.Drawing.Color.Transparent;
			this.labelX6.Location = new System.Drawing.Point(13, 162);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(159, 23);
			this.labelX6.TabIndex = 5;
			this.labelX6.Text = "监视文件类型";
			this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX5
			// 
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			this.labelX5.Location = new System.Drawing.Point(13, 133);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(159, 23);
			this.labelX5.TabIndex = 4;
			this.labelX5.Text = "任务启动方式";
			this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX4
			// 
			this.labelX4.BackColor = System.Drawing.Color.Transparent;
			this.labelX4.Location = new System.Drawing.Point(13, 104);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(159, 23);
			this.labelX4.TabIndex = 3;
			this.labelX4.Text = "同时最多启动任务数(1-100)";
			this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX3
			// 
			this.labelX3.BackColor = System.Drawing.Color.Transparent;
			this.labelX3.Location = new System.Drawing.Point(13, 74);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(159, 23);
			this.labelX3.TabIndex = 2;
			this.labelX3.Text = "全局最大连接数(1-1000)";
			this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX2
			// 
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
			this.labelX2.Location = new System.Drawing.Point(13, 45);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(159, 23);
			this.labelX2.TabIndex = 1;
			this.labelX2.Text = "原始地址下载线程数(1-10)";
			this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX1
			// 
			this.labelX1.BackColor = System.Drawing.Color.Transparent;
			this.labelX1.Location = new System.Drawing.Point(13, 16);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(159, 23);
			this.labelX1.TabIndex = 0;
			this.labelX1.Text = "文件保存目录";
			this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// tabItem1
			// 
			this.tabItem1.AttachedControl = this.tabControlPanel1;
			this.tabItem1.Name = "tabItem1";
			this.tabItem1.Text = "基本设置";
			// 
			// btnOk
			// 
			this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOk.Location = new System.Drawing.Point(178, 10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "确定(&O)";
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnApply
			// 
			this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnApply.Location = new System.Drawing.Point(340, 10);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "应用(&A)";
			this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.Location = new System.Drawing.Point(259, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(423, 387);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(431, 414);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(431, 414);
			this.Name = "ConfigForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "配置";
			this.Load += new System.EventHandler(this.ConfigFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigFormFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.nudNumThread)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxTasks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxConnection)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabControlPanel1.ResumeLayout(false);
			this.tabControlPanel1.PerformLayout();
			this.ResumeLayout(false);
		}
		private DevComponents.Editors.ComboItem comboItem2;
		private DevComponents.Editors.ComboItem comboItem1;
		private DevComponents.DotNetBar.TabItem tabItem1;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.LabelX labelX6;
		private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
		private DevComponents.DotNetBar.TabControl tabControl1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private DevComponents.DotNetBar.ButtonX btnOk;
		private DevComponents.DotNetBar.ButtonX btnApply;
		private DevComponents.DotNetBar.ButtonX btnCancel;
		private System.Windows.Forms.NumericUpDown nudMaxConnection;
		private System.Windows.Forms.NumericUpDown nudMaxTasks;
		private System.Windows.Forms.NumericUpDown nudNumThread;
		private DevComponents.DotNetBar.ButtonX btnSelect;
		private DevComponents.DotNetBar.Controls.TextBoxX txtSaveDir;
		private DevComponents.DotNetBar.Controls.ComboBoxEx cmboxTaskStartType;
		private System.Windows.Forms.TextBox txtFileExt;
	}
}
