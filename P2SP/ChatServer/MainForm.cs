using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Helper;
using UserComponents;
using UserComponents.P2SPService;
using System.Data.SQLite;

namespace ChatServer
{
    public partial class MainForm : CCSkinMain
    {
        private bool isStart = false;
        private int port;
        private P2SPClient client;
        private SettingForm settingForm;
        public MainForm()
        {
            InitializeComponent();
            this.InitP2SPClient();
        }

        private void InitP2SPClient()
        {
            if (this.client == null)
            {
                this.client = new P2SPClient();
                this.client.ListenerStart += Client_ListenerStart;
                this.client.ListenerStop += Client_ListenerStop;
                this.client.P2SPRecve += Client_P2SPRecve;
                this.client.P2SPSend += Client_P2SPSend;
            }
        }

        private void MouseDown_MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Helper.DLLHelper.ReleaseCapture();
                Helper.DLLHelper.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void tsBtnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.isStart)
                {
                    this.client.Start(this.port);
                }
                else
                {
                    this.client.Stop();

                }

                this.isStart = !this.isStart;
            }
            catch(Exception ex)
            {
                //LogHelper.logerror.Error(ex);
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
                this.tsBtnStartStop.Image = FormResource.start;
                this.tsBtnStartStop.Text = "启动";
                this.tsslblStatus.Text = "Service Stopped";
                //LogHelper.loginfo.Info(this.tsslblStatus.Text);
                this.fcTxtLog.AppendText(this.tsslblStatus.Text + "\n");
            }));
        }

        private void Client_ListenerStart(object sender, P2SPListenerStartEventArgs args)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                this.tsBtnStartStop.Image = FormResource.stop;
                this.tsBtnStartStop.Text = "停止";
                this.tsslblStatus.Text = "Service Started";
                //LogHelper.Info(this.tsslblStatus.Text);
                this.fcTxtLog.AppendText(this.tsslblStatus.Text + "\n");
            }));
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.port = ConfigHelper.GetAttributeInt("port", -1);
            this.tsslblStatus.Alignment = ToolStripItemAlignment.Right;
            //if (!File.Exists("db.sqlite"))
            //{
            //    CreateDatabase();
            //    CreateTable();
            //}
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

        private void tsbtnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.settingForm == null || this.settingForm.IsDisposed)
                {
                    this.settingForm = new SettingForm();
                    this.settingForm.MainFrom = this;
                }
                this.settingForm.ShowDialog();
            }
            catch(Exception ex)
            {
                //LogHelper.logerror.Error(ex);
            }
        }
    }
}
