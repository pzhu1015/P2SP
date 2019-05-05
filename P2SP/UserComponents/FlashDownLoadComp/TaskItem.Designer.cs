namespace UserComponents.FlashDownLoadComp
{
    partial class TaskItem
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
            this.SuspendLayout();
            // 
            // TaskItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "TaskItem";
            this.Size = new System.Drawing.Size(800, 72);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskItem_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TaskItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TaskItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
