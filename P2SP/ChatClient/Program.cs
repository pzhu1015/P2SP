using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChatClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            //-u aaaa -p cccc
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                string userId = "";
                string passWd = "";
                string host = "";
                int port = -1;
                int i = 0;
                while(i < args.Length)
                {
                    if (args[i] == "-user")
                    {
                        userId = args[i + 1];
                        i++;
                    }
                    else if (args[i] == "-password")
                    {
                        passWd = args[i + 1];
                        i++;
                    }
                    else if (args[i] == "-port")
                    {
                        port = Convert.ToInt32(args[i + 1]);
                    }
                    else if (args[i] == "-host")
                    {
                        host = args[i + 1];
                    }
                    else
                    {
                        Application.Exit();
                    }
                    i++;
                }
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(passWd))
                {
                    Application.Exit();
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                    MainForm mainFrom = new MainForm();
                    mainFrom.UserId = userId;
                    mainFrom.PassWord = passWd;
                    mainFrom.Host = host;
                    mainFrom.Port = port;
                    mainFrom.Login();
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
