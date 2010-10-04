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

		public MyStreamReader()
		{
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();
            LastLine = new StringBuilder();
		}

        private StringBuilder LastLine;

        public void AppendChar(char c)
        {
            LastLine.Append(c);

            if (c == '\n')
            {
                string sbuf = LastLine.ToString().Trim();

                if (sbuf != null)
                {
                    if (OnAppendNewLine != null)
                        OnAppendNewLine(this, sbuf);

                    //if (!sbuf.StartsWith("ANS_TIME_POSITION"))
                        RequestData.Append(LastLine.ToString());
                }

                LastLine.Remove(0, LastLine.Length);
            }
        }

        public delegate void NewLineEventHandler(MyStreamReader sender, string s);
        public event NewLineEventHandler OnAppendNewLine;
	}
}
