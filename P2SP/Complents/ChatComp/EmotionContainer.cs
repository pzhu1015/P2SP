using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Complents.ChatComp
{
    #region EmotionContainer
    [Designer(typeof(EmotionContainerDesigner))]
    [ToolboxBitmap(typeof(PictureBox))]
    [DefaultProperty("Items"), DefaultEvent("ItemClick")]
    public class EmotionContainer : Panel
    {
        #region 变量

        private static readonly int defaultGridSize = 38;
        private int _gridSize;
        private ToolTip _toolTip;
        private bool _showToolTips;
        private EmotionItemCollection _items;
        private GifBox _pictrueBox;
        private EmotionItem _hoverItem;
        private int _row = 10;
        private int _columns = 8;

        private static readonly object EventItemClick = new object();

        #endregion

        #region Event

        public event EmotionItemMouseEventHandler ItemClick
        {
            add { base.Events.AddHandler(EventItemClick, value); }
            remove { base.Events.RemoveHandler(EventItemClick, value); }
        }

        #endregion

        #region 构造函数

        public EmotionContainer()
            : base()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.CacheText |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.FixedHeight |
                ControlStyles.FixedWidth |
                ControlStyles.ResizeRedraw, true);
            base.ForeColor = Color.Gainsboro;
            base.AutoScroll = false;
            _gridSize = DefaultGridSize;
            Controls.Add(PictureBox);
        }

        #endregion

        #region 属性

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public EmotionItemCollection Items
        {
            get
            {
                if (_items == null)
                    _items = new EmotionItemCollection(this);
                return _items;
            }
        }

        [DefaultValue(38)]
        public virtual int GridSize
        {
            get
            {
                return _gridSize;
            }
            set
            {
                if (value != _gridSize)
                {
                    _gridSize = value;
                    ValidateSize();
                    ComputeItemsRectangle();
                }
            }
        }

        [DefaultValue(false)]
        public virtual bool ShowToolTips
        {
            get
            {
                return _showToolTips;
            }
            set
            {
                if (value != _showToolTips)
                {
                    _showToolTips = value;
                    if (!value)
                    {
                        ToolTip.RemoveAll();
                    }
                }
            }
        }

        [DefaultValue(10)]
        public int Row
        {
            get { return _row; }
            set 
            {
                _row = value < 5 ? 5 : value;
                Width = _gridSize * _row;
                base.Invalidate();
            }
        }
        
        [DefaultValue(8)]
        public int Columns
        {
            get { return _columns; }
            set
            {
                _columns = value < 5 ? 5 : value;
                Height = _gridSize * _columns;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Gainsboro")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = false;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(defaultGridSize * _row, defaultGridSize * _columns);
            }
        }

        protected virtual int DefaultGridSize
        {
            get { return defaultGridSize; }
        }

        internal ToolTip ToolTip
        {
            get
            {
                if (_toolTip == null)
                {
                    _toolTip = new ToolTip();
                    _toolTip.ShowAlways = true;
                    _toolTip.UseAnimation = false;
                    _toolTip.UseFading = false;
                    _toolTip.IsBalloon = false;
                }
                return _toolTip;
            }
        }

        private GifBox PictureBox
        {
            get
            {
                if (_pictrueBox == null)
                {
                    _pictrueBox = new GifBox();
                    _pictrueBox.Visible = false;
                    _pictrueBox.Location = new Point(2, 2);
                    _pictrueBox.Size = new Size(72, 72);
                }
                return _pictrueBox;
            }
        }

        #endregion

        #region 重载

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ComputeItemsRectangle();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            DrawGrid(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (EmotionItem item in Items)
            {
                if (item.Bitmap != null)
                {
                    e.Graphics.DrawImage(
                        item.Bitmap,
                        item.ClientRectangle,
                        0,
                        0,
                        item.Bitmap.Width,
                        item.Bitmap.Height,
                        GraphicsUnit.Pixel);
                }
                if (item.Honer)
                {
                    ControlPaint.DrawBorder(
                        e.Graphics,
                        item.Bounds,
                        Color.Blue,
                        ButtonBorderStyle.Solid);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool bHover = false;

            SetPictureBoxLocation(e.Location);
            foreach (EmotionItem item in Items)
            {
                if (item.Bounds.Contains(e.Location))
                {
                    if (item != _hoverItem)
                    {
                        if (_hoverItem != null)
                            _hoverItem.Honer = false;
                        _hoverItem = item;
                        item.Honer = true;
                        ShowPictureBox(item);

                        if (_showToolTips && !string.IsNullOrEmpty(item.ToolTip))
                        {
                            ToolTip.SetToolTip(this, item.ToolTip);
                        }
                    }
                    bHover = true;
                    break;
                }
            }
            if (!bHover)
            {
                if (_hoverItem != null)
                {
                    _hoverItem.Honer = false;
                    _hoverItem = null;
                }
                ToolTip.RemoveAll();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverItem != null)
            {
                _hoverItem.Honer = false;
                _hoverItem = null;
            }

            HidePictureBox();
            ToolTip.RemoveAll();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (_hoverItem != null)
                {
                    OnItemClick(new EmotionItemMouseClickEventArgs(_hoverItem, e));
                }
            }
        }

        protected virtual void OnItemClick(EmotionItemMouseClickEventArgs e)
        {
            EmotionItemMouseEventHandler handler =
                base.Events[EventItemClick] as EmotionItemMouseEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (!(e.Control is GifBox))
                throw new ArgumentException(string.Format(
                    "Can't add {0}.",
                    e.Control.GetType().ToString()),
                    "e.Control");
            base.OnControlAdded(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _items = null;
                if (_pictrueBox != null)
                {
                    _pictrueBox = null;
                }
                if (_hoverItem != null)
                {
                    _hoverItem = null;
                }
                if (_toolTip != null)
                {
                    _toolTip = null;
                }
            }
        }

        #endregion

        #region 函数

        private void ValidateSize()
        {
            Size = new Size(_gridSize * _row, _gridSize * _columns);
        }

        private void DrawGrid(PaintEventArgs e)
        {
            /* 10 * 6  36 * 10/36 * 6*/
            using (Pen pen = new Pen(ForeColor))
            {
                for (int i = _gridSize; i < this.Width; i += _gridSize)
                {
                    e.Graphics.DrawLine(pen,
                        i,
                        0,
                        i,
                        Height);
                }
                for (int i = _gridSize; i < this.Height; i += _gridSize)
                {
                    e.Graphics.DrawLine(pen,
                        0,
                        i,
                        Width,
                        i);
                }
            }

            ControlPaint.DrawBorder(e.Graphics,
                ClientRectangle,
                ForeColor,
                ButtonBorderStyle.Solid);
        }

        internal void ComputeItemsRectangle()
        {
            for (int index = 0; index < Items.Count; index++)
            {
                ComputeItemRectangle(Items[index], index);
            }
        }

        internal void ComputeItemRectangle(EmotionItem item, int index)
        {
            int cell = (index + 1) % _row;
            int row = (index + 1) / _row;

            if (cell == 0)
            {
                cell = _row;
                row -= 1;
            }

            Rectangle rect = new Rectangle(
                ClientRectangle.X + (cell - 1) * _gridSize + 4,
                ClientRectangle.Y + row * _gridSize + 4,
                _gridSize - 8,
                _gridSize - 8);
            item.ClientRectangle = rect;
            rect.Inflate(2, 2);
            item.Bounds = rect;
        }

        internal void ComputeItemRectangle(EmotionItem item)
        {
            ComputeItemRectangle(item, Items.IndexOf(item));
        }

        private void SetPictureBoxLocation(Point point)
        {
        	int scrollH = 0;
        	if (this.Parent is TabPage)
        	{
        		scrollH = ((TabPage)this.Parent).AutoScrollPosition.Y;
        	}
            if (point.X > Width - PictureBox.Width - 52)
            {
            	PictureBox.Location = new Point(2, 2 - scrollH);
            }
            else if (point.X < PictureBox.Width + 52)
            {
                PictureBox.Location = new Point(Width - PictureBox.Width - 2, 2 - scrollH);
            }
        }

        private void ShowPictureBox(EmotionItem item)
        {
            PictureBox.Image = item.Image;
            if (!PictureBox.Visible)
            {
                PictureBox.Visible = true;
            }
        }

        private void HidePictureBox()
        {
            if (PictureBox.Visible)
            {
                PictureBox.Image = null;
                PictureBox.Visible = false;
            }
        }

        #endregion

        #region EmotionItemCollection

        public class EmotionItemCollection :
            ItemCollectionBase<EmotionContainer, EmotionItem>
        {
            protected EmotionItemCollection() { }

            public EmotionItemCollection(EmotionContainer owner)
                : base(owner)
            {
            }

            public override void Add(EmotionItem item)
            {
                if (item == null)
                    throw new ArgumentNullException("item");
                item.Owner = base.Owner;
                base.List.Add(item);
            }

            public override void Insert(int index, EmotionItem item)
            {
                if (item == null)
                    throw new ArgumentNullException("item");
                item.Owner = Owner;
                base.List.Insert(index, item);
            }
        }

        #endregion
    }

    #endregion

    #region EmotionContainerDesigner

    internal class EmotionContainerDesigner : PanelDesigner
    {
        private DesignerActionListCollection _actionLists;

        public EmotionContainerDesigner()
            : base()
        {
        }

        public override bool CanParent(Control control)
        {
            if (control != null)
                return control is GifBox;
            return false;
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = base.ActionLists;
                    _actionLists.Add(new EmotionContainerActionList(this));
                }
                return _actionLists;
            }
        }

        internal class EmotionContainerActionList : DesignerActionList
        {
            private EmotionContainerDesigner _designer;

            public EmotionContainerActionList(EmotionContainerDesigner designer)
                : base(designer.Component)
            {
                this._designer = designer;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();

                items.Add(new DesignerActionMethodItem(
                this,
                "InvokeItemDialog",
                "编辑项...",
                true));

                return items;
            }

            public void InvokeItemDialog()
            {
                EditorServiceContext.EditValue(_designer, base.Component, "Items");
            }
        }
    }

    #endregion
}
