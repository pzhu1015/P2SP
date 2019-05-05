namespace SQLUserControl
{
    partial class TableListView
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
            this.tsTable = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDesignTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNewTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnImportTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExprotTable = new System.Windows.Forms.ToolStripButton();
            this.lvMain = new System.Windows.Forms.ListView();
            this.tsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTable
            // 
            this.tsTable.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsTable.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenTable,
            this.tsbtnDesignTable,
            this.tsbtnNewTable,
            this.tsbtnDeleteTable,
            this.tsbtnImportTable,
            this.tsbtnExprotTable});
            this.tsTable.Location = new System.Drawing.Point(0, 0);
            this.tsTable.Name = "tsTable";
            this.tsTable.Padding = new System.Windows.Forms.Padding(0);
            this.tsTable.Size = new System.Drawing.Size(720, 25);
            this.tsTable.TabIndex = 1;
            this.tsTable.Text = "tsTable";
            // 
            // tsbtnOpenTable
            // 
            this.tsbtnOpenTable.Image = global::SQLUserControl.Resource.open_table_16;
            this.tsbtnOpenTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenTable.Name = "tsbtnOpenTable";
            this.tsbtnOpenTable.Size = new System.Drawing.Size(64, 22);
            this.tsbtnOpenTable.Text = "打开表";
            // 
            // tsbtnDesignTable
            // 
            this.tsbtnDesignTable.Image = global::SQLUserControl.Resource.design_table_16;
            this.tsbtnDesignTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDesignTable.Name = "tsbtnDesignTable";
            this.tsbtnDesignTable.Size = new System.Drawing.Size(64, 22);
            this.tsbtnDesignTable.Text = "设计表";
            this.tsbtnDesignTable.Click += new System.EventHandler(this.tsbtnDesignTable_Click);
            // 
            // tsbtnNewTable
            // 
            this.tsbtnNewTable.Image = global::SQLUserControl.Resource.new_table_16;
            this.tsbtnNewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewTable.Name = "tsbtnNewTable";
            this.tsbtnNewTable.Size = new System.Drawing.Size(64, 22);
            this.tsbtnNewTable.Text = "新建表";
            // 
            // tsbtnDeleteTable
            // 
            this.tsbtnDeleteTable.Image = global::SQLUserControl.Resource.delete_table_16;
            this.tsbtnDeleteTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteTable.Name = "tsbtnDeleteTable";
            this.tsbtnDeleteTable.Size = new System.Drawing.Size(64, 22);
            this.tsbtnDeleteTable.Text = "删除表";
            // 
            // tsbtnImportTable
            // 
            this.tsbtnImportTable.Image = global::SQLUserControl.Resource.import_table_16;
            this.tsbtnImportTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnImportTable.Name = "tsbtnImportTable";
            this.tsbtnImportTable.Size = new System.Drawing.Size(76, 22);
            this.tsbtnImportTable.Text = "导入向导";
            // 
            // tsbtnExprotTable
            // 
            this.tsbtnExprotTable.Image = global::SQLUserControl.Resource.export_table_16;
            this.tsbtnExprotTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExprotTable.Name = "tsbtnExprotTable";
            this.tsbtnExprotTable.Size = new System.Drawing.Size(76, 22);
            this.tsbtnExprotTable.Text = "导出向导";
            // 
            // lvMain
            // 
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMain.Location = new System.Drawing.Point(0, 25);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(720, 452);
            this.lvMain.TabIndex = 2;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMain_ItemSelectionChanged);
            this.lvMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvMain_MouseDoubleClick);
            // 
            // TableListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.tsTable);
            this.DoubleBuffered = true;
            this.Name = "TableListView";
            this.Size = new System.Drawing.Size(720, 477);
            this.tsTable.ResumeLayout(false);
            this.tsTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTable;
        private System.Windows.Forms.ToolStripButton tsbtnOpenTable;
        private System.Windows.Forms.ToolStripButton tsbtnDesignTable;
        private System.Windows.Forms.ToolStripButton tsbtnNewTable;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteTable;
        private System.Windows.Forms.ToolStripButton tsbtnImportTable;
        private System.Windows.Forms.ToolStripButton tsbtnExprotTable;
        private System.Windows.Forms.ListView lvMain;
    }
}
