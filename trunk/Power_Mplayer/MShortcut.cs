using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Power_Mplayer
{
	public class MShortcut
	{
		public string Key;
		public string Cmd;
		public string Comment;

		public static Dictionary<string, MShortcut> LoadShortcuts(string fname)
		{
            Dictionary<string, MShortcut> mapping = new Dictionary<string, MShortcut>();

			if(!File.Exists(fname))
			{
				return null;
			}

			using(TextReader tr = new StreamReader(fname))
			{
				string str;
				while((str = tr.ReadLine()) != null)
				{
					str = str.TrimStart(' ', '\t');
					if(str == "" || str[0] == '#' )
						continue;

					MShortcut sc = new MShortcut();

					int space_index =  str.IndexOf(' ');
					int comment_index = str.IndexOf('#');

					sc.Key = str.Substring(0, str.IndexOf(' '));

					if(comment_index > 0)
					{
						sc.Cmd = str.Substring(space_index, comment_index-space_index);
						sc.Comment = str.Substring(comment_index);
					}
					else
					{
						// comment not exist
						sc.Cmd = str.Substring(space_index);
						sc.Comment = null;
					}

					sc.Cmd = sc.Cmd.TrimStart(' ', '\t').TrimEnd(' ', '\t');

                    try
                    {
                        mapping.Add(sc.Key, sc);
                    }
                    catch
                    {
                        // Key repeat 
                    }
				}
			}

			return mapping;
		}

        public static string GetShortcutPath(string mplayerPath)
        {
            if (mplayerPath.IndexOf(Path.VolumeSeparatorChar) < 0)
            {
                mplayerPath = System.Windows.Forms.Application.StartupPath + @"\" + mplayerPath;
            }
            mplayerPath = Path.GetDirectoryName(mplayerPath) + @"\mplayer\input.conf";

            return mplayerPath;
        }
	}
}
