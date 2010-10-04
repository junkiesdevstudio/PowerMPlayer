using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace Power_Mplayer
{
	/// <summary>
	/// Form1 ªººK­n´y­z¡C
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.ComponentModel.IContainer components;
        public Panel BigScreen;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ProgressBar MovieBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem menuItem18;
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
		private System.Windows.Forms.MenuItem MI_OpenSubFile;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.MenuItem MI_SelectSubtitle;
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
		private System.Windows.Forms.MenuItem MI_Play;
		private System.Windows.Forms.MenuItem MI_Video;
		private System.Windows.Forms.MenuItem MI_Audio;
		private System.Windows.Forms.MenuItem MI_Subtitle;
		private System.Windows.Forms.MenuItem MI_Tools;
		private System.Windows.Forms.MenuItem MI_Help;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem MI_FixSize;
        private System.Windows.Forms.TextBox txtShortcut;
        private MenuItem menuItem7;
        private MenuItem MI_Screenshot;
        private SaveFileDialog saveFileDialog1;
        private MenuItem MI_SubChineseTrans;
        private MenuItem MI_ChineseNone;
        private MenuItem MI_ToTradChinese;
        private MenuItem MI_ToSimpChinese;
        private MenuItem MI_EditShortcut;
        private MenuItem MI_AudioBalance;
        private MenuItem MI_File;
        private MenuItem MI_OpenFile;
        private MenuItem MI_OpenVCD;
        private MenuItem MI_OpenURL;
        private MenuItem menuItem6;
        private MenuItem MI_LastOpen;
        private MenuItem menuItem4;
        private MenuItem MI_Exit;
        private MenuItem MI_AudioBalance_Center;
        private MenuItem MI_AudioBalance_Left;
        private MenuItem MI_AudioBalance_Right;
        private GlassButton btn_stop;
        private GlassButton btn_despeed;
        private GlassButton btn_inspeed;
        private GlassButton btn_pause;
        private MenuItem MI_SelectAudio;

        private Font FontPlay, FontPause;
        private GlassButton btn_mute;
        private MTrackBar VolumeBar;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label txtStatus;

		// constructure
		private Form1()
		{
            MplayerSetting ms = new MplayerSetting();

            //set the UI language
            if (ms[SetVars.Language] != "")
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ms[SetVars.Language]);

            // Windows Form
            InitializeComponent();

            // Mplayer Interface
            mp = new Mplayer(this, ms);
            
			string var = mp.Setting[SetVars.SubEncoding];
			foreach(MenuItem mi in this.MI_SubEncoding.MenuItems)
			{
				if(mi.Text.StartsWith(var))
				{
					mi.Checked = true;
					break;
				}
			}

            var = mp.Setting[SetVars.SubChineseTrans];
            MI_SubChineseTrans.MenuItems[int.Parse(var)].Checked = true;

            FontPlay = new Font("Wingdings 3", 12F, FontStyle.Bold);
            FontPause = new Font("Webdings", 12F, System.Drawing.FontStyle.Bold);
		}

		public Form1(string[] str) : this()
		{
			if(str != null && str.Length > 0)
			{
				Playlist_AddItem(MediaType.File, str);
				this.Start(Playlist_First());
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

		#region Windows Form ³]­p¤u¨ã²£¥Íªºµ{¦¡½X
		/// <summary>
		/// ¦¹¬°³]­p¤u¨ã¤ä´©©Ò¥²¶·ªº¤èªk - ½Ð¤Å¨Ï¥Îµ{¦¡½X½s¿è¾¹­×§ï
		/// ³o­Ó¤èªkªº¤º®e¡C
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BigScreen = new System.Windows.Forms.Panel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.Label();
            this.MovieBar = new System.Windows.Forms.ProgressBar();
            this.txtShortcut = new System.Windows.Forms.TextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MI_File = new System.Windows.Forms.MenuItem();
            this.MI_OpenFile = new System.Windows.Forms.MenuItem();
            this.MI_OpenVCD = new System.Windows.Forms.MenuItem();
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
            this.MI_SelectAudio = new System.Windows.Forms.MenuItem();
            this.MI_AudioBalance = new System.Windows.Forms.MenuItem();
            this.MI_AudioBalance_Center = new System.Windows.Forms.MenuItem();
            this.MI_AudioBalance_Left = new System.Windows.Forms.MenuItem();
            this.MI_AudioBalance_Right = new System.Windows.Forms.MenuItem();
            this.MI_Subtitle = new System.Windows.Forms.MenuItem();
            this.MI_SelectSubtitle = new System.Windows.Forms.MenuItem();
            this.MI_OpenSubFile = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.MI_SubEncoding = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.MI_SubChineseTrans = new System.Windows.Forms.MenuItem();
            this.MI_ChineseNone = new System.Windows.Forms.MenuItem();
            this.MI_ToTradChinese = new System.Windows.Forms.MenuItem();
            this.MI_ToSimpChinese = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.MI_SubDelayLess = new System.Windows.Forms.MenuItem();
            this.MI_SubDelayMore = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.MI_SubPosUp = new System.Windows.Forms.MenuItem();
            this.MI_SubPosDown = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.MI_SubScaleDown = new System.Windows.Forms.MenuItem();
            this.MI_SubScaleUp = new System.Windows.Forms.MenuItem();
            this.MI_Tools = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.MI_EditShortcut = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.MI_Option = new System.Windows.Forms.MenuItem();
            this.MI_Help = new System.Windows.Forms.MenuItem();
            this.MI_About = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitter1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Playlist = new System.Windows.Forms.ListView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.VolumeBar = new Power_Mplayer.MTrackBar();
            this.btn_mute = new Power_Mplayer.GlassButton();
            this.btn_pause = new Power_Mplayer.GlassButton();
            this.btn_inspeed = new Power_Mplayer.GlassButton();
            this.btn_despeed = new Power_Mplayer.GlassButton();
            this.btn_stop = new Power_Mplayer.GlassButton();
            this.panel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play.png");
            this.imageList1.Images.SetKeyName(1, "pause.png");
            this.imageList1.Images.SetKeyName(2, "stop.png");
            this.imageList1.Images.SetKeyName(3, "volume.png");
            this.imageList1.Images.SetKeyName(4, "mute.png");
            this.imageList1.Images.SetKeyName(5, "forward1m.png");
            this.imageList1.Images.SetKeyName(6, "rewind1m.png");
            // 
            // BigScreen
            // 
            this.BigScreen.AllowDrop = true;
            this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BigScreen.ContextMenu = this.contextMenu1;
            resources.ApplyResources(this.BigScreen, "BigScreen");
            this.BigScreen.Name = "BigScreen";
            this.BigScreen.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
            this.BigScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BigScreen_MouseMove);
            this.BigScreen.Click += new System.EventHandler(this.btn_pause_Click);
            this.BigScreen.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
            this.BigScreen.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.VolumeBar);
            this.panel1.Controls.Add(this.btn_mute);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.btn_pause);
            this.panel1.Controls.Add(this.btn_inspeed);
            this.panel1.Controls.Add(this.btn_despeed);
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.MovieBar);
            this.panel1.Controls.Add(this.txtShortcut);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtStatus
            // 
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.ForeColor = System.Drawing.Color.White;
            this.txtStatus.Name = "txtStatus";
            // 
            // MovieBar
            // 
            resources.ApplyResources(this.MovieBar, "MovieBar");
            this.MovieBar.Name = "MovieBar";
            this.MovieBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MovieBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseMove);
            this.MovieBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseDown);
            this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
            // 
            // txtShortcut
            // 
            this.txtShortcut.BackColor = System.Drawing.Color.Gold;
            this.txtShortcut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtShortcut, "txtShortcut");
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyDown);
            this.txtShortcut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyUp);
            // 
            // MainPanel
            // 
            this.MainPanel.AllowDrop = true;
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.ContextMenu = this.contextMenu1;
            this.MainPanel.Controls.Add(this.BigScreen);
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            this.MainPanel.Click += new System.EventHandler(this.btn_pause_Click);
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
            this.MI_OpenVCD,
            this.MI_OpenURL,
            this.menuItem6,
            this.MI_LastOpen,
            this.menuItem4,
            this.MI_Exit});
            resources.ApplyResources(this.MI_File, "MI_File");
            // 
            // MI_OpenFile
            // 
            this.MI_OpenFile.Index = 0;
            resources.ApplyResources(this.MI_OpenFile, "MI_OpenFile");
            this.MI_OpenFile.Click += new System.EventHandler(this.Menu_OpenFile);
            // 
            // MI_OpenVCD
            // 
            this.MI_OpenVCD.Index = 1;
            resources.ApplyResources(this.MI_OpenVCD, "MI_OpenVCD");
            this.MI_OpenVCD.Click += new System.EventHandler(this.MI_OpenVCD_Click);
            // 
            // MI_OpenURL
            // 
            this.MI_OpenURL.Index = 2;
            resources.ApplyResources(this.MI_OpenURL, "MI_OpenURL");
            this.MI_OpenURL.Click += new System.EventHandler(this.MI_OpenURL_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            resources.ApplyResources(this.menuItem6, "menuItem6");
            // 
            // MI_LastOpen
            // 
            this.MI_LastOpen.Index = 4;
            resources.ApplyResources(this.MI_LastOpen, "MI_LastOpen");
            this.MI_LastOpen.Click += new System.EventHandler(this.MI_LastOpen_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            resources.ApplyResources(this.menuItem4, "menuItem4");
            // 
            // MI_Exit
            // 
            this.MI_Exit.Index = 6;
            resources.ApplyResources(this.MI_Exit, "MI_Exit");
            this.MI_Exit.Click += new System.EventHandler(this.MI_Exit_Click);
            // 
            // MI_Play
            // 
            this.MI_Play.Index = 1;
            this.MI_Play.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ShowPlaylist,
            this.MI_TopMost,
            this.MI_Fullscreen});
            resources.ApplyResources(this.MI_Play, "MI_Play");
            // 
            // MI_ShowPlaylist
            // 
            this.MI_ShowPlaylist.Index = 0;
            resources.ApplyResources(this.MI_ShowPlaylist, "MI_ShowPlaylist");
            this.MI_ShowPlaylist.Click += new System.EventHandler(this.MI_ShowPlaylist_Click);
            // 
            // MI_TopMost
            // 
            this.MI_TopMost.Index = 1;
            resources.ApplyResources(this.MI_TopMost, "MI_TopMost");
            this.MI_TopMost.Click += new System.EventHandler(this.MI_TopMost_Click);
            // 
            // MI_Fullscreen
            // 
            this.MI_Fullscreen.Index = 2;
            resources.ApplyResources(this.MI_Fullscreen, "MI_Fullscreen");
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
            resources.ApplyResources(this.MI_Video, "MI_Video");
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
            resources.ApplyResources(this.MI_Zoom, "MI_Zoom");
            // 
            // MI_Zoom50
            // 
            this.MI_Zoom50.Index = 0;
            resources.ApplyResources(this.MI_Zoom50, "MI_Zoom50");
            this.MI_Zoom50.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom100
            // 
            this.MI_Zoom100.Index = 1;
            resources.ApplyResources(this.MI_Zoom100, "MI_Zoom100");
            this.MI_Zoom100.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom200
            // 
            this.MI_Zoom200.Index = 2;
            resources.ApplyResources(this.MI_Zoom200, "MI_Zoom200");
            this.MI_Zoom200.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // MI_FixSize
            // 
            this.MI_FixSize.Index = 4;
            resources.ApplyResources(this.MI_FixSize, "MI_FixSize");
            this.MI_FixSize.Click += new System.EventHandler(this.MI_FixSize_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            resources.ApplyResources(this.menuItem2, "menuItem2");
            // 
            // MI_Brightness
            // 
            this.MI_Brightness.Index = 2;
            this.MI_Brightness.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_BrightnessLess,
            this.MI_BrightnessMore});
            resources.ApplyResources(this.MI_Brightness, "MI_Brightness");
            // 
            // MI_BrightnessLess
            // 
            this.MI_BrightnessLess.Index = 0;
            resources.ApplyResources(this.MI_BrightnessLess, "MI_BrightnessLess");
            this.MI_BrightnessLess.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_BrightnessMore
            // 
            this.MI_BrightnessMore.Index = 1;
            resources.ApplyResources(this.MI_BrightnessMore, "MI_BrightnessMore");
            this.MI_BrightnessMore.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_Contrast
            // 
            this.MI_Contrast.Index = 3;
            this.MI_Contrast.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ContrastLess,
            this.MI_ContrastMore});
            resources.ApplyResources(this.MI_Contrast, "MI_Contrast");
            // 
            // MI_ContrastLess
            // 
            this.MI_ContrastLess.Index = 0;
            resources.ApplyResources(this.MI_ContrastLess, "MI_ContrastLess");
            this.MI_ContrastLess.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_ContrastMore
            // 
            this.MI_ContrastMore.Index = 1;
            resources.ApplyResources(this.MI_ContrastMore, "MI_ContrastMore");
            this.MI_ContrastMore.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_Gamma
            // 
            this.MI_Gamma.Index = 4;
            this.MI_Gamma.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_GammaLess,
            this.MI_GammaMore});
            resources.ApplyResources(this.MI_Gamma, "MI_Gamma");
            // 
            // MI_GammaLess
            // 
            this.MI_GammaLess.Index = 0;
            resources.ApplyResources(this.MI_GammaLess, "MI_GammaLess");
            this.MI_GammaLess.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_GammaMore
            // 
            this.MI_GammaMore.Index = 1;
            resources.ApplyResources(this.MI_GammaMore, "MI_GammaMore");
            this.MI_GammaMore.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_Hue
            // 
            this.MI_Hue.Index = 5;
            this.MI_Hue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_HueLess,
            this.MI_HueMore});
            resources.ApplyResources(this.MI_Hue, "MI_Hue");
            // 
            // MI_HueLess
            // 
            this.MI_HueLess.Index = 0;
            resources.ApplyResources(this.MI_HueLess, "MI_HueLess");
            this.MI_HueLess.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_HueMore
            // 
            this.MI_HueMore.Index = 1;
            resources.ApplyResources(this.MI_HueMore, "MI_HueMore");
            this.MI_HueMore.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_Saturation
            // 
            this.MI_Saturation.Index = 6;
            this.MI_Saturation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SaturationLess,
            this.MI_SaturationMore});
            resources.ApplyResources(this.MI_Saturation, "MI_Saturation");
            // 
            // MI_SaturationLess
            // 
            this.MI_SaturationLess.Index = 0;
            resources.ApplyResources(this.MI_SaturationLess, "MI_SaturationLess");
            this.MI_SaturationLess.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // MI_SaturationMore
            // 
            this.MI_SaturationMore.Index = 1;
            resources.ApplyResources(this.MI_SaturationMore, "MI_SaturationMore");
            this.MI_SaturationMore.Click += new System.EventHandler(this.MI_VideoSetting_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // MI_Screenshot
            // 
            this.MI_Screenshot.Index = 8;
            resources.ApplyResources(this.MI_Screenshot, "MI_Screenshot");
            this.MI_Screenshot.Click += new System.EventHandler(this.MI_Screenshot_Click);
            // 
            // MI_Audio
            // 
            this.MI_Audio.Index = 3;
            this.MI_Audio.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SelectAudio,
            this.MI_AudioBalance});
            resources.ApplyResources(this.MI_Audio, "MI_Audio");
            // 
            // MI_SelectAudio
            // 
            this.MI_SelectAudio.Index = 0;
            resources.ApplyResources(this.MI_SelectAudio, "MI_SelectAudio");
            // 
            // MI_AudioBalance
            // 
            this.MI_AudioBalance.Index = 1;
            this.MI_AudioBalance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_AudioBalance_Center,
            this.MI_AudioBalance_Left,
            this.MI_AudioBalance_Right});
            resources.ApplyResources(this.MI_AudioBalance, "MI_AudioBalance");
            // 
            // MI_AudioBalance_Center
            // 
            this.MI_AudioBalance_Center.Index = 0;
            resources.ApplyResources(this.MI_AudioBalance_Center, "MI_AudioBalance_Center");
            this.MI_AudioBalance_Center.Click += new System.EventHandler(this.MI_AudioBalance_Click);
            // 
            // MI_AudioBalance_Left
            // 
            this.MI_AudioBalance_Left.Index = 1;
            resources.ApplyResources(this.MI_AudioBalance_Left, "MI_AudioBalance_Left");
            this.MI_AudioBalance_Left.Click += new System.EventHandler(this.MI_AudioBalance_Click);
            // 
            // MI_AudioBalance_Right
            // 
            this.MI_AudioBalance_Right.Index = 2;
            resources.ApplyResources(this.MI_AudioBalance_Right, "MI_AudioBalance_Right");
            this.MI_AudioBalance_Right.Click += new System.EventHandler(this.MI_AudioBalance_Click);
            // 
            // MI_Subtitle
            // 
            this.MI_Subtitle.Index = 4;
            this.MI_Subtitle.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SelectSubtitle,
            this.MI_OpenSubFile,
            this.menuItem9,
            this.MI_SubEncoding,
            this.MI_SubChineseTrans,
            this.menuItem3,
            this.MI_SubDelayLess,
            this.MI_SubDelayMore,
            this.menuItem22,
            this.MI_SubPosUp,
            this.MI_SubPosDown,
            this.menuItem26,
            this.MI_SubScaleDown,
            this.MI_SubScaleUp});
            resources.ApplyResources(this.MI_Subtitle, "MI_Subtitle");
            // 
            // MI_SelectSubtitle
            // 
            this.MI_SelectSubtitle.Index = 0;
            resources.ApplyResources(this.MI_SelectSubtitle, "MI_SelectSubtitle");
            // 
            // MI_OpenSubFile
            // 
            this.MI_OpenSubFile.Index = 1;
            resources.ApplyResources(this.MI_OpenSubFile, "MI_OpenSubFile");
            this.MI_OpenSubFile.Click += new System.EventHandler(this.MI_OpenSubFile_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            resources.ApplyResources(this.menuItem9, "menuItem9");
            // 
            // MI_SubEncoding
            // 
            this.MI_SubEncoding.Index = 3;
            this.MI_SubEncoding.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem15,
            this.menuItem5,
            this.menuItem21,
            this.menuItem25,
            this.menuItem24,
            this.menuItem23});
            resources.ApplyResources(this.MI_SubEncoding, "MI_SubEncoding");
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            resources.ApplyResources(this.menuItem18, "menuItem18");
            this.menuItem18.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            resources.ApplyResources(this.menuItem15, "menuItem15");
            this.menuItem15.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem5
            // 
            resources.ApplyResources(this.menuItem5, "menuItem5");
            this.menuItem5.Index = 2;
            this.menuItem5.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 3;
            resources.ApplyResources(this.menuItem21, "menuItem21");
            this.menuItem21.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 4;
            resources.ApplyResources(this.menuItem25, "menuItem25");
            this.menuItem25.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 5;
            resources.ApplyResources(this.menuItem24, "menuItem24");
            this.menuItem24.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 6;
            resources.ApplyResources(this.menuItem23, "menuItem23");
            this.menuItem23.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // MI_SubChineseTrans
            // 
            this.MI_SubChineseTrans.Index = 4;
            this.MI_SubChineseTrans.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ChineseNone,
            this.MI_ToTradChinese,
            this.MI_ToSimpChinese});
            resources.ApplyResources(this.MI_SubChineseTrans, "MI_SubChineseTrans");
            // 
            // MI_ChineseNone
            // 
            this.MI_ChineseNone.Index = 0;
            resources.ApplyResources(this.MI_ChineseNone, "MI_ChineseNone");
            this.MI_ChineseNone.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // MI_ToTradChinese
            // 
            this.MI_ToTradChinese.Index = 1;
            resources.ApplyResources(this.MI_ToTradChinese, "MI_ToTradChinese");
            this.MI_ToTradChinese.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // MI_ToSimpChinese
            // 
            this.MI_ToSimpChinese.Index = 2;
            resources.ApplyResources(this.MI_ToSimpChinese, "MI_ToSimpChinese");
            this.MI_ToSimpChinese.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            resources.ApplyResources(this.menuItem3, "menuItem3");
            // 
            // MI_SubDelayLess
            // 
            this.MI_SubDelayLess.Index = 6;
            resources.ApplyResources(this.MI_SubDelayLess, "MI_SubDelayLess");
            this.MI_SubDelayLess.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // MI_SubDelayMore
            // 
            this.MI_SubDelayMore.Index = 7;
            resources.ApplyResources(this.MI_SubDelayMore, "MI_SubDelayMore");
            this.MI_SubDelayMore.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 8;
            resources.ApplyResources(this.menuItem22, "menuItem22");
            // 
            // MI_SubPosUp
            // 
            this.MI_SubPosUp.Index = 9;
            resources.ApplyResources(this.MI_SubPosUp, "MI_SubPosUp");
            this.MI_SubPosUp.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // MI_SubPosDown
            // 
            this.MI_SubPosDown.Index = 10;
            resources.ApplyResources(this.MI_SubPosDown, "MI_SubPosDown");
            this.MI_SubPosDown.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 11;
            resources.ApplyResources(this.menuItem26, "menuItem26");
            // 
            // MI_SubScaleDown
            // 
            this.MI_SubScaleDown.Index = 12;
            resources.ApplyResources(this.MI_SubScaleDown, "MI_SubScaleDown");
            this.MI_SubScaleDown.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // MI_SubScaleUp
            // 
            this.MI_SubScaleUp.Index = 13;
            resources.ApplyResources(this.MI_SubScaleUp, "MI_SubScaleUp");
            this.MI_SubScaleUp.Click += new System.EventHandler(this.MI_SubSetting_Click);
            // 
            // MI_Tools
            // 
            this.MI_Tools.Index = 5;
            this.MI_Tools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.MI_EditShortcut,
            this.menuItem12,
            this.MI_Option});
            resources.ApplyResources(this.MI_Tools, "MI_Tools");
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // MI_EditShortcut
            // 
            this.MI_EditShortcut.Index = 1;
            resources.ApplyResources(this.MI_EditShortcut, "MI_EditShortcut");
            this.MI_EditShortcut.Click += new System.EventHandler(this.MI_EditShortcut_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            resources.ApplyResources(this.menuItem12, "menuItem12");
            // 
            // MI_Option
            // 
            this.MI_Option.Index = 3;
            resources.ApplyResources(this.MI_Option, "MI_Option");
            this.MI_Option.Click += new System.EventHandler(this.MI_Option_Click);
            // 
            // MI_Help
            // 
            this.MI_Help.Index = 6;
            this.MI_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_About});
            resources.ApplyResources(this.MI_Help, "MI_Help");
            // 
            // MI_About
            // 
            this.MI_About.Index = 0;
            resources.ApplyResources(this.MI_About, "MI_About");
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
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.VSplit;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseMove);
            this.splitter1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseDown);
            this.splitter1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseUp);
            // 
            // Playlist
            // 
            this.Playlist.AllowDrop = true;
            this.Playlist.FullRowSelect = true;
            resources.ApplyResources(this.Playlist, "Playlist");
            this.Playlist.Name = "Playlist";
            this.Playlist.UseCompatibleStateImageBehavior = false;
            this.Playlist.View = System.Windows.Forms.View.Details;
            this.Playlist.DoubleClick += new System.EventHandler(this.Playlist_DoubleClick);
            this.Playlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.Playlist_DragDrop);
            this.Playlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.Playlist_DragEnter);
            this.Playlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Playlist_KeyDown);
            this.Playlist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Playlist_ItemDrag);
            this.Playlist.DragOver += new System.Windows.Forms.DragEventHandler(this.Playlist_DragOver);
            // 
            // VolumeBar
            // 
            this.VolumeBar.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.VolumeBar, "VolumeBar");
            this.VolumeBar.Maximum = 10;
            this.VolumeBar.Minimum = 0;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Value = 10;
            this.VolumeBar.OnValueChanged += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // btn_mute
            // 
            this.btn_mute.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btn_mute, "btn_mute");
            this.btn_mute.FontAntiAlias = true;
            this.btn_mute.ForeColor = System.Drawing.Color.White;
            this.btn_mute.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btn_mute.Name = "btn_mute";
            this.btn_mute.RoundedCornerRadius = 3;
            this.btn_mute.UseVisualStyleBackColor = false;
            this.btn_mute.Click += new System.EventHandler(this.btn_mute_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btn_pause, "btn_pause");
            this.btn_pause.FontAntiAlias = true;
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.RoundedCornerRadius = 3;
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_inspeed
            // 
            this.btn_inspeed.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btn_inspeed, "btn_inspeed");
            this.btn_inspeed.FontAntiAlias = true;
            this.btn_inspeed.ForeColor = System.Drawing.Color.White;
            this.btn_inspeed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btn_inspeed.Name = "btn_inspeed";
            this.btn_inspeed.RoundedCornerRadius = 3;
            this.btn_inspeed.UseVisualStyleBackColor = false;
            this.btn_inspeed.Click += new System.EventHandler(this.btn_inspeed_Click);
            // 
            // btn_despeed
            // 
            this.btn_despeed.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btn_despeed, "btn_despeed");
            this.btn_despeed.FontAntiAlias = true;
            this.btn_despeed.ForeColor = System.Drawing.Color.White;
            this.btn_despeed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btn_despeed.Name = "btn_despeed";
            this.btn_despeed.RoundedCornerRadius = 3;
            this.btn_despeed.UseVisualStyleBackColor = false;
            this.btn_despeed.Click += new System.EventHandler(this.btn_despeed_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btn_stop, "btn_stop");
            this.btn_stop.FontAntiAlias = true;
            this.btn_stop.ForeColor = System.Drawing.Color.White;
            this.btn_stop.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.RoundedCornerRadius = 3;
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Playlist);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// À³¥Îµ{¦¡ªº¥D¶i¤JÂI¡C
		/// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int pid = Process.GetCurrentProcess().Id;
            string pname = Process.GetCurrentProcess().ProcessName;
            Process[] ps = Process.GetProcessesByName(pname);

            foreach (Process p in ps)
            {
                if(p.Id != pid)
                    p.Kill();
            }

            ps = Process.GetProcessesByName("mplayer");
            //ps = Process.GetProcesses();

            foreach (Process p in ps)
            {
                p.Kill();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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
				this.Start(Playlist_Current());
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            //UI Setting
			MainPanel.Top = 0;
			MainPanel.Left = 0;

			BigScreen.Top = 0;
			BigScreen.Left = 0;

            // setup panel1
            panel1.Height = MovieBar.Height + btn_pause.Height + txtStatus.Height;			

			MovieBar.Top = MovieBar.Left = 0;

			btn_despeed.Top = btn_inspeed.Top = btn_stop.Top = btn_pause.Top = MovieBar.Top + MovieBar.Height;
            btn_mute.Top = btn_pause.Top;
            VolumeBar.Top = btn_pause.Top;

            btn_pause.Left = 0;
			btn_stop.Left = btn_pause.Left + btn_pause.Width;
			btn_despeed.Left = btn_stop.Left + btn_stop.Width + 10;
			btn_inspeed.Left = btn_despeed.Left + btn_despeed.Width;

            txtStatus.Top = btn_pause.Top + btn_pause.Height;
            txtStatus.Left = 0;

			Playlist.Top = 0;
			Playlist.Columns.Add("Playlist", -2, HorizontalAlignment.Left);

			this.txtShortcut.Size = new Size(0, 0);

			this.Form1_Resize(null, null);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{			
			MovieBar.Width = txtStatus.Width = panel1.Width;
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

		public void adjBigScreen()
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

                needAdjBigScreen = true;
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
            //get { return !(btn_pause.ImageIndex == 0); }
            get { return (btn_pause.Font == FontPause); }
        }

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			Stop();
		}


		private void VolumeBar_Scroll(object sender, System.EventArgs e)
		{
            double old_volume = mp.Volume;
            double new_volume = ((int)VolumeBar.Value) * 10;

            if (new_volume != old_volume)
            {
                mp.Volume = VolumeBar.Value * 10;
                btn_mute.ImageIndex = 3;
            }

            this.txtShortcut.Focus();
		}


		private void MI_OpenURL_Click(object sender, System.EventArgs e)
		{
			OpenURL urlForm = new OpenURL();

            /*
			if(urlForm.ShowDialog() == DialogResult.OK)
			{
				if(urlForm.URL.IndexOf("//") > 0)
				{
					this.Start(urlForm.URL);
				}
			}
            */
		}

		#region GUI Movie Control

        private void Start(MPlaylistItem item)
		{
			if(mp.HasInstense())
				Quit();

			if(mp.Start(item))
			{
                txtStatus.Text = string.Format("Start playing {0}", mp.Filename);

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
                SetBtnPause();
				this.btn_stop.Enabled = true;
				this.btn_despeed.Enabled = true;
				this.btn_inspeed.Enabled = true;

				this.VolumeBar_Scroll(null, null);
			
				this.AppendSubtitleMenuItem(this.MI_SelectSubtitle);
                this.AppendAudioIDMenuItem(this.MI_SelectAudio);

                //this.MI_Zoom_Click(MI_Zoom100, null);
				this.Form1_Resize(null, null);

                needSyncTime = true;
				timer1.Start();
			}

			this.txtShortcut.Focus();
		}

        private void SetBtnPlay()
        {
            //btn_pause.ImageIndex = 1;
            btn_pause.Text = "u";
            btn_pause.Font = FontPlay;
            btn_pause.HoverColor = Color.FromArgb(0x99CC99);
        }

        private void SetBtnPause()
        {
            //btn_pause.ImageIndex = 0;
            btn_pause.Text = "ƒ«";
            btn_pause.Font = FontPause;
            btn_pause.HoverColor = Color.FromArgb(0xCCCC99);
        }

		private void Pause()
		{
			if(mp.HasInstense())
			{
				mp.Pause();

				if(!isPlaying)
				{
                    SetBtnPause();
                    this.txtStatus.Text = "Playing - " + strTimeStamp(this.nowTimePos, (int)mp.Length);
                    timer1.Start();
				}
				else
				{
					timer1.Stop();
                    SetBtnPlay();
                    this.txtStatus.Text = "Paused - " + strTimeStamp(this.nowTimePos, (int) mp.Length);
				}
			}

			this.txtShortcut.Focus();
		}

		private void Stop()
		{
            timer1.Stop();
            mp.Stop();
            SetBtnPlay();
			MovieBar.Value = 0;
            this.nowTimePos = 0;

			this.txtShortcut.Focus();
            this.txtStatus.Text = "Stopped";
		}

		private void Quit()
		{
			// log last media file
			if(mp.mediaType == MediaType.File)
			{
                if(mp.HasInstense())
				    mp.Setting[SetVars.LastMedia] = mp.Filename.ToLower() + ":" + mp.Time_Pos;
                else
                    mp.Setting[SetVars.LastMedia] = mp.Filename.ToLower() + ":0.0";

				mp.Setting.WriteSetting();
			}

			mp.Quit();
			Stop();

			this.MI_SelectSubtitle.MenuItems.Clear();
            this.MI_SelectAudio.MenuItems.Clear();

            this.txtStatus.Text = "End";
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
				bool paused = (isPlaying) ? false : true;
                int movieBar = MovieBar.Value;

				Quit();
				mp.CurrentSubtitle = sub;

				Start(Playlist_Current());

				MovieBar.Value = movieBar;
				mp.Time_Pos = pos;

				if(paused)
					Pause();
			}
		}

		private void Seek(double time_pos)
		{
			double length = mp.Length;

            if (length <= 0)
                return;

			if(time_pos > length)
				time_pos = length;
			else if(time_pos < 0)
				time_pos = 0;

			mp.Time_Pos = time_pos;
            nowTimePos = (int)time_pos;

			MovieBar.Value = (int) (100 * time_pos / length);
            this.txtStatus.Text = strTimeStamp((int) time_pos, (int) length);
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
                string[] fnames = new string[this.openFileDialog1.FileNames.Length];

                for (int i = this.openFileDialog1.FileNames.Length - 1; i >= 0; i--)
                {
                    fnames[this.openFileDialog1.FileNames.Length - 1 - i] = this.openFileDialog1.FileNames[i];
                }
    
				Playlist.Items.Clear();
				this.Playlist_AddItem(MediaType.File, fnames);

				Start(Playlist_First());
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
			// mute
            btn_mute.Text = (mp.Mute() == true) ? "ƒè" : "ƒÅ";
            this.txtShortcut.Focus();
		}

        private bool needAdjBigScreen = false;
        private bool needAppendAudioChannel = false;
        private bool needSyncTime = true;
        private int nowTimePos = 0;

        private delegate void SetTimeDelegate(int newTimePos);

        private void SetTimePosUI(int newTimePos)
        {
            nowTimePos = newTimePos;
            int movie_len = (int)mp.Length;

            if (nowTimePos != 0 && movie_len != 0)
            {
                this.txtStatus.Text = strTimeStamp(nowTimePos, movie_len);

                // some video has broken header with wrong Lengh value
                if (nowTimePos <= movie_len)
                    this.MovieBar.Value = (100 * nowTimePos) / movie_len;
            }
            else
            {
                this.txtStatus.Text = "0:0:0 / 0:0:0";
                this.MovieBar.Value = 0;
            }
        }

        public void SetTimePos(MyStreamReader sender, string str)
        {
            str = MediaInfo.isStateString(str);

            if (str != null && this != null && str.StartsWith("TIME_POSITION"))
            {
                mp.minfo.SetState(sender, str);
                int time_pos = (int)mp.Time_Pos;

                // safe Thread
                if (this.MovieBar.InvokeRequired || this.txtStatus.InvokeRequired)
                {
                    SetTimeDelegate d = new SetTimeDelegate(SetTimePosUI);
                    this.Invoke(d, new object[] { time_pos });
                }
                else
                    SetTimePosUI(time_pos);
            }
            return;
        }

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
                int movie_len = (int) mp.Length;

                // some video has broken header with wrong Lengh value
                if (nowTimePos >= movie_len)
                {
                    mp.SendSlaveCommand(SlaveCommandMode.None, "get_length");
                    needSyncTime = true;
                }

                if (needSyncTime || nowTimePos % 60 == 0)
                {
                    mp.SendSlaveCommand(SlaveCommandMode.None, "get_time_pos");
                    needSyncTime = false;
                }
                else
                    SetTimePosUI(nowTimePos+1);

                if (isFullscreen)
                {
                    if (Cursor.Position.Y < this.MainPanel.Height - this.panel1.Height)
                        HideMouse();
                }

                // do refresh
                // FIXME: ...........
                if (needAdjBigScreen == true)
                {
                    needAdjBigScreen = false;
                    this.adjBigScreen();
                }
                else if (needAppendAudioChannel)
                {
                    needAppendAudioChannel = false;
                    this.AppendAudioIDMenuItem(MI_SelectAudio);
                }
			}
			else
			{
				Quit();

				MPlaylistItem item = Playlist_Next();
                if (item != null)
                {
                    Start(item);
                }
                else
                {
                    if (isFullscreen)
                    {
                        this.BigScreen_DoubleClick(sender, e);
                    }
                }
			}
        }

        #region Cursor Hide/Show

        private bool isMouseHide = false;

        private void HideMouse()
        {
            if (!isMouseHide)
            {
                Cursor.Hide();
                isMouseHide = true;
            }
        }

        private void ShowMouse()
        {
            if (isMouseHide)
            {
                Cursor.Show();
                isMouseHide = false;
            }
        }

        #endregion

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
				this.splitter1.Visible = this.Playlist.Visible = false;
				oldFormSize = this.Size;
                oldFormLocation = this.Location;

				this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;
                this.WindowState = FormWindowState.Normal;
                                
                Bounds = Screen.FromHandle(this.Handle).Bounds;

                ScreenSaver.SetScreenSaverActive(0);
                ScreenSaver.PreventMonitorPowerdown();
                HideMouse();
			}
			else
			{
				this.Menu = this.mainMenu1;
				this.splitter1.Visible = this.Playlist.Visible = this.MI_ShowPlaylist.Checked;

				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.TopMost = this.MI_TopMost.Checked;

				this.Size = oldFormSize;
				this.Playlist.Width = this.oldPlaylistWidth;
                this.Location = oldFormLocation;

                ScreenSaver.SetScreenSaverActive(1);
                ScreenSaver.AllowMonitorPowerdown();
                ShowMouse();
			}

            this.Form1_Resize(sender, e);
            this.Refresh(); // force the Form do refresh / resize

            mp.RelativeTime_Pos = 0; // then we refresh the screen to fit new size
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

        private void MI_SubSetting_Click(object sender, System.EventArgs e)
        {
            if (sender == MI_SubDelayLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_delay -0.1");
            else if(sender == MI_SubDelayMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_delay 0.1");
            else if(sender == MI_SubScaleDown)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_scale -0.2");
            else if (sender == MI_SubScaleUp)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_scale 0.2");
            else if (sender ==MI_SubPosDown)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_pos 1");
            else if (sender == MI_SubPosUp)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "sub_pos -1");
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

        private void MI_SubChineseTrans_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MI_SubChineseTrans.MenuItems.Count; i++)
            {
                MenuItem mi = MI_SubChineseTrans.MenuItems[i];

                if (mi == (MenuItem)sender)
                {
                    mi.Checked = true;
                    mp.Setting[SetVars.SubChineseTrans] = i.ToString();
                    mp.Setting.WriteSetting();
                }
                else
                    mi.Checked = false;
            }

            Restart();
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
                ShowMouse();

                if (e.Y > this.MainPanel.Height - this.panel1.Height)
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

            Playlist.Items.Clear();
			this.Playlist_AddItem(MediaType.File, s);

			Start(Playlist_First());
		}

		#endregion

		#region MenuItem:Video

		private void MI_VideoSetting_Click(object sender, System.EventArgs e)
		{
            if (sender == MI_BrightnessMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "brightness 1");
            else if (sender == MI_BrightnessLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "brightness -1");
            else if (sender == MI_ContrastMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "contrast 1");
            else if (sender == MI_ContrastLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "contrast -1");
            else if (sender == MI_GammaMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "gamma 10");
            else if (sender == MI_GammaLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "gamma -10");
            else if (sender == MI_HueMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "hue 10");
            else if (sender == MI_HueLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "hue -10");
            else if (sender == MI_SaturationMore)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "saturation 10");
            else if (sender == MI_SaturationLess)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, "saturation -10");
		}

		private void MI_Zoom_Click(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
                int width = mp.Video_Width;
                int height = mp.Video_Height;

                if (width != 0 && height != 0)
                {
                    MenuItem mi = (MenuItem)sender;

                    if (this.WindowState == FormWindowState.Maximized)
                        this.WindowState = FormWindowState.Normal;

                    if (mi == this.MI_Zoom50)
                    {
                        width /= 2;
                        height /= 2;
                    }
                    else if (mi == this.MI_Zoom200)
                    {
                        width *= 2;
                        height *= 2;
                    }

                    height += this.panel1.Height;

                    if (this.Playlist.Visible)
                        width += this.Playlist.Width;

                    this.ClientSize = new Size(width, height);
                }

                // for first call Form1_Resize() in Start()
				this.Form1_Resize(null, null);
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

        private MPlaylistItem PlaylistNowItem;

        private MPlaylistItem Playlist_First()
        {
            PlaylistNowItem = null;

            if (Playlist.Items.Count > 0)
            {
                return PlaylistNowItem = Playlist.Items[0] as MPlaylistItem;
            }

            return null;
        }

        private MPlaylistItem Playlist_Current()
        {
            return PlaylistNowItem;
        }

        private MPlaylistItem Playlist_Next()
        {
            int PlaylistNowIndex = Playlist.Items.IndexOf((ListViewItem)PlaylistNowItem);

            if (PlaylistNowIndex >= 0 && PlaylistNowIndex < Playlist.Items.Count - 1)
            {
                return PlaylistNowItem = Playlist.Items[++PlaylistNowIndex] as MPlaylistItem;
            }

            return null;
        }

        private MPlaylistItem Playlist_GetItem(int index)
        {
            if (index >= 0 && index < Playlist.Items.Count)
            {
                return PlaylistNowItem = (MPlaylistItem) Playlist.Items[index];
            }

            return null;
        }

		private void Playlist_DoubleClick(object sender, System.EventArgs e)
		{
			int index = Playlist.SelectedIndices[0];
			this.Start( Playlist_GetItem(index) );
		}

        private void Playlist_AddItem(MediaType type, params string[] files)
        {
            foreach (string s in files)
            {
                Playlist_AddItem(new MPlaylistItem(type, s));
            }
        }

		private void Playlist_AddItem(MPlaylistItem item)
		{
            this.Playlist.Items.Add(item as ListViewItem);
		}

        // Sets the target drop effect.
		private void Playlist_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
		}

		private void Playlist_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                this.Playlist_AddItem(MediaType.File, s);

                //MessageBox.Show("Add success");
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // Retrieve the index of the insertion mark;
                //int targetIndex = Playlist.InsertionMark.Index;
                Point targetPoint =
                    Playlist.PointToClient(new Point(e.X, e.Y));

                ListViewItem targetItem = Playlist.GetItemAt(targetPoint.X, targetPoint.Y);

                int targetIndex = Playlist.Items.IndexOf(targetItem);
    
                // If the insertion mark is not visible, exit the method.
                if (targetIndex == -1)
                {
                    return;
                }

                // Retrieve the dragged item.
                MPlaylistItem draggedItem =
                    (MPlaylistItem)e.Data.GetData(typeof(MPlaylistItem));

                // Insert a copy of the dragged item at the target index.
                // A copy must be inserted before the original item is removed
                // to preserve item index values. 
                Playlist.Items.Insert(
                    targetIndex, (ListViewItem)draggedItem.Clone());

                // Remove the original copy of the dragged item.
                Playlist.Items.Remove(draggedItem);
            }
		}

		private void Playlist_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				for(int i=Playlist.SelectedIndices.Count-1;i>=0;i--)
				{
                    Playlist.Items.RemoveAt(Playlist.SelectedIndices[i]);
				}
			}
		}

        // Playlist ItemDrag implement from http://msdn.microsoft.com/zh-tw/library/hx62xfd2(VS.80).aspx

        // Starts the drag-and-drop operation when an item is dragged.
        private void Playlist_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Playlist.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        // Moves the insertion mark as the item is dragged.
        private void Playlist_DragOver(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                Point targetPoint = Playlist.PointToClient(new Point(e.X, e.Y));
                ListViewItem targetItem = Playlist.GetItemAt(targetPoint.X, targetPoint.Y);
                int targetIndex = Playlist.Items.IndexOf(targetItem);
                int fromIndex = Playlist.SelectedIndices[0];

                if (fromIndex != targetIndex)
                {
                    Playlist.Items[fromIndex].Selected = false;
                    Playlist.Items[targetIndex].Selected = true;
                }
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
            this.needSyncTime = true;

            if(this.isPlaying)
			    this.timer1.Start();

            this.txtShortcut.Focus();
		}

        private string strTimeStamp(int pos, int len)
        {
            string str_now_pos = "0:0:0";
            string str_movie_len = str_now_pos;

            if (pos > 0 && len > 0)
            {
                str_now_pos = (pos / 3600) + ":" + ((pos / 60) % 60) + ":" + (pos % 60);
            }
            if (len > 0)
            {
                str_movie_len = (len / 3600) + ":" + ((len / 60) % 60) + ":" + (len % 60);
            }

            return str_now_pos + " / " + str_movie_len;
        }

		private void MovieBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(MBar_MouseDown)
			{
				double val = (double) e.X / MovieBar.Width;

				int len = (int) mp.Length;
				int pos = (int) (val*len);		
				this.txtStatus.Text = strTimeStamp(pos, len);
			}
		}

		#endregion

		private void MI_LastOpen_Click(object sender, System.EventArgs e)
		{
			string s = mp.Setting[SetVars.LastMedia];
			if(s != null && s != "")
			{
				int index = s.IndexOf(':', 3);

                Playlist.Items.Clear();
				this.Playlist_AddItem(MediaType.File, s.Substring(0, index));

				this.Start(Playlist_First());
			}
        }

        #region txtShortcut events

        private void txtShortcut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Escape)
            {
                if (isFullscreen)
                    this.BigScreen_DoubleClick(sender, e);
            }

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
            else if (cmd.StartsWith("mute"))
            {
                btn_mute_Click(null, null);
            }
            else if (cmd.StartsWith("vo_ontop"))
            {
                this.MI_TopMost_Click(null, null);
            }
            else if (cmd.StartsWith("vo_fullscreen"))
            {
                this.BigScreen_DoubleClick(null, null);
            }
            else if (cmd.StartsWith("quit"))
            {
                this.Quit();
                if (this.isFullscreen)
                    this.BigScreen_DoubleClick(sender, e);
            }
            else
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep, cmd);

            this.needSyncTime = true;
		}

		private void txtShortcut_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.txtShortcut.Text = "";
        }

        #endregion

        private void btn_despeed_Click(object sender, System.EventArgs e)
		{
			mp.Speed_mult = 0.5;
            this.txtShortcut.Focus();
		}

		private void btn_inspeed_Click(object sender, System.EventArgs e)
		{
			mp.Speed_mult = 2;
            this.txtShortcut.Focus();
		}

        private string ScreenshotFilename = null;

        public void ScreenshotHandler(MyStreamReader sender, string s)
        {
            string str_sample = "*** screenshot '";

            if (s.StartsWith(str_sample))
            {
                string fname = s.Substring(str_sample.Length, s.Length - 5 - str_sample.Length);
                fname = string.Format(@"{0}\{1}", Path.GetDirectoryName(mp.Setting[SetVars.MplayerExe]), fname);

                while (!File.Exists(fname))
                    System.Threading.Thread.Sleep(500);

                System.Threading.Thread.Sleep(1000);    // waiting for mplayer creating picture

                ScreenshotFilename += Path.GetExtension(fname);

                if (ScreenshotFilename != null)
                {
                    if (File.Exists(ScreenshotFilename))
                        File.Delete(ScreenshotFilename);

                    File.Move(fname, ScreenshotFilename);
                }
                else
                    File.Delete(fname);

                ScreenshotFilename = null;
                sender.OnAppendNewLine -= ScreenshotHandler;
            }

            return;
        }

        private void MI_Screenshot_Click(object sender, EventArgs e)
        {
            if (mp.HasInstense())
            {
                if (isPlaying)
                    Pause();

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel || saveFileDialog1.FileName == "")
                    return;

                ScreenshotFilename = String.Format(@"{0}\{1}",Path.GetDirectoryName(saveFileDialog1.FileName), Path.GetFileNameWithoutExtension(saveFileDialog1.FileName));
                mp.Screenshot(ScreenshotHandler);
            }
        }

        #region Audio

        private void MI_AudioID_Click(object sender, EventArgs e)
        {
            foreach(MenuItem mi in this.MI_SelectAudio.MenuItems)
            {
                mi.Checked = false;
            }

            MenuItem m = (MenuItem)sender;
            mp.Audio_Select(m.Text);
            m.Checked = true;                     
        }

        private void AppendAudioIDMenuItem(MenuItem owner)
        {
            owner.MenuItems.Clear();

            if (mp.AudioChannels.Count > 0)
            {
                foreach (int j in mp.AudioChannels)
                {
                    MenuItem mi = new MenuItem(j.ToString());
                    mi.RadioCheck = true;
                    mi.Click += new EventHandler(this.MI_AudioID_Click);

                    owner.MenuItems.Add(mi);
                }

                owner.MenuItems[0].Checked = true;
            }
            else
                needAppendAudioChannel = true;
        }

        #endregion

        private void MI_EditShortcut_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", MShortcut.GetShortcutPath(mp.Setting[SetVars.MplayerExe]));
        }

        private void MI_AudioBalance_Click(object sender, EventArgs e)
        {
            if (sender == MI_AudioBalance_Center)
            {
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "balance -2");
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "balance +1");
            }
            else if (sender == MI_AudioBalance_Left)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "balance -2");
            else if (sender == MI_AudioBalance_Right)
                mp.SendSlaveCommand(SlaveCommandMode.Pausing_Keep_Force, "balance +2");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pl = sender as Panel;
            Graphics g = e.Graphics;

            Color c1 = Color.Black;
            Color c2 = Color.DimGray;

            Brush linearBrush = new LinearGradientBrush(pl.ClientRectangle, c2, c1, LinearGradientMode.Vertical);

            int width = pl.Width;
            int height = pl.Height;

            g.FillRectangle(new SolidBrush(c1), 0, height / 2, width, height / 2);
            g.FillRectangle(linearBrush, 0, 0, width, height / 2);
        }

        private void MI_OpenVCD_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            string path = folderBrowserDialog1.SelectedPath;
            string volumeName = path.Substring(0, 3);

            DriveInfo di = new DriveInfo(volumeName);
            if (di.DriveFormat != "CDFS")
            {
                MessageBox.Show("Please put VCD disk.");
                return;
            }

            this.Playlist.Items.Clear();

            string[] files = Mplayer.getVCDTracks(mp.Setting[SetVars.MplayerExe], volumeName);

            this.Playlist_AddItem(MediaType.VCD, files);

            Start(Playlist_First());
        }
    }
}