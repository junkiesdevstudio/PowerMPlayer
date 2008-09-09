using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// OptionForm ���K�n�y�z�C
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
		/// �]�p�u��һݪ��ܼơC
		/// </summary>
		private System.ComponentModel.Container components = null;

		private MplayerSetting msetting;

		public OptionForm(MplayerSetting ms)
		{
			//
			// Windows Form �]�p�u��䴩�����n��
			//
			InitializeComponent();

			//
			// TODO: �b InitializeComponent �I�s����[�J����غc�禡�{���X
			//
			this.msetting = ms;

			this.LoadSetting();
		}

		/// <summary>
		/// �M������ϥΤ����귽�C
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

		#region Windows Form �]�p�u�㲣�ͪ��{���X
		/// <summary>
		/// �����]�p�u��䴩�ҥ�������k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tp_general = new System.Windows.Forms.TabPage();
			this.tp_video = new System.Windows.Forms.TabPage();
			this.tp_audio = new System.Windows.Forms.TabPage();
			this.btn_close = new System.Windows.Forms.Button();
			this.txt_mplayer_cmd = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tp_general.SuspendLayout();
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
			this.tp_general.Text = "�@��";
			// 
			// tp_video
			// 
			this.tp_video.Location = new System.Drawing.Point(4, 21);
			this.tp_video.Name = "tp_video";
			this.tp_video.Size = new System.Drawing.Size(368, 271);
			this.tp_video.TabIndex = 1;
			this.tp_video.Text = "�v��";
			// 
			// tp_audio
			// 
			this.tp_audio.Location = new System.Drawing.Point(4, 21);
			this.tp_audio.Name = "tp_audio";
			this.tp_audio.Size = new System.Drawing.Size(368, 271);
			this.tp_audio.TabIndex = 2;
			this.tp_audio.Text = "�n��";
			// 
			// btn_close
			// 
			this.btn_close.Location = new System.Drawing.Point(296, 312);
			this.btn_close.Name = "btn_close";
			this.btn_close.TabIndex = 1;
			this.btn_close.Text = "����";
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// txt_mplayer_cmd
			// 
			this.txt_mplayer_cmd.Location = new System.Drawing.Point(88, 16);
			this.txt_mplayer_cmd.Name = "txt_mplayer_cmd";
			this.txt_mplayer_cmd.Size = new System.Drawing.Size(216, 22);
			this.txt_mplayer_cmd.TabIndex = 0;
			this.txt_mplayer_cmd.Text = ".\\mplayer.exe";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mplayer ��m:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(312, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "�s��";
			this.button2.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// OptionForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(376, 341);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OptionForm";
			this.Text = "Power Mplayer �ﶵ";
			this.tabControl1.ResumeLayout(false);
			this.tp_general.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadSetting()
		{
			if(msetting[MplayerSetting.MPLAYER_EXE] != "")
				this.txt_mplayer_cmd.Text = msetting[MplayerSetting.MPLAYER_EXE];

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
			this.msetting[MplayerSetting.MPLAYER_EXE] = this.txt_mplayer_cmd.Text;

			this.msetting.WriteSetting();
			this.Dispose();
		}
	}
}
