using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complents.P2SPService.Msgs
{
    public class RegistResp : RespMsg
    {
        private bool rslt;
        private string msg;

        public bool Rslt
        {
            get
            {
                return rslt;
            }

            set
            {
                rslt = value;
            }
        }

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                Msg = value;
            }
        }

        public RegistResp(MsgId _msgId, bool _rslt, string _msg)
            :base(_msgId)
        {
            this.rslt = _rslt;
            this.msg = _msg;
        }
    }
}
