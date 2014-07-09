/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/9
 * Time: 22:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoFinder
{
	/// <summary>
	/// Description of Donate.
	/// </summary>
	public partial class Donate : Form
	{
		public Donate()
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
		
		void DonateLoad(object sender, EventArgs e)
		{
			Tool tool = new Tool();
			txtMacID.Text = tool.GetMacID();
		}
		
		void LnkHomePageLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(!string.IsNullOrEmpty(HelpPage))
			{
				System.Diagnostics.Process.Start(HelpPage);
			}
		}
	}
}
