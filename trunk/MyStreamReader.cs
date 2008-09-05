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
		public const int BUFFER_SIZE = 128;

		public System.IO.StreamReader stream;
		public byte[] Buffer;
		public System.Text.StringBuilder RequestData;

		public MplayerState state;

		public MyStreamReader(MplayerState ms)
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();

			state = ms;
		}

		public string LastLine
		{
			get
			{
				int end = -1, start = -1;
				
				for(int i = RequestData.Length-1;i>=0;i--)
				{
					if(RequestData[i] == '\n')
					{
						if(end < 0)
							end = i;
						else
						{
							start = i+1;
							break;
						}
					}
				}
				
				if(RequestData[end - 1] == '\r')
					--end;

				if(end > 0 && start < 0)
					start = 0;

				return RequestData.ToString(start, end-start);
			}
		}


	}
}
