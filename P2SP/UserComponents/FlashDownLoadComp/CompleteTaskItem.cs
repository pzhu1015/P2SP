using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Helper;
using System.IO;

namespace UserComponents.FlashDownLoadComp
{
    public partial class CompleteTaskItem : TaskItem
    {
        public CompleteTaskItem()
        {
            InitializeComponent();
            this.itemType = TaskItemType.Complete;
            this.Height = 56;
            this.lblName.Text = "";
            this.lblSize.Text = "";
            this.pbItemDelete.Parent = this.pbItemImage;
        }

        public override void Selected(bool _show)
        {
            base.Selected(_show);
            if (_show)
            {
                this.btnDetail.Visible = true;
                this.btnOpen.Visible = true;
                this.btnOpenDir.Visible = true;
                this.Height = 90;
                this.pbItemImage.Top = 24;
                this.pbItemDelete.Top = this.pbItemImage.Height - this.pbItemDelete.Height;
            }
            else
            {
                this.btnDetail.Visible = false;
                this.btnOpen.Visible = false;
                this.btnOpenDir.Visible = false;
                this.Height = 56;
            }
            this.CheckIsDelete();
        }

        private void CheckIsDelete()
        {
            if (!File.Exists(this.task.FullName))
            {
                this.ItemIsDeleted = true;
            }
            else
            {
                this.ItemIsDeleted = false;
            }
        }

        public override void UnSelected()
        {
            base.UnSelected();
            this.btnDetail.Visible = false;
            this.btnOpen.Visible = false;
            this.btnOpenDir.Visible = false;
            this.Height = 56;
            this.pbItemImage.Top = 10;
            this.pbItemDelete.Top = this.pbItemImage.Height - this.pbItemDelete.Height;
            this.CheckIsDelete();
        }

        public void CompleteTaskItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnItemMouseDown(e);
        }

        private void CompleteTaskItem_MouseEnter(object sender, EventArgs e)
        {
            this.ItemEnter();
        }

        private void CompleteTaskItem_MouseLeave(object sender, EventArgs e)
        {
            this.ItemLeave();
        }

        public override void SetItemImage()
        {
            this.pbItemImage.Image = this.GetImage();
        }

        public override void SetItemName()
        {
            this.lblName.Text = this.itemName;
        }

        public override void SetItemSize()
        {
            this.lblSize.Text = this.GetSize();
        }

        public override void SetItemCreateTime()
        {
            this.lblCreateTime.Text = this.itemCreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override void setItemIsDeleted()
        {
            this.pbItemDelete.Visible = this.itemIsDeleted;
            this.pbItemImage.Enabled = !this.itemIsDeleted;
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", task.Directory);
        }
    }
}
