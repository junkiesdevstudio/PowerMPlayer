using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// ShowLog 的摘要描述。
	/// </summary>
	public class ShowLog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox2;
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string Stdout
		{
			set
			{
				this.richTextBox1.Text = value;
			}
		}

        public string Stderr
        {
            set
            {
                this.richTextBox2.Text = value;
            }
        }

		public ShowLog()
		{
			//
			// Windows Form 設計工具支援的必要項
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 呼叫之後加入任何建構函式程式碼
			//
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(35, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(41, 7);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(100, 96);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // ShowLog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(437, 428);
            this.Controls.Add(this.tabControl1);
            this.Name = "ShowLog";
            this.Text = "ShowLog";
            this.Load += new System.EventHandler(this.ShowLog_Load);
            this.Resize += new System.EventHandler(this.ShowLog_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ShowLog_Load(object sender, System.EventArgs e)
		{
            this.tabControl1.Left = 0;
            this.tabControl1.Top = 0;

            richTextBox1.Left = richTextBox1.Top = 0;
            richTextBox2.Left = richTextBox2.Top = 0;

			ShowLog_Resize(sender, e);
		}

		private void ShowLog_Resize(object sender, System.EventArgs e)
		{
            this.tabControl1.Height = this.ClientSize.Height;
            this.tabControl1.Width = this.ClientSize.Width;

            this.richTextBox1.Height = this.tabPage1.ClientSize.Height;
            this.richTextBox1.Width = this.tabPage1.ClientSize.Width;

            this.richTextBox2.Height = this.tabPage2.ClientSize.Height;
            this.richTextBox2.Width = this.tabPage2.ClientSize.Width;
		}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLog_Resize(sender, e);
        }
	}
}
