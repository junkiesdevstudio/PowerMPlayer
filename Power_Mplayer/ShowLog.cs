using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// ShowLog ���K�n�y�z�C
	/// </summary>
	public class ShowLog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox1;
		/// <summary>
		/// �]�p�u��һݪ��ܼơC
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string Log
		{
			set
			{
				this.richTextBox1.Text = value;
			}
		}

		public ShowLog()
		{
			//
			// Windows Form �]�p�u��䴩�����n��
			//
			InitializeComponent();

			//
			// TODO: �b InitializeComponent �I�s����[�J����غc�禡�{���X
			//
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(80, 72);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// ShowLog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.richTextBox1);
			this.Name = "ShowLog";
			this.Text = "ShowLog";
			this.Resize += new System.EventHandler(this.ShowLog_Resize);
			this.Load += new System.EventHandler(this.ShowLog_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowLog_Load(object sender, System.EventArgs e)
		{
			this.richTextBox1.Top = 0;
			this.richTextBox1.Left = 0;

			ShowLog_Resize(sender, e);
		}

		private void ShowLog_Resize(object sender, System.EventArgs e)
		{
            this.richTextBox1.Height = this.ClientSize.Height;
            this.richTextBox1.Width = this.ClientSize.Width;
		}
	}
}
