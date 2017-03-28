using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_CheckOut : System.Web.UI.UserControl
{
    public int modId;
    public ChuyenXe cx = new ChuyenXe();
    protected void Page_Load(object sender, EventArgs e)
    {
        string mod = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        string chuyenxe = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["nurl"].ToString();
        modId =ModControl.GetP_From_Code(mod);
        var res = new ChuyenXeRepository().SearchFor(o => o.url == chuyenxe).SingleOrDefault();
        if (res != null)
        {
            res.Xe = new XeRepository().Find(res.MaXe.Value);
            res.Xe.NhaXe1 = new NhaxeRepository().Find(res.Xe.Nhaxe.Value);
            cx = res;
        }
        else
        {
            Response.Redirect("/404.htm");
        }
        CMSfunc.checkURL();
        if (Session["UserID"] != null)
        {
            //var user = UserControls.GetUserByID(int.Parse(Session["UserID"].ToString()));
            //txtAddress.Text = user.User_Address;
            //txtName.Text = user.User_Name;
            //txtTel.Text = user.User_Tel;
            //email.Text = user.User_Email;
        }
        ltrSodo.Text = LoadSodo(cx.TongVe.Value, cx.VeThuongConLai.Value, cx.VeVipConLai.Value);

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
    public string LoadSodo(int Tong, int Thuong, int Vip)
    {
        StringBuilder str = new StringBuilder();
        int sohang = Tong / 4;
        int tongdu = Tong % 4;
        int sohangvip = Vip / 4;
        int vipdu = Vip % 4;
        int sohangt = Thuong / 4;
        int tdu = Thuong % 4;
        for (int i = 0; i < sohangvip; i++)
        {
            str.Append("<tr>");
            for (int j = 0; j < 4; j++)
            {
                str.Append("<td ng-click=\"toggle()\" data-type='VIP' data-status='false'>");
                str.Append("<img class=\"c-nornal\" src=\"../../resources/img/icon/icon-chairvip2.png\"/>");
                str.Append("<img class=\"c-vip\" src=\"../../resources/img/icon/icon-chairvip.png\" style=\"display: none\"/>");
                str.Append("</td>");
            }
            str.Append("</tr>");
        }
        str.Append("<tr>");
        for (int k = 0; k < vipdu; k++)
        {
            str.Append("<td ng-click=\"toggle()\" data-type='VIP' data-status='false'>");
            str.Append("<img class=\"c-nornal\" src=\"../../resources/img/icon/icon-chairvip2.png\"/>");
            str.Append("<img class=\"c-vip\" src=\"../../resources/img/icon/icon-chairvip.png\" style=\"display: none\"/>");
            str.Append("</td>");
        }
        if (vipdu != 0)
        {
            for (int k = 0; k < 4 - vipdu; k++)
            {
                str.Append("<td ng-click=\"toggle()\" data-type='THUONG' data-status='false'>");
                str.Append("<img class=\"c-nornal\" src=\"../../resources/img/icon/icon-chair.png\"/>");
                str.Append("<img class=\"c-vip\" src=\"../../resources/img/icon/icon-ghedadat.png\" style=\"display: none\"/>");
                str.Append("</td>");
            }
        }
        str.Append("<tr>");
        for (int i = 0; i < sohangt; i++)
        {
            str.Append("<tr>");
            for (int j = 0; j < 4; j++)
            {
                str.Append("<td ng-click=\"toggle()\" id='" + (Vip+ i) + "-" + j + "' data-type='THUONG' data-status='false'>");
                str.Append("<img class=\"c-nornal\" src=\"../../resources/img/icon/icon-chair.png\"/>");
                str.Append("<img class=\"c-vip\" src=\"../../resources/img/icon/icon-ghedadat.png\" style=\"display: none\"/>");
                str.Append("</td>");
            }
            str.Append("</tr>");
        }
        str.Append("<tr>");
        for (int k = 0; k < tdu; k++)
        {
            str.Append("<td ng-click=\"toggle()\" id='"+(sohang+1)+"-"+k+"' data-type='THUONG' data-status='false'>");
            str.Append("<img class=\"c-nornal\" src=\"../../resources/img/icon/icon-chair.png\"/>");
            str.Append("<img class=\"c-vip\" src=\"../../resources/img/icon/icon-ghedadat.png\" style=\"display: none\"/>");
            str.Append("</td>");
        }
        for (int k = 0; k < 4-tdu; k++)
        {
            str.Append("<td>");
            str.Append("</td>");
        }
        str.Append("</tr>");
        return str.ToString();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
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
                    Session["Member_Username"] = rows[0]["Member_Username"].ToString();
                    Session["Member_Email"] = rows[0]["Member_Email"].ToString();
                    Session["Member_Avarta"] = rows[0]["Member_Avarta"].ToString();
                    Session["Member_Name"] = rows[0]["Member_Name"].ToString();
                    if (Remember.Checked)
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
                    Value.ShowMessage(ltrLoginMessage, string.Format(ErrorMessage.Success, "Đăng nhập", ""), AlertType.ERROR);
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