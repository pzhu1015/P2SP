namespace ChatClient
{
    partial class RegistFrom
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
            this.btnCancel = new CCWin.SkinControl.SkinButtom();
            this.btnOk = new CCWin.SkinControl.SkinButtom();
            this.txtUserId = new CCWin.SkinControl.SkinTextBox();
            this.txtPassword = new CCWin.SkinControl.SkinTextBox();
            this.txtConfirmPassword = new CCWin.SkinControl.SkinTextBox();
            this.txtNickName = new CCWin.SkinControl.SkinTextBox();
            this.txtEmail = new CCWin.SkinControl.SkinTextBox();
            this.txtPhoneNumber = new CCWin.SkinControl.SkinTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = global::ChatClient.ControlResource.btnDownBack;
            this.btnCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnCancel.Location = new System.Drawing.Point(15, 277);
            this.btnCancel.MouseBack = global::ChatClient.ControlResource.btnMouseBack;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = global::ChatClient.ControlResource.btnNormlBack;
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOk.DownBack = global::ChatClient.ControlResource.btnDownBack;
            this.btnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnOk.Location = new System.Drawing.Point(124, 277);
            this.btnOk.MouseBack = global::ChatClient.ControlResource.btnMouseBack;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = global::ChatClient.ControlResource.btnNormlBack;
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.Transparent;
            this.txtUserId.Icon = null;
            this.txtUserId.IconIsButton = false;
            this.txtUserId.IsPasswordChat = '\0';
            this.txtUserId.IsSystemPasswordChar = false;
            this.txtUserId.Lines = new string[0];
            this.txtUserId.Location = new System.Drawing.Point(15, 43);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserId.MaxLength = 32767;
            this.txtUserId.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtUserId.MouseBack = null;
            this.txtUserId.Multiline = false;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.NormlBack = null;
            this.txtUserId.Padding = new System.Windows.Forms.Padding(5);
            this.txtUserId.ReadOnly = false;
            this.txtUserId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserId.Size = new System.Drawing.Size(185, 28);
            this.txtUserId.TabIndex = 4;
            this.txtUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserId.WaterColor = System.Drawing.Color.DarkGray;
            this.txtUserId.WaterText = "用户名";
            this.txtUserId.WordWrap = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Icon = null;
            this.txtPassword.IconIsButton = false;
            this.txtPassword.IsPasswordChat = '\0';
            this.txtPassword.IsSystemPasswordChar = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(15, 118);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPassword.MouseBack = null;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NormlBack = null;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.Size = new System.Drawing.Size(185, 28);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPassword.WaterText = "密码";
            this.txtPassword.WordWrap = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.Icon = null;
            this.txtConfirmPassword.IconIsButton = false;
            this.txtConfirmPassword.IsPasswordChat = '\0';
            this.txtConfirmPassword.IsSystemPasswordChar = false;
            this.txtConfirmPassword.Lines = new string[0];
            this.txtConfirmPassword.Location = new System.Drawing.Point(15, 157);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtConfirmPassword.MaxLength = 32767;
            this.txtConfirmPassword.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtConfirmPassword.MouseBack = null;
            this.txtConfirmPassword.Multiline = false;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.NormlBack = null;
            this.txtConfirmPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtConfirmPassword.ReadOnly = false;
            this.txtConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfirmPassword.Size = new System.Drawing.Size(185, 28);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConfirmPassword.WaterColor = System.Drawing.Color.DarkGray;
            this.txtConfirmPassword.WaterText = "确认密码";
            this.txtConfirmPassword.WordWrap = true;
            // 
            // txtNickName
            // 
            this.txtNickName.BackColor = System.Drawing.Color.Transparent;
            this.txtNickName.Icon = null;
            this.txtNickName.IconIsButton = false;
            this.txtNickName.IsPasswordChat = '\0';
            this.txtNickName.IsSystemPasswordChar = false;
            this.txtNickName.Lines = new string[0];
            this.txtNickName.Location = new System.Drawing.Point(15, 80);
            this.txtNickName.Margin = new System.Windows.Forms.Padding(0);
            this.txtNickName.MaxLength = 32767;
            this.txtNickName.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtNickName.MouseBack = null;
            this.txtNickName.Multiline = false;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.NormlBack = null;
            this.txtNickName.Padding = new System.Windows.Forms.Padding(5);
            this.txtNickName.ReadOnly = false;
            this.txtNickName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNickName.Size = new System.Drawing.Size(185, 28);
            this.txtNickName.TabIndex = 7;
            this.txtNickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNickName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtNickName.WaterText = "昵称";
            this.txtNickName.WordWrap = true;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Icon = null;
            this.txtEmail.IconIsButton = false;
            this.txtEmail.IsPasswordChat = '\0';
            this.txtEmail.IsSystemPasswordChar = false;
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(14, 195);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtEmail.MouseBack = null;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NormlBack = null;
            this.txtEmail.Padding = new System.Windows.Forms.Padding(5);
            this.txtEmail.ReadOnly = false;
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.Size = new System.Drawing.Size(185, 28);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.WaterColor = System.Drawing.Color.DarkGray;
            this.txtEmail.WaterText = "邮箱";
            this.txtEmail.WordWrap = true;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtPhoneNumber.Icon = null;
            this.txtPhoneNumber.IconIsButton = false;
            this.txtPhoneNumber.IsPasswordChat = '\0';
            this.txtPhoneNumber.IsSystemPasswordChar = false;
            this.txtPhoneNumber.Lines = new string[0];
            this.txtPhoneNumber.Location = new System.Drawing.Point(14, 233);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtPhoneNumber.MaxLength = 32767;
            this.txtPhoneNumber.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPhoneNumber.MouseBack = null;
            this.txtPhoneNumber.Multiline = false;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.NormlBack = null;
            this.txtPhoneNumber.Padding = new System.Windows.Forms.Padding(5);
            this.txtPhoneNumber.ReadOnly = false;
            this.txtPhoneNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhoneNumber.Size = new System.Drawing.Size(185, 28);
            this.txtPhoneNumber.TabIndex = 9;
            this.txtPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPhoneNumber.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPhoneNumber.WaterText = "手机号";
            this.txtPhoneNumber.WordWrap = true;
            // 
            // RegistFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(214, 329);
            this.CloseDownBack = global::ChatClient.FormResource.btn_close_down;
            this.CloseMouseBack = global::ChatClient.FormResource.btn_close_mouse;
            this.CloseNormlBack = global::ChatClient.FormResource.btn_close_normal;
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MiniDownBack = global::ChatClient.FormResource.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.FormResource.btn_mini_mouse;
            this.MiniNormlBack = global::ChatClient.FormResource.btn_mini_normal;
            this.Name = "RegistFrom";
            this.Shadow = false;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistFrom_FormClosing);
            this.Load += new System.EventHandler(this.RegistFrom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButtom btnCancel;
        private CCWin.SkinControl.SkinButtom btnOk;
        private CCWin.SkinControl.SkinTextBox txtUserId;
        private CCWin.SkinControl.SkinTextBox txtPassword;
        private CCWin.SkinControl.SkinTextBox txtConfirmPassword;
        private CCWin.SkinControl.SkinTextBox txtNickName;
        private CCWin.SkinControl.SkinTextBox txtEmail;
        private CCWin.SkinControl.SkinTextBox txtPhoneNumber;
    }
}