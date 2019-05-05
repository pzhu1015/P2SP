using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public abstract class ViewInfo : IViewInfo
    {
        public const int PAGE_SIZE = 10000;
        protected string name;
        protected string message;
        protected bool isOpen = false;
        protected ConnectionInfo connectionInfo;
        protected DatabaseInfo databaseInfo;
        protected DataSet dataSet;
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

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
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

        public DataSet DataSet
        {
            get
            {
                return dataSet;
            }

            set
            {
                dataSet = value;
            }
        }

        public abstract void Close();
        public abstract bool Open(long start);
        public abstract void Design();
        public abstract string GetSelect(long start, int pageSize);
    }
}
