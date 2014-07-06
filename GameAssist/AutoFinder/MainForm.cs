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
using System.Runtime.InteropServices;
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
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!Directory.Exists(Application.StartupPath + @"\Save"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Save");
                this.savePath = Application.StartupPath + @"\Save";
            }
            else
            {
                this.savePath = Application.StartupPath + @"\Save";
            }
            
            configLoader = new ConfigLoader();
            playground = configLoader.GetPlaygroundInfo(GameType.Lady);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		protected override void DefWndProc(ref Message m)
		{
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
						this.imageX = left + 0x202;
						this.imageY = top + 190;
						Bitmap bitmap = this.graber.TakePhoto(500, 450, left + 5, this.imageY);
						Bitmap bitmap2 = this.graber.TakePhoto(500, 450, this.imageX, this.imageY);
						if (this.checkBoxSaveImg.Checked)
						{
							string str = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_1.jpg";
							string text1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_2.jpg";
							bitmap.Save(this.savePath + @"\" + str, ImageFormat.Jpeg);
						}
						Bitmap image = (Bitmap) bitmap.Clone();
						Bitmap bitmap4 = (Bitmap) bitmap2.Clone();
						this.differenceFilter.OverlayImage = bitmap4;
						Bitmap bitmap5 = this.differenceFilter.Apply(image);
						Bitmap bitmap6 = this.grayFilter.Apply(bitmap5);
						Bitmap bitmap7 = this.thresholdFilter.Apply(bitmap6);
						this.pictureBox1.Image = bitmap7;
						this.bc.ProcessImage(bitmap7);
						this.diffRects = this.bc.GetObjectsRectangles();
						this.blobWnd.Location = new Point(this.imageX, this.imageY);
						this.blobWnd.BlobRects = this.diffRects;
						SetWindowPos(this.blobWnd.Handle.ToInt32(), -1, this.blobWnd.Location.X, this.blobWnd.Location.Y, this.blobWnd.Width, this.blobWnd.Height, 1);
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
	}
}
