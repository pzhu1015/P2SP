using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using UserComponents.DownLoadService;

namespace UserComponents.DownLoadService
{
    public class HttpDownLoadTask : DownLoadTask
    {
        private int count;

        private FileStream file;
        private static object fileLocker = new object();

        public override void Fail()
        {
            throw new NotImplementedException();
        }

        public override void Finish()
        {
            this.OnTaskFinish(new TaskFinishEventArgs());
        }

        public override void Start()
        {
            try
            {
                if (File.Exists(this.tempFullName))
                {
                    this.GetInfoFromMeta();
                }
                else
                {
                    this.GetInfoFromUrl();
                }
                this.OnTaskStart(new TaskStartEventArgs());
                AsyncHelper.AsyncHandler ah_start = new AsyncHelper.AsyncHandler(AsyncStart);
                ah_start.BeginInvoke(null, null);
                AsyncHelper.AsyncHandler ah_monitor = new AsyncHelper.AsyncHandler(AsyncMonitor);
                ah_monitor.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                this.OnTaskFail(new TaskFailEventArgs());
            }
        }
        public override void Stop()
        {
            this.OnTaskStop(new TaskStopEventArgs());
        }

        public override void Wait()
        {
            this.OnTaskWait(new TaskWaitEventArgs());
        }

