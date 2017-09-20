using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CCWin;
using Helper;
using Complents;
using Complents.P2SPService;
using Complents.P2SPService.Msgs;
using System.Net;

namespace ChatClient
{
    public partial class RegistFrom : CCSkinMain
    {
        private P2SPClient client;
        private LoginForm loginForm;
        public RegistFrom()
        {
            InitializeComponent();
        }

        public LoginForm LoginForm
        {
            get
            {
                return loginForm;
            }

            set
            {
                loginForm = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(RegistCb);
            ah.BeginInvoke(null, null);
        }

        private void RegistCb()
        {
            BaseMsg msg = new RegistMsg(this.txtUserId.Text, this.txtNickName.Text, this.txtPassword.Text, this.txtEmail.Text, this.txtPhoneNumber.Text);
            RespMsg resp = this.client.Send(msg);
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                RegistResp dataMsg = resp as RegistResp;
                if (dataMsg.Rslt)
                {
                    MessageBox.Show(dataMsg.Msg);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(dataMsg.Msg);
                }
                
            }));
        }

        private void RegistFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void RegistFrom_Load(object sender, EventArgs e)
        {
            if (this.client == null)
            {
                this.client = new P2SPClient();
                this.client.P2SPConnect += Client_P2SPConnect;
                this.client.P2SPSend += Client_P2SPSend;
                this.client.P2SPRecve += Client_P2SPRecve;
                this.client.Connect(new IPEndPoint(IPAddress.Parse(this.loginForm.Host), this.loginForm.Port));
            }
        }

        private void Client_P2SPConnect(object sender, P2SPConnectEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPRecve(object sender, P2SPRecveEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void Client_P2SPSend(object sender, P2SPSendEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
