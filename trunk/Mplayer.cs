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
using System.Collections;

namespace Power_Mplayer
{
	public enum MediaType {None, File, DVD, VCD, URL, TV, Radio, PVR, DVB, MF, CDDA, CUE, SDP, Mpst, Tivo};

	/// <summary>
	/// Mplayer Class
	/// </summary>
	public class Mplayer
	{
		// process control
		private Process mplayerProc;
		private MyStreamReader stdout;
		private MyStreamReader stderr;
		private System.IO.StreamWriter stdin;

		// power mplayer info
		private MediaInfo minfo;
		private MplayerSetting msetting;
		private ArrayList sublist;
		private Subtitle sub;

		public MediaType mediaType;
		private string mediaFilename;
		private Panel BigScreen;
		private MPlaylist playlist;

		private string CurrentMediaFilename
		{
			set
			{
				this.mediaFilename = value;

				if(this.mediaFilename.StartsWith("vcd://"))
					this.mediaType = MediaType.VCD;
				else if(this.mediaFilename.StartsWith("dvd://"))
					this.mediaType = MediaType.DVD;
				else if(this.mediaFilename.StartsWith("radio://"))
					this.mediaType = MediaType.Radio;
				else if(this.mediaFilename.StartsWith("file://"))
				{
					this.mediaFilename = this.mediaFilename.Substring(7);
					this.mediaType = MediaType.File;
				}
				else if(this.mediaFilename.IndexOf("//") > 0)
					this.mediaType = MediaType.URL;
			}
			get
			{
				return this.mediaFilename;
			}
		}

		public MplayerSetting Setting
		{
			get	{ return msetting; }
		}

		public ArrayList SubList
		{
			get { return sublist; }
		}

		public Subtitle CurrentSubtitle
		{
			get	{ return sub; }
			set	{ sub = value;}
		}

		public MPlaylist Playlist
		{
			get	{ return playlist; }
		}

