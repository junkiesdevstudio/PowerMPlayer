﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

namespace Power_Mplayer
{
	/// <summary>
	/// OptionForm ªººK­n´y­z¡C
	/// </summary>
	public class OptionForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tp_general;
		private System.Windows.Forms.TabPage tp_Subtitle;
		private System.Windows.Forms.TabPage tp_audio;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txt_mplayer_cmd;
		private System.Windows.Forms.Button btn_close;
		/// <summary>
		/// ³]­p¤u¨ã©Ò»ÝªºÅÜ¼Æ¡C
		/// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button btn_cancel;
        private GroupBox groupBox1;
        private CheckBox Srt_ForceUTF8;
        private CheckBox Srt_UseASS;
        private Label label5;
        private ComboBox Srt_AutoScale;
        private GroupBox groupBox4;
        private Label label6;
        private TextBox Srt_Font;
        private Button btn_BroseFont;
        private NumericUpDown Srt_SubFontTextScale;
        private Label label7;

		private MplayerSetting msetting;
        private CheckedListBox clb_FileAssociate;
        private Button btn_SelectAllExt;
        private Label label8;
        private ComboBox Srt_ChineseTrans;
        private TabPage tp_Output;
        private GroupBox groupBox2;
        private CheckBox Video_DirectRandering;
        private ComboBox Video_Output;
        private Label label2;
        private GroupBox groupBox3;
        private NumericUpDown Audio_Softvol_max;
        private Label label4;
        private CheckBox Audio_Softvol;
        private ComboBox Audio_Output;
        private Label label3;
		private TabPage tabPage1;
		private ComboBox chkLanguage;
		private Label label9;
        private FontSelector fontSelect;

		private CultureInfo culture;
		private ResourceManager rm;

		// constructure
		public OptionForm(MplayerSetting ms)
		{
			InitializeComponent();

			this.msetting = ms;
            this.fontSelect = null;
            
            GetAssociatedExt();

			//get the current culture(language)
			culture = CultureInfo.CurrentUICulture;
			rm = new ResourceManager("Power_Mplayer.Strings.OptionForm", typeof(OptionForm).Assembly);
			
		}

