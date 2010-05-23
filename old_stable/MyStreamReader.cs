using System;
using System.IO;
using System.Text;

namespace Power_Mplayer
{
	/// <summary>
	/// MyStreamReader
	/// </summary>
	public class MyStreamReader
	{
		public const int BUFFER_SIZE = 128;

		public System.IO.StreamReader stream;
		public byte[] Buffer;
		public System.Text.StringBuilder RequestData;

		public MediaInfo minfo;

		public MyStreamReader(MediaInfo mi)
		{
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();

			minfo = mi;
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

				// should this happened ? 
				if(start < 0)
					return null;

				return RequestData.ToString(start, end-start);
			}
		}


	}
}
