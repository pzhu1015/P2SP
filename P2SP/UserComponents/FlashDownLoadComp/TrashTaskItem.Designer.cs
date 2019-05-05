namespace UserComponents.FlashDownLoadComp
{
    partial class TrashTaskItem
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
            this.lblCreateTime = new DevExpress.XtraEditors.LabelControl();
            this.pbItemImage = new DevExpress.XtraEditors.PictureEdit();
            this.pbItemDelete = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemDelete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(57, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 14);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "FileName";
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrashTaskItem_MouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.TrashTaskItem_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.TrashTaskItem_MouseLeave);
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblSize.Location = new System.Drawing.Point(665, 15);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(31, 14);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "Total";
            this.lblSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrashTaskItem_MouseDown);
            this.lblSize.MouseEnter += new System.EventHandler(this.TrashTaskItem_MouseEnter);
            this.lblSize.MouseLeave += new System.EventHandler(this.TrashTaskItem_MouseLeave);
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateTime.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblCreateTime.Location = new System.Drawing.Point(761, 15);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(118, 14);
            this.lblCreateTime.TabIndex = 10;
            this.lblCreateTime.Text = "2018-04-02 00:00:00";
            this.lblCreateTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrashTaskItem_MouseDown);
            this.lblCreateTime.MouseEnter += new System.EventHandler(this.TrashTaskItem_MouseEnter);
            this.lblCreateTime.MouseLeave += new System.EventHandler(this.TrashTaskItem_MouseLeave);
            // 
            // pbItemImage
            // 
            this.pbItemImage.Location = new System.Drawing.Point(10, 3);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Properties.AllowFocused = false;
            this.pbItemImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbItemImage.Properties.Appearance.Options.UseBackColor = true;
            this.pbItemImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbItemImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbItemImage.Properties.ShowMenu = false;
            this.pbItemImage.Size = new System.Drawing.Size(40, 40);
            this.pbItemImage.TabIndex = 11;
            this.pbItemImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrashTaskItem_MouseDown);
            this.pbItemImage.MouseEnter += new System.EventHandler(this.TrashTaskItem_MouseEnter);
            this.pbItemImage.MouseLeave += new System.EventHandler(this.TrashTaskItem_MouseLeave);
            // 
            // pbItemDelete
            // 
            this.pbItemDelete.EditValue = global::UserComponents.FlashDownLoadResource.delete_16;
            this.pbItemDelete.Location = new System.Drawing.Point(20, 20);
            this.pbItemDelete.Name = "pbItemDelete";
            this.pbItemDelete.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbItemDelete.Properties.Appearance.Options.UseBackColor = true;
            this.pbItemDelete.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbItemDelete.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbItemDelete.Size = new System.Drawing.Size(20, 20);
            this.pbItemDelete.TabIndex = 13;
            this.pbItemDelete.Visible = false;
            // 
            // TrashTaskItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbItemDelete);
            this.Controls.Add(this.pbItemImage);
            this.Controls.Add(this.lblCreateTime);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblName);
            this.Name = "TrashTaskItem";
            this.Size = new System.Drawing.Size(965, 46);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemDelete.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.LabelControl lblCreateTime;
        private DevExpress.XtraEditors.PictureEdit pbItemImage;
        private DevExpress.XtraEditors.PictureEdit pbItemDelete;
    }
}
