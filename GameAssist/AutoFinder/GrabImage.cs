/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 13:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoFinder
{
	/// <summary>
	/// Description of GrabImage.
	/// </summary>
	public class GrabImage
	{
		public IntPtr hScreenDc = CreateDC("DISPLAY", null, null, 0);

		[DllImport("gdi32.dll")]
		public static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);
		[DllImport("gdi32.dll")]
		public static extern int DeleteDC(IntPtr hdc);
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hdc);
		public void DrawOnDesktop(Rectangle rect)
		{
			Graphics graphics = Graphics.FromHdc(CreateDC("DISPLAY", null, null, 0));
			graphics.FillRectangle(Brushes.Red, rect);
			graphics.Dispose();
		}

		public void DrawOnDesktop(Point upperLeftSource, Point upperLeftDestination, Size blockRegionSize)
		{
			Graphics graphics = Graphics.FromHdc(CreateDC("DISPLAY", null, null, 0));
			graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
			graphics.Dispose();
		}

		public void DrawOnWindow(IntPtr hWnd, Rectangle rect)
		{
			Graphics graphics = Graphics.FromHdc(GetWindowDC(hWnd));
			graphics.FillRectangle(Brushes.Red, rect);
			graphics.Dispose();
		}

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hwnd);
		[DllImport("user32.dll")]
		public static extern bool ReleaseDC(IntPtr hwnd, IntPtr hdc);
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
		public Bitmap TakePhoto(int Width, int Height, int x, int y)
		{
			this.hScreenDc = CreateDC("DISPLAY", null, null, 0);
			IntPtr hdc = CreateCompatibleDC(this.hScreenDc);
			IntPtr hgdiobj = CreateCompatibleBitmap(this.hScreenDc, Width, Height);
			IntPtr ptr3 = SelectObject(hdc, hgdiobj);
			BitBlt(hdc, 0, 0, Width, Height, this.hScreenDc, x, y, 0xcc0020);
			Bitmap bitmap = Image.FromHbitmap(SelectObject(hdc, ptr3));
			ReleaseDC(hgdiobj, this.hScreenDc);
			DeleteDC(this.hScreenDc);
			DeleteDC(hdc);
			DeleteDC(ptr3);
			DeleteObject(hgdiobj);
			return bitmap;
		}

		public Form DesktopForm { get; private set; }
	}
}
