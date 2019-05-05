using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using Helper;
using SQLDAL.IDAL;
using System.Data.Common;
using System.Data;

namespace SQLDAL.DAL
{
    public class MySQLConnectInfo : ConnectionInfo
    {
        public override void Close()
        {
            if (this.connection != null)
            {
                this.connection.Close();
                this.connection = null;
            }
            foreach(DatabaseInfo info in this.databases)
            {
                info.Close();
            }
            this.databases.Clear();
            this.databases = null;
            this.isOpen = false;
        }

        public override void Drop(string name)
        {
            try
            {
                if (!this.isOpen)
                {
                    return;
                }
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = $"DROP DATABASE {name};";
                command.ExecuteNonQuery();
                if (this.databases == null)
                {
                    return;
                }
                foreach (DatabaseInfo info in this.databases)
                {
                    if (info.Name == name)
                    {
                        this.databases.Remove(info);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        public override void Create(string name)
        {
            try
            {
                if (!this.isOpen)
                {
                    return;
                }
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = $"CREATE DATABASE {name};";
                command.ExecuteNonQuery();
                if (this.databases != null)
                {
                    DatabaseInfo info = new MySQLDatabaseInfo();
                    info.Name = name;
                    info.ConnectionInfo = this;
                    this.databases.Add(info);
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        public override bool Open(string host, string user, string password)
        {
            try
            {
                this.host = host;
                this.user = user;
                this.password = password;
                this.port = 3306;
                if (this.connection == null)
                {
                    string str = $"Data Source = {host}; User ID = {user}; Password = {password}; DataBase = mysql; Charset = utf8;";
                    DbConnection conn = new MySqlConnection(str);
                    conn.Open();
                    this.connection = conn;
                }

                
                if (this.databases == null)
                {
                    this.databases = new List<DatabaseInfo>();
                }

                if (this.dataSet == null)
                {
                    this.dataSet = new DataSet();
                }
                this.dataSet.Clear();
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = "SHOW DATABASES;";
                DbDataAdapter da = new MySqlDataAdapter(command as MySqlCommand);
                da.Fill(this.dataSet);
                DataTable dt = this.dataSet.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    this.AddDataBaseInfo(dr[0].ToString());
                }
                this.isOpen = true;
                return true;
            }
            catch(Exception ex)
            {
                this.message = ex.Message;
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        public override bool Refresh()
        {
            if (!this.isOpen)
            {
                return true;
            }
            if (this.databases != null)
            {
                this.databases.Clear();
            }
            return this.Open(this.host, this.user, this.password);
        }

        public override bool Open()
        {
            return this.Open(this.host, this.user, this.password);
        }

        public override DatabaseInfo AddDataBaseInfo(string name)
        {
            DatabaseInfo info = new MySQLDatabaseInfo();
            info.Name = name;
            info.ConnectionInfo = this;
            this.databases.Add(info);
            return info;
        }

        public override void UseDatabase(string name)
        {
            this.connection.ChangeDatabase(name);
        }
    }
}
