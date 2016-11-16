/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-14
 * Time: 10:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Security.Cryptography;

using Helper;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of RecveWriter.
	/// </summary>
	public abstract class RecveWriter : IDisposable
	{
		private bool isStart = false;
		protected int BlockSize = 1024 * 4 * 100;		
		protected SendType type;
		
		public SendType Type {
			get { return type; }
			set { type = value; }
		}
		
		protected string fileId;
		public string FileId {
			get { return fileId; }
			set { fileId = value; }
		}

		protected string name;
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		protected string path;
		public string Path {
			get { return path; }
			set { path = value; }
		}
		
		protected long totalLength;
		protected long totalPosition;
		
		public long TotalPosition {
			get { return totalPosition; }
			set { totalPosition = value; }
		}
		protected int totalCount;
			
		public RecveWriter(SendType _type)
		{
			this.type = _type;
		}
		
		public virtual void Next(string _subName, long _length)
		{
			
		}
		
		public virtual void Write(long offset, byte[] buffer)
		{
			
		}
		
		public virtual void Write(string _subName)
		{
			
		}
		
		public static RecveWriter GetWriter(SendType _type, int _count, string _fileId, string _path, string _name, long _length)
		{
			switch(_type)
			{
			case SendType.eFile:
				return new RecveFileWriter(_fileId, _path, _name, _length);
			case SendType.eFolder:
				return new RecveFolderWriter(_fileId, _count, _path, _name, _length);
			default:
				return null;
			}
		}
		
		public event CompleteWriteHandler CompleteWrite;
        public event WriteBufferHandler WriteBuffer;
        public event UpdateProgressHandler UpdateProgress;
        public event WriteFolderHandler WriteFolder;
        
        protected virtual void OnCompleteWrite(CompleteWriteEventArgs e)
        {
        	if (this.CompleteWrite != null)
        	{
        		this.CompleteWrite(this, e);
        	}
        }
        
        protected virtual void OnWriteFileBuffer(WriteBufferEventArgs e)
        {
        	if (this.WriteBuffer != null)
        	{
        		this.WriteBuffer(this, e);
        	}
        }
        
        protected virtual void OnUpdateProgress(UpdateProgressEventArgs e)
        {
        	if (this.UpdateProgress != null)
        	{
        		this.UpdateProgress(this, e);
        	}
        }
        
        protected virtual void OnWriteFolder(WriteFolderEventArgs e)
        {
        	if (this.WriteFolder != null)
        	{
        		this.WriteFolder(this, e);
        	}
        }
        
        private void StartCb()
		{
        	while(this.totalPosition != this.totalLength && this.isStart)
			{
        		this.OnUpdateProgress(new UpdateProgressEventArgs(this.totalPosition));
				System.Threading.Thread.Sleep(1000);
			}
        	if (this.isStart)
        	{
				this.OnUpdateProgress(new UpdateProgressEventArgs(this.totalLength));
        	}
		}
		
		public void Start()
		{
			this.isStart = true;
			AsyncHelper.AsyncHandler ah = new AsyncHelper.AsyncHandler(StartCb);
			ah.BeginInvoke(null, null);
		}
		
		public void Stop()
		{
			this.isStart = false;
		}
		
		public void Dispose()
		{
			
		}
	}
}
