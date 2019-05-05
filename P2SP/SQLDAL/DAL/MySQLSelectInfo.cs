using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLDAL.IDAL;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;
using Helper;

namespace SQLDAL.DAL
{
    public class MySQLSelectInfo : SelectInfo
    {
        public override void Close()
        {
            this.isOpen = false;
        }

        public override bool Open()
        {
            try
            {
                if (this.dataSet == null)
                {
                    this.dataSet = new DataSet();
                }
                this.dataSet.Clear();
                DbCommand command = this.connectionInfo.SqliteConnection.CreateCommand();
                command.CommandText = $"SELECT CONTENTS FROM TB_SELECT WHERE NAME='{this.name}' AND CONNECT='{this.connectionInfo.Name}' AND DATABASE='{this.databaseInfo.Name}';";
                DbDataAdapter da = new SQLiteDataAdapter(command as SQLiteCommand);
                da.Fill(this.dataSet);
                this.isOpen = true;
                return true;
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        public override bool Update(string contents)
        {
            try
            {
                if (this.dataSet == null)
                {
                    this.dataSet = new DataSet();
                }
                this.dataSet.Clear();
                DbCommand command = this.connectionInfo.SqliteConnection.CreateCommand();
                command.CommandText = $"UPDATE TB_SELECT SET CONTENTS='{contents}' WHERE NAME='{this.name}' AND CONNECT='{this.connectionInfo.Name}' AND DATABASE='{this.databaseInfo.Name}';";
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                LogHelper.logerror.Error(ex);
                return false;
            }
        }
    }
}
