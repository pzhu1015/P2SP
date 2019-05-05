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
using System.Data.Odbc;
using Helper;
using SQLUserControl;
using SQLDAL;

namespace SQLClient
{
    public partial class NewConnectionFrom : DevExpress.XtraEditors.XtraForm
    {
        private ConnectType type;
        private string driver;
        private SqlClientForm sqlClientForm;

        public SqlClientForm SqlClientForm
        {
            get
            {
                return sqlClientForm;
            }

            set
            {
                sqlClientForm = value;
            }
        }

        public string Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        public ConnectType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public NewConnectionFrom()
        {
            InitializeComponent();
        }

        private void NewConnectionFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.sqlClientForm.AddConnection(
                this.type,
                this.txtConnectName.Text,
                this.txtHost.Text,
                Convert.ToInt32(this.txtPort.Text),
                this.txtUser.Text,
                this.txtPassword.Text);

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string conn_str = "DRIVER={" + this.driver + "};" +
                                  "SERVER=" + this.txtHost.Text + ";" +
                                  "DATABASE=db;" +
                                  "UID=" + this.txtUser.Text + ";" +
                                  "PASSWORD=" + this.txtPassword.Text + ";";
                OdbcConnection conn = new OdbcConnection(conn_str);
                conn.Open();
                MessageBox.Show("Connect Successfull", "Result");
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }
    }
}