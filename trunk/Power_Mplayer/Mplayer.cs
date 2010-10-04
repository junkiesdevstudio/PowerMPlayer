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
using System.Collections.Generic;

namespace Power_Mplayer
{
	public enum MediaType {None, File, DVD, VCD, URL, CDDA};
    public enum SlaveCommandMode { None, Pausing, Pausing_Keep, Pausing_Toggle, Pausing_Keep_Force };

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
        public MediaInfo minfo { get; private set; }
        public MplayerSetting Setting {get; private set;}
        public List<Subtitle> SubList { get; private set; }
        public Subtitle CurrentSubtitle {get; set;}
        private Dictionary<string, MShortcut> shortcuts;
		private MKeyConverter mkconverter;

        private MPlaylistItem PlayItem { get; set; }
        public Panel BigScreen { get; set; }
        private Form1 MainForm;

        public string Filename
        {
            get
            {
                return PlayItem.SourcePath;
            }
        }

        public MediaType mediaType
        {
            get
            {
                if (PlayItem != null)       // quit before playing anything
                    return PlayItem.ItemType;
                else
                    return MediaType.None;
            }
        }

		// constructure
		public Mplayer(Form1 f, MplayerSetting ms)
		{
			mplayerProc = null;
            this.MainForm = f;
			this.BigScreen = f.BigScreen;

			minfo = new MediaInfo(this);

			stdout = new MyStreamReader();
			stderr = new MyStreamReader();
            stdout.OnAppendNewLine += minfo.SetState;
            stdout.OnAppendNewLine += f.SetTimePos;

            Setting = ms;
			
			string fname = Setting[SetVars.MplayerExe];
			if(fname.IndexOf(Path.VolumeSeparatorChar) < 0)
			{
				fname = System.Windows.Forms.Application.StartupPath + @"\" + fname;
			}
			fname = Path.GetDirectoryName(fname) + @"\mplayer\input.conf";

			this.shortcuts = MShortcut.LoadShortcuts(fname);
			this.mkconverter = new MKeyConverter();
		}

		public bool HasInstense()
		{
			return (mplayerProc != null && !mplayerProc.HasExited);
		}

