using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SQLClient
{
    public partial class LoadingForm : DevExpress.XtraEditors.XtraForm
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private string description;
        private string caption;

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                this.lblMsg.Description = description;
            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
                this.lblMsg.Caption = caption;
            }
        }
    }
}