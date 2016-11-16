/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-3-23
 * Time: 17:13
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
	/// Description of FtpDownLoadTask.
	/// </summary>
	public class FtpDownLoadTask : DownLoadTask
	{

		
		public FtpDownLoadTask()
		{
			this.isRange = true;
		}
		
		public override bool GetHeaderInfo()
		{
			try
			{
				FtpHelper.GetFtpHeader(out this.length, UrlHelper.DecodeURL(this.url), this.userName, this.passWord);
				string saveDir = DownLoadTaskMgr.Instance.GetSaveDir();
				this.name = this.GetUsedName(saveDir, this.name);
				this.fullName = saveDir + "\\" + this.name;
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
			FtpWebRequest request = null;
			FtpWebResponse response = null;
			Stream stream = null;
			bool error = false;
			try
			{
				request = (FtpWebRequest)FtpWebRequest.Create(UrlHelper.DecodeURL(this.Url));
				request.ContentOffset = start;
				request.Method = WebRequestMethods.Ftp.DownloadFile;
				request.UseBinary = true;
				if (!string.IsNullOrEmpty(this.userName) && !string.IsNullOrEmpty(this.passWord))
				{
					request.Credentials = new NetworkCredential(this.userName, this.passWord);
				}
				response = request.GetResponse() as FtpWebResponse;
				stream = response.GetResponseStream();
				if (this.status != DownLoadStatus.eStart)
				{
					return;
				}
				byte [] buff = new byte[4096];
				int readbytes = 0;
				long pos = start;
				while((pos <= end) && this.status == DownLoadStatus.eStart)
				{
					if ((readbytes = stream.Read(buff, 0, buff.Length)) > 0)
					{
						this.WriteToFile(pos, buff, readbytes);
						pos += readbytes;
						this.Update(block, pos);
					}
				}
				if (pos > end)
				{
					this.Update(block, end + 1);
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
