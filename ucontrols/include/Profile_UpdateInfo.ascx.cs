using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Profile_History : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public tbl_Member member = new tbl_Member();
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
        if (Session["MemberID"] != null)
        {
            this.member = new MemberRepository().Find(int.Parse(Session["MemberID"].ToString()));
        }
        else
        {
            Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, AlertType.ERROR);
            dvinfo.Visible = false;
        }
        if (!IsPostBack)
        {
            txtDiachi.Text = member.Member_Address;
            txtEmail.Text = member.Member_Email;
            txtName.Text = member.Member_Name;
            txtSdt.Text = member.Member_Phone;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var memberid = Session["MemberID"];
        if (memberid != null)
        {
            Hashtable tbMem = new Hashtable();
            tbMem.Add("Member_Address", txtDiachi.Text);
            tbMem.Add("Member_Email", txtEmail.Text);
            tbMem.Add("Member_Name", txtName.Text);
            tbMem.Add("Member_Phone", txtSdt.Text);
            try
            {
                bool _update = UpdateData.Update("tbl_Member", tbMem, "Member_ID=" + memberid.ToString());
                if (_update)
                {
                    dvinfo.Visible = true;
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.Success, "Cập nhật"), AlertType.SUCCESS);
                }
                else
                {
                    dvinfo.Visible = true;
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Cập nhật"), AlertType.ERROR);
                }
            }
            catch (Exception)
            {
                Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Cập nhật"), AlertType.ERROR);
            }
        }
        else
        {
            Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, AlertType.ERROR);
            dvinfo.Visible = false;
        }
    }
}