		/// <summary>
		/// ²M°£¥ô¦ó¨Ï¥Î¤¤ªº¸ê·½¡C
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form ³]­p¤u¨ã²£¥Íªºµ{¦¡½X
		/// <summary>
		/// ¦¹¬°³]­p¤u¨ã¤ä´©©Ò¥²¶·ªº¤èªk - ½Ð¤Å¨Ï¥Îµ{¦¡½X½s¿è¾¹­×§ï
		/// ³o­Ó¤èªkªº¤º®e¡C
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tp_general = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_mplayer_cmd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.tp_Output = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Audio_Softvol_max = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.Audio_Softvol = new System.Windows.Forms.CheckBox();
			this.Audio_Output = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Video_DirectRandering = new System.Windows.Forms.CheckBox();
			this.Video_Output = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tp_Subtitle = new System.Windows.Forms.TabPage();
			this.Srt_ChineseTrans = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.Srt_SubFontTextScale = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.btn_BroseFont = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.Srt_Font = new System.Windows.Forms.TextBox();
			this.Srt_AutoScale = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.Srt_UseASS = new System.Windows.Forms.CheckBox();
			this.Srt_ForceUTF8 = new System.Windows.Forms.CheckBox();
			this.tp_audio = new System.Windows.Forms.TabPage();
			this.btn_SelectAllExt = new System.Windows.Forms.Button();
			this.clb_FileAssociate = new System.Windows.Forms.CheckedListBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.chkLanguage = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btn_close = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tp_general.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tp_Output.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tp_Subtitle.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Srt_SubFontTextScale)).BeginInit();
			this.tp_audio.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.AccessibleDescription = null;
			this.tabControl1.AccessibleName = null;
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.BackgroundImage = null;
			this.tabControl1.Controls.Add(this.tp_general);
			this.tabControl1.Controls.Add(this.tp_Output);
			this.tabControl1.Controls.Add(this.tp_Subtitle);
			this.tabControl1.Controls.Add(this.tp_audio);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Font = null;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tp_general
			// 
			this.tp_general.AccessibleDescription = null;
			this.tp_general.AccessibleName = null;
			resources.ApplyResources(this.tp_general, "tp_general");
			this.tp_general.BackgroundImage = null;
			this.tp_general.Controls.Add(this.groupBox1);
			this.tp_general.Font = null;
			this.tp_general.Name = "tp_general";
			this.tp_general.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = null;
			this.groupBox1.AccessibleName = null;
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.BackgroundImage = null;
			this.groupBox1.Controls.Add(this.txt_mplayer_cmd);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Font = null;
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// txt_mplayer_cmd
			// 
			this.txt_mplayer_cmd.AccessibleDescription = null;
			this.txt_mplayer_cmd.AccessibleName = null;
			resources.ApplyResources(this.txt_mplayer_cmd, "txt_mplayer_cmd");
			this.txt_mplayer_cmd.BackgroundImage = null;
			this.txt_mplayer_cmd.Font = null;
			this.txt_mplayer_cmd.Name = "txt_mplayer_cmd";
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// button2
			// 
			this.button2.AccessibleDescription = null;
			this.button2.AccessibleName = null;
			resources.ApplyResources(this.button2, "button2");
			this.button2.BackgroundImage = null;
			this.button2.Font = null;
			this.button2.Name = "button2";
			this.button2.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// tp_Output
			// 
			this.tp_Output.AccessibleDescription = null;
			this.tp_Output.AccessibleName = null;
			resources.ApplyResources(this.tp_Output, "tp_Output");
			this.tp_Output.BackgroundImage = null;
			this.tp_Output.Controls.Add(this.groupBox3);
			this.tp_Output.Controls.Add(this.groupBox2);
			this.tp_Output.Font = null;
			this.tp_Output.Name = "tp_Output";
			this.tp_Output.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.AccessibleDescription = null;
			this.groupBox3.AccessibleName = null;
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.BackgroundImage = null;
			this.groupBox3.Controls.Add(this.Audio_Softvol_max);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.Audio_Softvol);
			this.groupBox3.Controls.Add(this.Audio_Output);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Font = null;
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// Audio_Softvol_max
			// 
			this.Audio_Softvol_max.AccessibleDescription = null;
			this.Audio_Softvol_max.AccessibleName = null;
			resources.ApplyResources(this.Audio_Softvol_max, "Audio_Softvol_max");
			this.Audio_Softvol_max.Font = null;
			this.Audio_Softvol_max.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.Audio_Softvol_max.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.Audio_Softvol_max.Name = "Audio_Softvol_max";
			this.Audio_Softvol_max.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Font = null;
			this.label4.Name = "label4";
			// 
			// Audio_Softvol
			// 
			this.Audio_Softvol.AccessibleDescription = null;
			this.Audio_Softvol.AccessibleName = null;
			resources.ApplyResources(this.Audio_Softvol, "Audio_Softvol");
			this.Audio_Softvol.BackgroundImage = null;
			this.Audio_Softvol.Font = null;
			this.Audio_Softvol.Name = "Audio_Softvol";
			// 
			// Audio_Output
			// 
			this.Audio_Output.AccessibleDescription = null;
			this.Audio_Output.AccessibleName = null;
			resources.ApplyResources(this.Audio_Output, "Audio_Output");
			this.Audio_Output.BackgroundImage = null;
			this.Audio_Output.Font = null;
			this.Audio_Output.Items.AddRange(new object[] {
            resources.GetString("Audio_Output.Items"),
            resources.GetString("Audio_Output.Items1")});
			this.Audio_Output.Name = "Audio_Output";
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Font = null;
			this.label3.Name = "label3";
			// 
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = null;
			this.groupBox2.AccessibleName = null;
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.BackgroundImage = null;
			this.groupBox2.Controls.Add(this.Video_DirectRandering);
			this.groupBox2.Controls.Add(this.Video_Output);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Font = null;
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// Video_DirectRandering
			// 
			this.Video_DirectRandering.AccessibleDescription = null;
			this.Video_DirectRandering.AccessibleName = null;
			resources.ApplyResources(this.Video_DirectRandering, "Video_DirectRandering");
			this.Video_DirectRandering.BackgroundImage = null;
			this.Video_DirectRandering.Font = null;
			this.Video_DirectRandering.Name = "Video_DirectRandering";
			// 
			// Video_Output
			// 
			this.Video_Output.AccessibleDescription = null;
			this.Video_Output.AccessibleName = null;
			resources.ApplyResources(this.Video_Output, "Video_Output");
			this.Video_Output.BackgroundImage = null;
			this.Video_Output.Font = null;
			this.Video_Output.Items.AddRange(new object[] {
            resources.GetString("Video_Output.Items"),
            resources.GetString("Video_Output.Items1")});
			this.Video_Output.Name = "Video_Output";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// tp_Subtitle
			// 
			this.tp_Subtitle.AccessibleDescription = null;
			this.tp_Subtitle.AccessibleName = null;
			resources.ApplyResources(this.tp_Subtitle, "tp_Subtitle");
			this.tp_Subtitle.BackgroundImage = null;
			this.tp_Subtitle.Controls.Add(this.Srt_ChineseTrans);
			this.tp_Subtitle.Controls.Add(this.label8);
			this.tp_Subtitle.Controls.Add(this.groupBox4);
			this.tp_Subtitle.Controls.Add(this.Srt_AutoScale);
			this.tp_Subtitle.Controls.Add(this.label5);
			this.tp_Subtitle.Controls.Add(this.Srt_UseASS);
			this.tp_Subtitle.Controls.Add(this.Srt_ForceUTF8);
			this.tp_Subtitle.Font = null;
			this.tp_Subtitle.Name = "tp_Subtitle";
			this.tp_Subtitle.UseVisualStyleBackColor = true;
			// 
			// Srt_ChineseTrans
			// 
			this.Srt_ChineseTrans.AccessibleDescription = null;
			this.Srt_ChineseTrans.AccessibleName = null;
			resources.ApplyResources(this.Srt_ChineseTrans, "Srt_ChineseTrans");
			this.Srt_ChineseTrans.BackgroundImage = null;
			this.Srt_ChineseTrans.Font = null;
			this.Srt_ChineseTrans.FormattingEnabled = true;
			this.Srt_ChineseTrans.Items.AddRange(new object[] {
            resources.GetString("Srt_ChineseTrans.Items"),
            resources.GetString("Srt_ChineseTrans.Items1"),
            resources.GetString("Srt_ChineseTrans.Items2")});
			this.Srt_ChineseTrans.Name = "Srt_ChineseTrans";
			// 
			// label8
			// 
			this.label8.AccessibleDescription = null;
			this.label8.AccessibleName = null;
			resources.ApplyResources(this.label8, "label8");
			this.label8.Font = null;
			this.label8.Name = "label8";
			// 
			// groupBox4
			// 
			this.groupBox4.AccessibleDescription = null;
			this.groupBox4.AccessibleName = null;
			resources.ApplyResources(this.groupBox4, "groupBox4");
			this.groupBox4.BackgroundImage = null;
			this.groupBox4.Controls.Add(this.Srt_SubFontTextScale);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.btn_BroseFont);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.Srt_Font);
			this.groupBox4.Font = null;
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.TabStop = false;
			// 
			// Srt_SubFontTextScale
			// 
			this.Srt_SubFontTextScale.AccessibleDescription = null;
			this.Srt_SubFontTextScale.AccessibleName = null;
			resources.ApplyResources(this.Srt_SubFontTextScale, "Srt_SubFontTextScale");
			this.Srt_SubFontTextScale.Font = null;
			this.Srt_SubFontTextScale.Name = "Srt_SubFontTextScale";
			this.Srt_SubFontTextScale.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AccessibleDescription = null;
			this.label7.AccessibleName = null;
			resources.ApplyResources(this.label7, "label7");
			this.label7.Font = null;
			this.label7.Name = "label7";
			// 
			// btn_BroseFont
			// 
			this.btn_BroseFont.AccessibleDescription = null;
			this.btn_BroseFont.AccessibleName = null;
			resources.ApplyResources(this.btn_BroseFont, "btn_BroseFont");
			this.btn_BroseFont.BackgroundImage = null;
			this.btn_BroseFont.Font = null;
			this.btn_BroseFont.Name = "btn_BroseFont";
			this.btn_BroseFont.UseVisualStyleBackColor = true;
			this.btn_BroseFont.Click += new System.EventHandler(this.btn_BroseFont_Click);
			// 
			// label6
			// 
			this.label6.AccessibleDescription = null;
			this.label6.AccessibleName = null;
			resources.ApplyResources(this.label6, "label6");
			this.label6.Font = null;
			this.label6.Name = "label6";
			// 
			// Srt_Font
			// 
			this.Srt_Font.AccessibleDescription = null;
			this.Srt_Font.AccessibleName = null;
			resources.ApplyResources(this.Srt_Font, "Srt_Font");
			this.Srt_Font.BackgroundImage = null;
			this.Srt_Font.Font = null;
			this.Srt_Font.Name = "Srt_Font";
			// 
			// Srt_AutoScale
			// 
			this.Srt_AutoScale.AccessibleDescription = null;
			this.Srt_AutoScale.AccessibleName = null;
			resources.ApplyResources(this.Srt_AutoScale, "Srt_AutoScale");
			this.Srt_AutoScale.BackgroundImage = null;
			this.Srt_AutoScale.Font = null;
			this.Srt_AutoScale.FormattingEnabled = true;
			this.Srt_AutoScale.Items.AddRange(new object[] {
            resources.GetString("Srt_AutoScale.Items"),
            resources.GetString("Srt_AutoScale.Items1"),
            resources.GetString("Srt_AutoScale.Items2"),
            resources.GetString("Srt_AutoScale.Items3")});
			this.Srt_AutoScale.Name = "Srt_AutoScale";
			// 
			// label5
			// 
			this.label5.AccessibleDescription = null;
			this.label5.AccessibleName = null;
			resources.ApplyResources(this.label5, "label5");
			this.label5.Font = null;
			this.label5.Name = "label5";
			// 
			// Srt_UseASS
			// 
			this.Srt_UseASS.AccessibleDescription = null;
			this.Srt_UseASS.AccessibleName = null;
			resources.ApplyResources(this.Srt_UseASS, "Srt_UseASS");
			this.Srt_UseASS.BackgroundImage = null;
			this.Srt_UseASS.Font = null;
			this.Srt_UseASS.Name = "Srt_UseASS";
			this.Srt_UseASS.UseVisualStyleBackColor = true;
			// 
			// Srt_ForceUTF8
			// 
			this.Srt_ForceUTF8.AccessibleDescription = null;
			this.Srt_ForceUTF8.AccessibleName = null;
			resources.ApplyResources(this.Srt_ForceUTF8, "Srt_ForceUTF8");
			this.Srt_ForceUTF8.BackgroundImage = null;
			this.Srt_ForceUTF8.Checked = true;
			this.Srt_ForceUTF8.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Srt_ForceUTF8.Font = null;
			this.Srt_ForceUTF8.Name = "Srt_ForceUTF8";
			// 
			// tp_audio
			// 
			this.tp_audio.AccessibleDescription = null;
			this.tp_audio.AccessibleName = null;
			resources.ApplyResources(this.tp_audio, "tp_audio");
			this.tp_audio.BackgroundImage = null;
			this.tp_audio.Controls.Add(this.btn_SelectAllExt);
			this.tp_audio.Controls.Add(this.clb_FileAssociate);
			this.tp_audio.Font = null;
			this.tp_audio.Name = "tp_audio";
			this.tp_audio.UseVisualStyleBackColor = true;
			// 
			// btn_SelectAllExt
			// 
			this.btn_SelectAllExt.AccessibleDescription = null;
			this.btn_SelectAllExt.AccessibleName = null;
			resources.ApplyResources(this.btn_SelectAllExt, "btn_SelectAllExt");
			this.btn_SelectAllExt.BackgroundImage = null;
			this.btn_SelectAllExt.Font = null;
			this.btn_SelectAllExt.Name = "btn_SelectAllExt";
			this.btn_SelectAllExt.UseVisualStyleBackColor = true;
			this.btn_SelectAllExt.Click += new System.EventHandler(this.btn_SelectAllExt_Click);
			// 
			// clb_FileAssociate
			// 
			this.clb_FileAssociate.AccessibleDescription = null;
			this.clb_FileAssociate.AccessibleName = null;
			resources.ApplyResources(this.clb_FileAssociate, "clb_FileAssociate");
			this.clb_FileAssociate.BackgroundImage = null;
			this.clb_FileAssociate.CheckOnClick = true;
			this.clb_FileAssociate.Font = null;
			this.clb_FileAssociate.FormattingEnabled = true;
			this.clb_FileAssociate.Items.AddRange(new object[] {
            resources.GetString("clb_FileAssociate.Items"),
            resources.GetString("clb_FileAssociate.Items1"),
            resources.GetString("clb_FileAssociate.Items2"),
            resources.GetString("clb_FileAssociate.Items3"),
            resources.GetString("clb_FileAssociate.Items4"),
            resources.GetString("clb_FileAssociate.Items5"),
            resources.GetString("clb_FileAssociate.Items6"),
            resources.GetString("clb_FileAssociate.Items7"),
            resources.GetString("clb_FileAssociate.Items8"),
            resources.GetString("clb_FileAssociate.Items9"),
            resources.GetString("clb_FileAssociate.Items10"),
            resources.GetString("clb_FileAssociate.Items11"),
            resources.GetString("clb_FileAssociate.Items12"),
            resources.GetString("clb_FileAssociate.Items13"),
            resources.GetString("clb_FileAssociate.Items14"),
            resources.GetString("clb_FileAssociate.Items15"),
            resources.GetString("clb_FileAssociate.Items16"),
            resources.GetString("clb_FileAssociate.Items17"),
            resources.GetString("clb_FileAssociate.Items18"),
            resources.GetString("clb_FileAssociate.Items19"),
            resources.GetString("clb_FileAssociate.Items20"),
            resources.GetString("clb_FileAssociate.Items21"),
            resources.GetString("clb_FileAssociate.Items22"),
            resources.GetString("clb_FileAssociate.Items23"),
            resources.GetString("clb_FileAssociate.Items24"),
            resources.GetString("clb_FileAssociate.Items25"),
            resources.GetString("clb_FileAssociate.Items26"),
            resources.GetString("clb_FileAssociate.Items27"),
            resources.GetString("clb_FileAssociate.Items28"),
            resources.GetString("clb_FileAssociate.Items29"),
            resources.GetString("clb_FileAssociate.Items30"),
            resources.GetString("clb_FileAssociate.Items31"),
            resources.GetString("clb_FileAssociate.Items32"),
            resources.GetString("clb_FileAssociate.Items33"),
            resources.GetString("clb_FileAssociate.Items34"),
            resources.GetString("clb_FileAssociate.Items35"),
            resources.GetString("clb_FileAssociate.Items36"),
            resources.GetString("clb_FileAssociate.Items37"),
            resources.GetString("clb_FileAssociate.Items38"),
            resources.GetString("clb_FileAssociate.Items39"),
            resources.GetString("clb_FileAssociate.Items40"),
            resources.GetString("clb_FileAssociate.Items41"),
            resources.GetString("clb_FileAssociate.Items42"),
            resources.GetString("clb_FileAssociate.Items43"),
            resources.GetString("clb_FileAssociate.Items44"),
            resources.GetString("clb_FileAssociate.Items45"),
            resources.GetString("clb_FileAssociate.Items46"),
            resources.GetString("clb_FileAssociate.Items47"),
            resources.GetString("clb_FileAssociate.Items48"),
            resources.GetString("clb_FileAssociate.Items49"),
            resources.GetString("clb_FileAssociate.Items50"),
            resources.GetString("clb_FileAssociate.Items51"),
            resources.GetString("clb_FileAssociate.Items52"),
            resources.GetString("clb_FileAssociate.Items53"),
            resources.GetString("clb_FileAssociate.Items54"),
            resources.GetString("clb_FileAssociate.Items55"),
            resources.GetString("clb_FileAssociate.Items56"),
            resources.GetString("clb_FileAssociate.Items57"),
            resources.GetString("clb_FileAssociate.Items58"),
            resources.GetString("clb_FileAssociate.Items59"),
            resources.GetString("clb_FileAssociate.Items60"),
            resources.GetString("clb_FileAssociate.Items61"),
            resources.GetString("clb_FileAssociate.Items62"),
            resources.GetString("clb_FileAssociate.Items63"),
            resources.GetString("clb_FileAssociate.Items64"),
            resources.GetString("clb_FileAssociate.Items65"),
            resources.GetString("clb_FileAssociate.Items66"),
            resources.GetString("clb_FileAssociate.Items67"),
            resources.GetString("clb_FileAssociate.Items68"),
            resources.GetString("clb_FileAssociate.Items69")});
			this.clb_FileAssociate.Name = "clb_FileAssociate";
			// 
			// tabPage1
			// 
			this.tabPage1.AccessibleDescription = null;
			this.tabPage1.AccessibleName = null;
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.BackgroundImage = null;
			this.tabPage1.Controls.Add(this.chkLanguage);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Font = null;
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// chkLanguage
			// 
			this.chkLanguage.AccessibleDescription = null;
			this.chkLanguage.AccessibleName = null;
			resources.ApplyResources(this.chkLanguage, "chkLanguage");
			this.chkLanguage.BackgroundImage = null;
			this.chkLanguage.Font = null;
			this.chkLanguage.FormattingEnabled = true;
			this.chkLanguage.Items.AddRange(new object[] {
            resources.GetString("chkLanguage.Items"),
            resources.GetString("chkLanguage.Items1"),
            resources.GetString("chkLanguage.Items2"),
            resources.GetString("chkLanguage.Items3")});
			this.chkLanguage.Name = "chkLanguage";
			// 
			// label9
			// 
			this.label9.AccessibleDescription = null;
			this.label9.AccessibleName = null;
			resources.ApplyResources(this.label9, "label9");
			this.label9.Font = null;
			this.label9.Name = "label9";
			// 
			// btn_close
			// 
			this.btn_close.AccessibleDescription = null;
			this.btn_close.AccessibleName = null;
			resources.ApplyResources(this.btn_close, "btn_close");
			this.btn_close.BackgroundImage = null;
			this.btn_close.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_close.Font = null;
			this.btn_close.Name = "btn_close";
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// openFileDialog1
			// 
			resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
			// 
			// btn_cancel
			// 
			this.btn_cancel.AccessibleDescription = null;
			this.btn_cancel.AccessibleName = null;
			resources.ApplyResources(this.btn_cancel, "btn_cancel");
			this.btn_cancel.BackgroundImage = null;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = null;
			this.btn_cancel.Name = "btn_cancel";
			// 
			// OptionForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.tabControl1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = null;
			this.Name = "OptionForm";
			this.Load += new System.EventHandler(this.OptionForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tp_general.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tp_Output.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tp_Subtitle.ResumeLayout(false);
			this.tp_Subtitle.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Srt_SubFontTextScale)).EndInit();
			this.tp_audio.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

        /// <summary>
        /// replace real font path with System path Environment Variable
        /// </summary>
        private string Srt_FontPath
        {
            set
            {
                Srt_Font.Text = System.Environment.ExpandEnvironmentVariables(value);
            }
            get
            {
                string expendFontRoot = System.Environment.ExpandEnvironmentVariables(FontSelector.FontRoot);

                if (this.Srt_Font.Text.StartsWith(expendFontRoot))
                    return FontSelector.FontRoot + System.IO.Path.GetFileName(Srt_Font.Text);
                else
                    return Srt_Font.Text;
            }
        }

		public void LoadSetting()
		{
			this.txt_mplayer_cmd.Text = msetting[SetVars.MplayerExe];

			//this.Srt_ForceUTF8.Checked = (msetting[SetVars.SrtForceUTF8] == "1") ? true : false;
            this.Srt_ForceUTF8.Checked = true;
            this.Srt_AutoScale.SelectedIndex = int.Parse(msetting[SetVars.SubAutoScale]);
            this.Srt_UseASS.Checked = (msetting[SetVars.SubASS] == "1") ? true : false;
            this.Srt_FontPath = msetting[SetVars.SubFont];
            this.Srt_ChineseTrans.SelectedIndex = int.Parse(msetting[SetVars.SubChineseTrans]);
            this.Srt_SubFontTextScale.Value = int.Parse(msetting[SetVars.SubFontTextScale]);

			this.Audio_Output.Text = this.msetting[SetVars.AO];
			this.Audio_Softvol.Checked = (this.msetting[SetVars.Audio_Softvol] == "1") ? true : false;
			
			this.Audio_Softvol_max.Enabled = this.Audio_Softvol.Checked;
			this.Audio_Softvol_max.Value = decimal.Parse(this.msetting[SetVars.Audio_SoftvolMax]);

			this.Video_Output.Text = this.msetting[SetVars.VO];
			this.Video_DirectRandering.Checked = this.msetting[SetVars.Video_DR] == "1" ? true : false;

			return;
		}

		public void WriteSetting()
		{
			this.msetting[SetVars.MplayerExe] = (this.txt_mplayer_cmd.Text == "") ? @".\mplayer\mplayer.exe" : txt_mplayer_cmd.Text;
			
            //this.msetting[SetVars.SrtForceUTF8] = this.Srt_ForceUTF8.Checked ? "1" : "0";
            this.msetting[SetVars.SrtForceUTF8] = "1";
            this.msetting[SetVars.SubAutoScale] = this.Srt_AutoScale.SelectedIndex.ToString();
            this.msetting[SetVars.SubASS] = this.Srt_UseASS.Checked ? "1" : "0";
            this.msetting[SetVars.SubFont] = this.Srt_FontPath;
            this.msetting[SetVars.SubChineseTrans] = this.Srt_ChineseTrans.SelectedIndex.ToString();
            this.msetting[SetVars.SubFontTextScale] = this.Srt_SubFontTextScale.Value.ToString();

			this.msetting[SetVars.AO] = this.Audio_Output.Text;
			this.msetting[SetVars.Audio_Softvol] = (this.Audio_Softvol.Checked) ? "1" : "0";
			this.msetting[SetVars.Audio_SoftvolMax] = this.Audio_Softvol_max.Value.ToString();

			this.msetting[SetVars.VO] = this.Video_Output.Text;
			this.msetting[SetVars.Video_DR] = this.Video_DirectRandering.Checked ? "1" : "0";

			this.msetting.WriteSetting();
		}

		private void btn_browse_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != "")
			{
				this.txt_mplayer_cmd.Text = this.openFileDialog1.FileName;
			}
		}


		private void Audio_Softval_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.Audio_Softvol.Checked)
			{
				this.Audio_Softvol_max.Enabled = true;;
			}
			else
			{
				this.Audio_Softvol_max.Enabled = false;
			}
		}

        private void btn_BroseFont_Click(object sender, EventArgs e)
        {
            if (this.fontSelect == null)
                this.fontSelect = new FontSelector();

            this.fontSelect.FontPath = this.Srt_Font.Text;

            if (this.fontSelect.ShowDialog() == DialogResult.OK)
            {
                this.Srt_Font.Text = fontSelect.FontPath;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            // apply 
            ApplyFileAssociate();

			//Get the current Culture used by the program
			System.Globalization.CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
			//Initiates a new culture
			System.Globalization.CultureInfo culture;
			//sets the culture acording to the user choice
			switch (chkLanguage.SelectedIndex)
			{
				case 1://The user chose English
					culture = new System.Globalization.CultureInfo("en");
					global::Power_Mplayer.Properties.Settings.Default.Language = "en";//Set the properties in the .config file
					break;
				case 2://The user chose Chinese(Traditional)
					culture = new System.Globalization.CultureInfo("zh-CHT");
					global::Power_Mplayer.Properties.Settings.Default.Language = "zh-CHT";
					break;
				case 3://The user chose Portuguese
					culture = new System.Globalization.CultureInfo("pt");
					global::Power_Mplayer.Properties.Settings.Default.Language = "pt";
					break;
				default://The user chose the system default
					culture = System.Threading.Thread.CurrentThread.CurrentCulture;
					global::Power_Mplayer.Properties.Settings.Default.Language = "";
					break;
			}

			global::Power_Mplayer.Properties.Settings.Default.Save();

			if (currentCulture.Name != culture.Name)
				//TODO: change the messagebox text to allow it to display the message box in any language
				if (MessageBox.Show(rm.GetString("LanguageChange_Restart_Message", this.culture), 
					rm.GetString("LanguageChange_Restart_Title", this.culture),
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					Application.Restart();
        }

        private void ApplyFileAssociate()
        {
            foreach(string ext in clb_FileAssociate.CheckedItems)
            {
                Win32API.SetAssociate(ext, "PowerMplayer", "");
            }
        }

        private void btn_SelectAllExt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_FileAssociate.Items.Count; i++)
            {
                clb_FileAssociate.SetItemChecked(i, true);
            }
        }

        private void GetAssociatedExt()
        {
            for (int i = 0; i < clb_FileAssociate.Items.Count; i++)
            {
                if (Win32API.isAssociate((string) clb_FileAssociate.Items[i]))
                {
                    clb_FileAssociate.SetItemChecked(i, true);
                }
            }
        }

		private void OptionForm_Load(object sender, EventArgs e)
		{
			//Get the language information in the .config file and set the default value of the combobox 
			switch (global::Power_Mplayer.Properties.Settings.Default.Language)
			{
				case "":
					chkLanguage.SelectedIndex = 0;
					break;
				case "en":
					chkLanguage.SelectedIndex = 1;
					break;
				case "zh-CHT":
					chkLanguage.SelectedIndex = 2;
					break;
				case "pt":
					chkLanguage.SelectedIndex = 3;
					break;
			}
		}

    }
}