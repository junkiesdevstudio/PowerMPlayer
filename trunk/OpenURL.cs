using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Power_Mplayer
{
	/// <summary>
	/// OpenURL 的摘要描述。
	/// </summary>
	public class OpenURL : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.Container components = null;

		// constructure
		public OpenURL()
		{
			InitializeComponent();

			// paste URL from clipboard 
			IDataObject iData = Clipboard.GetDataObject();

			if(iData.GetDataPresent(DataFormats.Text)) 
			{
				// Yes it is, so display it in a text box.
				textBox1.Text = (string) iData.GetData(DataFormats.Text); 
			}

			this.textBox1.SelectAll();
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(72, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(288, 22);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "請輸入您所要播放的 URL 或路徑 (包括 http:// 或 mms:// 或 rstp:// )";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "開啟:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(208, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "確定";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(288, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 4;
			this.button2.Text = "取消";
			// 
			// OpenURL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(376, 103);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenURL";
			this.Text = "開啟 URL";
			this.ResumeLayout(false);

		}
		#endregion

		public string URL
		{
			get
			{
				return this.textBox1.Text;
			}
		}
	}
}
