/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/9
 * Time: 7:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;

namespace AutoFinder
{
	/// <summary>
	/// Description of EmailHelper.
	/// </summary>
	public class EmailHelper
	{
		public EmailHelper()
		{
		}
		
		public void SendEmail(string mailBody, string toEmail)
		{
			if(string.IsNullOrEmpty(toEmail))
			{
				toEmail = "tarkyadmin@163.com";
			}
			//简单邮件传输协议类
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.163.com";//邮件服务器
            client.Port = 25;//smtp主机上的端口号,默认是25.
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//邮件发送方式:通过网络发送到SMTP服务器
            client.Credentials = new System.Net.NetworkCredential("autofinder@163.com", "autofinder123");//凭证,发件人登录邮箱的用户名和密码

            //电子邮件信息类
            System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("autofinder@163.com", "Auto Finder");//发件人Email,在邮箱是这样显示的,[发件人:小明<panthervic@163.com>;]
            System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress(toEmail, "");//收件人Email,在邮箱是这样显示的, [收件人:小红<43327681@163.com>;]
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(fromAddress, toAddress);//创建一个电子邮件类
            mailMessage.Subject = "From Auto Finder";
            
            mailMessage.Body = mailBody;//可为html格式文本
            //mailMessage.Body = "邮件的内容";//可为html格式文本
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;//邮件主题编码
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
            mailMessage.IsBodyHtml = false;//邮件内容是否为html格式
            mailMessage.Priority = System.Net.Mail.MailPriority.High;//邮件的优先级,有三个值:高(在邮件主题前有一个红色感叹号,表示紧急),低(在邮件主题前有一个蓝色向下箭头,表示缓慢),正常(无显示).
            try
            {
                client.Send(mailMessage);//发送邮件
                //client.SendAsync(mailMessage, "ojb");异步方法发送邮件,不会阻塞线程.
            }
            catch (Exception ex)
            {
            }
		}
	}
}
