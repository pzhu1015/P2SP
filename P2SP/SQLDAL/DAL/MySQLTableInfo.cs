using System;
using MySql.Data.MySqlClient;

using Helper;
using SQLDAL.IDAL;
using System.Data;
using System.Data.Common;

namespace SQLDAL.DAL
{
    public class MySQLTableInfo : TableInfo
    {
        public override void Close()
        {
            this.isOpen = false;
        }

        public override DataTable Describe()
        {
            try
            {
                DataTable dt = new DataTable();
                this.connectionInfo.UseDatabase(this.databaseInfo.Name);
                DbCommand command = this.connectionInfo.Connection.CreateCommand();
                command.CommandText = $"DESCRIBE {this.name}";
                DbDataAdapter da = new MySqlDataAdapter(command as MySqlCommand);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return null;
            }
        }

        public override void Design()
        {
        }

        public override string GetSelect(long start, int pageSize)
        {
            string statement = $"SELECT * FROM `{this.name}` LIMIT {start}, {pageSize};".ToUpper();
            return statement;
        }

        public override bool Open(Int64 start)
        {
            try
            {
                this.connectionInfo.UseDatabase(this.databaseInfo.Name);
                if (this.dataSet == null)
                {
                    this.dataSet = new DataSet();
                }
                this.dataSet.Clear();
                DbCommand command = this.connectionInfo.Connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {this.name} LIMIT {start}, {PAGE_SIZE};";
                DbDataAdapter da = new MySqlDataAdapter(command as MySqlCommand);
                da.Fill(this.dataSet);
                this.isOpen = true;
            }
            catch(Exception ex)
            {
                this.message = ex.Message;
                LogHelper.logerror.Error(ex);
                return false;
            }
            return true;
        }
    }
}
