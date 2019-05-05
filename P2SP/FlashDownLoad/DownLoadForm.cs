using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

using UserComponents.FlashDownLoadComp;
using UserComponents.DownLoadService;
using Helper;
using System.Threading;
using System.IO;
using System.Data.Entity;

namespace FlashDownLoad
{
    public partial class DownLoadForm : DevExpress.XtraEditors.XtraForm
    {
        public DownLoadForm()
        {
            InitializeComponent();
        }

        private NewTaskForm newTaskForm;
        private DeleteForm deleteForm;
        private ConfigForm configForm;

        public NewTaskForm NewTaskForm
        {
            get
            {
                return newTaskForm;
            }

            set
            {
                newTaskForm = value;
            }
        }

        public DeleteForm DeleteForm
        {
            get
            {
                return deleteForm;
            }

            set
            {
                deleteForm = value;
            }
        }

        public ConfigForm ConfigForm
        {
            get
            {
                return configForm;
            }

            set
            {
                configForm = value;
            }
        }

        private void DownLoadForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.panelDownLoadTask.Parent = this.xtpDownLoad;
                this.panelCompleteTask.Parent = this.xtpComplete;
                this.panelTrashTask.Parent = this.xtpTrash;
                AsyncHelper.AsyncHandler ah_monitor = new AsyncHelper.AsyncHandler(AsyncMonitor);
                ah_monitor.BeginInvoke(null, null);
                bool auto_finish_task = ConfigHelper.GetAttributeBool(Resource.AutoFinishTask);
                using (var db = new FDownLoadEntities())
                {
                    var list = db.TableTask.ToList();
                    foreach (TableTask t in list)
                    {
                        TaskStatus status = EnumHelper.GetEnum<TaskStatus>(t.Status);
                        DownLoadTask task = DownLoadService.Instance.GetTask(t.Url);
                        task.TaskId = t.TaskId;
                        task.Name = t.Name;
                        task.Size = t.FileSize;
                        task.Status = EnumHelper.GetEnum<TaskStatus>(t.Status);
                        task.FullName = t.FullName;
                        task.TempFullName = t.TempFullName;
                        task.CreateTime = t.CreateTime;
                        task.FinishTime = t.FinishTime;
                        task.Status = status;
                        task.Directory = t.Directory;
                        task.Threads = t.Threads;
                        task.IsTrashed = t.IsTrashed;
                        if (task.IsTrashed)
                        {
                            this.AddTrashTask(task);
                            continue;
                        }
                        STATUS_CHANGE:
                        switch (status)
                        {
                            case TaskStatus.Start:
                                {
                                    if (!auto_finish_task)
                                    {
                                        status = TaskStatus.Stop;
                                        task.Status = status;
                                        var tt = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                                        if (tt != null)
                                        {
                                            tt.Status = EnumHelper.GetDescription(task.Status);
                                        }
                                        db.SaveChanges();
                                        goto STATUS_CHANGE;
                                    }
                                    if (!File.Exists(t.TempFullName))
                                    {
                                        task.GetInfoFromUrl();
                                    }
                                    else
                                    {
                                        task.GetInfoFromMeta();
                                    }
                                    this.AddDownLoadTask(task);
                                    this.StartTask(task);
                                    break;
                                }
                            case TaskStatus.Fail:
                                {
                                    this.AddDownLoadTask(task);
                                    DownLoadService.Instance.AddFailTask(task);
                                    break;
                                }
                            case TaskStatus.Stop:
                                {
                                    if (!File.Exists(t.TempFullName))
                                    {
                                        //do nothing
                                    }
                                    else
                                    {
                                        task.GetInfoFromMeta();
                                    }
                                    this.AddDownLoadTask(task);
                                    DownLoadService.Instance.AddStopTask(task);
                                    break;
                                }
                            case TaskStatus.Wait:
                                {
                                    status = TaskStatus.Stop;
                                    task.Status = status;
                                    var tt = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                                    if (tt != null)
                                    {
                                        tt.Status = EnumHelper.GetDescription(task.Status);
                                    }
                                    db.SaveChanges();
                                    goto STATUS_CHANGE;
                                }
                            case TaskStatus.Finish:
                                {
                                    if (!File.Exists(t.FullName))
                                    {
                                        task.IsDeleted = true;
                                    }
                                    this.AddCompleteTask(task);
                                    DownLoadService.Instance.AddFinishTask(task);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }

            #region demo

            //string[] ext = new string[] {
            //    ".asf", ".avi", ".exe", ".iso", ".mp3",
            //    ".mpeg", ".mpg", ".mpga", ".ra", ".rar",
            //    ".rm", ".rmvb", ".tar", ".wma", ".wmp",
            //    ".wmv", ".mov", ".zip", ".3gp", ".chm",
            //    ".mdf", ".torrent", ".jar", ".msi", ".arj",
            //    ".bin", ".dll", ".psd", ".hqx", ".sit",
            //    ".lzh", ".gz", ".tgz", ".xlsx", ".xls",
            //    ".doc", ".docx", ".ppt", ".pptx", ".flv",
            //    ".mkv", ".tp", ".ts", ".flac", ".ape", 
            //    ".wav", ".aac", ".txt", ".dat", ".7z", 
            //    ".ttf", ".bat", ".xv", ".xvx", ".pdf",
            //    ".mp4", ".jpg", ".png"};
            //Random r = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    int idx = r.Next(ext.Length);
            //    DownLoadTaskItem downLoadTaskItem = new DownLoadTaskItem();
            //    downLoadTaskItem.ItemName = "Thurder_" + i.ToString() + ext[idx];
            //    downLoadTaskItem.ItemSize = 1024 * 1024 * 500;
            //    downLoadTaskItem.ItemDownLoadSize = 1024 * 1024 * 50;
            //    downLoadTaskItem.ItemSpeed = 1024 * 1024 * 3;
            //    if (i == 0 || i == 2)
            //    {
            //        downLoadTaskItem.ItemStatus = TaskStatus.Stop;
            //    }
            //    else
            //    {
            //        downLoadTaskItem.ItemStatus = TaskStatus.Start;
            //    }
            //    this.panelDownLoadTask.AddControls(downLoadTaskItem);

            //    idx = r.Next(ext.Length);
            //    CompleteTaskItem completeTaskItem = new CompleteTaskItem();
            //    completeTaskItem.ItemName = "Thurder" + ext[idx];
            //    completeTaskItem.ItemSize = 1024 * 1024 * 500;
            //    this.panelCompleteTask.AddControls(completeTaskItem);

            //    idx = r.Next(ext.Length);
            //    TrashTaskItem trashTaskItem = new TrashTaskItem();
            //    trashTaskItem.ItemName = "Thurder" + ext[idx];
            //    trashTaskItem.ItemSize = 1024 * 1024 * 500;
            //    this.panelTrashTask.AddControls(trashTaskItem);
            //}
            #endregion
        }

        private void AsyncMonitor()
        {
            try
            {
                while (true)
                {
                    long speed = 0;
                    foreach (DownLoadTaskItem taskItem in this.panelDownLoadTask.Items)
                    {
                        if (taskItem.ItemStatus == TaskStatus.Start)
                        {
                            speed += taskItem.ItemSpeed;
                        }
                    }
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        this.bbtnSpeed.Caption = DiskHelper.GetSize(speed) + "/s";
                    }));
                    Thread.Sleep(1000);
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void DownLoadForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.DeleteSelectedTask();
            }
        }

