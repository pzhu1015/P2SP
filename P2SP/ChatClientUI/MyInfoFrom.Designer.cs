/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-11
 * Time: 11:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class MyInfoFrom
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
			this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlTx = new CCWin.SkinControl.SkinPanel();
			this.spHeadImage = new CCWin.SkinControl.SkinPanel();
			this.skinTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnlTx.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(101, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "呢称";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(227, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "账号";
			// 
			// skinLabel1
			// 
			this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
			this.skinLabel1.AutoSize = true;
			this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
			this.skinLabel1.BorderColor = System.Drawing.Color.White;
			this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.skinLabel1.ForeColor = System.Drawing.Color.White;
			this.skinLabel1.Location = new System.Drawing.Point(101, 100);
			this.skinLabel1.Name = "skinLabel1";
			this.skinLabel1.Size = new System.Drawing.Size(164, 17);
			this.skinLabel1.TabIndex = 3;
			this.skinLabel1.Text = "站在巨人肩膀上才能看得更远";
			this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// skinTabControl1
			// 
			this.skinTabControl1.BaseColor = System.Drawing.Color.White;
			this.skinTabControl1.BorderColor = System.Drawing.Color.White;
			this.skinTabControl1.Controls.Add(this.tabPage1);
			this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
			this.skinTabControl1.Location = new System.Drawing.Point(1, 150);
			this.skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.skinTabControl1.Name = "skinTabControl1";
			this.skinTabControl1.Padding = new System.Drawing.Point(0, 0);
			this.skinTabControl1.PageColor = System.Drawing.Color.White;
			this.skinTabControl1.SelectedIndex = 0;
			this.skinTabControl1.Size = new System.Drawing.Size(459, 478);
			this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.skinTabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(451, 434);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "资料";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 180);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 12);
			this.label9.TabIndex = 6;
			this.label9.Text = "电  话 : ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 12);
			this.label8.TabIndex = 5;
			this.label8.Text = "职  业 : ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 12);
			this.label7.TabIndex = 4;
			this.label7.Text = "邮  箱 : ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 93);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 12);
			this.label6.TabIndex = 3;
			this.label6.Text = "所在地 : ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 12);
			this.label5.TabIndex = 2;
			this.label5.Text = "故  乡 : ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "个  人 : ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "账  号 : ";
			// 
			// pnlTx
			// 
			this.pnlTx.BackColor = System.Drawing.Color.Transparent;
			this.pnlTx.BackgroundImage = global::ChatClientUI.ResourceForm.picBackgroundImage;
			this.pnlTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlTx.Controls.Add(this.spHeadImage);
			this.pnlTx.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.pnlTx.DownBack = null;
			this.pnlTx.Location = new System.Drawing.Point(13, 51);
			this.pnlTx.Margin = new System.Windows.Forms.Padding(0);
			this.pnlTx.MouseBack = null;
			this.pnlTx.Name = "pnlTx";
			this.pnlTx.NormlBack = null;
			this.pnlTx.Size = new System.Drawing.Size(66, 66);
			this.pnlTx.TabIndex = 134;
			// 
			// spHeadImage
			// 
			this.spHeadImage.BackColor = System.Drawing.Color.Transparent;
			this.spHeadImage.BackgroundImage = global::ChatClientUI.ResourceForm.default_head;
			this.spHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.spHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.spHeadImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.spHeadImage.DownBack = null;
			this.spHeadImage.Location = new System.Drawing.Point(1, 1);
			this.spHeadImage.MouseBack = null;
			this.spHeadImage.Name = "spHeadImage";
			this.spHeadImage.NormlBack = null;
			this.spHeadImage.Radius = 3;
			this.spHeadImage.Size = new System.Drawing.Size(64, 64);
			this.spHeadImage.TabIndex = 1;
			// 
			// MyInfoFrom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
			this.BorderWidth = 1;
			this.CanResize = false;
			this.CaptionHeight = 150;
			this.ClientSize = new System.Drawing.Size(461, 629);
			this.CloseDownBack = global::ChatClientUI.ResourceForm.btn_close_down;
			this.CloseMouseBack = global::ChatClientUI.ResourceForm.btn_close_highlight;
			this.CloseNormlBack = global::ChatClientUI.ResourceForm.btn_close_disable;
			this.Controls.Add(this.pnlTx);
			this.Controls.Add(this.skinTabControl1);
			this.Controls.Add(this.skinLabel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.EffectBack = System.Drawing.Color.Black;
			this.EffectCaption = false;
			this.MaximizeBox = false;
			this.MiniDownBack = global::ChatClientUI.ResourceForm.btn_mini_down;
			this.MiniMouseBack = global::ChatClientUI.ResourceForm.btn_mini_highlight;
			this.MiniNormlBack = global::ChatClientUI.ResourceForm.btn_mini_normal;
			this.Name = "MyInfoFrom";
			this.ShowDrawIcon = false;
			this.Text = "个人资料";
			this.Load += new System.EventHandler(this.MyInfoFromLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyInfoFromFormClosing);
			this.skinTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pnlTx.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label9;
		private CCWin.SkinControl.SkinPanel spHeadImage;
		private CCWin.SkinControl.SkinPanel pnlTx;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPage1;
		private CCWin.SkinControl.SkinTabControl skinTabControl1;
		private CCWin.SkinControl.SkinLabel skinLabel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
