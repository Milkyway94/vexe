using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_subcontrol_Breadcrumb : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = string.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        string m = Request["nUrl"] != null ? Request["nUrl"].ToString() : "";
        int p = ModControl.GetP_From_Code(u);
        if (m != "")
        {
            lbNavigation.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(u) + "</li>";
        }
        else
        {
            lbNavigation.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(u) + "</li>";
        };
    }
}