        private void GetDownLoadSize()
        {
            this.downLoadSize = 0;
            lock (fileLocker)
            {
                if (this.metaData != null && this.metaData.Blocks != null)
                {
                    foreach (Block b in this.metaData.Blocks)
                    {
                        this.downLoadSize += (b.Offset - b.Start);
                    }
                }
            }
        }
        private void AsyncMonitor()
        {
            try
            {
                while (this.status == TaskStatus.Start)
                {
                    this.GetDownLoadSize();
                    if (this.downLoadSize > 0)
                    {
                        LogHelper.loginfo.Info(this.size + ", downloadSize: " + this.downLoadSize);
                        this.OnTaskProgress(new TaskMonitorEventArgs(this.downLoadSize));
                    }
                    Thread.Sleep(1000);
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
        }

        private void AsyncStart()
        {
            try
            {
                using (ManualResetEvent finish = new ManualResetEvent(false))
                {
                    this.count = this.metaData.Blocks.Length;
                    for (var i = 0; i < this.metaData.Blocks.Length; i++)
                    {
                        ThreadPool.QueueUserWorkItem((Object state) =>
                        {
                            this.StartOneThread(state);
                        }, new StartOneThreadEventArgs(i, finish));
                    }
                    finish.WaitOne();
                }
                if (this.status == TaskStatus.Start)
                {
                    this.file.Flush();
                    this.file.SetLength(this.size);
                    this.file.Close();
                    File.Move(this.tempFullName, this.fullName);
                    this.OnTaskFinish(new TaskFinishEventArgs());
                }
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                this.OnTaskFail(new TaskFailEventArgs());
            }
        }

        private void StartOneThread(Object state)
        {
            REDOWNLOAD:
            StartOneThreadEventArgs args = state as StartOneThreadEventArgs;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            long start = this.metaData.Blocks[args.Idx].Offset;
            long end = this.metaData.Blocks[args.Idx].End;
            try
            {
                if (start <= end)
                {
                    request = (HttpWebRequest)HttpWebRequest.Create(this.Url);
                    HttpHelper.AddRange(request, start, end);
                    response = request.GetResponse() as HttpWebResponse;
                    stream = response.GetResponseStream();
                    byte[] buff = new byte[4096];
                    int readbytes = 0;
                    long offset = start;
                    while (this.status == TaskStatus.Start && (offset - start) < response.ContentLength)
                    {
                        if ((readbytes = stream.Read(buff, 0, buff.Length)) > 0)
                        {
                            lock (fileLocker)
                            {
                                if (this.file != null)
                                {
                                    this.file.Seek(offset, SeekOrigin.Begin);
                                    this.file.Write(buff, 0, readbytes);
                                    offset += readbytes;
                                    this.metaData.Blocks[args.Idx].Offset = offset;
                                    byte[] meta_buffer = BufferHelper.Serialize(this.metaData);
                                    this.file.Seek(this.size, SeekOrigin.Begin);
                                    this.file.Write(meta_buffer, 0, meta_buffer.Length);
                                    this.file.Write(BitConverter.GetBytes(meta_buffer.Length), 0, sizeof(int));
                                    this.file.Flush();
                                }
                            }
                        }
                    }
                }
                if (Interlocked.Decrement(ref this.count) == 0)
                {
                    args.Finish.Set();
                }
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                Thread.Sleep(1000);
                goto REDOWNLOAD;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
        }

        public override bool LoadUrl()
        {
            try
            {
                Uri uri = new Uri(this.url);
                this.name = uri.Segments.Last<string>();
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
            return true;
        }

        public override bool GetInfoFromUrl()
        {
            try
            {
                WebHeaderCollection headers;
                Uri uri;
                HttpHelper.GetHttpHeader(out headers, out uri, this.url, 30000, null, null);
                if (headers == null || uri == null)
                {
                    return false;
                }
                string disposition = headers["Content-Disposition"];
                if (!string.IsNullOrEmpty(disposition))
                {
                    if (disposition.Contains("filename="))
                    {
                        int idx = disposition.LastIndexOf("filename=") + 10;
                        this.name = disposition.Substring(idx, disposition.Length - idx - 1);
                    }
                }
                if (string.IsNullOrEmpty(this.name))
                {
                    this.name = uri.Segments[uri.Segments.Length - 1];
                    if (this.name.Contains("/"))
                    {
                        this.name = "index.html";
                    }
                }
                if (string.IsNullOrEmpty(this.name))
                {
                    this.name = "Unkonwn";
                }
                bool range = (headers["Accept-Ranges"] != null && headers["Accept-Ranges"] == "bytes");
                if (!range)
                {
                    this.threads = 1;
                }
                this.size = Convert.ToInt64(headers["Content-Length"]);
                this.GetAvaiableName();
                this.CreateFileAndMetaData();
                return true;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        private bool GetAvaiableName()
        {
            //check the directory's all of filename is match the specify filename
            //if match filename +1 +2 +3 ...
            //if not match return the specify filename
            try
            {
                string n = this.name;
                int i = 1;
                while (true)
                {
                    string fn = this.directory + "\\" + this.name;
                    if (DownLoadService.Instance.CheckAvaiableName(fn))
                    {
                        this.fullName = fn;
                        break;
                    }
                    else
                    {
                        int idx = n.LastIndexOf(".");
                        this.name = n.Substring(0, idx) + "(" + (i++) + ")" + n.Substring(idx, n.Length - idx);
                    }

                }
                this.tempFullName = this.fullName + DownLoadService.Instance.FLASH_DOWNLOAD_EXTEND;
                if (File.Exists(this.tempFullName))
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        private void CreateFileAndMetaData()
        {
            try
            {
                this.metaData = new TaskMetaData();
                this.metaData.Threads = this.threads;
                this.metaData.Blocks = new Block[this.threads];
                this.metaData.Name = this.name;
                this.metaData.FullName = this.fullName;
                this.metaData.TempFullName = this.tempFullName;
                this.metaData.Url = this.url;
                this.metaData.Size = this.size;
                
                long perSize = this.size / this.threads;
                long start = 0, end = 0;
                for (int i = 0; i < this.threads; i++)
                {
                    if (i == 0)
                    {
                        start = perSize * i;
                    }
                    if (i == this.threads - 1)
                    {
                        end = size - 1;
                    }
                    else
                    {
                        end = start + perSize;
                    }
                    this.metaData.Blocks[i] = new Block(start, end, start);
                    start = end + 1;
                }
                byte[] meta_buffer = BufferHelper.Serialize(this.metaData);
                long length = this.size + meta_buffer.Length;
                this.file = DiskHelper.AllocateSpace(this.tempFullName, length);
                this.file.Seek(this.size, SeekOrigin.Begin);
                this.file.Write(meta_buffer, 0, meta_buffer.Length);
                this.file.Write(BitConverter.GetBytes(meta_buffer.Length), 0, sizeof(int));
                this.file.Flush();
            }
            catch(Exception ex)
            {
                if (this.file != null)
                {
                    this.file.Close();
                }
                LogHelper.logerror.Error(ex);
                this.OnTaskFail(new TaskFailEventArgs());
            }
        }

        public override bool GetInfoFromMeta()
        {
            try
            {
                this.file = new FileStream(this.TempFullName, FileMode.Open, FileAccess.ReadWrite);
                this.file.Seek(this.file.Length - sizeof(int), SeekOrigin.Begin);
                byte[] meta_length_buffer = new byte[sizeof(int)];
                file.Read(meta_length_buffer, 0, sizeof(int));
                int meta_length = BitConverter.ToInt32(meta_length_buffer, 0);
                byte[] meta_buffer = new byte[meta_length];
                file.Seek(file.Length - meta_length - sizeof(int), SeekOrigin.Begin);
                file.Read(meta_buffer, 0, meta_length);
                this.metaData = BufferHelper.Deserialize(meta_buffer, 0) as TaskMetaData;
                this.name = this.metaData.Name;
                this.threads = this.metaData.Threads;
                this.fullName = this.metaData.FullName;
                this.tempFullName = this.metaData.TempFullName;
                this.size = this.metaData.Size;
                this.GetDownLoadSize();
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                if (file != null)
                {
                    file.Close();
                }
            }

            return true;
        }
    }
}
