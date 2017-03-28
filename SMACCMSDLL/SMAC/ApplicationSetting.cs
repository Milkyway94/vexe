using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;

namespace SMAC
{
	public class ApplicationSetting
	{
		public static string URLRoot
		{
			get
			{
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				return applicationPath.EndsWith("/") ? applicationPath : (applicationPath + "/");
			}
		}

		public static string ExtApp
		{
			get
			{
				return ApplicationSetting.GetConfigString("ADCSettings", "extApp", ".aspx");
			}
		}

		public static string URLImages
		{
			get
			{
				string text = "~/skin";
				return text.Replace("~/", ApplicationSetting.URLRoot);
			}
		}

		public static string URLCSS
		{
			get
			{
				string text = "~/css";
				return text.Replace("~/", ApplicationSetting.URLRoot);
			}
		}

		public static string URLJavaScript
		{
			get
			{
				string text = "~/js";
				return text.Replace("~/", ApplicationSetting.URLRoot);
			}
		}

		public static string SmtpServer
		{
			get
			{
				return ApplicationSetting.GetConfigString("ADCSettings", "smtpServerAddress", string.Empty);
			}
		}

		public static string WebmasterEmail
		{
			get
			{
				return ApplicationSetting.GetConfigString("ADCSettings", "webmasterEmail", string.Empty);
			}
		}

		private static string GetConfigString(string strSection, string strKey, string strDefValue)
		{
			NameValueCollection nameValueCollection = ConfigurationSettings.GetConfig(strSection) as NameValueCollection;
			string result;
			if (nameValueCollection != null)
			{
				string text = nameValueCollection[strKey];
				if (text != null)
				{
					result = text;
					return result;
				}
			}
			result = strDefValue;
			return result;
		}
	}
}
