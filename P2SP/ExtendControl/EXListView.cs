using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Resources;

using Helper;

namespace ExtendControl 
{
    
    public class EXListView : ListView {
        private int _sortcol; //index of clicked ColumnHeader
        private Brush _sortcolbrush; //color of items in sorted column
        private Brush _highlightbrush; //color of highlighted items
        private int _cpadding; //padding of the embedded controls
            
        private const UInt32 LVM_FIRST = 0x1000;
        private const UInt32 LVM_SCROLL = (LVM_FIRST + 20);
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_PAINT = 0x000F;
            
        private struct EmbeddedControl {
            public Control MyControl;
            public EXControlListViewSubItem MySubItem;
        }
            
        private ArrayList _controls;
            
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, UInt32 m, int wParam, int lParam);
        
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_PAINT) {
                foreach (EmbeddedControl c in _controls) {
                    Rectangle r = c.MySubItem.Bounds;
                    if (r.Y > 0 && r.Y < this.ClientRectangle.Height) {
                        c.MyControl.Visible = true;
                        //c.MyControl.Bounds = new Rectangle(r.X + _cpadding, r.Y + _cpadding, r.Width - (2 * _cpadding), r.Height - (2 * _cpadding));
                        //c.MyControl.Bounds = new Rectangle(r.X + _cpadding, r.Y + _cpadding, r.Width - (2 * _cpadding), c.MyControl.Height);                                          
                        c.MyControl.Bounds = new Rectangle(r.X + _cpadding, r.Y + _cpadding, c.MyControl.Width, c.MyControl.Height);                                          
                    } else {
                        c.MyControl.Visible = false;
                    }
                }
            }
            switch (m.Msg) {
                case WM_HSCROLL:
                case WM_VSCROLL:
                case WM_MOUSEWHEEL:
                    this.Focus();
                    break;
            }
            base.WndProc(ref m);
        }
        
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }

        }
        
        private void ScrollMe(int x, int y) {
            SendMessage((IntPtr) this.Handle, LVM_SCROLL, x, y);
        }
        
        public EXListView() {
            _cpadding = 4;
            _controls = new ArrayList();
            _sortcol = -1;
            _sortcolbrush = SystemBrushes.ControlLight;
            _highlightbrush = SystemBrushes.Highlight;
            this.OwnerDraw = true;
            this.FullRowSelect = true;
            this.View = View.Details;
            this.MouseDown += new MouseEventHandler(this_MouseDown);
            this.MouseMove += new MouseEventHandler(this_MouseMove);
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this_DrawColumnHeader);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(this_DrawSubItem);
            this.ColumnClick += new ColumnClickEventHandler(this_ColumnClick);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
        
        public void AddControlToSubItem(Control control, EXControlListViewSubItem subitem) {
            this.Controls.Add(control);
            subitem.MyControl = control;
            EmbeddedControl ec;
            ec.MyControl = control;
            ec.MySubItem = subitem;
            this._controls.Add(ec);
        }
        
        public void RemoveControlFromSubItem(EXControlListViewSubItem subitem) {
            Control c = subitem.MyControl;
            for (int i = 0; i < this._controls.Count; i++) {
                if (((EmbeddedControl) this._controls[i]).MySubItem == subitem) {
                    this._controls.RemoveAt(i);
                    subitem.MyControl = null;
                    this.Controls.Remove(c);
                    c.Dispose();
                    return;
                }
            }
        }
        
        public int ControlPadding {
            get {return _cpadding;}
            set {_cpadding = value;}
        }
        
        public Brush MySortBrush {
            get {return _sortcolbrush;}
            set {_sortcolbrush = value;}
        }
        
        public Brush MyHighlightBrush {
            get {return _highlightbrush;}
            set {_highlightbrush = value;}
        }
        
        private void this_MouseDown(object sender, MouseEventArgs e) {
            ListViewHitTestInfo lstvinfo = this.HitTest(e.X, e.Y);
            ListViewItem.ListViewSubItem subitem = lstvinfo.SubItem;
            if (subitem == null) return;
            int subx = subitem.Bounds.Left;
            if (subx < 0) {
                this.ScrollMe(subx, 0);
            }
        }
        
        private void this_MouseMove(object sender, MouseEventArgs e) {
            ListViewItem item = this.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag == null) {
                this.Invalidate(item.Bounds);
                item.Tag = "t";
            }
        }
        
        private void this_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            e.DrawDefault = true;
        }
        
        private void this_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
            e.DrawBackground();
            if (e.ColumnIndex == _sortcol) {
                e.Graphics.FillRectangle(_sortcolbrush, e.Bounds);
            }
            if ((e.ItemState & ListViewItemStates.Selected) != 0) {
                e.Graphics.FillRectangle(_highlightbrush, e.Bounds);
            }
            int fonty = e.Bounds.Y + ((int) (e.Bounds.Height / 2)) - ((int) (e.SubItem.Font.Height / 2));
            int x = e.Bounds.X + 2;
            if (e.ColumnIndex == 0) {
                EXListViewItem item = (EXListViewItem) e.Item;
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(e.SubItem.ForeColor), x, fonty);
                return;
            }
            EXListViewSubItemAB subitem = e.SubItem as EXListViewSubItemAB;
            if (subitem == null) {
                e.DrawDefault = true;
            } else {
                x = subitem.DoDraw(e, x, this.Columns[e.ColumnIndex] as EXColumnHeader);                
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(e.SubItem.ForeColor), x, fonty);
            }
        }
        
        private void this_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (this.Items.Count == 0) return;
            for (int i = 0; i < this.Columns.Count; i++) {
                this.Columns[i].ImageKey = null;
            }
            for (int i = 0; i < this.Items.Count; i++) {
                this.Items[i].Tag = null;
            }
            if (e.Column != _sortcol) {
                _sortcol = e.Column;
                this.Sorting = SortOrder.Ascending;
                this.Columns[e.Column].ImageKey = "up";
            } else {
                if (this.Sorting == SortOrder.Ascending) {
                    this.Sorting = SortOrder.Descending;
                    this.Columns[e.Column].ImageKey = "down";
                } else {
                    this.Sorting = SortOrder.Ascending;
                    this.Columns[e.Column].ImageKey = "up";
                }
            }
            if (_sortcol == 0) {
                //ListViewItem
                if (this.Items[0].GetType() == typeof(EXListViewItem)) {
                    //sorting on text
                    this.ListViewItemSorter = new ListViewItemComparerText(e.Column, this.Sorting);
                } else {
                    //sorting on value
                    this.ListViewItemSorter = new ListViewItemComparerValue(e.Column, this.Sorting);
                }
            } else {
                //ListViewSubItem
                if (this.Items[0].SubItems[_sortcol].GetType() == typeof(EXListViewSubItemAB)) {
                    //sorting on text
                    this.ListViewItemSorter = new ListViewSubItemComparerText(e.Column, this.Sorting);
                } else {
                    //sorting on value
                    this.ListViewItemSorter = new ListViewSubItemComparerValue(e.Column, this.Sorting);
                }
            }
        }
        
        class ListViewSubItemComparerText : System.Collections.IComparer {
            
            private int _col;
            private SortOrder _order;

            public ListViewSubItemComparerText() {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewSubItemComparerText(int col, SortOrder order) {
                _col = col;
                _order = order;
            }
            
            public int Compare(object x, object y) {
                int returnVal = -1;
                
                string xstr = ((ListViewItem) x).SubItems[_col].Text;
                string ystr = ((ListViewItem) y).SubItems[_col].Text;
                
                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;
                
                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y)) {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                } else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y)) {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                } else {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }
        
        }
	
	    class ListViewSubItemComparerValue : System.Collections.IComparer {
            
            private int _col;
            private SortOrder _order;

            public ListViewSubItemComparerValue() {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewSubItemComparerValue(int col, SortOrder order) {
                _col = col;
                _order = order;
            }
            
            public int Compare(object x, object y) {
                int returnVal = -1;
                
                string xstr = ((EXListViewSubItemAB) ((ListViewItem) x).SubItems[_col]).MyValue;
                string ystr = ((EXListViewSubItemAB) ((ListViewItem) y).SubItems[_col]).MyValue;
                
                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;
                
                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y)) {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                } else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y)) {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                } else {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }
        
        }
	
	    class ListViewItemComparerText : System.Collections.IComparer {
            
            private int _col;
            private SortOrder _order;

            public ListViewItemComparerText() {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewItemComparerText(int col, SortOrder order) {
                _col = col;
                _order = order;
            }
            
            public int Compare(object x, object y) {
                int returnVal = -1;
                
                string xstr = ((ListViewItem) x).Text;
                string ystr = ((ListViewItem) y).Text;
                
                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;
                
                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y)) {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                } else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y)) {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                } else {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }
        
        }
	
	    class ListViewItemComparerValue : System.Collections.IComparer {
            
            private int _col;
            private SortOrder _order;

            public ListViewItemComparerValue() {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewItemComparerValue(int col, SortOrder order) {
                _col = col;
                _order = order;
            }
            
            public int Compare(object x, object y) {
                int returnVal = -1;
                
                string xstr = ((EXListViewItem) x).MyValue;
                string ystr = ((EXListViewItem) y).MyValue;
                
                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;
                
                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y)) {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                } else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y)) {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                } else {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }
        
        }
        
    }
    
    public class EXColumnHeader : ColumnHeader {
        
        public EXColumnHeader() {
            
        }
        
        public EXColumnHeader(string text) {
            this.Text = text;
        }
        
        public EXColumnHeader(string text, int width) {
            this.Text = text;
            this.Width = width;
        }
        
    }
    
    public class EXEditableColumnHeader : EXColumnHeader {
        
        private Control _control;
        
        public EXEditableColumnHeader() {
            
        }
        
        public EXEditableColumnHeader(string text) {
            this.Text = text;
        }
        
        public EXEditableColumnHeader(string text, int width) {
            this.Text = text;
            this.Width = width;
        }
        
        public EXEditableColumnHeader(string text, Control control) {
            this.Text = text;
            this.MyControl = control;
        }
        
        public EXEditableColumnHeader(string text, Control control, int width) {
            this.Text = text;
            this.MyControl = control;
            this.Width = width;
        }
        
        public Control MyControl {
            get {return _control;}
            set {
                _control = value;
                _control.Visible = false;
                _control.Tag = "not_init";
            }
        }
        
    }
	
	public class EXStatusColumnHeader : EXColumnHeader
	{
		private bool _editable;
		private ResourceManager resourceMan;
		private Dictionary<string, Image> iconMap;
		
		public Dictionary<string, Image> IconMap {
			get { return iconMap; }
			set { iconMap = value; }
		}
		
		public ResourceManager ResourceMan {
			get { return resourceMan; }
			set { resourceMan = value; }
		}

		public EXStatusColumnHeader()
		{
			init();
		}
		
		public EXStatusColumnHeader(string text)
		{
			init();
			this.Text = text;
		}
		
		public EXStatusColumnHeader(string text, int width)
		{
			init();
			this.Text = text;
			this.Width = width;
		}
		
		public EXStatusColumnHeader(
			string _text, 
			ResourceManager _resourceMan,
			int _width)
		{
			init();
			this.Text = _text;
			this.resourceMan = _resourceMan;
			this.Width = _width;
		}	
		
		public EXStatusColumnHeader(
			string _text, 
			Dictionary<string, Image> _iconMap,
			int _width)
		{
			init();
			this.Text = _text;
			this.iconMap = _iconMap;
			this.Width = _width;
		}
		
		public bool Editable 
		{
            get {return _editable;}
            set {_editable = value;}
        }
		
		private void init()
		{
            _editable = false;
            this.iconMap = new Dictionary<string, Image>();
        }
	}
	
    public abstract class EXListViewSubItemAB : ListViewItem.ListViewSubItem {
        
        private string _value = "";
        
        public EXListViewSubItemAB() {
            
        }
        
        public EXListViewSubItemAB(string text) {
            this.Text = text;
        }
        
        public string MyValue {
            get {return _value;}
            set {_value = value;}
        }
        
        //return the new x coordinate
        public abstract int DoDraw(DrawListViewSubItemEventArgs e, int x, ExtendControl.EXColumnHeader ch);

    }
    
    public class EXListViewSubItem : EXListViewSubItemAB {
        
        public EXListViewSubItem() {
            
        }
        
        public EXListViewSubItem(string text) {
            this.Text = text;
        }
        
        public override int DoDraw(DrawListViewSubItemEventArgs e, int x, ExtendControl.EXColumnHeader ch) {
            return x;
        }

    }
    
    public class EXControlListViewSubItem : EXListViewSubItemAB {
        
        private Control _control;
            
        public EXControlListViewSubItem() {
            
        }
        
        public Control MyControl {
            get {return _control;}
            set {_control = value;}
        }
        
        public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch) {
            return x;
        }
        
    }
	
	public class EXStatusListViewSubItem: EXListViewSubItemAB
	{
		private string status;
		
		public EXStatusListViewSubItem()
		{
			
		}
		
		public EXStatusListViewSubItem(string _status)
		{
			status = _status;
			this.MyValue = _status;
		}
		
		public string Status {
            get {return status;}
            set {
		        status = value;
		        this.MyValue = value;
	        }
        }
		
		public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch) {    
            EXStatusColumnHeader statuscol = (EXStatusColumnHeader) ch;
            Image image = null;
            if (statuscol.ResourceMan != null)
            {
            	image = statuscol.ResourceMan.GetObject(this.status) as Image;
            }
            else
            {
            	if (!statuscol.IconMap.ContainsKey(this.status))
            	{
	            	Icon smallIcon, largeIcon;
					string desc;
					IconHelper.GetExtsIconAndDescription(this.status, out largeIcon, out smallIcon, out desc);
					statuscol.IconMap.Add(this.status, largeIcon.ToBitmap() as Image);
            	}
            	image = statuscol.IconMap[this.status];
            }
            if (image != null)
            {
	            int imgy = e.Bounds.Y + ((int) (e.Bounds.Height / 2)) - ((int) (image.Height / 2));
	            e.Graphics.DrawImage(image, x, imgy, image.Width, image.Height);
	            x += image.Width + 2;
            }
            return x;
        }
	}
    
    public class EXListViewItem : ListViewItem {
	
	    private string _value;
        
        public EXListViewItem() {
            
        }
        
        public EXListViewItem(string text) {
            this.Text = text;
        }
	
        public string MyValue {
            get {return _value;}
            set {_value = value;}
        }
        
    }

}