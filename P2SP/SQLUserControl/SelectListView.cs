using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLDAL.IDAL;
using System.Reflection;

namespace SQLUserControl
{
    public partial class SelectListView : DevExpress.XtraEditors.XtraUserControl
    {
        public SelectListView()
        {
            InitializeComponent();
            Type type = this.lvMain.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.lvMain, true, null);
        }
        public event NewSelectEventHandler NewSelect;

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

        public void SelectItem()
        {
            this.tsbtnOpenSelect.Enabled = true;
            this.tsbtnDesignSelect.Enabled = true;
            this.tsbtnDeleteSelect.Enabled = true;
            this.tsbtnNewSelect.Enabled = true;
        }

        public void UnSelectItem()
        {
            this.tsbtnOpenSelect.Enabled = false;
            this.tsbtnDesignSelect.Enabled = false;
            this.tsbtnDeleteSelect.Enabled = false;
        }


        public void AddItem(SelectInfo info, string image_key)
        {
            this.lvMain.Items.Add(info.Name, image_key);
        }

        private void lvMain_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndices.Count == 0)
            {
                this.tsbtnOpenSelect.Enabled = false;
                this.tsbtnDesignSelect.Enabled = false;
                this.tsbtnDeleteSelect.Enabled = false;
            }
            else
            {
                this.tsbtnOpenSelect.Enabled = true;
                this.tsbtnDesignSelect.Enabled = true;
                this.tsbtnDeleteSelect.Enabled = true;
                this.tsbtnNewSelect.Enabled = true;
            }
        }

        protected virtual void OnNewSelect(NewSelectEventArgs e)
        {
            if (this.NewSelect != null)
            {
                this.NewSelect(this, e);
            }
        }

        private void tsbtnNewSelect_Click(object sender, EventArgs e)
        {
            this.OnNewSelect(new NewSelectEventArgs(this.databaseInfo));
        }
    }
    public delegate void NewSelectEventHandler(object sender, NewSelectEventArgs e);

    public class NewSelectEventArgs : EventArgs
    {
        private DatabaseInfo databaseInfo;
        public NewSelectEventArgs(DatabaseInfo info)
            :
            base()
        {
            this.databaseInfo = info;
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
    }
}
