using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Power_Mplayer
{
	public class Subtitle
	{
		public SubtitleType SubType;
		public string Filename;
		public string Name;
		public int SubID;	// VobSubID , DVDSubID

		public Subtitle(string filename)
		{
			this.SubID = -1;

			if(filename == null)
			{
				this.Filename = "";
				this.SubType = SubtitleType.NoSubtitle;
				this.Name = "No Subtitle";
			}
			else
			{
				this.Filename = filename;
				this.Name = Path.GetFileName(filename);
			
				string ext = Path.GetExtension(filename);
				switch(ext.ToLower())
				{
					case ".srt":
						this.SubType = SubtitleType.Srt;
						break;
					case ".idx":
						//this.Filename = Path.GetDirectoryName(filename) + @"\" + Path.GetFileNameWithoutExtension(filename);
						this.SubType = SubtitleType.VobSubFile;
						break;
					case ".ass":
						this.SubType = SubtitleType.Ass;
						break;
				}
			}
		}

		// for vobsub
		public Subtitle(string fname, string name, int vobid, SubtitleType type)
		{
			this.Filename = fname;
			this.Name = name;
			this.SubID = vobid;
			this.SubType = type;
		}

		public override string ToString()
		{
			return this.Name;
		}

		public string MplayerStartArgs
		{
			get
			{
				string ret = "";

                string fname = Win32API.ToShortPathName(this.Filename);

				switch(this.SubType)
				{
					case SubtitleType.NoSubtitle:
						ret = " -noautosub";
						break;
					case SubtitleType.Ass:
					case SubtitleType.Srt:
                        ret = string.Format(" -sub \"{0}\"", SubManager.GetTempSubPath(fname));
						break;

					case SubtitleType.VobSubID:
                        fname = Path.GetDirectoryName(fname) + @"\" + Path.GetFileNameWithoutExtension(fname);
                        ret = " -vobsub \"" + fname + "\"";
						ret += " -vobsubid " + this.SubID;
						break;

					case SubtitleType.VobSubFile:
                        fname = Path.GetDirectoryName(fname) + @"\" + Path.GetFileNameWithoutExtension(fname);
						ret = " -vobsub \"" + fname + "\"";
						break;

					case SubtitleType.DemuxSubID:
						ret = " -sid " + this.SubID;
						break;
				}			

				return ret;
			}
		}

        public string getSlaveCommand()
        {
            switch(SubType)
            {
                case SubtitleType.NoSubtitle:
                case SubtitleType.DemuxSubID:
                case SubtitleType.VobSubID:
                    return string.Format("sub_select {0}", SubID);

                default:
                    return null;
            }
        }

	}
}
