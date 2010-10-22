using System;
using System.IO;
using System.Text;

namespace MplayerWrapper
{
	/// <summary>
	/// MyStreamReader
	/// </summary>
	public class MyStreamReader
	{
		public const int BUFFER_SIZE = 128;

        private StreamReader stream;
        public byte[] Buffer { get; private set; }
        public StringBuilder RequestData { get; private set; }

		public MyStreamReader(StreamReader sr)
		{
			Buffer = new byte[BUFFER_SIZE];
			RequestData = new StringBuilder();
            LastLine = new StringBuilder();

            _asyncResult = null;
            stream = sr;
		}

        private StringBuilder LastLine;
        private void AppendChar(char c)
        {
            LastLine.Append(c);

            if (c == '\n')
            {
                string sbuf = LastLine.ToString().Trim();

                if (sbuf != null)
                {
                    //if (!sbuf.StartsWith("ANS_TIME_POSITION"))
                    RequestData.Append(LastLine.ToString());

                    if (OnAppendNewLine != null && _continueRead)
                        OnAppendNewLine(this, sbuf);
                }

                LastLine.Remove(0, LastLine.Length);
            }
        }

        public delegate void NewLineEventHandler(MyStreamReader sender, string s);
        public event NewLineEventHandler OnAppendNewLine;

        private IAsyncResult _asyncResult;
        private bool _continueRead;

        public void BeginRead()
        {
            _continueRead = true;
            _asyncResult = this.stream.BaseStream.BeginRead(Buffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), null);
        }

        private void EndRead()
        {
            _continueRead = false;

            if (_asyncResult != null)
            {
                _asyncResult.AsyncWaitHandle.WaitOne();
                _asyncResult = null;
            }
        }

        public void Close()
        {
            EndRead();
            stream.Close();
            RequestData.Remove(0, RequestData.Length);
        }

        private void ReadCallBack(IAsyncResult asyncResult)
        {
            int read = stream.BaseStream.EndRead(asyncResult);

            if (read > 0)
            {
                char[] charBuf = new char[read];
                int len = Encoding.Default.GetDecoder().GetChars(Buffer, 0, read, charBuf, 0);

                for (int i = 0; i < len; i++)
                    AppendChar(charBuf[i]);

                if (_continueRead)
                    BeginRead();
                else
                    _asyncResult = null;
            }

            return;
        }

	}
}
