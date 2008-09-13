using System;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	public enum SubtitleType {NoSubtitle, Srt, Ass, VobSub};

	public class Subtitle
	{
		public SubtitleType SubType;
		public string Filename;
		public string Name;

		public Subtitle(string filename)
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
					this.SubType = SubtitleType.VobSub;
					break;
				case ".ass":
					this.SubType = SubtitleType.Ass;
					break;
			}
		}

		public Subtitle(SubtitleType type)
		{
			this.Filename = "";
			this.SubType = type;

			switch(type)
			{
				case SubtitleType.NoSubtitle:
					this.Name = "µL¦r¹õ";
					break;
				default:
					this.Name = "";
					break;
			}
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
					case SubtitleType.VobSub:
						ret = " -vobsub \"" + Path.GetFileNameWithoutExtension(this.Filename) + "\"";
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
			sublist.Add(new Subtitle(SubtitleType.NoSubtitle));

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
	}
}
