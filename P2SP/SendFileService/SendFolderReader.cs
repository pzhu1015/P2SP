/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-13
 * Time: 17:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;

using Helper;

namespace SendFileService
{
	public class SubInfo
	{
		private SendType fileType;
		
		public SendType FileType {
			get { return fileType; }
			set { fileType = value; }
		}
		
		private string fullName;
		
		public string FullName {
			get { return fullName; }
			set { fullName = value; }
		}
		private string subName;
		
		public string SubName {
			get { return subName; }
			set { subName = value; }
		}
		
		private long length;
		
		public long Length {
			get { return length; }
			set { length = value; }
		}
		
		private long position;
		
		public long Position {
			get { return position; }
			set { position = value; }
		}
		
		private HashAlgorithm hash;
		
		public HashAlgorithm Hash {
			get { return hash; }
			set { hash = value; }
		}
		
		private FileStream stream;
		
		public FileStream Stream {
			get { return stream; }
			set { stream = value; }
		}
		
		public SubInfo(string _fullName, string _subName, long _length)
		{
			this.fileType = SendType.eFile;
			this.fullName = _fullName;
			this.subName = _subName;
			this.length = _length;
		}
		
		public SubInfo(string _fullName, string _subName)
		{
			this.fileType = SendType.eFolder;
			this.fullName = _fullName;
			this.subName = _subName;
		}
	}
	/// <summary>
	/// Description of SendFolderReader.
	/// </summary>
	public class SendFolderReader : SendReader
	{
		private SubInfo subInfo;
		public Queue<SubInfo> fileList = new Queue<SubInfo>();
		public SendFolderReader(string path)
			:
			base(SendType.eFolder)
		{
			this.Init(path);
		}
		
		private void Init(string path)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			this.name = dirInfo.Name;
			this.image = IconHelper.GetFolderIcon(dirInfo.FullName);
			string subDir = this.name;
			this.getAllSubItem(dirInfo, subDir);
			this.totalCount = this.fileList.Count;
			this.totalPosition = 0;
		}
		
		private void getAllSubItem(DirectoryInfo dirInfo, string _subDir)
		{
			FileInfo [] fileInfos = dirInfo.GetFiles();
			foreach(FileInfo fInfo in fileInfos)
			{
				this.totalLength += fInfo.Length;
				string subName = _subDir + "\\" + fInfo.Name;
//				{
//					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
//					System.Diagnostics.StackFrame sf = st.GetFrame(0);
//					DebugHelper.Console(subName, sf);
//				}
				SubInfo subInfo = new SubInfo(fInfo.FullName, subName, fInfo.Length);
				this.fileList.Enqueue(subInfo);
			}
			DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
			foreach(DirectoryInfo dInfo in dirInfos)
			{
				string  subDir =  _subDir + "\\" + dInfo.Name;
				this.getAllSubItem(dInfo, subDir);
			}
			if (fileInfos.Length == 0 && dirInfos.Length == 0)
			{
				string subName = _subDir;
				SubInfo subInfo = new SubInfo(dirInfo.FullName, subName);
				
				this.fileList.Enqueue(subInfo);
			}
		}
		
		private void Next()
		{
			this.subInfo = this.fileList.Dequeue();
			if (this.subInfo.FileType == SendType.eFile)
			{
				this.subInfo.Hash = new MD5CryptoServiceProvider();
				this.subInfo.Stream = new FileStream(
						this.subInfo.FullName,
		                FileMode.Open,
		                FileAccess.Read,
		                FileShare.Read,
		                BlockSize,
		                true);
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("读文件, " + this.subInfo.SubName, sf);
				}
			}
		}
		
		public override void Read()
		{
			DebugHelper.Assert(this.fileList.Count > 0 || this.totalPosition < this.totalLength);
			if (this.subInfo == null)
			{
				this.Next();
			}
			DebugHelper.Assert(this.subInfo != null);
			if (this.subInfo.FileType == SendType.eFolder)
			{
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console("读文件, " + this.subInfo.SubName, sf);
				}
				AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(EndRead);
				ah.BeginInvoke(null, null);
				return;
			}
			long size = 0;
			long delta = this.subInfo.Length - this.subInfo.Position;
            if (delta >= BlockSize)
            {
            	size = BlockSize;
            }
            else if (delta < BlockSize)
            {
            	size = (int)delta;
            }
            byte[] buffer = new byte[size];
            this.subInfo.Stream.BeginRead(
                buffer,
                0,
                buffer.Length,
                new AsyncCallback(EndRead),
                buffer);
		}
		
		private void EndRead()
		{
			string subName = this.subInfo.SubName;
			this.subInfo = null;
			if (this.totalLength == this.totalPosition && this.fileList.Count == 0)
			{
				this.OnCompleteRead(new CompleteReadEventArgs(subName));
			}
			else
			{
				this.OnReadFolder(new ReadFolderEventArgs(subName));
			}
		}
		
		private void EndRead(IAsyncResult iar)
        {
            int len = this.subInfo.Stream.EndRead(iar);
            byte[] buffer = (byte[])iar.AsyncState;
            DebugHelper.Assert(buffer.Length == len);
            long offset = this.subInfo.Position;
            this.totalPosition += buffer.Length;
            this.subInfo.Position += buffer.Length;
            HashAlgorithm hash = this.subInfo.Hash;
            string subName = this.subInfo.SubName;
            long length = this.subInfo.Length;
            if (this.subInfo.Length == this.subInfo.Position)
            {
            	this.Dispose();
            	MD5Helper.ComputeFinalBlockHash(hash, buffer);
            	string md5 = MD5Helper.GetMd5(hash);
            	{
            		System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(md5, sf);   
            	}
            	if (this.totalLength == this.totalPosition && this.fileList.Count == 0)
            	{
	                this.OnCompleteRead(new CompleteReadEventArgs(subName, length, offset, buffer));
            	}
            	else
            	{
            		this.OnReadFileBuffer(new ReadBufferEventArgs(subName, length, offset, buffer));
            	}
            }
            else
            {
            	MD5Helper.ComputeBlockHash(hash, buffer);
            	this.OnReadFileBuffer(new ReadBufferEventArgs(subName, length, offset, buffer));
            }
            
        }	
		
		public new void Dispose()
		{
			if (this.subInfo != null)
			{
				this.subInfo.Hash = null;
				if (this.subInfo.Stream != null)
				{
					this.subInfo.Stream.Close();
					this.subInfo.Stream.Dispose();
					this.subInfo.Stream = null;
					this.subInfo = null;
				}
			}
		}
	}
}
