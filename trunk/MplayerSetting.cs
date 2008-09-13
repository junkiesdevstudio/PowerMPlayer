using System;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	/// <summary>
	/// MplayerSetting ªººK­n´y­z¡C
	/// </summary>
	public class MplayerSetting
	{
		public const string SUB_FONT =		"SubFont";
		public const string SUB_ENCODING =	"SubEncoding";
		public const string SUB_AUTOSCALE = "SubAutoScale";
		public const string MPLAYER_EXE =	"MplayerExe";
		public const string SUB_ASS =		"SubASS";

		private ArrayList SettingValues;
 
		private string SettingFile = System.Environment.CurrentDirectory + @"\PowerMplayer.ini";

		public string MplayerArguements
		{
			get
			{
				string args = "";

				ReadSetting();

				if(this.HasProperty(SUB_ASS) && this[SUB_ASS] == "1")
					args += " -ass";

				if(this.HasProperty(SUB_FONT))
					args += " -font \"" + System.Environment.ExpandEnvironmentVariables(this[SUB_FONT]) + "\"";

				if(this.HasProperty(SUB_ENCODING))
					args += " -subcp " + this[SUB_ENCODING];

				if(this.HasProperty(SUB_AUTOSCALE))
					args += " -subfont-autoscale " + this[SUB_AUTOSCALE];

				return args;
			}
		}

		public MplayerSetting()
		{
			this.SettingValues = new ArrayList();

			this.ReadSetting();
		}

		private bool HasProperty(string property)
		{
			if(this[SUB_FONT] != null && this[SUB_FONT] != "")
				return true;
			return false;
		}

		public string this[string VarName]
		{
			get
			{
				foreach(MValue val in SettingValues)
				{
					if(val.Name == VarName)
						return (string) val.Value;
				}

				return null;
			}
			set
			{
				foreach(MValue val in SettingValues)
				{
					if(val.Name == VarName)
					{
						val.SetValue(value);
						return;
					}
				}

				MValue newval = new MValue(VarName, TypeCode.String);
				newval.SetValue(value);

				this.SettingValues.Add(newval);

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
			if(!File.Exists(this.SettingFile))
				return;
		
			this.SettingValues.Clear();

			using(TextReader tr = new StreamReader(this.SettingFile))
			{
				string str;
				while((str = tr.ReadLine()) != null)
				{
					string[] cmds = str.Split('=');

					this[cmds[0]] = cmds[1];
				}

				tr.Close();
			}

			return ;
		}
	}
}
