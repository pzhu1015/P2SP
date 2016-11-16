/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-13
 * Time: 17:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.IO;

using Helper;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of RecveFolderWriter.
	/// </summary>
	public class RecveFolderWriter : RecveWriter
	{
		private string subName;
		private HashAlgorithm hash;
		private FileStream stream;
		private int count = 0;
		private long length;
		public RecveFolderWriter(string _fileId, int _totalCount, string _path, string _name, long _totalLength)
			:
			base(SendType.eFolder)
		{
			this.fileId = _fileId;
			this.path = _path;
			this.name = _name;
			this.totalLength = _totalLength;
			this.totalCount = _totalCount;
		}
		
		private void Init(string _fileId, int _totalCount, string _path, string _name, long _totalLength)
		{
			this.fileId = _fileId;
			this.path = _path;
			this.name = _name;
			this.totalLength = _totalLength;
			this.totalCount = _totalCount;
			this.totalPosition = 0;
		}
		
		public override void Next(string _subName, long _length)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("写文件, " + _subName, sf);
			}
			this.subName = _subName;
			this.length = _length;
			this.CreateSubDir(this.subName);
			this.hash = new MD5CryptoServiceProvider();
			this.stream = new FileStream(
				this.path + "\\" + this.subName,
	            FileMode.OpenOrCreate,
	            FileAccess.Write,
	            FileShare.None,
	            BlockSize,
	            true);
		}
		
		private void CreateSubDir(string subName)
		{
			string[] subItems = subName.Split('\\');
			string subPath = this.path;
			for(int i = 0; i < subItems.Length - 1; i++)
			{
				subPath += "\\" + subItems[i];
				if (!Directory.Exists(subPath))
				{
					Directory.CreateDirectory(subPath);
				}
			}
		}
		
		private void CreateFullSubDir(string subName)
		{
			string[] subItems = subName.Split('\\');
			string subPath = this.path;
			for(int i = 0; i < subItems.Length; i++)
			{
				subPath += "\\" + subItems[i];
				if (!Directory.Exists(subPath))
				{
					Directory.CreateDirectory(subPath);
				}
			}
		}
		
		public override void Write(string _subName)
		{
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Console("写文件, " + _subName, sf);
			}
			this.CreateFullSubDir(_subName);
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(EndWrite);
			ah.BeginInvoke(null, null);
		}
		
		private void EndWrite()
		{
			this.count++;
			if (this.totalLength == this.totalPosition && this.count == this.totalCount)
			{
				this.OnCompleteWrite(new CompleteWriteEventArgs());
			}
			else
			{
				this.OnWriteFolder(new WriteFolderEventArgs());
			}
		}
		
		public override void Write(long offset, byte[] buffer)
        {
			DebugHelper.Assert(this.stream != null);
        	this.stream.Position = offset;
            this.stream.BeginWrite(
                buffer,
                0,
                buffer.Length,
                new AsyncCallback(EndWrite),
                buffer);
        }
		
		private void EndWrite(IAsyncResult iar)
        {
            this.stream.EndWrite(iar);
            byte[] buffer = (byte[])iar.AsyncState; 
            this.totalPosition += buffer.Length;
            HashAlgorithm ha = this.hash;
            if (this.stream.Position == this.length)
            {
            	this.count++;
            	this.Dispose();
				MD5Helper.ComputeFinalBlockHash(ha, buffer);
				string md5 = MD5Helper.GetMd5(ha);
            	{
            		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(md5, sf);
				}
				if (this.totalLength == this.totalPosition && this.count == this.totalCount)
	            {
					this.OnCompleteWrite(new CompleteWriteEventArgs());
				}
				else
				{
					this.OnWriteFileBuffer(new WriteBufferEventArgs(buffer.Length));
				}
            }
            else
            {
            	MD5Helper.ComputeBlockHash(this.hash, buffer);
            	this.OnWriteFileBuffer(new WriteBufferEventArgs(buffer.Length));
            }
        }
		
		 public new void Dispose()
        {
            if (this.stream != null)
            {
                this.stream.Flush();
                this.stream.Close();
                this.stream.Dispose();
                this.stream = null;
                this.hash = null;
            }
        }
	}
}
