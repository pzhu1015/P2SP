using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using SQLDAL.IDAL;

namespace SQLUserControl
{
    public partial class TableListView : DevExpress.XtraEditors.XtraUserControl
    {
        public event OpenTableEventHandler OpenTable;
        public event DesignTableEventHandler DesignTable;
        public TableListView()
        {
            InitializeComponent();
            Type type = this.lvMain.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.lvMain, true, null);
        }

        private DatabaseInfo databaseInfo;
        private ImageList smallImageList;
        private View view;
        private bool labelEdit;

        public ImageList SmallImageList
        {
            get
            {
                return smallImageList;
            }

            set
            {
                smallImageList = value;
                this.lvMain.SmallImageList = this.smallImageList;
            }
        }

        public View View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
                this.lvMain.View = view;
            }
        }

        public bool LabelEdit
        {
            get
            {
                return labelEdit;
            }

            set
            {
                labelEdit = value;
                this.lvMain.LabelEdit = labelEdit;
            }
        }

        public DatabaseInfo DatabaseInfo
        {
            get
            {
                return databaseInfo;
            }

            set
            {
                databaseInfo = value;
            }
        }

        public void AddItem(TableInfo info, string image_key)
        {
            ListViewItem item = this.lvMain.Items.Add(info.Name, image_key);
            item.Tag = info;
        }

        public void SelectItem()
        {
            this.tsbtnOpenTable.Enabled = true;
            this.tsbtnDesignTable.Enabled = true;
            this.tsbtnDeleteTable.Enabled = true;
            this.tsbtnNewTable.Enabled = true;
        }

        public void UnSelectItem()
        {
            this.tsbtnOpenTable.Enabled = false;
            this.tsbtnDesignTable.Enabled = false;
            this.tsbtnDeleteTable.Enabled = false;
        }

        private void lvMain_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndices.Count == 0)
            {
                this.tsbtnOpenTable.Enabled = false;
                this.tsbtnDesignTable.Enabled = false;
                this.tsbtnDeleteTable.Enabled = false;
            }
            else
            {
                this.tsbtnOpenTable.Enabled = true;
                this.tsbtnDesignTable.Enabled = true;
                this.tsbtnDeleteTable.Enabled = true;
                this.tsbtnNewTable.Enabled = true;
            }
        }

        protected virtual void OnOpenTable(OpenTabletEventArgs e)
        {
            if (this.OpenTable != null)
            {
                this.OpenTable(this, e);
            }
        }

        protected virtual void OnDesignTable(DesignTabletEventArgs e)
        {
            if (this.DesignTable != null)
            {
                this.DesignTable(this, e);
            }
        }

        private void tsbtnDesignTable_Click(object sender, EventArgs e)
        {
            if (this.lvMain.SelectedItems.Count == 0)
            {
                return;
            }
            this.OnDesignTable(new DesignTabletEventArgs(this.lvMain.SelectedItems[0]));
        }

        private void lvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvMain.SelectedItems.Count == 0)
            {
                return;
            }
            this.OnOpenTable(new OpenTabletEventArgs(this.lvMain.SelectedItems[0]));
        }
    }

    public delegate void OpenTableEventHandler(object sender, OpenTabletEventArgs e);

    public class OpenTabletEventArgs : EventArgs
    {
        private ListViewItem item;
        public OpenTabletEventArgs(ListViewItem item)
            :
            base()
        {
            this.item = item;
        }

        public ListViewItem Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }
    }

    public delegate void DesignTableEventHandler(object sender, DesignTabletEventArgs e);

    public class DesignTabletEventArgs : EventArgs
    {
        private ListViewItem item;
        public DesignTabletEventArgs(ListViewItem item)
            :
            base()
        {
            this.item = item;
        }

        public ListViewItem Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }
    }
}