		// receive data from mplayer 
		private void ReadCallBack(IAsyncResult asyncResult)
		{
			MyStreamReader rs = asyncResult.AsyncState as MyStreamReader;
			int read = rs.stream.BaseStream.EndRead(asyncResult);

			if(read > 0)
			{
				char[] charBuf = new char[read];
				int len = Encoding.Default.GetDecoder().GetChars(rs.Buffer, 0, read, charBuf, 0);

				for(int i=0;i<len;i++)
                    rs.AppendChar(charBuf[i]);
				
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
				Encoding code = Encoding.GetEncoding(this.Setting[SetVars.SubEncoding]);
				using(StreamReader sr = new StreamReader(src, code))
				{
					StreamWriter sw = new StreamWriter(dest, false, Encoding.UTF8);

					string buf = sr.ReadToEnd();

                    if (Setting[SetVars.SubChineseTrans] == "1")
                    {
                        buf = Win32API.ToTraditional(buf);
                    }
                    else if (Setting[SetVars.SubChineseTrans] == "2")
                    {
                        buf = Win32API.ToSimplified(buf);
                    }

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
        public bool Start(MPlaylistItem item)
        {
            if (this.HasInstense())
                this.Quit();

            System.Environment.CurrentDirectory = System.Windows.Forms.Application.StartupPath;
            if (!File.Exists(Setting[SetVars.MplayerExe]))
            {
                System.Windows.Forms.MessageBox.Show("找不到 " + Path.GetFullPath(Setting[SetVars.MplayerExe]) + "\n請從[工具]->[選項]中設定。");
                return false;
            }

            PlayItem = item;

            mplayerProc = new Process();

            mplayerProc.StartInfo.CreateNoWindow = true;
            mplayerProc.StartInfo.UseShellExecute = false;
            mplayerProc.StartInfo.RedirectStandardError = true;
            mplayerProc.StartInfo.RedirectStandardInput = true;
            mplayerProc.StartInfo.RedirectStandardOutput = true;

            // create command
            mplayerProc.StartInfo.FileName = Setting[SetVars.MplayerExe];
            mplayerProc.StartInfo.WorkingDirectory = Path.GetDirectoryName(mplayerProc.StartInfo.FileName);

            // enable slave mode
            string slaveArgs = "-slave -quiet" + // salve mode
                " -msglevel identify=6" +	// show ID_ tag , an easy way to extract information
                " -nokeepaspect";

            // embed window
            string colorkey = "0x" + ColorTranslator.ToHtml(this.BigScreen.BackColor).TrimStart('#');
            string windowArgs = string.Format("-wid {0} -colorkey {1}", this.BigScreen.Handle.ToString(), colorkey);

            // setting arguements
            //mplayerProc.StartInfo.Arguments += Setting.MplayerArguements;
            string args = string.Format("{0} {1} {2}", slaveArgs, windowArgs, Setting.MplayerArguements);

            // according MediaType
            switch (this.mediaType)
            {
                case MediaType.File:
                    // load all subtitles
                    SubList = Subtitle.FindSubtitle(this.Filename);
                    if (this.CurrentSubtitle == null)
                    {
                        if (this.SubList.Count > 1)
                            this.CurrentSubtitle = SubList[1];
                        else
                            this.CurrentSubtitle = SubList[0];
                    }

                    string subArgs = "";

                    // use subtitle
                    if (this.Setting[SetVars.SrtForceUTF8] != "1"
                        || (CurrentSubtitle.SubType != SubtitleType.Ass && CurrentSubtitle.SubType != SubtitleType.Srt))
                    {
                        subArgs = CurrentSubtitle.MplayerStartArgs;
                    }
                    else
                    {
                        string ext = Path.GetExtension(CurrentSubtitle.Filename);
                        string dest = System.Windows.Forms.Application.StartupPath + @"\temp_subtitle" + ext;
                        this.tran2utf8(CurrentSubtitle.Filename, dest);

                        Subtitle s = new Subtitle(dest);
                        subArgs = s.MplayerStartArgs;
                    }

                    // create arugments
                    mplayerProc.StartInfo.Arguments = string.Format("{0} {1} \"{2}\"",
                        args, subArgs, Win32API.ToShortPathName(this.Filename));

                    break;

                case MediaType.VCD:
                    // create arguments
                    mplayerProc.StartInfo.Arguments = string.Format("{0} {1}",
                        PlayItem.GetMplayerCommand(), args);
                    break;

                case MediaType.URL:
                default:
                    // create arguments
                    mplayerProc.StartInfo.Arguments = string.Format("{0} -cache 8192 \"{1}\"",
                        args, this.Filename);

                    break;
            }

            if (this.SubList == null || this.SubList.Count == 0)
                SubList = Subtitle.FindSubtitle(null);  // create empty SubList

            // start mpayer
            if (mplayerProc.Start() == false)
            {
                mplayerProc = null;
                return false;
            }

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
            SendSlaveCommand(SlaveCommandMode.Pausing, "seek 0 2");
		}

		private bool Muted = false;
		public bool Mute()
		{
			SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "mute {0}", (Muted) ? 0 : 1);
			Muted = !Muted;
			return Muted;
		}

        public void Quit()
        {
            if (this.HasInstense())
            {
                //stdin.WriteLine("quit ");
                SendSlaveCommand(SlaveCommandMode.None, "quit");
                mplayerProc.WaitForExit();

                // wait for last callback in stdout
                this.WaitForReceive();

                stdin.Close();
                stdout.stream.Close();
                stderr.stream.Close();
                stdout.RequestData.Remove(0, stdout.RequestData.Length);
                stderr.RequestData.Remove(0, stderr.RequestData.Length);
            }

            if (this.mediaType == MediaType.File && CurrentSubtitle != null)
            {
                // delete temp_subtitle for ForeceUTF8
                string dest = System.Windows.Forms.Application.StartupPath + @"\temp_subtitle" + Path.GetExtension(CurrentSubtitle.Filename);
                if (File.Exists(dest))
                    File.Delete(dest);

                this.SubList.Clear();
            }

            
            CurrentSubtitle = null;
            AudioChannels.Clear();
            VideoChannels.Clear();

            PlayItem = null;
            this.minfo.ClearValues();
        }

		#endregion

        public bool SendSlaveCommand(SlaveCommandMode mode, string format, params object[] args)
        {
            if (HasInstense())
            {
                string cmd = string.Format("{0}{1} ",
                    (mode == SlaveCommandMode.None) ? "" : mode.ToString().ToLower() + " ",
                    string.Format(format, args));

                stdin.WriteLine(cmd);
                stdin.Flush();
                return true;
            }
            return false;
        }

		public string Read()
		{
			return stdout.RequestData.ToString();
		}

		public double Length
		{
			get
			{
                return minfo.ToDouble("LENGTH");
			}
		}

		#region Pos Property

		public int Percent_Pos
		{
			get
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("get_percent_pos ");
					this.WaitForReceive();

					return minfo.ToInt32("PERCENT_POSITION");
				}
				return 0;
			}
			set
			{
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "seek {0} 1 ", value);
			}
		}

		public double Time_Pos
		{
			get
			{
                return minfo.ToDouble("TIME_POSITION");
			}
			set
			{
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "seek {0} 2", value);
			}
		}

		public double RelativeTime_Pos
		{
			set
			{
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "seek {0}", value);
			}
		}

		#endregion

        private double _volume;

		public double Volume
		{
			set
			{
                _volume = value;
                if (SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "volume {0} 1", value) == true)
                    Muted = false;
			}
            get
            {
                return _volume;
            }
		}

		#region Video Property

		public double Video_Aspect
		{
			get
			{
//				double ret = (double) minfo["VIDEO_ASPECT"];
                double ret = 0;

//				if(ret == 0)
				{
                    int wid = minfo.ToInt32("VIDEO_WIDTH");
                    int hei = minfo.ToInt32("VIDEO_HEIGHT");

                    if (hei == 0)
                        ret = 0;
                    else
                        ret = (double)wid / hei;
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
				return minfo.ToInt32("VIDEO_WIDTH");
			}
		}

		public int Video_Height
		{
			get
			{
				return minfo.ToInt32("VIDEO_HEIGHT");
			}
		}

		#endregion

		#region Sub Property

		public void SelectSub(Subtitle sub)
		{
			if(this.HasInstense())
			{
				stdin.WriteLine("sub_select " + sub.SubID + " ");
			}
		}

		#endregion

		public double Speed_mult
		{
			set
			{
				if(this.HasInstense())
				{
					stdin.WriteLine("speed_mult {0} ", value);
				}
			}
		}

		public string LaunchShortcut(System.Windows.Forms.KeyEventArgs e)
		{
			string str = "";
			if(e.Shift)
				str = this.mkconverter.getKeyName((int) e.KeyCode | (int) Keys.Shift);
			else
				str = this.mkconverter.getKeyName((int) e.KeyCode);

			//this seens to be generating a NullReferenceException, to avoid it I check if the this.shortcuts is null
			//TODO: Replace the shortcuts by methods that are fired by the form, avoiding these errors
            if (this.shortcuts != null)
            {
                try
                {
                    str = this.shortcuts[str].Cmd;
                }
                catch 
                {
                    // not found
                    str = "None";
                }
            }

			return str;
		}

        public void Screenshot(MyStreamReader.NewLineEventHandler handler)
        {
            if (HasInstense())
            {
                stdout.OnAppendNewLine += handler;
                SendSlaveCommand(SlaveCommandMode.Pausing, "screenshot 0");
            }

            return;
        }

        public List<int> AudioChannels
        {
            get { return minfo.AudioChannel; }
        }

        public List<int> VideoChannels
        {
            get { return minfo.VideoChannel; }
        }

        public void Audio_Select(string id)
        {
            if (this.HasInstense())
            {
                stdin.WriteLine("switch_audio {0} ", id);
            }
        }

        public static string[] getVCDTracks(string mpalyerPath, string VolumeLetter)
        {
            if (!File.Exists(mpalyerPath))
            {
                MessageBox.Show("mplayer.exe not found.");
                return null;
            }

            Process p = new Process();

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;

            // create command
            p.StartInfo.FileName = mpalyerPath;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(p.StartInfo.FileName);
            p.StartInfo.Arguments = string.Format("vcd:// -cdrom-device {0} -msglevel identify=6", VolumeLetter);

            p.StartInfo.RedirectStandardOutput = true;

            p.Start();

            int num = 0;
            using (StreamReader sr = p.StandardOutput)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("ID_VCD_END_TRACK"))
                    {
                        string snum = line.Substring(line.IndexOf('=') + 1).Trim();
                        num = int.Parse(snum);
                        break;
                    }
                }

                sr.Close();
                p.Kill();
            }

            if (num <= 0)
                return null;

            string[] pathes = new string[num-1];
            for (int i = 0; i < num-1; i++)
            {
                pathes[i] = string.Format("{0}{1}", VolumeLetter, i + 2);
            }

            return pathes;
        }

    }
}
