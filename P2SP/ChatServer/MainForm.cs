using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Helper;
using Complents;
using Complents.P2SPService;
using System.Data.SQLite;

namespace ChatServer
{
    public partial class MainForm : CCSkinMain
    {
        private int port;
        private P2SPClient client;
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsBtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.client == null)
                {
                    this.client = new P2SPClient();
                    this.client.ListenerStart += Client_ListenerStart;
                    this.client.ListenerStop += Client_ListenerStop;
                    this.client.P2SPRecve += Client_P2SPRecve;
                    this.client.P2SPSend += Client_P2SPSend;
                }
                this.client.Start(this.port);
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        private void Client_P2SPSend(object sender, P2SPSendEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPRecve(object sender, P2SPRecveEventArgs args)
        {
            args.Msg.OnMsgProcess(this.client);
        }

        private void Client_ListenerStop(object sender, P2SPListenerStopEventArgs args)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                this.tsBtnStart.Enabled = true;
                this.tsBtnStop.Enabled = false;
                this.tsslblStatus.Text = "Service Stopped";
            }));
        }

        private void Client_ListenerStart(object sender, P2SPListenerStartEventArgs args)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                this.tsBtnStart.Enabled = false;
                this.tsBtnStop.Enabled = true;
                this.tsslblStatus.Text = "Service Started";
            }));
        }

        private void tsBtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.client.Stop();
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.port = ConfigHelper.GetAttributeInt("port", -1);
            this.tsslblStatus.Alignment = ToolStripItemAlignment.Right;
            if (!File.Exists("db.sqlite"))
            {
                CreateDatabase();
                CreateTable();
            }
        }

        private void CreateDatabase()
        {
            SQLiteHelper.CreateFile("db.sqlite");
            SQLiteHelper.connectionString = "Data Source = MyDatabase.sqlite;";
        }

        private void CreateTable()
        {
            string str = "";
            str += "create table tb_user(";
            str += "userId varchar(20),";
            str += "userName varchar(20),";
            str += "password varchar(20),";
            str += "email varchar(20),";
            str += "phone varchar(20)";
            str += ")";
            SQLiteHelper.ExecuteSql(str);
        }
    }
}
