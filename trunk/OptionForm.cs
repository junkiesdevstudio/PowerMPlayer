using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// OptionForm 的摘要描述。
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
		/// 設計工具所需的變數。
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btn_cancel;
        private GroupBox groupBox2;
        private CheckBox Video_DirectRandering;
        private ComboBox Video_Output;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private NumericUpDown Audio_Softvol_max;
        private Label label4;
        private CheckBox Audio_Softvol;
        private ComboBox Audio_Output;
        private Label label3;
        private CheckBox Srt_ForceUTF8;
        private CheckBox Srt_UseASS;
        private Label label5;
        private ComboBox Srt_AutoScale;
        private GroupBox groupBox4;
        private Label label6;
        private TextBox Srt_Font;
        private Button btn_BroseFont;
        private NumericUpDown numericUpDown1;
        private Label label7;

		private MplayerSetting msetting;
        private CheckedListBox clb_FileAssociate;
        private Button btn_SelectAllExt;
        private FontSelector fontSelect;

		// constructure
		public OptionForm(MplayerSetting ms)
		{
			InitializeComponent();

			this.msetting = ms;
            this.fontSelect = null;
            
            GetAssociatedExt();
		}

		/// <summary>
		/// 清除任何使用中的資源。
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

		#region Windows Form 設計工具產生的程式碼
		/// <summary>
		/// 此為設計工具支援所必須的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_general = new System.Windows.Forms.TabPage();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_mplayer_cmd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tp_Subtitle = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_BroseFont = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Srt_Font = new System.Windows.Forms.TextBox();
            this.Srt_AutoScale = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Srt_UseASS = new System.Windows.Forms.CheckBox();
            this.Srt_ForceUTF8 = new System.Windows.Forms.CheckBox();
            this.tp_audio = new System.Windows.Forms.TabPage();
            this.clb_FileAssociate = new System.Windows.Forms.CheckedListBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_SelectAllExt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tp_general.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tp_Subtitle.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tp_audio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_general);
            this.tabControl1.Controls.Add(this.tp_Subtitle);
            this.tabControl1.Controls.Add(this.tp_audio);
            this.tabControl1.Location = new System.Drawing.Point(0, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 296);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_general
            // 
            this.tp_general.Controls.Add(this.groupBox3);
            this.tp_general.Controls.Add(this.groupBox2);
            this.tp_general.Controls.Add(this.groupBox1);
            this.tp_general.Location = new System.Drawing.Point(4, 21);
            this.tp_general.Name = "tp_general";
            this.tp_general.Size = new System.Drawing.Size(368, 271);
            this.tp_general.TabIndex = 0;
            this.tp_general.Text = "一般";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Audio_Softvol_max);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Audio_Softvol);
            this.groupBox3.Controls.Add(this.Audio_Output);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(8, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 88);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "聲音";
            // 
            // Audio_Softvol_max
            // 
            this.Audio_Softvol_max.Location = new System.Drawing.Point(243, 49);
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
            this.Audio_Softvol_max.Size = new System.Drawing.Size(96, 22);
            this.Audio_Softvol_max.TabIndex = 6;
            this.Audio_Softvol_max.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(173, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "最大值 (%)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Audio_Softvol
            // 
            this.Audio_Softvol.Location = new System.Drawing.Point(10, 46);
            this.Audio_Softvol.Name = "Audio_Softvol";
            this.Audio_Softvol.Size = new System.Drawing.Size(152, 24);
            this.Audio_Softvol.TabIndex = 4;
            this.Audio_Softvol.Text = "使用軟體音訊混合器";
            // 
            // Audio_Output
            // 
            this.Audio_Output.Items.AddRange(new object[] {
            "win32",
            "dsound"});
            this.Audio_Output.Location = new System.Drawing.Point(120, 18);
            this.Audio_Output.Name = "Audio_Output";
            this.Audio_Output.Size = new System.Drawing.Size(121, 20);
            this.Audio_Output.TabIndex = 2;
            this.Audio_Output.Text = "dsound";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "聲音輸出驅動程式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Video_DirectRandering);
            this.groupBox2.Controls.Add(this.Video_Output);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 71);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "影像";
            // 
            // Video_DirectRandering
            // 
            this.Video_DirectRandering.Location = new System.Drawing.Point(8, 44);
            this.Video_DirectRandering.Name = "Video_DirectRandering";
            this.Video_DirectRandering.Size = new System.Drawing.Size(104, 24);
            this.Video_DirectRandering.TabIndex = 6;
            this.Video_DirectRandering.Text = "Direct Rendering";
            // 
            // Video_Output
            // 
            this.Video_Output.Items.AddRange(new object[] {
            "directx",
            "winvidix"});
            this.Video_Output.Location = new System.Drawing.Point(118, 18);
            this.Video_Output.Name = "Video_Output";
            this.Video_Output.Size = new System.Drawing.Size(121, 20);
            this.Video_Output.TabIndex = 4;
            this.Video_Output.Text = "directx";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "影像輸出驅動程式";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_mplayer_cmd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mplayer 設定";
            // 
            // txt_mplayer_cmd
            // 
            this.txt_mplayer_cmd.Location = new System.Drawing.Point(82, 21);
            this.txt_mplayer_cmd.Name = "txt_mplayer_cmd";
            this.txt_mplayer_cmd.Size = new System.Drawing.Size(204, 22);
            this.txt_mplayer_cmd.TabIndex = 0;
            this.txt_mplayer_cmd.Text = ".\\mplayer.exe";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mplayer 位置:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "瀏覽";
            this.button2.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tp_Subtitle
            // 
            this.tp_Subtitle.Controls.Add(this.groupBox4);
            this.tp_Subtitle.Controls.Add(this.Srt_AutoScale);
            this.tp_Subtitle.Controls.Add(this.label5);
            this.tp_Subtitle.Controls.Add(this.Srt_UseASS);
            this.tp_Subtitle.Controls.Add(this.Srt_ForceUTF8);
            this.tp_Subtitle.Location = new System.Drawing.Point(4, 21);
            this.tp_Subtitle.Name = "tp_Subtitle";
            this.tp_Subtitle.Size = new System.Drawing.Size(368, 271);
            this.tp_Subtitle.TabIndex = 1;
            this.tp_Subtitle.Text = "字幕";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btn_BroseFont);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.Srt_Font);
            this.groupBox4.Location = new System.Drawing.Point(8, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 186);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "字型";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(69, 46);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "起始大小";
            // 
            // btn_BroseFont
            // 
            this.btn_BroseFont.Location = new System.Drawing.Point(271, 18);
            this.btn_BroseFont.Name = "btn_BroseFont";
            this.btn_BroseFont.Size = new System.Drawing.Size(75, 23);
            this.btn_BroseFont.TabIndex = 2;
            this.btn_BroseFont.Text = "瀏覽字型";
            this.btn_BroseFont.UseVisualStyleBackColor = true;
            this.btn_BroseFont.Click += new System.EventHandler(this.btn_BroseFont_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "字型";
            // 
            // Srt_Font
            // 
            this.Srt_Font.Location = new System.Drawing.Point(69, 18);
            this.Srt_Font.Name = "Srt_Font";
            this.Srt_Font.Size = new System.Drawing.Size(196, 22);
            this.Srt_Font.TabIndex = 0;
            // 
            // Srt_AutoScale
            // 
            this.Srt_AutoScale.FormattingEnabled = true;
            this.Srt_AutoScale.Items.AddRange(new object[] {
            "無自動調整",
            "依高度自動調整",
            "依寬度自動調整",
            "依對角自動調整"});
            this.Srt_AutoScale.Location = new System.Drawing.Point(99, 196);
            this.Srt_AutoScale.Name = "Srt_AutoScale";
            this.Srt_AutoScale.Size = new System.Drawing.Size(121, 20);
            this.Srt_AutoScale.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "字幕自動調整";
            // 
            // Srt_UseASS
            // 
            this.Srt_UseASS.AutoSize = true;
            this.Srt_UseASS.Location = new System.Drawing.Point(8, 222);
            this.Srt_UseASS.Name = "Srt_UseASS";
            this.Srt_UseASS.Size = new System.Drawing.Size(94, 16);
            this.Srt_UseASS.TabIndex = 5;
            this.Srt_UseASS.Text = "使用 SSA/ASS";
            this.Srt_UseASS.UseVisualStyleBackColor = true;
            // 
            // Srt_ForceUTF8
            // 
            this.Srt_ForceUTF8.Location = new System.Drawing.Point(8, 244);
            this.Srt_ForceUTF8.Name = "Srt_ForceUTF8";
            this.Srt_ForceUTF8.Size = new System.Drawing.Size(200, 24);
            this.Srt_ForceUTF8.TabIndex = 4;
            this.Srt_ForceUTF8.Text = "將字幕自動轉成 utf8 編碼";
            // 
            // tp_audio
            // 
            this.tp_audio.Controls.Add(this.btn_SelectAllExt);
            this.tp_audio.Controls.Add(this.clb_FileAssociate);
            this.tp_audio.Location = new System.Drawing.Point(4, 21);
            this.tp_audio.Name = "tp_audio";
            this.tp_audio.Size = new System.Drawing.Size(368, 271);
            this.tp_audio.TabIndex = 2;
            this.tp_audio.Text = "檔案類型";
            // 
            // clb_FileAssociate
            // 
            this.clb_FileAssociate.CheckOnClick = true;
            this.clb_FileAssociate.FormattingEnabled = true;
            this.clb_FileAssociate.Items.AddRange(new object[] {
            ".3gp",
            ".669",
            ".AAC",
            ".ac3",
            ".aif",
            ".aifc",
            ".aiff",
            ".amc",
            ".amf",
            ".APL",
            ".asf",
            ".au",
            ".avi",
            ".cda",
            ".far",
            ".it",
            ".itz",
            ".KAR",
            ".M2V",
            ".M4A",
            ".mdz",
            ".mid",
            ".midi",
            ".MIZ",
            ".mka",
            ".mkv",
            ".mod",
            ".mov",
            ".MP1",
            ".mp2",
            ".mp2v",
            ".mp3",
            ".mp4",
            ".mpa",
            ".mpe",
            ".mpeg",
            ".mpg",
            ".mpg4",
            ".mpv2",
            ".mtm",
            ".NSA",
            ".nst",
            ".NSV",
            ".OGG",
            ".ogm",
            ".okt",
            ".ptm",
            ".ra",
            ".ram",
            ".rm",
            ".rmi",
            ".rmm",
            ".rnx",
            ".rp",
            ".rv",
            ".s3m",
            ".s3z",
            ".smi",
            ".smil",
            ".snd",
            ".stm",
            ".stz",
            ".ult",
            ".VOC",
            ".wav",
            ".wma",
            ".wmv",
            ".xm",
            ".xmz"});
            this.clb_FileAssociate.Location = new System.Drawing.Point(8, 12);
            this.clb_FileAssociate.Name = "clb_FileAssociate";
            this.clb_FileAssociate.Size = new System.Drawing.Size(271, 225);
            this.clb_FileAssociate.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_close.Location = new System.Drawing.Point(216, 312);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 24);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "關閉";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(296, 312);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 24);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            // 
            // btn_SelectAllExt
            // 
            this.btn_SelectAllExt.Location = new System.Drawing.Point(285, 12);
            this.btn_SelectAllExt.Name = "btn_SelectAllExt";
            this.btn_SelectAllExt.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectAllExt.TabIndex = 2;
            this.btn_SelectAllExt.Text = "全選";
            this.btn_SelectAllExt.UseVisualStyleBackColor = true;
            this.btn_SelectAllExt.Click += new System.EventHandler(this.btn_SelectAllExt_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(376, 341);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionForm";
            this.Text = "Power Mplayer 選項";
            this.tabControl1.ResumeLayout(false);
            this.tp_general.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tp_Subtitle.ResumeLayout(false);
            this.tp_Subtitle.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tp_audio.ResumeLayout(false);
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

			this.Srt_ForceUTF8.Checked = (msetting[SetVars.SrtForceUTF8] == "1") ? true : false;
            this.Srt_AutoScale.SelectedIndex = int.Parse(msetting[SetVars.SubAutoScale]);
            this.Srt_UseASS.Checked = (msetting[SetVars.SubASS] == "1") ? true : false;
            this.Srt_FontPath = msetting[SetVars.SubFont];

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
			
            this.msetting[SetVars.SrtForceUTF8] = this.Srt_ForceUTF8.Checked ? "1" : "0";
            this.msetting[SetVars.SubAutoScale] = this.Srt_AutoScale.SelectedIndex.ToString();
            this.msetting[SetVars.SubASS] = this.Srt_UseASS.Checked ? "1" : "0";
            this.msetting[SetVars.SubFont] = this.Srt_FontPath;

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

    }
}
