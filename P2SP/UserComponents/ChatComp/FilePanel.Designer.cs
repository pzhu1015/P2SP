/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-8
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UserComponents.ChatComp
{
	partial class FilePanel
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
			this.panelMain.AutoScroll = true;
			this.panelMain.BackColor = System.Drawing.Color.White;
			this.panelMain.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.DownBack = null;
			this.panelMain.Location = new System.Drawing.Point(0, 24);
			this.panelMain.MouseBack = null;
			this.panelMain.Name = "panelMain";
			this.panelMain.NormlBack = null;
			this.panelMain.Size = new System.Drawing.Size(230, 176);
			this.panelMain.TabIndex = 2;
			// 
			// FilePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelMain);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(230, 0);
			this.MinimumSize = new System.Drawing.Size(230, 100);
			this.Name = "FilePanel";
			this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
			this.Size = new System.Drawing.Size(230, 200);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FilePanelPaint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FilePanelMouseClick);
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinPanel panelMain;
	}
}
