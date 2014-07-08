/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/8
 * Time: 7:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoFinder
{
	/// <summary>
	/// Description of Help.
	/// </summary>
	public partial class Help : Form
	{
		public Help()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string HelpPage
		{
			get;set;
		}
		
		void LinkLabel1Click(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(HelpPage))
			{
				System.Diagnostics.Process.Start(HelpPage);
			}
		}
	}
}
