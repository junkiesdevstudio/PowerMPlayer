///////////////////////////////
// Power Mplayer, Mplayer.cs 
// Author: hialan.liu@gmail.com
///////////////////////////////

using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace Power_Mplayer
{
	/// <summary>
	/// Mplayer Class
	/// </summary>
	public class Mplayer
	{
		private Process mplayerProc;
		private MyStreamReader stdout;
		private MyStreamReader stderr;
		private System.IO.StreamWriter stdin;

		private MediaInfo minfo;
		private MplayerSetting msetting;

		private Panel BigScreen;

		public MplayerSetting Setting
		{
			get
			{
				return msetting;
			}
		}

		// constructure
		public Mplayer(Panel bs)
		{
			mplayerProc = null;
			this.BigScreen = bs;

			minfo = new MediaInfo();

			stdout = new MyStreamReader(minfo);
			stderr = new MyStreamReader(minfo);

			msetting = new MplayerSetting();
		}

		public bool HasInstense()
		{
			return (mplayerProc != null && !mplayerProc.HasExited);
		}

		// receive data from mplayer 
		private static void ReadCallBack(IAsyncResult asyncResult)
		{
			MyStreamReader rs = (MyStreamReader) asyncResult.AsyncState;
			int read = rs.stream.BaseStream.EndRead(asyncResult);

			if(read > 0)
			{
				char[] charBuf = new char[read];
				int len = Encoding.Default.GetDecoder().GetChars(rs.Buffer, 0, read, charBuf, 0);

				for(int i=0;i<len;i++)
				{
					rs.RequestData.Append(charBuf[i]);

					if(charBuf[i] == '\n')
					{
						rs.minfo.SetState(rs.LastLine);
					}
				}
				
				rs.stream.BaseStream.BeginRead(rs.Buffer, 0, rs.Buffer.Length, new AsyncCallback(ReadCallBack), rs);
			}

			return ;
		}

		// create process
		public bool Start(string filename)
		{			

			if(this.HasInstense())
			{
				this.Quit();
			}

			System.Environment.CurrentDirectory = System.Windows.Forms.Application.StartupPath;
			if(!File.Exists(msetting[MplayerSetting.MPLAYER_EXE]))
			{
				System.Windows.Forms.MessageBox.Show("找不到 " + Path.GetFullPath(msetting[MplayerSetting.MPLAYER_EXE]) + "\n請從[工具]->[選項]中設定。");
				return false;
			}

			if(mplayerProc == null || mplayerProc.HasExited)
			{
				mplayerProc = new Process();

				mplayerProc.StartInfo.CreateNoWindow = true;
				mplayerProc.StartInfo.UseShellExecute = false;
				mplayerProc.StartInfo.RedirectStandardError = true;
				mplayerProc.StartInfo.RedirectStandardInput = true;
				mplayerProc.StartInfo.RedirectStandardOutput = true;

				// create command
				mplayerProc.StartInfo.FileName = msetting[MplayerSetting.MPLAYER_EXE];
				mplayerProc.StartInfo.WorkingDirectory = Path.GetDirectoryName(mplayerProc.StartInfo.FileName);

				mplayerProc.StartInfo.Arguments = "-slave -quiet" + // salve mode
					" -msglevel identify=6" +	// show ID_ tag , an easy way to extract information
					" -nokeepaspect"; // to avoid MPlayer-specific bug with non-4:3 displays

				// embed window
				string colorkey = "0x" + ColorTranslator.ToHtml(this.BigScreen.BackColor).TrimStart('#');
				mplayerProc.StartInfo.Arguments += " -wid " + this.BigScreen.Handle + " -colorkey " + colorkey;

				//System.Windows.Forms.MessageBox.Show(mplayerProc.StartInfo.Arguments);

				mplayerProc.StartInfo.Arguments += msetting.MplayerArguements;

				// append filename
				mplayerProc.StartInfo.Arguments += " " + "\"" + filename + "\"";

				// start mpayer
				mplayerProc.Start();

				// redirect in/output
				stdin = mplayerProc.StandardInput;
				stdout.stream = mplayerProc.StandardOutput;		
				stderr.stream = mplayerProc.StandardError;

				stdin.AutoFlush = true;

				stdout.RequestData.Append(mplayerProc.StartInfo.FileName + " " + mplayerProc.StartInfo.Arguments + "\n\n");
				stdout.stream.BaseStream.BeginRead(stdout.Buffer, 0, MyStreamReader.BUFFER_SIZE, new AsyncCallback(ReadCallBack), stdout);
				stderr.stream.BaseStream.BeginRead(stderr.Buffer, 0, MyStreamReader.BUFFER_SIZE, new AsyncCallback(ReadCallBack), stderr);

				// config show area
				//Win32API.SetParent(mplayerProc.MainWindowHandle.ToInt32(), this.BigScreen.Handle.ToInt32());
				//Win32API.MoveWindow(mplayerProc.MainWindowHandle.ToInt32(), 0, 0, this.BigScreen.Width, this.BigScreen.Height, true);
				this.BigScreen.BackgroundImage = null;

				Pause();
				System.Threading.Thread.Sleep(1000);
				Pause();
			}			

			return true;
		}

		// wait for response
		private void WaitForReceive()
		{
			Thread.Sleep(50);
		}

		/// <summary>
		/// controls of movie
		/// </summary>
		/// 
		private bool Playing = true;
		public void Pause()
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("pause ");

				Playing = !Playing;
			}
		}

		public void Stop()
		{
			if(this.HasInstense())
			{
				this.Time_Pos = 0;
				Pause();
			}
		}

		private bool Muted = false;
		public bool Mute()
		{
			if(Muted)
			{
				stdin.WriteLine("mute 0 ");
			}
			else
			{
				stdin.WriteLine("mute 1 ");
			}
			Muted = !Muted;

			return Muted;
		}

		public string Read()
		{
			return stdout.RequestData.ToString();
		}

		public void Exit()
		{
			stdin.WriteLine("exit ");
		}

		public void Quit()
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("quit ");

				mplayerProc.WaitForExit();

				this.WaitForReceive();

				stdin.Close();
				stdout.stream.Close();
				stderr.stream.Close();
				stdout.RequestData.Remove(0, stdout.RequestData.Length);
				stderr.RequestData.Remove(0, stderr.RequestData.Length);
			}
		}

		public void FullScreen()
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("vo_fullscreen 1 ");
			}
		}

		public string Filename
		{
			get
			{
				return (string) minfo["FILENAME"];
			}
		}

		public int Percent_Pos
		{
			get
			{
				stdin.WriteLine("get_percent_pos ");
				this.WaitForReceive();
				return (int) minfo["PERCENT_POSITION"];
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
				this.WaitForReceive();
				return (double) minfo["TIME_POSITION"];
			}
			set
			{
				stdin.WriteLine("seek " + value.ToString() + " 2 ");
			}
		}

		public double Volume
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("volume " + (value * 10).ToString() + " 1 ");
					Muted = false;
				}
			}
		}

		public double Video_Aspect
		{
			get
			{
				int wid = (int) minfo["VIDEO_WIDTH"];
				int hei = (int) minfo["VIDEO_HEIGHT"];
				
				if(hei == 0)
					return 0;
				else
					return (double) wid/hei;
			}
		}

		public double Length
		{
			get
			{
				return (double) minfo["LENGTH"];
			}
		}
	}
}
