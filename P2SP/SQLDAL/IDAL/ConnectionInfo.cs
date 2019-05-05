using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SQLDAL.IDAL
{
    public abstract class ConnectionInfo : IConnectInfo
    {
        protected string name;
        protected string host;
        protected int port;
        protected string user;
        protected string password;
        protected string serverVersion;
        protected int type;
        protected string message;
        protected bool isOpen = false;
        protected DbConnection connection;
        protected DbConnection sqliteConnection;
        protected DataSet dataSet;
        protected List<DatabaseInfo> databases;

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

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public DbConnection Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public List<DatabaseInfo> Databases
        {
            get
            {
                return databases;
            }

            set
            {
                databases = value;
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

        public string ServerVersion
        {
            get
            {
                return serverVersion;
            }

            set
            {
                serverVersion = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public DbConnection SqliteConnection
        {
            get
            {
                return sqliteConnection;
            }

            set
            {
                sqliteConnection = value;
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

        protected DataSet Dataset
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
        public abstract bool Open(string host, string user, string password);
        public abstract void Close();
        public abstract bool Refresh();
        public abstract void Create(string name);
        public abstract void Drop(string name);
        public abstract DatabaseInfo AddDataBaseInfo(string name);
        public abstract void UseDatabase(string name);

        public static bool AddConnection(string connectionstring, ConnectionInfo info)
        {
            try
            {
                DbConnection connection = new SQLiteConnection(connectionstring);
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO TB_CONNECTION VALUES('{info.name}', '{info.host}', {info.port}, '{info.user}', '{info.password}', {info.type}, '')";
                int ret = command.ExecuteNonQuery();
                info.sqliteConnection = connection;
                return true;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        public static bool RemoveConnection(string connectionstring, string name)
        {
            try
            {
                DbConnection connection = new SQLiteConnection(connectionstring);
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM TB_CONNECTION WHERE NAME='{name}'";
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        public static List<ConnectionInfo> LoadConnection(string connectionstring)
        {
            try
            {
                List<ConnectionInfo> list = new List<ConnectionInfo>();
                DataSet ds = new DataSet();
                DbConnection connection = new SQLiteConnection(connectionstring);
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TB_CONNECTION";
                DbDataAdapter da = new SQLiteDataAdapter(command as SQLiteCommand);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ConnectionInfo lc = SQLDALHelper.GetConnectionInfo((ConnectType)Convert.ToInt32(dr["type"]));
                    lc.Name = dr["name"].ToString();
                    lc.Host = dr["host"].ToString();
                    lc.Port = Convert.ToInt32(dr["port"]);
                    lc.User = dr["user"].ToString();
                    lc.Password = dr["password"].ToString();
                    lc.ServerVersion = dr["serverversion"].ToString();
                    lc.type = Convert.ToInt32(dr["type"]);
                    lc.sqliteConnection = connection;
                    list.Add(lc);
                }
                return list;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return null;
            }
        }

    }
}
