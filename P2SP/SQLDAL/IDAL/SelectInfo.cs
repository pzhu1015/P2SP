using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public abstract class SelectInfo : ISelectInfo
    {
        protected string name;
        protected string message;
        protected bool isOpen = false;
        protected DataSet dataSet;
        protected ConnectionInfo connectionInfo;
        protected DatabaseInfo databaseInfo;

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

        public DataSet Dataset
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

        public abstract bool Open();
        public abstract void Close();
        public abstract bool Update(string contents);
    }
}
