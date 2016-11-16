/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-25
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.ChatComp
{
	partial class LoginUserPanel
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
			this.panelMain = new CCWin.SkinControl.SkinPanel();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.DownBack = null;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Margin = new System.Windows.Forms.Padding(0);
			this.panelMain.MouseBack = null;
			this.panelMain.Name = "panelMain";
			this.panelMain.NormlBack = null;
			this.panelMain.Size = new System.Drawing.Size(300, 110);
			this.panelMain.TabIndex = 6;
			// 
			// LoginUserPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.panelMain);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(300, 110);
			this.MinimumSize = new System.Drawing.Size(300, 110);
			this.Name = "LoginUserPanel";
			this.Size = new System.Drawing.Size(300, 110);
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinPanel panelMain;
	}
}
