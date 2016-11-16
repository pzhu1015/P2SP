#region UnsafeMethods

using System;
using System.Drawing;
using System.Runtime.InteropServices;
internal class UnsafeMethods
{
    public static readonly IntPtr TRUE = new IntPtr(1);
    public static readonly IntPtr FALSE = new IntPtr(0);

    public const int WM_LBUTTONDOWN = 0x201;
    public const int WM_RBUTTONDOWN = 0x204;
    public const int WM_MBUTTONDOWN = 0x207;
    public const int WM_NCLBUTTONDOWN = 0x0A1;
    public const int WM_NCRBUTTONDOWN = 0x0A4;
    public const int WM_NCMBUTTONDOWN = 0x0A7;
    public const int WM_NCCALCSIZE = 0x0083;
    public const int WM_NCHITTEST = 0x0084;
    public const int WM_NCPAINT = 0x0085;
    public const int WM_NCACTIVATE = 0x0086;
    public const int WM_MOUSELEAVE = 0x02A3;
    public const int WS_EX_NOACTIVATE = 0x08000000;
    public const int HTTRANSPARENT = -1;
    public const int HTLEFT = 10;
    public const int HTRIGHT = 11;
    public const int HTTOP = 12;
    public const int HTTOPLEFT = 13;
    public const int HTTOPRIGHT = 14;
    public const int HTBOTTOM = 15;
    public const int HTBOTTOMLEFT = 16;
    public const int HTBOTTOMRIGHT = 17;
    public const int WM_USER = 0x0400;
    public const int WM_REFLECT = WM_USER + 0x1C00;
    public const int WM_COMMAND = 0x0111;
    public const int CBN_DROPDOWN = 7;
    public const int WM_GETMINMAXINFO = 0x0024;

    public enum TrackerEventFlags : uint
    {
        TME_HOVER = 0x00000001,
        TME_LEAVE = 0x00000002,
        TME_QUERY = 0x40000000,
        TME_CANCEL = 0x80000000
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

    [DllImport("user32")]
    public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    internal static int HIWORD(int n)
    {
        return (n >> 16) & 0xffff;
    }

    internal static int HIWORD(IntPtr n)
    {
        return HIWORD(unchecked((int)(long)n));
    }

    internal static int LOWORD(int n)
    {
        return n & 0xffff;
    }

    internal static int LOWORD(IntPtr n)
    {
        return LOWORD(unchecked((int)(long)n));
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TRACKMOUSEEVENT
    {
        public uint cbSize;
        public uint dwFlags;
        public IntPtr hwndTrack;
        public uint dwHoverTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MINMAXINFO
    {
        public Point reserved;
        public Size maxSize;
        public Point maxPosition;
        public Size minTrackSize;
        public Size maxTrackSize;
    }

    #region RECT structure

    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(
                    this.left,
                    this.top,
                    this.right - this.left,
                    this.bottom - this.top);
            }
        }

        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x,
                            y,
                            x + width,
                            y + height);
        }

        public static RECT FromRectangle(Rectangle rect)
        {
            return new RECT(rect.Left,
                             rect.Top,
                             rect.Right,
                             rect.Bottom);
        }
    }

    #endregion RECT structure

    #region WINDOWPOS

    [StructLayout(LayoutKind.Sequential)]
    internal struct WINDOWPOS
    {
        internal IntPtr hwnd;
        internal IntPtr hWndInsertAfter;
        internal int x;
        internal int y;
        internal int cx;
        internal int cy;
        internal uint flags;
    }
    #endregion

    #region NCCALCSIZE_PARAMS
    //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/windows/windowreference/windowstructures/nccalcsize_params.asp
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        /// <summary>
        /// Contains the new coordinates of a window that has been moved or resized, that is, it is the proposed new window coordinates.
        /// </summary>
        public RECT rectProposed;
        /// <summary>
        /// Contains the coordinates of the window before it was moved or resized.
        /// </summary>
        public RECT rectBeforeMove;
        /// <summary>
        /// Contains the coordinates of the window's client area before the window was moved or resized.
        /// </summary>
        public RECT rectClientBeforeMove;
        /// <summary>
        /// Pointer to a WINDOWPOS structure that contains the size and position values specified in the operation that moved or resized the window.
        /// </summary>
        public WINDOWPOS lpPos;
    }

    #endregion
}

#endregion