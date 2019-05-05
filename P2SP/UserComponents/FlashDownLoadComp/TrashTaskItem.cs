using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UserComponents.FlashDownLoadComp
{
    public partial class TrashTaskItem : TaskItem
    {
        public TrashTaskItem()
        {
            InitializeComponent();
            this.itemType = TaskItemType.Trash;
            this.pbItemDelete.Parent = this.pbItemImage;
        }

        public override void UnSelected()
        {
            base.UnSelected();
            this.pbItemDelete.Top = this.pbItemImage.Height - this.pbItemDelete.Height;
        }

        public override void Selected(bool _show)
        {
            base.Selected(_show);
            this.pbItemDelete.Top = this.pbItemImage.Height - this.pbItemDelete.Height;
        }

        public void TrashTaskItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnItemMouseDown(e);
        }

        private void TrashTaskItem_MouseEnter(object sender, EventArgs e)
        {
            this.ItemEnter();
        }

        private void TrashTaskItem_MouseLeave(object sender, EventArgs e)
        {
            this.ItemLeave();
        }

        public override void SetItemName()
        {
            this.lblName.Text = this.itemName;
        }

        public override void SetItemImage()
        {
            this.pbItemImage.Image = this.GetImage();
        }

        public override void SetItemCreateTime()
        {
            this.lblCreateTime.Text = this.itemCreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override void SetItemSize()
        {
            this.lblSize.Text = this.GetSize();
        }

        public override void setItemIsDeleted()
        {
            this.pbItemDelete.Visible = this.itemIsDeleted;
            this.pbItemImage.Enabled = !this.itemIsDeleted;
        }
    }
}
