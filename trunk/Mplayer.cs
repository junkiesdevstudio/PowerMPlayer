using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// Mplayer 的摘要描述。
	/// </summary>
	public class Mplayer
	{
		private Process mplayerProc;
		private MyStreamReader stdout;
		private MyStreamReader stderr;
		private System.IO.StreamWriter stdin;

		private Panel BigScreen;


		public Mplayer(Panel bs)
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
			mplayerProc = null;
			this.BigScreen = bs;

			stdout = new MyStreamReader();
			stderr = new MyStreamReader();
		}


		private static void ReadCallBack(IAsyncResult asyncResult)
		{
			MyStreamReader rs = (MyStreamReader) asyncResult.AsyncState;
			int read = rs.stream.BaseStream.EndRead(asyncResult);

			if(read > 0)
			{
				char[] charBuf = new char[read];
				int len = Encoding.Default.GetDecoder().GetChars(rs.Buffer, 0, read, charBuf, 0);
				//string str = new string(charBuf);
				rs.RequestData.Append(charBuf);
				
				rs.stream.BaseStream.BeginRead(rs.Buffer, 0, rs.Buffer.Length, new AsyncCallback(ReadCallBack), rs);
			}

			return ;

		}

		// create process
		public void Start(string filename)
		{			
			if(mplayerProc == null || mplayerProc.HasExited)
			{
				mplayerProc = new Process();

				mplayerProc.StartInfo.CreateNoWindow = true;
				mplayerProc.StartInfo.UseShellExecute = false;
				mplayerProc.StartInfo.RedirectStandardError = true;
				mplayerProc.StartInfo.RedirectStandardInput = true;
				mplayerProc.StartInfo.RedirectStandardOutput = true;

				// create command
				mplayerProc.StartInfo.FileName = @"C:\mplayer\mplayer.exe";
				mplayerProc.StartInfo.WorkingDirectory = @"C:\mplayer";

				mplayerProc.StartInfo.Arguments = "-slave -quiet" + // salve mode
					" -identify" +	// show ID_ tag , an easy way to extract information
					" -nokeepaspect"; // to avoid MPlayer-specific bug with non-4:3 displays

				// embed window
				string colorkey = "0x" + ColorTranslator.ToHtml(this.BigScreen.BackColor).TrimStart('#');
				mplayerProc.StartInfo.Arguments += " -wid " + this.BigScreen.Handle + " -colorkey " + colorkey;

				//System.Windows.Forms.MessageBox.Show(mplayerProc.StartInfo.Arguments);

				// append filename
				mplayerProc.StartInfo.Arguments += " " + filename;

				// start mpayer
				mplayerProc.Start();

				// redirect in/output
				stdin = mplayerProc.StandardInput;
				stdout.stream = mplayerProc.StandardOutput;		
				stderr.stream = mplayerProc.StandardError;

				stdin.AutoFlush = true;
				stdout.stream.BaseStream.BeginRead(stdout.Buffer, 0, MyStreamReader.BUFFER_SIZE, new AsyncCallback(ReadCallBack), stdout);
				stderr.stream.BaseStream.BeginRead(stderr.Buffer, 0, MyStreamReader.BUFFER_SIZE, new AsyncCallback(ReadCallBack), stderr);

				// config show area
				//Win32API.SetParent(mplayerProc.MainWindowHandle.ToInt32(), this.BigScreen.Handle.ToInt32());
				//Win32API.MoveWindow(mplayerProc.MainWindowHandle.ToInt32(), 0, 0, this.BigScreen.Width, this.BigScreen.Height, true);
				this.BigScreen.BackgroundImage = null;
			}
			else
			{
				Pause();
			}
			
		}

		/// <summary>
		/// controls of movie
		/// </summary>
		public void Stop()
		{
			stdin.AutoFlush = true;
			stdin.WriteLine("stop");
		}

		public void Pause()
		{
			stdin.WriteLine("pause ");
		}

		public string Read()
		{
			return stdout.RequestData.ToString();;
		}

		public void Exit()
		{
			stdin.WriteLine("exit ");
		}

		public void Quit()
		{
			if(mplayerProc != null)
			{
				stdin.WriteLine("quit ");
				stdin.Flush();

				mplayerProc.WaitForExit();

				stdin.Close();
				stdout.stream.Close();
				stderr.stream.Close();
			}
		}

		/// implement of slave property
		/// 
		
		public string Filename
		{
			get
			{
				stdin.WriteLine("get_file_name ");
				return stdout.LastLine;
			}
		}

		public int Audio_Bitrate
		{
			get
			{
				stdin.WriteLine("get_audio_bitrate ");
				return 0;
			}
		}

		public string Audio_Codec
		{
			get
			{
				stdin.WriteLine("get_audio_codec ");
				return "";
			}
		}

		public int Percent_Pos
		{
			get
			{
				stdin.WriteLine("get_percent_pos ");
				return 0;
			}
			set
			{
				stdin.WriteLine("seek " + value.ToString() + " 1 ");
			}
		}

		public double Time_Pos
		{
			get
			{
				stdin.WriteLine("get_time_pos ");
				return 0.0;
			}
			set
			{
				stdin.WriteLine("seek " + value.ToString() + " 2 ");
			}
		}

		public double Length
		{
			get
			{
				stdin.WriteLine("get_time_length ");
				return 0.0;
			}
		}

		public double Volume
		{
			set
			{
				stdin.WriteLine("volume " + (value * 10).ToString() + " 1 ");
			}
		}
	}
}
