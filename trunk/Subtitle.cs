using System;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	public enum SubtitleType {NoSubtitle, Srt, Ass, VobSubFile, VobSubID, DemuxSubID};

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
				this.Name = "�L�r��";
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
						this.Filename = Path.GetDirectoryName(filename) + @"\" + Path.GetFileNameWithoutExtension(filename);
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

				switch(this.SubType)
				{
					case SubtitleType.NoSubtitle:
						ret = " -noautosub";
						break;
					case SubtitleType.Ass:
					case SubtitleType.Srt:
						ret = " -sub \"" + this.Filename + "\"";
						break;

					case SubtitleType.VobSubID:
						ret = " -vobsub \"" + this.Filename + "\"";
						ret += " -vobsubid " + this.SubID;
						break;

					case SubtitleType.VobSubFile:
						ret = " -vobsub \"" + this.Filename + "\"";
						break;

					case SubtitleType.DemuxSubID:
						ret = " -sid " + this.SubID;
						break;
				}			

				return ret;
			}
		}

		/// <summary>Find all available subtitles</summary>
		/// <param name="filename">Media filename</param>
		/// <returns>Numbers of found subtitles.</returns>
		public static ArrayList FindSubtitle(string filename)
		{
			ArrayList sublist = new ArrayList();

			// add no subtitle			
			sublist.Add(new Subtitle(null));

			if(filename == null || !File.Exists(filename))
				return sublist;

			string subdir = Path.GetDirectoryName(filename);
			filename = Path.GetFileNameWithoutExtension(filename).ToLower();

			string[] files = System.IO.Directory.GetFiles(subdir);

			for(int i=0;i<files.Length;i++)
			{
				if(!Path.GetFileName(files[i]).ToLower().StartsWith(filename))
					continue;

				switch(Path.GetExtension(files[i]).ToLower())
				{
					case ".ass":
					case ".srt":
					case ".idx":
						sublist.Add(new Subtitle(files[i]));
						break;
				}
			}

			return sublist;
		}

		/// <summary>
		/// Add a Vobsub
		/// </summary>
		/// <param name="sublist">An ArrayList of Subtitle List</param>
		/// <param name="subfile">Vobsub Filename</param>
		/// <param name="str">Mplayer -identify ID_ string</param>
		/// <returns></returns>
		public static bool AddVobSub(ArrayList sublist, string subfile, string str)
		{
			if(!str.StartsWith("VSID_"))
				return false;

			string[] substr = str.Split('_', '=');
			
			int id = int.Parse(substr[1]);
			string lang = substr[3];

			sublist.Add(new Subtitle(subfile, id.ToString() + " : " + lang, id, SubtitleType.VobSubID));

			return true;
		}

		public static bool AddDemuxSub(ArrayList sublist, string subfile, string str)
		{
			if(!str.StartsWith("SID_"))
				return false;

			string[] substr = str.Split('_', '=');

			// SID_0_LANG=chi , no need
			if(substr[2] == "LANG")	
				return false;

			int id = int.Parse(substr[1]);
			string lang = substr[3];

			sublist.Add(new Subtitle(subfile, id.ToString() + " : " + lang, id, SubtitleType.DemuxSubID));

			return true;
		}
	}
}
