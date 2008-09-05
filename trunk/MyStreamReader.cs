using System;
using System.IO;
using System.Text;

namespace Power_Mplayer
{
	/// <summary>
	/// MyStreamReader 的摘要描述。
	/// </summary>
	public class MyStreamReader
	{
		public MyStreamReader()
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();
		}

		public string LastLine
		{
			get
			{
				int start = RequestData.ToString(0, RequestData.Length-2).LastIndexOf("\r\n");

				return RequestData.ToString(start, RequestData.Length-start);
			}
		}

		public System.IO.StreamReader stream;
		public byte[] Buffer;
		public System.Text.StringBuilder RequestData;
		public const int BUFFER_SIZE = 128;
	}
}