        private void xtcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.bbtnThroughDeleteM.Visibility = BarItemVisibility.Never;
            this.bbtnNew.Visibility = BarItemVisibility.Never;
            this.bbtnOpen.Visibility = BarItemVisibility.Never;
            this.bbtnSetting.Visibility = BarItemVisibility.Always;
            this.bbtnStart.Visibility = BarItemVisibility.Never;
            this.bbtnStop.Visibility = BarItemVisibility.Never;
            if (this.xtcMain.SelectedTabPageIndex == 0)
            {
                this.bbtnThroughDeleteM.Visibility = BarItemVisibility.Always;
                this.bbtnNew.Visibility = BarItemVisibility.Always;
                this.bbtnStart.Visibility = BarItemVisibility.Always;
                this.bbtnStop.Visibility = BarItemVisibility.Always;
                this.bbtnOpen.Visibility = BarItemVisibility.Never;
            }
            else if (this.xtcMain.SelectedTabPageIndex == 1)
            {
                this.bbtnThroughDeleteM.Visibility = BarItemVisibility.Always;
                this.bbtnNew.Visibility = BarItemVisibility.Always;
                this.bbtnStart.Visibility = BarItemVisibility.Never;
                this.bbtnStop.Visibility = BarItemVisibility.Never;
                this.bbtnOpen.Visibility = BarItemVisibility.Always;
            }
            else if (this.xtcMain.SelectedTabPageIndex == 2)
            {
                this.bbtnThroughDeleteM.Visibility = BarItemVisibility.Always;
                this.bbtnNew.Visibility = BarItemVisibility.Never;
                this.bbtnStart.Visibility = BarItemVisibility.Never;
                this.bbtnStop.Visibility = BarItemVisibility.Never;
                this.bbtnOpen.Visibility = BarItemVisibility.Always;
            }
            else
            {
                //Do Nothing
            }
        }

