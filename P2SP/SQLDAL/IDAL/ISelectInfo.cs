using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public interface ISelectInfo
    {
        bool Open();
        void Close();
        bool Update(string contents);
    }
}
