namespace UserComponents.FlashDownLoadComp
{
    partial class CompleteTaskItem
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
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenDir = new DevExpress.XtraEditors.SimpleButton();
            this.lblCreateTime = new DevExpress.XtraEditors.LabelControl();
            this.pbItemImage = new DevExpress.XtraEditors.PictureEdit();
            this.btnDetail = new DevExpress.XtraEditors.PictureEdit();
            this.pbItemDelete = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemDelete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(60, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 14);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "FileName";
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompleteTaskItem_MouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.CompleteTaskItem_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.CompleteTaskItem_MouseLeave);
            // 
            // lblSize
            // 
            this.lblSize.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblSize.Location = new System.Drawing.Point(60, 28);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(28, 14);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Total";
            this.lblSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompleteTaskItem_MouseDown);
            this.lblSize.MouseEnter += new System.EventHandler(this.CompleteTaskItem_MouseEnter);
            this.lblSize.MouseLeave += new System.EventHandler(this.CompleteTaskItem_MouseLeave);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(60, 48);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(46, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "打开";
            this.btnOpen.Visible = false;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(116, 48);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(46, 23);
            this.btnOpenDir.TabIndex = 8;
            this.btnOpenDir.Text = "目录";
            this.btnOpenDir.Visible = false;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateTime.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblCreateTime.Location = new System.Drawing.Point(574, 10);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(118, 14);
            this.lblCreateTime.TabIndex = 9;
            this.lblCreateTime.Text = "2018-04-02 00:00:00";
            this.lblCreateTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompleteTaskItem_MouseDown);
            this.lblCreateTime.MouseEnter += new System.EventHandler(this.CompleteTaskItem_MouseEnter);
            this.lblCreateTime.MouseLeave += new System.EventHandler(this.CompleteTaskItem_MouseLeave);
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
            this.pbItemImage.TabIndex = 10;
            this.pbItemImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompleteTaskItem_MouseDown);
            this.pbItemImage.MouseEnter += new System.EventHandler(this.CompleteTaskItem_MouseEnter);
            this.pbItemImage.MouseLeave += new System.EventHandler(this.CompleteTaskItem_MouseLeave);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetail.EditValue = global::UserComponents.FlashDownLoadResource.detail_16;
            this.btnDetail.Location = new System.Drawing.Point(763, 8);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Properties.AllowFocused = false;
            this.btnDetail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnDetail.Properties.Appearance.Options.UseBackColor = true;
            this.btnDetail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDetail.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnDetail.Size = new System.Drawing.Size(20, 60);
            this.btnDetail.TabIndex = 11;
            this.btnDetail.Visible = false;
            // 
            // pbItemDelete
            // 
            this.pbItemDelete.EditValue = global::UserComponents.FlashDownLoadResource.delete_16;
            this.pbItemDelete.Location = new System.Drawing.Point(20, 20);
            this.pbItemDelete.Name = "pbItemDelete";
            this.pbItemDelete.Properties.AllowFocused = false;
            this.pbItemDelete.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbItemDelete.Properties.Appearance.Options.UseBackColor = true;
            this.pbItemDelete.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbItemDelete.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbItemDelete.Size = new System.Drawing.Size(20, 20);
            this.pbItemDelete.TabIndex = 12;
            this.pbItemDelete.Visible = false;
            // 
            // CompleteTaskItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbItemDelete);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.pbItemImage);
            this.Controls.Add(this.lblCreateTime);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblName);
            this.Name = "CompleteTaskItem";
            this.Size = new System.Drawing.Size(800, 90);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemDelete.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.SimpleButton btnOpenDir;
        private DevExpress.XtraEditors.LabelControl lblCreateTime;
        private DevExpress.XtraEditors.PictureEdit pbItemImage;
        private DevExpress.XtraEditors.PictureEdit btnDetail;
        private DevExpress.XtraEditors.PictureEdit pbItemDelete;
    }
}
