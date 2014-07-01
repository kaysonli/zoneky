/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 6/30/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WebDownloader
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnFetchClick(object sender, EventArgs e)
		{
			string[] urls = txtUrls.Text.Split('\n');
//			Dictionary<string, string> markups = Tool.FetchPreMarkups(urls);
			Tool tool = new Tool();
			Dictionary<string, string> markups = tool.FetchPreMarkups();
			tool.SaveToFile(txtYAML.Text, markups);
		}
		
		void BtnTranslateClick(object sender, EventArgs e)
		{
			new Tool().Translate(txtUrls.Text.Split('\n'));
		}
	}
}
