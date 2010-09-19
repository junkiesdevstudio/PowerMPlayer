using System;
using System.IO;
using System.Collections.Generic;

namespace Power_Mplayer
{
	/// <summary>
	/// MplayerSetting ªººK­n´y­z¡C
	/// </summary>
	/// 
	public enum SetVars 
	{
		// Power Mplayer Setting
		MplayerExe, SrtForceUTF8,
		
		//  subtitle
		SubFont, SubEncoding, SubAutoScale, SubASS, SubChineseTrans, SubFontTextScale,
		
		// Audio
		AO, Audio_Softvol, Audio_SoftvolMax,
		
		// Video
		VO, Video_DR, 

		// LastMedia
		LastMedia,

		//Language, will only be used in the .ini file
		Language
	}
	public class MplayerSetting
	{
		private string SettingFile = System.Windows.Forms.Application.StartupPath + @"\PowerMplayer.ini";

		private List<MValue> SettingValues;
		
		private void CreateDefaultValue()
		{
			this.SettingValues.Clear();

			// Power Mplayer Setting
			this.SettingValues.Add(new MValue(SetVars.MplayerExe.ToString(),	@".\mplayer.exe",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SrtForceUTF8.ToString(),	"1",			TypeCode.String));

			// subtitle
			this.SettingValues.Add(new MValue(SetVars.SubFont.ToString(),		@".\mplayer\subfont.ttf", TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubEncoding.ToString(),	"BIG5",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubAutoScale.ToString(),  "3",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubASS.ToString(),		"0",			TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.SubChineseTrans.ToString(), "0",          TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.SubFontTextScale.ToString(),"4",            TypeCode.String));

			// Audio
			this.SettingValues.Add(new MValue(SetVars.AO.ToString(),			"dsound",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_Softvol.ToString(),	"0",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_SoftvolMax.ToString(), "110",		TypeCode.String));

			// Video
			this.SettingValues.Add(new MValue(SetVars.VO.ToString(),			"direct3d",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Video_DR.ToString(),		"0",			TypeCode.String));

			// LastMedia
			this.SettingValues.Add(new MValue(SetVars.LastMedia.ToString(),		"",				TypeCode.String));

			//Language
			this.SettingValues.Add(new MValue(SetVars.Language.ToString(),		"",				TypeCode.String));
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

                args += " -vf screenshot,eq2";

				// using ass
				if(this[SetVars.SubASS] == "1")
					args += " -ass";

				// font
				args += " -font \"" + System.Environment.ExpandEnvironmentVariables(this[SetVars.SubFont]) + "\"";

                args += " -subfont-text-scale " + this[SetVars.SubFontTextScale];

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
			this.SettingValues = new List<MValue>();
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
			//if portable is defined in the begining of the file, it will be compiled to generate the .ini file, otherwise, it will use the .config file
#if portable
			#region portable
			using (TextWriter tw = new StreamWriter(this.SettingFile))
			{
				foreach (MValue val in SettingValues)
				{
					tw.WriteLine(val.Name + "=" + (string)val.Value);
				}

				tw.Close();
			}
			#endregion
#else
			#region local
			foreach (MValue val in SettingValues)
			{
				switch (val.Name)
				{
					//General
					case "MplayerExe":
						global::Power_Mplayer.Properties.Settings.Default.MplayerExe = val.Value.ToString();
						break;
					case "SrtForceUTF8":
						global::Power_Mplayer.Properties.Settings.Default.SrtForceUTF8 = val.Value.ToString();
						break;

					//Subtitle
					case "SubFont":
						global::Power_Mplayer.Properties.Settings.Default.SubFont = val.Value.ToString();
						break;
					case "SubEncoding":
						global::Power_Mplayer.Properties.Settings.Default.SubEncoding = val.Value.ToString();
						break;
					case "SubAutoScale":
						global::Power_Mplayer.Properties.Settings.Default.SubAutoScale = val.Value.ToString();
						break;
					case "SubASS":
						global::Power_Mplayer.Properties.Settings.Default.SubASS = val.Value.ToString();
						break;
					case "SubChineseTrans":
						global::Power_Mplayer.Properties.Settings.Default.SubChineseTrans = val.Value.ToString();
						break;
					case "SubFontTextScale":
						global::Power_Mplayer.Properties.Settings.Default.SubFontTextScale = val.Value.ToString();
						break;

					// Audio
					case "AO":
						global::Power_Mplayer.Properties.Settings.Default.AO = val.Value.ToString();
						break;
					case "Audio_Softvol":
						global::Power_Mplayer.Properties.Settings.Default.Audio_Softvol = val.Value.ToString();
						break;
					case "Audio_SoftvolMax":
						global::Power_Mplayer.Properties.Settings.Default.Audio_SoftvolMax = val.Value.ToString();
						break;

					// Video
					case "VO":
						global::Power_Mplayer.Properties.Settings.Default.VO = val.Value.ToString();
						break;
					case "Video_DR":
						global::Power_Mplayer.Properties.Settings.Default.Video_DR = val.Value.ToString();
						break;

					// Lastmedia
					case "LastMedia":
						global::Power_Mplayer.Properties.Settings.Default.LastMedia = val.Value.ToString();
						break;

					// Language
					case "Language":
					this.SettingValues.Add(new MValue(SetVars.Language.ToString(),
						global::Power_Mplayer.Properties.Settings.Default.Language, TypeCode.String));
					break;
				}
			}
			//Save the configuration
			global::Power_Mplayer.Properties.Settings.Default.Save();
			#endregion
#endif
		}

