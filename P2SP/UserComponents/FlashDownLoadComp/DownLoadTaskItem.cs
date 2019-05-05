using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Helper;
using System.IO;
using UserComponents.DownLoadService;

namespace UserComponents.FlashDownLoadComp
{
    public partial class DownLoadTaskItem : TaskItem
    {


        public DownLoadTaskItem()
        {
            InitializeComponent();

            this.itemType = TaskItemType.DownLoad;
            this.pgbTotal.Text = "0";
            this.lblName.Text = "";
            this.lblSize.Text = "";
        }


        public override void Selected(bool _show)
        {
            base.Selected(_show);
            if (_show)
            {
                this.btnDetail.Visible = true;
            }
            else
            {
                this.btnDetail.Visible = false;
            }
        }

        public override void UnSelected()
        {
            base.UnSelected();
            this.btnDetail.Visible = false;
        }

        public void DownLoadTaskItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnItemMouseDown(e);
        }

        private void DownLoadTaskItem_MouseEnter(object sender, EventArgs e)
        {
            this.ItemEnter();
        }

        private void DownLoadTaskItem_MouseLeave(object sender, EventArgs e)
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

        public override void SetItemDownLoadSize()
        {
            this.lblSize.Text = this.GetDownLoadSize();
        }

        public override void SetItemProgress()
        {
            this.pgbTotal.Text = this.itemProgress.ToString();
        }

        public override void SetItemSpeed()
        {
            this.lblStatus.Text = this.GetSpeed();
        }

        public override void SetItemStatus()
        {
            if (this.itemStatus == DownLoadService.TaskStatus.Stop)
            {
                this.lblStatus.ForeColor = Color.Black;
                this.lblStatus.Text = FlashDownLoadResource.stop;
            }
            else if (this.itemStatus == DownLoadService.TaskStatus.Start)
            {
                this.lblStatus.ForeColor = Color.Black;
                this.lblStatus.Text = this.GetSpeed();
            }
            else if (this.itemStatus == DownLoadService.TaskStatus.Finish)
            {
                this.lblStatus.ForeColor = Color.Black;
                this.lblStatus.Text = FlashDownLoadResource.finish;
            }
            else if (this.itemStatus == DownLoadService.TaskStatus.Wait)
            {
                this.lblStatus.ForeColor = Color.Black;
                this.lblStatus.Text = FlashDownLoadResource.wait;
            }
            else if (this.itemStatus == DownLoadService.TaskStatus.Fail)
            {
                this.lblStatus.Text = FlashDownLoadResource.fail;
                this.lblStatus.ForeColor = Color.Red;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override void SetItemRemainTime()
        {
            TimeSpan ts = new TimeSpan(0, 0, this.itemRemainSecond);
            this.lblRemainTime.Text = ts.ToString();
        }
    }
}
