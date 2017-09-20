namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loginUserPanel1 = new Complents.ChatComp.LoginUserPanel();
            this.SuspendLayout();
            // 
            // loginUserPanel1
            // 
            this.loginUserPanel1.AutoSize = true;
            this.loginUserPanel1.BackColor = System.Drawing.Color.White;
            this.loginUserPanel1.Location = new System.Drawing.Point(43, 53);
            this.loginUserPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.loginUserPanel1.MaximumSize = new System.Drawing.Size(750, 480);
            this.loginUserPanel1.MinimumSize = new System.Drawing.Size(300, 110);
            this.loginUserPanel1.Name = "loginUserPanel1";
            this.loginUserPanel1.Size = new System.Drawing.Size(414, 261);
            this.loginUserPanel1.TabIndex = 0;
            this.loginUserPanel1.Load += new System.EventHandler(this.loginUserPanel1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 378);
            this.Controls.Add(this.loginUserPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Complents.ChatComp.LoginUserPanel loginUserPanel1;
    }
}