		public void ReadSetting()
		{
			//if portable is defined in the begining of the file, it will be compiled to generate the .ini file, otherwise, it will use the .config file
			#if (portable)
			#region portable
			CreateDefaultValue();

			if (!File.Exists(this.SettingFile))
			{
				this.WriteSetting();
				return;
			}

			using (TextReader tr = new StreamReader(this.SettingFile))
			{
				string str;
				while ((str = tr.ReadLine()) != null)
				{
					string[] cmds = str.Split('=');

					if (cmds[1] == "")
						continue;

					if (Enum.IsDefined(typeof(SetVars), cmds[0]))
					{
						SetVars sv = (SetVars)Enum.Parse(typeof(SetVars), cmds[0], true);
						this[sv] = cmds[1];
					}
				}

				tr.Close();
			}

			return;
			#endregion
			#else
			#region local
			//Clear all the seetings
			this.SettingValues.Clear();

			//Load the seetings
			// Power Mplayer Setting
			this.SettingValues.Add(new MValue(SetVars.MplayerExe.ToString(), 
				global::Power_Mplayer.Properties.Settings.Default.MplayerExe, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SrtForceUTF8.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SrtForceUTF8, TypeCode.String));

			// subtitle
			this.SettingValues.Add(new MValue(SetVars.SubFont.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubFont, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubEncoding.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubEncoding, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubAutoScale.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubAutoScale, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubASS.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubASS, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubChineseTrans.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubChineseTrans, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.SubFontTextScale.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.SubFontTextScale, TypeCode.String));

			// Audio
			this.SettingValues.Add(new MValue(SetVars.AO.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.AO, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_Softvol.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.Audio_Softvol, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_SoftvolMax.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.Audio_SoftvolMax, TypeCode.String));

			// Video
			this.SettingValues.Add(new MValue(SetVars.VO.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.VO, TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Video_DR.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.Video_DR, TypeCode.String));

			// LastMedia
			this.SettingValues.Add(new MValue(SetVars.LastMedia.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.LastMedia, TypeCode.String));

			// Language
			this.SettingValues.Add(new MValue(SetVars.Language.ToString(),
				global::Power_Mplayer.Properties.Settings.Default.Language, TypeCode.String));
			#endregion
			#endif
		}
	}
}
