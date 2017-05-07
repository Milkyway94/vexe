using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_LoginMember : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrLoginMessage.Visible = false;
        if (!IsPostBack)
        {
            if (Request.QueryString["act"] == "logout")
            {
                SessionUtil.RemoveKey("MemberID");
                SessionUtil.RemoveKey("Username");
                SessionUtil.RemoveKey("Email");
                SessionUtil.RemoveKey("Image");
                SessionUtil.RemoveKey("Name");
            }
            txtUsername.Attributes["placeholder"] = "Nhập số điện thoại để đăng nhập";
            txtPassword.Attributes["placeholder"] = "Nhập mật khẩu của bạn";
            txtUsername.Attributes["required"] = "required";
            txtPassword.Attributes["required"] = "required";
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        string returnUrl = HttpUtility.UrlDecode(Request.QueryString["returnUrl"]);

        string pass = ApplicationUtil.PasswordEncrypt(txtPassword.Text);
        var members = new MemberRepository().SearchFor(o => o.Member_Username == txtUsername.Text || o.Member_Email == txtUsername.Text || o.Member_Phone == txtUsername.Text);
        if (members.Count() > 0)
        {
            tbl_Member member = members.SingleOrDefault();
            if (member.Member_Password == pass)
            {
                if (member.Member_Status == false)
                {
                    Value.ShowMessage(ltrLoginMessage, ErrorMessage.AccountLocked, AlertType.ERROR);
                    txtUsername.Focus();
                }
                else
                {
                    Session["MemberID"] = member.Member_ID;
                    Session["Member_Role"] = member.Member_Role;
                    Session["Member_Username"] = member.Member_Username;
                    Session["Member_Email"] = member.Member_Email;
                    Session["Member_Avarta"] = member.Member_Avarta;
                    Session["Member_Name"] = member.Member_Name;
                    if (ckRemember.Checked)
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
                        Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Value.ShowMessage(ltrLoginMessage, string.Format(ErrorMessage.Success, "Đăng nhập",""), AlertType.ERROR);
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        Response.Redirect("/");
                    }
                    else
                    {
                        Response.Redirect(returnUrl);
                    }
                }
            }
            else
            {
                Value.ShowMessage(ltrLoginMessage, ErrorMessage.LoginFail, AlertType.ERROR);
                txtUsername.Focus();
            }
        }
        else
        {
            Value.ShowMessage(ltrLoginMessage, ErrorMessage.LoginFail, AlertType.ERROR);
            txtUsername.Focus();
        }
    }
}