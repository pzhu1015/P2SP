/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-7-30
 * Time: 17:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Helper
{
	public delegate void AsyncCheckHeadler(AsyncCheckEventArgs e);
	public class AsyncCheckEventArgs : EventArgs
	{
		public string fileName;
		
		public string FileName {
			get { return fileName; }
			set { fileName = value; }
		}
		
		private string md5;
		
		public string Md5 {
			get { return md5; }
			set { md5 = value; }
		}

		public AsyncCheckState State { get; private set; }

		public AsyncCheckEventArgs(AsyncCheckState state, string _md5, string _fileName)
		{
			this.md5 = _md5; 
			this.State = state;
			this.fileName = _fileName;
		}
	}
	
	public enum AsyncCheckState
	{
		Completed,
		Checking
	}
	/// <summary>
	/// Description of MD5Helper.
	/// </summary>
	public class MD5Helper
	{
		private string fileName;
		
		//支持所有哈希算法
		private HashAlgorithm hashAlgorithm;

		//文件缓冲区
		private byte[] buffer;

		//文件读取流
		private Stream inputStream;

		public event AsyncCheckHeadler AsyncCheckProgress;
		
		/// <summary>
		/// 返回指定文件的MD5值
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public string Check(string path)
		{
			if (!File.Exists(path))
				throw new ArgumentException(string.Format("<{0}>, 不存在", path));

			this.fileName = path;
			
			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
			byte[] buffer = md5Provider.ComputeHash(fs);
			string resule = BitConverter.ToString(buffer);
			resule = resule.Replace("-", "");
			return resule;
		}
		
		public void AsyncCheck(string path)
		{
			if (!File.Exists(path))
				throw new ArgumentException(string.Format("<{0}>, 不存在", path));
			
			this.fileName = path;
			
			int bufferSize = 5048576;//缓冲区大小，1MB

			buffer = new byte[bufferSize];

			//打开文件流
			this.inputStream = File.Open(path, FileMode.Open);
			this.hashAlgorithm = new MD5CryptoServiceProvider();

			//异步读取数据到缓冲区
			this.inputStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(AsyncComputeHashCallback), null);
		}
		
		private void AsyncComputeHashCallback(IAsyncResult result)
		{
			int bytesRead = this.inputStream.EndRead(result);

			//检查是否到达流末尾
			if (this.inputStream.Position < this.inputStream.Length)
			{
//				//输出进度
//				string pro = string.Format("{0:P0}", (double)this.inputStream.Position / this.inputStream.Length);
//
//				if (null != AsyncCheckProgress)
//					AsyncCheckProgress(new AsyncCheckEventArgs(AsyncCheckState.Checking, pro, this.fileName));

				var output = new byte[buffer.Length];
				//分块计算哈希值
				this.hashAlgorithm.TransformBlock(buffer, 0, buffer.Length, output, 0);

				//异步读取下一分块
				this.inputStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(AsyncComputeHashCallback), null);
				return;
			}
			else
			{
				//计算最后分块哈希值
				this.hashAlgorithm.TransformFinalBlock(buffer, 0, bytesRead);
			}

			string md5 = BitConverter.ToString(this.hashAlgorithm.Hash).Replace("-", "");

			//关闭流
			this.inputStream.Close();
			AsyncCheckProgress(new AsyncCheckEventArgs(AsyncCheckState.Checking, md5, this.fileName));
		}
		
		public string CretaeMD5(string fileName)
        {
            string hashStr = string.Empty;
            try
            {
                FileStream fs = new FileStream(
                    fileName,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hash = md5.ComputeHash(fs);
                hashStr = ByteArrayToHexString(hash);
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hashStr;
        }

        public string CretaeMD5(Stream stream)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(stream);
            return ByteArrayToHexString(hash);
        }

        public string CretaeMD5(byte[] buffer, int offset, int count)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(buffer, offset, count);
            return ByteArrayToHexString(hash);
        }

        private string ByteArrayToHexString(byte[] values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte value in values)
            {
                sb.AppendFormat("{0:X2}", value);
            }
            return sb.ToString();
        }
        
        
        public static void ComputeBlockHash(HashAlgorithm hashAlgorithm, byte[] input)
		{
			if (hashAlgorithm != null)
			{
	        	byte[] output = new byte[input.Length];
	        	hashAlgorithm.TransformBlock(input, 0, input.Length, output, 0);
			}
		}
        
        public static void ComputeFinalBlockHash(HashAlgorithm hashAlgorithm, byte[] input)
        {
        	if (hashAlgorithm != null)
        	{
        		hashAlgorithm.TransformFinalBlock(input, 0, input.Length);
        	}
        }
        
        public static string GetMd5(HashAlgorithm hashAlgorithm)
        {
        	if (hashAlgorithm == null)
        	{
        		return "";
        	}
        	string md5 = BitConverter.ToString(hashAlgorithm.Hash).Replace("-", "");
        	return md5;
        }
	}
}
