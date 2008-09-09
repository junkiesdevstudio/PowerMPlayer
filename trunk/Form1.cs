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
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel BigScreen;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.TrackBar VolumeBar;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ProgressBar MovieBar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.StatusBarPanel statusPanel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btn_pause;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Button btn_mute;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItemFont;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem MI_NoSubAutoScale;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleHeight;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleWidth;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleDiagonal;
		private System.Windows.Forms.MenuItem MI_Option;
		private Mplayer mp;

		public Form1()
		{
			// Windows Form
			InitializeComponent();

			mp = new Mplayer(this.BigScreen);

			// setup subtitle setting
			string var = mp.Setting[MplayerSetting.SUB_AUTOSCALE];
			if(var == "0")
				this.MI_NoSubAutoScale.Checked = true;
			else if(var == "1")
				this.MI_SubAutoScaleHeight.Checked = true;
			else if(var == "2")
				this.MI_SubAutoScaleWidth.Checked = true;
			else if(var == "3")
				this.MI_SubAutoScaleDiagonal.Checked = true;

		}

		/// <summary>
		/// Clear all using resources
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			this.Quit();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.btn_pause = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.BigScreen = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_mute = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.VolumeBar = new System.Windows.Forms.TrackBar();
			this.btn_stop = new System.Windows.Forms.Button();
			this.MovieBar = new System.Windows.Forms.ProgressBar();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItemFont = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.MI_NoSubAutoScale = new System.Windows.Forms.MenuItem();
			this.MI_SubAutoScaleHeight = new System.Windows.Forms.MenuItem();
			this.MI_SubAutoScaleWidth = new System.Windows.Forms.MenuItem();
			this.MI_SubAutoScaleDiagonal = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.MI_Option = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_pause
			// 
			this.btn_pause.BackColor = System.Drawing.Color.Transparent;
			this.btn_pause.Enabled = false;
			this.btn_pause.ImageIndex = 1;
			this.btn_pause.ImageList = this.imageList1;
			this.btn_pause.Location = new System.Drawing.Point(0, 0);
			this.btn_pause.Name = "btn_pause";
			this.btn_pause.Size = new System.Drawing.Size(40, 40);
			this.btn_pause.TabIndex = 1;
			this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BigScreen
			// 
			this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(1)), ((System.Byte)(1)), ((System.Byte)(1)));
			this.BigScreen.Location = new System.Drawing.Point(0, 0);
			this.BigScreen.Name = "BigScreen";
			this.BigScreen.Size = new System.Drawing.Size(168, 136);
			this.BigScreen.TabIndex = 2;
			this.BigScreen.Click += new System.EventHandler(this.btn_pause_Click);
			this.BigScreen.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.btn_mute);
			this.panel1.Controls.Add(this.statusBar1);
			this.panel1.Controls.Add(this.VolumeBar);
			this.panel1.Controls.Add(this.btn_stop);
			this.panel1.Controls.Add(this.btn_pause);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 333);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(568, 64);
			this.panel1.TabIndex = 3;
			// 
			// btn_mute
			// 
			this.btn_mute.ImageIndex = 3;
			this.btn_mute.ImageList = this.imageList1;
			this.btn_mute.Location = new System.Drawing.Point(416, 0);
			this.btn_mute.Name = "btn_mute";
			this.btn_mute.Size = new System.Drawing.Size(40, 40);
			this.btn_mute.TabIndex = 9;
			this.btn_mute.Click += new System.EventHandler(this.btn_mute_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 40);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(568, 24);
			this.statusBar1.TabIndex = 6;
			this.statusBar1.Text = "aaa";
			// 
			// statusPanel1
			// 
			this.statusPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusPanel1.Width = 552;
			// 
			// VolumeBar
			// 
			this.VolumeBar.Location = new System.Drawing.Point(456, 8);
			this.VolumeBar.Name = "VolumeBar";
			this.VolumeBar.TabIndex = 5;
			this.VolumeBar.Value = 10;
			this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
			// 
			// btn_stop
			// 
			this.btn_stop.Enabled = false;
			this.btn_stop.ImageIndex = 2;
			this.btn_stop.ImageList = this.imageList1;
			this.btn_stop.Location = new System.Drawing.Point(40, 0);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(40, 40);
			this.btn_stop.TabIndex = 3;
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// MovieBar
			// 
			this.MovieBar.Location = new System.Drawing.Point(8, 296);
			this.MovieBar.Name = "MovieBar";
			this.MovieBar.Size = new System.Drawing.Size(100, 16);
			this.MovieBar.TabIndex = 7;
			this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.Color.Black;
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
																					  this.menuItem8,
																					  this.menuItem7,
																					  this.menuItem10});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "檔案(&F)";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "開啟檔案(&O)";
			this.menuItem2.Click += new System.EventHandler(this.Menu_OpenFile);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "離開(&E)";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "播放(&P)";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemFont,
																					  this.menuItem17,
																					  this.menuItem20,
																					  this.menuItem16,
																					  this.menuItem14});
			this.menuItem8.Text = "字幕(&S)";
			// 
			// menuItemFont
			// 
			this.menuItemFont.Index = 0;
			this.menuItemFont.Text = "字型";
			this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 1;
			this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem18,
																					   this.menuItem19});
			this.menuItem17.Text = "字幕編碼";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 0;
			this.menuItem18.Text = "BIG5";
			this.menuItem18.Click += new System.EventHandler(this.MI_SubEncoding);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.Text = "GB2312";
			this.menuItem19.Click += new System.EventHandler(this.MI_SubEncoding);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 2;
			this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.MI_NoSubAutoScale,
																					   this.MI_SubAutoScaleHeight,
																					   this.MI_SubAutoScaleWidth,
																					   this.MI_SubAutoScaleDiagonal});
			this.menuItem20.Text = "字幕自動調整";
			// 
			// MI_NoSubAutoScale
			// 
			this.MI_NoSubAutoScale.Index = 0;
			this.MI_NoSubAutoScale.Text = "無自動調整";
			this.MI_NoSubAutoScale.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
			// 
			// MI_SubAutoScaleHeight
			// 
			this.MI_SubAutoScaleHeight.Index = 1;
			this.MI_SubAutoScaleHeight.Text = "依高度自動調整";
			this.MI_SubAutoScaleHeight.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
			// 
			// MI_SubAutoScaleWidth
			// 
			this.MI_SubAutoScaleWidth.Index = 2;
			this.MI_SubAutoScaleWidth.Text = "依寬度自動調整";
			this.MI_SubAutoScaleWidth.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
			// 
			// MI_SubAutoScaleDiagonal
			// 
			this.MI_SubAutoScaleDiagonal.Index = 3;
			this.MI_SubAutoScaleDiagonal.Text = "依對角自動調整";
			this.MI_SubAutoScaleDiagonal.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 3;
			this.menuItem16.Text = "-";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 4;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15});
			this.menuItem14.Text = "選擇字幕";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "None";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.MI_Option});
			this.menuItem7.Text = "工具(&T)";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 0;
			this.menuItem11.Text = "Mplayer 紀錄";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 1;
			this.menuItem12.Text = "-";
			// 
			// MI_Option
			// 
			this.MI_Option.Index = 2;
			this.MI_Option.Text = "選項";
			this.MI_Option.Click += new System.EventHandler(this.MI_Option_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 4;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem13});
			this.menuItem10.Text = "說明(&H)";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 0;
			this.menuItem13.Text = "關於";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(568, 397);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MovieBar);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Power MPlayer";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusPanel1)).EndInit();
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

		private void btn_pause_Click(object sender, System.EventArgs e)
		{
			Pause();
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
			double aspect = 0;

			if(mp.HasInstense())
			{
				aspect = mp.Video_Aspect;
			}

			MovieBar.Top = panel1.Top - MovieBar.Height;
			MovieBar.Width = panel1.Width;
			VolumeBar.Left = panel1.Width - VolumeBar.Width;
			btn_mute.Left = VolumeBar.Left - btn_mute.Width;

			MainPanel.Height = this.Height - this.panel1.Height - this.MovieBar.Height - this.statusBar1.Height * 2;
			MainPanel.Width = this.Width;

			if(aspect == 0)
			{
				BigScreen.Height = MainPanel.Height;
				BigScreen.Width = MainPanel.Width;
			}
			else
			{
				double now_aspect = (double) MainPanel.Width / MainPanel.Height;

				if(now_aspect < aspect)
				{
					BigScreen.Width = MainPanel.Width;
					BigScreen.Height = (int) (BigScreen.Width / aspect);
				}
				else
				{
					BigScreen.Height = MainPanel.Height;
					BigScreen.Width = (int) (BigScreen.Height * aspect);
				}

				BigScreen.Left = (MainPanel.Width - BigScreen.Width) / 2;
				BigScreen.Top = (MainPanel.Height - BigScreen.Height) / 2;
			}

			//MessageBox.Show(mp.Width.ToString());
		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			Stop();
		}


		private void VolumeBar_Scroll(object sender, System.EventArgs e)
		{
			mp.Volume = VolumeBar.Value;
			btn_mute.ImageIndex = 3;
		}

		private void MovieBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//MovieBar.Value = 100 * e.X / MovieBar.Width;
			//mp.Percent_Pos = MovieBar.Value;
			
			int val = 100 * e.X / MovieBar.Width;

			mp.Percent_Pos = val;
			MovieBar.Value = val;
		}

		#region GUI Movie Control

		private void Start(string filename)
		{
			if(mp.HasInstense())
				Quit();

			if(mp.Start(this.openFileDialog1.FileName))
			{
				this.Form1_Resize(null, null);

				this.Text = System.IO.Path.GetFileName(mp.Filename);

				this.btn_pause.Enabled = true;
				this.btn_stop.Enabled = true;
				this.btn_pause.ImageIndex = 1;

				timer1.Start();
			}
		}

		private void Pause()
		{
			if(mp.HasInstense())
			{
				mp.Pause();

				if(btn_pause.ImageIndex == 0)
				{
					timer1.Start();
					btn_pause.ImageIndex = 1;
				}
				else
				{
					timer1.Stop();
					btn_pause.ImageIndex = 0;
				}
			}
		}

		private void Stop()
		{
			if(mp.HasInstense())
				mp.Stop();

			timer1.Stop();
			btn_pause.ImageIndex = 0;
			MovieBar.Value = 0;
		}

		private void Quit()
		{
			Stop();
			mp.Quit();
		}

		private void Restart()
		{
			if(mp.HasInstense())
			{
				double pos = mp.Time_Pos - 0.5;
				bool paused = (btn_pause.ImageIndex == 0) ? true : false;
				string filename = mp.Filename;
				int movieBar = MovieBar.Value;

				Quit();
				Start(filename);

				MovieBar.Value = movieBar;
				mp.Time_Pos = pos;

				if(paused)
					Pause();
			}
		}

		#endregion

		// Open File
		private void Menu_OpenFile(object sender, System.EventArgs e)
		{
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != null && this.openFileDialog1.FileName != "")
			{
				Start(this.openFileDialog1.FileName);
			}
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			ShowLog sl = new ShowLog();

			sl.Log = mp.Read();
			sl.Show();
		}

		private void btn_mute_Click(object sender, System.EventArgs e)
		{
			// Volume
			if(mp.Mute() == true) 
			{
				btn_mute.ImageIndex = 4;
			}
			else
			{
				btn_mute.ImageIndex = 3;
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
				int now_pos = (int) mp.Time_Pos;
				int movie_len = (int) mp.Length;

				string str_now_pos = (now_pos / 3600) + ":" + ((now_pos / 60) % 60)+ ":" + (now_pos % 60);
				string str_movie_len = (movie_len / 3600) + ":" + ((movie_len / 60) % 60) + ":" + (movie_len % 60);

				this.statusPanel1.Text = str_now_pos + " / " + str_movie_len;
				this.MovieBar.Value = (100 * now_pos) / movie_len;
			}
		}

		private void BigScreen_DoubleClick(object sender, System.EventArgs e)
		{
			//mp.FullScreen();
		}

		private void menuItemFont_Click(object sender, System.EventArgs e)
		{
			FontSelector fontSelect = new FontSelector(mp.Setting);
			fontSelect.ShowDialog();

			Restart();
		}

		// sub-autoscale
		private void MI_SubAutoScale_Click(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;

			this.MI_SubAutoScaleHeight.Checked = false;
			this.MI_SubAutoScaleWidth.Checked = false;
			this.MI_SubAutoScaleDiagonal.Checked = false;
			this.MI_NoSubAutoScale.Checked = false;

			switch(mi.Index)
			{
				case 0:
					this.MI_NoSubAutoScale.Checked = true;
					break;
				case 1:
					this.MI_SubAutoScaleHeight.Checked = true;
					break;
				case 2:
					this.MI_SubAutoScaleWidth.Checked = true;
					break;
				case 3:
					this.MI_SubAutoScaleDiagonal.Checked = true;
					break;
			}

			mp.Setting[MplayerSetting.SUB_AUTOSCALE] = mi.Index.ToString();
			mp.Setting.WriteSetting();
		}

		private void MI_Option_Click(object sender, System.EventArgs e)
		{
			OptionForm opt_form = new OptionForm(mp.Setting);

			opt_form.ShowDialog();
		}

		private void MI_SubEncoding(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;

			mp.Setting[MplayerSetting.SUB_ENCODING] = mi.Text;
			mp.Setting.WriteSetting();

			Restart();
			
		}

	}
}
