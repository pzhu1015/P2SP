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
    public partial class ViewListView : DevExpress.XtraEditors.XtraUserControl
    {
        public ViewListView()
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

        public void AddItem(ViewInfo info, string image_key)
        {
            this.lvMain.Items.Add(info.Name, image_key);
        }

        public void SelectItem()
        {
            this.tsbtnOpenView.Enabled = true;
            this.tsbtnDesignView.Enabled = true;
            this.tsbtnDeleteView.Enabled = true;
            this.tsbtnNewView.Enabled = true;
        }

        public void UnSelectItem()
        {
            this.tsbtnOpenView.Enabled = false;
            this.tsbtnDesignView.Enabled = false;
            this.tsbtnDeleteView.Enabled = false;
        }

        private void lvMain_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndices.Count == 0)
            {
                this.tsbtnOpenView.Enabled = false;
                this.tsbtnDesignView.Enabled = false;
                this.tsbtnDeleteView.Enabled = false;
            }
            else
            {
                this.tsbtnOpenView.Enabled = true;
                this.tsbtnDesignView.Enabled = true;
                this.tsbtnDeleteView.Enabled = true;
                this.tsbtnNewView.Enabled = true;
            }
        }

    }
}
