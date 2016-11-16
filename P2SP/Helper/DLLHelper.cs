/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-2-13
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Helper
{
	/// <summary>
	/// Description of DLLHelper.
	/// </summary>
	public class DLLHelper
	{
		public const int HOTKEY_ID = 1000;
        public const uint WM_HOTKEY = 0x312;
        public const uint MOD_ALT = 0x1;
        public const uint MOD_CONTROL = 0x2;
        public const uint MOD_SHIFT = 0x4;	
		
		[DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void CLAYUI_CSharp_Init(IntPtr handle);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void CLAYUI_CSharp_Release();

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void CLAYUI_OnAnimation(IntPtr handle, int vert, int flag, int anitype, int invert);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void Redraw(IntPtr handle, int usetime);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern int IsPlay();

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void CLAYUI_InitDialog2(IntPtr handle, IntPtr handle1);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void MakeWindowTpt(IntPtr handle, int factor);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void WinRedraw(IntPtr handle, int redraw);

        [DllImport(@"clayui_forcsharp.dll")]
        public static extern void desktomemdc1(IntPtr handle);
        
        [DllImport("winmm.dll")]
        public static extern long waveOutSetVolume(UInt32 deviceID, UInt32 Volume);
        [DllImport("winmm.dll")]
        public static extern long waveOutGetVolume(UInt32 deviceID, out UInt32 Volume);
	}
}
