using System;
using System.IO;
using System.Web;
using System.Web.Security;

namespace SMAC
{
	public class ApplicationUtil
	{
		public static string FormatSqlString(string input)
		{
			string result;
			if (input.Length != 0)
			{
				string text = input.Replace("select", "");
				text = text.Replace("update", "");
				text = text.Replace("insert", "");
				text = text.Replace("delete", "");
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string GetTitle(string n)
		{
			string result;
			if (n != null)
			{
				result = CMSfunc.VietnameseConvert.ChuyenTVKhongDau(CMSfunc._Replate(n.Trim()));
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string GetTitlemod(string n)
		{
			string result;
			if (n != null)
			{
				result = CMSfunc.VietnameseConvert.ChuyenTVKhongDau(CMSfunc._Replatemod(n.Trim()));
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string PasswordEncrypt(string plainText)
		{
			return FormsAuthentication.HashPasswordForStoringInConfigFile(plainText, "SHA1");
		}

		public static void SetKey(string Name, string Value)
		{
			HttpContext current = HttpContext.Current;
			if (current.Application[Name] == null)
			{
				current.Application.Add(Name, Value);
			}
			else
			{
				current.Application[Name] = Value;
			}
		}

		public static string GetValue(string Name)
		{
			HttpContext current = HttpContext.Current;
			string result;
			if (current.Application[Name] != null)
			{
				result = current.Application[Name].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static void RemoveKey(string Name)
		{
			try
			{
				HttpContext current = HttpContext.Current;
				current.Application.Remove(Name);
			}
			catch
			{
			}
		}

		public static string FormatString(string input)
		{
			string result;
			if (input.Length != 0)
			{
				string text = input.Replace("'", "");
				text = text.Replace(">", "&gt;");
				text = text.Replace("<", "&lt;");
				text = text.Replace("&", "&amp;");
				text = text.Replace(")", "&quot;");
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string[] MakeListFields(params string[] fields)
		{
			return fields;
		}

		public static string GetTypeImage(string urlImg)
		{
			return Path.GetExtension(urlImg);
		}
	}
}
