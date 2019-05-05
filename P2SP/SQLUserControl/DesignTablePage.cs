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
    public partial class DesignTablePage : DevExpress.XtraEditors.XtraUserControl
    {
        private TableInfo tableInfo;
        private ToolStripLabel fieldsInfo;
        private ToolStripLabel indexsInfo;
        private ToolStripLabel primaryKeysInfo;
        private ToolStripLabel triggersInfo;
        public DesignTablePage()
        {
            InitializeComponent();
            Type type = this.dgvFields.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvFields, true, null);
            type = this.dgvIndexs.GetType();
            pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvIndexs, true, null);
        }

        public TableInfo TableInfo
        {
            get
            {
                return tableInfo;
            }

            set
            {
                tableInfo = value;
            }
        }

        public ToolStripLabel FieldsInfo
        {
            get
            {
                return fieldsInfo;
            }

            set
            {
                fieldsInfo = value;
            }
        }

        public ToolStripLabel IndexsInfo
        {
            get
            {
                return indexsInfo;
            }

            set
            {
                indexsInfo = value;
            }
        }

        public ToolStripLabel PrimaryKeysInfo
        {
            get
            {
                return primaryKeysInfo;
            }

            set
            {
                primaryKeysInfo = value;
            }
        }

        public ToolStripLabel TriggersInfo
        {
            get
            {
                return triggersInfo;
            }

            set
            {
                triggersInfo = value;
            }
        }

        public void SetStatusBar()
        {

        }

        public void BindData()
        {
            //DataTable dt = this.tableInfo.Describe();
            //this.dgvFields.DataSource = dt;
        }
    }
}
