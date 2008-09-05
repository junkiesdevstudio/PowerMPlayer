using System;
using System.Collections;

namespace Power_Mplayer
{
	public struct MValue
	{
		private string NAME;
		public Object Value;
		private System.TypeCode VType;

		public string Name
		{
			get { return NAME; }
		}

		public TypeCode ValueType
		{
			get { return VType; }
		}

		public MValue(string name, TypeCode code)
		{
			NAME = name;
			Value = null;
			VType = code;
		}

		public void SetValue(string val)
		{
			switch(this.ValueType)
			{
				case TypeCode.Double:
					Value = double.Parse(val);
					break;
				case TypeCode.String:
					Value = val;
					break;
				case TypeCode.Int32:
					Value = Int32.Parse(val);
					break;
			}
		}
	}

	/// <summary>
	/// MplayerState 的摘要描述。
	/// </summary>
	public class MplayerState
	{
		ArrayList MValues;

		public MplayerState()
		{
			//
			// TODO: 在此加入建構函式的程式碼
			//
			MValues = new ArrayList();

			CreateValues();
		}

		private void CreateValues()
		{
			MValues.Add(new MValue("FILENAME",		TypeCode.String));
			MValues.Add(new MValue("LENGTH",		TypeCode.Double));

			// Audio

			MValues.Add(new MValue("AUDIO_ID",		TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_BITRATE", TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_RATE",	TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_NCH",		TypeCode.Int32));
			MValues.Add(new MValue("AUDIO_FORMAT",	TypeCode.String));

			// Video

			MValues.Add(new MValue("VIDEO_ID",		TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_FORMAT",	TypeCode.String));
			MValues.Add(new MValue("VIDEO_BITRATE",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_WIDTH",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_HEIGHT",	TypeCode.Int32));
			MValues.Add(new MValue("VIDEO_FPS",		TypeCode.Double));
			MValues.Add(new MValue("VIDEO_ASPECT",	TypeCode.Double));
		}

		private string isStateString(string str)
		{
			if(str.StartsWith("ID_"))
				return str.Substring(3);
			else if(str.StartsWith("ANS_"))
				return str.Substring(4);
			else 
				return null;
		}

		public void SetState(string str)
		{
			str = isStateString(str);

			if(str != null)
			{
				//System.Windows.Forms.MessageBox.Show(str);
				string[] cmds = str.Split('=');

				foreach(MValue val in MValues)
				{
					if(cmds[0].Equals(val.Name))
					{
						val.SetValue(cmds[1]);
						break;
					}
				}
			}
			// end of if
		}
	}
}
