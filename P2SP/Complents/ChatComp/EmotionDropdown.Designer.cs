/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-1-17
 * Time: 17:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Complents.ChatComp
{
	partial class EmotionDropdown
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
			this.stcMain = new CCWin.SkinControl.SkinTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ecDefault = new Complents.ChatComp.EmotionContainer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.stcMain.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// stcMain
			// 
			this.stcMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.stcMain.BaseColor = System.Drawing.Color.White;
			this.stcMain.BorderColor = System.Drawing.Color.White;
			this.stcMain.Controls.Add(this.tabPage1);
			this.stcMain.Controls.Add(this.tabPage2);
			this.stcMain.Controls.Add(this.tabPage3);
			this.stcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stcMain.ItemSize = new System.Drawing.Size(70, 36);
			this.stcMain.Location = new System.Drawing.Point(0, 0);
			this.stcMain.Margin = new System.Windows.Forms.Padding(0);
			this.stcMain.Name = "stcMain";
			this.stcMain.Padding = new System.Drawing.Point(0, 0);
			this.stcMain.PageColor = System.Drawing.Color.White;
			this.stcMain.SelectedIndex = 0;
			this.stcMain.Size = new System.Drawing.Size(411, 367);
			this.stcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.stcMain.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.Controls.Add(this.ecDefault);
			this.tabPage1.Location = new System.Drawing.Point(4, 4);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(403, 323);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "默认";
			// 
			// ecDefault
			// 
			this.ecDefault.Columns = 15;
			this.ecDefault.GridSize = 32;
			this.ecDefault.Location = new System.Drawing.Point(0, 0);
			this.ecDefault.Name = "ecDefault";
			this.ecDefault.Row = 12;
			this.ecDefault.ShowToolTips = true;
			this.ecDefault.TabIndex = 0;
			this.ecDefault.ItemClick += new Complents.ChatComp.EmotionItemMouseEventHandler(this.EcDefaultItemClick);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.White;
			this.tabPage2.Location = new System.Drawing.Point(4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(411, 323);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "符号表情";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.White;
			this.tabPage3.Location = new System.Drawing.Point(4, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(411, 323);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "我的收藏";
			// 
			// EmotionDropdown
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.stcMain);
			this.Name = "EmotionDropdown";
			this.Size = new System.Drawing.Size(411, 367);
			this.stcMain.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private Complents.ChatComp.EmotionContainer ecDefault;
		private CCWin.SkinControl.SkinTabControl stcMain;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
	}
}
