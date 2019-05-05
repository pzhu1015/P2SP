using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserComponents.FlashDownLoadComp
{
    public class TrashTaskPanel : TaskPanel
    {
        public TrashTaskPanel()
            :
            base()
        {
            this.itemType = TaskItemType.Trash;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TrashTaskPanel
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
