using System;
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

		[DllImport("user32")]
		public static extern IntPtr SetParent(int hwndChild, int hwndNewParent);
        
		[DllImport("user32")]
		public static extern IntPtr MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.U1)] bool bRepaint);

		[DllImport("dwmapi.dll")]
		public static extern void DwmIsCompositionEnabled(ref bool pfEnabled);
	}
}
