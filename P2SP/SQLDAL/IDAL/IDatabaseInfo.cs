using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.IDAL
{
    public interface IDatabaseInfo
    {
        void Open();
        void Close();
        void Refresh();
        void RefreshTable();
        void RefreshView();
        void RefreshSelect();
        void CreateTable(string name);
        void CreateView(string name);
        SelectInfo CreateSelect(string name, string contents);
        void DropTable(string name);
        void DropView(string name);
        void DropSelect(string name);
        TableInfo AddTableInfo(string name);
        ViewInfo AddViewInfo(string name);
        SelectInfo AddSelectInfo(string name);
    }
}
