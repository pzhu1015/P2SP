namespace SQLUserControl
{
    partial class ViewListView
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
            this.tsView = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDesignView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNewView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExportView = new System.Windows.Forms.ToolStripButton();
            this.lvMain = new System.Windows.Forms.ListView();
            this.tsView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsView
            // 
            this.tsView.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsView.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenView,
            this.tsbtnDesignView,
            this.tsbtnNewView,
            this.tsbtnDeleteView,
            this.tsbtnExportView});
            this.tsView.Location = new System.Drawing.Point(0, 0);
            this.tsView.Name = "tsView";
            this.tsView.Padding = new System.Windows.Forms.Padding(0);
            this.tsView.Size = new System.Drawing.Size(706, 25);
            this.tsView.TabIndex = 2;
            this.tsView.Text = "tsView";
            // 
            // tsbtnOpenView
            // 
            this.tsbtnOpenView.Image = global::SQLUserControl.Resource.open_view_16;
            this.tsbtnOpenView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenView.Name = "tsbtnOpenView";
            this.tsbtnOpenView.Size = new System.Drawing.Size(76, 22);
            this.tsbtnOpenView.Text = "打开视图";
            // 
            // tsbtnDesignView
            // 
            this.tsbtnDesignView.Image = global::SQLUserControl.Resource.design_view_16;
            this.tsbtnDesignView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDesignView.Name = "tsbtnDesignView";
            this.tsbtnDesignView.Size = new System.Drawing.Size(76, 22);
            this.tsbtnDesignView.Text = "设计视图";
            // 
            // tsbtnNewView
            // 
            this.tsbtnNewView.Image = global::SQLUserControl.Resource.new_view_16;
            this.tsbtnNewView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewView.Name = "tsbtnNewView";
            this.tsbtnNewView.Size = new System.Drawing.Size(76, 22);
            this.tsbtnNewView.Text = "新建视图";
            // 
            // tsbtnDeleteView
            // 
            this.tsbtnDeleteView.Image = global::SQLUserControl.Resource.delete_view_16;
            this.tsbtnDeleteView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteView.Name = "tsbtnDeleteView";
            this.tsbtnDeleteView.Size = new System.Drawing.Size(76, 22);
            this.tsbtnDeleteView.Text = "删除视图";
            // 
            // tsbtnExportView
            // 
            this.tsbtnExportView.Image = global::SQLUserControl.Resource.export_view_16;
            this.tsbtnExportView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExportView.Name = "tsbtnExportView";
            this.tsbtnExportView.Size = new System.Drawing.Size(76, 22);
            this.tsbtnExportView.Text = "导出向导";
            // 
            // lvMain
            // 
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMain.Location = new System.Drawing.Point(0, 25);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(706, 470);
            this.lvMain.TabIndex = 3;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMain_ItemSelectionChanged);
            // 
            // ViewListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.tsView);
            this.Name = "ViewListView";
            this.Size = new System.Drawing.Size(706, 495);
            this.tsView.ResumeLayout(false);
            this.tsView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsView;
        private System.Windows.Forms.ToolStripButton tsbtnOpenView;
        private System.Windows.Forms.ToolStripButton tsbtnDesignView;
        private System.Windows.Forms.ToolStripButton tsbtnNewView;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteView;
        private System.Windows.Forms.ToolStripButton tsbtnExportView;
        private System.Windows.Forms.ListView lvMain;
    }
}
