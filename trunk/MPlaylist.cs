using System;
using System.Collections;

namespace Power_Mplayer
{
	/// <summary>
	/// MPlaylist ªººK­n´y­z¡C
	/// </summary>
	public class MPlaylist : ArrayList
	{
		public int NowIndex = 0;

		public MPlaylist() : base()
		{
		}

		public string First()
		{
			NowIndex = 0;
			if(this.Count > 0)
			{
				return (string) this[NowIndex];
			}

			return null;
		}

		public string GetFilename(int index)
		{
			NowIndex = index;

			if(NowIndex > this.Count)
				NowIndex = this.Count;
			else if(NowIndex < 0)
				NowIndex = 0;

			if(this.Count > 0)
			{
				return (string) this[NowIndex];
			}
			
			return null;
		}

		public string Current()
		{
			if(this.Count > 0)
			{
				return (string) this[NowIndex];
			}

			return null;
		}

		public string Next()
		{
			if(NowIndex < this.Count-1)
			{
				return (string) this[++NowIndex];
			}

			return null;
		}
	}
}
