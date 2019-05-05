using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserComponents.FlashDownLoadComp
{
    public class CompleteTaskPanel: TaskPanel
    {
        public CompleteTaskPanel()
            :
            base()
        {
            this.itemType = TaskItemType.Complete;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CompleteTaskPanel
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
