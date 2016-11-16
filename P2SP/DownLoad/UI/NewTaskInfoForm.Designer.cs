/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-17
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class NewTaskInfoForm
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
			this.pboxFileIcon = new System.Windows.Forms.PictureBox();
			this.nudNumThread = new System.Windows.Forms.NumericUpDown();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.scExTop = new System.Windows.Forms.SplitContainer();
			this.spliterTop = new DevComponents.DotNetBar.ExpandableSplitter();
			this.lblSize = new DevComponents.DotNetBar.LabelX();
			this.lblError = new DevComponents.DotNetBar.LabelX();
			this.btnSelect = new DevComponents.DotNetBar.ButtonX();
			this.txtSaveDir = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.lblUrl = new DevComponents.DotNetBar.LabelX();
			this.lblName = new DevComponents.DotNetBar.LabelX();
			this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.txtUrl = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.txtPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.spBtnDownLoad = new DevComponents.DotNetBar.ButtonX();
			this.btnManual = new DevComponents.DotNetBar.ButtonItem();
			this.btnCancel = new DevComponents.DotNetBar.ButtonX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			((System.ComponentModel.ISupportInitialize)(this.pboxFileIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudNumThread)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.scExTop.Panel1.SuspendLayout();
			this.scExTop.Panel2.SuspendLayout();
			this.scExTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// pboxFileIcon
			// 
			this.pboxFileIcon.Location = new System.Drawing.Point(13, 32);
			this.pboxFileIcon.Name = "pboxFileIcon";
			this.pboxFileIcon.Size = new System.Drawing.Size(50, 47);
			this.pboxFileIcon.TabIndex = 37;
			this.pboxFileIcon.TabStop = false;
			// 
			// nudNumThread
			// 
			this.nudNumThread.Location = new System.Drawing.Point(110, 146);
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
			this.nudNumThread.Size = new System.Drawing.Size(57, 21);
			this.nudNumThread.TabIndex = 35;
			this.nudNumThread.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.scExTop);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.spBtnDownLoad);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
			this.splitContainer1.Size = new System.Drawing.Size(352, 367);
			this.splitContainer1.SplitterDistance = 324;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 45;
			// 
			// scExTop
			// 
			this.scExTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scExTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.scExTop.IsSplitterFixed = true;
			this.scExTop.Location = new System.Drawing.Point(0, 0);
			this.scExTop.Name = "scExTop";
			this.scExTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scExTop.Panel1
			// 
			this.scExTop.Panel1.Controls.Add(this.labelX4);
			this.scExTop.Panel1.Controls.Add(this.spliterTop);
			this.scExTop.Panel1.Controls.Add(this.lblSize);
			this.scExTop.Panel1.Controls.Add(this.lblError);
			this.scExTop.Panel1.Controls.Add(this.btnSelect);
			this.scExTop.Panel1.Controls.Add(this.txtSaveDir);
			this.scExTop.Panel1.Controls.Add(this.lblUrl);
			this.scExTop.Panel1.Controls.Add(this.lblName);
			this.scExTop.Panel1.Controls.Add(this.pboxFileIcon);
			this.scExTop.Panel1.Controls.Add(this.txtName);
			this.scExTop.Panel1.Controls.Add(this.txtUrl);
			// 
			// scExTop.Panel2
			// 
			this.scExTop.Panel2.Controls.Add(this.txtUserName);
			this.scExTop.Panel2.Controls.Add(this.textBoxX1);
			this.scExTop.Panel2.Controls.Add(this.txtPassWord);
			this.scExTop.Panel2.Controls.Add(this.checkBoxX3);
			this.scExTop.Panel2.Controls.Add(this.checkBoxX2);
			this.scExTop.Panel2.Controls.Add(this.labelX3);
			this.scExTop.Panel2.Controls.Add(this.labelX2);
			this.scExTop.Panel2.Controls.Add(this.nudNumThread);
			this.scExTop.Panel2.Controls.Add(this.labelX1);
			this.scExTop.Panel2.Controls.Add(this.checkBoxX1);
			this.scExTop.Size = new System.Drawing.Size(352, 324);
			this.scExTop.SplitterDistance = 139;
			this.scExTop.TabIndex = 0;
			// 
			// spliterTop
			// 
			this.spliterTop.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.spliterTop.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.spliterTop.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.spliterTop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.spliterTop.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spliterTop.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.spliterTop.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.spliterTop.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.spliterTop.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.spliterTop.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.spliterTop.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.spliterTop.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.spliterTop.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.spliterTop.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
			this.spliterTop.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
			this.spliterTop.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
			this.spliterTop.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
			this.spliterTop.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.spliterTop.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.spliterTop.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.spliterTop.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.spliterTop.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
			this.spliterTop.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.spliterTop.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.spliterTop.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.spliterTop.Location = new System.Drawing.Point(0, 135);
			this.spliterTop.Name = "spliterTop";
			this.spliterTop.Size = new System.Drawing.Size(352, 4);
			this.spliterTop.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
			this.spliterTop.TabIndex = 45;
			this.spliterTop.TabStop = false;
			this.spliterTop.Click += new System.EventHandler(this.SpliterTopClick);
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(67, 59);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(160, 23);
			this.lblSize.TabIndex = 44;
			// 
			// lblError
			// 
			this.lblError.Location = new System.Drawing.Point(13, 108);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(327, 23);
			this.lblError.TabIndex = 43;
			this.lblError.TextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// btnSelect
			// 
			this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSelect.Location = new System.Drawing.Point(276, 83);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(62, 21);
			this.btnSelect.TabIndex = 42;
			this.btnSelect.Text = "...";
			this.btnSelect.Click += new System.EventHandler(this.BtnSelectClick);
			// 
			// txtSaveDir
			// 
			// 
			// 
			// 
			this.txtSaveDir.Border.Class = "TextBoxBorder";
			this.txtSaveDir.Location = new System.Drawing.Point(11, 83);
			this.txtSaveDir.Name = "txtSaveDir";
			this.txtSaveDir.Size = new System.Drawing.Size(259, 21);
			this.txtSaveDir.TabIndex = 40;
			this.txtSaveDir.TextChanged += new System.EventHandler(this.TxtSaveDirTextChanged);
			// 
			// lblUrl
			// 
			this.lblUrl.Location = new System.Drawing.Point(67, 6);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(271, 23);
			this.lblUrl.TabIndex = 38;
			this.lblUrl.Click += new System.EventHandler(this.LblUrlClick);
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(67, 33);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(271, 23);
			this.lblName.TabIndex = 0;
			this.lblName.Click += new System.EventHandler(this.LblNameClick);
			// 
			// txtName
			// 
			// 
			// 
			// 
			this.txtName.Border.Class = "TextBoxBorder";
			this.txtName.Location = new System.Drawing.Point(67, 35);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(271, 21);
			this.txtName.TabIndex = 39;
			this.txtName.Visible = false;
			this.txtName.Leave += new System.EventHandler(this.TxtNameLeave);
			// 
			// txtUrl
			// 
			// 
			// 
			// 
			this.txtUrl.Border.Class = "TextBoxBorder";
			this.txtUrl.Location = new System.Drawing.Point(67, 6);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(271, 21);
			this.txtUrl.TabIndex = 41;
			this.txtUrl.Visible = false;
			this.txtUrl.Leave += new System.EventHandler(this.TxtUrlLeave);
			// 
			// txtUserName
			// 
			// 
			// 
			// 
			this.txtUserName.Border.Class = "TextBoxBorder";
			this.txtUserName.Location = new System.Drawing.Point(67, 32);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(100, 21);
			this.txtUserName.TabIndex = 36;
			// 
			// textBoxX1
			// 
			// 
			// 
			// 
			this.textBoxX1.Border.Class = "TextBoxBorder";
			this.textBoxX1.Location = new System.Drawing.Point(173, 10);
			this.textBoxX1.Name = "textBoxX1";
			this.textBoxX1.Size = new System.Drawing.Size(174, 157);
			this.textBoxX1.TabIndex = 8;
			// 
			// txtPassWord
			// 
			// 
			// 
			// 
			this.txtPassWord.Border.Class = "TextBoxBorder";
			this.txtPassWord.Location = new System.Drawing.Point(67, 59);
			this.txtPassWord.Name = "txtPassWord";
			this.txtPassWord.PasswordChar = '*';
			this.txtPassWord.Size = new System.Drawing.Size(100, 21);
			this.txtPassWord.TabIndex = 7;
			// 
			// checkBoxX3
			// 
			this.checkBoxX3.Location = new System.Drawing.Point(13, 117);
			this.checkBoxX3.Name = "checkBoxX3";
			this.checkBoxX3.Size = new System.Drawing.Size(138, 23);
			this.checkBoxX3.TabIndex = 5;
			this.checkBoxX3.Text = "只从原始地址下载";
			// 
			// checkBoxX2
			// 
			this.checkBoxX2.Location = new System.Drawing.Point(13, 88);
			this.checkBoxX2.Name = "checkBoxX2";
			this.checkBoxX2.Size = new System.Drawing.Size(138, 23);
			this.checkBoxX2.TabIndex = 4;
			this.checkBoxX2.Text = "下载完成后自动运行";
			// 
			// labelX3
			// 
			this.labelX3.Location = new System.Drawing.Point(13, 146);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(91, 23);
			this.labelX3.TabIndex = 3;
			this.labelX3.Text = "原始地址线程数";
			this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX2
			// 
			this.labelX2.Location = new System.Drawing.Point(21, 61);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(40, 23);
			this.labelX2.TabIndex = 2;
			this.labelX2.Text = "密码:";
			this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// labelX1
			// 
			this.labelX1.Location = new System.Drawing.Point(13, 32);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(48, 23);
			this.labelX1.TabIndex = 1;
			this.labelX1.Text = "用户名:";
			this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// checkBoxX1
			// 
			this.checkBoxX1.Location = new System.Drawing.Point(13, 6);
			this.checkBoxX1.Name = "checkBoxX1";
			this.checkBoxX1.Size = new System.Drawing.Size(85, 23);
			this.checkBoxX1.TabIndex = 0;
			this.checkBoxX1.Text = "登录服务器";
			// 
			// spBtnDownLoad
			// 
			this.spBtnDownLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.spBtnDownLoad.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.spBtnDownLoad.Location = new System.Drawing.Point(184, 10);
			this.spBtnDownLoad.Name = "spBtnDownLoad";
			this.spBtnDownLoad.Size = new System.Drawing.Size(75, 23);
			this.spBtnDownLoad.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.btnManual});
			this.spBtnDownLoad.TabIndex = 47;
			this.spBtnDownLoad.Text = "立即下载";
			this.spBtnDownLoad.Click += new System.EventHandler(this.SpBtnDownLoadClick);
			// 
			// btnManual
			// 
			this.btnManual.GlobalItem = false;
			this.btnManual.ImagePaddingHorizontal = 8;
			this.btnManual.Name = "btnManual";
			this.btnManual.Text = "手动下载";
			this.btnManual.Click += new System.EventHandler(this.BtnManualClick);
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.Location = new System.Drawing.Point(265, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 46;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// labelX4
			// 
			this.labelX4.Location = new System.Drawing.Point(13, 6);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(50, 23);
			this.labelX4.TabIndex = 46;
			this.labelX4.Text = "Url:";
			this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// NewTaskInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(352, 367);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewTaskInfoForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "新建任务";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.NewTaskInfoFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewTaskInfoFormFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pboxFileIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudNumThread)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.scExTop.Panel1.ResumeLayout(false);
			this.scExTop.Panel2.ResumeLayout(false);
			this.scExTop.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.ExpandableSplitter spliterTop;
		private DevComponents.DotNetBar.LabelX lblError;
		private System.Windows.Forms.SplitContainer scExTop;
		private DevComponents.DotNetBar.Controls.TextBoxX txtUrl;
		private DevComponents.DotNetBar.LabelX lblUrl;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
		private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
		private DevComponents.DotNetBar.ButtonItem btnManual;
		private DevComponents.DotNetBar.ButtonX btnCancel;
		private DevComponents.DotNetBar.ButtonX spBtnDownLoad;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.NumericUpDown nudNumThread;
		private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
		private DevComponents.DotNetBar.Controls.TextBoxX txtPassWord;
		private DevComponents.DotNetBar.Controls.TextBoxX txtName;
		private DevComponents.DotNetBar.Controls.TextBoxX txtSaveDir;
		private System.Windows.Forms.PictureBox pboxFileIcon;
		private DevComponents.DotNetBar.LabelX lblName;
		private DevComponents.DotNetBar.LabelX lblSize;
		private DevComponents.DotNetBar.ButtonX btnSelect;
	}
}
