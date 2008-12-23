using System;
using System.IO;
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
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ProgressBar MovieBar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.StatusBarPanel statusPanel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btn_pause;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.Button btn_mute;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuItem menuItemFont;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem MI_NoSubAutoScale;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleHeight;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleWidth;
		private System.Windows.Forms.MenuItem MI_SubAutoScaleDiagonal;
		private System.Windows.Forms.MenuItem MI_Option;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem MI_SubDelayLess;
		private System.Windows.Forms.MenuItem MI_SubDelayMore;
		private System.Windows.Forms.MenuItem MI_SubPosUp;
		private System.Windows.Forms.MenuItem MI_SubPosDown;
		private System.Windows.Forms.MenuItem MI_SubScaleDown;
		private System.Windows.Forms.MenuItem MI_SubScaleUp;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem MI_OpenSubFile;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem MI_SelectSubtitle;
		private System.Windows.Forms.MenuItem MI_Exit;
		private System.Windows.Forms.MenuItem MI_ASS;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem MI_SubEncoding;
		private System.Windows.Forms.MenuItem MI_About;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem MI_Fullscreen;
		private System.Windows.Forms.MenuItem MI_BrightnessMore;
		private System.Windows.Forms.MenuItem MI_BrightnessLess;
		private System.Windows.Forms.MenuItem MI_ContrastMore;
		private System.Windows.Forms.MenuItem MI_ContrastLess;
		private System.Windows.Forms.MenuItem MI_TopMost;
		private System.Windows.Forms.MenuItem MI_OpenFile;
		private System.Windows.Forms.MenuItem MI_OpenURL;
		private Mplayer mp;
		private OptionForm optForm;
		private System.Windows.Forms.MenuItem MI_Brightness;
		private System.Windows.Forms.MenuItem MI_Contrast;
		private System.Windows.Forms.MenuItem MI_Gamma;
		private System.Windows.Forms.MenuItem MI_Hue;
		private System.Windows.Forms.MenuItem MI_Saturation;
		private System.Windows.Forms.MenuItem MI_GammaLess;
		private System.Windows.Forms.MenuItem MI_GammaMore;
		private System.Windows.Forms.MenuItem MI_HueLess;
		private System.Windows.Forms.MenuItem MI_HueMore;
		private System.Windows.Forms.MenuItem MI_SaturationLess;
		private System.Windows.Forms.MenuItem MI_SaturationMore;
		private System.Windows.Forms.ListView Playlist;
		private System.Windows.Forms.MenuItem MI_ShowPlaylist;
		private System.Windows.Forms.Panel splitter1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem MI_Zoom;
		private System.Windows.Forms.MenuItem MI_Zoom50;
		private System.Windows.Forms.MenuItem MI_Zoom100;
		private System.Windows.Forms.MenuItem MI_Zoom200;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem MI_File;
		private System.Windows.Forms.MenuItem MI_Play;
		private System.Windows.Forms.MenuItem MI_Video;
		private System.Windows.Forms.MenuItem MI_Audio;
		private System.Windows.Forms.MenuItem MI_Subtitle;
		private System.Windows.Forms.MenuItem MI_Tools;
		private System.Windows.Forms.MenuItem MI_Help;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem MI_FixSize;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem MI_LastOpen;
		private System.Windows.Forms.TextBox txtShortcut;
		private System.Windows.Forms.Button btn_despeed;
		private System.Windows.Forms.Button btn_inspeed;
        private MenuItem menuItem7;
        private MenuItem MI_Screenshot;
        private SaveFileDialog saveFileDialog1;
		private FontSelector fontSelect;

		// constructure
		private Form1()
		{
			// Windows Form
			InitializeComponent();

			mp = new Mplayer(this.BigScreen);

			// setup subtitle setting
			string var = mp.Setting[SetVars.SubAutoScale];
			if(var == "0")
				this.MI_NoSubAutoScale.Checked = true;
			else if(var == "1")
				this.MI_SubAutoScaleHeight.Checked = true;
			else if(var == "2")
				this.MI_SubAutoScaleWidth.Checked = true;
			else if(var == "3")
				this.MI_SubAutoScaleDiagonal.Checked = true;

			var = mp.Setting[SetVars.SubASS];
			if(var == "1")
				this.MI_ASS.Checked = true;

			var = mp.Setting[SetVars.SubEncoding];
			foreach(MenuItem mi in this.MI_SubEncoding.MenuItems)
			{
				if(mi.Text.StartsWith(var))
				{
					mi.Checked = true;
					break;
				}
			}
		}

		public Form1(string[] str) : this()
		{
			if(str != null && str.Length > 0)
			{
				this.Playlist_AddItem(str);
				this.Start(mp.Playlist.First());
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_pause = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BigScreen = new System.Windows.Forms.Panel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_inspeed = new System.Windows.Forms.Button();
            this.btn_despeed = new System.Windows.Forms.Button();
            this.btn_mute = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.MovieBar = new System.Windows.Forms.ProgressBar();
            this.txtShortcut = new System.Windows.Forms.TextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MI_File = new System.Windows.Forms.MenuItem();
            this.MI_OpenFile = new System.Windows.Forms.MenuItem();
            this.MI_OpenURL = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.MI_LastOpen = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.MI_Exit = new System.Windows.Forms.MenuItem();
            this.MI_Play = new System.Windows.Forms.MenuItem();
            this.MI_ShowPlaylist = new System.Windows.Forms.MenuItem();
            this.MI_TopMost = new System.Windows.Forms.MenuItem();
            this.MI_Fullscreen = new System.Windows.Forms.MenuItem();
            this.MI_Video = new System.Windows.Forms.MenuItem();
            this.MI_Zoom = new System.Windows.Forms.MenuItem();
            this.MI_Zoom50 = new System.Windows.Forms.MenuItem();
            this.MI_Zoom100 = new System.Windows.Forms.MenuItem();
            this.MI_Zoom200 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.MI_FixSize = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.MI_Brightness = new System.Windows.Forms.MenuItem();
            this.MI_BrightnessLess = new System.Windows.Forms.MenuItem();
            this.MI_BrightnessMore = new System.Windows.Forms.MenuItem();
            this.MI_Contrast = new System.Windows.Forms.MenuItem();
            this.MI_ContrastLess = new System.Windows.Forms.MenuItem();
            this.MI_ContrastMore = new System.Windows.Forms.MenuItem();
            this.MI_Gamma = new System.Windows.Forms.MenuItem();
            this.MI_GammaLess = new System.Windows.Forms.MenuItem();
            this.MI_GammaMore = new System.Windows.Forms.MenuItem();
            this.MI_Hue = new System.Windows.Forms.MenuItem();
            this.MI_HueLess = new System.Windows.Forms.MenuItem();
            this.MI_HueMore = new System.Windows.Forms.MenuItem();
            this.MI_Saturation = new System.Windows.Forms.MenuItem();
            this.MI_SaturationLess = new System.Windows.Forms.MenuItem();
            this.MI_SaturationMore = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.MI_Screenshot = new System.Windows.Forms.MenuItem();
            this.MI_Audio = new System.Windows.Forms.MenuItem();
            this.MI_Subtitle = new System.Windows.Forms.MenuItem();
            this.MI_SelectSubtitle = new System.Windows.Forms.MenuItem();
            this.MI_OpenSubFile = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItemFont = new System.Windows.Forms.MenuItem();
            this.MI_SubEncoding = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.MI_NoSubAutoScale = new System.Windows.Forms.MenuItem();
            this.MI_SubAutoScaleHeight = new System.Windows.Forms.MenuItem();
            this.MI_SubAutoScaleWidth = new System.Windows.Forms.MenuItem();
            this.MI_SubAutoScaleDiagonal = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.MI_SubDelayLess = new System.Windows.Forms.MenuItem();
            this.MI_SubDelayMore = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.MI_SubPosUp = new System.Windows.Forms.MenuItem();
            this.MI_SubPosDown = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.MI_SubScaleDown = new System.Windows.Forms.MenuItem();
            this.MI_SubScaleUp = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.MI_ASS = new System.Windows.Forms.MenuItem();
            this.MI_Tools = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.MI_Option = new System.Windows.Forms.MenuItem();
            this.MI_Help = new System.Windows.Forms.MenuItem();
            this.MI_About = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Playlist = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // BigScreen
            // 
            this.BigScreen.AllowDrop = true;
            this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BigScreen.ContextMenu = this.contextMenu1;
            this.BigScreen.Location = new System.Drawing.Point(0, 0);
            this.BigScreen.Name = "BigScreen";
            this.BigScreen.Size = new System.Drawing.Size(168, 136);
            this.BigScreen.TabIndex = 2;
            this.BigScreen.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
            this.BigScreen.Click += new System.EventHandler(this.btn_pause_Click);
            this.BigScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BigScreen_MouseMove);
            this.BigScreen.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
            this.BigScreen.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_inspeed);
            this.panel1.Controls.Add(this.btn_despeed);
            this.panel1.Controls.Add(this.btn_mute);
            this.panel1.Controls.Add(this.statusBar1);
            this.panel1.Controls.Add(this.VolumeBar);
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_pause);
            this.panel1.Controls.Add(this.MovieBar);
            this.panel1.Controls.Add(this.txtShortcut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 64);
            this.panel1.TabIndex = 4;
            // 
            // btn_inspeed
            // 
            this.btn_inspeed.Enabled = false;
            this.btn_inspeed.ImageIndex = 5;
            this.btn_inspeed.ImageList = this.imageList1;
            this.btn_inspeed.Location = new System.Drawing.Point(128, 0);
            this.btn_inspeed.Name = "btn_inspeed";
            this.btn_inspeed.Size = new System.Drawing.Size(40, 40);
            this.btn_inspeed.TabIndex = 11;
            this.btn_inspeed.Click += new System.EventHandler(this.btn_inspeed_Click);
            // 
            // btn_despeed
            // 
            this.btn_despeed.Enabled = false;
            this.btn_despeed.ImageIndex = 6;
            this.btn_despeed.ImageList = this.imageList1;
            this.btn_despeed.Location = new System.Drawing.Point(88, 0);
            this.btn_despeed.Name = "btn_despeed";
            this.btn_despeed.Size = new System.Drawing.Size(40, 40);
            this.btn_despeed.TabIndex = 10;
            this.btn_despeed.Click += new System.EventHandler(this.btn_despeed_Click);
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
            this.statusPanel1.Name = "statusPanel1";
            this.statusPanel1.Width = 552;
            // 
            // VolumeBar
            // 
            this.VolumeBar.LargeChange = 2;
            this.VolumeBar.Location = new System.Drawing.Point(456, 8);
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(104, 42);
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
            this.MovieBar.Location = new System.Drawing.Point(224, 16);
            this.MovieBar.Name = "MovieBar";
            this.MovieBar.Size = new System.Drawing.Size(100, 16);
            this.MovieBar.TabIndex = 7;
            this.MovieBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseDown);
            this.MovieBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseMove);
            this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
            // 
            // txtShortcut
            // 
            this.txtShortcut.BackColor = System.Drawing.Color.Gold;
            this.txtShortcut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShortcut.Location = new System.Drawing.Point(336, 16);
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.Size = new System.Drawing.Size(48, 15);
            this.txtShortcut.TabIndex = 7;
            this.txtShortcut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyUp);
            this.txtShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyDown);
            // 
            // MainPanel
            // 
            this.MainPanel.AllowDrop = true;
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.ContextMenu = this.contextMenu1;
            this.MainPanel.Controls.Add(this.BigScreen);
            this.MainPanel.Location = new System.Drawing.Point(8, 16);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(248, 216);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
            this.MainPanel.Click += new System.EventHandler(this.btn_pause_Click);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            this.MainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
            this.MainPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_File,
            this.MI_Play,
            this.MI_Video,
            this.MI_Audio,
            this.MI_Subtitle,
            this.MI_Tools,
            this.MI_Help});
            // 
            // MI_File
            // 
            this.MI_File.Index = 0;
            this.MI_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_OpenFile,
            this.MI_OpenURL,
            this.menuItem6,
            this.MI_LastOpen,
            this.menuItem4,
            this.MI_Exit});
            this.MI_File.Text = "檔案(&F)";
            // 
            // MI_OpenFile
            // 
            this.MI_OpenFile.Index = 0;
            this.MI_OpenFile.Text = "開啟檔案(&O)";
            this.MI_OpenFile.Click += new System.EventHandler(this.Menu_OpenFile);
            // 
            // MI_OpenURL
            // 
            this.MI_OpenURL.Index = 1;
            this.MI_OpenURL.Text = "開啟 URL";
            this.MI_OpenURL.Click += new System.EventHandler(this.MI_OpenURL_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // MI_LastOpen
            // 
            this.MI_LastOpen.Index = 3;
            this.MI_LastOpen.Text = "前次開啟";
            this.MI_LastOpen.Click += new System.EventHandler(this.MI_LastOpen_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // MI_Exit
            // 
            this.MI_Exit.Index = 5;
            this.MI_Exit.Text = "離開(&E)";
            this.MI_Exit.Click += new System.EventHandler(this.MI_Exit_Click);
            // 
            // MI_Play
            // 
            this.MI_Play.Index = 1;
            this.MI_Play.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ShowPlaylist,
            this.MI_TopMost,
            this.MI_Fullscreen});
            this.MI_Play.Text = "播放(&P)";
            // 
            // MI_ShowPlaylist
            // 
            this.MI_ShowPlaylist.Index = 0;
            this.MI_ShowPlaylist.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.MI_ShowPlaylist.Text = "顯示播放清單";
            this.MI_ShowPlaylist.Click += new System.EventHandler(this.MI_ShowPlaylist_Click);
            // 
            // MI_TopMost
            // 
            this.MI_TopMost.Index = 1;
            this.MI_TopMost.Text = "置頂";
            this.MI_TopMost.Click += new System.EventHandler(this.MI_TopMost_Click);
            // 
            // MI_Fullscreen
            // 
            this.MI_Fullscreen.Index = 2;
            this.MI_Fullscreen.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.MI_Fullscreen.Text = "全螢幕播放";
            this.MI_Fullscreen.Click += new System.EventHandler(this.BigScreen_DoubleClick);
            // 
            // MI_Video
            // 
            this.MI_Video.Index = 2;
            this.MI_Video.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_Zoom,
            this.menuItem2,
            this.MI_Brightness,
            this.MI_Contrast,
            this.MI_Gamma,
            this.MI_Hue,
            this.MI_Saturation,
            this.menuItem7,
            this.MI_Screenshot});
            this.MI_Video.Text = "視訊(&V)";
            // 
            // MI_Zoom
            // 
            this.MI_Zoom.Index = 0;
            this.MI_Zoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_Zoom50,
            this.MI_Zoom100,
            this.MI_Zoom200,
            this.menuItem1,
            this.MI_FixSize});
            this.MI_Zoom.Text = "縮放大小";
            // 
            // MI_Zoom50
            // 
            this.MI_Zoom50.Index = 0;
            this.MI_Zoom50.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
            this.MI_Zoom50.Text = "50%";
            this.MI_Zoom50.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom100
            // 
            this.MI_Zoom100.Index = 1;
            this.MI_Zoom100.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
            this.MI_Zoom100.Text = "100%";
            this.MI_Zoom100.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom200
            // 
            this.MI_Zoom200.Index = 2;
            this.MI_Zoom200.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
            this.MI_Zoom200.Text = "200%";
            this.MI_Zoom200.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // MI_FixSize
            // 
            this.MI_FixSize.Index = 4;
            this.MI_FixSize.Text = "固定大小";
            this.MI_FixSize.Click += new System.EventHandler(this.MI_FixSize_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // MI_Brightness
            // 
            this.MI_Brightness.Index = 2;
            this.MI_Brightness.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_BrightnessLess,
            this.MI_BrightnessMore});
            this.MI_Brightness.Text = "亮度";
            // 
            // MI_BrightnessLess
            // 
            this.MI_BrightnessLess.Index = 0;
            this.MI_BrightnessLess.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.MI_BrightnessLess.Text = "亮度 -";
            this.MI_BrightnessLess.Click += new System.EventHandler(this.MI_BrightnessLess_Click);
            // 
            // MI_BrightnessMore
            // 
            this.MI_BrightnessMore.Index = 1;
            this.MI_BrightnessMore.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.MI_BrightnessMore.Text = "亮度 +";
            this.MI_BrightnessMore.Click += new System.EventHandler(this.MI_BrightnessMore_Click);
            // 
            // MI_Contrast
            // 
            this.MI_Contrast.Index = 3;
            this.MI_Contrast.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ContrastLess,
            this.MI_ContrastMore});
            this.MI_Contrast.Text = "對比";
            // 
            // MI_ContrastLess
            // 
            this.MI_ContrastLess.Index = 0;
            this.MI_ContrastLess.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.MI_ContrastLess.Text = "對比 -";
            this.MI_ContrastLess.Click += new System.EventHandler(this.MI_ContrastLess_Click);
            // 
            // MI_ContrastMore
            // 
            this.MI_ContrastMore.Index = 1;
            this.MI_ContrastMore.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.MI_ContrastMore.Text = "對比 +";
            this.MI_ContrastMore.Click += new System.EventHandler(this.MI_ContrastMore_Click);
            // 
            // MI_Gamma
            // 
            this.MI_Gamma.Index = 4;
            this.MI_Gamma.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_GammaLess,
            this.MI_GammaMore});
            this.MI_Gamma.Text = "Gamma";
            // 
            // MI_GammaLess
            // 
            this.MI_GammaLess.Index = 0;
            this.MI_GammaLess.Text = "Gamma -";
            this.MI_GammaLess.Click += new System.EventHandler(this.MI_GammaLess_Click);
            // 
            // MI_GammaMore
            // 
            this.MI_GammaMore.Index = 1;
            this.MI_GammaMore.Text = "Gamma +";
            this.MI_GammaMore.Click += new System.EventHandler(this.MI_GammaMore_Click);
            // 
            // MI_Hue
            // 
            this.MI_Hue.Index = 5;
            this.MI_Hue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_HueLess,
            this.MI_HueMore});
            this.MI_Hue.Text = "色調";
            // 
            // MI_HueLess
            // 
            this.MI_HueLess.Index = 0;
            this.MI_HueLess.Text = "色調 -";
            this.MI_HueLess.Click += new System.EventHandler(this.MI_HueLess_Click);
            // 
            // MI_HueMore
            // 
            this.MI_HueMore.Index = 1;
            this.MI_HueMore.Text = "色調 +";
            this.MI_HueMore.Click += new System.EventHandler(this.MI_HueMore_Click);
            // 
            // MI_Saturation
            // 
            this.MI_Saturation.Index = 6;
            this.MI_Saturation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SaturationLess,
            this.MI_SaturationMore});
            this.MI_Saturation.Text = "飽和度";
            // 
            // MI_SaturationLess
            // 
            this.MI_SaturationLess.Index = 0;
            this.MI_SaturationLess.Text = "飽和度 -";
            this.MI_SaturationLess.Click += new System.EventHandler(this.MI_SaturationLess_Click);
            // 
            // MI_SaturationMore
            // 
            this.MI_SaturationMore.Index = 1;
            this.MI_SaturationMore.Text = "飽和度 +";
            this.MI_SaturationMore.Click += new System.EventHandler(this.MI_SaturationMore_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // MI_Screenshot
            // 
            this.MI_Screenshot.Index = 8;
            this.MI_Screenshot.Text = "擷取畫面快照";
            this.MI_Screenshot.Click += new System.EventHandler(this.MI_Screenshot_Click);
            // 
            // MI_Audio
            // 
            this.MI_Audio.Index = 3;
            this.MI_Audio.Text = "音訊(&A)";
            // 
            // MI_Subtitle
            // 
            this.MI_Subtitle.Index = 4;
            this.MI_Subtitle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SelectSubtitle,
            this.MI_OpenSubFile,
            this.menuItem9,
            this.menuItemFont,
            this.MI_SubEncoding,
            this.menuItem20,
            this.menuItem3,
            this.MI_SubDelayLess,
            this.MI_SubDelayMore,
            this.menuItem22,
            this.MI_SubPosUp,
            this.MI_SubPosDown,
            this.menuItem26,
            this.MI_SubScaleDown,
            this.MI_SubScaleUp,
            this.menuItem16,
            this.MI_ASS});
            this.MI_Subtitle.Text = "字幕(&S)";
            // 
            // MI_SelectSubtitle
            // 
            this.MI_SelectSubtitle.Index = 0;
            this.MI_SelectSubtitle.Text = "選擇字幕";
            // 
            // MI_OpenSubFile
            // 
            this.MI_OpenSubFile.Index = 1;
            this.MI_OpenSubFile.Text = "開啟字幕";
            this.MI_OpenSubFile.Click += new System.EventHandler(this.MI_OpenSubFile_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // menuItemFont
            // 
            this.menuItemFont.Index = 3;
            this.menuItemFont.Text = "字型";
            this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // MI_SubEncoding
            // 
            this.MI_SubEncoding.Index = 4;
            this.MI_SubEncoding.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem15,
            this.menuItem5,
            this.menuItem21,
            this.menuItem25,
            this.menuItem24,
            this.menuItem23});
            this.MI_SubEncoding.Text = "字幕編碼";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            this.menuItem18.Text = "BIG5 (正體中文字集)";
            this.menuItem18.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "GB2312 (簡體中文字集)";
            this.menuItem15.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "CP936 (簡體中文字集)";
            this.menuItem5.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 3;
            this.menuItem21.Text = "SHIFT-JIS (日語字元集)";
            this.menuItem21.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 4;
            this.menuItem25.Text = "CP949 (韓語字元集)";
            this.menuItem25.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 5;
            this.menuItem24.Text = "UTF-8 (UTF-8)";
            this.menuItem24.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 6;
            this.menuItem23.Text = "Unicode (Unicode)";
            this.menuItem23.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 5;
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
            this.MI_NoSubAutoScale.RadioCheck = true;
            this.MI_NoSubAutoScale.Text = "無自動調整";
            this.MI_NoSubAutoScale.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
            // 
            // MI_SubAutoScaleHeight
            // 
            this.MI_SubAutoScaleHeight.Index = 1;
            this.MI_SubAutoScaleHeight.RadioCheck = true;
            this.MI_SubAutoScaleHeight.Text = "依高度自動調整";
            this.MI_SubAutoScaleHeight.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
            // 
            // MI_SubAutoScaleWidth
            // 
            this.MI_SubAutoScaleWidth.Index = 2;
            this.MI_SubAutoScaleWidth.RadioCheck = true;
            this.MI_SubAutoScaleWidth.Text = "依寬度自動調整";
            this.MI_SubAutoScaleWidth.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
            // 
            // MI_SubAutoScaleDiagonal
            // 
            this.MI_SubAutoScaleDiagonal.Index = 3;
            this.MI_SubAutoScaleDiagonal.RadioCheck = true;
            this.MI_SubAutoScaleDiagonal.Text = "依對角自動調整";
            this.MI_SubAutoScaleDiagonal.Click += new System.EventHandler(this.MI_SubAutoScale_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // MI_SubDelayLess
            // 
            this.MI_SubDelayLess.Index = 7;
            this.MI_SubDelayLess.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.MI_SubDelayLess.Text = "延遲 -";
            this.MI_SubDelayLess.Click += new System.EventHandler(this.MI_SubDelayLess_Click);
            // 
            // MI_SubDelayMore
            // 
            this.MI_SubDelayMore.Index = 8;
            this.MI_SubDelayMore.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.MI_SubDelayMore.Text = "延遲 +";
            this.MI_SubDelayMore.Click += new System.EventHandler(this.MI_SubDelayMore_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 9;
            this.menuItem22.Text = "-";
            // 
            // MI_SubPosUp
            // 
            this.MI_SubPosUp.Index = 10;
            this.MI_SubPosUp.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.MI_SubPosUp.Text = "上移";
            this.MI_SubPosUp.Click += new System.EventHandler(this.MI_SubPosUp_Click);
            // 
            // MI_SubPosDown
            // 
            this.MI_SubPosDown.Index = 11;
            this.MI_SubPosDown.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.MI_SubPosDown.Text = "下移";
            this.MI_SubPosDown.Click += new System.EventHandler(this.MI_SubPosDown_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 12;
            this.menuItem26.Text = "-";
            // 
            // MI_SubScaleDown
            // 
            this.MI_SubScaleDown.Index = 13;
            this.MI_SubScaleDown.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.MI_SubScaleDown.Text = "縮小";
            this.MI_SubScaleDown.Click += new System.EventHandler(this.MI_SubScaleDown_Click);
            // 
            // MI_SubScaleUp
            // 
            this.MI_SubScaleUp.Index = 14;
            this.MI_SubScaleUp.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.MI_SubScaleUp.Text = "放大";
            this.MI_SubScaleUp.Click += new System.EventHandler(this.MI_SubScaleUp_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 15;
            this.menuItem16.Text = "-";
            // 
            // MI_ASS
            // 
            this.MI_ASS.Index = 16;
            this.MI_ASS.Text = "使用 SSA/ASS";
            this.MI_ASS.Click += new System.EventHandler(this.MI_ASS_Click);
            // 
            // MI_Tools
            // 
            this.MI_Tools.Index = 5;
            this.MI_Tools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem12,
            this.MI_Option});
            this.MI_Tools.Text = "工具(&T)";
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
            // MI_Help
            // 
            this.MI_Help.Index = 6;
            this.MI_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_About});
            this.MI_Help.Text = "說明(&H)";
            // 
            // MI_About
            // 
            this.MI_About.Index = 0;
            this.MI_About.Text = "關於";
            this.MI_About.Click += new System.EventHandler(this.MI_About_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Playlist
            // 
            this.Playlist.AllowColumnReorder = true;
            this.Playlist.AllowDrop = true;
            this.Playlist.FullRowSelect = true;
            this.Playlist.Location = new System.Drawing.Point(408, 0);
            this.Playlist.Name = "Playlist";
            this.Playlist.Size = new System.Drawing.Size(160, 224);
            this.Playlist.TabIndex = 5;
            this.Playlist.UseCompatibleStateImageBehavior = false;
            this.Playlist.View = System.Windows.Forms.View.Details;
            this.Playlist.Visible = false;
            this.Playlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.Playlist_DragEnter);
            this.Playlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.Playlist_DragDrop);
            this.Playlist.DoubleClick += new System.EventHandler(this.Playlist_DoubleClick);
            this.Playlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Playlist_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitter1.Location = new System.Drawing.Point(392, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 304);
            this.splitter1.TabIndex = 6;
            this.splitter1.Visible = false;
            this.splitter1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseDown);
            this.splitter1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseMove);
            this.splitter1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(568, 377);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Playlist);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Power Mplayer";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
		static void Main(string[] args) 
		{
			Application.Run(new Form1(args));
		}

		private void btn_pause_Click(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
				Pause();
			}
			else
			{
				this.Start(mp.Playlist.Current());
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			MainPanel.Top = 0;
			MainPanel.Left = 0;

			BigScreen.Top = 0;
			BigScreen.Left = 0;

			MovieBar.Top = MovieBar.Left = 0;

			btn_despeed.Top = btn_inspeed.Top = btn_stop.Top = btn_pause.Top = MovieBar.Top + MovieBar.Height;
			btn_pause.Left = 0;
			btn_stop.Left = btn_pause.Left + btn_pause.Width;
			btn_despeed.Left = btn_stop.Left + btn_stop.Width + 10;
			btn_inspeed.Left = btn_despeed.Left + btn_despeed.Width;
			
			btn_mute.Top = btn_pause.Top;
			VolumeBar.Top = btn_pause.Top;

			Playlist.Top = 0;
			Playlist.Columns.Add("播放清單", -2, HorizontalAlignment.Left);

			this.txtShortcut.Size = new Size(0, 0);

			this.Form1_Resize(null, null);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			// setup panel1
			panel1.Height = MovieBar.Height + btn_pause.Height;			
			if(!this.isFullscreen)
				panel1.Height += this.statusBar1.Height;
			
			MovieBar.Width = panel1.Width;
			VolumeBar.Left = this.ClientSize.Width - VolumeBar.Width;
			btn_mute.Left = VolumeBar.Left - btn_mute.Width;

			// setup MainPanel
			MainPanel.Height = this.ClientSize.Height ;
			if(!this.isFullscreen)
				MainPanel.Height -= this.panel1.Height;

			MainPanel.Width = this.ClientSize.Width;
			if(!this.isFullscreen && this.Playlist.Visible)
				MainPanel.Width -= this.splitter1.Width + this.Playlist.Width;

			if(this.Playlist.Visible)
			{	
				this.splitter1.Left = this.MainPanel.Width;
				this.splitter1.Height = this.MainPanel.Height;

				this.Playlist.Height = this.MainPanel.Height;
				this.Playlist.Left = this.splitter1.Left + this.splitter1.Width;
				this.Playlist.Width = this.ClientSize.Width - this.Playlist.Left;
			}

			adjBigScreen();

			this.txtShortcut.Focus();
		}

		private void adjBigScreen()
		{
			double aspect = 0;

			if(mp.HasInstense())
			{
				aspect = mp.Video_Aspect;
			}

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
		}

        private bool isPlaying
        {
            get
            {
                return !(btn_pause.ImageIndex == 0);
            }
        }

		private void BackToPauseState()
		{
			if(!this.isPlaying)
				mp.Pause();

			this.txtShortcut.Focus();
		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			Stop();
		}


		private void VolumeBar_Scroll(object sender, System.EventArgs e)
		{
			mp.Volume = VolumeBar.Value * 10;
			btn_mute.ImageIndex = 3;

			this.BackToPauseState();
		}


		private void MI_OpenURL_Click(object sender, System.EventArgs e)
		{
			OpenURL urlForm = new OpenURL();

			if(urlForm.ShowDialog() == DialogResult.OK)
			{
				if(urlForm.URL.IndexOf("//") > 0)
				{
					this.Start(urlForm.URL);
				}
			}
		}

		#region GUI Movie Control

		private void Start(string filename)
		{
			if(mp.HasInstense())
				Quit();

			mp.Filename = filename;

			if(filename != null)
				this.Start();
		}

		private void Start()
		{
			if(mp.HasInstense())
				Quit();

			if(mp.Start())
			{
				// log last file
				if(mp.mediaType == MediaType.File)
				{
					string lastFile = (string) mp.Setting[SetVars.LastMedia];	
					if(lastFile != null && lastFile.StartsWith(mp.Filename.ToLower()))
					{
						int index = lastFile.IndexOf(':', 3);	// C:\XXXXX\xxxx.avi:123.12
						string buf = lastFile.Substring(index+1);
						double time_pos = double.Parse(buf);
						Seek(time_pos);
					}
				}

				this.Text = System.IO.Path.GetFileName(mp.Filename);

				this.btn_pause.Enabled = true;
				this.btn_pause.ImageIndex = 1;
				this.btn_stop.Enabled = true;
				this.btn_despeed.Enabled = true;
				this.btn_inspeed.Enabled = true;
				
				this.VolumeBar_Scroll(null, null);
			
				this.AppendSubtitleMenuItem(this.MI_SelectSubtitle);

				this.Form1_Resize(null, null);

				timer1.Start();
			}

			this.txtShortcut.Focus();
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

			this.txtShortcut.Focus();
		}

		private void Stop()
		{
			if(mp.HasInstense())
				mp.Stop();

			timer1.Stop();
			btn_pause.ImageIndex = 0;
			MovieBar.Value = 0;

			this.txtShortcut.Focus();
		}

		private void Quit()
		{
			// log last media file
			if(mp.HasInstense() && mp.mediaType == MediaType.File)
			{
				mp.Setting[SetVars.LastMedia] = mp.Filename.ToLower() + ":" + mp.Time_Pos;
				mp.Setting.WriteSetting();
			}

			mp.Quit();
			Stop();

			this.MI_SelectSubtitle.MenuItems.Clear();
		}

		private void Restart()
		{
			this.Restart(mp.CurrentSubtitle);
		}

		private void Restart(Subtitle sub)
		{
			if(mp.HasInstense())
			{
				double pos = mp.Time_Pos - 0.5;
				bool paused = (btn_pause.ImageIndex == 0) ? true : false;
				string filename = mp.Filename;
				int movieBar = MovieBar.Value;
				MediaType mt = mp.mediaType;

				Quit();
				mp.CurrentSubtitle = sub;
				mp.Filename = filename;
				mp.mediaType = mt;

				Start();

				MovieBar.Value = movieBar;
				mp.Time_Pos = pos;

				if(paused)
					Pause();
			}
		}

		private void Seek(double time_pos)
		{
			double length = mp.Length;

			if(time_pos > length)
				time_pos = length;
			else if(time_pos < 0)
				time_pos = 0;

			mp.Time_Pos = time_pos;
			MovieBar.Value = (int) (100 * time_pos / length);

			this.BackToPauseState();

			this.txtShortcut.Focus();
		}

		#endregion

		// Open File
		private void Menu_OpenFile(object sender, System.EventArgs e)
		{
			this.openFileDialog1.FileName = "";
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != "")
			{
				mp.Playlist.Clear();
				this.Playlist_AddItem(this.openFileDialog1.FileNames);

				Start(mp.Playlist.First());
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
            if (mp.HasInstense())
            {
                if (mp.Mute() == true)
                {
                    btn_mute.ImageIndex = 4;
                }
                else
                {
                    btn_mute.ImageIndex = 3;
                }
            }
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
				int now_pos = (int) mp.Time_Pos;
				int movie_len = (int) mp.Length;

				if(now_pos != 0 && movie_len != 0)
				{
					string str_now_pos = (now_pos / 3600) + ":" + ((now_pos / 60) % 60)+ ":" + (now_pos % 60);
					string str_movie_len = (movie_len / 3600) + ":" + ((movie_len / 60) % 60) + ":" + (movie_len % 60);

					this.statusPanel1.Text = str_now_pos + " / " + str_movie_len;
					this.MovieBar.Value = (100 * now_pos) / movie_len;
				}
				else
				{
					this.statusPanel1.Text = "0:0:0 / 0:0:0";
					this.MovieBar.Value = 0;
				}

			}
			else
			{
				Quit();

				string fname = mp.Playlist.Next();
				if(fname != null)
					Start(fname);
			}
		}

		// FIXME: use better method...
		private bool isFullscreen = false;
		private Size oldFormSize = new Size(0, 0);
		private int oldPlaylistWidth = 0;
        private Point oldFormLocation;
		private void BigScreen_DoubleClick(object sender, System.EventArgs e)
		{
			isFullscreen = !isFullscreen;
			if(isFullscreen == true)
			{
				oldPlaylistWidth = this.Playlist.Width;
				this.Menu = null;		// this line will cause Playlist.Width = 0
				this.statusBar1.Visible = false;
				this.splitter1.Visible = this.Playlist.Visible = false;
				oldFormSize = this.Size;
                oldFormLocation = this.Location;

				this.FormBorderStyle = FormBorderStyle.None;
				//this.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Normal;
				this.TopMost = true;
				
				//int cx = Win32API.GetSystemMetrics(Win32API.SM_CXSCREEN);
				//int cy = Win32API.GetSystemMetrics(Win32API.SM_CYSCREEN);
				//Win32API.SetWindowPos(this.Handle.ToInt32(), Win32API.HWND_TOP, 0, 0, cx, cy, Win32API.SWP_SHOWWINDOW);

                Screen sc = Screen.FromHandle(this.Handle);
                int cx = sc.Bounds.Width;
                int cy = sc.Bounds.Height;

                this.Width = cx;
                this.Height = cy;
                this.Left = this.Top = 0;
			}
			else
			{
				this.Menu = this.mainMenu1;
				this.statusBar1.Visible = true;
				this.splitter1.Visible = this.Playlist.Visible = this.MI_ShowPlaylist.Checked;

				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.WindowState = FormWindowState.Normal;
				this.TopMost = this.MI_TopMost.Checked;

				/*
				this.Width = mp.Video_Width;
				this.Height = mp.Video_Height + this.panel1.Height + (this.Height - this.ClientSize.Height);
				*/

				this.Size = oldFormSize;
				this.Playlist.Width = this.oldPlaylistWidth;
                this.Location = oldFormLocation;
			}

			if(btn_pause.ImageIndex == 0)
				this.Pause();

			this.Form1_Resize(sender, e);
		}

		private void MI_Option_Click(object sender, System.EventArgs e)
		{
			if(this.optForm == null)
				this.optForm = new OptionForm(mp.Setting);

			optForm.LoadSetting();
			if(optForm.ShowDialog() == DialogResult.OK)
			{
				optForm.WriteSetting();
				Restart();
			}
		}

		#region Subtitle MenuItem

		private void menuItemFont_Click(object sender, System.EventArgs e)
		{
			if(this.fontSelect == null)
				this.fontSelect = new FontSelector();

			this.fontSelect.FontPath = System.Environment.ExpandEnvironmentVariables(mp.Setting[SetVars.SubFont]);
			if(fontSelect.ShowDialog() == DialogResult.OK)
			{
				string expendFontRoot = System.Environment.ExpandEnvironmentVariables(FontSelector.FontRoot);

				if(fontSelect.FontPath.StartsWith(expendFontRoot))
					mp.Setting[SetVars.SubFont] = FontSelector.FontRoot + Path.GetFileName(fontSelect.FontPath);
				else
					mp.Setting[SetVars.SubFont] = fontSelect.FontPath;

				mp.Setting.WriteSetting();

				Restart();
			}
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

			mp.Setting[SetVars.SubAutoScale] = mi.Index.ToString();
			mp.Setting.WriteSetting();

			this.Restart();
		}

		private void MI_SubEncoding_Click(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;

			foreach(MenuItem smi in this.MI_SubEncoding.MenuItems)
			{
				smi.Checked = false;
			}
			mi.Checked = true;

			string[] str = mi.Text.Split(' ', '(');
			mp.Setting[SetVars.SubEncoding] = str[0];
			mp.Setting.WriteSetting();

			Restart();
		}

		private void MI_SubDelayLess_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Delay = -0.1;
		}

		private void MI_SubDelayMore_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Delay = 0.1;
		}

		private void MI_SubScaleDown_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Scale = -0.2;
		}

		private void MI_SubScaleUp_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Scale = 0.2;
		}

		private void MI_SubPosUp_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Pos = -1;
		}

		private void MI_SubPosDown_Click(object sender, System.EventArgs e)
		{
			mp.Sub_Pos = 1;
		}

		private void MI_OpenSubFile_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.FileName = "";
			this.openFileDialog1.ShowDialog();

			if(this.openFileDialog1.FileName != null && this.openFileDialog1.FileName != "")
			{
				this.Restart(new Subtitle(this.openFileDialog1.FileName));
			}
		}

		private void MI_Subtitle_Click(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem) sender;

			Subtitle sub = (Subtitle) mp.SubList[mi.Index];
			
			if(sub.SubType == SubtitleType.VobSubID || sub.SubType == SubtitleType.DemuxSubID)
			{
				mp.SelectSub(sub);
				mp.CurrentSubtitle = sub;

				this.AppendSubtitleMenuItem(this.MI_SelectSubtitle);
			}
			else
				this.Restart(sub);
		}

		private void AppendSubtitleMenuItem(MenuItem mi_selectsub)
		{
			mi_selectsub.MenuItems.Clear();

			// if Subtitles.count <= 0 , will not enter the loop
			for(int i=0;i<mp.SubList.Count;i++)
			{
				MenuItem mi = new MenuItem(((Subtitle) mp.SubList[i]).Name);
				mi.Index = i;
				mi.RadioCheck = true;
				mi.Click += new System.EventHandler(this.MI_Subtitle_Click);

				if(mp.CurrentSubtitle != null && mp.CurrentSubtitle.Name == mi.Text)
					mi.Checked = true;
				
				mi_selectsub.MenuItems.Add(mi);
			}
		}

		private void MI_ASS_Click(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem) sender;

			mi.Checked = !mi.Checked;

			mp.Setting[SetVars.SubASS] = mi.Checked ? "1" : "0";
			mp.Setting.WriteSetting();

			this.Restart();
		}

		#endregion

		private void MI_Exit_Click(object sender, System.EventArgs e)
		{
			this.Quit();
			this.Dispose(true);
		}

		private void MainPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.isFullscreen)
			{
				if(e.Y > this.MainPanel.Height - this.panel1.Height)
				{
					this.panel1.BringToFront();
				}
				else
				{
					this.MainPanel.BringToFront();
				}
			}
		}

		private void BigScreen_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.isFullscreen)
			{
				int shift = (this.MainPanel.Height - this.BigScreen.Height) / 2;
				this.MainPanel_MouseMove(sender, new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y + shift, e.Delta));
			}
		}

		private void MI_About_Click(object sender, System.EventArgs e)
		{
			AboutDialog ad = new AboutDialog();
			ad.ShowDialog();
		}

		#region Drag Event
		// temp solution

		private void MainPanel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void MainPanel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string[] s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
			
			mp.Playlist.Clear();
			this.Playlist_AddItem(s);

			Start(mp.Playlist.First());
		}

		#endregion

		#region MenuItem:Video

		private void MI_BrightnessMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Brightness = 1;
			this.BackToPauseState();
		}

		private void MI_BrightnessLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Brightness = -1;
			this.BackToPauseState();
		}

		private void MI_ContrastMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Contrast = 1;
			this.BackToPauseState();
		}

		private void MI_ContrastLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Contrast = -1;
			this.BackToPauseState();
		}

		private void MI_GammaLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Gamma = -10;
			this.BackToPauseState();
		}

		private void MI_GammaMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Gamma = 10;
			this.BackToPauseState();
		}

		private void MI_HueLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Hue = -10;
			this.BackToPauseState();
		}

		private void MI_HueMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Hue = +10;
			this.BackToPauseState();
		}

		private void MI_SaturationLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Saturation = -10;
			this.BackToPauseState();
		}

		private void MI_SaturationMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Saturation = 10;
			this.BackToPauseState();
		}

		private void MI_Zoom_Click(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
				if(this.WindowState == FormWindowState.Maximized)
					this.WindowState = FormWindowState.Normal;

				MenuItem mi = (MenuItem) sender;
				int width = mp.Video_Width;
				int height = mp.Video_Height;

				if(mi == this.MI_Zoom50)
				{
					width /= 2;
					height /= 2;
				}
				else if(mi == this.MI_Zoom200)
				{
					width *= 2;
					height *= 2;

					//FIXME: why???? 50%, 100% no need....
					//height -= this.statusBar1.Height;
				}

				height += this.panel1.Height;

				if(this.Playlist.Visible)
					width += this.Playlist.Width;

				this.ClientSize = new Size(width, height);

				this.Form1_Resize(null, null);

				//FIXME: 200% special case....
				//this.BigScreen.Left = 0;
			}
		}

		private void MI_FixSize_Click(object sender, System.EventArgs e)
		{
			this.MI_FixSize.Checked = !this.MI_FixSize.Checked;

			if(this.MI_FixSize.Checked)
				this.FormBorderStyle = FormBorderStyle.FixedDialog;
			else
				this.FormBorderStyle = FormBorderStyle.Sizable;
		}

		#endregion

		private void MI_TopMost_Click(object sender, System.EventArgs e)
		{
			MI_TopMost.Checked = !MI_TopMost.Checked;
			this.TopMost = MI_TopMost.Checked;
		}

		private void MI_ShowPlaylist_Click(object sender, System.EventArgs e)
		{
			MI_ShowPlaylist.Checked = !MI_ShowPlaylist.Checked;
			this.splitter1.Visible = Playlist.Visible = MI_ShowPlaylist.Checked;
			this.Form1_Resize(null, null);
		}

		#region splitter Eventes

		private bool SplitMousePress = false;
		private void splitter1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.SplitMousePress = true;
		}

		private void splitter1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.SplitMousePress = false;
		}

		private void splitter1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.SplitMousePress)
			{
				Panel p = (Panel) sender;

				p.Left = p.Left + e.X;

				this.MainPanel.Width = p.Left;

				this.Playlist.Left = p.Left + p.Width;
				this.Playlist.Width = this.ClientSize.Width - this.Playlist.Left;
	
				this.adjBigScreen();
			}
		}

		#endregion

		#region Playlist Events

		private void CreatePlaylistItems()
		{
			Playlist.Items.Clear();

			for(int i=0;i<mp.Playlist.Count;i++)
			{
				string str = (string) mp.Playlist[i];
				
				if(str.StartsWith("file://"))
					str = Path.GetFileName(str);
				
				Playlist.Items.Add(new ListViewItem( str ));
			}
		}

		private void Playlist_DoubleClick(object sender, System.EventArgs e)
		{
			int index = Playlist.SelectedIndices[0];

			this.Start(mp.Playlist.GetFilename(index));
		}

		private void Playlist_AddItem(params string[] s)
		{
			foreach(string str in s)
			{
				if(str.IndexOf("//") <= 0)
					mp.Playlist.Add("file://" + str);
				else
					mp.Playlist.Add(str);
			}

			this.CreatePlaylistItems();
		}

		private void Playlist_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void Playlist_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string[] s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
			
			this.Playlist_AddItem(s);
		}

		private void Playlist_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				for(int i=Playlist.SelectedIndices.Count-1;i>=0;i--)
				{
					mp.Playlist.RemoveAt(Playlist.SelectedIndices[i]);
				}

				this.CreatePlaylistItems();
			}
		}

		#endregion

		#region MovieBar Events

		private bool MBar_MouseDown = false;
		private void MovieBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			MBar_MouseDown = true;
			this.timer1.Stop();
		}

		private void MovieBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			double val = (double) e.X / MovieBar.Width;
			double len = mp.Length;

			this.Seek(val*len);

			MBar_MouseDown = false;
			this.timer1.Start();
		}

		private void MovieBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(MBar_MouseDown)
			{
				double val = (double) e.X / MovieBar.Width;

				int len = (int) mp.Length;
				int pos = (int) (val*len);

				string str_now_pos = (pos / 3600) + ":" + ((pos / 60) % 60)+ ":" + (pos % 60);
				string str_movie_len = (len / 3600) + ":" + ((len / 60) % 60) + ":" + (len % 60);

				this.statusPanel1.Text = str_now_pos + " / " + str_movie_len;
			}
		}

		#endregion

		private void MI_LastOpen_Click(object sender, System.EventArgs e)
		{
			string s = mp.Setting[SetVars.LastMedia];
			if(s != null && s != "")
			{
				int index = s.IndexOf(':', 3);

				mp.Playlist.Clear();
				this.Playlist_AddItem("file://" + s.Substring(0, index));

				this.Start(mp.Playlist.First());
			}
		}

		private void Form1_Move(object sender, System.EventArgs e)
		{
			mp.MoveScreen();
		}

		private void txtShortcut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			string cmd = mp.LaunchShortcut(e);

			if(cmd == "None")
				return;

			if(cmd.ToLower().StartsWith("pause"))
			{
				this.btn_pause_Click(null, null);
			}
			else if(cmd.StartsWith("volume"))
			{
				int i = int.Parse(cmd.Split(' ')[1]);

				if(i > 0)
				{
					if(this.VolumeBar.Value + i <= VolumeBar.Maximum)
						this.VolumeBar.Value += i;
					else
						this.VolumeBar.Value = VolumeBar.Maximum;
				}
				else
				{
					if(this.VolumeBar.Value + i >= VolumeBar.Minimum)
						this.VolumeBar.Value += i;
					else 
						this.VolumeBar.Value = VolumeBar.Minimum;
				}

				this.VolumeBar_Scroll(null, null);
			}
			else if(cmd.StartsWith("vo_ontop"))
			{
				this.MI_TopMost_Click(null, null);
			}
			else if(cmd.StartsWith("vo_fullscreen"))
			{
				this.BigScreen_DoubleClick(null, null);
			}
			else if(cmd.StartsWith("quit"))
			{
				this.Quit();
			}
			else
			{
				mp.SendSlaveCommand(cmd + " ");
			}
		}

		private void txtShortcut_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.txtShortcut.Text = "";
		}

		private void btn_despeed_Click(object sender, System.EventArgs e)
		{
			mp.Speed_mult = 0.5;
		}

		private void btn_inspeed_Click(object sender, System.EventArgs e)
		{
			mp.Speed_mult = 2;
		}

        private void MI_Screenshot_Click(object sender, EventArgs e)
        {
            if (mp.HasInstense())
            {
                if (isPlaying)
                    Pause();

                string fname = mp.Screenshot();

                string Ext = Path.GetExtension(fname);

                this.saveFileDialog1.FileName = fname;
                this.saveFileDialog1.Filter = "*" + Ext + "|" + Ext;

                if (this.saveFileDialog1.ShowDialog() != DialogResult.Cancel && saveFileDialog1.FileName != "")
                {
                    File.Move(fname, saveFileDialog1.FileName);
                }
                else
                {
                    File.Delete(fname);
                }
            }
        }
	}
}
