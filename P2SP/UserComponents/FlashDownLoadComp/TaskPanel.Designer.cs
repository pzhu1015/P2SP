namespace UserComponents.FlashDownLoadComp
{
    partial class TaskPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.vsbRight = new DevExpress.XtraEditors.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // vsbRight
            // 
            this.vsbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbRight.Location = new System.Drawing.Point(181, 2);
            this.vsbRight.Name = "vsbRight";
            this.vsbRight.Size = new System.Drawing.Size(17, 96);
            this.vsbRight.SmallChange = 10;
            this.vsbRight.TabIndex = 0;
            this.vsbRight.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbRight_Scroll);
            // 
            // TaskPanel
            // 
            this.AllowTouchScroll = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoSize = true;
            this.Controls.Add(this.vsbRight);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.VScrollBar vsbRight;
    }
}
