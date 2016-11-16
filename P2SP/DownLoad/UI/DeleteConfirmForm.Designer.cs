/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-5
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class DeleteConfirmForm
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
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btnCancle = new DevComponents.DotNetBar.ButtonX();
			this.btnOk = new DevComponents.DotNetBar.ButtonX();
			this.chBoxIsDeleteFile = new DevComponents.DotNetBar.Controls.CheckBoxX();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// labelX1
			// 
			this.labelX1.Location = new System.Drawing.Point(94, 23);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(209, 23);
			this.labelX1.TabIndex = 0;
			this.labelX1.Text = "删除任务提示: 您确定删除任务吗?";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::DownLoad.MainIcon.warning_32;
			this.pictureBox2.Location = new System.Drawing.Point(39, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(49, 54);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// btnCancle
			// 
			this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancle.Location = new System.Drawing.Point(187, 82);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(75, 23);
			this.btnCancle.TabIndex = 2;
			this.btnCancle.Text = "取消(&C)";
			this.btnCancle.Click += new System.EventHandler(this.BtnCancleClick);
			// 
			// btnOk
			// 
			this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOk.Location = new System.Drawing.Point(282, 82);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "确定(&O)";
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// chBoxIsDeleteFile
			// 
			this.chBoxIsDeleteFile.Location = new System.Drawing.Point(39, 82);
			this.chBoxIsDeleteFile.Name = "chBoxIsDeleteFile";
			this.chBoxIsDeleteFile.Size = new System.Drawing.Size(128, 23);
			this.chBoxIsDeleteFile.TabIndex = 4;
			this.chBoxIsDeleteFile.Text = "同时删除文件";
			// 
			// DeleteConfirmForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(369, 113);
			this.Controls.Add(this.chBoxIsDeleteFile);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancle);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.labelX1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeleteConfirmForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "删除";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteConfirmFormFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
		}
		private DevComponents.DotNetBar.Controls.CheckBoxX chBoxIsDeleteFile;
		private DevComponents.DotNetBar.ButtonX btnCancle;
		private DevComponents.DotNetBar.ButtonX btnOk;
		private System.Windows.Forms.PictureBox pictureBox2;
		private DevComponents.DotNetBar.LabelX labelX1;
	}
}
