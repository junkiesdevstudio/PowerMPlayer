using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace MplayerWrapper
{
	/// <summary>
	/// Win32API ���K�n�y�z�C
	/// </summary>
	public static class Win32API
	{
		// for execuse external program
		[DllImport("user32")]
		public static extern IntPtr SetParent(int hwndChild, int hwndNewParent);
        
		[DllImport("user32")]
		public static extern IntPtr MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.U1)] bool bRepaint);

		[DllImport("dwmapi.dll")]
		public static extern void DwmIsCompositionEnabled(ref bool pfEnabled);

        #region Full Screen : no needed

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

        #endregion

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

        #region Path long <-> short

        // from http://www.c-sharpcorner.com/UploadFile/crajesh1981/RajeshPage103142006044841AM/RajeshPage1.aspx?ArticleID=63e02c1f-761f-44ab-90dd-8d2348b8c6d2

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

        #endregion

        #region File Associate

        public static void SetAssociate(string ext, string ProgramName, string strIcon)
        {
            if(ext[0] != '.')
                return;

            ext = ext.ToLower();

            RegistryKey rk = Registry.ClassesRoot.OpenSubKey("\\", true);
            RegistryKey rkTest = rk.CreateSubKey(ext);
            rkTest.SetValue("", ProgramName, RegistryValueKind.String);
            rkTest.Close();

            if (strIcon != null && strIcon != "")
            {
                rkTest = rk.CreateSubKey(ProgramName + @"\DefaultIcon");
                rkTest.SetValue("", strIcon);
                rkTest.Close();
            }

            rkTest = rk.CreateSubKey(ProgramName + @"\shell\open");
            rkTest.SetValue("", "Open with PowerMplayer");
            rkTest.Close();

            rkTest = rk.CreateSubKey(ProgramName + @"\shell\open\command");
            rkTest.SetValue("", string.Format(@"""{0}"" ""%1""", System.Windows.Forms.Application.ExecutablePath), RegistryValueKind.ExpandString);
            rkTest.Close();
        }

        public static bool isAssociate(string ProgramName, string ext)
        {
            //string ProgramName = "PowerMplayer";

            ext = ext.ToLower();

            try
            {
                RegistryKey rk = Registry.ClassesRoot.OpenSubKey(ext);

                if (rk != null)
                {
                    string kv = (string)rk.GetValue("");
                    return kv.StartsWith(ProgramName);
                }
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(ee.ToString());
            }

            return false;
        }

        #endregion

        #region Chinese Trans

        // codes from
        // http://sanchen.blogspot.com/2007/12/microsoftvisualbasicstringsstrconv.html

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);
        
        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        internal const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        public static string ToSimplified(string source)
        {
            String target = new String(' ', source.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_SIMPLIFIED_CHINESE, source, source.Length, target, source.Length);
            return target;
        }

        public static string ToTraditional(string source)
        {
            String target = new String(' ', source.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_TRADITIONAL_CHINESE, source, source.Length, target, source.Length);
            return target;
        }

        #endregion
    }
}
