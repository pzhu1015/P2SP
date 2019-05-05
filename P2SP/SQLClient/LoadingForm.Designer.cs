namespace SQLClient
{
    partial class LoadingForm
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
            this.lblMsg = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.BackColor = System.Drawing.Color.White;
            this.lblMsg.Appearance.Options.UseBackColor = true;
            this.lblMsg.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMsg.AppearanceCaption.Options.UseFont = true;
            this.lblMsg.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMsg.AppearanceDescription.Options.UseFont = true;
            this.lblMsg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsg.ImageHorzOffset = 40;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(239, 66);
            this.lblMsg.TabIndex = 1;
            // 
            // LoadingForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 66);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitFrom";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel lblMsg;
    }
}