using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Power_Mplayer
{
	/// <summary>
	/// Form1 的摘要描述。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel BigScreen;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btn_play;
		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.TrackBar VolumeBar;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ProgressBar MovieBar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private Mplayer mp;

		public Form1()
		{
			//
			// Windows Form 設計工具支援的必要項
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 呼叫之後加入任何建構函式程式碼
			//
			mp = new Mplayer(this.BigScreen);
		}

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.btn_play = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.BigScreen = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.VolumeBar = new System.Windows.Forms.TrackBar();
			this.btn_stop = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.MovieBar = new System.Windows.Forms.ProgressBar();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_play
			// 
			this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_play.Location = new System.Drawing.Point(16, 88);
			this.btn_play.Name = "btn_play";
			this.btn_play.Size = new System.Drawing.Size(40, 23);
			this.btn_play.TabIndex = 0;
			this.btn_play.Text = "Play";
			this.btn_play.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(96, 88);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Pause";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// BigScreen
			// 
			this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(1)), ((System.Byte)(1)), ((System.Byte)(1)));
			this.BigScreen.Location = new System.Drawing.Point(0, 0);
			this.BigScreen.Name = "BigScreen";
			this.BigScreen.Size = new System.Drawing.Size(168, 136);
			this.BigScreen.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.MovieBar);
			this.panel1.Controls.Add(this.statusBar1);
			this.panel1.Controls.Add(this.VolumeBar);
			this.panel1.Controls.Add(this.btn_stop);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.btn_play);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 273);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(568, 144);
			this.panel1.TabIndex = 3;
			// 
			// VolumeBar
			// 
			this.VolumeBar.Location = new System.Drawing.Point(456, 80);
			this.VolumeBar.Name = "VolumeBar";
			this.VolumeBar.TabIndex = 5;
			this.VolumeBar.Value = 10;
			this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
			// 
			// btn_stop
			// 
			this.btn_stop.Location = new System.Drawing.Point(200, 88);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.TabIndex = 3;
			this.btn_stop.Text = "Stop";
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(280, 88);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Text = "Log";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.MainPanel.Controls.Add(this.BigScreen);
			this.MainPanel.Location = new System.Drawing.Point(8, 16);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(264, 208);
			this.MainPanel.TabIndex = 4;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Open File";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Open &DVD";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "&Exit";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "&Play";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9});
			this.menuItem7.Text = "&Tools";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 3;
			this.menuItem8.Text = "&Help";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "Options";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 120);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(568, 24);
			this.statusBar1.TabIndex = 6;
			this.statusBar1.Text = "statusBar1";
			// 
			// MovieBar
			// 
			this.MovieBar.Location = new System.Drawing.Point(8, 48);
			this.MovieBar.Name = "MovieBar";
			this.MovieBar.TabIndex = 7;
			this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(568, 417);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.panel1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 應用程式的主進入點。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string filename = @"C:\mplayer\film.rmvb";
			
			mp.Start(filename);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			mp.Pause();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			MainPanel.Top = 0;
			MainPanel.Left = 0;

			BigScreen.Top = 0;
			BigScreen.Left = 0;

			MovieBar.Left = 0;

			this.Form1_Resize(sender, e);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			MovieBar.Width = panel1.Width;
			VolumeBar.Left = panel1.Width - VolumeBar.Width;

			MainPanel.Height = this.Height - this.panel1.Height;
			MainPanel.Width = this.Width;

			BigScreen.Height = MainPanel.Height;
			BigScreen.Width = MainPanel.Width;

			//MessageBox.Show(mp.Width.ToString());
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			mp.Quit();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ShowLog sl = new ShowLog();

			sl.Log = mp.Read();
			sl.Show();
		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			double a = mp.Length;

		}


		private void VolumeBar_Scroll(object sender, System.EventArgs e)
		{
			mp.Volume = VolumeBar.Value;
		}

		private void MovieBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			MovieBar.Value = 100 * e.X / MovieBar.Width;

			mp.Percent_Pos = MovieBar.Value;
		}

	}
}
