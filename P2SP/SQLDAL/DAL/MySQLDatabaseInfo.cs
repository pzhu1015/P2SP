using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

using Helper;
using SQLDAL.IDAL;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SQLDAL.DAL
{
    public class MySQLDatabaseInfo : DatabaseInfo
    {
        public override TableInfo AddTableInfo(string name)
        {
            TableInfo info = new MySQLTableInfo();
            info.Name = name;
            info.ConnectionInfo = this.connectionInfo ;
            info.DatabaseInfo = this;
            this.tables.Add(info);
            return info;
        }

        public override ViewInfo AddViewInfo(string name)
        {
            ViewInfo info = new MySQLViewInfo();
            info.Name = name;
            info.ConnectionInfo = this.connectionInfo;
            info.DatabaseInfo = this;
            this.views.Add(info);
            return info;
        }

        public override SelectInfo AddSelectInfo(string name)
        {
            SelectInfo info = new MySQLSelectInfo();
            info.Name = name;
            info.ConnectionInfo = this.connectionInfo;
            info.DatabaseInfo = this;
            this.selects.Add(info);
            return info;
        }

        public override void Close()
        {
            if (this.tables != null)
            {
                this.tables.Clear();
                this.tables = null;
            }

            if (this.Views != null)
            {
                this.Views.Clear();
                this.Views = null;
            }

            if (this.Selects != null)
            {
                this.Selects.Clear();
                this.Selects = null;
            }
            this.isOpen = false;
        }

        public override SelectInfo CreateSelect(string name, string contents)
        {
            try
            {
                DbCommand command = this.connectionInfo.SqliteConnection.CreateCommand();
                command.CommandText = $"INSERT INTO TB_SELECT VALUES('{name}', '{contents}', '{this.connectionInfo.Name}', '{this.name}')";
                int ret = command.ExecuteNonQuery();
                return AddSelectInfo(name);
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return null;
            }

        }

        public override void CreateTable(string name)
        {
            try
            {
                if (!this.isOpen)
                {
                    return;
                }
                TableInfo info = new MySQLTableInfo();
                info.Name = name;
                info.ConnectionInfo = this.connectionInfo;
                this.tables.Add(info);

            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        public override void CreateView(string name)
        {
            throw new NotImplementedException();
        }

        public override void DropSelect(string name)
        {
            throw new NotImplementedException();
        }

        public override void DropTable(string name)
        {
            try
            {
                if (!this.isOpen)
                {
                    return;
                }
                DbCommand command = this.connectionInfo.Connection.CreateCommand();
                command.CommandText = $"DROP TABLE {name}";
                command.ExecuteNonQuery();
                foreach(TableInfo info in this.tables)
                {
                    if (info.Name == name)
                    {
                        this.tables.Remove(info);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        public override void DropView(string name)
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            try
            {
                if (this.isOpen)
                {
                    return;
                }
                if (this.tables == null)
                {
                    this.tables = new List<TableInfo>();
                }
                if (this.views == null)
                {
                    this.views = new List<ViewInfo>();
                }
                if (this.selects == null)
                {
                    this.Selects = new List<SelectInfo>();
                }
                if (this.dataset == null)
                {
                    this.dataset = new DataSet();
                }
                if (this.selectDataset == null)
                {
                    this.selectDataset = new DataSet();
                }
                DbCommand command = this.connectionInfo.Connection.CreateCommand();
                command.CommandText = "SHOW FULL TABLES WHERE Table_type != 'VIEW';SHOW FULL TABLES WHERE Table_type = 'VIEW'";
                DbDataAdapter da = new MySqlDataAdapter(command as MySqlCommand);
                da.Fill(this.dataset);

                DataTable dt = this.dataset.Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    this.AddTableInfo(dr[0].ToString());
                }

                dt = this.dataset.Tables[1];
                foreach(DataRow dr in dt.Rows)
                {
                    this.AddViewInfo(dr[0].ToString());
                }
                DbCommand sqlite_command = this.connectionInfo.SqliteConnection.CreateCommand();
                sqlite_command.CommandText = $"select name from tb_select where connect='{this.connectionInfo.Name}' and database='{this.name}'";
                DbDataAdapter sqlite_da = new SQLiteDataAdapter(sqlite_command as SQLiteCommand);
                sqlite_da.Fill(this.selectDataset);
                dt = this.selectDataset.Tables[0];

                foreach(DataRow dr in dt.Rows)
                {
                    this.AddSelectInfo(dr[0].ToString());
                }
                this.isOpen = true;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }

        }

        public override void Refresh()
        {
            if (!this.isOpen)
            {
                return;
            }
            if (this.tables != null)
            {
                this.tables.Clear();
            }
            if (this.Views != null)
            {
                this.Views.Clear();
            }
            if (this.Selects != null)
            {
                this.Selects.Clear();
            }
            this.Open();
        }

        public override void RefreshSelect()
        {
            throw new NotImplementedException();
        }

        public override void RefreshTable()
        {
            try
            {
                if (!this.isOpen)
                {
                    return;
                }
                if (this.tables != null)
                {
                    this.tables.Clear();
                }
                DbCommand command = this.connectionInfo.Connection.CreateCommand();
                command.CommandText = $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{name}';";
                DbDataAdapter da = new MySqlDataAdapter(command as MySqlCommand);
                da.Fill(this.dataset, "TABLES");
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        public override void RefreshView()
        {
            throw new NotImplementedException();
        }
    }
}
