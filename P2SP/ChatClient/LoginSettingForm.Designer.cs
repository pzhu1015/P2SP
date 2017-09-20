namespace ChatClient
{
    partial class LoginSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new CCWin.SkinControl.SkinButtom();
            this.btnCancel = new CCWin.SkinControl.SkinButtom();
            this.txtHost = new CCWin.SkinControl.SkinTextBox();
            this.txtPort = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.groupBox1.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOk.DownBack = global::ChatClient.ControlResource.btnDownBack;
            this.btnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnOk.Location = new System.Drawing.Point(229, 12);
            this.btnOk.MouseBack = global::ChatClient.ControlResource.btnMouseBack;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = global::ChatClient.ControlResource.btnNormlBack;
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = global::ChatClient.ControlResource.btnDownBack;
            this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnCancel.Location = new System.Drawing.Point(338, 12);
            this.btnCancel.MouseBack = global::ChatClient.ControlResource.btnMouseBack;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = global::ChatClient.ControlResource.btnNormlBack;
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.Transparent;
            this.txtHost.Icon = null;
            this.txtHost.IconIsButton = false;
            this.txtHost.IsPasswordChat = '\0';
            this.txtHost.IsSystemPasswordChar = false;
            this.txtHost.Lines = new string[0];
            this.txtHost.Location = new System.Drawing.Point(95, 17);
            this.txtHost.Margin = new System.Windows.Forms.Padding(0);
            this.txtHost.MaxLength = 32767;
            this.txtHost.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtHost.MouseBack = null;
            this.txtHost.Multiline = false;
            this.txtHost.Name = "txtHost";
            this.txtHost.NormlBack = null;
            this.txtHost.Padding = new System.Windows.Forms.Padding(5);
            this.txtHost.ReadOnly = false;
            this.txtHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHost.Size = new System.Drawing.Size(154, 28);
            this.txtHost.TabIndex = 2;
            this.txtHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHost.WaterColor = System.Drawing.Color.DarkGray;
            this.txtHost.WaterText = "0.0.0.0";
            this.txtHost.WordWrap = true;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.Icon = null;
            this.txtPort.IconIsButton = false;
            this.txtPort.IsPasswordChat = '\0';
            this.txtPort.IsSystemPasswordChar = false;
            this.txtPort.Lines = new string[0];
            this.txtPort.Location = new System.Drawing.Point(326, 17);
            this.txtPort.Margin = new System.Windows.Forms.Padding(0);
            this.txtPort.MaxLength = 32767;
            this.txtPort.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPort.MouseBack = null;
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.NormlBack = null;
            this.txtPort.Padding = new System.Windows.Forms.Padding(5);
            this.txtPort.ReadOnly = false;
            this.txtPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPort.Size = new System.Drawing.Size(75, 28);
            this.txtPort.TabIndex = 3;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPort.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPort.WaterText = "0000";
            this.txtPort.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(12, 28);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(80, 17);
            this.skinLabel1.TabIndex = 4;
            this.skinLabel1.Text = "服务器地址：";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(269, 28);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(44, 17);
            this.skinLabel2.TabIndex = 5;
            this.skinLabel2.Text = "端口：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.skinLabel2);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.skinLabel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录服务器";
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.btnCancel);
            this.skinPanel1.Controls.Add(this.btnOk);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(3, 288);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(426, 44);
            this.skinPanel1.TabIndex = 7;
            // 
            // LoginSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackPalace = global::ChatClient.FormResource.BackPalace;
            this.ClientSize = new System.Drawing.Size(432, 335);
            this.CloseDownBack = global::ChatClient.FormResource.btn_close_down;
            this.CloseMouseBack = global::ChatClient.FormResource.btn_close_mouse;
            this.CloseNormlBack = global::ChatClient.FormResource.btn_close_normal;
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MiniDownBack = global::ChatClient.FormResource.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.FormResource.btn_mini_mouse;
            this.MiniNormlBack = global::ChatClient.FormResource.btn_mini_normal;
            this.Name = "LoginSettingForm";
            this.Shadow = false;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.LoginSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.skinPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButtom btnOk;
        private CCWin.SkinControl.SkinButtom btnCancel;
        private CCWin.SkinControl.SkinTextBox txtHost;
        private CCWin.SkinControl.SkinTextBox txtPort;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private CCWin.SkinControl.SkinPanel skinPanel1;
    }
}