		// constructure
		public Mplayer(Panel bs)
		{
			mplayerProc = null;
			this.BigScreen = bs;

			minfo = new MediaInfo(this);

			stdout = new MyStreamReader(minfo);
			stderr = new MyStreamReader(minfo);

			msetting = new MplayerSetting();
			playlist = new MPlaylist();
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

		/// <summary>
		/// wait for response
		/// </summary>
		private void WaitForReceive()
		{
			Thread.Sleep(50);
		}

		private bool tran2utf8(string src, string dest)
		{
			try
			{
				Encoding code = Encoding.GetEncoding(this.msetting[SetVars.SubEncoding]);
				using(StreamReader sr = new StreamReader(src, code))
				{
					StreamWriter sw = new StreamWriter(dest, false, Encoding.UTF8);

					string buf = sr.ReadToEnd();
					sw.Write(buf);

					sr.Close();
					sw.Close();
				}

				return true;
			}
			catch(System.Exception ee)
			{
				System.Windows.Forms.MessageBox.Show(ee.Message);
			}

			return false;
		}

		#region controls of movie

		// create process
		public bool Start()
		{			
			if(this.HasInstense())
			{
				this.Quit();
			}

			System.Environment.CurrentDirectory = System.Windows.Forms.Application.StartupPath;
			if(!File.Exists(msetting[SetVars.MplayerExe]))
			{
				System.Windows.Forms.MessageBox.Show("找不到 " + Path.GetFullPath(msetting[SetVars.MplayerExe]) + "\n請從[工具]->[選項]中設定。");
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
				mplayerProc.StartInfo.FileName = msetting[SetVars.MplayerExe];
				mplayerProc.StartInfo.WorkingDirectory = Path.GetDirectoryName(mplayerProc.StartInfo.FileName);

				mplayerProc.StartInfo.Arguments = "-slave -quiet" + // salve mode
					" -msglevel identify=6" +	// show ID_ tag , an easy way to extract information
					" -nokeepaspect"; // to avoid MPlayer-specific bug with non-4:3 displays

				// embed window
				string colorkey = "0x" + ColorTranslator.ToHtml(this.BigScreen.BackColor).TrimStart('#');
				mplayerProc.StartInfo.Arguments += " -wid " + this.BigScreen.Handle + " -colorkey " + colorkey;

				mplayerProc.StartInfo.Arguments += msetting.MplayerArguements;

				// according MediaType
				switch(this.mediaType)
				{
					case MediaType.File:
						// load all subtitles
						sublist = Subtitle.FindSubtitle(this.CurrentMediaFilename);
						if(this.sub == null)
						{
							if(this.sublist.Count > 1)
								this.sub = (Subtitle) sublist[1];
							else
								this.sub = (Subtitle) sublist[0];
						}

						// use subtitle
						if(this.msetting[SetVars.SrtForceUTF8] != "1" 
							|| (sub.SubType != SubtitleType.Ass && sub.SubType != SubtitleType.Srt))
						{
							mplayerProc.StartInfo.Arguments += sub.MplayerStartArgs;
						}
						else
						{
							string ext = Path.GetExtension(sub.Filename);
							string dest = System.Windows.Forms.Application.StartupPath + @"\temp_subtitle" + ext;
							this.tran2utf8(sub.Filename, dest);

							Subtitle s = new Subtitle(dest);
							mplayerProc.StartInfo.Arguments += s.MplayerStartArgs;
						}
						break;

					case MediaType.URL:
						mplayerProc.StartInfo.Arguments += " -cache 8192";
						break;
				}

				if(this.sublist == null || this.sublist.Count == 0)
					sublist = Subtitle.FindSubtitle(null);

				// append filename
				mplayerProc.StartInfo.Arguments += " " + "\"" + this.CurrentMediaFilename + "\"";

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

		public void Pause()
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("pause ");
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

		/*
		public void Exit()
		{
			stdin.WriteLine("exit ");
		}
		*/

		public void Quit()
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("quit ");
				mplayerProc.WaitForExit();

				// wait for last callback in stdout
				this.WaitForReceive();

				stdin.Close();
				stdout.stream.Close();
				stderr.stream.Close();
				stdout.RequestData.Remove(0, stdout.RequestData.Length);
				stderr.RequestData.Remove(0, stderr.RequestData.Length);

				if(this.mediaType == MediaType.File)
				{
					// delete temp_subtitle for ForeceUTF8
					string dest = System.Windows.Forms.Application.StartupPath + @"\temp_subtitle" + Path.GetExtension(sub.Filename);
					if(File.Exists(dest))
						File.Delete(dest);
				}
				
				this.sublist.Clear();
				sub = null;

				this.mediaType = MediaType.None;
			}
		}

		#endregion

		public string Read()
		{
			return stdout.RequestData.ToString();
		}

		public string Filename
		{
			get
			{
				//return (string) minfo["FILENAME"];
				return this.CurrentMediaFilename;
			}
			set
			{
				this.CurrentMediaFilename = value;
			}
		}

		public double Length
		{
			get
			{
				return (double) minfo["LENGTH"];
			}
		}

		#region Pos Property

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

		#endregion

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

		#region Video Property

		public double Video_Aspect
		{
			get
			{
				double ret = (double) minfo["VIDEO_ASPECT"];

				if(ret == 0)
				{
					int wid = (int) minfo["VIDEO_WIDTH"];
					int hei = (int) minfo["VIDEO_HEIGHT"];
				
					if(hei == 0)
						ret = 0;
					else
						ret = (double) wid/hei;
				}			

				return ret ;
			}
			set
			{
				stdin.WriteLine(" switch_ratio " + value.ToString() + " ");
			}
		}

		public int Video_Width
		{
			get
			{
				return (int) minfo["VIDEO_WIDTH"];
			}
		}

		public int Video_Height
		{
			get
			{
				return (int) minfo["VIDEO_HEIGHT"];
			}
		}

		public int Video_Brightness
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("brightness " + value.ToString() + " ");
				}
			}
		}

		public int Video_Contrast
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("contrast " + value.ToString() + " ");
				}
			}
		}

		public int Video_Hue
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("hue " + value.ToString() + " ");
				}
			}
		}

		public int Video_Saturation
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("saturation " + value.ToString() + " ");
				}
			}
		}

		public int Video_Gamma
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("gamma " + value.ToString() + " ");
				}
			}
		}

		#endregion

		#region Sub Property

		public double Sub_Scale
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("sub_scale " + value + " ");
				}
			}
		}

		public int Sub_Pos
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("sub_pos " + value + " ");
				}
			}
		}

		public double Sub_Delay
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("sub_delay " + value + " ");
				}
			}
		}

		public void SelectSub(Subtitle sub)
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("sub_select " + sub.SubID + " ");
			}
		}

		#endregion
	}
}
