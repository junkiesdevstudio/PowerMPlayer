using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Power_Mplayer
{
    public enum SubtitleType { NoSubtitle, Srt, Ass, VobSubFile, VobSubID, DemuxSubID };

    public class SubManager
    {
        private MPlaylistItem _playItem;
        private List<Subtitle> _subList;
        public Subtitle CurrentSub { get; private set; }
        public string SubEncoding { get; set; }
        public int ChineseTransMode { get; set; }

        public SubManager()
        {
            _subList = new List<Subtitle>();
            CurrentSub = null;
        }

        public static string GetTempSubPath(string srcPath)
        {
            return System.Windows.Forms.Application.StartupPath + @"\temp_subtitle" + Path.GetExtension(srcPath);
        }
        
        public void FindSub(MPlaylistItem playitem)
        {
            if (playitem == null)
                return;

            if (_playItem != null && _playItem.SourcePath != playitem.SourcePath)
                CurrentSub = null;

            _playItem = playitem;
            string filename = playitem.SourcePath;

            _subList.Clear();

            // add no subtitle			
            _subList.Add(new Subtitle(null));

            if (filename == null || !File.Exists(filename) || playitem.ItemType != MediaType.File)
            {
                CurrentSub = _subList[0];
                return;
            }

            string subdir = Path.GetDirectoryName(filename);
            filename = Path.GetFileNameWithoutExtension(filename).ToLower();

            string[] files = System.IO.Directory.GetFiles(subdir);

            for (int i = 0; i < files.Length; i++)
            {
                if (!Path.GetFileName(files[i]).ToLower().StartsWith(filename))
                    continue;

                switch (Path.GetExtension(files[i]).ToLower())
                {
                    case ".ass":
                    case ".srt":
                    case ".idx":
                        _subList.Add(new Subtitle(files[i]));
                        break;
                }
            }

            if (CurrentSub == null)
            {
                if (_subList.Count > 1)
                    SelectSub(_subList[1]);
                else
                    SelectSub(_subList[0]);
            }

            return;
        }

        public void AddSub(string str)
        {
            Subtitle sub = null;

            string[] substr = str.Split('_', '=');

            if (str.StartsWith("VSID"))
            {
                int id = int.Parse(substr[1]);
                string lang = substr[3];

                sub = new Subtitle(CurrentSub.Filename, id.ToString() + " : " + lang, id, SubtitleType.VobSubID);
            }
            else if (str.StartsWith("SID"))
            {
                // SID_0_LANG=chi , no need
                // ???
                if (substr[2] == "LANG")
                    return;

                int id = int.Parse(substr[1]);
                string lang = substr[3];

                sub = new Subtitle(CurrentSub.Filename, id.ToString() + " : " + lang, id, SubtitleType.DemuxSubID);
            }

            if (sub != null)
            {
                _subList.Add(sub);
            }

            return;
        }

        public Subtitle[] ListSubtitle()
        {
            return _subList.ToArray();
        }

        public static bool tran2utf8(string src, string dest, string srcEncoding, int transMode)
        {
            try
            {
                Encoding code = Encoding.GetEncoding(srcEncoding);
                using (StreamReader sr = new StreamReader(src, code))
                {
                    StreamWriter sw = new StreamWriter(dest, false, Encoding.UTF8);

                    string buf = sr.ReadToEnd();

                    if (transMode == 1)
                    {
                        buf = Win32API.ToTraditional(buf);
                    }
                    else if (transMode == 2)
                    {
                        buf = Win32API.ToSimplified(buf);
                    }

                    sw.Write(buf);

                    sr.Close();
                    sw.Close();
                }

                return true;
            }
            catch { }

            return false;
        }

        public string[] SelectSub(Subtitle sub)
        {
            List<string> slaveArgs = new List<string>();

            CurrentSub = sub;

            if (sub.getSlaveCommand() != null)
            {
                slaveArgs.Add(sub.getSlaveCommand());
                return slaveArgs.ToArray();
            }

            if (sub.SubType == SubtitleType.Srt || sub.SubType == SubtitleType.Ass)
            {
                slaveArgs.Add("sub_remove -1");
                
                string utf8Path = GetTempSubPath(sub.Filename);
                if (File.Exists(utf8Path))
                    File.Delete(utf8Path);

                tran2utf8(sub.Filename, utf8Path, SubEncoding, ChineseTransMode);

                string newpath = Win32API.ToShortPathName(utf8Path).Replace("\\", "\\\\");
                slaveArgs.Add(string.Format("sub_load {0}", newpath));
                slaveArgs.Add("sub_file 0");
                return slaveArgs.ToArray();
            }

            return null;
        }

    }
}
