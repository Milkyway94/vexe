using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Profile_Info : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public tbl_Member member = new tbl_Member();
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (Session["MemberID"] != null)
        {
            this.member = new MemberRepository().Find(int.Parse(Session["MemberID"].ToString()));
        }
        else
        {
            Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, AlertType.ERROR);
            mainarea.Visible = false;
        }
        Control _objControl = LoadControl("/ucontrols/subcontrol/ProfileSidebar.ascx");
        sidebar.Controls.Add(_objControl);
    }
}