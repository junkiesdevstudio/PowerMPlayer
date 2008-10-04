using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace Power_Mplayer
{
	public class MShortcuts
	{
		public string Key;
		public string Cmd;
		public string Comment;

		public static ArrayList LoadShortcuts(string fname)
		{
			ArrayList mapping = new ArrayList();

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

					MShortcuts sc = new MShortcuts();

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
					
					mapping.Add(sc);
				}
			}

			return mapping;
		}

		public static void SaveShortcuts(string fname)
		{
			using(TextWriter tw = new StreamWriter(fname))
			{
				
			}
		}
	}
}
