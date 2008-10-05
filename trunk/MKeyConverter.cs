using System;
using System.Collections;
using System.Windows.Forms;

namespace Power_Mplayer
{
	public struct MKey
	{
		public string KeyName;
		public int KeyValue;

		public MKey(string name, int val)
		{
			KeyName = name;
			KeyValue = val;
		}
	}

	// TODO: Find Better Method...
	public class MKeyConverter
	{
		private ArrayList map;

		public MKeyConverter()
		{
			map = new ArrayList();

			map.Add(new MKey("None", (int) Keys.None));

			for(Keys k = Keys.A ; k <= Keys.Z ; k++)
			{
				map.Add(new MKey(k.ToString().ToLower(), (int) k));
				map.Add(new MKey(k.ToString().ToUpper(), (int) k | (int) Keys.Shift));
			}

			for(Keys k = Keys.F1 ; k <= Keys.F24 ; k++)
			{
				map.Add(new MKey(k.ToString(), (int) k));
			}

			for(Keys k=Keys.D0; k<= Keys.D9 ; k++)
			{
				map.Add(new MKey(k.ToString()[1].ToString(), (int) k));
			}

			map.Add(new MKey("SPACE", (int) Keys.Space));
			map.Add(new MKey("BS", (int) Keys.Back));
			map.Add(new MKey("ENTER", (int) Keys.Enter));
			map.Add(new MKey("UP", (int) Keys.Up));
			map.Add(new MKey("DOWN", (int) Keys.Down));
			map.Add(new MKey("LEFT" ,(int) Keys.Left));
			map.Add(new MKey("RIGHT" ,(int) Keys.Right));
			map.Add(new MKey("HOME" ,(int) Keys.Home));
			map.Add(new MKey("END" ,(int) Keys.End));
			map.Add(new MKey("INS" ,(int) Keys.Insert));
			map.Add(new MKey("DEL" ,(int) Keys.Delete));
			map.Add(new MKey("PGUP" ,(int) Keys.PageUp));
			map.Add(new MKey("PGDWN" ,(int) Keys.PageDown));

			map.Add(new MKey("," ,(int) Keys.Oemcomma));
			map.Add(new MKey("<", (int) Keys.Oemcomma | (int) Keys.Shift));
			map.Add(new MKey("." ,(int) Keys.OemPeriod));
			map.Add(new MKey(">" ,(int) Keys.OemPeriod | (int) Keys.Shift));
			map.Add(new MKey("-" ,(int) Keys.OemMinus));
			map.Add(new MKey("_" ,(int) Keys.OemMinus | (int) Keys.Shift));
			map.Add(new MKey("=" ,(int) Keys.Oemplus));
			map.Add(new MKey("+" ,(int) Keys.Oemplus | (int) Keys.Shift));
			map.Add(new MKey("/" ,(int) Keys.OemQuestion));
			map.Add(new MKey("?" ,(int) Keys.OemQuestion | (int) Keys.Shift));
			map.Add(new MKey(";" ,(int) Keys.OemSemicolon));
			map.Add(new MKey(":" ,(int) Keys.OemSemicolon | (int) Keys.Shift));
			map.Add(new MKey("'" ,(int) Keys.OemQuotes));
			map.Add(new MKey("\"" ,(int) Keys.OemQuotes | (int) Keys.Shift));
			map.Add(new MKey("\\" ,(int) Keys.OemPipe));
			map.Add(new MKey("|" ,(int) Keys.OemPipe | (int) Keys.Shift));
			map.Add(new MKey("[" , (int) Keys.OemOpenBrackets));
			map.Add(new MKey("{" , (int) Keys.OemOpenBrackets | (int) Keys.Shift));
			map.Add(new MKey("]", (int) Keys.OemCloseBrackets));
			map.Add(new MKey("}", (int) Keys.OemCloseBrackets | (int) Keys.Shift));

			map.Add(new MKey("(", (int) Keys.D9 | (int) Keys.Shift));
			map.Add(new MKey(")", (int) Keys.D0 | (int) Keys.Shift));
		}

		public string getKeyName(int key)
		{
			foreach(MKey k in map)
			{
				if(k.KeyValue == key)
				{
					return k.KeyName;
				}
			}

			return ((MKey) map[0]).KeyName;
		}

		public int getKeyValue(string key)
		{
			foreach(MKey k in map)
			{
				if(k.KeyName == key)
				{
					return k.KeyValue;
				}
			}

			return ((MKey) map[0]).KeyValue;
		}
	}
}
