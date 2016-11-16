/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-1-13
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class NewTaskForm
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
			this.btnCancel = new DevComponents.DotNetBar.ButtonX();
			this.txtUrl = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.lblError = new DevComponents.DotNetBar.LabelX();
			this.sptBtnContinue = new DevComponents.DotNetBar.ButtonX();
			this.btnDownLoad = new DevComponents.DotNetBar.ButtonItem();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.Location = new System.Drawing.Point(218, 131);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// txtUrl
			// 
			// 
			// 
			// 
			this.txtUrl.Border.Class = "TextBoxBorder";
			this.txtUrl.Location = new System.Drawing.Point(1, 5);
			this.txtUrl.Multiline = true;
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(375, 123);
			this.txtUrl.TabIndex = 15;
			// 
			// lblError
			// 
			this.lblError.Location = new System.Drawing.Point(1, 131);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(211, 23);
			this.lblError.TabIndex = 16;
			this.lblError.TextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// sptBtnContinue
			// 
			this.sptBtnContinue.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
			this.sptBtnContinue.Location = new System.Drawing.Point(301, 131);
			this.sptBtnContinue.Name = "sptBtnContinue";
			this.sptBtnContinue.Size = new System.Drawing.Size(75, 23);
			this.sptBtnContinue.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
									this.btnDownLoad});
			this.sptBtnContinue.TabIndex = 17;
			this.sptBtnContinue.Text = "继续";
			this.sptBtnContinue.Click += new System.EventHandler(this.SptBtnContinueClick);
			// 
			// btnDownLoad
			// 
			this.btnDownLoad.GlobalItem = false;
			this.btnDownLoad.ImagePaddingHorizontal = 8;
			this.btnDownLoad.Name = "btnDownLoad";
			this.btnDownLoad.Text = "立即下载";
			this.btnDownLoad.Click += new System.EventHandler(this.BtnDownLoadClick);
			// 
			// NewTaskForm
			// 
			this.AcceptButton = this.sptBtnContinue;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(377, 159);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.sptBtnContinue);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(385, 186);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(385, 186);
			this.Name = "NewTaskForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "新建任务";
			this.Load += new System.EventHandler(this.NewTaskFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewTaskFormFormClosing);
			this.ResumeLayout(false);
		}
		private DevComponents.DotNetBar.ButtonItem btnDownLoad;
		private DevComponents.DotNetBar.LabelX lblError;
		private DevComponents.DotNetBar.ButtonX btnCancel;
		private DevComponents.DotNetBar.ButtonX sptBtnContinue;
		private DevComponents.DotNetBar.Controls.TextBoxX txtUrl;
	}
}
