/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-14
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class UserInfoForm
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblName = new CCWin.SkinControl.SkinLabel();
			this.lblPersnalMsg = new CCWin.SkinControl.SkinLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Location = new System.Drawing.Point(6, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(84, 141);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// lblName
			// 
			this.lblName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
			this.lblName.AutoSize = true;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.BorderColor = System.Drawing.Color.Black;
			this.lblName.BorderSize = 4;
			this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblName.Font = new System.Drawing.Font("微软雅黑", 16F);
			this.lblName.ForeColor = System.Drawing.Color.White;
			this.lblName.Location = new System.Drawing.Point(94, 8);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(79, 30);
			this.lblName.TabIndex = 103;
			this.lblName.Text = "用户名";
			// 
			// lblPersnalMsg
			// 
			this.lblPersnalMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lblPersnalMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
			this.lblPersnalMsg.AutoSize = true;
			this.lblPersnalMsg.BackColor = System.Drawing.Color.Transparent;
			this.lblPersnalMsg.BorderColor = System.Drawing.Color.Black;
			this.lblPersnalMsg.BorderSize = 4;
			this.lblPersnalMsg.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.lblPersnalMsg.ForeColor = System.Drawing.Color.White;
			this.lblPersnalMsg.Location = new System.Drawing.Point(95, 37);
			this.lblPersnalMsg.Name = "lblPersnalMsg";
			this.lblPersnalMsg.Size = new System.Drawing.Size(65, 20);
			this.lblPersnalMsg.TabIndex = 104;
			this.lblPersnalMsg.Text = "个人名言";
			// 
			// UserInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
			this.BorderWidth = 1;
			this.ClientSize = new System.Drawing.Size(279, 181);
			this.ControlBox = false;
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblPersnalMsg);
			this.Controls.Add(this.pictureBox1);
			this.Name = "UserInfoForm";
			this.Radius = 1;
			this.ShowDrawIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.UserInfoFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CCWin.SkinControl.SkinLabel lblPersnalMsg;
		private CCWin.SkinControl.SkinLabel lblName;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
