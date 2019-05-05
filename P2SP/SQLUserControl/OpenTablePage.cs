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
using Helper;
using System.Reflection;

namespace SQLUserControl
{
    public partial class OpenTablePage : DevExpress.XtraEditors.XtraUserControl
    {
        private bool isSetting = false;
        private int pageSize = 1000;
        private Int64 cacheStart = 0;
        private Int64 cacheEnd = 0;
        private Int64 showStart = 0;
        private DataTable bindTable;
        private TableInfo tableInfo;
        private ToolStripLabel statement;
        private ToolStripLabel pageInfo;
        public OpenTablePage()
        {
            InitializeComponent();
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
                this.cacheStart = 0;
                this.cacheEnd = this.tableInfo.DataSet.Tables[0].Rows.Count;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public ToolStripLabel Statement
        {
            get
            {
                return statement;
            }

            set
            {
                statement = value;
            }
        }

        public ToolStripLabel PageInfo
        {
            get
            {
                return pageInfo;
            }

            set
            {
                pageInfo = value;
            }
        }

        public void BindData(Int64 start)
        {
            try
            { 
                DataTable dt = this.tableInfo.DataSet.Tables[0];
                Int64 count = dt.Rows.Count;
                Int64 end = start + this.pageSize;
                if (end > count)
                {
                    end = count;
                } 
                this.bindTable = dt.Clone();
                for (Int64 i = start; i < end; i++)
                {
                    this.bindTable.ImportRow(dt.Rows[(int)i]);
                }
                this.dgv.DataSource = this.bindTable;
                Type type = this.dgv.GetType();
                PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(this.dgv, true, null);

            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void tsbtnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 crt_page = Convert.ToInt64(this.tstxtCurentPage.Text);
                Int64 start = crt_page * this.pageSize;
                Int64 end = start + this.pageSize;
                if (end > this.cacheEnd)
                {
                    this.tableInfo.Open(start);
                    this.cacheStart = start;
                    this.cacheEnd = start + this.tableInfo.DataSet.Tables[0].Rows.Count;
                    this.showStart = 0;
                }
                else
                {
                    this.showStart += this.pageSize;
                }
                this.BindData(this.showStart);
                this.tstxtCurentPage.Text = (crt_page + 1).ToString();
                this.SetStatusBar();
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void tsbtnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 crt_page = Convert.ToInt64(this.tstxtCurentPage.Text);
                if (crt_page == 1)
                {
                    return;
                }
                Int64 start = (crt_page - 2) * this.pageSize;
                if (start < this.cacheStart)
                {
                    this.tableInfo.Open(start);
                    this.cacheStart = start;
                    this.cacheEnd = start + this.tableInfo.DataSet.Tables[0].Rows.Count;
                    this.showStart = 0;
                }
                else
                {
                    this.showStart -= this.pageSize;
                }
                this.BindData(this.showStart);
                this.tstxtCurentPage.Text = (crt_page - 1).ToString();
                this.SetStatusBar();
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void tsbtnFristPage_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 crt_page = Convert.ToInt64(this.tstxtCurentPage.Text);
                if (crt_page == 1)
                {
                    return;
                }
                Int64 start = 0 * this.pageSize;
                if (start < this.cacheStart)
                {
                    this.tableInfo.Open(start);
                    this.cacheStart = start;
                    this.cacheEnd = start + this.tableInfo.DataSet.Tables[0].Rows.Count;
                    this.showStart = 0;
                }
                this.showStart = 0;
                this.BindData(this.showStart);
                this.tstxtCurentPage.Text = "1";
                this.SetStatusBar();
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void tsbtnSetting_Click(object sender, EventArgs e)
        {
            if (!this.isSetting)
            {
                this.tstxtPageSize.Visible = true;
                this.tstxtPageSize.Text = this.pageSize.ToString();
                this.tslblRecordPerPage.Visible = true;

                this.tsbtnFristPage.Visible = false;
                this.tsbtnPrevPage.Visible = false;
                this.tstxtCurentPage.Visible = false;
                this.tsbtnNextPage.Visible = false;
                this.tsbtnLastPage.Visible = false;
            }
            else
            {
                this.tstxtPageSize.Visible = false;
                this.pageSize = Convert.ToInt32(this.tstxtPageSize.Text);
                this.tslblRecordPerPage.Visible = false;

                this.tsbtnFristPage.Visible = true;
                this.tsbtnPrevPage.Visible = true;
                this.tstxtCurentPage.Visible = true;
                this.tsbtnNextPage.Visible = true;
                this.tsbtnLastPage.Visible = true;
            }
            this.isSetting = !this.isSetting;
        }

        public void SetStatusBar()
        {
            Int64 crt_page = Convert.ToInt64(this.tstxtCurentPage.Text);
            Int64 start = (crt_page - 1) * this.pageSize;
            this.statement.Text = this.tableInfo.GetSelect(start, this.pageSize);
            int rowIndex = 0;
            if (this.dgv.CurrentCell != null)
            {
                rowIndex = this.dgv.CurrentCell.RowIndex;
            }
            rowIndex += 1;
            this.pageInfo.Text = $"第{rowIndex}条记录(共{this.bindTable.Rows.Count}条)于第{crt_page}页";
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            Int64 crt_page = Convert.ToInt64(this.tstxtCurentPage.Text);
            int rowIndex = 0;
            if (this.dgv.CurrentCell != null)
            {
                rowIndex = this.dgv.CurrentCell.RowIndex;
            }
            rowIndex += 1;
            this.pageInfo.Text = $"第{rowIndex}条记录(共{this.bindTable.Rows.Count}条)于第{crt_page}页";
        }

        private void tstxtPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.pageSize = Convert.ToInt32(this.tstxtPageSize.Text);
                this.BindData(this.showStart);
                this.SetStatusBar();
            }
        }
    }
}
