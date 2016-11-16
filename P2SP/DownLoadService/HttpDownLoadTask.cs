/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-23
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;
using System.Threading;

using Helper;

namespace DownLoadService
{
	/// <summary>
	/// Description of HttpDownLoadTask.
	/// </summary>
	public class HttpDownLoadTask : DownLoadTask
	{
		public HttpDownLoadTask()
		{
			this.isRange = false;
		}
		
		public override bool GetHeaderInfo()
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
				string tmpname = "";
				string tmp = headers["Content-Disposition"]; 
				if (!string.IsNullOrEmpty(tmp))
				{
					if (tmp.Contains("filename="))
					{
						int idx = tmp.LastIndexOf("filename=") + 10;
						tmpname = tmp.Substring(idx, tmp.Length - idx - 1);
					}
				}
				if (string.IsNullOrEmpty(tmpname))
				{
					tmpname = uri.Segments[uri.Segments.Length-1];
					if (name.Contains("/"))
					{
						tmpname = "index.html";
					}
				}
			    if (string.IsNullOrEmpty(tmpname))
			    {
			    	tmpname = "未知";
			    }
			    string saveDir = DownLoadTaskMgr.Instance.GetSaveDir();
			    tmpname = this.GetUsedName(saveDir, tmpname);
			    this.name = tmpname;
			    this.fullName = saveDir + "\\" + this.name;
			    this.isRange = (headers["Accept-Ranges"] != null & headers["Accept-Ranges"] == "bytes");
			    this.length = Convert.ToInt64(headers["Content-Length"]);
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return false;
			}
			return true;
		}
		
		public override void DownLoadThreadFunc(object o)
		{
			int idx = (int)o;
			Block block = this.blockList[idx];
			long start = block.Pos;
			long end = block.End;
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("start... " + idx, sf);
			}
			HttpWebRequest request = null;
			HttpWebResponse response = null;
			Stream stream = null;
			bool error = false;
			try
			{
				request = (HttpWebRequest)HttpWebRequest.Create(this.Url);
				request.AddRange((int)start, (int)(end));
				response = request.GetResponse() as HttpWebResponse;
				stream = response.GetResponseStream();
				if (this.status != DownLoadStatus.eStart)
				{
					return;
				}
				byte [] buff = new byte[4096];
				int readbytes = 0;
				long pos = start;
				while((pos-start) < response.ContentLength && this.status == DownLoadStatus.eStart)
				{
					if ((readbytes = stream.Read(buff, 0, buff.Length)) > 0)
					{
						this.WriteToFile(pos, buff, readbytes);
						pos += readbytes;
						this.Update(block, pos);
					}
				}
			}
			catch (Exception ex)
			{
				error = true;
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Error(ex, sf);
				}
				if ((block.MaxTrys--) > 0)
				{
					Thread.Sleep(2000);
					{
						System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
						System.Diagnostics.StackFrame sf = st.GetFrame(0);
						DebugHelper.Console("restart... " + idx, sf);
					}
					ThreadPool.QueueUserWorkItem(new WaitCallback(DownLoadThreadFunc), idx);
				}
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
				System.GC.Collect();
				if (!error)
				{
					if (this.status == DownLoadStatus.eStop)
					{
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("stop... " + idx, sf);
						}
					}
					else if (this.status == DownLoadStatus.eStart)
					{
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("block finish... " + idx, sf);
						}
					}
					this.latch.CountDown();
				}
				else
				{
					if (block.MaxTrys <= 0)
					{
						{
							System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
							System.Diagnostics.StackFrame sf = st.GetFrame(0);
							DebugHelper.Console("block fail..." + idx, sf);
						}
						this.latch.CountDown();
					}
				}
			}
		}
	}
}
