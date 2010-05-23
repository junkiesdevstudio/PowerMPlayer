using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace Power_Mplayer
{
	/// <summary>
	/// Form1 ���K�n�y�z�C
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.ComponentModel.IContainer components;
        public Panel BigScreen;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.TrackBar VolumeBar;
		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ProgressBar MovieBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btn_pause;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.Button btn_mute;
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
        private System.Windows.Forms.MenuItem MI_Exit;
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
        private MenuItem MI_OpenDVD;
        private TextBox txtStatus;
        private MenuItem MI_SubChineseTrans;
        private MenuItem MI_ChineseNone;
        private MenuItem MI_ToTradChinese;
        private MenuItem MI_ToSimpChinese;
        private MenuItem MI_EditShortcut;
        private MenuItem MI_SelectAudio;

		// constructure
		private Form1()
		{
            mp = new Mplayer(this);

			//set the UI language
			if (this.mp.Setting[SetVars.Language] != "")
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(this.mp.Setting[SetVars.Language]);

			// Windows Form
			InitializeComponent();

            // set BigScreen
            mp.BigScreen = this.BigScreen;
            
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
		}

		public Form1(string[] str) : this()
		{
			if(str != null && str.Length > 0)
			{
				this.Playlist_AddItem(str);
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

		#region Windows Form �]�p�u�㲣�ͪ��{���X
		/// <summary>
		/// �����]�p�u��䴩�ҥ�������k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btn_inspeed = new System.Windows.Forms.Button();
            this.btn_despeed = new System.Windows.Forms.Button();
            this.btn_mute = new System.Windows.Forms.Button();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.MovieBar = new System.Windows.Forms.ProgressBar();
            this.txtShortcut = new System.Windows.Forms.TextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MI_File = new System.Windows.Forms.MenuItem();
            this.MI_OpenFile = new System.Windows.Forms.MenuItem();
            this.MI_OpenDVD = new System.Windows.Forms.MenuItem();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_pause
            // 
            this.btn_pause.AccessibleDescription = null;
            this.btn_pause.AccessibleName = null;
            resources.ApplyResources(this.btn_pause, "btn_pause");
            this.btn_pause.BackgroundImage = null;
            this.btn_pause.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_pause.FlatAppearance.BorderSize = 0;
            this.btn_pause.Font = null;
            this.btn_pause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_pause.ImageList = this.imageList1;
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
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
            this.BigScreen.AccessibleDescription = null;
            this.BigScreen.AccessibleName = null;
            this.BigScreen.AllowDrop = true;
            resources.ApplyResources(this.BigScreen, "BigScreen");
            this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BigScreen.BackgroundImage = null;
            this.BigScreen.ContextMenu = this.contextMenu1;
            this.BigScreen.Font = null;
            this.BigScreen.Name = "BigScreen";
            this.BigScreen.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
            this.BigScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BigScreen_MouseMove);
            this.BigScreen.Click += new System.EventHandler(this.btn_pause_Click);
            this.BigScreen.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
            this.BigScreen.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
            // 
            // contextMenu1
            // 
            resources.ApplyResources(this.contextMenu1, "contextMenu1");
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.btn_inspeed);
            this.panel1.Controls.Add(this.btn_despeed);
            this.panel1.Controls.Add(this.btn_mute);
            this.panel1.Controls.Add(this.VolumeBar);
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_pause);
            this.panel1.Controls.Add(this.MovieBar);
            this.panel1.Controls.Add(this.txtShortcut);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // txtStatus
            // 
            this.txtStatus.AccessibleDescription = null;
            this.txtStatus.AccessibleName = null;
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.BackgroundImage = null;
            this.txtStatus.Font = null;
            this.txtStatus.ForeColor = System.Drawing.Color.White;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.TabStop = false;
            // 
            // btn_inspeed
            // 
            this.btn_inspeed.AccessibleDescription = null;
            this.btn_inspeed.AccessibleName = null;
            resources.ApplyResources(this.btn_inspeed, "btn_inspeed");
            this.btn_inspeed.BackgroundImage = null;
            this.btn_inspeed.FlatAppearance.BorderSize = 0;
            this.btn_inspeed.Font = null;
            this.btn_inspeed.ImageList = this.imageList1;
            this.btn_inspeed.Name = "btn_inspeed";
            this.btn_inspeed.Click += new System.EventHandler(this.btn_inspeed_Click);
            // 
            // btn_despeed
            // 
            this.btn_despeed.AccessibleDescription = null;
            this.btn_despeed.AccessibleName = null;
            resources.ApplyResources(this.btn_despeed, "btn_despeed");
            this.btn_despeed.BackgroundImage = null;
            this.btn_despeed.FlatAppearance.BorderSize = 0;
            this.btn_despeed.Font = null;
            this.btn_despeed.ImageList = this.imageList1;
            this.btn_despeed.Name = "btn_despeed";
            this.btn_despeed.Click += new System.EventHandler(this.btn_despeed_Click);
            // 
            // btn_mute
            // 
            this.btn_mute.AccessibleDescription = null;
            this.btn_mute.AccessibleName = null;
            resources.ApplyResources(this.btn_mute, "btn_mute");
            this.btn_mute.BackgroundImage = null;
            this.btn_mute.FlatAppearance.BorderSize = 0;
            this.btn_mute.Font = null;
            this.btn_mute.ImageList = this.imageList1;
            this.btn_mute.Name = "btn_mute";
            this.btn_mute.Click += new System.EventHandler(this.btn_mute_Click);
            // 
            // VolumeBar
            // 
            this.VolumeBar.AccessibleDescription = null;
            this.VolumeBar.AccessibleName = null;
            resources.ApplyResources(this.VolumeBar, "VolumeBar");
            this.VolumeBar.BackgroundImage = null;
            this.VolumeBar.Font = null;
            this.VolumeBar.LargeChange = 2;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Value = 10;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // btn_stop
            // 
            this.btn_stop.AccessibleDescription = null;
            this.btn_stop.AccessibleName = null;
            resources.ApplyResources(this.btn_stop, "btn_stop");
            this.btn_stop.BackgroundImage = null;
            this.btn_stop.FlatAppearance.BorderSize = 0;
            this.btn_stop.Font = null;
            this.btn_stop.ImageList = this.imageList1;
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // MovieBar
            // 
            this.MovieBar.AccessibleDescription = null;
            this.MovieBar.AccessibleName = null;
            resources.ApplyResources(this.MovieBar, "MovieBar");
            this.MovieBar.BackgroundImage = null;
            this.MovieBar.Font = null;
            this.MovieBar.Name = "MovieBar";
            this.MovieBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MovieBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseMove);
            this.MovieBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseDown);
            this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
            // 
            // txtShortcut
            // 
            this.txtShortcut.AccessibleDescription = null;
            this.txtShortcut.AccessibleName = null;
            resources.ApplyResources(this.txtShortcut, "txtShortcut");
            this.txtShortcut.BackColor = System.Drawing.Color.Gold;
            this.txtShortcut.BackgroundImage = null;
            this.txtShortcut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShortcut.Font = null;
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyDown);
            this.txtShortcut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShortcut_KeyUp);
            // 
            // MainPanel
            // 
            this.MainPanel.AccessibleDescription = null;
            this.MainPanel.AccessibleName = null;
            this.MainPanel.AllowDrop = true;
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.BackgroundImage = null;
            this.MainPanel.ContextMenu = this.contextMenu1;
            this.MainPanel.Controls.Add(this.BigScreen);
            this.MainPanel.Font = null;
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
            resources.ApplyResources(this.mainMenu1, "mainMenu1");
            // 
            // MI_File
            // 
            resources.ApplyResources(this.MI_File, "MI_File");
            this.MI_File.Index = 0;
            this.MI_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_OpenFile,
            this.MI_OpenDVD,
            this.MI_OpenURL,
            this.menuItem6,
            this.MI_LastOpen,
            this.menuItem4,
            this.MI_Exit});
            // 
            // MI_OpenFile
            // 
            resources.ApplyResources(this.MI_OpenFile, "MI_OpenFile");
            this.MI_OpenFile.Index = 0;
            this.MI_OpenFile.Click += new System.EventHandler(this.Menu_OpenFile);
            // 
            // MI_OpenDVD
            // 
            resources.ApplyResources(this.MI_OpenDVD, "MI_OpenDVD");
            this.MI_OpenDVD.Index = 1;
            // 
            // MI_OpenURL
            // 
            resources.ApplyResources(this.MI_OpenURL, "MI_OpenURL");
            this.MI_OpenURL.Index = 2;
            this.MI_OpenURL.Click += new System.EventHandler(this.MI_OpenURL_Click);
            // 
            // menuItem6
            // 
            resources.ApplyResources(this.menuItem6, "menuItem6");
            this.menuItem6.Index = 3;
            // 
            // MI_LastOpen
            // 
            resources.ApplyResources(this.MI_LastOpen, "MI_LastOpen");
            this.MI_LastOpen.Index = 4;
            this.MI_LastOpen.Click += new System.EventHandler(this.MI_LastOpen_Click);
            // 
            // menuItem4
            // 
            resources.ApplyResources(this.menuItem4, "menuItem4");
            this.menuItem4.Index = 5;
            // 
            // MI_Exit
            // 
            resources.ApplyResources(this.MI_Exit, "MI_Exit");
            this.MI_Exit.Index = 6;
            this.MI_Exit.Click += new System.EventHandler(this.MI_Exit_Click);
            // 
            // MI_Play
            // 
            resources.ApplyResources(this.MI_Play, "MI_Play");
            this.MI_Play.Index = 1;
            this.MI_Play.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ShowPlaylist,
            this.MI_TopMost,
            this.MI_Fullscreen});
            // 
            // MI_ShowPlaylist
            // 
            resources.ApplyResources(this.MI_ShowPlaylist, "MI_ShowPlaylist");
            this.MI_ShowPlaylist.Index = 0;
            this.MI_ShowPlaylist.Click += new System.EventHandler(this.MI_ShowPlaylist_Click);
            // 
            // MI_TopMost
            // 
            resources.ApplyResources(this.MI_TopMost, "MI_TopMost");
            this.MI_TopMost.Index = 1;
            this.MI_TopMost.Click += new System.EventHandler(this.MI_TopMost_Click);
            // 
            // MI_Fullscreen
            // 
            resources.ApplyResources(this.MI_Fullscreen, "MI_Fullscreen");
            this.MI_Fullscreen.Index = 2;
            this.MI_Fullscreen.Click += new System.EventHandler(this.BigScreen_DoubleClick);
            // 
            // MI_Video
            // 
            resources.ApplyResources(this.MI_Video, "MI_Video");
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
            // 
            // MI_Zoom
            // 
            resources.ApplyResources(this.MI_Zoom, "MI_Zoom");
            this.MI_Zoom.Index = 0;
            this.MI_Zoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_Zoom50,
            this.MI_Zoom100,
            this.MI_Zoom200,
            this.menuItem1,
            this.MI_FixSize});
            // 
            // MI_Zoom50
            // 
            resources.ApplyResources(this.MI_Zoom50, "MI_Zoom50");
            this.MI_Zoom50.Index = 0;
            this.MI_Zoom50.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom100
            // 
            resources.ApplyResources(this.MI_Zoom100, "MI_Zoom100");
            this.MI_Zoom100.Index = 1;
            this.MI_Zoom100.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // MI_Zoom200
            // 
            resources.ApplyResources(this.MI_Zoom200, "MI_Zoom200");
            this.MI_Zoom200.Index = 2;
            this.MI_Zoom200.Click += new System.EventHandler(this.MI_Zoom_Click);
            // 
            // menuItem1
            // 
            resources.ApplyResources(this.menuItem1, "menuItem1");
            this.menuItem1.Index = 3;
            // 
            // MI_FixSize
            // 
            resources.ApplyResources(this.MI_FixSize, "MI_FixSize");
            this.MI_FixSize.Index = 4;
            this.MI_FixSize.Click += new System.EventHandler(this.MI_FixSize_Click);
            // 
            // menuItem2
            // 
            resources.ApplyResources(this.menuItem2, "menuItem2");
            this.menuItem2.Index = 1;
            // 
            // MI_Brightness
            // 
            resources.ApplyResources(this.MI_Brightness, "MI_Brightness");
            this.MI_Brightness.Index = 2;
            this.MI_Brightness.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_BrightnessLess,
            this.MI_BrightnessMore});
            // 
            // MI_BrightnessLess
            // 
            resources.ApplyResources(this.MI_BrightnessLess, "MI_BrightnessLess");
            this.MI_BrightnessLess.Index = 0;
            this.MI_BrightnessLess.Click += new System.EventHandler(this.MI_BrightnessLess_Click);
            // 
            // MI_BrightnessMore
            // 
            resources.ApplyResources(this.MI_BrightnessMore, "MI_BrightnessMore");
            this.MI_BrightnessMore.Index = 1;
            this.MI_BrightnessMore.Click += new System.EventHandler(this.MI_BrightnessMore_Click);
            // 
            // MI_Contrast
            // 
            resources.ApplyResources(this.MI_Contrast, "MI_Contrast");
            this.MI_Contrast.Index = 3;
            this.MI_Contrast.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ContrastLess,
            this.MI_ContrastMore});
            // 
            // MI_ContrastLess
            // 
            resources.ApplyResources(this.MI_ContrastLess, "MI_ContrastLess");
            this.MI_ContrastLess.Index = 0;
            this.MI_ContrastLess.Click += new System.EventHandler(this.MI_ContrastLess_Click);
            // 
            // MI_ContrastMore
            // 
            resources.ApplyResources(this.MI_ContrastMore, "MI_ContrastMore");
            this.MI_ContrastMore.Index = 1;
            this.MI_ContrastMore.Click += new System.EventHandler(this.MI_ContrastMore_Click);
            // 
            // MI_Gamma
            // 
            resources.ApplyResources(this.MI_Gamma, "MI_Gamma");
            this.MI_Gamma.Index = 4;
            this.MI_Gamma.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_GammaLess,
            this.MI_GammaMore});
            // 
            // MI_GammaLess
            // 
            resources.ApplyResources(this.MI_GammaLess, "MI_GammaLess");
            this.MI_GammaLess.Index = 0;
            this.MI_GammaLess.Click += new System.EventHandler(this.MI_GammaLess_Click);
            // 
            // MI_GammaMore
            // 
            resources.ApplyResources(this.MI_GammaMore, "MI_GammaMore");
            this.MI_GammaMore.Index = 1;
            this.MI_GammaMore.Click += new System.EventHandler(this.MI_GammaMore_Click);
            // 
            // MI_Hue
            // 
            resources.ApplyResources(this.MI_Hue, "MI_Hue");
            this.MI_Hue.Index = 5;
            this.MI_Hue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_HueLess,
            this.MI_HueMore});
            // 
            // MI_HueLess
            // 
            resources.ApplyResources(this.MI_HueLess, "MI_HueLess");
            this.MI_HueLess.Index = 0;
            this.MI_HueLess.Click += new System.EventHandler(this.MI_HueLess_Click);
            // 
            // MI_HueMore
            // 
            resources.ApplyResources(this.MI_HueMore, "MI_HueMore");
            this.MI_HueMore.Index = 1;
            this.MI_HueMore.Click += new System.EventHandler(this.MI_HueMore_Click);
            // 
            // MI_Saturation
            // 
            resources.ApplyResources(this.MI_Saturation, "MI_Saturation");
            this.MI_Saturation.Index = 6;
            this.MI_Saturation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SaturationLess,
            this.MI_SaturationMore});
            // 
            // MI_SaturationLess
            // 
            resources.ApplyResources(this.MI_SaturationLess, "MI_SaturationLess");
            this.MI_SaturationLess.Index = 0;
            this.MI_SaturationLess.Click += new System.EventHandler(this.MI_SaturationLess_Click);
            // 
            // MI_SaturationMore
            // 
            resources.ApplyResources(this.MI_SaturationMore, "MI_SaturationMore");
            this.MI_SaturationMore.Index = 1;
            this.MI_SaturationMore.Click += new System.EventHandler(this.MI_SaturationMore_Click);
            // 
            // menuItem7
            // 
            resources.ApplyResources(this.menuItem7, "menuItem7");
            this.menuItem7.Index = 7;
            // 
            // MI_Screenshot
            // 
            resources.ApplyResources(this.MI_Screenshot, "MI_Screenshot");
            this.MI_Screenshot.Index = 8;
            this.MI_Screenshot.Click += new System.EventHandler(this.MI_Screenshot_Click);
            // 
            // MI_Audio
            // 
            resources.ApplyResources(this.MI_Audio, "MI_Audio");
            this.MI_Audio.Index = 3;
            this.MI_Audio.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_SelectAudio});
            // 
            // MI_SelectAudio
            // 
            resources.ApplyResources(this.MI_SelectAudio, "MI_SelectAudio");
            this.MI_SelectAudio.Index = 0;
            // 
            // MI_Subtitle
            // 
            resources.ApplyResources(this.MI_Subtitle, "MI_Subtitle");
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
            // 
            // MI_SelectSubtitle
            // 
            resources.ApplyResources(this.MI_SelectSubtitle, "MI_SelectSubtitle");
            this.MI_SelectSubtitle.Index = 0;
            // 
            // MI_OpenSubFile
            // 
            resources.ApplyResources(this.MI_OpenSubFile, "MI_OpenSubFile");
            this.MI_OpenSubFile.Index = 1;
            this.MI_OpenSubFile.Click += new System.EventHandler(this.MI_OpenSubFile_Click);
            // 
            // menuItem9
            // 
            resources.ApplyResources(this.menuItem9, "menuItem9");
            this.menuItem9.Index = 2;
            // 
            // MI_SubEncoding
            // 
            resources.ApplyResources(this.MI_SubEncoding, "MI_SubEncoding");
            this.MI_SubEncoding.Index = 3;
            this.MI_SubEncoding.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem15,
            this.menuItem5,
            this.menuItem21,
            this.menuItem25,
            this.menuItem24,
            this.menuItem23});
            // 
            // menuItem18
            // 
            resources.ApplyResources(this.menuItem18, "menuItem18");
            this.menuItem18.Index = 0;
            this.menuItem18.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem15
            // 
            resources.ApplyResources(this.menuItem15, "menuItem15");
            this.menuItem15.Index = 1;
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
            resources.ApplyResources(this.menuItem21, "menuItem21");
            this.menuItem21.Index = 3;
            this.menuItem21.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem25
            // 
            resources.ApplyResources(this.menuItem25, "menuItem25");
            this.menuItem25.Index = 4;
            this.menuItem25.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem24
            // 
            resources.ApplyResources(this.menuItem24, "menuItem24");
            this.menuItem24.Index = 5;
            this.menuItem24.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // menuItem23
            // 
            resources.ApplyResources(this.menuItem23, "menuItem23");
            this.menuItem23.Index = 6;
            this.menuItem23.Click += new System.EventHandler(this.MI_SubEncoding_Click);
            // 
            // MI_SubChineseTrans
            // 
            resources.ApplyResources(this.MI_SubChineseTrans, "MI_SubChineseTrans");
            this.MI_SubChineseTrans.Index = 4;
            this.MI_SubChineseTrans.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_ChineseNone,
            this.MI_ToTradChinese,
            this.MI_ToSimpChinese});
            // 
            // MI_ChineseNone
            // 
            resources.ApplyResources(this.MI_ChineseNone, "MI_ChineseNone");
            this.MI_ChineseNone.Index = 0;
            this.MI_ChineseNone.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // MI_ToTradChinese
            // 
            resources.ApplyResources(this.MI_ToTradChinese, "MI_ToTradChinese");
            this.MI_ToTradChinese.Index = 1;
            this.MI_ToTradChinese.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // MI_ToSimpChinese
            // 
            resources.ApplyResources(this.MI_ToSimpChinese, "MI_ToSimpChinese");
            this.MI_ToSimpChinese.Index = 2;
            this.MI_ToSimpChinese.Click += new System.EventHandler(this.MI_SubChineseTrans_Click);
            // 
            // menuItem3
            // 
            resources.ApplyResources(this.menuItem3, "menuItem3");
            this.menuItem3.Index = 5;
            // 
            // MI_SubDelayLess
            // 
            resources.ApplyResources(this.MI_SubDelayLess, "MI_SubDelayLess");
            this.MI_SubDelayLess.Index = 6;
            this.MI_SubDelayLess.Click += new System.EventHandler(this.MI_SubDelayLess_Click);
            // 
            // MI_SubDelayMore
            // 
            resources.ApplyResources(this.MI_SubDelayMore, "MI_SubDelayMore");
            this.MI_SubDelayMore.Index = 7;
            this.MI_SubDelayMore.Click += new System.EventHandler(this.MI_SubDelayMore_Click);
            // 
            // menuItem22
            // 
            resources.ApplyResources(this.menuItem22, "menuItem22");
            this.menuItem22.Index = 8;
            // 
            // MI_SubPosUp
            // 
            resources.ApplyResources(this.MI_SubPosUp, "MI_SubPosUp");
            this.MI_SubPosUp.Index = 9;
            this.MI_SubPosUp.Click += new System.EventHandler(this.MI_SubPosUp_Click);
            // 
            // MI_SubPosDown
            // 
            resources.ApplyResources(this.MI_SubPosDown, "MI_SubPosDown");
            this.MI_SubPosDown.Index = 10;
            this.MI_SubPosDown.Click += new System.EventHandler(this.MI_SubPosDown_Click);
            // 
            // menuItem26
            // 
            resources.ApplyResources(this.menuItem26, "menuItem26");
            this.menuItem26.Index = 11;
            // 
            // MI_SubScaleDown
            // 
            resources.ApplyResources(this.MI_SubScaleDown, "MI_SubScaleDown");
            this.MI_SubScaleDown.Index = 12;
            this.MI_SubScaleDown.Click += new System.EventHandler(this.MI_SubScaleDown_Click);
            // 
            // MI_SubScaleUp
            // 
            resources.ApplyResources(this.MI_SubScaleUp, "MI_SubScaleUp");
            this.MI_SubScaleUp.Index = 13;
            this.MI_SubScaleUp.Click += new System.EventHandler(this.MI_SubScaleUp_Click);
            // 
            // MI_Tools
            // 
            resources.ApplyResources(this.MI_Tools, "MI_Tools");
            this.MI_Tools.Index = 5;
            this.MI_Tools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.MI_EditShortcut,
            this.menuItem12,
            this.MI_Option});
            // 
            // menuItem11
            // 
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Index = 0;
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // MI_EditShortcut
            // 
            resources.ApplyResources(this.MI_EditShortcut, "MI_EditShortcut");
            this.MI_EditShortcut.Index = 1;
            this.MI_EditShortcut.Click += new System.EventHandler(this.MI_EditShortcut_Click);
            // 
            // menuItem12
            // 
            resources.ApplyResources(this.menuItem12, "menuItem12");
            this.menuItem12.Index = 2;
            // 
            // MI_Option
            // 
            resources.ApplyResources(this.MI_Option, "MI_Option");
            this.MI_Option.Index = 3;
            this.MI_Option.Click += new System.EventHandler(this.MI_Option_Click);
            // 
            // MI_Help
            // 
            resources.ApplyResources(this.MI_Help, "MI_Help");
            this.MI_Help.Index = 6;
            this.MI_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MI_About});
            // 
            // MI_About
            // 
            resources.ApplyResources(this.MI_About, "MI_About");
            this.MI_About.Index = 0;
            this.MI_About.Click += new System.EventHandler(this.MI_About_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.Multiselect = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseMove);
            this.splitter1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseDown);
            this.splitter1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter1_MouseUp);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // Playlist
            // 
            this.Playlist.AccessibleDescription = null;
            this.Playlist.AccessibleName = null;
            resources.ApplyResources(this.Playlist, "Playlist");
            this.Playlist.AllowDrop = true;
            this.Playlist.BackgroundImage = null;
            this.Playlist.Font = null;
            this.Playlist.FullRowSelect = true;
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
            // Form1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Playlist);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// ���ε{�����D�i�J�I�C
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
            //Drive Setting
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.CDRom)
                {
                    MenuItem mi = new MenuItem(d.Name);
                    mi.Click += new System.EventHandler(this.MI_DVDDrive_Click);
                    MI_OpenDVD.MenuItems.Add(mi);
                }
            }

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
			Playlist.Columns.Add("����M��", -2, HorizontalAlignment.Left);

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
                txtStatus.Text = "�}�l���� " + mp.Filename;

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
                this.AppendAudioIDMenuItem(this.MI_SelectAudio);

                //this.MI_Zoom_Click(MI_Zoom100, null);
				this.Form1_Resize(null, null);

                needSyncTime = true;
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
					btn_pause.ImageIndex = 1;
                    this.txtStatus.Text = "�~�򼽩� - " + strTimeStamp(this.nowTimePos, (int)mp.Length);
                    timer1.Start();
				}
				else
				{
					timer1.Stop();
					btn_pause.ImageIndex = 0;
                    this.txtStatus.Text = "�Ȱ����� - " + strTimeStamp(this.nowTimePos, (int) mp.Length);
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
            this.nowTimePos = 0;

			this.txtShortcut.Focus();
            this.txtStatus.Text = "�w����";
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

            this.txtStatus.Text = "���񵲧�";
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
                string[] fnames = new string[this.openFileDialog1.FileNames.Length];

                for (int i = this.openFileDialog1.FileNames.Length - 1; i >= 0; i--)
                {
                    fnames[this.openFileDialog1.FileNames.Length - 1 - i] = this.openFileDialog1.FileNames[i];
                }
    
				Playlist.Items.Clear();
				this.Playlist_AddItem(fnames);

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

            this.txtShortcut.Focus();
		}

        private bool needAdjBigScreen = false;
        private bool needAppendAudioChannel = false;
        private bool needSyncTime = true;
        private int nowTimePos = 0;

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(mp.HasInstense())
			{
                int movie_len = (int) mp.Length;

                // some video has broken header with wrong Lengh value
                if (nowTimePos >= movie_len)
                    needSyncTime = true;

                if (needSyncTime || nowTimePos % 60 == 0)
                {
                    nowTimePos = (int)mp.Time_Pos;
                    needSyncTime = false;

                    // To avoid screensaver or powersaver
                    // Win32API.ResetSystemIdle();
                }
                else
                    nowTimePos++;

                if (nowTimePos != 0 && movie_len != 0)
                {
                    this.txtStatus.Text = strTimeStamp(nowTimePos, movie_len);

                    // some video has broken header with wrong Lengh value
                    if(nowTimePos <= movie_len)
                        this.MovieBar.Value = (100 * nowTimePos) / movie_len;
                }
                else
                {
                    this.txtStatus.Text = "0:0:0 / 0:0:0";
                    this.MovieBar.Value = 0;
                }

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

				string fname = Playlist_Next();
                if (fname != null)
                {
                    Start(fname);
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

				//int cx = Win32API.GetSystemMetrics(Win32API.SM_CXSCREEN);
				//int cy = Win32API.GetSystemMetrics(Win32API.SM_CYSCREEN);
				//Win32API.SetWindowPos(this.Handle.ToInt32(), Win32API.HWND_TOP, 0, 0, cx, cy, Win32API.SWP_SHOWWINDOW);
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
                
                /*
                this.mp = null;
                mp = new Mplayer(this);
                */


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
			this.Playlist_AddItem(s);

			Start(Playlist_First());
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

        private string Playlist_First()
        {
            PlaylistNowItem = null;

            if (Playlist.Items.Count > 0)
            {
                PlaylistNowItem = (MPlaylistItem)Playlist.Items[0];
                return PlaylistNowItem.SourceString;
            }

            return null;
        }

        private string Playlist_Current()
        {
            if(PlaylistNowItem != null)
                return PlaylistNowItem.SourceString;

            return null;
        }

        private string Playlist_Next()
        {
            int PlaylistNowIndex = Playlist.Items.IndexOf((ListViewItem)PlaylistNowItem);

            if (PlaylistNowIndex >= 0 && PlaylistNowIndex < Playlist.Items.Count - 1)
            {
                PlaylistNowItem = (MPlaylistItem) Playlist.Items[++PlaylistNowIndex];
                return PlaylistNowItem.SourceString;
            }

            return null;
        }

        private string Playlist_GetFilename(int index)
        {
            if (index >= 0 && index < Playlist.Items.Count)
            {
                PlaylistNowItem = (MPlaylistItem) Playlist.Items[index];
                return PlaylistNowItem.SourceString;
            }

            return null;
        }

		private void Playlist_DoubleClick(object sender, System.EventArgs e)
		{
			int index = Playlist.SelectedIndices[0];

			this.Start( Playlist_GetFilename(index) );
		}

		private void Playlist_AddItem(params string[] s)
		{
			foreach(string str in s)
			{
                this.Playlist.Items.Add((ListViewItem) new MPlaylistItem(str));
			}
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

                this.Playlist_AddItem(s);

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
				this.Playlist_AddItem("file://" + s.Substring(0, index));

				this.Start(Playlist_First());
			}
		}

		private void Form1_Move(object sender, System.EventArgs e)
		{
			mp.MoveScreen();
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
                if (this.isFullscreen)
                    this.BigScreen_DoubleClick(sender, e);
			}
			else
			{
				mp.SendSlaveCommand(cmd + " ");
			}

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

        private void MI_DVDDrive_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            /*
            mp.Playlist.Clear();
            this.Playlist_AddItem("dvd://1" + " -dvd-device=" + mi.Text[0] + ":");

            Start(mp.Playlist.First());
            */

            MessageBox.Show("�٨S�g...");
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
    }
}