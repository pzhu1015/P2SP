using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FlashDownLoad
{
    public partial class DeleteForm : DevExpress.XtraEditors.XtraForm
    {
        private DownLoadForm downLoadForm;

        public DownLoadForm DownLoadForm
        {
            get
            {
                return downLoadForm;
            }

            set
            {
                downLoadForm = value;
            }
        }

        public DeleteForm()
        {
            InitializeComponent();
        }

        private void DeleteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.downLoadForm.DeleteSelectedTask(this.chkDelete.Checked);
        }
    }
}