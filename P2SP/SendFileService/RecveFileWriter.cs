/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-9-2
 * Time: 13:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

using Helper;

namespace SendFileService
{
	/// <summary>
	/// Description of RecveFileWriter.
	/// </summary>
	public class RecveFileWriter : RecveWriter
	{
		private HashAlgorithm hash;
		private FileStream stream;
        public RecveFileWriter(string _fileId, string _path, string _name, long _totalLength)
			:
			base(SendType.eFile)
        {
        	this.Init(_fileId, _path, _name, _totalLength);
        }
        
        private void Init(string _filId, string _path, string _name, long _totalLength)
        {
        	this.totalCount = 1;
        	this.fileId = _filId;
        	this.path = _path;
        	this.name = _name;
        	this.totalLength = _totalLength;
        	this.totalPosition = 0;
        	this.hash = new MD5CryptoServiceProvider();
        	this.stream = new FileStream(
        		this.path + "\\" + this.name,
        		FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.None,
               	BlockSize,
                true);
        }
        
        public override void Write(long offset, byte[] buffer)
        {
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
            if (this.totalPosition == this.totalLength)
            {
            	this.Dispose();
            	MD5Helper.ComputeFinalBlockHash(this.hash, buffer);
            	this.OnCompleteWrite(new CompleteWriteEventArgs());
            	
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
