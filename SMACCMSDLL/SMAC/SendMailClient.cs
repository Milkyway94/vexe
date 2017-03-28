using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SMAC
{
	public class SendMailClient
	{
		public static bool SendGMail(string MailTo, string From, string name, string ccList, string subject, string smtpClientHost, int Port, string EmailCredentials, string PassCredentials, string msgSend, string body)
		{
			bool result = false;
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Credentials = new NetworkCredential(EmailCredentials, PassCredentials);
			smtpClient.Port = Port;
			smtpClient.Host = smtpClientHost;
			smtpClient.EnableSsl = true;
			MailMessage mailMessage = new MailMessage();
			mailMessage.IsBodyHtml = true;
			string[] array = MailTo.Split(new char[]
			{
				','
			});
			try
			{
				mailMessage.From = new MailAddress(From, name, Encoding.UTF8);
				byte b = 0;
				while ((int)b < array.Length)
				{
					mailMessage.To.Add(array[(int)b]);
					b += 1;
				}
				mailMessage.Subject = subject;
				mailMessage.Body = body;
				mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
				mailMessage.ReplyTo = new MailAddress(From);
				smtpClient.Send(mailMessage);
				result = true;
			}
			catch (Exception var_5_C9)
			{
				result = false;
			}
			return result;
		}

		public static bool SendMail(string toList, string from, string name, string ccList, string subject, string smtpClientHost, string EmailCredentials, string PassCredentials, string msgSend, string body)
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient();
			bool result = false;
			try
			{
				MailAddress from2 = new MailAddress(from, name);
				mailMessage.From = from2;
				mailMessage.To.Add(toList);
				if (ccList != null && ccList != string.Empty)
				{
					mailMessage.CC.Add(ccList);
				}
				mailMessage.Subject = subject;
				mailMessage.IsBodyHtml = true;
				mailMessage.Body = body;
				smtpClient.Host = smtpClientHost;
				smtpClient.Port = 3000;
				smtpClient.UseDefaultCredentials = true;
				smtpClient.Credentials = new NetworkCredential(EmailCredentials, PassCredentials);
				smtpClient.Send(mailMessage);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
