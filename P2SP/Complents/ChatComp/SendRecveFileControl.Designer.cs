/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-18
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.ChatComp
{
	partial class SendRecveFileControl
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.progressBar = new CCWin.SkinControl.SkinProgressBar();
			this.lblCurrentLength = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblCommon = new System.Windows.Forms.Label();
			this.picBoxFile = new System.Windows.Forms.PictureBox();
			this.lblCancel = new System.Windows.Forms.Label();
			this.lblSave = new System.Windows.Forms.Label();
			this.lblRecve = new System.Windows.Forms.Label();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxFile)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.progressBar);
			this.splitContainer1.Panel1.Controls.Add(this.lblCurrentLength);
			this.splitContainer1.Panel1.Controls.Add(this.lblSpeed);
			this.splitContainer1.Panel1.Controls.Add(this.lblFileName);
			this.splitContainer1.Panel1.Controls.Add(this.lblCommon);
			this.splitContainer1.Panel1.Controls.Add(this.picBoxFile);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lblCancel);
			this.splitContainer1.Panel2.Controls.Add(this.lblSave);
			this.splitContainer1.Panel2.Controls.Add(this.lblRecve);
			this.splitContainer1.Size = new System.Drawing.Size(220, 112);
			this.splitContainer1.SplitterDistance = 83;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			// 
			// progressBar
			// 
			this.progressBar.Back = null;
			this.progressBar.BarBack = null;
			this.progressBar.BarMinusSize = new System.Drawing.Size(0, 0);
			this.progressBar.BarRadius = 1;
			this.progressBar.Border = System.Drawing.Color.Transparent;
			this.progressBar.ForeColor = System.Drawing.Color.Transparent;
			this.progressBar.FormatString = "";
			this.progressBar.InnerBorder = System.Drawing.Color.Transparent;
			this.progressBar.Location = new System.Drawing.Point(4, 48);
			this.progressBar.Margin = new System.Windows.Forms.Padding(0);
			this.progressBar.Name = "progressBar";
			this.progressBar.Radius = 1;
			this.progressBar.Size = new System.Drawing.Size(213, 10);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 10;
			this.progressBar.TrackBack = System.Drawing.Color.White;
			this.progressBar.TrackFore = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(182)))), ((int)(((byte)(233)))));
			this.progressBar.TxtShow = false;
			// 
			// lblCurrentLength
			// 
			this.lblCurrentLength.Location = new System.Drawing.Point(103, 61);
			this.lblCurrentLength.Margin = new System.Windows.Forms.Padding(0);
			this.lblCurrentLength.Name = "lblCurrentLength";
			this.lblCurrentLength.Size = new System.Drawing.Size(112, 16);
			this.lblCurrentLength.TabIndex = 9;
			this.lblCurrentLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSpeed
			// 
			this.lblSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblSpeed.Location = new System.Drawing.Point(4, 61);
			this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(82, 16);
			this.lblSpeed.TabIndex = 8;
			this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFileName
			// 
			this.lblFileName.Location = new System.Drawing.Point(52, 24);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(155, 19);
			this.lblFileName.TabIndex = 7;
			this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCommon
			// 
			this.lblCommon.Location = new System.Drawing.Point(52, 4);
			this.lblCommon.Name = "lblCommon";
			this.lblCommon.Size = new System.Drawing.Size(162, 19);
			this.lblCommon.TabIndex = 6;
			this.lblCommon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picBoxFile
			// 
			this.picBoxFile.Location = new System.Drawing.Point(6, 5);
			this.picBoxFile.Name = "picBoxFile";
			this.picBoxFile.Size = new System.Drawing.Size(40, 40);
			this.picBoxFile.TabIndex = 0;
			this.picBoxFile.TabStop = false;
			// 
			// lblCancel
			// 
			this.lblCancel.ForeColor = System.Drawing.Color.Blue;
			this.lblCancel.Location = new System.Drawing.Point(183, 3);
			this.lblCancel.Margin = new System.Windows.Forms.Padding(0);
			this.lblCancel.Name = "lblCancel";
			this.lblCancel.Size = new System.Drawing.Size(31, 18);
			this.lblCancel.TabIndex = 3;
			this.lblCancel.Text = "拒绝";
			this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSave
			// 
			this.lblSave.ForeColor = System.Drawing.Color.Blue;
			this.lblSave.Location = new System.Drawing.Point(69, 3);
			this.lblSave.Name = "lblSave";
			this.lblSave.Size = new System.Drawing.Size(84, 18);
			this.lblSave.TabIndex = 2;
			this.lblSave.Text = "另存为";
			this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRecve
			// 
			this.lblRecve.ForeColor = System.Drawing.Color.Blue;
			this.lblRecve.Location = new System.Drawing.Point(13, 3);
			this.lblRecve.Name = "lblRecve";
			this.lblRecve.Size = new System.Drawing.Size(33, 18);
			this.lblRecve.TabIndex = 1;
			this.lblRecve.Text = "接收";
			this.lblRecve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SendRecveFileControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(220, 112);
			this.MinimumSize = new System.Drawing.Size(220, 112);
			this.Name = "SendRecveFileControl";
			this.Size = new System.Drawing.Size(220, 112);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBoxFile)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblSave;
		private System.Windows.Forms.Label lblCancel;
		private System.Windows.Forms.Label lblRecve;
		private CCWin.SkinControl.SkinProgressBar progressBar;
		private System.Windows.Forms.Label lblSpeed;
		private System.Windows.Forms.Label lblCurrentLength;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblCommon;
		private System.Windows.Forms.PictureBox picBoxFile;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
