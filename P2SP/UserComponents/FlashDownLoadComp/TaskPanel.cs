using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Helper;
using DevExpress.XtraEditors;

namespace UserComponents.FlashDownLoadComp
{
    public enum TaskItemSortedType
    {
        eTime,
        eExtension,
        eStatus,
        eName,
        eSize,
        eProgress
    }
    public delegate void SelectedItemsChangedHandler(object sender, EventArgs e);
    public delegate void SelectedItemsMouseRightDownHandler(object sender, MouseEventArgs e);
    public partial class TaskPanel : PanelControl
    {
        [Browsable(true)]
        [Description("当选中项个数发生改变时触发")]
        public event SelectedItemsChangedHandler SelectedItemsChanged;

        [Browsable(true)]
        [Description("当选中项鼠标右击时触发")]
        public event SelectedItemsMouseRightDownHandler SelectedItemsMouseRightDown;

        private int realY = 0;
        private int realHeight = 0;
        private bool mouseIsDown = false;
        private Rectangle mouseRect = Rectangle.Empty;
        protected TaskItemType itemType;
        private TaskItemSortedType itemSortedType = TaskItemSortedType.eTime;

        private List<TaskItem> items = new List<TaskItem>();
        private List<TaskItem> selectedItems = new List<TaskItem>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content/*可修改*/), MergableProperty(false)]
        public List<TaskItem> SelectedItems
        {
            get
            {
                return selectedItems;
            }

            set
            {
                selectedItems = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content/*可修改*/), MergableProperty(false)]
        public List<TaskItem> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }

        protected TaskItemSortedType ItemSortedType
        {
            get
            {
                return itemSortedType;
            }

            set
            {
                itemSortedType = value;
            }
        }

        public TaskPanel()
        {
            InitializeComponent();
            this.MouseDown += TaskPanel_MouseDown;
            this.MouseUp += TaskPanel_MouseUp;
            this.MouseMove += TaskPanel_MouseMove;
            this.SizeChanged += TaskPanel_SizeChanged;
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void TaskPanel_SizeChanged(object sender, EventArgs e)
        {
            foreach (TaskItem t in this.items)
            {
                t.Width = this.Width - this.vsbRight.Width;
            }
        }

        private void TaskPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseIsDown)
            {
                ResizeToRectangle(e.Location);
            }
        }

        private void TaskPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Cursor.Clip = Rectangle.Empty;
            this.mouseIsDown = false;
            DrawRectangle();
            Rectangle rect = new Rectangle(
                this.mouseRect.X + this.mouseRect.Width,
                this.mouseRect.Y + this.mouseRect.Height,
                Math.Abs(this.mouseRect.Width),
                Math.Abs(this.mouseRect.Height));
            foreach (TaskItem t in this.items)
            {
                LogHelper.loginfo.Info(rect.ToString() + ":" + t.Bounds.ToString());
                
                if (rect.IntersectsWith(t.Bounds))
                {
                    if (!this.selectedItems.Contains(t))
                    {
                        t.Selected(false);
                        this.AddSelectedItem(t);
                    }
                }
                else
                {
                    if (this.selectedItems.Contains(t))
                    {
                        t.UnSelected();
                        this.RemoveSelectedItem(t);
                    }
                }
            }
            this.LayOutItem();
            this.OnSelectedItemsChanged(new EventArgs());
            this.mouseRect = Rectangle.Empty;
        }

        private void TaskPanel_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (TaskItem t in this.selectedItems)
            {
                t.UnSelected();
            }
            this.ClearSelectedItem();
            this.LayOutItem();

            this.mouseIsDown = true;
            this.DrawStart(e.Location);
            this.OnSelectedItemsChanged(new EventArgs());
        }

        protected void OnSelectedItemsChanged(EventArgs e)
        {
            if (this.SelectedItemsChanged != null)
            {
                this.SelectedItemsChanged(this, e);
            }
        }

        protected void OnSelectedItemMouseRightDown(MouseEventArgs e)
        {
            if (this.SelectedItemsMouseRightDown != null)
            {
                this.SelectedItemsMouseRightDown(this, e);
            }
        }

        private void DrawStart(Point location)
        {
            this.Capture = true;
            Cursor.Clip = this.RectangleToScreen(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            this.mouseRect = new Rectangle(location.X, location.Y, 0, 0);

        }

        private void DrawRectangle()
        {
            Rectangle rect = this.RectangleToScreen(this.mouseRect);
            ControlPaint.DrawReversibleFrame(rect, Color.LightSkyBlue, FrameStyle.Dashed);
        }

        private void ResizeToRectangle(Point location)
        {
            this.DrawRectangle();
            this.mouseRect.Width = location.X - this.mouseRect.Left;
            this.mouseRect.Height = location.Y - this.mouseRect.Top;
            this.DrawRectangle();
        }

        public void AddControls(TaskItem control)
        {
            control.SetBounds(0, this.items.Count * (control.Height + 1), this.Width - this.vsbRight.Width, control.Height);
            control.ItemMouseDown += Control_ItemMouseDown;
            this.items.Add(control);
            this.Controls.Add(control);
            this.realHeight += control.Top + control.Height;
            this.LayOutItem();
        }

        public void RemoveControls(TaskItem control)
        {
            this.items.Remove(control);
            this.Controls.Remove(control);
            this.LayOutItem();
        }

        private void Control_ItemMouseOut(object sender, EventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            taskItem.ItemLeave();
        }

        private void Control_ItemMouseOver(object sender, EventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            taskItem.ItemEnter();
        }

        private void Control_ItemMouseDown(object sender, MouseEventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
            {
                if (this.selectedItems.Contains(taskItem))
                {
                    taskItem.UnSelected();
                    this.RemoveSelectedItem(taskItem);
                }
                else
                {
                    taskItem.Selected(true);
                    this.AddSelectedItem(taskItem);
                    if (this.selectedItems.Count > 1)
                    {
                        foreach (TaskItem t in this.selectedItems)
                        {
                            t.Selected(false);
                        }
                    }
                }
            }
            else
            {

                foreach (TaskItem t in this.selectedItems)
                {
                    t.UnSelected();
                }
                this.ClearSelectedItem();
                taskItem.Selected(true);
                this.AddSelectedItem(taskItem);
            }
            this.LayOutItem();
            if (e.Button == MouseButtons.Right)
            {
                this.OnSelectedItemMouseRightDown(e);
            }
            this.OnSelectedItemsChanged(new EventArgs());
        }

        public void DeleteSelectedItem()
        {
            foreach(TaskItem t in this.selectedItems)
            {
                t.Deleted();
                this.items.Remove(t);
                this.Controls.Remove(t);
            }
            this.selectedItems.Clear();
            this.LayOutItem();
        }

        private void LayOutItem()
        {
            this.Hide();
            this.realHeight = 0;
            int y = this.realY;
            for (int i = 0; i < this.items.Count; i++)
            {
                TaskItem item = this.items[i];
                if (i == 0)
                {
                    item.SetBounds(0, y, item.Width, item.Height);
                    this.realHeight += item.Height;
                }
                else
                {
                    y += this.items[i - 1].Height + 1;
                    item.SetBounds(0, y, item.Width, item.Height);
                    this.realHeight += item.Height + 1;
                }
            }
            this.Show();
            this.SetVScrollBar();
        }

        private void AddSelectedItem(TaskItem item)
        {
            this.selectedItems.Add(item);
        }

        private void RemoveSelectedItem(TaskItem item)
        {
            this.selectedItems.Remove(item);
        }

        private void ClearSelectedItem()
        {
            this.selectedItems.Clear();
        }

        public void Sort()
        {
            switch (this.itemSortedType)
            {
                case TaskItemSortedType.eName:
                    this.items = this.items.OrderBy(t => t.ItemName).ToList();
                    break;
                case TaskItemSortedType.eTime:
                    this.items = this.items.OrderBy(t => t.ItemCreateTime).ToList();
                    break;
                case TaskItemSortedType.eExtension:
                    this.items = this.items.OrderBy(t => t.ItemExtenstion).ToList();
                    break;
                case TaskItemSortedType.eSize:
                    this.items = this.items.OrderBy(t => t.ItemSize).ToList();
                    break;
                case TaskItemSortedType.eStatus:
                    this.items = this.items.OrderBy(t => t.ItemStatus).ToList();
                    break;
                case TaskItemSortedType.eProgress:
                    this.items = this.items.OrderBy(t => t.ItemProgress).ToList();
                    break;
            }
            this.LayOutItem();
        }

        private void vsbRight_Scroll(object sender, ScrollEventArgs e)
        {
            this.realY = 0 - this.vsbRight.Value;
            this.LayOutItem();
        }

        private void SetVScrollBar()
        {
            if (this.realHeight > this.Height)
            {
                this.vsbRight.LargeChange = (this.realHeight - this.Height) / 4;
                this.vsbRight.Maximum = this.realHeight - this.Height + this.vsbRight.LargeChange * 2;
            }
        }
    }
}

