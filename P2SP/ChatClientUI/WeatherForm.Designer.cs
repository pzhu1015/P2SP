/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-19
 * Time: 16:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ChatClientUI
{
	partial class WeatherForm
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
			this.lblTemperature = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblWeather = new System.Windows.Forms.Label();
			this.btnToday = new CCWin.SkinControl.SkinButtom();
			this.btnTomorrow = new CCWin.SkinControl.SkinButtom();
			this.btnAfter = new CCWin.SkinControl.SkinButtom();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnState = new CCWin.SkinControl.SkinButtom();
			this.lblSuggest = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTemperature
			// 
			this.lblTemperature.AutoSize = true;
			this.lblTemperature.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTemperature.ForeColor = System.Drawing.SystemColors.Control;
			this.lblTemperature.Location = new System.Drawing.Point(16, 10);
			this.lblTemperature.Name = "lblTemperature";
			this.lblTemperature.Size = new System.Drawing.Size(0, 35);
			this.lblTemperature.TabIndex = 0;
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCity.ForeColor = System.Drawing.SystemColors.Control;
			this.lblCity.Location = new System.Drawing.Point(16, 61);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(0, 16);
			this.lblCity.TabIndex = 1;
			// 
			// lblWeather
			// 
			this.lblWeather.AutoSize = true;
			this.lblWeather.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblWeather.ForeColor = System.Drawing.SystemColors.Control;
			this.lblWeather.Location = new System.Drawing.Point(16, 99);
			this.lblWeather.Name = "lblWeather";
			this.lblWeather.Size = new System.Drawing.Size(0, 14);
			this.lblWeather.TabIndex = 2;
			// 
			// btnToday
			// 
			this.btnToday.BackColor = System.Drawing.Color.Transparent;
			this.btnToday.BaseColor = System.Drawing.Color.Transparent;
			this.btnToday.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnToday.DownBack = null;
			this.btnToday.DrawType = CCWin.SkinControl.DrawStyle.None;
			this.btnToday.ForeColor = System.Drawing.SystemColors.Control;
			this.btnToday.ImageWidth = 22;
			this.btnToday.Location = new System.Drawing.Point(2, 28);
			this.btnToday.Margin = new System.Windows.Forms.Padding(0);
			this.btnToday.MouseBack = null;
			this.btnToday.Name = "btnToday";
			this.btnToday.NormlBack = null;
			this.btnToday.Palace = true;
			this.btnToday.Size = new System.Drawing.Size(95, 42);
			this.btnToday.TabIndex = 3;
			this.btnToday.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnToday.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.btnToday.UseVisualStyleBackColor = true;
			// 
			// btnTomorrow
			// 
			this.btnTomorrow.BackColor = System.Drawing.Color.Transparent;
			this.btnTomorrow.BaseColor = System.Drawing.Color.Transparent;
			this.btnTomorrow.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnTomorrow.DownBack = null;
			this.btnTomorrow.DrawType = CCWin.SkinControl.DrawStyle.None;
			this.btnTomorrow.ForeColor = System.Drawing.SystemColors.Control;
			this.btnTomorrow.ImageWidth = 22;
			this.btnTomorrow.Location = new System.Drawing.Point(98, 28);
			this.btnTomorrow.Margin = new System.Windows.Forms.Padding(0);
			this.btnTomorrow.MouseBack = null;
			this.btnTomorrow.Name = "btnTomorrow";
			this.btnTomorrow.NormlBack = null;
			this.btnTomorrow.Size = new System.Drawing.Size(95, 42);
			this.btnTomorrow.TabIndex = 4;
			this.btnTomorrow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnTomorrow.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.btnTomorrow.UseVisualStyleBackColor = true;
			// 
			// btnAfter
			// 
			this.btnAfter.BackColor = System.Drawing.Color.Transparent;
			this.btnAfter.BaseColor = System.Drawing.Color.Transparent;
			this.btnAfter.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnAfter.DownBack = null;
			this.btnAfter.DrawType = CCWin.SkinControl.DrawStyle.None;
			this.btnAfter.ForeColor = System.Drawing.SystemColors.Control;
			this.btnAfter.ImageWidth = 22;
			this.btnAfter.Location = new System.Drawing.Point(194, 28);
			this.btnAfter.MouseBack = null;
			this.btnAfter.Name = "btnAfter";
			this.btnAfter.NormlBack = null;
			this.btnAfter.Size = new System.Drawing.Size(95, 42);
			this.btnAfter.TabIndex = 5;
			this.btnAfter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnAfter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.btnAfter.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(1, 1);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnState);
			this.splitContainer1.Panel1.Controls.Add(this.lblSuggest);
			this.splitContainer1.Panel1.Controls.Add(this.lblTemperature);
			this.splitContainer1.Panel1.Controls.Add(this.lblCity);
			this.splitContainer1.Panel1.Controls.Add(this.lblWeather);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.btnTomorrow);
			this.splitContainer1.Panel2.Controls.Add(this.btnAfter);
			this.splitContainer1.Panel2.Controls.Add(this.btnToday);
			this.splitContainer1.Size = new System.Drawing.Size(298, 268);
			this.splitContainer1.SplitterDistance = 181;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 6;
			// 
			// btnState
			// 
			this.btnState.BackColor = System.Drawing.Color.Transparent;
			this.btnState.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
			this.btnState.ControlState = CCWin.SkinClass.ControlState.Normal;
			this.btnState.DownBack = global::ChatClientUI.ResourceControl.btnState_DownBack;
			this.btnState.DrawType = CCWin.SkinControl.DrawStyle.Img;
			this.btnState.Image = global::ChatClientUI.ResourceChatForm.settings_20;
			this.btnState.Location = new System.Drawing.Point(262, 10);
			this.btnState.Margin = new System.Windows.Forms.Padding(0);
			this.btnState.MouseBack = global::ChatClientUI.ResourceControl.btnState_MouseBack;
			this.btnState.Name = "btnState";
			this.btnState.NormlBack = null;
			this.btnState.Size = new System.Drawing.Size(26, 22);
			this.btnState.TabIndex = 28;
			this.btnState.UseVisualStyleBackColor = true;
			// 
			// lblSuggest
			// 
			this.lblSuggest.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblSuggest.ForeColor = System.Drawing.SystemColors.Control;
			this.lblSuggest.Location = new System.Drawing.Point(0, 158);
			this.lblSuggest.Name = "lblSuggest";
			this.lblSuggest.Size = new System.Drawing.Size(298, 23);
			this.lblSuggest.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(224, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "后天";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(133, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "明天";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(30, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "今天";
			// 
			// WeatherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
			this.BackPalace = global::ChatClientUI.ResourceForm.BackPalace;
			this.BorderWidth = 1;
			this.CanResize = false;
			this.CaptionHeight = 1;
			this.ClientSize = new System.Drawing.Size(300, 270);
			this.ControlBox = false;
			this.Controls.Add(this.splitContainer1);
			this.Name = "WeatherForm";
			this.Radius = 1;
			this.ShowBorder = false;
			this.ShowDrawIcon = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.WeatherFormLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private CCWin.SkinControl.SkinButtom btnState;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblSuggest;
		private CCWin.SkinControl.SkinButtom btnToday;
		private CCWin.SkinControl.SkinButtom btnTomorrow;
		private CCWin.SkinControl.SkinButtom btnAfter;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label lblTemperature;
		private System.Windows.Forms.Label lblCity;
		private System.Windows.Forms.Label lblWeather;
	}
}
