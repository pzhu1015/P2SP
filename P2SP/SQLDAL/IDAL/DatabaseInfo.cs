using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public abstract class DatabaseInfo : IDatabaseInfo
    {
        protected string name;
        protected bool isOpen = false;
        protected DataSet dataset;
        protected DataSet selectDataset;
        protected List<TableInfo> tables;
        protected List<ViewInfo> views;
        protected List<SelectInfo> selects;
        protected ConnectionInfo connectionInfo;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public ConnectionInfo ConnectionInfo
        {
            get
            {
                return connectionInfo;
            }

            set
            {
                connectionInfo = value;
            }
        }

        public List<TableInfo> Tables
        {
            get
            {
                return tables;
            }

            set
            {
                tables = value;
            }
        }

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }

            set
            {
                isOpen = value;
            }
        }

        public List<ViewInfo> Views
        {
            get
            {
                return views;
            }

            set
            {
                views = value;
            }
        }

        public List<SelectInfo> Selects
        {
            get
            {
                return selects;
            }

            set
            {
                selects = value;
            }
        }

        public DataSet Dataset
        {
            get
            {
                return dataset;
            }

            set
            {
                dataset = value;
            }
        }

        public DataSet SelectDataset
        {
            get
            {
                return selectDataset;
            }

            set
            {
                selectDataset = value;
            }
        }

        public abstract void Open();
        public abstract void Refresh();
        public abstract void Close();
        public abstract void RefreshTable();
        public abstract void RefreshView();
        public abstract void RefreshSelect();
        public abstract void CreateTable(string name);
        public abstract void CreateView(string name);
        public abstract SelectInfo CreateSelect(string name, string contents);
        public abstract void DropTable(string name);
        public abstract void DropView(string name);
        public abstract void DropSelect(string name);
        public abstract TableInfo AddTableInfo(string name);
        public abstract ViewInfo AddViewInfo(string name);
        public abstract SelectInfo AddSelectInfo(string name);
    }
}
