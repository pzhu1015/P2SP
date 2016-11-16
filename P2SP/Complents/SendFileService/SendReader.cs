/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-14
 * Time: 10:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;

using Helper;

namespace Complents.SendFileService
{
	/// <summary>
	/// Description of SendReader.
	/// </summary>
	public abstract class SendReader : IDisposable
	{
		private bool isStart = false;
		protected const int BlockSize = 1024 * 4 * 100;
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
		
		protected Image image;	
		public Image Image {
			get { return image; }
			set { image = value; }
		}
		
		protected SendType type;		
		public SendType Type {
			get { return type; }
			set { type = value; }
		}
		
		protected int totalCount;
		
		public int TotalCount {
			get { return totalCount; }
			set { totalCount = value; }
		}
		
		protected long totalLength;
		
		public long TotalLength {
			get { return totalLength; }
			set { totalLength = value; }
		}
		
		protected long totalPosition;
		
		public long TotalPosition {
			get { return totalPosition; }
			set { totalPosition = value; }
		}
		
		public SendReader(SendType _type)
		{
			this.type = _type;
		}
		
		public virtual void Read()
		{
			
		}
		
		public event ReadBufferHandler ReadBuffer;
		public event CompleteReadHandler CompleteRead;
		public event UpdateProgressHandler UpdateProgress;
		public event ReadFolderHandler ReadFolder;
		
		public static SendReader GetReader(string path)
		{
			SendType type;
			if (DiskHelper.IsDir(path))
			{
				type = SendType.eFolder;
			}
			else
			{
				type = SendType.eFile;
			}
			switch(type)
			{
			case SendType.eFile:
					return new SendFileReader(path);
			case SendType.eFolder:
					return new SendFolderReader(path);
			default:
					return null;
			}
		}
		
		protected virtual void OnReadFileBuffer(ReadBufferEventArgs e)
		{
			if (this.ReadBuffer != null)
			{
				this.ReadBuffer(this, e);
			}
		}
		
		protected virtual void OnCompleteRead(CompleteReadEventArgs e)
		{
			if (this.CompleteRead != null)
			{
				this.CompleteRead(this, e);
			}
		}
		
		protected virtual void OnUpdateProgress(UpdateProgressEventArgs e)
		{
			if (this.UpdateProgress != null)
			{
				this.UpdateProgress(this, e);
			}
		}
		
		protected virtual void OnReadFolder(ReadFolderEventArgs e)
		{
			if (this.ReadFolder != null)
			{
				this.ReadFolder(this, e);
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
			this.Read();
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
