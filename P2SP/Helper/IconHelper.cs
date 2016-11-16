/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-4-11
 * Time: 22:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;

namespace Helper
{
	/// <summary>
	/// Description of IconHelper.
	/// </summary>
	public class IconHelper
	{
		public IconHelper()
		{
		}
		
		/// <summary>
	    /// 获得指定文件图标句柄
	    /// </summary>
	    /// <param name="path">指定的文件名</param>
	    /// <param name="fileattribute">文件属性</param>
	    /// <param name="?">返回的文件信息</param>
	    /// <param name="SizeFileInfo">sfinfo的比特值</param>
	    /// <param name="flag">指明要返回的文件信息标识符</param>
	    /// <returns>文件的图标句柄</returns>
	    [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
	    public static extern IntPtr SHGetFileInfo(string path, uint fileattribute, ref SHFILEINFO sfinfo
	          , uint SizeFileInfo, uint flag);
	
	    /// <summary>
	    /// 图标结构
	    /// </summary>
	    [StructLayout(LayoutKind.Sequential)]//自定义类型
	    public struct SHFILEINFO
	    {
	        public IntPtr hIcon;//文件的图标句柄
	        public IntPtr iIcon;//图标的系统索引号
	        public uint aattributes;//文件的属性值
	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]//MarshalAs只是如何在托管代码和非托管代码间传送数据
	        public string displayname;//文件的显示名
	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
	        public string typename;//文件的类型
	    }
	
	    /// <summary>
	    /// 清除图标
	    /// </summary>
	    /// <param name="hIcon">图标句柄</param>
	    /// <returns>返回非零表示成功，零表示失败</returns>
	    [DllImport("user32.dll", EntryPoint = "DestroyIcon")]
	    public static extern int DestroyIcon(IntPtr hIcon);
	    
	    public static Image GetFolderIcon(string path)
	    {
	    	SHFILEINFO shfi = new SHFILEINFO();
	    	SHGetFileInfo(path, (uint)0x80, ref shfi,
	    	              (uint)Marshal.SizeOf(shfi),
	    	              (uint)(0x100 | 0x400));
	    	Image image = ((Icon)(Icon.FromHandle(shfi.hIcon).Clone())).ToBitmap();
	    	DestroyIcon(shfi.hIcon);
	    	return image;
	    }
	    
	    
	    public static Image GetFileIcon(string path)
	    {
	        SHFILEINFO shfi = new SHFILEINFO();
	        FileInfo file = new FileInfo(path);
	        SHGetFileInfo(path,(uint)0x80,ref shfi,
	                      (uint)Marshal.SizeOf(shfi),
	                      (uint)(0x100|0x400));
	      	Image image = ((Icon)(Icon.FromHandle(shfi.hIcon).Clone())).ToBitmap();
	    	DestroyIcon(shfi.hIcon);
	    	return image;
	    }
	    
		
		
		/// <summary>
        /// 通过扩展名得到图标和描述
        /// </summary>
        /// <param name="ext">扩展名(如“.txt”)</param>
        /// <param name="largeIcon">得到大图标</param>
        /// <param name="smallIcon">得到小图标</param>
        /// <param name="description">得到类型描述或者空字符串</param>
        public static void GetExtsIconAndDescription(string ext, out Icon largeIcon, out Icon smallIcon, out string description)
        {
            GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标
            description = "";                               //缺省类型描述
            RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey(ext);   //从注册表中读取扩展名相应的子键
            if (extsubkey == null) return;

            string extdefaultvalue = extsubkey.GetValue(null) as string;     //取出扩展名对应的文件类型名称
            if (extdefaultvalue == null) return;

            if (extdefaultvalue.Equals("exefile", StringComparison.OrdinalIgnoreCase))  //扩展名类型是可执行文件
            {
                RegistryKey exefilesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键
                if (exefilesubkey != null)
                {
                    string exefiledescription = exefilesubkey.GetValue(null) as string;   //得到exefile描述字符串
                    if (exefiledescription != null) description = exefiledescription;
                }
                System.IntPtr exefilePhiconLarge = new IntPtr();
                System.IntPtr exefilePhiconSmall = new IntPtr();
                NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 2, ref exefilePhiconLarge, ref exefilePhiconSmall, 1);
                if (exefilePhiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(exefilePhiconLarge);
                if (exefilePhiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(exefilePhiconSmall);
                return;
            }

            RegistryKey typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键
            if (typesubkey == null) return;

            string typedescription = typesubkey.GetValue(null) as string;   //得到类型描述字符串
            if (typedescription != null) description = typedescription;

            RegistryKey defaulticonsubkey = typesubkey.OpenSubKey("DefaultIcon");  //取默认图标子键
            if (defaulticonsubkey == null) return;

            //得到图标来源字符串
            string defaulticon = defaulticonsubkey.GetValue(null) as string; //取出默认图标来源字符串
            if (defaulticon == null) return;
            string[] iconstringArray = defaulticon.Split(',');
            int nIconIndex = 0; //声明并初始化图标索引
            if (iconstringArray.Length > 1)
                if (!int.TryParse(iconstringArray[1], out nIconIndex))
                    nIconIndex = 0;     //int.TryParse转换失败，返回0

            //得到图标
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }
        
        /// <summary>
        /// 获取缺省图标
        /// </summary>
        /// <param name="largeIcon"></param>
        /// <param name="smallIcon"></param>
        private static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
        {
            largeIcon = smallIcon = null;
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }
	}
	
	[StructLayoutAttribute(LayoutKind.Sequential)]
    public struct HICON__
    {

        /// int
        public int unused;
    }

    public partial class NativeMethods
    {

        /// Return Type: UINT->unsigned int
        ///lpszFile: LPCWSTR->WCHAR*
        ///nIconIndex: int
        ///phiconLarge: HICON*
        ///phiconSmall: HICON*
        ///nIcons: UINT->unsigned int
        [DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ExtractIconExW([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref System.IntPtr phiconLarge, ref System.IntPtr phiconSmall, uint nIcons);

    }
}
