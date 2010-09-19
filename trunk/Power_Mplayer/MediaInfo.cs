using System;
using System.Collections;
using System.Collections.Generic;

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

        public int ToInt()
        {
            return int.Parse((string)Value);
        }

        public double ToDouble()
        {
            return double.Parse((string)Value);
        }
	}

	/// <summary>
	/// MplayerState ªººK­n´y­z¡C
	/// </summary>
	public class MediaInfo
	{
		private List<MValue> MValues;
		private Mplayer mp;
        public List<int> AudioChannel;
        public List<int> VideoChannel;

		// constructure
		public MediaInfo(Mplayer m)
		{
			MValues = new List<MValue>();
			mp = m;

            AudioChannel = new List<int>();
            VideoChannel = new List<int>();

			CreateValues();
		}

		// create values that used in mplayer
		private void CreateValues()
		{
			MValues.Add(new MValue("FILENAME",		TypeCode.String));
			MValues.Add(new MValue("LENGTH",		TypeCode.Double));
			MValues.Add(new MValue("DEMUXER",		TypeCode.String));
			MValues.Add(new MValue("SEEKABLE",		TypeCode.Int32));

			// Audio

//			MValues.Add(new MValue("AUDIO_ID",		TypeCode.Int32));
            AudioChannel.Clear();
			MValues.Add(new MValue("AUDIO_BITRATE", TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_RATE",	TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_NCH",		TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_FORMAT",	TypeCode.String));
			MValues.Add(new MValue("AUDIO_CODEC",	TypeCode.String));

			// Video

//			MValues.Add(new MValue("VIDEO_ID",		TypeCode.Int32));
            VideoChannel.Clear();
			MValues.Add(new MValue("VIDEO_FORMAT",	TypeCode.String));
			MValues.Add(new MValue("VIDEO_BITRATE",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_WIDTH",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_HEIGHT",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_FPS",		TypeCode.Double));
			MValues.Add(new MValue("VIDEO_ASPECT",	TypeCode.Double));
			MValues.Add(new MValue("VIDEO_CODEC",	TypeCode.String));

			// Palyer State

			MValues.Add(new MValue("TIME_POSITION",		TypeCode.Double));
			MValues.Add(new MValue("PERCENT_POSITION",	TypeCode.Int32));

			// Subtitle

//			MValues.Add(new MValue("FILE_SUB_ID",		TypeCode.Int32));
//			MValues.Add(new MValue("FILE_SUB_FILENAME",	TypeCode.String));
		}

        public void ClearValues()
        {
            MValues.Clear();
            this.CreateValues();
        }

		private string isStateString(string str)
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
				if(str.StartsWith("VSID"))
				{
					Subtitle.AddVobSub(mp.SubList, mp.CurrentSubtitle.Filename, str);
					return;
				}
				else if(str.StartsWith("SID"))
				{
					Subtitle.AddDemuxSub(mp.SubList, mp.Filename, str);
					return;
				}

				string[] cmds = str.Split('=');

                if (cmds[0].StartsWith("AUDIO_ID"))
                {
                    this.AudioChannel.Add(int.Parse(cmds[1]));
                }
                else if(cmds[0].StartsWith("VIDEO_ID"))
                {
                    this.VideoChannel.Add(int.Parse(cmds[1]));
                }

				foreach(MValue val in MValues)
				{
					if(cmds[0] == val.Name)
					{
						val.SetValue(cmds[1]);
						break;
					}
				}
			}
			// end of if
		}

		public Object this[string dataname]
		{
			get
			{
				foreach(MValue val in MValues)
				{
					if(val.Name == dataname)
						return val.Value;
				}

				return null;
			}
		}
	}
}
