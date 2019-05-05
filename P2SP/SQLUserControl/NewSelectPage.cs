using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLDAL.IDAL;
using Helper;
using DevExpress.XtraRichEdit.Services;

namespace SQLUserControl
{
    public partial class NewSelectPage : DevExpress.XtraEditors.XtraUserControl
    {
        private SaveSelectForm saveSelectForm;
        private SelectInfo selectInfo;
        private DatabaseInfo databaseInfo;
        private ToolStripLabel statement;
        private ToolStripLabel pageInfo;
        private ToolStripLabel timeInfo;
        public NewSelectPage()
        {
            InitializeComponent();
            this.splitMain.SplitterPosition = this.Height;
            this.txtMain.ReplaceService<ISyntaxHighlightService>(new CustomSyntaxHighlightService(this.txtMain.Document));
            this.txtMain.Views.SimpleView.Padding = new System.Windows.Forms.Padding(20, 4, 4, 0);
            this.txtMain.Views.DraftView.Padding = new System.Windows.Forms.Padding(20, 4, 4, 0);
            this.txtMain.Views.SimpleView.AllowDisplayLineNumbers = true;
            this.txtMain.Views.DraftView.AllowDisplayLineNumbers = true;

            this.txtMain.Document.Sections[0].LineNumbering.Start = 1;
            this.txtMain.Document.Sections[0].LineNumbering.CountBy = 1;
            this.txtMain.Document.Sections[0].LineNumbering.Distance = 75f;
            this.txtMain.Document.Sections[0].LineNumbering.RestartType = DevExpress.XtraRichEdit.API.Native.LineNumberingRestart.Continuous;

            this.txtMain.Document.CharacterStyles["Line Number"].FontName = "Courier New";
            this.txtMain.Document.CharacterStyles["Line Number"].FontSize = 10;
            this.txtMain.Document.CharacterStyles["Line Number"].ForeColor = Color.DarkGray;
            this.txtMain.Document.CharacterStyles["Line Number"].Bold = true;

        }

        public DatabaseInfo DatabaseInfo
        {
            get
            {
                return databaseInfo;
            }

            set
            {
                databaseInfo = value;
            }
        }

        public SelectInfo SelectInfo
        {
            get
            {
                return selectInfo;
            }

            set
            {
                selectInfo = value;
            }
        }

        public SaveSelectForm SaveSelectForm
        {
            get
            {
                return saveSelectForm;
            }

            set
            {
                saveSelectForm = value;
            }
        }

        public ToolStripLabel Statement
        {
            get
            {
                return statement;
            }

            set
            {
                statement = value;
            }
        }

        public ToolStripLabel PageInfo
        {
            get
            {
                return pageInfo;
            }

            set
            {
                pageInfo = value;
            }
        }

        public ToolStripLabel TimeInfo
        {
            get
            {
                return timeInfo;
            }

            set
            {
                timeInfo = value;
            }
        }

        private void tsbtnSaveSelect_Click(object sender, EventArgs e)
        {
            if (this.selectInfo == null)
            {
                if (this.saveSelectForm == null)
                {
                    this.saveSelectForm = new SaveSelectForm();
                    this.saveSelectForm.NewSelectPage = this;
                }
                this.saveSelectForm.ShowDialog();
            }
            else
            {
                this.tsbtnSaveSelect.Enabled = false;
                try
                {
                    //update the contents to sqlite
                    this.selectInfo.Update(this.txtMain.Text);
                }
                catch (Exception ex)
                {
                    LogHelper.logerror.Error(ex);
                }
                finally
                {
                    this.tsbtnSaveSelect.Enabled = true;
                }
            }
        }

        public void CreateSelect(string name)
        {
            this.selectInfo = this.databaseInfo.CreateSelect(name, this.txtMain.Text);
        }

        public void SetStatusBar()
        {
            
        }

        public void BindData()
        {
            this.txtMain.Text = this.selectInfo.Dataset.Tables[0].Rows[0][0].ToString();
            //this.txtMain.ReplaceService<ISyntaxHighlightService>(new MySyntaxHighlightServiceCSharp(this.txtMain));//高亮显示
            //this.txtMain.ReplaceService<ISyntaxHighlightService>(new CustomSyntaxHighlightService(this.txtMain.Document));//高亮显示
        }
    }
}
