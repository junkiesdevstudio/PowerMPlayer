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
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem MI_Fullscreen;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem MI_BrightnessMore;
		private System.Windows.Forms.MenuItem MI_BrightnessLess;
		private System.Windows.Forms.MenuItem MI_ContrastMore;
		private System.Windows.Forms.MenuItem MI_ContrastLess;
		private Mplayer mp;

		public Form1()
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
			this.MI_Exit = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.MI_Fullscreen = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.MI_BrightnessMore = new System.Windows.Forms.MenuItem();
			this.MI_BrightnessLess = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.MI_ContrastMore = new System.Windows.Forms.MenuItem();
			this.MI_ContrastLess = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
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
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.MI_Option = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.MI_About = new System.Windows.Forms.MenuItem();
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
			this.BigScreen.AllowDrop = true;
			this.BigScreen.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(1)), ((System.Byte)(1)), ((System.Byte)(1)));
			this.BigScreen.Location = new System.Drawing.Point(0, 0);
			this.BigScreen.Name = "BigScreen";
			this.BigScreen.Size = new System.Drawing.Size(168, 136);
			this.BigScreen.TabIndex = 2;
			this.BigScreen.Click += new System.EventHandler(this.btn_pause_Click);
			this.BigScreen.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
			this.BigScreen.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
			this.BigScreen.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
			this.BigScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BigScreen_MouseMove);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.btn_mute);
			this.panel1.Controls.Add(this.statusBar1);
			this.panel1.Controls.Add(this.VolumeBar);
			this.panel1.Controls.Add(this.btn_stop);
			this.panel1.Controls.Add(this.btn_pause);
			this.panel1.Controls.Add(this.MovieBar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 333);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(568, 64);
			this.panel1.TabIndex = 4;
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
			this.MovieBar.Location = new System.Drawing.Point(120, 16);
			this.MovieBar.Name = "MovieBar";
			this.MovieBar.Size = new System.Drawing.Size(100, 16);
			this.MovieBar.TabIndex = 7;
			this.MovieBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovieBar_MouseUp);
			// 
			// MainPanel
			// 
			this.MainPanel.AllowDrop = true;
			this.MainPanel.BackColor = System.Drawing.Color.Black;
			this.MainPanel.Controls.Add(this.BigScreen);
			this.MainPanel.Location = new System.Drawing.Point(8, 16);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(264, 208);
			this.MainPanel.TabIndex = 3;
			this.MainPanel.Click += new System.EventHandler(this.btn_pause_Click);
			this.MainPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
			this.MainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
			this.MainPanel.DoubleClick += new System.EventHandler(this.BigScreen_DoubleClick);
			this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem6,
																					  this.menuItem13,
																					  this.menuItem14,
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
																					  this.MI_Exit});
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
			// MI_Exit
			// 
			this.MI_Exit.Index = 2;
			this.MI_Exit.Text = "離開(&E)";
			this.MI_Exit.Click += new System.EventHandler(this.MI_Exit_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.MI_Fullscreen});
			this.menuItem6.Text = "播放(&P)";
			// 
			// MI_Fullscreen
			// 
			this.MI_Fullscreen.Index = 0;
			this.MI_Fullscreen.Shortcut = System.Windows.Forms.Shortcut.F11;
			this.MI_Fullscreen.Text = "全螢幕播放";
			this.MI_Fullscreen.Click += new System.EventHandler(this.BigScreen_DoubleClick);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 2;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.MI_BrightnessLess,
																					   this.MI_BrightnessMore,
																					   this.menuItem28,
																					   this.MI_ContrastLess,
																					   this.MI_ContrastMore});
			this.menuItem13.Text = "視訊(&V)";
			// 
			// MI_BrightnessMore
			// 
			this.MI_BrightnessMore.Index = 1;
			this.MI_BrightnessMore.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.MI_BrightnessMore.Text = "亮度 +";
			this.MI_BrightnessMore.Click += new System.EventHandler(this.MI_BrightnessMore_Click);
			// 
			// MI_BrightnessLess
			// 
			this.MI_BrightnessLess.Index = 0;
			this.MI_BrightnessLess.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
			this.MI_BrightnessLess.Text = "亮度 -";
			this.MI_BrightnessLess.Click += new System.EventHandler(this.MI_BrightnessLess_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 2;
			this.menuItem28.Text = "-";
			// 
			// MI_ContrastMore
			// 
			this.MI_ContrastMore.Index = 4;
			this.MI_ContrastMore.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.MI_ContrastMore.Text = "對比 +";
			this.MI_ContrastMore.Click += new System.EventHandler(this.MI_ContrastMore_Click);
			// 
			// MI_ContrastLess
			// 
			this.MI_ContrastLess.Index = 3;
			this.MI_ContrastLess.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.MI_ContrastLess.Text = "對比 -";
			this.MI_ContrastLess.Click += new System.EventHandler(this.MI_ContrastLess_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 3;
			this.menuItem14.Text = "音訊(&A)";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
			this.menuItem8.Text = "字幕(&S)";
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
			// menuItem7
			// 
			this.menuItem7.Index = 5;
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
			this.menuItem10.Index = 6;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.MI_About});
			this.menuItem10.Text = "說明(&H)";
			// 
			// MI_About
			// 
			this.MI_About.Index = 0;
			this.MI_About.Text = "關於";
			this.MI_About.Click += new System.EventHandler(this.MI_About_Click);
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

			MovieBar.Top = MovieBar.Left = 0;
			btn_pause.Top = MovieBar.Top + MovieBar.Height;
			btn_pause.Left = 0;
			btn_stop.Top = btn_pause.Top;
			btn_stop.Left = btn_pause.Left + btn_pause.Width;
			
			btn_mute.Top = btn_pause.Top;
			VolumeBar.Top = btn_pause.Top;
			
			this.Form1_Resize(sender, e);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			double aspect = 0;

			if(mp.HasInstense())
			{
				aspect = mp.Video_Aspect;
			}

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

			mp.Filename = filename;

			if(mp.Start())
			{
				this.Form1_Resize(null, null);

				this.Text = System.IO.Path.GetFileName(filename);

				this.btn_pause.Enabled = true;
				this.btn_stop.Enabled = true;
				this.btn_pause.ImageIndex = 1;

				this.AppendSubtitleMenuItem(this.MI_SelectSubtitle);

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
			mp.Quit();
			Stop();
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

				Quit();
				mp.CurrentSubtitle = sub;
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
			this.openFileDialog1.FileName = "";
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

		private bool isFullscreen = false;
		private void BigScreen_DoubleClick(object sender, System.EventArgs e)
		{
			this.isFullscreen = !this.isFullscreen;
			if(isFullscreen == true)
			{
				this.Menu = null;
				this.statusBar1.Visible = false;

				this.FormBorderStyle = FormBorderStyle.None;
				this.WindowState = FormWindowState.Maximized;
				
				int cx = Win32API.GetSystemMetrics(Win32API.SM_CXSCREEN);
				int cy = Win32API.GetSystemMetrics(Win32API.SM_CYSCREEN);
				Win32API.SetWindowPos(this.Handle.ToInt32(), Win32API.HWND_TOP, 0, 0, cx, cy, Win32API.SWP_SHOWWINDOW);
			}
			else
			{
				this.Menu = this.mainMenu1;
				this.statusBar1.Visible = true;
				this.WindowState = FormWindowState.Normal;
				this.FormBorderStyle = FormBorderStyle.Sizable;

				this.Width = mp.Video_Width;
				this.Height = mp.Video_Height + this.panel1.Height + (this.Height - this.ClientSize.Height);
			}

			if(btn_pause.ImageIndex == 0)
				this.Pause();

			this.Form1_Resize(sender, e);
		}

		private void MI_Option_Click(object sender, System.EventArgs e)
		{
			OptionForm opt_form = new OptionForm(mp.Setting);
			opt_form.ShowDialog();

			Restart();
		}

		#region Subtitle MenuItem

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

			Subtitle sub = mp.Subtitles[mi.Index];
			
			if(sub.SubType == SubtitleType.VobSubID)
			{
				mp.SelectSub(sub.VobSubID);
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
			for(int i=0;i<mp.Subtitles.Count;i++)
			{
				MenuItem mi = new MenuItem(mp.Subtitles[i].Name);
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

		int last_mouse_pause = 0;
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

			this.last_mouse_pause = e.Y;
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
			
			this.Start(s[0]);
		}

		#endregion

		private void MI_BrightnessMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Brightness = 1;
		}

		private void MI_BrightnessLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Brightness = -1;
		}

		private void MI_ContrastMore_Click(object sender, System.EventArgs e)
		{
			mp.Video_Contrast = 1;
		}

		private void MI_ContrastLess_Click(object sender, System.EventArgs e)
		{
			mp.Video_Contrast = -1;
		}
	}
}
