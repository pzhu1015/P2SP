/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-18
 * Time: 16:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class LoginSettingFrom
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
			this.btnOk = new CCWin.SkinControl.SkinButtom();
			this.btnCancel = new CCWin.SkinControl.SkinButtom();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
			this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
			this.txtTcpPort = new CCWin.SkinControl.SkinTextBox();
			this.txtServerIp = new CCWin.SkinControl.SkinTextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.BackColor = System.Drawing.Color.Transparent;
			this.btnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOk.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
			this.btnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOk.Location = new System.Drawing.Point(198, 7);
			this.btnOk.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
			this.btnOk.Name = "btnOk";
			this.btnOk.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
			this.btnOk.Size = new System.Drawing.Size(69, 24);
			this.btnOk.TabIndex = 133;
			this.btnOk.Text = "确定";
			this.btnOk.UseVisualStyleBackColor = false;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.DownBack = global::ChatClientUI.ResourceControl.btnDownBack;
			this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancel.Location = new System.Drawing.Point(302, 7);
			this.btnCancel.MouseBack = global::ChatClientUI.ResourceControl.btnMouseBack;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.NormlBack = global::ChatClientUI.ResourceControl.btnNormlBack;
			this.btnCancel.Size = new System.Drawing.Size(69, 24);
			this.btnCancel.TabIndex = 134;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(3, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.skinLabel3);
			this.splitContainer1.Panel1.Controls.Add(this.skinLabel1);
			this.splitContainer1.Panel1.Controls.Add(this.txtTcpPort);
			this.splitContainer1.Panel1.Controls.Add(this.txtServerIp);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.splitContainer1.Panel2.Controls.Add(this.btnOk);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
			this.splitContainer1.Size = new System.Drawing.Size(373, 265);
			this.splitContainer1.SplitterDistance = 231;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 135;
			// 
			// skinLabel3
			// 
			this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
			this.skinLabel3.AutoSize = true;
			this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
			this.skinLabel3.BorderColor = System.Drawing.Color.White;
			this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.skinLabel3.Location = new System.Drawing.Point(202, 110);
			this.skinLabel3.Name = "skinLabel3";
			this.skinLabel3.Size = new System.Drawing.Size(60, 17);
			this.skinLabel3.TabIndex = 4;
			this.skinLabel3.Text = "Tcp端口: ";
			// 
			// skinLabel1
			// 
			this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
			this.skinLabel1.AutoSize = true;
			this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
			this.skinLabel1.BorderColor = System.Drawing.Color.White;
			this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.skinLabel1.Location = new System.Drawing.Point(10, 109);
			this.skinLabel1.Name = "skinLabel1";
			this.skinLabel1.Size = new System.Drawing.Size(39, 17);
			this.skinLabel1.TabIndex = 2;
			this.skinLabel1.Text = "地址: ";
			// 
			// txtTcpPort
			// 
			this.txtTcpPort.BackColor = System.Drawing.Color.Transparent;
			this.txtTcpPort.Icon = null;
			this.txtTcpPort.IconIsButton = false;
			this.txtTcpPort.IsPasswordChat = '\0';
			this.txtTcpPort.IsSystemPasswordChar = false;
			this.txtTcpPort.Lines = new string[0];
			this.txtTcpPort.Location = new System.Drawing.Point(267, 104);
			this.txtTcpPort.Margin = new System.Windows.Forms.Padding(0);
			this.txtTcpPort.MaxLength = 32767;
			this.txtTcpPort.MinimumSize = new System.Drawing.Size(0, 28);
			this.txtTcpPort.MouseBack = null;
			this.txtTcpPort.Multiline = false;
			this.txtTcpPort.Name = "txtTcpPort";
			this.txtTcpPort.NormlBack = null;
			this.txtTcpPort.Padding = new System.Windows.Forms.Padding(5);
			this.txtTcpPort.ReadOnly = false;
			this.txtTcpPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTcpPort.Size = new System.Drawing.Size(88, 28);
			this.txtTcpPort.TabIndex = 1;
			this.txtTcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTcpPort.WaterColor = System.Drawing.Color.DarkGray;
			this.txtTcpPort.WaterText = "";
			this.txtTcpPort.WordWrap = true;
			// 
			// txtServerIp
			// 
			this.txtServerIp.BackColor = System.Drawing.Color.Transparent;
			this.txtServerIp.Icon = null;
			this.txtServerIp.IconIsButton = false;
			this.txtServerIp.IsPasswordChat = '\0';
			this.txtServerIp.IsSystemPasswordChar = false;
			this.txtServerIp.Lines = new string[0];
			this.txtServerIp.Location = new System.Drawing.Point(47, 104);
			this.txtServerIp.Margin = new System.Windows.Forms.Padding(0);
			this.txtServerIp.MaxLength = 32767;
			this.txtServerIp.MinimumSize = new System.Drawing.Size(0, 28);
			this.txtServerIp.MouseBack = null;
			this.txtServerIp.Multiline = false;
			this.txtServerIp.Name = "txtServerIp";
			this.txtServerIp.NormlBack = null;
			this.txtServerIp.Padding = new System.Windows.Forms.Padding(5);
			this.txtServerIp.ReadOnly = false;
			this.txtServerIp.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtServerIp.Size = new System.Drawing.Size(141, 28);
			this.txtServerIp.TabIndex = 0;
			this.txtServerIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtServerIp.WaterColor = System.Drawing.Color.DarkGray;
			this.txtServerIp.WaterText = "";
			this.txtServerIp.WordWrap = true;
			// 
			// LoginSettingFrom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
			this.CanResize = false;
			this.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ClientSize = new System.Drawing.Size(379, 292);
			this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
			this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
			this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
			this.Controls.Add(this.splitContainer1);
			this.EffectWidth = 3;
			this.MaximizeBox = false;
			this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
			this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
			this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
			this.Name = "LoginSettingFrom";
			this.ShowDrawIcon = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "登录设置";
			this.Load += new System.EventHandler(this.LoginSettingFromLoad);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginSettingFromFormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinTextBox txtServerIp;
		private CCWin.SkinControl.SkinTextBox txtTcpPort;
		private CCWin.SkinControl.SkinLabel skinLabel1;
		private CCWin.SkinControl.SkinLabel skinLabel3;
		private CCWin.SkinControl.SkinButtom btnOk;
		private CCWin.SkinControl.SkinButtom btnCancel;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
