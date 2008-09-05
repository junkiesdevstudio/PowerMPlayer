using System;
using System.Runtime.InteropServices;

namespace Power_Mplayer
{
	/// <summary>
	/// Win32API ���K�n�y�z�C
	/// </summary>
	public class Win32API
	{
		public Win32API()
		{
			//
			// TODO: �b���[�J�غc�禡���{���X
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
