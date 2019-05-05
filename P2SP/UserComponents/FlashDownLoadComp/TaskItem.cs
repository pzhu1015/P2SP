using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helper;
using UserComponents.DownLoadService;

namespace UserComponents.FlashDownLoadComp
{
    
    public enum TaskItemType
    {
        DownLoad,
        Complete,
        Trash
    }

    public delegate void ItemMouseDownHandler(object sender, MouseEventArgs e);
    public partial class TaskItem : DevExpress.XtraEditors.XtraUserControl
    {
        protected bool isSelected = false;
        protected TaskItemType itemType;
        protected string itemName = "";
        protected string itemExtension = "";
        protected Image itemImage = null;
        protected long itemSize = 0;
        protected long itemSpeed = 0;
        protected long itemDownLoadSize = 0;
        protected int itemProgress = 0;
        protected int itemRemainSecond = 0;
        protected DateTime itemCreateTime = DateTime.Now;
        protected TaskStatus itemStatus = TaskStatus.Stop;
        protected DownLoadTask task;
        protected bool itemIsDeleted;

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
            }
        }

        public TaskItemType ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
                this.SetItemName();
                this.SetItemExtension();
                this.SetItemImage();
            }
        }

        public Image ItemImage
        {
            get
            {
                return itemImage;
            }

            set
            {
                itemImage = value;
                this.SetItemImage();
            }
        }

        public long ItemSize
        {
            get
            {
                return itemSize;
            }

            set
            {
                itemSize = value;
                this.SetItemSize();
            }
        }

        public long ItemDownLoadSize
        {
            get
            {
                return itemDownLoadSize;
            }

            set
            {
                itemDownLoadSize = value;
                this.SetItemDownLoadSize();
            }
        }

        public int ItemProgress
        {
            get
            {
                return itemProgress;
            }

            set
            {
                itemProgress = value;
                this.SetItemProgress();
            }
        }

        public DateTime ItemCreateTime
        {
            get
            {
                return itemCreateTime;
            }

            set
            {
                itemCreateTime = value;
                this.SetItemCreateTime();
            }
        }

        public TaskStatus ItemStatus
        {
            get
            {
                return itemStatus;
            }

            set
            {
                itemStatus = value;
                this.SetItemStatus();
            }
        }

        public long ItemSpeed
        {
            get
            {
                return itemSpeed;
            }

            set
            {
                itemSpeed = value;
                this.SetItemSpeed();
            }
        }

        public string ItemExtenstion
        {
            get
            {
                return itemExtension;
            }

            set
            {
                itemExtension = value;
            }
        }

        public int ItemRemainSecond
        {
            get
            {
                return itemRemainSecond;
            }

            set
            {
                itemRemainSecond = value;
                this.SetItemRemainTime();
            }
        }

        public DownLoadTask Task
        {
            get
            {
                return task;
            }

            set
            {
                task = value;
            }
        }

        public bool ItemIsDeleted
        {
            get
            {
                return itemIsDeleted;
            }

            set
            {
                itemIsDeleted = value;
                this.setItemIsDeleted();
            }
        }

        public virtual void setItemIsDeleted()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemExtension()
        {
            int idx = this.itemName.LastIndexOf('.');
            if (idx > 0)
            {
                this.itemExtension = this.itemName.Substring(idx);
            }
        }
        public virtual void SetItemSize()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemImage()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemName()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemCreateTime()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemDownLoadSize()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemStatus()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemSpeed()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemProgress()
        {
            throw new NotImplementedException();
        }

        public virtual void SetItemRemainTime()
        {
            throw new NotImplementedException();
        }

        public event ItemMouseDownHandler ItemMouseDown;

        public TaskItem()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        protected virtual void OnItemMouseDown(MouseEventArgs e)
        {

            if (this.ItemMouseDown != null)
            {
                this.ItemMouseDown(this, e);
            }
        }

        public virtual void Selected(bool _show)
        {
            this.isSelected = true;
            this.BackColor = Color.LightSkyBlue;
        }

        public virtual void UnSelected()
        {
            this.isSelected = false;
            this.BackColor = Color.Transparent;
        }

        public virtual void ItemEnter()
        {
            if (this.isSelected)
            {
                return;
            }
            this.BackColor = Color.LightSkyBlue;
        }

        public virtual void ItemLeave()
        {
            if (this.isSelected)
            {
                return;
            }
            this.BackColor = Color.Transparent;
        }

        public void Deleted()
        {

        }

        private void TaskItem_MouseEnter(object sender, EventArgs e)
        {
            this.ItemEnter();
        }

        private void TaskItem_MouseLeave(object sender, EventArgs e)
        {
            this.ItemLeave();
        }

        private void TaskItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnItemMouseDown(e);
        }

        protected string GetDownLoadSize()
        {
            return DiskHelper.GetSize(this.itemDownLoadSize) + "/" + DiskHelper.GetSize(this.itemSize);
        }

        protected Image GetImage()
        {
            try
            {
                Icon smallIcon, largeIcon;
                string desc;
                IconHelper.GetExtsIconAndDescription(this.itemExtension, out largeIcon, out smallIcon, out desc);
                return largeIcon.ToBitmap() as Image;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return null;
            }
        }

        protected string GetSize()
        {
            return DiskHelper.GetSize(this.itemSize);
        }

        protected string GetSpeed()
        {
            return DiskHelper.GetSize(this.itemSpeed) + "/s";
        }
    }
}
