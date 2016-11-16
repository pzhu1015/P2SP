/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2014-2-22
 * Time: 22:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.ComponentModel;

namespace Complents.SendFileService
{
	public enum SendType
	{
		[Description("文件")]   
		eFile,
		[Description("文件夹")] 
		eFolder
	}
	/// <summary>
	/// Description of FileIdMgr.
	/// </summary>
	public sealed class FileIdMgr
	{
		private static FileIdMgr instance = new FileIdMgr();
		
		public static FileIdMgr Instance {
			get {
				return instance;
			}
		}
		
		private int id = 0;
		
		private FileIdMgr()
		{
		}
		
		public string GetFileId(string _to, string _from)
		{
			int nextId = Interlocked.Increment(ref this.id);
			return _to + "_" + _from + "_" + nextId.ToString();
		}
	}
}
