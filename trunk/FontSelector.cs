using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Power_Mplayer
{
	/// <summary>
	/// FontSelector ���K�n�y�z�C
	/// </summary>
	public class FontSelector : System.Windows.Forms.Form
	{
		private PrivateFontCollection[] privateFontCollection;
		private System.Collections.ArrayList fontList;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// �]�p�u��һݪ��ܼơC
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int SelectIndex
		{
			get
			{
				return this.listBox1.SelectedIndex;
			}
		}

		public FontSelector()
		{
			//
			// Windows Form �]�p�u��䴩�����n��
			//
			InitializeComponent();

			//
			// TODO: �b InitializeComponent �I�s����[�J����غc�禡�{���X
			//
			fontList = new System.Collections.ArrayList();

			LoadAllFonts();
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btn_OK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(8, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(208, 244);
			this.listBox1.TabIndex = 0;
			// 
			// btn_OK
			// 
			this.btn_OK.Location = new System.Drawing.Point(232, 40);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(80, 24);
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "�T�w";
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "�п�ܦr��";
			// 
			// FontSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(320, 293);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FontSelector";
			this.Text = "FontSelector";
			this.ResumeLayout(false);

		}
		#endregion

		private string FontName(FontFamily ff)
		{
			string result = ff.Name;

			if(ff.IsStyleAvailable(FontStyle.Regular))
				result += "";
			else if(ff.IsStyleAvailable(FontStyle.Bold))
				result += " ����";
			else if(ff.IsStyleAvailable(FontStyle.Italic))
				result += " ����";
			else if(ff.IsStyleAvailable(FontStyle.Italic | FontStyle.Bold))
				result += " �ʱ���";
			else if(ff.IsStyleAvailable(FontStyle.Underline))
				result += " ���u";
			else if(ff.IsStyleAvailable(FontStyle.Strikeout))
				result += " �R���u";

			return result;

		}

		private void LoadAllFonts()
		{
			string FontDir = @"C:\Windows\Fonts\";
			string[] files = System.IO.Directory.GetFiles(FontDir);
			
			for(int i=0;i<files.Length;i++)
			{
				//string tmp = Path.GetExtension(files[i]).ToLower();
				if(Path.GetExtension(files[i]).ToLower() != ".ttf")
					continue;

				fontList.Add(files[i]);

			}

			this.privateFontCollection = new PrivateFontCollection[fontList.Count];

			for(int i=0;i<fontList.Count;i++)
			{
				this.privateFontCollection[i] = new PrivateFontCollection();
				this.privateFontCollection[i].AddFontFile((string) fontList[i]);

				this.listBox1.Items.Add(FontName(this.privateFontCollection[i].Families[0]));
			}

		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

	}
}
