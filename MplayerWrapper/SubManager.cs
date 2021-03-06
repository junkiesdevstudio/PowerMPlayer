﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MplayerWrapper
{
    public enum SubtitleType { NoSubtitle, Srt, Ass, VobSubFile, VobSubID, DemuxSubID };
    
    /// <summary>
    /// SubManager provide functions (API) that manage subtitle
    /// 
    /// Abstract:
    /// since subtitle functions provide from mpalayer is not so good, so we handled all things from UI.
    /// 
    /// here is main principles: 
    ///     * mplayer may know only one subtitle item (CurrentSub) from UI.
    ///     * we try do everything (including change encoding) in slave mode, reduce restart player times.
    /// 
    /// For VOBSub:
    ///     * select sub file restart player
    ///     * select sub id using slave mode
    /// 
    /// For DemuxSub:
    ///     * select sub id using slave mode
    ///     
    /// For SUB_FILE (SRT / SSA)
    ///     * let mplayer eat only one encoding UTF8 (-utf8)
    ///     * we translation encoding from user's setting to utf8 in a temp file, 
    ///       then feed the temp file to mplayer.
    ///     * so we can do anything without restart player.
    ///     
    /// API summary:
    ///     public void FindSub(MPlaylistItem playitem): find the all sub files in the media folder
    ///     public void AddSub(string str): for MediaInfo to add mplayer detected sub id
    ///     public Subtitle[] ListSubtitle(): list all subs 
    ///     public string[] SelectSub(Subtitle sub): 
    ///         tell the manager use the sub before / after Mplayer.Start() and do preprocess.
    ///         * before Mplayer.Start() : start playing with selected sub
    ///         * after Mplayer.Start() : create slave commands that can switch to the sub 
    ///                                   in slave mode without restart player
    ///     public Subtitle CurrentSub: get using sub
    ///     public string SubEncoding: set/get encoding
    ///     public int ChineseTransMode: set/get chinese translation mode. 
    ///         * 0: none 
    ///         * 1: to Traditional Chinese
    ///         * 2: to Simplified Chinese
    /// </summary>
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
            else
                SelectSub(CurrentSub);

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
                // Example: 
                // ID_SUBTITLE_ID=0
                // ID_SID_0_LANG=chi
                // ID_SID_0_NAME=chs    <== what we need
                // ID_SUBTITLE_ID=1
                // ID_SID_1_LANG=eng
                // ID_SID_1_NAME=eng    <== what we need
                // ID_SUBTITLE_ID=2
                // ID_SID_2_LANG=chi
                // ID_SID_2_NAME=cht    <== what we need

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
            if (sub == null)
                return null;

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
