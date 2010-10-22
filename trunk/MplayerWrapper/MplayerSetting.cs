using System;
using System.IO;
using System.Collections.Generic;

namespace MplayerWrapper
{
	/// <summary>
	/// MplayerSetting ªººK­n´y­z¡C
	/// </summary>
	/// 
	public enum SetVars 
	{
		// Power Mplayer Setting
		MplayerExe, MplayerOtherArgs,
		
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
		
		public void CreateDefaultValue()
		{
			this.SettingValues.Clear();

			// Power Mplayer Setting
			this.SettingValues.Add(new MValue(SetVars.MplayerExe.ToString(),	@".\mplayer.exe",		TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.MplayerOtherArgs.ToString(), "-vf screenshot,eq2", TypeCode.String));

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

                // using ass
				if(this[SetVars.SubASS] == "1")
					args += " -ass";

				// font
				args += " -font \"" + System.Environment.ExpandEnvironmentVariables(this[SetVars.SubFont]) + "\"";

                args += " -subfont-text-scale " + this[SetVars.SubFontTextScale];

				// sub autoscale
				args += " -subfont-autoscale " + this[SetVars.SubAutoScale];

                // append user specify args
                args += " " + this[SetVars.MplayerOtherArgs];

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

				return;
			}
		}

		public void WriteSetting()
		{
			//if portable is defined in the begining of the file, it will be compiled to generate the .ini file, otherwise, it will use the .config file

            using (TextWriter tw = new StreamWriter(this.SettingFile))
			{
				foreach (MValue val in SettingValues)
				{
					tw.WriteLine(val.Name + "=" + (string)val.Value);
				}

				tw.Close();
			}

		}

		public void ReadSetting()
		{
			//if portable is defined in the begining of the file, it will be compiled to generate the .ini file, otherwise, it will use the .config file

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
		}
	}
}
