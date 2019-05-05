using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SQLUserControl
{
    public partial class SaveSelectForm : DevExpress.XtraEditors.XtraForm
    {
        private NewSelectPage newSelectPage;
        public SaveSelectForm()
        {
            InitializeComponent();
        }

        public NewSelectPage NewSelectPage
        {
            get
            {
                return newSelectPage;
            }

            set
            {
                newSelectPage = value;
            }
        }

        private void SaveSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.newSelectPage.CreateSelect(this.txtName.Text);
            this.Hide();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}