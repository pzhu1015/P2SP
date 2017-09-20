using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complents.P2SPService.Msgs
{
    public delegate void RegistHandler(object sender, EventArgs args);
    [Serializable]
    public class RegistMsg :BaseMsg
    {
        public event RegistHandler Regist;
        private string userId;
        private string userName;
        private string passWord;
        private string email;
        private string phone;

        private void OnRegist(EventArgs e)
        {
            if (this.Regist != null)
            {
                this.Regist(this, e);
            }
        }

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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public RegistMsg(string _userId, string _userName, string _password, string _email, string _phone)
            :
            base(new MsgId("_server_", "_user_", MsgType.eRegist), true)
        {
            this.userId = _userId;
            this.userName = _userName;
            this.passWord = _password;
            this.email = _email;
            this.phone = _phone;
        }

        public override void OnMsgProcess(P2SPClient _client)
        {
            base.OnMsgProcess(_client);
            this.OnRegist(new EventArgs());
        }
    }
}
