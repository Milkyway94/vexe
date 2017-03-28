using System;
using System.Web;

namespace SMAC
{
    public class SessionUtil
	{
		public static void SetKey(string Name, string Value)
		{
			HttpContext current = HttpContext.Current;
			if (current.Session[Name] == null)
			{
				current.Session.Add(Name, Value);
			}
			else
			{
				current.Session[Name] = Value;
			}
		}

		public static string GetValue(string Name)
		{
			HttpContext current = HttpContext.Current;
			string result;
			if (current.Session[Name] != null)
			{
				try
				{
					result = current.Session[Name].ToString();
					return result;
				}
				catch
				{
					result = "";
					return result;
				}
			}
			result = "";
			return result;
		}

		public static void RemoveKey(string Name)
		{
			try
			{
				HttpContext current = HttpContext.Current;
				current.Session.Remove(Name);
			}
			catch
			{
			}
		}
	}
}
