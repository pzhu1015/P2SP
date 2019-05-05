using SQLDAL.DAL;
using SQLDAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLDAL
{
    public enum ConnectType
    {
        eJimoSQL,
        eMySQL,
        eOracleSQL
    }

    public class SQLDALHelper
    {
        public static ConnectionInfo GetConnectionInfo(ConnectType type)
        {
            switch (type)
            {
                case ConnectType.eJimoSQL: return null;
                case ConnectType.eMySQL: return new MySQLConnectInfo();
                case ConnectType.eOracleSQL: return null;
                default: return null;
            }
        }
    }
}
