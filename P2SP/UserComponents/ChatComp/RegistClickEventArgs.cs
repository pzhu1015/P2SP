using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserComponents.ChatComp
{
    public delegate void RegistClickEventHandler(object sender, RegistClickEventArgs args);
    public class RegistClickEventArgs: EventArgs
    {
        public RegistClickEventArgs()
            :
            base()
        {

        }
    }
}