        private void panelDownLoadTask_SelectedItemsChanged(object sender, EventArgs e)
        {
            this.bbtnStart.Enabled = false;
            this.bbtnStop.Enabled = false;
            this.bbtnThroughDeleteM.Enabled = false;

            foreach (DownLoadTaskItem taskItem in this.panelDownLoadTask.SelectedItems)
            {
                if (taskItem.ItemStatus == TaskStatus.Start || taskItem.ItemStatus == TaskStatus.Wait)
                {
                    this.bbtnStop.Enabled = true;
                }
                else if (taskItem.ItemStatus == TaskStatus.Stop || taskItem.ItemStatus == TaskStatus.Fail)
                {
                    this.bbtnStart.Enabled = true;
                }
                else
                {
                    //Do Nothing
                }
                this.bbtnThroughDeleteM.Enabled = true;
            }
        }

        private void panelCompleteTask_SelectedItemsChanged(object sender, EventArgs e)
        {
            this.bbtnThroughDeleteM.Enabled = false;
            this.bbtnOpen.Enabled = false;
            if (this.panelCompleteTask.SelectedItems.Count == 1)
            {
                this.bbtnOpen.Enabled = true;
                this.bbtnThroughDeleteM.Enabled = true;
            }
            else if (this.panelCompleteTask.SelectedItems.Count > 1)
            {
                this.bbtnOpen.Enabled = false;
                this.bbtnThroughDeleteM.Enabled = true;
            }
            else
            {
                //Do Nothing
            }
        }

        private void panelTrashTask_SelectedItemsChanged(object sender, EventArgs e)
        {
            if (this.panelTrashTask.SelectedItems.Count == 1)
            {
                this.bbtnOpen.Enabled = true;
                this.bbtnThroughDeleteM.Enabled = true;
            }
            else if (this.panelTrashTask.SelectedItems.Count > 1)
            {
                this.bbtnOpen.Enabled = false;
                this.bbtnThroughDeleteM.Enabled = true;
            }
            else
            {
                //Do Nothing
            }
        }

        private void panelDownLoadTask_SelectedItemsMouseRightDown(object sender, MouseEventArgs e)
        {
            this.pmDownLoad.ShowPopup(Control.MousePosition);
        }

        private void panelCompleteTask_SelectedItemsMouseRightDown(object sender, MouseEventArgs e)
        {
            this.pmComplete.ShowPopup(Control.MousePosition);
        }

        private void panelTrashTask_SelectedItemsMouseRightDown(object sender, MouseEventArgs e)
        {
            this.pmTrash.ShowPopup(Control.MousePosition);
        }

