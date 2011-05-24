using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Security.Principal;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using System.Diagnostics;
using System.IO;

namespace MplayerWrapper
{
	public class OptionForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tp_general;
		private System.Windows.Forms.TabPage tp_Subtitle;
		private System.Windows.Forms.TabPage tp_FileExtension;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txt_mplayer_cmd;
		private System.Windows.Forms.Button btn_close;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button btn_cancel;
        private GroupBox groupBox1;
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
		private TabPage tp_Language;
		private ComboBox chkLanguage;
		private Label label9;
        private FontSelector fontSelect;

		//Allow the use of MUI for this form
        private CultureInfo culture;
        private LinkLabel linkLabel1;
        private Label label11;
        private TextBox tb_mplayer_args;
        private Label label12;
        private Button btn_Reset;
        private CheckBox CB_ForceIDX;
        private CheckBox cb_AudioVolume;
        private NumericUpDown nud_AudioVolumeVal;
        private Label label10;
        private CheckBox cb_VolumeSmooth;
        private ComboBox cb_dsoundList;
        private Label label13;
        private TabPage tp_Codec;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private Label label14;
        private TextBox tb_vfm;
        private Button btn_UseNativeCodec;
        private Button btn_ShowAllVfm;
        private Label label15;
        private TextBox textBox1;
        private Button btn_ListAllAfm;
        private Button btn_ListAllVCodec;
        private Button btn_ListAllAcodec;
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
			//Load the resourceManager for the current Form
			rm = new ResourceManager("MplayerWrapper.Strings.OptionForm", typeof(OptionForm).Assembly);

            // get dsound devices
            Microsoft.DirectX.DirectSound.DevicesCollection dc = new DevicesCollection();

