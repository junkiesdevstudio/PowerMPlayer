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

        public StreamReader stream { get; set; }
        public byte[] Buffer { get; private set; }
        public StringBuilder RequestData { get; private set; }

        public MediaInfo minfo { get; private set; }

		public MyStreamReader(MediaInfo mi)
		{
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();
            LastLine = new StringBuilder();

			minfo = mi;
		}

        public StringBuilder LastLine { get; private set; }

        public void AppendLastlineToRequestData()
        {
            RequestData.Append(LastLine.ToString());
            LastLine.Remove(0, LastLine.Length);
        }

        public void AppendChar(char c)
        {
            LastLine.Append(c);
        }

        /*
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
        */


	}
}
