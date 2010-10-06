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

        private Dictionary<string, MShortcut> shortcuts;
		private MKeyConverter mkconverter;

        private MPlaylistItem PlayItem { get; set; }
        public Panel BigScreen { get; set; }
        private Form1 MainForm;

        public string Filename
        {
            get
            {
                if (PlayItem != null)
                    return PlayItem.SourcePath;
                else
                    return null;
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


		#region controls of movie

		// create process
        public bool Start(MPlaylistItem item, int start_pos)
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
                " -nokeepaspect -nofontconfig";

            if (start_pos > 0)
                slaveArgs += string.Format(" -ss {0}", start_pos);

            // embed window
            string colorkey = "0x" + ColorTranslator.ToHtml(this.BigScreen.BackColor).TrimStart('#');
            string windowArgs = string.Format("-wid {0} -colorkey {1}", this.BigScreen.Handle.ToString(), colorkey);

            // setting arguements
            string args = string.Format("{0} {1} {2}", slaveArgs, windowArgs, Setting.MplayerArguements);

            // load all subtitles
            minfo.SubMgr.SubEncoding = Setting[SetVars.SubEncoding];
            minfo.SubMgr.ChineseTransMode = int.Parse(Setting[SetVars.SubChineseTrans]);
            minfo.SubMgr.FindSub(this.PlayItem);

            // according MediaType
            switch (this.mediaType)
            {
                case MediaType.File:
                    string subArgs = minfo.SubMgr.CurrentSub.MplayerStartArgs;

                    // create arugments
                    mplayerProc.StartInfo.Arguments = string.Format("{0} {1} \"{2}\"",
                        args, subArgs, Win32API.ToShortPathName(this.Filename));

                    break;

                case MediaType.DVD:
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

            // start mpayer
            if (mplayerProc.Start() == false)
            {
                mplayerProc = null;
                return false;
            }

            // redirect in/output
            stdin = mplayerProc.StandardInput;
            stdin.AutoFlush = true;

            stderr = new MyStreamReader(mplayerProc.StandardError);
            stdout = new MyStreamReader(mplayerProc.StandardOutput);

            stdout.OnAppendNewLine += minfo.SetState;
            stdout.OnAppendNewLine += MainForm.SetTimePos;
            stdout.RequestData.Append(mplayerProc.StartInfo.FileName + " " + mplayerProc.StartInfo.Arguments + "\n\n");
            stdout.BeginRead();
            stderr.BeginRead();

            // config show area
            //Win32API.SetParent(mplayerProc.MainWindowHandle.ToInt32(), this.BigScreen.Handle.ToInt32());
            //Win32API.MoveWindow(mplayerProc.MainWindowHandle.ToInt32(), 0, 0, this.BigScreen.Width, this.BigScreen.Height, true);
            this.BigScreen.BackgroundImage = null;

            isMuted = !isMuted;
            Mute();

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

        public bool isMuted { get; private set; }
		public bool Mute()
		{
            isMuted = !isMuted;
			SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "mute {0}", (isMuted) ? 1 : 0);
			
			return isMuted;
		}

        public void Quit()
        {
            if (this.HasInstense())
            {
                //stdin.WriteLine("quit ");
                SendSlaveCommand(SlaveCommandMode.None, "quit");
                mplayerProc.WaitForExit();

                stdin.Close();
                stdout.Close();
                stderr.Close();
            }

            if (this.mediaType == MediaType.File && minfo.SubMgr.CurrentSub != null)
            {
                // delete temp_subtitle for ForeceUTF8
                string dest = SubManager.GetTempSubPath(minfo.SubMgr.CurrentSub.Filename);
                if (File.Exists(dest))
                    File.Delete(dest);
            }

            //CurrentSubtitle = null;
            AudioChannels.Clear();
            VideoChannels.Clear();

            PlayItem = null;
            this.minfo.ClearValues();
        }

		#endregion

        public void SendSlaveCommand(SlaveCommandMode mode, string[] cmds)
        {
            if (cmds == null)
                return;

            foreach (string s in cmds)
            {
                SendSlaveCommand(mode, s);
            }
        }

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

		public string Read(bool isStderr)
		{
            if (!isStderr)
            {
                if (stdout != null)
                    return stdout.RequestData.ToString();
                else
                    return "";
            }
            else
            {
                if (stderr != null)
                    return stderr.RequestData.ToString();
                else
                    return "";
            }
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
				return minfo.ToInt32("PERCENT_POSITION");
			}
			set
			{
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "seek {0} 1 ", value);
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "get_percent_pos");
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
                SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "get_time_pos");
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
                    isMuted = false;
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
				return minfo.ToDouble("VIDEO_ASPECT");
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
            SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "switch_audio {0}", id);
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

                if(!p.HasExited)
                    p.Kill();
            }

            if (num <= 0)
                return null;

            string[] pathes = new string[num-1];
            for (int i = 0; i < num-1; i++)
            {
                pathes[i] = string.Format("{1} {0}", VolumeLetter, i + 2);
            }

            return pathes;
        }

        public static string[] getDVDTitles(string mpalyerPath, string VolumeLetter)
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
            p.StartInfo.Arguments = string.Format("dvd:// -dvd-device {0} -msglevel identify=6", VolumeLetter);

            p.StartInfo.RedirectStandardOutput = true;

            p.Start();

            int num = 0;
            using (StreamReader sr = p.StandardOutput)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("ID_DVD_TITLES"))
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

            string[] pathes = new string[num];
            for (int i = 0; i < num; i++)
            {
                pathes[i] = string.Format("{1} {0}", VolumeLetter, i + 1);
            }

            return pathes;
        }

    }
}
