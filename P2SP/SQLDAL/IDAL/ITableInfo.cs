using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public interface ITableInfo
    {
        DataTable Describe();
        void Close();
        bool Open(Int64 start);
        void Design();
        string GetSelect(Int64 start, int pageSize);
    }
}
