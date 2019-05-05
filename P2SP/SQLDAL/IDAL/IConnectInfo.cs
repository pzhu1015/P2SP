using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public interface IConnectInfo 
    {
        bool Open();
        bool Open(string host, string user, string password);
        void Close();
        bool Refresh();
        void Create(string name);
        void Drop(string name);
        void UseDatabase(string name);
        DatabaseInfo AddDataBaseInfo(string name);
    }
}
