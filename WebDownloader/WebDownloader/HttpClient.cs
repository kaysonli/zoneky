/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 6/30/2014
 * Time: 8:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

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
				string name = pair.Key.TrimEnd();
				string fileName = DateTime.Today.ToString("yyyy-MM-dd")+ "-" + name.Replace('/', '-');
				string category = name.Split('/')[0];
				string detail = name.Split('/')[1];
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
					string yaml = string.Format(yamlTemplate, detail, category);
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
		
		private static string[] ExtractKeyword(string url)
		{
			string decode = System.Web.HttpUtility.UrlDecode(url);
			string name = decode.Substring(decode.IndexOf('=') + 1);
			return name.Split('/');
		}
		
		public static string Translate(string[] urls)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < urls.Length; i++) {
				string[] names = ExtractKeyword(urls[i].TrimEnd());
				foreach(var n in names)
				{
					if(!dic.ContainsKey(n))
					{
						var trans = Translate(n);
						dic.Add(n, trans);
						sb.AppendLine(n + ":" + trans);
					}
				}
			}
			string text = sb.ToString();
			return text;
		}
		
		public static string Translate(string word)
		{
			var api = "http://fanyi.youdao.com/openapi.do?keyfrom=zoneky&key=696322534&type=data&doctype=text&version=1.0&q={0}";
			var result = DownloadPage(string.Format(api, word));
			var lines = result.Split('\n');
			var w = lines[1].Split('=')[1];
			return w;
		}
		
	}
}
