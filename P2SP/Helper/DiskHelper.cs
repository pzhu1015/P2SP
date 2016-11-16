/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-11
 * Time: 21:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace Helper
{
	/// <summary>
	/// Description of DiskHelper.
	/// </summary>
	public class DiskHelper
	{
		private const double KBCount = 1024;
		private const double MBCount = KBCount * 1024;
		private const double GBCount = MBCount * 1024;
		private const double TBCount = GBCount * 1024;
		public DiskHelper()
		{
		}
		
		public static bool CheckFileDirectoryIsExist(string fullName)
		{
			FileInfo fileInfo = new FileInfo(fullName);
			return fileInfo.Directory.Exists;
		}
		
		public static bool CheckDirectoryIsExist(string dirName)
		{
			return Directory.Exists(dirName);
		}
		
		public static bool AllocateSpace(string filename, long length)
		{
			FileStream fs = null;
			try
			{
				fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
				fs.Seek(length-1, SeekOrigin.Begin);
				fs.WriteByte(new byte());
				
			}
			catch(Exception ex)
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
				System.Diagnostics.StackFrame sf = st.GetFrame(0);
				DebugHelper.Error(ex, sf);
				return false;
			}
			finally
			{
				if (fs != null)
				{
					fs.Flush();
					fs.Close();
				}
			}
			return true;
		}
		
		public static bool CheckDiskSpace(long size, string dirName)
		{
			string driveName = dirName.Substring(0, 3);
			DriveInfo diskInfo = new DriveInfo(driveName);
			return diskInfo.AvailableFreeSpace > size;
		}
		
		public static string GetSize(long size)
		{
			string strSize = "";
			if (size < KBCount)
			{
				strSize = size.ToString("F2") + " B";
			}
			else if (size >= KBCount && size < MBCount)
			{
				strSize = (size / KBCount).ToString("F2") + "KB";
			}
			else if (size >= MBCount && size < GBCount)
			{
				strSize = (size / MBCount).ToString("F2") + "MB";
			}
			else if (size >= GBCount && size < TBCount)
			{
				strSize = (size / GBCount).ToString("F2") + "GB";
			}
			else if (size >= TBCount)
			{
				strSize = (size / TBCount).ToString("F2") + "TB";
			}
			return strSize;
		}
		
		public static Boolean FileIsUsed(String fileFullName)
		{
			Boolean result = false;
			if (!File.Exists(fileFullName))
			{
				result = false;
			}
			else
			{
				FileStream fileStream = null;
				try
				{
					fileStream = System.IO.File.Open(fileFullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite,System.IO.FileShare.None);
					result = false;
				}
				catch (IOException ioEx)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(ioEx.ToString(), sf);
					result = true;
				}
				catch (Exception ex)
				{
					System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
					System.Diagnostics.StackFrame sf = st.GetFrame(0);
					DebugHelper.Console(ex.ToString(), sf);
                   	result = true;
				}
				finally
				{
					if (fileStream != null)
					{
                       fileStream.Close();
					}
				}
			}
			return result;
		}
		
		public static bool IsDir(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            if ((fi.Attributes & FileAttributes.Directory) != 0)
                return true;
            else
            {
                return false;
            }
        }
	}
}
