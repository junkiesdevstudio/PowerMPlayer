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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontSelector));
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
            this.listBox1.AccessibleDescription = null;
            this.listBox1.AccessibleName = null;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.BackgroundImage = null;
            this.listBox1.Font = null;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = null;
            this.btn_OK.AccessibleName = null;
            resources.ApplyResources(this.btn_OK, "btn_OK");
            this.btn_OK.BackgroundImage = null;
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Font = null;
            this.btn_OK.Name = "btn_OK";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = null;
            this.textBox1.AccessibleName = null;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackgroundImage = null;
            this.textBox1.Font = null;
            this.textBox1.Name = "textBox1";
            // 
            // btn_browse
            // 
            this.btn_browse.AccessibleDescription = null;
            this.btn_browse.AccessibleName = null;
            resources.ApplyResources(this.btn_browse, "btn_browse");
            this.btn_browse.BackgroundImage = null;
            this.btn_browse.Font = null;
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = null;
            this.btn_Cancel.AccessibleName = null;
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.BackgroundImage = null;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Font = null;
            this.btn_Cancel.Name = "btn_Cancel";
            // 
            // FontSelector
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.listBox1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "FontSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

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
