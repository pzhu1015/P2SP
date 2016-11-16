/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-13
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class SystemSettingForm
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
			this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtShowMsgKey = new CCWin.SkinControl.SkinTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbtnEnter = new CCWin.SkinControl.SkinRadioButton();
			this.rbtnCtrlEnter = new CCWin.SkinControl.SkinRadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnOpenRecveDir = new CCWin.SkinControl.SkinButtom();
			this.btnChangeRecveDir = new CCWin.SkinControl.SkinButtom();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRecveDir = new CCWin.SkinControl.SkinTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtScreenCaptureKey = new CCWin.SkinControl.SkinTextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
			this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
			this.skinTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// skinTabControl1
			// 
			this.skinTabControl1.BaseColor = System.Drawing.Color.White;
			this.skinTabControl1.BorderColor = System.Drawing.Color.White;
			this.skinTabControl1.Controls.Add(this.tabPage1);
			this.skinTabControl1.Controls.Add(this.tabPage2);
			this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
			this.skinTabControl1.Location = new System.Drawing.Point(1, 24);
			this.skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.skinTabControl1.Name = "skinTabControl1";
			this.skinTabControl1.Padding = new System.Drawing.Point(0, 0);
			this.skinTabControl1.PageColor = System.Drawing.Color.White;
			this.skinTabControl1.SelectedIndex = 0;
			this.skinTabControl1.Size = new System.Drawing.Size(585, 362);
			this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.skinTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(577, 318);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "基本设置";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtShowMsgKey);
			this.groupBox4.Location = new System.Drawing.Point(13, 72);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(556, 59);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "提取消息:";
			// 
			// txtShowMsgKey
			// 
			this.txtShowMsgKey.BackColor = System.Drawing.Color.Transparent;
			this.txtShowMsgKey.Icon = null;
			this.txtShowMsgKey.IconIsButton = false;
			this.txtShowMsgKey.IsPasswordChat = '\0';
			this.txtShowMsgKey.IsSystemPasswordChar = false;
			this.txtShowMsgKey.Lines = new string[0];
			this.txtShowMsgKey.Location = new System.Drawing.Point(15, 17);
			this.txtShowMsgKey.Margin = new System.Windows.Forms.Padding(0);
			this.txtShowMsgKey.MaxLength = 32767;
			this.txtShowMsgKey.MinimumSize = new System.Drawing.Size(0, 28);
			this.txtShowMsgKey.MouseBack = null;
			this.txtShowMsgKey.Multiline = false;
			this.txtShowMsgKey.Name = "txtShowMsgKey";
			this.txtShowMsgKey.NormlBack = null;
			this.txtShowMsgKey.Padding = new System.Windows.Forms.Padding(5);
			this.txtShowMsgKey.ReadOnly = true;
			this.txtShowMsgKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtShowMsgKey.Size = new System.Drawing.Size(319, 28);
			this.txtShowMsgKey.TabIndex = 6;
			this.txtShowMsgKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtShowMsgKey.WaterColor = System.Drawing.Color.DarkGray;
			this.txtShowMsgKey.WaterText = "";
			this.txtShowMsgKey.WordWrap = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbtnEnter);
			this.groupBox3.Controls.Add(this.rbtnCtrlEnter);
			this.groupBox3.Location = new System.Drawing.Point(13, 137);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(556, 78);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "发送消息: ";
			// 
			// rbtnEnter
			// 
			this.rbtnEnter.AutoSize = true;
			this.rbtnEnter.BackColor = System.Drawing.Color.Transparent;
			this.rbtnEnter.Checked = true;
			this.rbtnEnter.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.rbtnEnter.DownBack = null;
			this.rbtnEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rbtnEnter.LightEffect = false;
			this.rbtnEnter.Location = new System.Drawing.Point(15, 47);
			this.rbtnEnter.MouseBack = null;
			this.rbtnEnter.Name = "rbtnEnter";
			this.rbtnEnter.NormlBack = null;
			this.rbtnEnter.SelectedDownBack = null;
			this.rbtnEnter.SelectedMouseBack = null;
			this.rbtnEnter.SelectedNormlBack = null;
			this.rbtnEnter.Size = new System.Drawing.Size(80, 21);
			this.rbtnEnter.TabIndex = 2;
			this.rbtnEnter.TabStop = true;
			this.rbtnEnter.Text = "按Enter键";
			this.rbtnEnter.UseVisualStyleBackColor = true;
			this.rbtnEnter.Click += new System.EventHandler(this.RbtnEnterClick);
			// 
			// rbtnCtrlEnter
			// 
			this.rbtnCtrlEnter.AutoSize = true;
			this.rbtnCtrlEnter.BackColor = System.Drawing.Color.Transparent;
			this.rbtnCtrlEnter.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.rbtnCtrlEnter.DownBack = null;
			this.rbtnCtrlEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rbtnCtrlEnter.LightEffect = false;
			this.rbtnCtrlEnter.Location = new System.Drawing.Point(15, 20);
			this.rbtnCtrlEnter.MouseBack = null;
			this.rbtnCtrlEnter.Name = "rbtnCtrlEnter";
			this.rbtnCtrlEnter.NormlBack = null;
			this.rbtnCtrlEnter.SelectedDownBack = null;
			this.rbtnCtrlEnter.SelectedMouseBack = null;
			this.rbtnCtrlEnter.SelectedNormlBack = null;
			this.rbtnCtrlEnter.Size = new System.Drawing.Size(109, 21);
			this.rbtnCtrlEnter.TabIndex = 0;
			this.rbtnCtrlEnter.Text = "按Ctrl+Enter键";
			this.rbtnCtrlEnter.UseVisualStyleBackColor = true;
			this.rbtnCtrlEnter.Click += new System.EventHandler(this.RbtnCtrlEnterClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnOpenRecveDir);
			this.groupBox2.Controls.Add(this.btnChangeRecveDir);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtRecveDir);
			this.groupBox2.Location = new System.Drawing.Point(13, 221);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(556, 79);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "文件管理: ";
			// 
			// btnOpenRecveDir
			// 
			this.btnOpenRecveDir.BackColor = System.Drawing.Color.Transparent;
			this.btnOpenRecveDir.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnOpenRecveDir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOpenRecveDir.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
			this.btnOpenRecveDir.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnOpenRecveDir.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOpenRecveDir.Location = new System.Drawing.Point(481, 41);
			this.btnOpenRecveDir.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
			this.btnOpenRecveDir.Name = "btnOpenRecveDir";
			this.btnOpenRecveDir.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
			this.btnOpenRecveDir.Size = new System.Drawing.Size(69, 24);
			this.btnOpenRecveDir.TabIndex = 133;
			this.btnOpenRecveDir.Text = "打开文件夹";
			this.btnOpenRecveDir.UseVisualStyleBackColor = false;
			this.btnOpenRecveDir.Click += new System.EventHandler(this.BtnOpenRecveDirClick);
			// 
			// btnChangeRecveDir
			// 
			this.btnChangeRecveDir.BackColor = System.Drawing.Color.Transparent;
			this.btnChangeRecveDir.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnChangeRecveDir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChangeRecveDir.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
			this.btnChangeRecveDir.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnChangeRecveDir.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnChangeRecveDir.Location = new System.Drawing.Point(406, 41);
			this.btnChangeRecveDir.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
			this.btnChangeRecveDir.Name = "btnChangeRecveDir";
			this.btnChangeRecveDir.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
			this.btnChangeRecveDir.Size = new System.Drawing.Size(69, 24);
			this.btnChangeRecveDir.TabIndex = 132;
			this.btnChangeRecveDir.Text = "更改目录";
			this.btnChangeRecveDir.UseVisualStyleBackColor = false;
			this.btnChangeRecveDir.Click += new System.EventHandler(this.BtnChangeRecveDirClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(185, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "默认把接收到的文件保存到此目录";
			// 
			// txtRecveDir
			// 
			this.txtRecveDir.BackColor = System.Drawing.Color.Transparent;
			this.txtRecveDir.Icon = null;
			this.txtRecveDir.IconIsButton = false;
			this.txtRecveDir.IsPasswordChat = '\0';
			this.txtRecveDir.IsSystemPasswordChar = false;
			this.txtRecveDir.Lines = new string[0];
			this.txtRecveDir.Location = new System.Drawing.Point(15, 39);
			this.txtRecveDir.Margin = new System.Windows.Forms.Padding(0);
			this.txtRecveDir.MaxLength = 32767;
			this.txtRecveDir.MinimumSize = new System.Drawing.Size(0, 28);
			this.txtRecveDir.MouseBack = null;
			this.txtRecveDir.Multiline = false;
			this.txtRecveDir.Name = "txtRecveDir";
			this.txtRecveDir.NormlBack = null;
			this.txtRecveDir.Padding = new System.Windows.Forms.Padding(5);
			this.txtRecveDir.ReadOnly = true;
			this.txtRecveDir.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRecveDir.Size = new System.Drawing.Size(388, 28);
			this.txtRecveDir.TabIndex = 0;
			this.txtRecveDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtRecveDir.WaterColor = System.Drawing.Color.DarkGray;
			this.txtRecveDir.WaterText = "";
			this.txtRecveDir.WordWrap = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtScreenCaptureKey);
			this.groupBox1.Location = new System.Drawing.Point(13, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(556, 63);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "捕捉屏幕: ";
			// 
			// txtScreenCaptureKey
			// 
			this.txtScreenCaptureKey.BackColor = System.Drawing.Color.Transparent;
			this.txtScreenCaptureKey.Icon = null;
			this.txtScreenCaptureKey.IconIsButton = false;
			this.txtScreenCaptureKey.IsPasswordChat = '\0';
			this.txtScreenCaptureKey.IsSystemPasswordChar = false;
			this.txtScreenCaptureKey.Lines = new string[0];
			this.txtScreenCaptureKey.Location = new System.Drawing.Point(15, 17);
			this.txtScreenCaptureKey.Margin = new System.Windows.Forms.Padding(0);
			this.txtScreenCaptureKey.MaxLength = 32767;
			this.txtScreenCaptureKey.MinimumSize = new System.Drawing.Size(0, 28);
			this.txtScreenCaptureKey.MouseBack = null;
			this.txtScreenCaptureKey.Multiline = false;
			this.txtScreenCaptureKey.Name = "txtScreenCaptureKey";
			this.txtScreenCaptureKey.NormlBack = null;
			this.txtScreenCaptureKey.Padding = new System.Windows.Forms.Padding(5);
			this.txtScreenCaptureKey.ReadOnly = true;
			this.txtScreenCaptureKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtScreenCaptureKey.Size = new System.Drawing.Size(319, 28);
			this.txtScreenCaptureKey.TabIndex = 3;
			this.txtScreenCaptureKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtScreenCaptureKey.WaterColor = System.Drawing.Color.DarkGray;
			this.txtScreenCaptureKey.WaterText = "";
			this.txtScreenCaptureKey.WordWrap = true;
			this.txtScreenCaptureKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScreenCaptureKeyKeyDown);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.White;
			this.tabPage2.Location = new System.Drawing.Point(4, 40);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(577, 318);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "安全设置";
			// 
			// skinLabel2
			// 
			this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
			this.skinLabel2.BorderColor = System.Drawing.Color.White;
			this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.skinLabel2.Location = new System.Drawing.Point(189, 0);
			this.skinLabel2.Name = "skinLabel2";
			this.skinLabel2.Size = new System.Drawing.Size(8, 8);
			this.skinLabel2.TabIndex = 2;
			this.skinLabel2.Text = "skinLabel2";
			// 
			// skinLabel3
			// 
			this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Forme;
			this.skinLabel3.AutoSize = true;
			this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
			this.skinLabel3.BorderColor = System.Drawing.Color.White;
			this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.skinLabel3.Location = new System.Drawing.Point(31, 4);
			this.skinLabel3.Name = "skinLabel3";
			this.skinLabel3.Size = new System.Drawing.Size(56, 17);
			this.skinLabel3.TabIndex = 3;
			this.skinLabel3.Text = "系统设置";
			// 
			// SystemSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
			this.BorderWidth = 1;
			this.CanResize = false;
			this.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ClientSize = new System.Drawing.Size(587, 387);
			this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
			this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
			this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
			this.ControlBoxOffset = new System.Drawing.Point(1, 1);
			this.Controls.Add(this.skinLabel3);
			this.Controls.Add(this.skinLabel2);
			this.Controls.Add(this.skinTabControl1);
			this.EffectCaption = false;
			this.Icon = global::ChatClientUI.ResourceMainForm.logo_xp_16;
			this.MaximizeBox = false;
			this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
			this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
			this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
			this.Name = "SystemSettingForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "系统设置";
			this.Load += new System.EventHandler(this.SystemSettingFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SystemSettingFormFormClosing);
			this.skinTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CCWin.SkinControl.SkinRadioButton rbtnEnter;
		private CCWin.SkinControl.SkinRadioButton rbtnCtrlEnter;
		private CCWin.SkinControl.SkinLabel skinLabel3;
		private CCWin.SkinControl.SkinLabel skinLabel2;
		private CCWin.SkinControl.SkinTextBox txtShowMsgKey;
		private CCWin.SkinControl.SkinTextBox txtScreenCaptureKey;
		private CCWin.SkinControl.SkinButtom btnOpenRecveDir;
		private CCWin.SkinControl.SkinButtom btnChangeRecveDir;
		private CCWin.SkinControl.SkinTextBox txtRecveDir;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private CCWin.SkinControl.SkinTabControl skinTabControl1;
	}
}
