/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/8/21
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JD_Union
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
		
		void Button1Click(object sender, EventArgs e)
		{
			string itemUrl = "http://item.jd.com/11444582.html";
			int size = 14;
			string code = Process(itemUrl, CodeType.JavaScript, size);
			MessageBox.Show(code);
		}
		
		string Process(string itemUrl, CodeType codeType, int size)
		{
			HttpHelper helper = new HttpHelper(CodeType.JavaScript);
			helper.CodeType = codeType;
			string placementContent = helper.CreatePlacement(itemUrl);
			Regex regex = new Regex("\"placementId\":[0-9]+");
			Match match = regex.Match(placementContent);
			if(match.Success)
			{
				string id =match.Value.Split(':')[1];
				string code = helper.GetCustomCode(id);
				string pattern = "<script.+script>";
				if(codeType == CodeType.Url)
				{
					pattern = "\"http:.+?\"";
				}
				match = Regex.Match(code, pattern);
				return match.Value;
			}
			return "";
			
		}
	}
}
