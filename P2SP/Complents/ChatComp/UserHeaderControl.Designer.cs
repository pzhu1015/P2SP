/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-8-22
 * Time: 10:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.ChatComp
{
	partial class UserHeaderControl
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
			this.backGround = new CCWin.SkinControl.SkinPanel();
			this.headImage = new CCWin.SkinControl.SkinPanel();
			this.backGround.SuspendLayout();
			this.SuspendLayout();
			// 
			// backGround
			// 
			this.backGround.BackColor = System.Drawing.Color.Transparent;
			this.backGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.backGround.Controls.Add(this.headImage);
			this.backGround.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.backGround.Dock = System.Windows.Forms.DockStyle.Fill;
			this.backGround.DownBack = null;
			this.backGround.Location = new System.Drawing.Point(0, 0);
			this.backGround.MouseBack = null;
			this.backGround.Name = "backGround";
			this.backGround.NormlBack = null;
			this.backGround.Radius = 4;
			this.backGround.Size = new System.Drawing.Size(84, 84);
			this.backGround.TabIndex = 0;
			// 
			// headImage
			// 
			this.headImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.headImage.BackColor = System.Drawing.Color.Transparent;
			this.headImage.BackgroundImage = global::Complents.ChatCompResource.default_head;
			this.headImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.headImage.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.headImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.headImage.DownBack = null;
			this.headImage.Location = new System.Drawing.Point(2, 2);
			this.headImage.Margin = new System.Windows.Forms.Padding(0);
			this.headImage.MouseBack = null;
			this.headImage.Name = "headImage";
			this.headImage.NormlBack = null;
			this.headImage.Radius = 4;
			this.headImage.Size = new System.Drawing.Size(80, 80);
			this.headImage.TabIndex = 0;
			// 
			// UserHeaderControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.backGround);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "UserHeaderControl";
			this.Size = new System.Drawing.Size(84, 84);
			this.backGround.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinPanel backGround;
		private CCWin.SkinControl.SkinPanel headImage;
	}
}
