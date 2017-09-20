using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using CCWin;
using Complents;
using Complents.P2SPService;
using Complents.P2SPService.Msgs;
using Helper;

namespace ChatClient
{

    public partial class MainForm : CCSkinMain
    {
        private string userId;
        private string passWord;
        private string host;
        private int port;
        private P2SPClient client;
        private bool isEditMotto = false;
        private WeatherForm weatherFrom;

        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        [DllImportAttribute("user32.dll")]
        private extern static bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        private extern static int SendMessage(IntPtr handle, int m, int p, int h);

        private void MouseDown_MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBoxMotto_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isEditMotto)
            {
                return;
            }
            this.isEditMotto = false;
            this.toolStripTextBoxMotto.SelectAll();
        }

        private void toolStripTextBoxMotto_Leave(object sender, EventArgs e)
        {
            this.isEditMotto = true;
            this.SaveMotto();
        }

        private void SaveMotto()
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 10);
        }

        private void picWeather_MouseLeave(object sender, EventArgs e)
        {
            this.LeaveWeatherFrom();
        }

        private void picWeather_MouseEnter(object sender, EventArgs e)
        {
            if (this.weatherFrom == null)
            {
                this.weatherFrom = new WeatherForm();
                this.weatherFrom.MainForm = this;
            }
            this.weatherFrom.Location = new Point(this.Left - this.weatherFrom.Width, this.Top);
            this.weatherFrom.Show();
      
            AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(EnterCb);
            ah.BeginInvoke(null, null);
        }

        public void EnterCb()
        {
            this.weatherFrom.LoadWeather();
        }

        public void LeaveWeatherFrom()
        {
            AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(LeaveCb);
            ah.BeginInvoke(null, null);
        }

        private void LeaveCb()
        {
            System.Threading.Thread.Sleep(1000);
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                 this.weatherFrom.Hide();
            }));

        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        public PictureBox getWeatherBox()
        {
            return this.picWeather;
        }

        public void Login()
        {
            if (this.client == null)
            {
                this.client = new P2SPClient();
                this.client.P2SPConnect += Client_P2SPConnect;
                this.client.P2SPDisConnect += Client_P2SPDisConnect;
                this.client.P2SPRecve += Client_P2SPRecve;
                this.client.P2SPSend += Client_P2SPSend;
            }
            this.client.Connect(new IPEndPoint(IPAddress.Parse(this.host), this.port));
        }

        private void Client_P2SPSend(object sender, P2SPSendEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPRecve(object sender, P2SPRecveEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPDisConnect(object sender, P2SPDisConnectEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPConnect(object sender, P2SPConnectEventArgs args)
        {
            MessageBox.Show("connect success");
            //send login msg to the server and access user info 
            BaseMsg msg = null;
            msg.Client = args.Client;
            this.client.Send(msg);
        }
    }
}
