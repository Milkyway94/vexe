using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_NhaXe : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (nurl != null)
        {
            lbnav.Text = "<li><a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li> <li>" + ModControl.GetName_From_Code(nurl) + "</li>";
        }
        else
        {
            lbnav.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(url) + "</li>";
        }
    }
}