/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-24
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;

using Helper;

namespace SendFileService
{
	/// <summary>
	/// Description of SendFileReader.
	/// </summary>
	public class SendFileReader : SendReader
	{
		private HashAlgorithm hash;
		private FileStream stream;
		public SendFileReader(string path)
			:
			base(SendType.eFile)
		{
			this.Init(path);
		}
		
		private void Init(string path)
		{
			FileInfo info = new FileInfo(path);
			this.name = info.Name;
			this.image = Icon.ExtractAssociatedIcon(info.FullName).ToBitmap();
			this.hash = new MD5CryptoServiceProvider();
			this.totalCount = 1;
			this.totalLength = info.Length;
			this.totalPosition = 0;
			this.stream = new FileStream(
                info.FullName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                BlockSize,
                true);
		}
		
		public override void Read()
        {
			DebugHelper.Assert(this.totalPosition < this.totalLength);
            int size = 0;
            long delta = this.totalLength - this.totalPosition;
            if (delta >= BlockSize)
            {
            	size = BlockSize;
            }
            else if (delta < BlockSize)
            {
            	size = (int)delta;
            }
            byte[] buffer = new byte[size];
            DebugHelper.Assert(this.stream != null);
            this.stream.BeginRead(
                buffer,
                0,
                buffer.Length,
                new AsyncCallback(EndRead),
                buffer);
        }
        
        private void EndRead(IAsyncResult iar)
        {
            int len = this.stream.EndRead(iar);
            byte[] buffer = (byte[])iar.AsyncState;
            DebugHelper.Assert(buffer.Length == len);
            long offset = this.totalPosition;
            this.totalPosition += buffer.Length;
            if (this.totalPosition == this.totalLength)
            {
            	this.Dispose();
            	MD5Helper.ComputeFinalBlockHash(this.hash, buffer);
            	this.OnCompleteRead(new CompleteReadEventArgs(offset, buffer));
            }
            else
            {
            	MD5Helper.ComputeBlockHash(this.hash, buffer);
            	this.OnReadFileBuffer(new ReadBufferEventArgs(offset, buffer));
            }
            
        }
		
        public new void Dispose()
		{
			if (this.stream != null)
            {
                this.stream.Close();
                this.stream.Dispose();
                this.stream = null;
            }
		}

	}
}
