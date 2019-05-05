using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Threading;

namespace SQLClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*default*/
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new SqlClientForm());
            */

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //// The following line provides localization for the application's user interface.           
            //System.Threading.Thread.CurrentThread.CurrentUICulture =  new System.Globalization.CultureInfo("zh-CN");
            //// The following line provides localization for data formats.             
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //设置TabPage边框为0            
            SkinElement element = SkinManager.GetSkinElement(SkinProductId.Tab, DevExpress.LookAndFeel.UserLookAndFeel.Default, "TabPane");
            element.ContentMargins.Right = 0;
            element.ContentMargins.Bottom = 0;
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            Application.Run(new SqlClientForm());
            //Application.Run(new XtraForm1());
        }
    }
}
