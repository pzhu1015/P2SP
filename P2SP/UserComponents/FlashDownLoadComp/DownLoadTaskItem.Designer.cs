namespace UserComponents.FlashDownLoadComp
{
    partial class DownLoadTaskItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgbTotal = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.pbItemImage = new DevExpress.XtraEditors.PictureEdit();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnDetail = new DevExpress.XtraEditors.PictureEdit();
            this.lblRemainTime = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalSource = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pgbTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbTotal
            // 
            this.pgbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbTotal.Location = new System.Drawing.Point(484, 15);
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgbTotal.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.pgbTotal.Properties.ShowTitle = true;
            this.pgbTotal.Size = new System.Drawing.Size(172, 10);
            this.pgbTotal.TabIndex = 0;
            this.pgbTotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownLoadTaskItem_MouseDown);
            this.pgbTotal.MouseEnter += new System.EventHandler(this.DownLoadTaskItem_MouseEnter);
            this.pgbTotal.MouseLeave += new System.EventHandler(this.DownLoadTaskItem_MouseLeave);
            // 
            // lblSize
            // 
            this.lblSize.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(64, 33);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(31, 14);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Total";
            this.lblSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownLoadTaskItem_MouseDown);
            this.lblSize.MouseEnter += new System.EventHandler(this.DownLoadTaskItem_MouseEnter);
            this.lblSize.MouseLeave += new System.EventHandler(this.DownLoadTaskItem_MouseLeave);
            // 
            // lblName
            // 
            this.lblName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(64, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 14);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "FileName";
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownLoadTaskItem_MouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.DownLoadTaskItem_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.DownLoadTaskItem_MouseLeave);
            // 
            // pbItemImage
            // 
            this.pbItemImage.Location = new System.Drawing.Point(10, 10);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Properties.AllowFocused = false;
            this.pbItemImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbItemImage.Properties.Appearance.Options.UseBackColor = true;
            this.pbItemImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbItemImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbItemImage.Properties.ShowMenu = false;
            this.pbItemImage.Size = new System.Drawing.Size(40, 40);
            this.pbItemImage.TabIndex = 13;
            this.pbItemImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownLoadTaskItem_MouseDown);
            this.pbItemImage.MouseEnter += new System.EventHandler(this.DownLoadTaskItem_MouseEnter);
            this.pbItemImage.MouseLeave += new System.EventHandler(this.DownLoadTaskItem_MouseLeave);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(674, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 14);
            this.lblStatus.TabIndex = 14;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetail.EditValue = global::UserComponents.FlashDownLoadResource.detail_16;
            this.btnDetail.Location = new System.Drawing.Point(763, 1);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Properties.AllowFocused = false;
            this.btnDetail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnDetail.Properties.Appearance.Options.UseBackColor = true;
            this.btnDetail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDetail.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnDetail.Size = new System.Drawing.Size(20, 60);
            this.btnDetail.TabIndex = 12;
            this.btnDetail.Visible = false;
            // 
            // lblRemainTime
            // 
            this.lblRemainTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainTime.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblRemainTime.Location = new System.Drawing.Point(493, 33);
            this.lblRemainTime.Name = "lblRemainTime";
            this.lblRemainTime.Size = new System.Drawing.Size(50, 14);
            this.lblRemainTime.TabIndex = 15;
            this.lblRemainTime.Text = "00:00:00";
            // 
            // lblTotalSource
            // 
            this.lblTotalSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSource.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalSource.Location = new System.Drawing.Point(579, 31);
            this.lblTotalSource.Name = "lblTotalSource";
            this.lblTotalSource.Size = new System.Drawing.Size(19, 14);
            this.lblTotalSource.TabIndex = 16;
            this.lblTotalSource.Text = "1/1";
            // 
            // DownLoadTaskItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblTotalSource);
            this.Controls.Add(this.lblRemainTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbItemImage);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pgbTotal);
            this.Name = "DownLoadTaskItem";
            this.Size = new System.Drawing.Size(800, 65);
            ((System.ComponentModel.ISupportInitialize)(this.pgbTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl pgbTotal;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.PictureEdit btnDetail;
        private DevExpress.XtraEditors.PictureEdit pbItemImage;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblRemainTime;
        private DevExpress.XtraEditors.LabelControl lblTotalSource;
    }
}
