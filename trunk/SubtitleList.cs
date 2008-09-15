using System;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	public enum SubtitleType {NoSubtitle, Srt, Ass, VobSubFile, VobSubID};

	public class Subtitle
	{
		public SubtitleType SubType;
		public string Filename;
		public string Name;
		public int VobSubID;	// VobSubID only

		public Subtitle(string filename)
		{
			this.VobSubID = -1;

			if(filename == null)
			{
				this.Filename = "";
				this.SubType = SubtitleType.NoSubtitle;
				this.Name = "µL¦r¹õ";
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
			this.VobSubID = vobid;
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
						ret += " -vobsubid " + this.VobSubID;
						break;

					case SubtitleType.VobSubFile:
						ret = " -vobsub \"" + this.Filename + "\"";
						break;
				}			

				return ret;
			}
		}
	}

	/// <summary>
	/// SubtitleList Class
	/// </summary>
	public class SubtitleList
	{
		private ArrayList sublist;
		private string subdir;

		public int Count
		{
			get
			{
				return sublist.Count;
			}
		}

		public Subtitle this[int index]
		{
			get
			{
				return (Subtitle) sublist[index];
			}
		}

		// constructure
		public SubtitleList()
		{
			sublist = new ArrayList();
			subdir = "";
		}

		~SubtitleList()
		{
			sublist.Clear();
		}

		/// <summary>Find all available subtitles</summary>
		/// <param name="SubDir">Directory contain subtitles</param>
		/// <returns>Numbers of found subtitles.</returns>
		public int FindSubtitle(string SubDir)
		{
			if(!Directory.Exists(SubDir))
				return -1;

			subdir = SubDir;
			sublist.Clear();
			//sublist.Add(new Subtitle(SubtitleType.AutoDetect));
			sublist.Add(new Subtitle(null));

			string[] files = System.IO.Directory.GetFiles(subdir);

			for(int i=0;i<files.Length;i++)
			{
				string ext = Path.GetExtension(files[i]);

				switch(ext.ToLower())
				{
					case ".ass":
					case ".srt":
					case ".idx":
						sublist.Add(new Subtitle(files[i]));
						break;
				}
			}

			return sublist.Count;
		}

		public bool AddVobSub(string subfile, string str)
		{
			if(!str.StartsWith("VSID_"))
				return false;

			string[] substr = str.Split('_', '=');
			
			int id = int.Parse(substr[1]);
			string lang = substr[3];

			sublist.Add(new Subtitle(subfile, id.ToString() + " : " + lang, id, SubtitleType.VobSubID));

			return true;
		}
	}
}
