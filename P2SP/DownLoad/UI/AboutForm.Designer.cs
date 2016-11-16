/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-20
 * Time: 20:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DownLoad.UI
{
	partial class AboutForm
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
			this.btnOk = new DevComponents.DotNetBar.ButtonX();
			this.SuspendLayout();
			// 
			// labelX1
			// 
			this.labelX1.Location = new System.Drawing.Point(12, 23);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(336, 72);
			this.labelX1.TabIndex = 0;
			this.labelX1.Text = "<font color=\"#BA1419\"><b>版权所有: 彭志虎 ，使用者有任何意见或建意请发送致邮箱 : pengzhihu1015@163.com ，联系" +
			"QQ: 507143199\r\n<br/>此软件只供学习与参考，禁止用于任何商业用途，<br/>最终解释权由彭志虎提供，谢谢使用。</b></font>";
			this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Near;
			// 
			// btnOk
			// 
			this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOk.Location = new System.Drawing.Point(261, 101);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "确定(&O)";
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// AboutForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(348, 128);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.labelX1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "关于";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutFormFormClosing);
			this.ResumeLayout(false);
		}
		private DevComponents.DotNetBar.ButtonX btnOk;
		private DevComponents.DotNetBar.LabelX labelX1;
	}
}
