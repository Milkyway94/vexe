using SMAC;
using System;
using System.Web;
using System.Web.UI;

public class DefaultAdmin : Page
{
	protected override void OnInit(EventArgs e)
	{
		CMSfunc.checkURL();
		if (this.Session["UserID"] == null || this.Session["UserID"].ToString() == "")
		{
			base.Response.Redirect(ApplicationSetting.URLRoot + "admin/login.aspx");
		}
		base.OnInit(e);
	}
}
