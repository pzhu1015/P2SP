using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public interface IViewInfo
    {
        void Close();
        bool Open(Int64 start);
        void Design();
        string GetSelect(Int64 start, int pageSize);
    }
}
