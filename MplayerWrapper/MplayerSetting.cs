using System;
using System.IO;
using System.Collections.Generic;

namespace MplayerWrapper
{
	/// <summary>
	/// MplayerSetting ���K�n�y�z�C
	/// </summary>
	/// 
	public enum SetVars 
	{
		// Power Mplayer Setting
		MplayerExe, MplayerOtherArgs,
		
		//  subtitle
		SubFont, SubEncoding, SubAutoScale, SubASS, SubChineseTrans, SubFontTextScale,
		
		// Audio
		AO, AC, AFM, dsoundDevice, Audio_Softvol, Audio_SoftvolMax, Audio_Volume, 
        Audio_Volume_Val, Audio_Volume_Smooth, 
        Audio_Filter_Karaoke, Audio_Filter_Volnorm, Audio_Filter_VolnormMethod,
		
		// Video
		VO, VC, VFM, Video_DR, Video_DoubleBuffering, Video_Slices, 
        Video_Filter_pp, Video_Filter_ppQuality,

		// LastMedia
		LastMedia,

		//Language, will only be used in the .ini file
		Language,

        // -forceidx , Force index rebuilding. 
        ForceIDX
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
            this.SettingValues.Add(new MValue(SetVars.dsoundDevice.ToString(),  "0",            TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_Softvol.ToString(),	"0",			TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Audio_SoftvolMax.ToString(), "110",		TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Volume.ToString(),  "0",            TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Volume_Val.ToString(), "-1",        TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Volume_Smooth.ToString(), "0",      TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.AFM.ToString(),           "",             TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.AC.ToString(),            "",             TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Filter_Karaoke.ToString(), "0",     TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Filter_Volnorm.ToString(), "0",     TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Audio_Filter_VolnormMethod.ToString(), "1", TypeCode.String));

			// Video
			this.SettingValues.Add(new MValue(SetVars.VO.ToString(),			"direct3d",		TypeCode.String));
			this.SettingValues.Add(new MValue(SetVars.Video_DR.ToString(),		"0",			TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.VFM.ToString(),           "",             TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.VC.ToString(),            "",             TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Video_DoubleBuffering.ToString(), "0",    TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Video_Slices.ToString(), "1",             TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Video_Filter_pp.ToString(), "0",          TypeCode.String));
            this.SettingValues.Add(new MValue(SetVars.Video_Filter_ppQuality.ToString(), "6",   TypeCode.String));

			// LastMedia
			this.SettingValues.Add(new MValue(SetVars.LastMedia.ToString(),		"",				TypeCode.String));

			//Language
			this.SettingValues.Add(new MValue(SetVars.Language.ToString(),		"",				TypeCode.String));

            //ForceIDX
            this.SettingValues.Add(new MValue(SetVars.ForceIDX.ToString(),      "0",            TypeCode.String));
		}

		public string MplayerArguements
		{
			get
			{
                List<string> AudioFilters = new List<string>();
                string args = "";

				ReadSetting();

				// Audio
                if (this[SetVars.AO].ToLower() == "dsound")
                    args += string.Format(" -ao dsound:device={0}", this[SetVars.dsoundDevice]);
                else
                    args += string.Format(" -ao {0}", this[SetVars.AO]);

                if(this[SetVars.AC] != "")
                    args += string.Format(" -ac {0}", this[SetVars.AC]);

                if (this[SetVars.AFM] != "")
                    args += string.Format(" -afm {0}", this[SetVars.AFM]);

				if(this[SetVars.Audio_Softvol] == "1")
					args += " -softvol -softvol-max " + this[SetVars.Audio_SoftvolMax];

                if (this[SetVars.Audio_Volume] == "1")
                    AudioFilters.Add(string.Format("volume={0}:{1}", this[SetVars.Audio_Volume_Val], this[SetVars.Audio_Volume_Smooth]));

                if (this[SetVars.Audio_Filter_Karaoke] == "1")
                    AudioFilters.Add("karaoke");

                if(this[SetVars.Audio_Filter_Volnorm] == "1")
                    AudioFilters.Add(string.Format("volnorm={0}", this[SetVars.Audio_Filter_VolnormMethod]));

                if (AudioFilters.Count > 0)
                {
                    args += " -af ";
                    for(int i=0;i<AudioFilters.Count;i++)
                    {
                        args += AudioFilters[i];

                        if (i + 1 < AudioFilters.Count)
                            args += ",";
                    }
                }

				// Video
				args += " -vo " + this[SetVars.VO];

                if (this[SetVars.VC] != "")
                    args += string.Format(" -vc {0}", this[SetVars.VC]);

                if (this[SetVars.VFM] != "")
                    args += string.Format(" -vfm {0}", this[SetVars.VFM]);

                args += (this[SetVars.Video_DR] == "1") ? " -dr" : " -nodr";

                if (this[SetVars.Video_DoubleBuffering] == "1")
                    args += " -double";

                args += (this[SetVars.Video_Slices] == "1") ? " -slices" : " -noslices";

                // using ass
				if(this[SetVars.SubASS] == "1")
					args += " -ass";

				// font
				args += " -font \"" + System.Environment.ExpandEnvironmentVariables(this[SetVars.SubFont]) + "\"";

                args += " -subfont-text-scale " + this[SetVars.SubFontTextScale];

				// sub autoscale
				args += " -subfont-autoscale " + this[SetVars.SubAutoScale];

                if (this[SetVars.ForceIDX] == "1")
                    args += " -forceidx";

                // append user specify args
                args += " " + this[SetVars.MplayerOtherArgs];

                // video filters
                if (this[SetVars.Video_Filter_pp] == "1")
                    args += string.Format(" -vf-pre pp -autoq {0}", this[SetVars.Video_Filter_ppQuality]);

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
                string[] cmds = new string[2];

				while ((str = tr.ReadLine()) != null)
				{
                    int pos = str.IndexOf('=');

                    cmds[0] = str.Substring(0, pos);
                    cmds[1] = (pos < str.Length) ? str.Substring(pos+1) : "";

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
