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
		private System.Windows.Forms.TabPage tp_video;
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox Audio_Output;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox Video_Output;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown Audio_Softvol_max;
		private System.Windows.Forms.CheckBox Audio_Softvol;
		private System.Windows.Forms.CheckBox Video_DirectRandering;

		private MplayerSetting msetting;

		public OptionForm(MplayerSetting ms)
		{
			//
			// Windows Form 設計工具支援的必要項
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 呼叫之後加入任何建構函式程式碼
			//
			this.msetting = ms;

			this.LoadSetting();
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
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_mplayer_cmd = new System.Windows.Forms.TextBox();
			this.tp_video = new System.Windows.Forms.TabPage();
			this.Video_Output = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tp_audio = new System.Windows.Forms.TabPage();
			this.Audio_Softvol_max = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.Audio_Softvol = new System.Windows.Forms.CheckBox();
			this.Audio_Output = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_close = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Video_DirectRandering = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.tp_general.SuspendLayout();
			this.tp_video.SuspendLayout();
			this.tp_audio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tp_general);
			this.tabControl1.Controls.Add(this.tp_video);
			this.tabControl1.Controls.Add(this.tp_audio);
			this.tabControl1.Location = new System.Drawing.Point(0, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(376, 296);
			this.tabControl1.TabIndex = 0;
			// 
			// tp_general
			// 
			this.tp_general.Controls.Add(this.button2);
			this.tp_general.Controls.Add(this.label1);
			this.tp_general.Controls.Add(this.txt_mplayer_cmd);
			this.tp_general.Location = new System.Drawing.Point(4, 21);
			this.tp_general.Name = "tp_general";
			this.tp_general.Size = new System.Drawing.Size(368, 271);
			this.tp_general.TabIndex = 0;
			this.tp_general.Text = "一般";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(312, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "瀏覽";
			this.button2.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mplayer 位置:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txt_mplayer_cmd
			// 
			this.txt_mplayer_cmd.Location = new System.Drawing.Point(88, 16);
			this.txt_mplayer_cmd.Name = "txt_mplayer_cmd";
			this.txt_mplayer_cmd.Size = new System.Drawing.Size(216, 22);
			this.txt_mplayer_cmd.TabIndex = 0;
			this.txt_mplayer_cmd.Text = ".\\mplayer.exe";
			// 
			// tp_video
			// 
			this.tp_video.Controls.Add(this.Video_DirectRandering);
			this.tp_video.Controls.Add(this.Video_Output);
			this.tp_video.Controls.Add(this.label2);
			this.tp_video.Location = new System.Drawing.Point(4, 21);
			this.tp_video.Name = "tp_video";
			this.tp_video.Size = new System.Drawing.Size(368, 271);
			this.tp_video.TabIndex = 1;
			this.tp_video.Text = "影像";
			// 
			// Video_Output
			// 
			this.Video_Output.Items.AddRange(new object[] {
															  "directx",
															  "winvidix"});
			this.Video_Output.Location = new System.Drawing.Point(120, 8);
			this.Video_Output.Name = "Video_Output";
			this.Video_Output.Size = new System.Drawing.Size(121, 20);
			this.Video_Output.TabIndex = 2;
			this.Video_Output.Text = "directx";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "影像輸出驅動程式";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tp_audio
			// 
			this.tp_audio.Controls.Add(this.Audio_Softvol_max);
			this.tp_audio.Controls.Add(this.label4);
			this.tp_audio.Controls.Add(this.Audio_Softvol);
			this.tp_audio.Controls.Add(this.Audio_Output);
			this.tp_audio.Controls.Add(this.label3);
			this.tp_audio.Location = new System.Drawing.Point(4, 21);
			this.tp_audio.Name = "tp_audio";
			this.tp_audio.Size = new System.Drawing.Size(368, 271);
			this.tp_audio.TabIndex = 2;
			this.tp_audio.Text = "聲音";
			// 
			// Audio_Softvol_max
			// 
			this.Audio_Softvol_max.Location = new System.Drawing.Point(248, 128);
			this.Audio_Softvol_max.Maximum = new System.Decimal(new int[] {
																			  10000,
																			  0,
																			  0,
																			  0});
			this.Audio_Softvol_max.Minimum = new System.Decimal(new int[] {
																			  10,
																			  0,
																			  0,
																			  0});
			this.Audio_Softvol_max.Name = "Audio_Softvol_max";
			this.Audio_Softvol_max.Size = new System.Drawing.Size(96, 22);
			this.Audio_Softvol_max.TabIndex = 4;
			this.Audio_Softvol_max.Value = new System.Decimal(new int[] {
																			110,
																			0,
																			0,
																			0});
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(176, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "最大值 (%)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Audio_Softvol
			// 
			this.Audio_Softvol.Location = new System.Drawing.Point(8, 128);
			this.Audio_Softvol.Name = "Audio_Softvol";
			this.Audio_Softvol.Size = new System.Drawing.Size(152, 24);
			this.Audio_Softvol.TabIndex = 2;
			this.Audio_Softvol.Text = "使用軟體音訊混合器";
			this.Audio_Softvol.CheckedChanged += new System.EventHandler(this.Audio_Softval_CheckedChanged);
			// 
			// Audio_Output
			// 
			this.Audio_Output.Items.AddRange(new object[] {
															  "win32",
															  "dsound"});
			this.Audio_Output.Location = new System.Drawing.Point(120, 8);
			this.Audio_Output.Name = "Audio_Output";
			this.Audio_Output.Size = new System.Drawing.Size(121, 20);
			this.Audio_Output.TabIndex = 0;
			this.Audio_Output.Text = "dsound";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "聲音輸出驅動程式";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_close
			// 
			this.btn_close.Location = new System.Drawing.Point(296, 312);
			this.btn_close.Name = "btn_close";
			this.btn_close.TabIndex = 1;
			this.btn_close.Text = "關閉";
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// Video_DirectRandering
			// 
			this.Video_DirectRandering.Location = new System.Drawing.Point(8, 104);
			this.Video_DirectRandering.Name = "Video_DirectRandering";
			this.Video_DirectRandering.TabIndex = 4;
			this.Video_DirectRandering.Text = "Direct Rendering";
			// 
			// OptionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(376, 341);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OptionForm";
			this.Text = "Power Mplayer 選項";
			this.tabControl1.ResumeLayout(false);
			this.tp_general.ResumeLayout(false);
			this.tp_video.ResumeLayout(false);
			this.tp_audio.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Audio_Softvol_max)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadSetting()
		{
			if(msetting[SetVars.MplayerExe] != "")
				this.txt_mplayer_cmd.Text = msetting[SetVars.MplayerExe];

			this.Audio_Output.Text = this.msetting[SetVars.AO];
			this.Audio_Softvol.Checked = (this.msetting[SetVars.Audio_Softvol] == "1") ? true : false;
			
			this.Audio_Softvol_max.Enabled = this.Audio_Softvol.Checked;
			this.Audio_Softvol_max.Value = decimal.Parse(this.msetting[SetVars.Audio_SoftvolMax]);

			this.Video_Output.Text = this.msetting[SetVars.VO];
			this.Video_DirectRandering.Checked = this.msetting[SetVars.Video_DR] == "1" ? true : false;

			return;
		}

		private void btn_browse_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != "")
			{
				this.txt_mplayer_cmd.Text = this.openFileDialog1.FileName;
			}
		}

		private void btn_close_Click(object sender, System.EventArgs e)
		{
			this.msetting[SetVars.MplayerExe] = this.txt_mplayer_cmd.Text;

			this.msetting[SetVars.AO] = this.Audio_Output.Text;
			this.msetting[SetVars.Audio_Softvol] = (this.Audio_Softvol.Checked) ? "1" : "0";
			this.msetting[SetVars.Audio_SoftvolMax] = this.Audio_Softvol_max.Value.ToString();

			this.msetting[SetVars.VO] = this.Video_Output.Text;
			this.msetting[SetVars.Video_DR] = this.Video_DirectRandering.Checked ? "1" : "0";

			this.msetting.WriteSetting();
			this.Dispose();
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
	}
}
