using System;

using SQLDAL.IDAL;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Helper;

namespace SQLDAL.DAL
{
    public class MySQLViewInfo : ViewInfo
    {
        public override void Close()
        {
            this.isOpen = false;
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
                da.Fill(this.dataSet, this.name);
                this.isOpen = true;
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                LogHelper.logerror.Error(ex);
                return false;
            }
            return true;
        }
    }
}
