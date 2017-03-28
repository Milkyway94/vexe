using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SMAC
{
	public class DefaultWeb : Page
	{
		public static void CheckWeb()
		{
			string value = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].Replace("www.", "");
		}
	}
}
