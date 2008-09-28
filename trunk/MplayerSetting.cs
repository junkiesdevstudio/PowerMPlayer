using System;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	/// <summary>
	/// MplayerSetting 的摘要描述。
	/// </summary>
	/// 
	public enum SetVars 
	{
		// Power Mplayer Setting
		MplayerExe, SrtForceUTF8,
		
		//  subtitle
		SubFont, SubEncoding, SubAutoScale, SubASS, 
		
		// Audio
		AO, Audio_Softvol, Audio_SoftvolMax,
		
		// Video
		VO, Video_DR, 

		// 雜項
		LastMedia
	}
	public class MplayerSetting
	{
		private string SettingFile = System.Windows.Forms.Application.StartupPath + @"\PowerMplayer.ini";

		private ArrayList SettingValues;
		
		private void CreateDefaultValue()
		{
			this.SettingValues.Clear();

			// Power Mplayer Setting
			this.SettingValues.Add(new MValue(SetVars.MplayerExe.ToString(),	@".\mplayer.exe",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SrtForceUTF8.ToString(),	"0",			TypeCode.String));

			// subtitle
			this.SettingValues.Add(new MValue(SetVars.SubFont.ToString(),		@".\mplayer\subfont.ttf", TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubEncoding.ToString(),	"BIG5",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubAutoScale.ToString(), "3",				TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubASS.ToString(),		"0",			TypeCode.String));

			// Audio
			this.SettingValues.Add(new MValue(SetVars.AO.ToString(),			"dsound",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_Softvol.ToString(),	"0",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_SoftvolMax.ToString(), "110",		TypeCode.String));

			// Video
			this.SettingValues.Add(new MValue(SetVars.VO.ToString(),			"directx",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Video_DR.ToString(),		"0",			TypeCode.String));

			// 雜項
			this.SettingValues.Add(new MValue(SetVars.LastMedia.ToString(),		"",				TypeCode.String));
		}

		public string MplayerArguements
		{
			get
			{
				string args = "";

				ReadSetting();

				// Audio
				args += " -ao " + this[SetVars.AO];

				if(this[SetVars.Audio_Softvol] == "1")
					args += " -softvol -softvol-max " + this[SetVars.Audio_SoftvolMax];

				// Video
				args += " -vo " + this[SetVars.VO];

				if(this[SetVars.Video_DR] == "1")
					args += " -dr";

				// using ass
				if(this[SetVars.SubASS] == "1")
					args += " -ass";

				// font
				args += " -font \"" + System.Environment.ExpandEnvironmentVariables(this[SetVars.SubFont]) + "\"";
				
				// subencoding				
				if(this[SetVars.SrtForceUTF8] == "1")
					args += " -utf8";
				else
					args += " -subcp " + this[SetVars.SubEncoding];

				// sub autoscale
				args += " -subfont-autoscale " + this[SetVars.SubAutoScale];

				return args;
			}
		}

		public MplayerSetting()
		{
			this.SettingValues = new ArrayList();
			this.ReadSetting();
		}

		public string this[SetVars sv]
		{
			get
			{
				foreach(MValue val in SettingValues)
				{
					if(val.Name == sv.ToString())
						return (string) val.Value;
				}

				return null;
			}
			set
			{
				foreach(MValue val in SettingValues)
				{
					if(val.Name == sv.ToString())
					{
						val.SetValue(value);
						return;
					}
				}

				/* add new vars
				MValue newval = new MValue(sv.ToString(), value, TypeCode.String);
				this.SettingValues.Add(newval);
				*/
				
				return;
			}
		}

		public void WriteSetting()
		{
			using(TextWriter tw = new StreamWriter(this.SettingFile))
			{
				foreach(MValue val in SettingValues)
				{
					tw.WriteLine(val.Name + "=" + (string) val.Value);
				}

				tw.Close();
			}
		}

		public void ReadSetting()
		{
			CreateDefaultValue();

			if(!File.Exists(this.SettingFile))
			{
				this.WriteSetting();
				return;
			}

			using(TextReader tr = new StreamReader(this.SettingFile))
			{
				string str;
				while((str = tr.ReadLine()) != null)
				{
					string[] cmds = str.Split('=');

					if(cmds[1] == "")
						continue;

					if(Enum.IsDefined(typeof(SetVars), cmds[0]))
					{
						SetVars sv = (SetVars) Enum.Parse(typeof(SetVars), cmds[0], true);
						this[sv] = cmds[1];
					}
				}

				tr.Close();
			}

			return ;
		}
	}
}
