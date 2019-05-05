using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UserComponents.DownLoadService;
using Helper;

namespace FlashDownLoad
{
    public partial class NewTaskForm : DevExpress.XtraEditors.XtraForm
    {
        private DownLoadForm downLoadForm = null;

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

        public NewTaskForm()
        {
            InitializeComponent();
        }

        private void NewTaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DownLoadTask task = DownLoadService.Instance.GetTask(this.txtUrl.Text);
                task.Directory = ConfigHelper.GetAttribute(Resource.DownLoadDirectory);
                task.Threads = (short)ConfigHelper.GetAttributeInt(Resource.MaxThreads, 5);
                task.LoadUrl();
                task.CreateTime = DateTime.Now;
                using (var db = new FDownLoadEntities())
                {
                    TableTask t = db.TableTask.Add(new TableTask()
                    {
                        TaskId = db.TableTask.Count(),
                        Name = task.Name,
                        Url = task.Url,
                        FullName = "",
                        TempFullName = "",
                        FileSize = task.Size,
                        Status = EnumHelper.GetDescription(task.Status),
                        CreateTime = task.CreateTime,
                        Directory = task.Directory,
                        Threads = task.Threads,
                        IsTrashed = task.IsTrashed
                    });
                    db.SaveChanges();
                    task.TaskId = t.TaskId;
                }
                this.downLoadForm.AddDownLoadTask(task);
                this.downLoadForm.StartTask(task);
                this.Hide();
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }
    }
}