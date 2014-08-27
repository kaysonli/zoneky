﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Configuration;

namespace AAProxy
{

    /// <summary>
    /// Summary description for Proxy
    /// </summary>
    public class XDomainProxy : IHttpModule
    {
        CookieContainer loginCookie = new CookieContainer();
        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
            context.EndRequest += new EventHandler(Application_EndRequest);
        }
        public void Application_BeginRequest(object sender, EventArgs e)
        {

        }
        public void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpResponse response = context.Response;
            response.StatusCode = 200;
            ForwardRequst(context);
        }

        void Login(HttpContext context)
        {

            string userName = ConfigurationManager.AppSettings["email"];
            string password = ConfigurationManager.AppSettings["password"];
            string loginUrl = "https://gladmainnew.morningstar.com/loginsrf/login.srf";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            CookieContainer cc = new CookieContainer();
            request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";//数据提交方式为POST 
            string postData = string.Format("rbtn=btnEmail&email={0}&strPassword={1}&rnd={2}&downloadable=1&ProductCode=DIRECT", userName, password, new Random().NextDouble());
            postData = "rbtn=btnEmail&email={0}&strPassword={1}&Login=Log+in&url=https%3A%2F%2Fassetallocationstg.morningstar.com%2Fassetallocation%2F%3Fdownloadable%3D1%26ProductCode%3DDIRECT%26port%3D%26strInstID%3D%26version%3D&decode=&wkstation=&pagetype=&content=&reset=&rnd=0.717375262043148&downloadable=1&strInstID=&ProductCode=DIRECT&ProductID=DIRECT&login=1&ip=10.86.16.181&hdid=&lang=ENU&mac=&pcname=&org=&impadvisorid=&skout=&HostProductCode=&insesn=1&version=";
            byte[] postdatabytes = Encoding.UTF8.GetBytes(string.Format(postData, userName, password));
            request.ContentLength = postdatabytes.Length;
            request.AllowAutoRedirect = false;
            request.CookieContainer = cc;

            //提交请求   
            Stream stream;
            stream = request.GetRequestStream();
            stream.Write(postdatabytes, 0, postdatabytes.Length);
            stream.Close();

            //接收响应   
            response = (HttpWebResponse)request.GetResponse();
            loginCookie.Add(response.Cookies);
            SetCookie(response, context);
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = sr.ReadToEnd();
        }

        void SetCookie(HttpWebResponse response, HttpContext context)
        {
            foreach (Cookie cookie in response.Cookies)
            {
                HttpCookie httpCookie = new HttpCookie(cookie.Name, cookie.Value);
                httpCookie.Domain = cookie.Domain;
                httpCookie.Expires = cookie.Expires;
                httpCookie.Path = cookie.Path;
                httpCookie.HttpOnly = cookie.HttpOnly;
                httpCookie.Secure = cookie.Secure;
                context.Response.SetCookie(httpCookie);
            }
        }

        void ForwardRequst(HttpContext context)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            string action = context.Request.Url.AbsolutePath;
            string proxyName = "assetallocation";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["proxyName"]))
            {
                proxyName = ConfigurationManager.AppSettings["proxyName"];
            }
            string leadingPath = "/" + proxyName;
            if (action.StartsWith(leadingPath))
            {
                action = action.Substring(leadingPath.Length);
            }
            string remoteUrl = "https://assetallocationstg.morningstar.com/assetallocation/";
            remoteUrl = ConfigurationManager.AppSettings["remoteUrl"];
            string requestUrl = remoteUrl + action + "?" + context.Request.QueryString.ToString();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(requestUrl);//实例化web访问类
                request.Method = context.Request.HttpMethod;
                //模拟头
                request.ContentType = context.Request.ContentType;

                string postData = context.Request.Form.ToString();
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postdatabytes.Length;
                request.Accept = string.Join(",", context.Request.AcceptTypes);//application/json,text/json
                request.AllowAutoRedirect = false;
                request.CookieContainer = loginCookie;
                request.KeepAlive = true;
                request.UserAgent = context.Request.UserAgent;

                if (context.Request.HttpMethod == "POST")
                {
                    //提交请求   
                    Stream stream;
                    stream = request.GetRequestStream();
                    stream.Write(postdatabytes, 0, postdatabytes.Length);
                    stream.Close();
                }

                //接收响应
                response = (HttpWebResponse)request.GetResponse();
                //context.Response.ContentEncoding = Encoding.GetEncoding(response.ContentEncoding);
                context.Response.ContentType = response.ContentType;


                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                if (content.IndexOf("\"type\":\"SessionExpired\"") > -1)
                {
                    Login(context);
                    request = (HttpWebRequest)WebRequest.Create(requestUrl);//实例化web访问类
                    request.Method = context.Request.HttpMethod;
                    //模拟头
                    request.ContentType = context.Request.ContentType;

                    postData = context.Request.Form.ToString();
                    postdatabytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = postdatabytes.Length;
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = loginCookie;
                    request.KeepAlive = true;
                    if (context.Request.HttpMethod == "POST")
                    {
                        //提交请求   
                        Stream stream;
                        stream = request.GetRequestStream();
                        stream.Write(postdatabytes, 0, postdatabytes.Length);
                        stream.Close();
                    }

                    //接收响应
                    response = (HttpWebResponse)request.GetResponse();
                    //context.Response.ContentEncoding = Encoding.GetEncoding(response.ContentEncoding);
                    context.Response.ContentType = response.ContentType;
                    SetCookie(response, context);
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                SetCookie(response, context);
                response.Close();
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                context.Response.AddHeader("Access-Control-Allow-Credentials", "false");
                context.Response.Write(content);
            }
            catch (Exception ex)
            {
                context.Response.Write("path: " + action);
                context.Response.Write("error: " + ex.Message);
            }
        }

        private bool ValidateRemoteCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

}