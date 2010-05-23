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
		/// <summary>
		/// 設計工具所需的變數。
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
