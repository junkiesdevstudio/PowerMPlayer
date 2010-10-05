using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace Power_Mplayer
{
	public class MValue
	{
		public Object Value;
		public string Name { get; private set;}
		public TypeCode ValueType { get; private set;}

		public MValue(string name, TypeCode code)
		{
			Name = name;
			ValueType = code;

			switch(code)
			{
				case TypeCode.Int32:
					Value = 0;
					break;
				case TypeCode.Double:
					Value = 0.0;
					break;
				default:
				case TypeCode.String:
					Value = null;
					break;
			}
		}

		public MValue(string name, Object val, TypeCode code) : this(name, code)
		{
			Value = val;
		}

		public void SetValue(string val)
		{
			switch(this.ValueType)
			{
				case TypeCode.Int32:
					Value = Int32.Parse(val);
					break;
				case TypeCode.Double:
					Value = double.Parse(val);
					break;

				default:
				case TypeCode.String:
					Value = val;
					break;
			}
		}
	}

	/// <summary>
	/// MplayerState ªººK­n´y­z¡C
	/// </summary>
	public class MediaInfo
	{       
		//private Mplayer mp;
        private Dictionary<string, string> MInfo;
        public List<int> AudioChannel {get; private set;}
        public List<int> VideoChannel {get; private set;}
//        public List<Subtitle> SubList { get; private set; }
        public SubManager SubMgr { get; private set; }

		// constructure
		public MediaInfo(Mplayer m)
		{
            MInfo = new Dictionary<string, string>();
			//mp = m;

            AudioChannel = new List<int>();
            VideoChannel = new List<int>();
            SubMgr = new SubManager();
		}

        public void ClearValues()
        {
            MInfo.Clear();
        }

		public static string isStateString(string str)
		{
			if(str == null)
				return null;

			if(str.StartsWith("ID_"))
				return str.Substring(3);
			else if(str.StartsWith("ANS_"))
				return str.Substring(4);
			else 
				return null;
		}

        // EventHandler of Mplayer.stdout
		public void SetState(MyStreamReader sender, string str)
		{
			str = isStateString(str);

			if(str != null)
			{
                SubMgr.AddSub(str);

				string[] cmds = str.Split('=');

                if (cmds[0].StartsWith("AUDIO_ID"))
                {
                    this.AudioChannel.Add(int.Parse(cmds[1]));
                }
                else if(cmds[0].StartsWith("VIDEO_ID"))
                {
                    this.VideoChannel.Add(int.Parse(cmds[1]));
                }

                MInfo[cmds[0]] = cmds[1];
			}
			// end of if
		}

		public string this[string dataname]
		{
			get
			{
                try
                {
                    string s = MInfo[dataname];
                    return s;
                }
                catch
                {
                    return null;
                }               
			}
		}

        public int ToInt32(string IndexName)
        {
            int ret;
            string s = this[IndexName];

            if (s != null && int.TryParse(s, out ret) == true)
                return ret;

            return 0;
        }

        public double ToDouble(string IndexName)
        {
            double ret;
            string s = this[IndexName];

            if (s != null && double.TryParse(s, out ret) == true)
                return ret;

            return 0;
        }

	}
}
