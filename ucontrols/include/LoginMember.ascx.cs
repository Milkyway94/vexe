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
            txtUsername.Attributes["placeholder"] = "Nhập Email hoặc số điện thoại";
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

    protected string _Replate(string str)
    {
        str = str.Replace("'", "");
        str = str.Replace("*", "");
        str = str.Replace(";", "");
        str = str.Replace("-", "");
        str = str.Replace("~", "");
        str = str.Replace(")", "");
        str = str.Replace("(", "");
        str = str.Replace("]", "");
        str = str.Replace("[", "");
        str = str.Replace("@", "");
        str = str.Replace("%", "");
        str = str.Replace("<", "");
        str = str.Replace(">", "");
        return str.ToString();
    }
    protected void btLogin_Click(object sender, EventArgs e)
    {
        string returnUrl = HttpUtility.UrlDecode(Request.QueryString["returnUrl"]);

        string pass = ApplicationUtil.PasswordEncrypt(_Replate(txtPassword.Text));
        string sql = "SELECT * FROM tbl_Member WHERE Member_Username='" + _Replate(txtUsername.Text) + "' OR Member_Phone='" + _Replate(txtUsername.Text) + "' OR Member_Email='" + _Replate(txtUsername.Text) + "'";
        DataSet dsUser = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = dsUser.Tables[0].Rows;
        if (rows.Count >= 1)
        {
            if (rows[0]["Member_Password"].ToString() == pass)
            {
                if (Convert.ToBoolean(rows[0]["Member_Status"]) == false)
                {
                    Value.ShowMessage(ltrLoginMessage, ErrorMessage.AccountLocked, AlertType.ERROR);
                    txtUsername.Focus();
                }
                else
                {
                    Session["MemberID"] = rows[0]["Member_ID"].ToString();
                    Session["Member_Role"] = rows[0]["Member_Role"].ToString();
                    Session["Member_Username"] = rows[0]["Member_Username"].ToString();
                    Session["Member_Email"] = rows[0]["Member_Email"].ToString();
                    Session["Member_Avarta"] = rows[0]["Member_Avarta"].ToString();
                    Session["Member_Name"] = rows[0]["Member_Name"].ToString();
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