            for (int i = 0; i < dc.Count; i++)
                cb_dsoundList.Items.Add(dc[i].Description);
		}

		/// <summary>
		/// 
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

        #region Windows Form auto generate codes
        /// <summary>
		/// Window Form auto generate codes
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_general = new System.Windows.Forms.TabPage();
            this.CB_ForceIDX = new System.Windows.Forms.CheckBox();
            this.tb_mplayer_args = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_mplayer_cmd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tp_Output = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_dsoundList = new System.Windows.Forms.ComboBox();
            this.cb_VolumeSmooth = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nud_AudioVolumeVal = new System.Windows.Forms.NumericUpDown();
            this.cb_AudioVolume = new System.Windows.Forms.CheckBox();
            this.Audio_Softvol_max = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Audio_Softvol = new System.Windows.Forms.CheckBox();
            this.Audio_Output = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Video_DirectRandering = new System.Windows.Forms.CheckBox();
            this.Video_Output = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tp_Codec = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_ShowAllVfm = new System.Windows.Forms.Button();
            this.btn_UseNativeCodec = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_vfm = new System.Windows.Forms.TextBox();
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
            this.tp_FileExtension = new System.Windows.Forms.TabPage();
            this.btn_SelectAllExt = new System.Windows.Forms.Button();
            this.clb_FileAssociate = new System.Windows.Forms.CheckedListBox();
            this.tp_Language = new System.Windows.Forms.TabPage();
            this.chkLanguage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_ListAllAfm = new System.Windows.Forms.Button();
            this.btn_ListAllVCodec = new System.Windows.Forms.Button();
            this.btn_ListAllAcodec = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tp_general.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tp_Output.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AudioVolumeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tp_Codec.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tp_Subtitle.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Srt_SubFontTextScale)).BeginInit();
            this.tp_FileExtension.SuspendLayout();
            this.tp_Language.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_general);
            this.tabControl1.Controls.Add(this.tp_Output);
            this.tabControl1.Controls.Add(this.tp_Codec);
            this.tabControl1.Controls.Add(this.tp_Subtitle);
            this.tabControl1.Controls.Add(this.tp_FileExtension);
            this.tabControl1.Controls.Add(this.tp_Language);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tp_general
            // 
            this.tp_general.Controls.Add(this.CB_ForceIDX);
            this.tp_general.Controls.Add(this.tb_mplayer_args);
            this.tp_general.Controls.Add(this.label12);
            this.tp_general.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tp_general, "tp_general");
            this.tp_general.Name = "tp_general";
            this.tp_general.UseVisualStyleBackColor = true;
            // 
            // CB_ForceIDX
            // 
            resources.ApplyResources(this.CB_ForceIDX, "CB_ForceIDX");
            this.CB_ForceIDX.Name = "CB_ForceIDX";
            this.CB_ForceIDX.UseVisualStyleBackColor = true;
            // 
            // tb_mplayer_args
            // 
            resources.ApplyResources(this.tb_mplayer_args, "tb_mplayer_args");
            this.tb_mplayer_args.Name = "tb_mplayer_args";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.txt_mplayer_cmd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txt_mplayer_cmd
            // 
            resources.ApplyResources(this.txt_mplayer_cmd, "txt_mplayer_cmd");
            this.txt_mplayer_cmd.Name = "txt_mplayer_cmd";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tp_Output
            // 
            this.tp_Output.Controls.Add(this.groupBox3);
            this.tp_Output.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tp_Output, "tp_Output");
            this.tp_Output.Name = "tp_Output";
            this.tp_Output.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cb_dsoundList);
            this.groupBox3.Controls.Add(this.cb_VolumeSmooth);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.nud_AudioVolumeVal);
            this.groupBox3.Controls.Add(this.cb_AudioVolume);
            this.groupBox3.Controls.Add(this.Audio_Softvol_max);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Audio_Softvol);
            this.groupBox3.Controls.Add(this.Audio_Output);
            this.groupBox3.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // cb_dsoundList
            // 
            resources.ApplyResources(this.cb_dsoundList, "cb_dsoundList");
            this.cb_dsoundList.Name = "cb_dsoundList";
            // 
            // cb_VolumeSmooth
            // 
            resources.ApplyResources(this.cb_VolumeSmooth, "cb_VolumeSmooth");
            this.cb_VolumeSmooth.Name = "cb_VolumeSmooth";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // nud_AudioVolumeVal
            // 
            resources.ApplyResources(this.nud_AudioVolumeVal, "nud_AudioVolumeVal");
            this.nud_AudioVolumeVal.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nud_AudioVolumeVal.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.nud_AudioVolumeVal.Name = "nud_AudioVolumeVal";
            // 
            // cb_AudioVolume
            // 
            resources.ApplyResources(this.cb_AudioVolume, "cb_AudioVolume");
            this.cb_AudioVolume.Name = "cb_AudioVolume";
            this.cb_AudioVolume.CheckedChanged += new System.EventHandler(this.cb_AudioVolume_CheckedChanged);
            // 
            // Audio_Softvol_max
            // 
            resources.ApplyResources(this.Audio_Softvol_max, "Audio_Softvol_max");
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
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Audio_Softvol
            // 
            resources.ApplyResources(this.Audio_Softvol, "Audio_Softvol");
            this.Audio_Softvol.Name = "Audio_Softvol";
            this.Audio_Softvol.CheckedChanged += new System.EventHandler(this.Audio_Softvol_CheckedChanged);
            // 
            // Audio_Output
            // 
            this.Audio_Output.Items.AddRange(new object[] {
            resources.GetString("Audio_Output.Items"),
            resources.GetString("Audio_Output.Items1")});
            resources.ApplyResources(this.Audio_Output, "Audio_Output");
            this.Audio_Output.Name = "Audio_Output";
            this.Audio_Output.SelectedIndexChanged += new System.EventHandler(this.Audio_Output_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Video_DirectRandering);
            this.groupBox2.Controls.Add(this.Video_Output);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // Video_DirectRandering
            // 
            resources.ApplyResources(this.Video_DirectRandering, "Video_DirectRandering");
            this.Video_DirectRandering.Name = "Video_DirectRandering";
            // 
            // Video_Output
            // 
            this.Video_Output.Items.AddRange(new object[] {
            resources.GetString("Video_Output.Items"),
            resources.GetString("Video_Output.Items1"),
            resources.GetString("Video_Output.Items2"),
            resources.GetString("Video_Output.Items3"),
            resources.GetString("Video_Output.Items4")});
            resources.ApplyResources(this.Video_Output, "Video_Output");
            this.Video_Output.Name = "Video_Output";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tp_Codec
            // 
            this.tp_Codec.Controls.Add(this.groupBox6);
            this.tp_Codec.Controls.Add(this.groupBox5);
            resources.ApplyResources(this.tp_Codec, "tp_Codec");
            this.tp_Codec.Name = "tp_Codec";
            this.tp_Codec.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_ListAllAcodec);
            this.groupBox6.Controls.Add(this.btn_ListAllAfm);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.textBox1);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_ListAllVCodec);
            this.groupBox5.Controls.Add(this.btn_ShowAllVfm);
            this.groupBox5.Controls.Add(this.btn_UseNativeCodec);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tb_vfm);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btn_ShowAllVfm
            // 
            resources.ApplyResources(this.btn_ShowAllVfm, "btn_ShowAllVfm");
            this.btn_ShowAllVfm.Name = "btn_ShowAllVfm";
            this.btn_ShowAllVfm.UseVisualStyleBackColor = true;
            this.btn_ShowAllVfm.Click += new System.EventHandler(this.btn_ShowAllVfm_Click);
            // 
            // btn_UseNativeCodec
            // 
            resources.ApplyResources(this.btn_UseNativeCodec, "btn_UseNativeCodec");
            this.btn_UseNativeCodec.Name = "btn_UseNativeCodec";
            this.btn_UseNativeCodec.UseVisualStyleBackColor = true;
            this.btn_UseNativeCodec.Click += new System.EventHandler(this.btn_UseNativeCodec_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // tb_vfm
            // 
            resources.ApplyResources(this.tb_vfm, "tb_vfm");
            this.tb_vfm.Name = "tb_vfm";
            // 
            // tp_Subtitle
            // 
            this.tp_Subtitle.Controls.Add(this.Srt_ChineseTrans);
            this.tp_Subtitle.Controls.Add(this.label8);
            this.tp_Subtitle.Controls.Add(this.groupBox4);
            this.tp_Subtitle.Controls.Add(this.Srt_AutoScale);
            this.tp_Subtitle.Controls.Add(this.label5);
            this.tp_Subtitle.Controls.Add(this.Srt_UseASS);
            resources.ApplyResources(this.tp_Subtitle, "tp_Subtitle");
            this.tp_Subtitle.Name = "tp_Subtitle";
            this.tp_Subtitle.UseVisualStyleBackColor = true;
            // 
            // Srt_ChineseTrans
            // 
            this.Srt_ChineseTrans.FormattingEnabled = true;
            this.Srt_ChineseTrans.Items.AddRange(new object[] {
            resources.GetString("Srt_ChineseTrans.Items"),
            resources.GetString("Srt_ChineseTrans.Items1"),
            resources.GetString("Srt_ChineseTrans.Items2")});
            resources.ApplyResources(this.Srt_ChineseTrans, "Srt_ChineseTrans");
            this.Srt_ChineseTrans.Name = "Srt_ChineseTrans";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Srt_SubFontTextScale);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btn_BroseFont);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.Srt_Font);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // Srt_SubFontTextScale
            // 
            resources.ApplyResources(this.Srt_SubFontTextScale, "Srt_SubFontTextScale");
            this.Srt_SubFontTextScale.Name = "Srt_SubFontTextScale";
            this.Srt_SubFontTextScale.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btn_BroseFont
            // 
            resources.ApplyResources(this.btn_BroseFont, "btn_BroseFont");
            this.btn_BroseFont.Name = "btn_BroseFont";
            this.btn_BroseFont.UseVisualStyleBackColor = true;
            this.btn_BroseFont.Click += new System.EventHandler(this.btn_BroseFont_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // Srt_Font
            // 
            resources.ApplyResources(this.Srt_Font, "Srt_Font");
            this.Srt_Font.Name = "Srt_Font";
            // 
            // Srt_AutoScale
            // 
            this.Srt_AutoScale.FormattingEnabled = true;
            this.Srt_AutoScale.Items.AddRange(new object[] {
            resources.GetString("Srt_AutoScale.Items"),
            resources.GetString("Srt_AutoScale.Items1"),
            resources.GetString("Srt_AutoScale.Items2"),
            resources.GetString("Srt_AutoScale.Items3")});
            resources.ApplyResources(this.Srt_AutoScale, "Srt_AutoScale");
            this.Srt_AutoScale.Name = "Srt_AutoScale";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Srt_UseASS
            // 
            resources.ApplyResources(this.Srt_UseASS, "Srt_UseASS");
            this.Srt_UseASS.Name = "Srt_UseASS";
            this.Srt_UseASS.UseVisualStyleBackColor = true;
            // 
            // tp_FileExtension
            // 
            this.tp_FileExtension.Controls.Add(this.btn_SelectAllExt);
            this.tp_FileExtension.Controls.Add(this.clb_FileAssociate);
            resources.ApplyResources(this.tp_FileExtension, "tp_FileExtension");
            this.tp_FileExtension.Name = "tp_FileExtension";
            this.tp_FileExtension.UseVisualStyleBackColor = true;
            // 
            // btn_SelectAllExt
            // 
            resources.ApplyResources(this.btn_SelectAllExt, "btn_SelectAllExt");
            this.btn_SelectAllExt.Name = "btn_SelectAllExt";
            this.btn_SelectAllExt.UseVisualStyleBackColor = true;
            this.btn_SelectAllExt.Click += new System.EventHandler(this.btn_SelectAllExt_Click);
            // 
            // clb_FileAssociate
            // 
            this.clb_FileAssociate.CheckOnClick = true;
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
            resources.ApplyResources(this.clb_FileAssociate, "clb_FileAssociate");
            this.clb_FileAssociate.Name = "clb_FileAssociate";
            // 
            // tp_Language
            // 
            this.tp_Language.Controls.Add(this.chkLanguage);
            this.tp_Language.Controls.Add(this.label9);
            resources.ApplyResources(this.tp_Language, "tp_Language");
            this.tp_Language.Name = "tp_Language";
            this.tp_Language.UseVisualStyleBackColor = true;
            // 
            // chkLanguage
            // 
            this.chkLanguage.FormattingEnabled = true;
            this.chkLanguage.Items.AddRange(new object[] {
            resources.GetString("chkLanguage.Items"),
            resources.GetString("chkLanguage.Items1"),
            resources.GetString("chkLanguage.Items2"),
            resources.GetString("chkLanguage.Items3")});
            resources.ApplyResources(this.chkLanguage, "chkLanguage");
            this.chkLanguage.Name = "chkLanguage";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btn_close, "btn_close");
            this.btn_close.Name = "btn_close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_cancel, "btn_cancel");
            this.btn_cancel.Name = "btn_cancel";
            // 
            // btn_Reset
            // 
            resources.ApplyResources(this.btn_Reset, "btn_Reset");
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // btn_ListAllAfm
            // 
            resources.ApplyResources(this.btn_ListAllAfm, "btn_ListAllAfm");
            this.btn_ListAllAfm.Name = "btn_ListAllAfm";
            this.btn_ListAllAfm.UseVisualStyleBackColor = true;
            this.btn_ListAllAfm.Click += new System.EventHandler(this.btn_ListAllAfm_Click);
            // 
            // btn_ListAllVCodec
            // 
            resources.ApplyResources(this.btn_ListAllVCodec, "btn_ListAllVCodec");
            this.btn_ListAllVCodec.Name = "btn_ListAllVCodec";
            this.btn_ListAllVCodec.UseVisualStyleBackColor = true;
            this.btn_ListAllVCodec.Click += new System.EventHandler(this.btn_ListAllVCodec_Click);
            // 
            // btn_ListAllAcodec
            // 
            resources.ApplyResources(this.btn_ListAllAcodec, "btn_ListAllAcodec");
            this.btn_ListAllAcodec.Name = "btn_ListAllAcodec";
            this.btn_ListAllAcodec.UseVisualStyleBackColor = true;
            this.btn_ListAllAcodec.Click += new System.EventHandler(this.btn_ListAllAcodec_Click);
            // 
            // OptionForm
            // 
            this.AcceptButton = this.btn_close;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btn_cancel;
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionForm";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_general.ResumeLayout(false);
            this.tp_general.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tp_Output.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_AudioVolumeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tp_Codec.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tp_Subtitle.ResumeLayout(false);
            this.tp_Subtitle.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Srt_SubFontTextScale)).EndInit();
            this.tp_FileExtension.ResumeLayout(false);
            this.tp_Language.ResumeLayout(false);
            this.tp_Language.PerformLayout();
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
            this.tb_mplayer_args.Text = msetting[SetVars.MplayerOtherArgs];

            this.Srt_AutoScale.SelectedIndex = int.Parse(msetting[SetVars.SubAutoScale]);
            this.Srt_UseASS.Checked = (msetting[SetVars.SubASS] == "1") ? true : false;
            this.Srt_FontPath = msetting[SetVars.SubFont];
            this.Srt_ChineseTrans.SelectedIndex = int.Parse(msetting[SetVars.SubChineseTrans]);
            this.Srt_SubFontTextScale.Value = int.Parse(msetting[SetVars.SubFontTextScale]);

			this.Audio_Output.Text = this.msetting[SetVars.AO];
            this.cb_dsoundList.SelectedIndex = int.Parse(this.msetting[SetVars.dsoundDevice]);
			this.Audio_Softvol.Checked = (this.msetting[SetVars.Audio_Softvol] == "1") ? true : false;
			this.Audio_Softvol_max.Enabled = this.Audio_Softvol.Checked;
			this.Audio_Softvol_max.Value = decimal.Parse(this.msetting[SetVars.Audio_SoftvolMax]);
            this.cb_AudioVolume.Checked = (this.msetting[SetVars.Audio_Volume] == "1") ? true : false;
            this.nud_AudioVolumeVal.Enabled = cb_VolumeSmooth.Enabled = cb_AudioVolume.Checked;
            this.nud_AudioVolumeVal.Value = decimal.Parse(this.msetting[SetVars.Audio_Volume_Val]);
            this.cb_VolumeSmooth.Checked = (this.msetting[SetVars.Audio_Volume_Smooth] == "1") ? true : false;

			this.Video_Output.Text = this.msetting[SetVars.VO];
			this.Video_DirectRandering.Checked = this.msetting[SetVars.Video_DR] == "1" ? true : false;

            this.CB_ForceIDX.Checked = (msetting[SetVars.ForceIDX] == "1") ? true : false;

			return;
		}

		public void WriteSetting()
		{
			this.msetting[SetVars.MplayerExe] = (this.txt_mplayer_cmd.Text == "") ? @".\mplayer\mplayer.exe" : txt_mplayer_cmd.Text;
            this.msetting[SetVars.MplayerOtherArgs] = this.tb_mplayer_args.Text;

            this.msetting[SetVars.SubAutoScale] = this.Srt_AutoScale.SelectedIndex.ToString();
            this.msetting[SetVars.SubASS] = this.Srt_UseASS.Checked ? "1" : "0";
            this.msetting[SetVars.SubFont] = this.Srt_FontPath;
            this.msetting[SetVars.SubChineseTrans] = this.Srt_ChineseTrans.SelectedIndex.ToString();
            this.msetting[SetVars.SubFontTextScale] = this.Srt_SubFontTextScale.Value.ToString();

			this.msetting[SetVars.AO] = this.Audio_Output.Text;
            this.msetting[SetVars.dsoundDevice] = this.cb_dsoundList.SelectedIndex.ToString();
			this.msetting[SetVars.Audio_Softvol] = (this.Audio_Softvol.Checked) ? "1" : "0";
			this.msetting[SetVars.Audio_SoftvolMax] = this.Audio_Softvol_max.Value.ToString();
            this.msetting[SetVars.Audio_Volume] = (this.cb_AudioVolume.Checked) ? "1" : "0";
            this.msetting[SetVars.Audio_Volume_Val] = this.nud_AudioVolumeVal.Value.ToString();
            this.msetting[SetVars.Audio_Volume_Smooth] = (this.cb_VolumeSmooth.Checked) ? "1" : "0";

			this.msetting[SetVars.VO] = this.Video_Output.Text;
			this.msetting[SetVars.Video_DR] = this.Video_DirectRandering.Checked ? "1" : "0";

            this.msetting[SetVars.ForceIDX] = this.CB_ForceIDX.Checked ? "1" : "0";

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
			if(isAdmin)
	            ApplyFileAssociate();

			SaveLanguageConfig();
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
		private bool isAdmin;

		private void OptionForm_Load(object sender, EventArgs e)
		{
			//set the settings for someone who uses the local version(msi)
            btn_cancel.Enabled = true;

			GetCurrentLanguage();
			GetExtPermition();

		}

        /// <summary>
        /// Sets the dropdown menu in the language tab to be the same as the current language in the config file
        /// </summary>
        private void GetCurrentLanguage()
		{
			//Get the language information in the .config file and set the default value of the combobox 
			switch (msetting[SetVars.Language])
			{
				//It´s better to use the SelectedIndex Property than the Text Property because the Text won´t be the same for all the Languages
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

		/// <summary>
		/// Saves the current user language seetings
		/// </summary>
		private void SaveLanguageConfig()
		{
			//Get the current Culture used by the program
			string currentCulture = msetting[SetVars.Language];//global::Power_Mplayer.Properties.Settings.Default.Language;
			//Initiates a new culture
			string newCulture;
			//sets the culture acording to the user choice
			switch (chkLanguage.SelectedIndex)
			{
				case 1://The user chose English
					newCulture = "en";
					msetting[SetVars.Language] = "en";//Set the properties in the .config file
					break;
				case 2://The user chose Chinese(Traditional)
					newCulture = "zh-CHT";
					msetting[SetVars.Language] = "zh-CHT";
					break;
				case 3://The user chose Portuguese
					newCulture = "pt";
					msetting[SetVars.Language] = "pt";
					break;
				default://The user chose the system default, it will use the standard windows ui language, if avalible
					newCulture = "";
					msetting[SetVars.Language] = "";
					break;
			}

			if (currentCulture != newCulture)
				//TODO: change the messagebox text to allow it to display the message box in any language
				if (MessageBox.Show(rm.GetString("LanguageChange_Restart_Message", this.culture),
					rm.GetString("LanguageChange_Restart_Title", this.culture),
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					Application.Restart();
		}

		/// <summary>
		/// Check if the current user has administrator permitions and disable the File extension tab
		/// </summary>
		private void GetExtPermition()
		{
			WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
			isAdmin = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);

			clb_FileAssociate.Enabled = isAdmin;
			btn_SelectAllExt.Enabled = isAdmin;
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;

            System.Diagnostics.Process.Start(label.Text);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will reset all the settings.\nAre you sure?", "Reset setting", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.msetting.CreateDefaultValue();
                this.LoadSetting();
                this.btn_cancel.Enabled = false;
            }
        }

        private void Audio_Softvol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            Audio_Softvol_max.Enabled = cb.Checked;
        }

        private void cb_AudioVolume_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            nud_AudioVolumeVal.Enabled = cb_VolumeSmooth.Enabled = cb.Checked;
        }

        private void Audio_Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb_dsoundList.Enabled = cb.Text == "dsound" ? true : false;            
        }

        private void btn_UseNativeCodec_Click(object sender, EventArgs e)
        {
            tb_vfm.Text = "dsnative";
        }

        private void btn_ShowAllVfm_Click(object sender, EventArgs e)
        {
            getMplayerUsage("-vfm help");
        }



        private void btn_ListAllAfm_Click(object sender, EventArgs e)
        {
            getMplayerUsage("-afm help");
        }

        private void btn_ListAllAcodec_Click(object sender, EventArgs e)
        {
            getMplayerUsage("-ac help");
        }

        private void btn_ListAllVCodec_Click(object sender, EventArgs e)
        {
            getMplayerUsage("-vc help");
        }

        private void getMplayerUsage(string args)
        {
            Process p = new Process();

            p.StartInfo.FileName = this.msetting[SetVars.MplayerExe];
            p.StartInfo.Arguments = args;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            using(TextWriter tw = new StreamWriter("tmp.txt"))
            {
                TextReader tr = p.StandardOutput as TextReader;
                tw.Write(tr.ReadToEnd());
                tw.Close();
            }

            p.Dispose();

            Process.Start("notepad.exe", "tmp.txt");
        }
    }
}
