using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace UserComponents.DownLoadService
{
    public enum TaskProtocol
    {
        [Description("unknow")]
        Unknow,
        [Description("http")]
        Http,
        [Description("ftp")]
        Ftp,
        [Description("thunder")]
        Thunder,
        [Description("bt")]
        BT,
        [Description("ed2k")]
        Ed2k
    }

    public enum TaskStatus
    {
        [Description("start")]
        Start,
        [Description("stop")]
        Stop,
        [Description("wait")]
        Wait,
        [Description("finish")]
        Finish,
        [Description("fail")]
        Fail
    }

    [Serializable]
    public class TaskMetaData
    {
        private string url;
        private string name;
        private string fullName;
        private string tempFullName;
        private long size;
        private short threads;
        private Block[] blocks;

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public long Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public short Threads
        {
            get
            {
                return threads;
            }

            set
            {
                threads = value;
            }
        }

        public Block[] Blocks
        {
            get
            {
                return blocks;
            }

            set
            {
                blocks = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string TempFullName
        {
            get
            {
                return tempFullName;
            }

            set
            {
                tempFullName = value;
            }
        }
    }

    [Serializable]
    public class Block
    {
        private long start;
        private long end;
        private long offset;

        public Block(long start, long end, long offset)
        {
            this.start = start;
            this.end = end;
            this.offset = offset;
        }

        public long Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public long End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        public long Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }
    }

    public class StartOneThreadEventArgs: EventArgs
    {
        private int idx;
        private ManualResetEvent finish;

        public int Idx
        {
            get
            {
                return idx;
            }

            set
            {
                idx = value;
            }
        }

        public ManualResetEvent Finish
        {
            get
            {
                return finish;
            }

            set
            {
                finish = value;
            }
        }

        public StartOneThreadEventArgs(int _idx, ManualResetEvent _finish)
            :
            base()
        {
            this.idx = _idx;
            this.finish = _finish;
        }
    }

    public class TaskStartEventArgs: EventArgs
    {
        public TaskStartEventArgs()
            :
            base()
        {

        }
    }

    public class TaskStopEventArgs: EventArgs
    {
        public TaskStopEventArgs()
            :
            base()
        {

        }
    }

    public class TaskFailEventArgs: EventArgs
    {
        public TaskFailEventArgs()
            :
            base()
        {

        }
    }

    public class TaskFinishEventArgs: EventArgs
    {
        public TaskFinishEventArgs()
            :
            base()
        {

        }
    }

    public class TaskWaitEventArgs: EventArgs
    {
        public TaskWaitEventArgs()
            :
            base()
        {

        }
    }

    public class TaskMonitorEventArgs: EventArgs
    {
        private long downloadSize;

        public TaskMonitorEventArgs(long _downloadSize)
            :
            base()
        {
            this.downloadSize = _downloadSize;
        }

        public long DownloadSize
        {
            get
            {
                return downloadSize;
            }

            set
            {
                downloadSize = value;
            }
        }
    }

    public delegate void TaskStartHandler(object sender, TaskStartEventArgs e);
    public delegate void TaskStopHandler(object sender, TaskStopEventArgs e);
    public delegate void TaskFailHandler(object sender, TaskFailEventArgs e);
    public delegate void TaskFinishHandler(object sender, TaskFinishEventArgs e);
    public delegate void TaskWaitHandler(object sender, TaskWaitEventArgs e);
    public delegate void TaskMonitorHandler(object sender, TaskMonitorEventArgs e);

    public abstract class DownLoadTask : IDownLoadTask
    {
        protected TaskMetaData metaData;
        protected TaskProtocol protocol;
        protected TaskStatus status;
        protected long taskId;
        protected string url;
        protected string name;
        protected string fullName;
        protected string tempFullName;
        protected string directory;
        protected short threads;
        protected long size;
        protected long downLoadSize;
        protected object taskItem;
        protected DateTime createTime;
        protected DateTime finishTime;
        protected bool isDeleted = false;
        protected bool isTrashed = false;

        public TaskProtocol Protocol
        {
            get
            {
                return protocol;
            }

            set
            {
                protocol = value;
            }
        }

        public TaskStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Directory
        {
            get
            {
                return directory;
            }

            set
            {
                directory = value;
            }
        }

        public short Threads
        {
            get
            {
                return threads;
            }

            set
            {
                threads = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public long Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public object TaskItem
        {
            get
            {
                return taskItem;
            }

            set
            {
                taskItem = value;
            }
        }

        public TaskMetaData MetaData
        {
            get
            {
                return metaData;
            }

            set
            {
                metaData = value;
            }
        }

        public long DownLoadSize
        {
            get
            {
                return downLoadSize;
            }

            set
            {
                downLoadSize = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string TempFullName
        {
            get
            {
                return tempFullName;
            }

            set
            {
                tempFullName = value;
            }
        }

        public long TaskId
        {
            get
            {
                return taskId;
            }

            set
            {
                taskId = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }

            set
            {
                createTime = value;
            }
        }

        public DateTime FinishTime
        {
            get
            {
                return finishTime;
            }

            set
            {
                finishTime = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }

        public bool IsTrashed
        {
            get
            {
                return isTrashed;
            }

            set
            {
                isTrashed = value;
            }
        }

        public event TaskStartHandler TaskStart;
        public event TaskStopHandler TaskStop;
        public event TaskFailHandler TaskFail;
        public event TaskFinishHandler TaskFinish;
        public event TaskWaitHandler TaskWait;
        public event TaskMonitorHandler TaskMonitor;

        protected virtual void OnTaskStart(TaskStartEventArgs e)
        {
            this.status = TaskStatus.Start;
            if (this.TaskStart != null)
            {
                this.TaskStart(this, e);
            }
        }

        protected virtual void OnTaskStop(TaskStopEventArgs e)
        {
            this.status = TaskStatus.Stop;
            if (this.TaskStop != null)
            {
                this.TaskStop(this, e);
            }
        }

        protected virtual void OnTaskFail(TaskFailEventArgs e)
        {
            this.status = TaskStatus.Fail;
            if (this.TaskFail != null)
            {
                this.TaskFail(this, e);
            }
        }

        protected virtual void OnTaskFinish(TaskFinishEventArgs e)
        {
            this.status = TaskStatus.Finish;
            if (this.TaskFinish != null)
            {
                this.TaskFinish(this, e);
            }
        }

        protected virtual void OnTaskProgress(TaskMonitorEventArgs e)
        {
            if (this.TaskMonitor != null)
            {
                this.TaskMonitor(this, e);
            }
        }

        protected virtual void OnTaskWait(TaskWaitEventArgs e)
        {
            this.status = TaskStatus.Wait;
            if (this.TaskWait != null)
            {
                this.TaskWait(this, e);
            }
        }

        public abstract void Start();

        public abstract void Stop();

        public abstract void Wait();

        public abstract void Finish();

        public abstract void Fail();

        public abstract bool LoadUrl();
        public abstract bool GetInfoFromUrl();

        public abstract bool GetInfoFromMeta();
        
    }
}
