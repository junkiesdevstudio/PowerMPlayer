using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Power_Mplayer
{
	/// <summary>
	/// Win32API 的摘要描述。
	/// </summary>
	public class Win32API
	{
		public Win32API()
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
		}

		// for execuse external program
		[DllImport("user32")]
		public static extern IntPtr SetParent(int hwndChild, int hwndNewParent);
        
		[DllImport("user32")]
		public static extern IntPtr MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.U1)] bool bRepaint);

		[DllImport("dwmapi.dll")]
		public static extern void DwmIsCompositionEnabled(ref bool pfEnabled);

        /*
		// for full screen
		[DllImport("user32.dll", EntryPoint=("GetSystemMetrics"))]
		public static extern int GetSystemMetrics(int nIndex);
		public const int SM_CXSCREEN = 0;
		public const int SM_CYSCREEN = 1;

		/// <summary>
		/// Set Window Position
		/// </summary>
		/// <param name="hWnd">window handle</param>
		/// <param name="hWndInsertAfter">placement-order handle</param>
		/// <param name="X">horizontal position</param>
		/// <param name="Y">vertical position</param>
		/// <param name="cx">vertical position</param>
		/// <param name="cy">width</param>
		/// <param name="uFlags">window positioning flags</param>
		/// <returns></returns>
		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern bool SetWindowPos(
			int hWnd,               // window handle
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags);           // window positioning flags
		public const int HWND_TOP		 = 0x0;
		public const int HWND_BOTTOM     = 0x1;
		public const int HWND_TOPMOST	 = -1;
		public const int HWND_NOTOPMOST  = -2;

		public const uint SWP_NOSIZE     = 0x1;
		public const uint SWP_NOMOVE     = 0x2;
		public const uint SWP_SHOWWINDOW = 0x40;

        */

		/// <summary>
		/// SendMessage Win32 API
		/// </summary>
		/// <param name="hWnd">handle to destination window</param>
		/// <param name="Msg">message</param>
		/// <param name="wParam">first message parameter</param>
		/// <param name="lParam">second message parameter</param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, long wParam, long lParam);

		public const uint WM_PAINT		= 0x0000F;

		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        // from http://www.c-sharpcorner.com/UploadFile/crajesh1981/RajeshPage103142006044841AM/RajeshPage1.aspx?ArticleID=63e02c1f-761f-44ab-90dd-8d2348b8c6d2
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetLongPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder longPath,
                 int longPathLength
                 );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetShortPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                 int shortPathLength
                 );

        public static string ToShortPathName(string longPath)
        {
            StringBuilder shortPath = new StringBuilder(255);
            Win32API.GetShortPathName(longPath, shortPath, shortPath.Capacity);

            return shortPath.ToString();
        }
	}
}
