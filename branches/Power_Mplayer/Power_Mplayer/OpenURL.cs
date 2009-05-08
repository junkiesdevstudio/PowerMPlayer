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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenURL));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
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
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// button1
			// 
			this.button1.AccessibleDescription = null;
			this.button1.AccessibleName = null;
			resources.ApplyResources(this.button1, "button1");
			this.button1.BackgroundImage = null;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = null;
			this.button1.Name = "button1";
			// 
			// button2
			// 
			this.button2.AccessibleDescription = null;
			this.button2.AccessibleName = null;
			resources.ApplyResources(this.button2, "button2");
			this.button2.BackgroundImage = null;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = null;
			this.button2.Name = "button2";
			// 
			// OpenURL
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenURL";
			this.ResumeLayout(false);
			this.PerformLayout();

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
