/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 14:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoFinder
{
	/// <summary>
	/// Description of BlobWindow.
	/// </summary>
	public partial class BlobWindow : Form
	{
		public BlobWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BlobWindowPaint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
            if (this.BlobRects != null)
            {
                foreach (Rectangle rectangle in this.BlobRects)
                {
                    graphics.FillRectangle(new SolidBrush(SystemColors.Control), rectangle);
                }
            }
		}
		
		 public Rectangle[] BlobRects { get; set; }
	}
}
