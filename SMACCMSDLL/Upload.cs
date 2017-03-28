using System;
using System.Web;

public class Upload : IHttpHandler
{
	public bool IsReusable
	{
		get
		{
			return true;
		}
	}

	public void ProcessRequest(HttpContext context)
	{
		if (context.Request.Files.Count > 0)
		{
			string physicalApplicationPath = context.Request.PhysicalApplicationPath;
			for (int i = 0; i < context.Request.Files.Count; i++)
			{
				HttpPostedFile httpPostedFile = context.Request.Files[i];
				if (httpPostedFile.ContentLength > 0)
				{
					httpPostedFile.SaveAs(string.Format("{0}{1}{2}", physicalApplicationPath, "Upload\\", httpPostedFile.FileName));
				}
			}
		}
		HttpContext.Current.Response.Write(" ");
	}
}
