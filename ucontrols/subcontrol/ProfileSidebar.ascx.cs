using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_subcontrol_ProfileSidebar : System.Web.UI.UserControl
{
    private int modid;
    public string active1, active2, active3, active4;
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request.QueryString["url"]) ? "Home" : Request["url"].ToString();
        string nUrl = String.IsNullOrEmpty(Request["nUrl"]) ? "" : Request["nUrl"].ToString();
        modid = ModControl.GetP_From_Code(url);
        switch (url)
        {
            case "thong-tin-tai-khoan":
                active1 = "active";
                break;
            case "cap-nhat-tai-khoan":
                active2 = "active";
                break;
            case "nap-tien-vola":
                active3 = "active";
                break;
            case "lich-su-giao-dich":
                active4 = "active";
                break;
            default:
                break;
        }
    }
}