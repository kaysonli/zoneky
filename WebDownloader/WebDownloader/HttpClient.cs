/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 6/30/2014
 * Time: 8:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace WebDownloader
{
	/// <summary>
	/// Description of HttpClient.
	/// </summary>
	public static class Tool
	{
		public static Dictionary<string, string> FetchPreMarkups(string[] urls)
		{
			Dictionary<string, string> markups = new Dictionary<string, string>();
			for (int i = 0, ln = urls.Length; i < ln; i++) {
				string url = urls[i];
				string name = url.Substring(url.IndexOf('=') + 1);
				string html = DownloadPage(urls[i]);
				string pre = GetPreMarkup(html);
				markups.Add(name, pre);
			}
			return markups;
		}
		
		public static string DownloadPage(string url)
		{
			string html = "";
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				var response = req.GetResponse();
				var stream = response.GetResponseStream();
				var reader = new StreamReader(stream);
				html = reader.ReadToEnd();
			}
			catch(Exception e){
				
			}
			return html;
		}
		
		public static string GetPreMarkup(string html)
		{
			int start = html.IndexOf("<pre>");
			int end = html.IndexOf("</pre>");
			string pre = html.Substring(start, end- start + 6);
			return pre;
		}
		
		public static void SaveToFile(string yamlTemplate, Dictionary<string, string> dic)
		{
			foreach(var pair in dic)
			{
				string fileName = DateTime.Today.ToString("yyyy-MM-dd")+ "-" + pair.Key.TrimEnd().Replace('/', '-');
				string posts = "posts";
				if(!Directory.Exists(posts))
				{
					Directory.CreateDirectory(posts);
				}
				
				string markups = "markups";
				if(!Directory.Exists(markups))
				{
					Directory.CreateDirectory(markups);
				}
				
				using(FileStream fs = new FileStream(Path.Combine(posts, fileName + ".md"), FileMode.Create))
				{
					StreamWriter sw = new StreamWriter(fs);
					string yaml = string.Format(yamlTemplate, pair.Key);
					sw.WriteLine(yaml);
					sw.WriteLine("{% raw %}");
					sw.WriteLine(pair.Value);
					sw.WriteLine("{% endraw %}");
					sw.Flush();
					sw.Close();
				}
				
				using(FileStream fs = new FileStream(Path.Combine(markups, fileName + ".txt"), FileMode.Create))
				{
					StreamWriter sw = new StreamWriter(fs);
					
					sw.WriteLine("{% raw %}");
					sw.WriteLine(pair.Value);
					sw.WriteLine("{% endraw %}");
					sw.Flush();
					sw.Close();
				}
			}
			
		}
		
		public static void SaveToFile(Dictionary<string, string> dic)
		{
			foreach(var pair in dic)
			{
				string fileName = DateTime.Today.ToString("yyyy-MM-dd")+ "-" + pair.Key.TrimEnd().Replace('/', '-');
				if(!Directory.Exists("markups"))
				{
					Directory.CreateDirectory("markups");
				}
				
				using(FileStream fs = new FileStream(Path.Combine("markups", fileName + ".md"), FileMode.Create))
				{
					StreamWriter sw = new StreamWriter(fs);
					sw.WriteLine("{% raw %}");
					sw.WriteLine(pair.Value);
					sw.WriteLine("{% endraw %}");
					sw.Flush();
					sw.Close();
				}
			}
		}
		
	}
}