        private void bbtnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.newTaskForm == null)
            {
                this.newTaskForm = new NewTaskForm();
                this.newTaskForm.DownLoadForm = this;
            }
            this.newTaskForm.ShowDialog();
        }

        private void bbtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbtnSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.configForm == null)
            {
                this.configForm = new ConfigForm();
            }
            this.configForm.LoadConfig();
            this.configForm.ShowDialog();
        }

        private void bbtnTroughDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.deleteForm == null)
            {
                this.deleteForm = new DeleteForm();
                this.deleteForm.DownLoadForm = this;
            }
            this.deleteForm.ShowDialog();
        }

        private void DeleteSelectedTask()
        {
            if (this.xtcMain.SelectedTabPageIndex == 0)
            {
                foreach (DownLoadTaskItem taskItem in this.panelDownLoadTask.SelectedItems)
                {
                    DownLoadTask task = taskItem.Task;
                    if (task.Status != TaskStatus.Stop)
                    {
                        this.StopTask(task);
                    }
                    task.IsTrashed = true;
                    using (var db = new FDownLoadEntities())
                    {
                        var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                        if (t != null)
                        {
                            t.IsTrashed = task.IsTrashed;
                            t.Status = EnumHelper.GetDescription(task.Status);
                            db.SaveChanges();
                        }
                    }
                    this.AddTrashTask(task);
                }
                this.panelDownLoadTask.DeleteSelectedItem();
            }
            else if (this.xtcMain.SelectedTabPageIndex == 1)
            {
                foreach (CompleteTaskItem taskItem in this.panelCompleteTask.SelectedItems)
                {
                    DownLoadTask task = taskItem.Task;
                    task.IsTrashed = true;
                    using (var db = new FDownLoadEntities())
                    {
                        var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                        if (t != null)
                        {
                            t.IsTrashed = task.IsTrashed;
                            db.SaveChanges();
                        }
                    }
                    this.AddTrashTask(task);
                }
                this.panelCompleteTask.DeleteSelectedItem();
            }
            else if (this.xtcMain.SelectedTabPageIndex == 2)
            {
                foreach (TrashTaskItem taskItem in this.panelTrashTask.SelectedItems)
                {
                    DownLoadTask task = taskItem.Task;
                    using (var db = new FDownLoadEntities())
                    {
                        var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                        if (t != null)
                        {
                            db.TableTask.Remove(t);
                            db.SaveChanges();
                        }
                    }
                }
                this.panelTrashTask.DeleteSelectedItem();
            }
            else
            {
                //Do Nothing;
            }
        }

        public void DeleteSelectedTask(bool isdelete)
        {
            if (isdelete)
            {
                if (this.xtcMain.SelectedTabPageIndex == 0)
                {
                    foreach (DownLoadTaskItem taskItem in this.panelDownLoadTask.SelectedItems)
                    {
                        DownLoadTask task = taskItem.Task;
                        if (task.Status != TaskStatus.Stop)
                        {
                            this.StopTask(task);
                        }
                        using (var db = new FDownLoadEntities())
                        {
                            var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                            if (t != null)
                            {
                                db.TableTask.Remove(t);
                                db.SaveChanges();
                            }
                        }
                        DownLoadService.Instance.RemoveStopTask(task);
                        DownLoadService.Instance.RemoveStartTask(task);
                        DownLoadService.Instance.RemoveWaitTask(task);
                        DownLoadService.Instance.RemoveFailTask(task);
                        if (File.Exists(task.TempFullName))
                        {
                            File.Delete(task.TempFullName);
                        }
                    }
                    this.panelDownLoadTask.DeleteSelectedItem();
                }
                else if (this.xtcMain.SelectedTabPageIndex == 1)
                {
                    foreach (CompleteTaskItem taskItem in this.panelCompleteTask.SelectedItems)
                    {
                        DownLoadTask task = taskItem.Task;
                        using (var db = new FDownLoadEntities())
                        {
                            var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                            if (t != null)
                            {
                                db.TableTask.Remove(t);
                                db.SaveChanges();
                            }
                        }
                        DownLoadService.Instance.RemoveFinishTask(task);
                        if (File.Exists(task.FullName))
                        {
                            File.Delete(task.FullName);
                        }
                    }
                    this.panelCompleteTask.DeleteSelectedItem();
                }
                else if (this.xtcMain.SelectedTabPageIndex == 2)
                {
                    foreach (TrashTaskItem taskItem in this.panelTrashTask.SelectedItems)
                    {
                        DownLoadTask task = taskItem.Task;
                        using (var db = new FDownLoadEntities())
                        {
                            var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                            if (t != null)
                            {
                                db.TableTask.Remove(t);
                                db.SaveChanges();
                            }
                        }
                        DownLoadService.Instance.RemoveTrashTask(task);
                        if (task.Status == TaskStatus.Finish)
                        {
                            if (File.Exists(task.FullName))
                            {
                                File.Delete(task.FullName);
                            }
                        }
                        else
                        {
                            if (File.Exists(task.TempFullName))
                            {
                                File.Delete(task.TempFullName);
                            }
                        }
                    }
                    this.panelTrashTask.DeleteSelectedItem();
                }
                else
                {
                    //Do Nothing;
                }
            }
            else
            {
                this.DeleteSelectedTask();
            }
        }

        public void StopTask(DownLoadTask task)
        {
            task.TaskStart -= Task_TaskStart;
            task.TaskFail -= Task_TaskFail;
            task.TaskFinish -= Task_TaskFinish;
            task.TaskMonitor -= Task_TaskMonitor;
            task.Stop();
        }

        public void StartTask(DownLoadTask task)
        {
            task.TaskWait += Task_TaskWait;
            task.TaskStart += Task_TaskStart;
            task.TaskStop += Task_TaskStop;
            task.TaskFail += Task_TaskFail;
            task.TaskFinish += Task_TaskFinish;
            task.TaskMonitor += Task_TaskMonitor;
            AsyncHelper.AsyncHandlerArgs ah = new AsyncHelper.AsyncHandlerArgs(this.AsyncStart);
            ah.BeginInvoke(task, null, null);  
        }

        private void AsyncStart(object args)
        {
            DownLoadTask task = args as DownLoadTask;
            task.Start();
        }

        private void Task_TaskWait(object sender, TaskWaitEventArgs e)
        {
            DownLoadTask task = sender as DownLoadTask;
            TaskItem taskItem = task.TaskItem as TaskItem;
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                taskItem.ItemStatus = task.Status;
            }));
            using (var db = new FDownLoadEntities())
            {
                var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                if (t != null)
                {
                    t.Status = EnumHelper.GetDescription(task.Status);
                    t.FinishTime = DateTime.Now;
                }
                db.SaveChanges();
            }
        }

        public void AddDownLoadTask(DownLoadTask task)
        {
            DownLoadTaskItem downLoadTaskItem = new DownLoadTaskItem();
            downLoadTaskItem.ItemName = task.Name;
            downLoadTaskItem.ItemSize = task.Size;
            if (task.Status == TaskStatus.Start)
            {
                downLoadTaskItem.ItemDownLoadSize = task.DownLoadSize;
                downLoadTaskItem.ItemSpeed = 0;
            }
            if (task.Size > 0)
            {
                downLoadTaskItem.ItemProgress = (int)(100 * task.DownLoadSize / task.Size);
            }
            downLoadTaskItem.ItemStatus = task.Status;
            downLoadTaskItem.Task = task;
            task.TaskItem = downLoadTaskItem;
            this.panelDownLoadTask.AddControls(downLoadTaskItem);
        }

        private void AddCompleteTask(DownLoadTask task)
        {
            CompleteTaskItem completeTaskItem = new CompleteTaskItem();
            completeTaskItem.ItemName = task.Name;
            completeTaskItem.ItemSize = task.Size;
            completeTaskItem.ItemCreateTime = DateTime.Now;
            completeTaskItem.ItemIsDeleted = task.IsDeleted; 
            completeTaskItem.Task = task;
            task.TaskItem = completeTaskItem;
            this.panelCompleteTask.AddControls(completeTaskItem);
        }

        private void AddTrashTask(DownLoadTask task)
        {
            TrashTaskItem trashTaskItem = new TrashTaskItem();
            trashTaskItem.ItemName = task.Name;
            trashTaskItem.ItemSize = task.Size;
            trashTaskItem.ItemCreateTime = task.CreateTime;
            trashTaskItem.Task = task;
            task.TaskItem = trashTaskItem;
            this.panelTrashTask.AddControls(trashTaskItem);
        }

        private void Task_TaskMonitor(object sender, TaskMonitorEventArgs e)
        {
            DownLoadTask task = sender as DownLoadTask;
            DownLoadTaskItem taskItem = task.TaskItem as DownLoadTaskItem;
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                taskItem.ItemSpeed = e.DownloadSize - taskItem.ItemDownLoadSize;
                taskItem.ItemDownLoadSize = e.DownloadSize;
                LogHelper.loginfo.Info(e.DownloadSize + "-" + taskItem.ItemDownLoadSize);
                taskItem.ItemProgress = (int)(100 * taskItem.ItemDownLoadSize / taskItem.ItemSize);
                if (taskItem.ItemSpeed != 0)
                {
                    taskItem.ItemRemainSecond = (int)((taskItem.ItemSize - taskItem.ItemDownLoadSize) / taskItem.ItemSpeed);
                }
            }));
        }

        private void Task_TaskFinish(object sender, TaskFinishEventArgs e)
        {
            DownLoadTask task = sender as DownLoadTask;
            TaskItem taskItem = task.TaskItem as TaskItem;
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                taskItem.ItemStatus = task.Status;
                this.panelDownLoadTask.RemoveControls(taskItem);
                this.AddCompleteTask(task);
            }));
            using (var db = new FDownLoadEntities())
            {
                var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                if (t != null)
                {
                    t.Status = EnumHelper.GetDescription(task.Status);
                    t.FinishTime = DateTime.Now;
                }
                db.SaveChanges();
            }
            DownLoadService.Instance.RemoveStartTask(task);
            DownLoadService.Instance.AddFinishTask(task);
            task = DownLoadService.Instance.GetWaitTask();
            if (task != null)
            {
                AsyncHelper.AsyncHandlerArgs ahArgs = new AsyncHelper.AsyncHandlerArgs(this.AsyncStart);
                ahArgs.BeginInvoke(task, null, null);
            }
        }

        private void Task_TaskFail(object sender, TaskFailEventArgs e)
        {
            DownLoadTask task = sender as DownLoadTask;
            TaskItem taskItem = task.TaskItem as TaskItem;
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                taskItem.ItemStatus = task.Status;
            }));
            using (var db = new FDownLoadEntities())
            {
                var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                if (t != null)
                {
                    t.Status = EnumHelper.GetDescription(task.Status);
                }
                db.SaveChanges();
            }
            DownLoadService.Instance.RemoveStartTask(task);
            DownLoadService.Instance.AddFailTask(task);
        }

        private void Task_TaskStop(object sender, TaskStopEventArgs e)
        {
            DownLoadTask task = sender as DownLoadTask;
            TaskItem taskItem = task.TaskItem as TaskItem;
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                task.TaskStop -= Task_TaskStop;
                taskItem.ItemStatus = task.Status;
            }));
            using (var db = new FDownLoadEntities())
            {
                var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                if (t != null)
                {
                    t.Status = EnumHelper.GetDescription(task.Status);
                }
                db.SaveChanges();
            }
            DownLoadService.Instance.RemoveWaitTask(task);
            DownLoadService.Instance.RemoveStartTask(task);
            DownLoadService.Instance.AddStopTask(task);
            task = DownLoadService.Instance.GetWaitTask();
            if (task != null)
            {
                AsyncHelper.AsyncHandlerArgs ahArgs = new AsyncHelper.AsyncHandlerArgs(this.AsyncStart);
                ahArgs.BeginInvoke(task, null, null);
            }
        }

        private void Task_TaskStart(object sender, TaskStartEventArgs e)
        {
            try
            {
                DownLoadTask task = sender as DownLoadTask;
                TaskItem taskItem = task.TaskItem as TaskItem;
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    taskItem.ItemStatus = task.Status;
                    taskItem.ItemName = task.Name;
                    taskItem.ItemSize = task.Size;
                }));
                using (var db = new FDownLoadEntities())
                {
                    var t = db.TableTask.FirstOrDefault(x => x.TaskId == task.TaskId);
                    if (t != null)
                    {
                        t.Status = EnumHelper.GetDescription(task.Status);
                        t.Name = task.Name;
                        t.FullName = task.FullName;
                        t.TempFullName = task.TempFullName;
                        t.FileSize = task.Size;
                    }
                    db.SaveChanges();
                }
                DownLoadService.Instance.RemoveStopTask(task);
                DownLoadService.Instance.AddStartTask(task);
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void bbtnStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.xtcMain.SelectedTabPageIndex == 0)
            {
                foreach(TaskItem taskItem in this.panelDownLoadTask.SelectedItems)
                {
                    this.StopTask(taskItem.Task);
                }
                this.bbtnStop.Enabled = false;
                this.bbtnStart.Enabled = true;
            }
            
        }

        private void bbtnStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.xtcMain.SelectedTabPageIndex == 0)
            {
                foreach (TaskItem taskItem in this.panelDownLoadTask.SelectedItems)
                {
                    this.StartTask(taskItem.Task);
                }
                this.bbtnStop.Enabled = true;
                this.bbtnStart.Enabled = false;
            }
        }

        private void bbtnDownLoadCopyUrl_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (DownLoadTaskItem taskItem in this.panelDownLoadTask.SelectedItems)
            {
                Clipboard.SetText(taskItem.Task.Url);
            }
        }

        private void btnCompleteCopyUrl_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (CompleteTaskItem taskItem in this.panelCompleteTask.SelectedItems)
            {
                Clipboard.SetText(taskItem.Task.Url);
            }
        }
    }
}
