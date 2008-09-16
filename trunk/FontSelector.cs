using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Power_Mplayer
{
	/// <summary>
	/// FontSelector ���K�n�y�z�C
	/// </summary>
	public class FontSelector : System.Windows.Forms.Form
	{
		public const string FontRoot = @"%SystemRoot%\Fonts\";
		private MplayerSetting msetting;		

		private PrivateFontCollection[] privateFontCollection;
		private System.Collections.ArrayList fontList;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btn_Cancel;
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

		public string FontPath
		{
			get
			{
				return this.textBox1.Text;
			}
			set
			{
				this.textBox1.Text = value;
			}
		}

		/// <summary>
		/// Constructure
		/// </summary>
		public FontSelector()
		{
			//
			// Windows Form Controls
			//
			InitializeComponent();

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

				// clear arraylist
				this.fontList.Clear();
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btn_browse = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(8, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(208, 208);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// btn_OK
			// 
			this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_OK.Location = new System.Drawing.Point(224, 32);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(72, 24);
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "�T�w";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "�п�ܦr���Υ��s����ܦr����";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 248);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(208, 22);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// btn_browse
			// 
			this.btn_browse.Location = new System.Drawing.Point(224, 248);
			this.btn_browse.Name = "btn_browse";
			this.btn_browse.Size = new System.Drawing.Size(72, 23);
			this.btn_browse.TabIndex = 4;
			this.btn_browse.Text = "�s��";
			this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(224, 64);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(72, 24);
			this.btn_Cancel.TabIndex = 5;
			this.btn_Cancel.Text = " ����";
			// 
			// FontSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(306, 282);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_browse);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FontSelector";
			this.Text = "��ܦr��";
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
			string FontDir = System.Environment.ExpandEnvironmentVariables(FontRoot);
			string[] files = System.IO.Directory.GetFiles(FontDir);
			
			for(int i=0;i<files.Length;i++)
			{
				//string tmp = Path.GetExtension(files[i]).ToLower();
				string ext = Path.GetExtension(files[i]).ToLower();
				
				if(ext == ".ttf" || ext == ".ttc")
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

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.textBox1.Text = (string) this.fontList[this.listBox1.SelectedIndex];
		}

		private void btn_browse_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.Filter = "TrueType �r��|*.ttf, *.ttc";
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != null && this.openFileDialog1.FileName != "")
			{
				this.textBox1.Text = this.openFileDialog1.FileName;
			}
		}

	}
}
