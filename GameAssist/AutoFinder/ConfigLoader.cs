/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 15:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace AutoFinder
{
	/// <summary>
	/// Description of ConfigLoader.
	/// </summary>
	public class ConfigLoader
	{
		private string configUrl = "../../autofinder-config.xml";
		private string remoteUrl = "http://lzkwin.github.io/studio/autofinder-config.xml";
		bool useRemote = true;
		XmlDocument doc = new XmlDocument();
		
		public string DownloadFile(string url)
		{
			string content = "";
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				HttpWebResponse res = (HttpWebResponse)req.GetResponse();
				using(StreamReader reader = new StreamReader(res.GetResponseStream()))
				{
					content = reader.ReadToEnd();
				}
			}
			catch(Exception ex)
			{
				
			}
			return content;
		}
		
		public ConfigLoader()
		{
			try
			{
				if(this.useRemote)
				{
					string xml = DownloadFile(remoteUrl);
					doc.LoadXml(xml);
				}
				else
				{
					using(Stream s = new FileStream(this.configUrl, FileMode.Open))
					{
						doc.Load(s);
					}
				}
			}
			catch(Exception e)
			{
				
			}
		}
		
		public int AdsInterval
		{
			get {
				string interval = doc.SelectSingleNode("config/ads/interval").InnerText;
				int val = 3000;
				if(!int.TryParse(interval, out val))
				{
					val = 3000;
				}
				return val;
			}
		}
		
		public string AdsTitle 
		{
			get
			{
				return doc.SelectSingleNode("config/ads/title").InnerText;
			}
		}
		
		public string Version
		{
			get
			{
				return doc.SelectSingleNode("config/startup/version").InnerText;
			}
		}
		
		public string HelpPage 
		{
			get
			{
				var helpPage = doc.SelectSingleNode("config/startup/help-page");
				if(helpPage != null)
				{
					return helpPage.InnerText;
				}
				return "";
			}
		}
		
		public string EmailReceiver
		{
			get
			{
				var node = doc.SelectSingleNode("config/startup/email-recv");
				if(node != null)
				{
					return node.InnerText;
				}
				return "";
			}
		}
		
		public bool SendMail
		{
			get
			{
				var node = doc.SelectSingleNode("config/startup/sendmail");
				if(node != null)
				{
					return bool.Parse(node.InnerText);
				}
				return false;
			}
		}
		
		public string DownloadPage 
		{
			get
			{
				var downloadPage = doc.SelectSingleNode("config/startup/download-page");
				if(downloadPage != null)
				{
					return downloadPage.InnerText;
				}
				return "";
			}
		}
		
		public string OpenPageUrl
		{
			get
			{
				var onClose = doc.SelectSingleNode("config/startup/onclose");
				bool open = bool.Parse(onClose.Attributes["open"].Value);
				if(open)
				{
					return onClose.Attributes["url"].Value;
				}
				return "";
			}
		}
		
		public List<string> GetVipList()
		{
			var users = doc.SelectSingleNode("config/startup/vips");
			List<string> ids = new List<string>();
			foreach(XmlNode node in users)
			{
				ids.Add(node.InnerText);
			}
			return ids;
		}
		
		public List<AdInfo> GetScreenAds()
		{
			List<AdInfo> ads = new List<AdInfo>();
			var nodes = doc.SelectSingleNode("config/ads/screen");
			foreach(XmlNode node in nodes)
			{
				AdInfo ad = new AdInfo()
				{
					ImageUrl = node.Attributes["imgUrl"].Value,
					ClickUrl = node.Attributes["clickUrl"].Value
				};
				ads.Add(ad);
			}
			return ads;
		}
		
		public List<AdInfo> GetBottomAds()
		{
			List<AdInfo> ads = new List<AdInfo>();
			var nodes = doc.SelectSingleNode("config/ads/statusbar");
			foreach(XmlNode node in nodes)
			{
				AdInfo ad = new AdInfo()
				{
					Text = node.Attributes["text"].Value,
					ClickUrl = node.Attributes["clickUrl"].Value
				};
				ads.Add(ad);
			}
			return ads;
		}
		
		public GameWindowInfo GetPlaygroundInfo(GameType gameType)
		{
			GameWindowInfo info = new GameWindowInfo();
			var startup = doc.SelectSingleNode("config/startup");
			foreach(XmlNode game in startup.ChildNodes)
			{
				GameType type = (GameType)int.Parse(game.Attributes["type"].Value);
				info.MarginLeft = int.Parse(game.Attributes["marginLeft"].Value);
				info.MarginTop = int.Parse(game.Attributes["marginTop"].Value);
				info.Width = int.Parse(game.Attributes["width"].Value);
				info.Height = int.Parse(game.Attributes["height"].Value);
				info.Gutter = int.Parse(game.Attributes["gutter"].Value);
				if(type == gameType)
				{
					return info;
				}
			}
			return info;
		}
	}
	
	public enum GameType
	{
		Lady = 0,
		Everyone = 1
	}
	
	public struct AdInfo
	{
		public string ImageUrl;
		public string ClickUrl;
		public string Text;
	}
	
	public struct GameWindowInfo
	{
		public int MarginTop;
		public int MarginLeft;
		public int Width;
		public int Height;
		public int Gutter;
	}
	
	public struct StartupConfig
	{
		public GameType GameType { get;set;}
		
	}
}
