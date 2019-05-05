namespace SQLUserControl
{
    partial class SelectListView
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
            this.tsSelect = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDesignSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNewSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteSelect = new System.Windows.Forms.ToolStripButton();
            this.lvMain = new System.Windows.Forms.ListView();
            this.tsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsSelect
            // 
            this.tsSelect.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsSelect.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenSelect,
            this.tsbtnDesignSelect,
            this.tsbtnNewSelect,
            this.tsbtnDeleteSelect});
            this.tsSelect.Location = new System.Drawing.Point(0, 0);
            this.tsSelect.Name = "tsSelect";
            this.tsSelect.Padding = new System.Windows.Forms.Padding(0);
            this.tsSelect.Size = new System.Drawing.Size(797, 25);
            this.tsSelect.TabIndex = 3;
            this.tsSelect.Text = "tsSelect";
            // 
            // tsbtnOpenSelect
            // 
            this.tsbtnOpenSelect.Image = global::SQLUserControl.Resource.open_select_16;
            this.tsbtnOpenSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenSelect.Name = "tsbtnOpenSelect";
            this.tsbtnOpenSelect.Size = new System.Drawing.Size(76, 22);
            this.tsbtnOpenSelect.Text = "打开查询";
            // 
            // tsbtnDesignSelect
            // 
            this.tsbtnDesignSelect.Image = global::SQLUserControl.Resource.design_select_16;
            this.tsbtnDesignSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDesignSelect.Name = "tsbtnDesignSelect";
            this.tsbtnDesignSelect.Size = new System.Drawing.Size(76, 22);
            this.tsbtnDesignSelect.Text = "设计查询";
            // 
            // tsbtnNewSelect
            // 
            this.tsbtnNewSelect.Image = global::SQLUserControl.Resource.new_select_16;
            this.tsbtnNewSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewSelect.Name = "tsbtnNewSelect";
            this.tsbtnNewSelect.Size = new System.Drawing.Size(76, 22);
            this.tsbtnNewSelect.Text = "新建查询";
            this.tsbtnNewSelect.Click += new System.EventHandler(this.tsbtnNewSelect_Click);
            // 
            // tsbtnDeleteSelect
            // 
            this.tsbtnDeleteSelect.Image = global::SQLUserControl.Resource.delete_select_16;
            this.tsbtnDeleteSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteSelect.Name = "tsbtnDeleteSelect";
            this.tsbtnDeleteSelect.Size = new System.Drawing.Size(76, 22);
            this.tsbtnDeleteSelect.Text = "删除查询";
            // 
            // lvMain
            // 
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMain.Location = new System.Drawing.Point(0, 25);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(797, 472);
            this.lvMain.TabIndex = 4;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMain_ItemSelectionChanged);
            // 
            // SelectListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.tsSelect);
            this.Name = "SelectListView";
            this.Size = new System.Drawing.Size(797, 497);
            this.tsSelect.ResumeLayout(false);
            this.tsSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSelect;
        private System.Windows.Forms.ToolStripButton tsbtnOpenSelect;
        private System.Windows.Forms.ToolStripButton tsbtnDesignSelect;
        private System.Windows.Forms.ToolStripButton tsbtnNewSelect;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteSelect;
        private System.Windows.Forms.ListView lvMain;
    }
}
