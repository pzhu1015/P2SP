using Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserComponents.DownLoadService
{
    public class DownLoadService
    {
        public readonly string FLASH_DOWNLOAD_EXTEND = ".fd";
        private static DownLoadService instance = new DownLoadService();
        private int maxStart = 2;
        private static object listLocker = new object();
        private List<DownLoadTask> taskWaitList = new List<DownLoadTask>();
        private List<DownLoadTask> taskStartList = new List<DownLoadTask>();
        private List<DownLoadTask> taskStopList = new List<DownLoadTask>();
        private List<DownLoadTask> taskFinishList = new List<DownLoadTask>();
        private List<DownLoadTask> taskFailList = new List<DownLoadTask>();
        private List<DownLoadTask> taskTrashList = new List<DownLoadTask>();
        private DownLoadService()
        {

        }

        public static DownLoadService Instance
        {
            get { return instance; }
        }

        public DownLoadTask GetTask(string url)
        {
            //Parse the url to get protocol
            //url format like:
            //[protocol]://[hostname]:[port]/[path]/[parameters][?query]#fragment
            TaskProtocol protocol = TaskProtocol.Http;
            DownLoadTask task = null;
            switch (protocol)
            {
                case TaskProtocol.BT:
                    task = new BTDownLoadTask();
                    break;
                case TaskProtocol.Ed2k:
                    task = new Ed2kDownLoadTask();
                    break;
                case TaskProtocol.Ftp:
                    task = new FtpDownLoadTask();
                    break;
                case TaskProtocol.Http:
                    task = new HttpDownLoadTask();
                    break;
                case TaskProtocol.Thunder:
                    task = new ThunderDownLoadTasks();
                    break;
                default:
                    break;
            }
            task.Url = url;
            return task;
        }

        #region remove task from list
        public void RemoveStartTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskStartList.Remove(task);
            }
        }

        public void RemoveWaitTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskWaitList.Remove(task);
            }
        }

        public void RemoveFailTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskFailList.Remove(task);
            }
        }

        public void RemoveStopTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskStopList.Remove(task);
            }
        }

        public void RemoveFinishTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskFinishList.Remove(task);
            }
        }

        public void RemoveTrashTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskTrashList.Remove(task);
            }
        }
        #endregion


        #region add task to list
        public void AddStartTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskStartList.Add(task);
            }
        }

        public void AddStopTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskStopList.Add(task);
            }
        }

        public void AddWaitTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskWaitList.Add(task);
            }
        }

        public void AddFailTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskFailList.Add(task);
            }
        }

        public void AddFinishTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskFinishList.Add(task);
            }
        }

        public void AddTrashTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                this.taskTrashList.Add(task);
            }
        }
        #endregion

        public void ReStoreTask(DownLoadTask task)
        {
            lock (listLocker)
            {
                if (this.taskTrashList.Contains(task))
                {
                    this.taskTrashList.Remove(task);
                }
                if (task.Status == TaskStatus.Start)
                {
                    this.taskStartList.Add(task);
                }
                else if (task.Status == TaskStatus.Finish)
                {
                    this.taskFinishList.Add(task);
                }
                else if (task.Status == TaskStatus.Fail)
                {
                    this.taskFailList.Add(task);
                }
                else
                {
                    this.taskWaitList.Add(task);
                }
            }
        }

        //public void StopTask(DownLoadTask task)
        //{
        //    lock (listLocker)
        //    {
        //        if (this.taskStartList.Contains(task))
        //        {
        //            this.taskStartList.Remove(task);
        //        }

        //        if (this.taskWaitList.Contains(task))
        //        {
        //            this.taskWaitList.Remove(task);
        //        }
        //        this.taskStopList.Add(task);
        //    }
        //}

        public DownLoadTask GetWaitTask()
        {
            DownLoadTask task = null;
            lock(listLocker)
            {
                if (this.taskWaitList.Count > 0)
                {
                    task = this.taskWaitList.First<DownLoadTask>();
                }
            }
            return task;
        }

        //public void StartTask(DownLoadTask task)
        //{
        //    bool start = false;
        //    lock (listLocker)
        //    {
        //        if (!this.taskStopList.Contains(task) &&
        //        !this.taskStartList.Contains(task) &&
        //        !this.taskFailList.Contains(task) &&
        //        !this.taskFinishList.Contains(task))
        //        {
        //            if (this.taskStartList.Count < this.maxStart)
        //            {
        //                this.taskStartList.Add(task);
        //                start = true;

        //            }
        //            else
        //            {
        //                this.taskWaitList.Add(task);
        //            }
        //        }
        //        else if (this.taskStopList.Contains(task))
        //        {
        //            this.taskStopList.Remove(task);
        //            if (this.taskStartList.Count < this.maxStart)
        //            {
        //                this.taskStartList.Add(task);
        //                start = true;
        //            }
        //            else
        //            {
        //                this.taskWaitList.Add(task);
        //            }
        //        }
        //        else if (this.taskFailList.Contains(task))
        //        {
        //            this.taskFailList.Remove(task);
        //            if (this.taskStartList.Count < this.maxStart)
        //            {
        //                this.taskStartList.Add(task);
        //                start = true;
        //            }
        //            else
        //            {
        //                this.taskWaitList.Add(task);
        //            }
        //        }
        //        else
        //        {
        //            this.taskWaitList.Remove(task);
        //            if (this.taskStartList.Count < this.maxStart)
        //            {
        //                this.taskStartList.Add(task);
        //                start = true;
        //            }
        //        }
        //    }
        //    if (start)
        //    {
        //        task.Start();
        //    }
        //    else
        //    {
        //        task.Wait();
        //    }
        //}

        //public void FinishTask(DownLoadTask task)
        //{
        //    lock (listLocker)
        //    {
        //        if (this.taskStartList.Contains(task))
        //        {
        //            this.taskStartList.Remove(task);
        //        }
        //        this.taskFinishList.Add(task);
        //    }
        //    task.Finish();
        //}

        //public void FailTask(DownLoadTask task)
        //{
        //    lock (listLocker)
        //    {
        //        if (this.taskStartList.Contains(task))
        //        {
        //            this.taskStartList.Remove(task);
        //        }
        //        this.taskFailList.Add(task);
        //    }
        //    task.Fail();
        //}

        //public void StopAllTask()
        //{
        //    lock (listLocker)
        //    {
        //        foreach (DownLoadTask task in this.taskStartList)
        //        {
        //            this.taskStopList.Add(task);
        //            task.Stop();
        //        }
        //        foreach (DownLoadTask task in this.taskWaitList)
        //        {
        //            this.taskStopList.Add(task);
        //            task.Stop();
        //        }
        //    }
        //}

        public bool CheckAvaiableName(string _fullName)
        {
            lock (listLocker)
            {
                foreach (DownLoadTask task in this.taskWaitList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
                foreach (DownLoadTask task in this.taskStartList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
                foreach (DownLoadTask task in this.taskStopList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
                foreach (DownLoadTask task in this.taskFinishList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
                foreach (DownLoadTask task in this.taskTrashList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
                foreach (DownLoadTask task in this.taskFailList)
                {
                    if (task.FullName == _fullName)
                    {
                        return false;
                    }
                }
            }
            if (File.Exists(_fullName))
            {
                return false;
            }
            return true;
        }
    }
}
