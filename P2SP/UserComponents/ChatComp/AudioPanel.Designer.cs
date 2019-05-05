/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-6
 * Time: 9:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UserComponents.ChatComp
{
	partial class AudioPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPanel));
			this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
			this.panelSetting = new CCWin.SkinControl.SkinPanel();
			this.btnVoice = new CCWin.SkinControl.SkinButtom();
			this.tbVoice = new System.Windows.Forms.TrackBar();
			this.tbMic = new System.Windows.Forms.TrackBar();
			this.btnMic = new CCWin.SkinControl.SkinButtom();
			this.lblCommon = new CCWin.SkinControl.SkinLabel();
			this.btnAccecpt = new CCWin.SkinControl.SkinButtom();
			this.btnCancel = new CCWin.SkinControl.SkinButtom();
			this.skinPanel1.SuspendLayout();
			this.panelSetting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbVoice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbMic)).BeginInit();
			this.SuspendLayout();
			// 
			// skinPanel1
			// 
			this.skinPanel1.BackColor = System.Drawing.Color.White;
			this.skinPanel1.Controls.Add(this.panelSetting);
			this.skinPanel1.Controls.Add(this.lblCommon);
			this.skinPanel1.Controls.Add(this.btnAccecpt);
			this.skinPanel1.Controls.Add(this.btnCancel);
			this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skinPanel1.DownBack = null;
			this.skinPanel1.Location = new System.Drawing.Point(0, 24);
			this.skinPanel1.MouseBack = null;
			this.skinPanel1.Name = "skinPanel1";
			this.skinPanel1.NormlBack = null;
			this.skinPanel1.Size = new System.Drawing.Size(200, 276);
			this.skinPanel1.TabIndex = 0;
			// 
			// panelSetting
			// 
			this.panelSetting.BackColor = System.Drawing.Color.Transparent;
			this.panelSetting.Controls.Add(this.btnVoice);
			this.panelSetting.Controls.Add(this.tbVoice);
			this.panelSetting.Controls.Add(this.tbMic);
			this.panelSetting.Controls.Add(this.btnMic);
			this.panelSetting.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.panelSetting.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSetting.DownBack = null;
			this.panelSetting.Location = new System.Drawing.Point(0, 0);
			this.panelSetting.MouseBack = null;
			this.panelSetting.Name = "panelSetting";
			this.panelSetting.NormlBack = null;
			this.panelSetting.Size = new System.Drawing.Size(200, 145);
			this.panelSetting.TabIndex = 144;
			this.panelSetting.Visible = false;
			// 
			// btnVoice
			// 
			this.btnVoice.AutoSize = true;
			this.btnVoice.BackColor = System.Drawing.Color.Transparent;
			this.btnVoice.BackRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.btnVoice.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnVoice.DownBack = global::UserComponents.ChatCompResource.btnState_DownBack;
			this.btnVoice.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnVoice.Image = global::UserComponents.ChatCompResource.sound_enable;
			this.btnVoice.ImageWidth = 22;
			this.btnVoice.Location = new System.Drawing.Point(121, 108);
			this.btnVoice.Margin = new System.Windows.Forms.Padding(0);
			this.btnVoice.MouseBack = global::UserComponents.ChatCompResource.btnState_MouseBack;
			this.btnVoice.Name = "btnVoice";
			this.btnVoice.NormlBack = null;
			this.btnVoice.Size = new System.Drawing.Size(28, 28);
			this.btnVoice.TabIndex = 143;
			this.btnVoice.UseVisualStyleBackColor = false;
			this.btnVoice.Click += new System.EventHandler(this.BtnVoiceClick);
			// 
			// tbVoice
			// 
			this.tbVoice.BackColor = System.Drawing.Color.White;
			this.tbVoice.Location = new System.Drawing.Point(121, 3);
			this.tbVoice.Name = "tbVoice";
			this.tbVoice.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbVoice.Size = new System.Drawing.Size(45, 104);
			this.tbVoice.TabIndex = 138;
			this.tbVoice.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbVoice.Scroll += new System.EventHandler(this.TbVoiceScroll);
			// 
			// tbMic
			// 
			this.tbMic.BackColor = System.Drawing.Color.White;
			this.tbMic.Location = new System.Drawing.Point(64, 3);
			this.tbMic.Name = "tbMic";
			this.tbMic.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbMic.Size = new System.Drawing.Size(45, 104);
			this.tbMic.TabIndex = 139;
			this.tbMic.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbMic.Scroll += new System.EventHandler(this.TbMicScroll);
			// 
			// btnMic
			// 
			this.btnMic.BackColor = System.Drawing.Color.Transparent;
			this.btnMic.BackRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.btnMic.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnMic.DownBack = global::UserComponents.ChatCompResource.btnState_DownBack;
			this.btnMic.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnMic.Image = global::UserComponents.ChatCompResource.mic_enable;
			this.btnMic.ImageWidth = 22;
			this.btnMic.Location = new System.Drawing.Point(64, 113);
			this.btnMic.Margin = new System.Windows.Forms.Padding(0);
			this.btnMic.MouseBack = global::UserComponents.ChatCompResource.btnState_MouseBack;
			this.btnMic.Name = "btnMic";
			this.btnMic.NormlBack = null;
			this.btnMic.Size = new System.Drawing.Size(25, 23);
			this.btnMic.TabIndex = 141;
			this.btnMic.UseVisualStyleBackColor = false;
			this.btnMic.Click += new System.EventHandler(this.BtnMicClick);
			// 
			// lblCommon
			// 
			this.lblCommon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblCommon.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
			this.lblCommon.AutoSize = true;
			this.lblCommon.BackColor = System.Drawing.Color.Transparent;
			this.lblCommon.BorderColor = System.Drawing.Color.White;
			this.lblCommon.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCommon.Location = new System.Drawing.Point(47, 150);
			this.lblCommon.Name = "lblCommon";
			this.lblCommon.Size = new System.Drawing.Size(113, 17);
			this.lblCommon.TabIndex = 137;
			this.lblCommon.Text = "等待对方接收邀请...";
			// 
			// btnAccecpt
			// 
			this.btnAccecpt.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnAccecpt.BackColor = System.Drawing.Color.Transparent;
			this.btnAccecpt.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnAccecpt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccecpt.DownBack = ((System.Drawing.Image)(resources.GetObject("btnAccecpt.DownBack")));
			this.btnAccecpt.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnAccecpt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnAccecpt.Image = global::UserComponents.ChatCompResource.accecpt;
			this.btnAccecpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAccecpt.Location = new System.Drawing.Point(64, 179);
			this.btnAccecpt.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnAccecpt.MouseBack")));
			this.btnAccecpt.Name = "btnAccecpt";
			this.btnAccecpt.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnAccecpt.NormlBack")));
			this.btnAccecpt.Size = new System.Drawing.Size(69, 24);
			this.btnAccecpt.TabIndex = 136;
			this.btnAccecpt.Text = "接听";
			this.btnAccecpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAccecpt.UseVisualStyleBackColor = false;
			this.btnAccecpt.Click += new System.EventHandler(this.BtnAccecptClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.DownBack = ((System.Drawing.Image)(resources.GetObject("btnCancel.DownBack")));
			this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancel.Image = global::UserComponents.ChatCompResource.cancel;
			this.btnCancel.Location = new System.Drawing.Point(64, 209);
			this.btnCancel.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseBack")));
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnCancel.NormlBack")));
			this.btnCancel.Size = new System.Drawing.Size(69, 24);
			this.btnCancel.TabIndex = 135;
			this.btnCancel.Text = "取消";
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// AudioPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.skinPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(200, 0);
			this.MinimumSize = new System.Drawing.Size(200, 300);
			this.Name = "AudioPanel";
			this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
			this.Size = new System.Drawing.Size(200, 300);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.AudioPanelPaint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AudioPanelMouseClick);
			this.skinPanel1.ResumeLayout(false);
			this.skinPanel1.PerformLayout();
			this.panelSetting.ResumeLayout(false);
			this.panelSetting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbVoice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbMic)).EndInit();
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinPanel panelSetting;
		private System.Windows.Forms.TrackBar tbVoice;
		private System.Windows.Forms.TrackBar tbMic;
		private CCWin.SkinControl.SkinButtom btnMic;
		private CCWin.SkinControl.SkinButtom btnVoice;
		private CCWin.SkinControl.SkinLabel lblCommon;
		private CCWin.SkinControl.SkinButtom btnAccecpt;
		private CCWin.SkinControl.SkinButtom btnCancel;
		private CCWin.SkinControl.SkinPanel skinPanel1;
	}
}
