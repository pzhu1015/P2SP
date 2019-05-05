using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CCWin;

namespace ChatServer
{
    public partial class SettingForm : CCSkinMain
    {
        private MainForm mainFrom;
        public SettingForm()
        {
            InitializeComponent();
        }

        public MainForm MainFrom
        {
            get
            {
                return mainFrom;
            }

            set
            {
                mainFrom = value;
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
