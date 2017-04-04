using System;
using System.Web.UI;
using System.Text;
using SMAC;
using System.IO;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Web.Services;
using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using QCMS_BUSSINESS.Model;
using System.Linq;

public partial class _Default : Page
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string url, nUrl;
    protected int p, id;
    protected int o;

    protected string video;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ltrTitle.Text = LoadTitle(p, 1);
        CMSfunc.checkURL();
        string lang = Request.QueryString["lang"];
        if (!String.IsNullOrEmpty(lang) && lang != "1")
        {
            Session["vlang"] = lang;
        }
        if (Session["vlang"] == null || lang == "1")
        {
            Session["vlang"] = "1";
        }
        url = String.IsNullOrEmpty(Request.QueryString["url"]) ? "Home" : Request["url"].ToString();
        nUrl = String.IsNullOrEmpty(Request["nUrl"]) ? "" : Request["nUrl"].ToString();
        p = ModControl.GetP_From_Code(url);
        id = ModControl.GetID_From_Url(p, nUrl);
        //====================================================
        LoadHeadTag(p, id);
        //ltrAboutUS.Text = LoadAboutUs();
        //====================================================
        if (Request["a"] == "send")
        {
            string txtEmail = Request["txtEmail"];
            string txtName = Request["txtName"];
            string txtPhone = Request["txtPhone"];
            string txtContent = Request["txtContent"];
            string sql1 = "SET IDENTITY_INSERT tbl_Contact ON";
            sql1 += "INSERT INTO tbl_Contact(Contact_Name, Contact_Tel, Contact_Email, Contact_Content) VALUES(" + txtName + "," + txtPhone + ", " + txtEmail + ", " + txtContent + ")";
            try
            {
                UpdateData.UpdateBySql(sql1);
            }
            catch (Exception ex)
            {

                Response.Write("<script>console.log(\"" + ex.ToString() + "\");</script>");
            }

            //====================================================
            string strBody = "<html><body>\n";
            strBody += "<h3>LỜI NHẮN TỪ WEBSITE http://phuongbelo.com</h3>\n";
            strBody += "<table class=\"cssRegister\" cellpadding=\"1\" cellspacing=\"1\">\n";
            strBody += "<tr><td><b>" + CMSfunc._Title("Họ Tên") + "</b></td><td>" + txtName + "</td></tr>\n";
            strBody += "<tr><td><b>" + CMSfunc._Title("Điện thoại") + "</b></td><td>" + txtPhone + "</td></tr>\n";
            strBody += "<tr><td><b>E-mail</td><td>" + txtEmail + "</b></td></tr>\n";
            strBody += "<tr><td><b>" + CMSfunc._Title("Nội dung liên hệ") + "</b></td><td>" + txtContent + "</td></tr>\n";
            strBody += "</table>\n";
            strBody += "</body></html>\n";
            //====================================================
            string fromEmail = txtEmail.Trim();
            string toEmail = CMSfunc._GetConst("_EmailAdmin");
            string Name = txtName.Trim();
            string Subject = "[PhuongBelo]Thông tin liên hệ từ khách hang thông qua website http://PhuongBelo.com";
            string Host = CMSfunc._GetConst("_Hostmail");
            string EmailClient = CMSfunc._GetConst("_EmailClient");
            string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
            int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
            string SendSuccess = CMSfunc._Title("[PhuongBelo] Bạn đã gửi thông tin liên hệ thành công!");
            bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, SendSuccess, strBody);
            if (_isSend)
            {
                string url1 = "/";//HttpContext.Current.Request.Url.Host; 
                string alert = "<script>\n";
                alert += "alert('" + SendSuccess + "!');\n";
                alert += "document.location='" + url1 + "';";
                alert += "</script>\n";
                //Session["UserID"] = new List<tbl_User>();
                Response.Write(alert);
            }
        }
    }
    protected override void CreateChildControls()
    {
        url = Request.QueryString["url"];
        string _F = ContentControl._LoadControl(ModControl.GetP_From_Code(url));
        Control _objControl;
        _F = _F == null ? "" : _F;
        switch (_F)
        {
            default:
                _objControl = LoadControl("ucontrols/include/404.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "About":
                _objControl = LoadControl("ucontrols/include/About.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "RequestTravel":
                _objControl = LoadControl("ucontrols/include/RequestTravel.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "giao-dich":
                _objControl = LoadControl("ucontrols/include/Transaction.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Profile_History":
                _objControl = LoadControl("ucontrols/include/Profile_History.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Checkin":
                _objControl = LoadControl("ucontrols/include/Checkin.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Profile_Vola":
                _objControl = LoadControl("ucontrols/include/Profile_Vola.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Profile_Info":
                _objControl = LoadControl("ucontrols/include/Profile_Info.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Profile_UpdateInfo":
                _objControl = LoadControl("ucontrols/include/Profile_UpdateInfo.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Step3":
                _objControl = LoadControl("ucontrols/include/Step3.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Profile":
                _objControl = LoadControl("ucontrols/include/Profile.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "VertifyTicket":
                _objControl = LoadControl("ucontrols/include/Vertify.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Login":
                _objControl = LoadControl("ucontrols/include/LoginMember.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Home":
            case "":
                _objControl = LoadControl("ucontrols/include/Home.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "CheckOut":
                _objControl = LoadControl("ucontrols/include/CheckOut.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Service":
                _objControl = LoadControl("ucontrols/include/Service.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Concept":
                _objControl = LoadControl("ucontrols/include/Tuyendung.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Gallery":
                _objControl = LoadControl("ucontrols/include/Gallery.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "News":
                _objControl = LoadControl("ucontrols/include/News.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Contact":
                _objControl = LoadControl("ucontrols/include/Contact.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Document":
                _objControl = LoadControl("ucontrols/include/Document.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Order":
                _objControl = LoadControl("ucontrols/include/Order.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Enterprise":
                _objControl = LoadControl("ucontrols/include/Enterprise.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Shop":
            case "Product":
                _objControl = LoadControl("ucontrols/include/Shop.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Register":
                _objControl = LoadControl("ucontrols/include/Registers.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "tim-kiem":
                _objControl = LoadControl("ucontrols/include/Search.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "kiem-tra-ve":
                _objControl = LoadControl("ucontrols/include/CheckTicket.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "NhaXe":
                _objControl = LoadControl("ucontrols/include/NhaXe.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
        }
        base.CreateChildControls();
    }
    public string LinkIcon()
    {
        string sql = "select * from tbl_Other where Other_Mod='social' and Other_Status=1 and lang=" + Session["vlang"];
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string fa = rows[i]["Other_Name"].ToString();
                string link = rows[i]["Other_Content"].ToString();
                str.Append("<li class=\"" + fa + "\"><a href = \"" + link + "\" target=\"_blank\" ><span class='icon-social'><i class=\"fa fa-" + fa + "\"></i></span><span class=\"title-social\"> " + fa + " </span></a></li>");
            }
        }
        return str.ToString();
    }

    public string LoadListOrder()
    {
        StringBuilder str = new StringBuilder();
        if (ShoppingCarts.cart != null)
        {
            str.Append("<div class=\"table-responsive\">");
            str.Append("<table class=table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            str.Append("<tbody>");
            str.Append("<tr class=\"thead_giohang\">");
            str.Append("<td class=\"col_sp\">SẢN PHẨM</td>");
            str.Append("<td>SỐ LƯỢNG</td>");
            str.Append("<td class=\"text-center\">ĐƠN GIÁ</td>");
            str.Append("<td class=\"text-center\">THÀNH TIỀN</td>");
            str.Append("</tr>");
            foreach (var item in ShoppingCarts.cart)
            {
                double tongtien = double.Parse(item.Product.Price.ToString()) * item.Quantity;
                str.Append("<tr>");
                str.Append("<td>");
                str.Append("<div class=\"item_list_donhang\">");
                str.Append("<div class=\"col-lg-4 col-md-4 col-sm-4 col-xs-4\">");
                str.Append("<div class=\"thumb_donhang\"><img alt = \"#\" src=\"" + item.Product.Avatar + "\"></div></div>");
                str.Append("<div class=\"col-lg-8 col-md-8 col-sm-8 col-xs-8\">");
                str.Append("<div class=\"title_sanpham_donhang\"><b>" + item.Product.Name + "</b></div>");
                str.Append("<div class=\"title_sanpham_donhang\">Mã sản phẩm:  <b>" + item.Product.SKU + "</b></div></div></div>");
                str.Append("</td>");
                str.Append("<td>");
                str.Append("<input type =\"text\" placeholder=\"1-100\" class=\"form-control\" id=\"quantity_" + item.Product.ID + "\" onblur=\"UpdateQuantity(" + item.Product.ID + ")\" value=\"" + item.Quantity + "\" style=\"margin-top:5px; width:70px;\">");
                str.Append("<div class=\"txt_error\" id=\"inp_so_luong_sp_0_error\"></div>");
                str.Append("</td>");
                str.Append("<td class=\"text-center\">");
                str.Append("<span class=\"txt_money\">" + item.Product.Price + "</span></td>");
                str.Append("<td class=\"text-center relative\"><span class=\"txt_money\" id=\"tong_tien_sp_" + item.Product.ID + "\">" + tongtien + "</span>");
                str.Append("<a class=\"del_donhang\"><i class=\"fa fa-times\"></i></a>");
                str.Append(" </td>");
                str.Append("<td>");
                str.Append("<input type =\"text\" placeholder=\"1-100\" class=\"form-control\" id=\"inp_so_luong_sp_0\" style=\"display: none; margin-top:5px; width:70px;>");
                str.Append("<div class=\"txt_error\" id=\"inp_so_luong_sp_0_error\"></div>");
                str.Append("</td>");
                str.Append("</tr>");
            }
            str.Append("</tbody>");
            str.Append("</table>");
            str.Append("</div>");
        }
        else
        {
            str.Append("<tr><td colspan=\"4\"><b>Bạn chưa có sản phẩm nào trong giỏ, mời bạn tiếp tục mua sắm.</b></td></tr>");
        }
        return str.ToString();
    }
    protected string GetUsernameByID()
    {
        int o = int.Parse(Session["UserID"].ToString());
        string sql = "select * from tbl_User where User_ID=" + o;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string name = rows[0]["username"].ToString();
            str.Append("<a href=\"/profile.htm\">" + name + "</a>");
        }
        return str.ToString();
    }

    public void LoadHeadTag(int p, int id)
    {
        StringBuilder str = new StringBuilder();
        string CurrentURL = "http://phuongbelo.com" + System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.Replace("Default.aspx", string.Empty);
        string sql = "";
        if (p != 0)
        {
            if (id != 0)
                sql += "SELECT Content_Name,Content_Title,Content_Key,Content_Des,Content_Img FROM tbl_Content Where Mod_ID=" + p + " AND Content_ID=" + id + " AND Content_Status=1";
            else
                sql += "SELECT Mod_Name,Mod_Title,Mod_Key,Mod_Des,Mod_Img FROM tbl_Mod Where Mod_ID=" + p + " AND Mod_Status=1";
            DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
            DataRowCollection rows = ds.Rows;
            if (rows.Count > 0)
            {
                ltrTitle.Text = rows[0][1].ToString();
                this.ltrHeadTags.Text += string.Format("<meta name='keywords' content='{0}' />", rows[0][2]);
                this.ltrHeadTags.Text += string.Format("<meta name='description' content='{0}' />", rows[0][3]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:image' content='{0}' />", rows[0][4]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:title' content='{0}' />", rows[0][1]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:description' content='{0}' />", rows[0][3]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:site_name' content='{0}' />", rows[0][0]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:url' content='{0}' />", CurrentURL);
            }
        }
        else
        {
            this.ltrHeadTags.Text += string.Format("<meta name='keywords' content='{0}' />", ModControl.GetModField("Key", ModControl.GetP_From_Code("Home")));
            this.ltrHeadTags.Text += string.Format("<meta name='description' content='{0}' />", ModControl.GetModField("Des", ModControl.GetP_From_Code("Home")));
            ltrTitle.Text = ModControl.GetModField("Title", ModControl.GetP_From_Code("Home"));
        }
        this.ltrHeadTags.Text += "<link rel=\"canonical\" href=\"" + CurrentURL + "\" />";
        this.ltrHeadTags.Text += CMSfunc.LoadOther("HeadContent");
    }

    protected string CheckOut(int p)
    {
        string sql = "SELECT Mod_Name,Mod_Parent, Mod_ID,Mod_Code, Mod_Img FROM tbl_Mod WHERE Mod_ID=1275 and lang=" + Session["vlang"] + " AND Mod_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < rows.Count; i++)
        {
            string urlL1 = ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm");
            str.Append("<a href=\"" + urlL1 + "\" class=\"btn btn-success\" id=\"checkout_c\">Thanh toán</a>");
        }
        return str.ToString();
    }
    public string GetMinitop()
    {
        int p;
        string n, c, sql;
        sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1";
        sql += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
        sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Minitop' AND lang=" + Session["vlang"] + "))";
        sql += " ORDER BY Mod_Pos";
        //===================================================
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        //===================================================    
        for (int i = 0; i < rows.Count; i++)
        {
            p = Convert.ToInt32(rows[i]["Mod_ID"]);
            n = rows[i]["Mod_Name"].ToString();
            c = rows[i]["Mod_Code"].ToString();
            string url = c == "home" ? ResolveUrl("~/") : ResolveUrl("~/" + c + ".htm");
            str.Append("<a title=\"" + n + "\" href=\"" + url + "\">" + n + "</a>");
            if (i < rows.Count - 1) str.Append(" | ");
        }
        return str.ToString();
    }
    protected string LoadTitle(int p, int id)
    {
        StringBuilder str = new StringBuilder();
        if (p != 0)
        {
            if (id != 0)
                str.Append(ContentControl.GetContentField("Title", id));
            else
            {
                str.Append(ModControl.GetModField("Title", p));
                int cm = ConvertUtil.ReplaceInt(Request["cm"]);
                int ck = ConvertUtil.ReplaceInt(Request["ck"]);
                if (cm != 0)
                    str.Append(" - " + ModControl.GetModField("Name", cm));
                if (ck != 0)
                    str.Append(" - " + ModControl.GetModField("Name", ck));
            }
        }
        else
        {
            str.Append(ModControl.GetModField("Title", ModControl.GetP_From_Code("Home")));
        }

        return str.ToString();
    }
    protected string LoadKey(int p, int id)
    {
        StringBuilder str = new StringBuilder();
        str.Append("<meta name=\"keywords\" content=\"");
        if (p != 0)
        {
            if (id != 0)
                str.Append(ContentControl.GetContentField("Key", id));
            else
                str.Append(ModControl.GetModField("Key", p));
            int cm = ConvertUtil.ReplaceInt(Request["cm"]);
            int ck = ConvertUtil.ReplaceInt(Request["ck"]);
            if (cm != 0)
                str.Append(" - " + ModControl.GetModField("Name", cm));
            if (ck != 0)
                str.Append(" - " + ModControl.GetModField("Name", ck));
        }
        else
            str.Append(ModControl.GetModField("Key", ModControl.GetP_From_Code("Home")));

        str.Append("\" />");
        return str.ToString();
    }
    protected string LoadDes(int p, int id)
    {
        StringBuilder str = new StringBuilder();
        str.Append("<meta name=\"description\" content=\"");
        if (p != 0)
        {
            if (id != 0)
                str.Append(ContentControl.GetContentField("Meta", id));
            else
                str.Append(ModControl.GetModField("Meta", p));
            int cm = ConvertUtil.ReplaceInt(Request["cm"]);
            int ck = ConvertUtil.ReplaceInt(Request["ck"]);
            if (cm != 0)
                str.Append(" - " + ModControl.GetModField("Name", cm));
            if (ck != 0)
                str.Append(" - " + ModControl.GetModField("Name", ck));
        }
        else
            str.Append(ModControl.GetModField("Meta", ModControl.GetP_From_Code("Home")));

        str.Append("\" />");
        return str.ToString();
    }
    protected string LoadSocial()
    {
        StringBuilder str = new StringBuilder();
        string uRoot = ApplicationSetting.URLRoot;
        str.Append("<li><a href=\"" + CMSfunc._Title("urlFacebook") + "\"><i class=\"fa fa-facebook\"></i></a></li>");
        str.Append("<li><a href=\"" + CMSfunc._Title("urlYoutube") + "\"><i class=\"fa fa-youtube\"></i></a></li>");
        str.Append("<li><a href=\"" + CMSfunc._Title("urlGoogle") + "\"><i class=\"fa fa-google-plus\"></i></a></li>");
        return str.ToString();
    }
    protected string GetMnFooter()
    {
        string sql = "SELECT m.Mod_ID, m.Mod_Name,m.Mod_Code FROM tbl_Mod m LEFT JOIN ";
        sql += " tbl_ModBox mb on m.Mod_ID = mb.Mod_ID LEFT JOIN  ";
        sql += " tbl_Box b on mb.Box_ID = b.Box_ID";
        sql += " WHERE m.lang=" + Session["vlang"] + " AND m.Mod_Status=1 AND b.Box_Code='Menufooter'";
        sql += " ORDER BY m.Mod_Pos";
        //===================================================
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        //===================================================
        str.Append("<ul>");
        for (int i = 0; i < rows.Count; i++)
        {
            int p = Convert.ToInt32(rows[i][0]);
            string n = rows[i][1].ToString();
            string c = rows[i][2].ToString();
            string url = c == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + c + ".htm");
            str.Append("<li><a title=\"" + n + "\" href=\"" + url + "\">" + n + "</a></li>");
            //if (i < rows.Count - 1) str.Append("<a title=\"" + n + "\" href=\"#\">|</a>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    protected string GetSiteLink()
    {
        //string sql = "SELECT top 5 Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Level=1 AND lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Hot=1 ORDER BY Mod_Pos";
        string sql = "SELECT m.Mod_ID, m.Mod_Name,m.Mod_Code FROM tbl_Mod m LEFT JOIN ";
        sql += " tbl_ModBox mb on m.Mod_ID = mb.Mod_ID LEFT JOIN  ";
        sql += " tbl_Box b on mb.Box_ID = b.Box_ID";
        sql += " WHERE m.lang=" + Session["vlang"] + " AND m.Mod_Status=1 AND b.Box_Code='SiteLink'";
        sql += " ORDER BY m.Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        StringBuilder str = new StringBuilder();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int idL1 = Convert.ToInt32(dr["Mod_ID"]);
            string nL1 = dr["Mod_Name"].ToString();
            string cL1 = dr["Mod_Code"].ToString();
            string url = ResolveUrl("~/" + cL1 + "/" + idL1 + ".htm");
            str.Append("<div class=\"col-xs-12 col-sm-6 col-md-2 itemFooter\">");
            str.Append("    <h5><a href=\"" + url + "\" title=\"" + nL1 + "\">" + nL1 + "</a></h5>");
            string sql1 = "SELECT top 10 Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Parent=" + idL1 + " AND lang=" + Session["vlang"] + " AND Mod_Status=1 ORDER BY Mod_Pos";
            DataSet ds1 = UpdateData.UpdateBySql(sql1);
            DataRowCollection rows1 = ds1.Tables[0].Rows;
            if (rows1.Count > 0)
            {
                str.Append("<ul>");
                for (int i = 0; i < rows1.Count; i++)
                {
                    int idL2 = Convert.ToInt32(rows1[i]["Mod_ID"]);
                    string nL2 = rows1[i]["Mod_Name"].ToString();
                    string cL2 = rows1[i]["Mod_Code"].ToString();
                    string urlL2 = cL2 == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + cL2 + "/" + idL2 + ".htm");
                    str.Append("<li><a href=\"" + urlL2 + "\" title=\"" + nL2 + "\">" + nL2 + "</a></li>");
                }
                str.Append("</ul>");
            }
            str.Append("</div>");
        }
        return str.ToString();
    }
    public string LoadPartner()
    {
        StringBuilder str = new StringBuilder();
        DataSet ds = UpdateData.UpdateBySql("SELECT Content_Name,Content_Img,Content_URL FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID in(SELECT Mod_ID FROM tbl_Mod WHERE Mod_Code='GiaiThuong') ORDER BY Content_Pos DESC");
        DataRowCollection rows = ds.Tables[0].Rows;
        str.Append("<ul class=\"bodySliderBottom\">");
        for (int i = 0; i < rows.Count; i++)
        {
            string n = rows[i]["Content_Name"].ToString();
            string img = ApplicationSetting.URLRoot + rows[i]["Content_Img"].ToString();
            string url = rows[i]["Content_URL"].ToString();
            str.Append("    <li><a href=\"" + url + "\" target=\"_blank\"><img src=\"" + img + "\" alt=\"" + n + "\" title=\"" + n + "\"/></a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    #region Online Visitor Counter
    public string getVisitor()
    {
        return System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[1];
    }
    public string getVisitorOnline()
    {
        return System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[0];
    }
    #endregion
    public string MenuNoiBo(int p)
    {
        string sql = "SELECT Mod_Name,Mod_ID,Mod_Code, Mod_Img FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1";
        sql += " AND Mod_Level=1 AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
        sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_ID='9' AND lang=" + Session["vlang"] + "))";
        sql += " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (Session["UserID"] == null)
        {
            return "";
        }
        for (int i = 0; i < rows.Count; i++)
        {
            if (AuthenticationMenu.CheckPermission(int.Parse(rows[i]["Mod_ID"].ToString()), int.Parse(Session["UserID"].ToString())))
            {
                string cL1 = rows[i]["Mod_Code"].ToString();
                string nL1 = rows[i]["Mod_Name"].ToString();
                string iL1 = rows[i]["Mod_Img"].ToString();
                string urlL1 = cL1 == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm");
                if (int.Parse(rows[i]["Mod_ID"].ToString()) == p)
                {
                    str.Append("<li class=\"active\"><a title=\"" + nL1 + "\" href=\"" + urlL1 + "\"><img  height=16 width=16 src=" + iL1 + " >&nbsp;" + nL1 + "</a></li>");
                }
                else
                {
                    str.Append("<li><a title=\"" + nL1 + "\" href=\"" + urlL1 + "\"><img  height=16 width=16 src=" + iL1 + " >&nbsp;" + nL1 + "</a></li>");
                }
            }
        }
        return str.ToString();
    }
    public string GetShopCat(int ModID)
    {
        string currentURL = HttpContext.Current.Request.Url.Host;
        StringBuilder str = new StringBuilder();
        if (ModID == 232)
        {
            string sql = "select * from Shop_Category where TypeLevel=1 and lang=" + Session["vlang"];
            DataSet ds = UpdateData.UpdateBySql(sql);
            DataRowCollection rows = ds.Tables[0].Rows;
            if (rows.Count > 0)
            {
                str.Append("<ul class=\"sub-menu1\">");
                for (int i = 0; i < rows.Count; i++)
                {
                    string text3 = rows[i]["ID"].ToString();
                    string text4 = rows[i]["Name"].ToString();
                    string text5 = rows[i]["NameAscii"].ToString();
                    string text7 = CMSfunc.ReWriteUrlMod(text3);

                    // string urlL1 = "san-pham.htm?CatID="+rows[i]["ID"];
                    str.Append("<li><a href = \"" + text7 + "\" ><i class=\"fa fa-user-plus fa-lg\"></i>" + text4 + "</a></li>");
                }
                str.Append("</ul>");
            }
        }

        return str.ToString();
    }
    public string facebookfanpage()
    {
        string sql = "select * from tbl_Other where Other_Mod='Facebook'";
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }

    public string LoadChinhSach()
    {
        string sql = "select * from tbl_Other where Other_Mod='Quydinh'";
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }

    public string LoadContact()
    {
        string sql = "select * from tbl_Other where Other_Mod='contact' and lang=" + Session["vlang"];
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }
    //public string LoadAboutUs()
    //{
    //    string sql = "select * from tbl_Other where Other_Mod='aboutus' AND lang=" + Session["vlang"];
    //    sql += "and Other_Status=1";
    //    DataSet ds = UpdateData.UpdateBySql(sql);
    //    DataRowCollection rows = ds.Tables[0].Rows;
    //    StringBuilder str = new StringBuilder();
    //    if (rows.Count > 0)
    //    {
    //        string link = rows[0]["Other_Content"].ToString();
    //        str.Append(link);
    //    }
    //    return str.ToString();
    //}
    //public static tbl_Promote GetPromoteByCode(string Code)
    //{
    //    string sql = "SELECT * FROM tbl_Promote WHERE Code='" + Code+"' AND Status!=2";
    //    tbl_Promote p = new tbl_Promote();
    //    DataRowCollection rows = UpdateData.UpdateBySql(sql).Tables[0].Rows;
    //    if (rows.Count > 0)
    //    {
    //        DataRow item = rows[0];
    //        p.ID = int.Parse(item["ID"].ToString());
    //        p.Code = item["Code"].ToString();
    //        p.Value = double.Parse(item["Value"].ToString());
    //        p.Start = DateTime.Parse(item["Start"].ToString());
    //        p.End = DateTime.Parse(item["End"].ToString());
    //        p.OrderFrom = double.Parse(item["OrderFrom"].ToString());
    //        p.OrderTo = double.Parse(item["OrderTo"].ToString());
    //        p.Status = int.Parse(item["Status"].ToString());
    //        return p;
    //    }
    //   else
    //    {
    //        return null;
    //    }
    //}
    [WebMethod]
    public static string LoadSearchInput()
    {
        string str = "{";
        str += "\"Diemdi\": \"" + HttpContext.Current.Request["Xuatphat"] + "\",";
        str += "\"Diemden\": \"" + HttpContext.Current.Request["Dich"] + "\"";
        str += "}";
        return str;
    }
    [WebMethod]
    public static List<TinhThanh> GetAllProvince()
    {
        ProvinceRepository proRepo = new ProvinceRepository();
        return proRepo.All().ToList();
    }
    [WebMethod]
    public static List<ChuyenXeViewModel> SearchTravel(string Ngaydi, string Giodi, string Diemdi, string Diemden)
    {
        List<ChuyenXeViewModel> lstCx = new List<ChuyenXeViewModel>();
        ChuyenXeRepository cxRepo = new ChuyenXeRepository();
        var td = cxRepo.SearchFor(o => (o.Diemdi.Contains(Diemdi) || Diemdi.Contains(o.Diemdi)) && (o.Diemden.Contains(Diemden) || Diemden.Contains(o.Diemden)) && o.TrangThai != 0&& o.Ngaydi>DateTime.Now);
        foreach (var item in td)
        {
            ChuyenXeViewModel cx = new ChuyenXeViewModel(item);
            lstCx.Add(cx);
        }
        return lstCx;
    }
    [WebMethod]
    public static List<Code> getCode(int machuyen)
    {
        ChuyenXeRepository repo = new ChuyenXeRepository();
        return repo.LayThongTinVeCuaChuyenXe(machuyen);
    }
    [WebMethod]
    public static List<Ghe> LayGheCuaChuyen(int maxe)
    {
        GheRepository gheRepo = new GheRepository();
        var ghes = gheRepo.SearchFor(o => o.Maxe == maxe).ToList();
        foreach (var item in ghes)
        {
            item.Xe = new Xe();
        }
        return ghes;
    }
    [WebMethod]
    public static string LayTatCaDiaDiem()
    {
        StringBuilder str = new StringBuilder();
        ProvinceRepository proRepo = new ProvinceRepository();
        DistrictRepository distRepo = new DistrictRepository();
        str.Append("[");
        str.Append("{\"text\": \"Tỉnh/Thành Phố\",");
        str.Append("\"data\": [");
        foreach (var item in proRepo.All().ToList())
        {
            str.Append("\"" + item.TenTinh + "\"");
            if (proRepo.All().ToList().IndexOf(item) < proRepo.All().ToList().Count - 1)
            {
                str.Append(",");
            }
        }
        str.Append("]},{\"text\": \"Quận/Huyện/Bến xe\",");
        str.Append("\"data\": [");
        foreach (var item in distRepo.All().ToList())
        {
            item.TinhThanh = proRepo.Find(item.MaTinh.Value);
            str.Append("\"" + item.TenHuyen + "-" + item.TinhThanh.TenTinh + "\"");
            if (distRepo.All().ToList().IndexOf(item) < distRepo.All().ToList().Count - 1)
            {
                str.Append(",");
            }
        }
        str.Append("]}");
        str.Append("]");
        return str.ToString();
    }
    [WebMethod]
    public static ChuyenXe GetChuyenXeByUrl(string url)
    {
        var res = new ChuyenXeRepository().SearchFor(o => o.url == url).SingleOrDefault();
        res.Xe = new XeRepository().Find(res.MaXe.Value);
        res.Xe.NhaXe1 = new NhaxeRepository().Find(res.Xe.Nhaxe.Value);
        return res;
    }
    [WebMethod]
    public static Result<double> DoiVe(string Mave, string Tongtien)
    {
        Result<double> res = new Result<double>();
        if (HttpContext.Current.Session["MemberID"] != null)
        {
            int userId = int.Parse(HttpContext.Current.Session["MemberID"].ToString());
            string sql = "Select UnitPrice from tbl_OrderDetail od, tbl_Order o where o.Order_ID=od.Order_ID AND od.MaVe='" + Mave + "' and o.Order_Account='" + userId + "' AND o.Order_isComplete =0 AND od.isTimeOut=0";
            var result = UpdateData.UpdateBySql(sql);
            DataRowCollection rows = result.Tables[0].Rows;
            if (rows.Count > 0)
            {
                int machuyenxe = int.Parse(result.Tables[0].Rows[0]["MaChuyenXe"].ToString());
                ChuyenXe cxx = new ChuyenXeRepository().Find(machuyenxe);
                DateTime Giodi = cxx.Giokhoihanh.Value;
                int timeEx=Convert.ToInt32(CMSfunc._GetConst("_ExchangeTimeout"));
                TimeSpan timeout = new TimeSpan(timeEx, 0, 0);
                TimeSpan timeDiff =Giodi-DateTime.Now;
                if (timeDiff > timeout)
                {
                    double tt = double.Parse(result.Tables[0].Rows[0]["UnitPrice"].ToString());
                    if (tt >= double.Parse(Tongtien))
                    {
                        Hashtable tbVe = new Hashtable();
                        tbVe.Add("isTimeOut", "1");
                        bool _updateVe = UpdateData.Update("tbl_OrderDetail", tbVe, "MaVe='" + Mave + "'");
                        if (_updateVe)
                        {
                            res.data = tt;
                            res.errcode = ErrorCode.SUCCESS;
                            res.message = string.Format(ErrorMessage.Success, "Đổi vé");
                        }
                        else
                        {
                            res.data = 0;
                            res.errcode = ErrorCode.FAIL;
                            res.message = string.Format(ErrorMessage.Fail, "Mã vé");
                        }
                    }
                    else
                    {
                        res.data = 0;
                        res.errcode = ErrorCode.NOT_EQUAL;
                        res.message = ErrorMessage.NotEqual;
                    }
                }
                else
                {
                    res.data = 0;
                    res.errcode = ErrorCode.FAIL;
                    res.message = ErrorMessage.ExTimeOut;
                }
            }
            else
            {
                res.data = 0;
                res.errcode = ErrorCode.NODATA;
                res.message = string.Format(ErrorMessage.NotFound, "Mã vé");
            }
        }
        else
        {
            res.data = 0;
            res.errcode = ErrorCode.UNAUTHORIZED;
            res.message = ErrorMessage.Unauthorized;
        }
        return res;
    }
    [WebMethod]
    public static Result<OrderStatus> ThanhToan(int method, int vip, int thuong, int machuyenxe, double khuyenmai, double giatridoive, string diachinhanve, double tongtien)
    {
        Result<OrderStatus> res = new Result<OrderStatus>();
        var MemberID = HttpContext.Current.Session["MemberID"];
        if (MemberID != null)
        {
            string ticketCode = "VX" + Value.GetTimestamp(DateTime.Now) + "-" + machuyenxe + "-" + HttpContext.Current.Session["MemberID"].ToString();
            #region Input
            Hashtable tbIn = new Hashtable();
            tbIn.Add("Order_CheckOutMethod", method.ToString());
            tbIn.Add("Order_Vip", vip.ToString());
            tbIn.Add("Order_Thuong", thuong.ToString());
            tbIn.Add("Order_Promote", khuyenmai.ToString());
            tbIn.Add("Order_Giatrivedoi", giatridoive.ToString());
            tbIn.Add("Order_Account", HttpContext.Current.Session["MemberID"].ToString());
            tbIn.Add("Order_CreatedDate", DateTime.Now.ToString());
            tbIn.Add("MaChuyenXe", machuyenxe.ToString());
            tbIn.Add("Order_Code", ticketCode);
            tbIn.Add("Order_ShipAddress", diachinhanve);
            tbIn.Add("Order_TongTien", tongtien.ToString());
            tbIn.Add("Order_TongThanhToan", (tongtien-giatridoive-khuyenmai).ToString());
            #endregion
            #region Check GiaoDich
            //string gdQuery = "SELECT * FROM GiaoDich Where TrangThaiGiaoDich=1 AND MemberID=" + int.Parse(MemberID.ToString());
            //DataTable dtGd = UpdateData.UpdateBySql(gdQuery).Tables[0];
            //if (dtGd.Rows.Count > 0)
            //{
            //    tbIn.Add("Order_Status", "0");
            //}
            //else
            //{
            //    tbIn.Add("Order_Status", "1");
            //}
            #endregion
            tbIn.Add("Order_Status", "1");
            bool _insert = UpdateData.Insert("tbl_Order", tbIn);
            switch (method)
            {
                case 1:
                    #region Thanh Toan qua ATM

                    #endregion
                    break;
                case 2:
                    #region Thanh Toan qua VISA

                    #endregion
                    break;
                case 3:
                    #region Thanh Toan qua so du Ngan Luong

                    #endregion
                    break;
                case 4:
                    #region Thanh toan khi nhan ve
                    if (_insert)
                    {
                        #region Send Mail
                        //send mail
                        string strBody = "<html><body>\n";
                        strBody += "<h2>Xác thực giao dịch vé xe điện tử từ website " + CMSfunc._GetConst("_Domain") + "</h1><br>\n";
                        strBody += "Mã xác nhận của bạn là: <strong style='color: red'>" + ticketCode + "</strong><br>\n";
                        strBody += "Vui lòng ấn vào link dưới đây để xác thực: <br>\n";
                        strBody += "<a href=\"" + CMSfunc._GetConst("_Domain") + "/xac-thuc-thanh-toan.htm?mave=" + ticketCode + "\">Link xác nhận</a><br>\n";
                        strBody += "<span style='text-align: right'>Cảm ơn quý khách đã đặt vé tại " + CMSfunc._GetConst("_Domain") + "! </span>\n";
                        strBody += "</body></html>";

                        string fromEmail = HttpContext.Current.Session["Member_Email"].ToString().Trim();
                        string toEmail = HttpContext.Current.Session["Member_Email"].ToString();
                        string Name = HttpContext.Current.Session["Member_Name"].ToString().Trim();

                        string Subject = "XÁC THỰC ĐẶT VÉ XE ĐIỆN TỬ";
                        string Host = CMSfunc._GetConst("_Hostmail");
                        string EmailClient = CMSfunc._GetConst("_EmailClient");
                        string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                        int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                        try
                        {
                            bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                            if (_isSend)
                            {
                                res.data = OrderStatus.CoGiaoDichChuaXacThuc;
                                res.errcode = ErrorCode.TURNDATA;
                                res.message = ErrorMessage.HaveTransaction;
                            }
                            else
                            {
                                res.data = OrderStatus.ChuaGiaoDich;
                                res.errcode = ErrorCode.TURNDATA;
                                res.message = ErrorMessage.NoTransaction;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.data = OrderStatus.ChuaGiaoDich;
                            res.message = ex.Message;
                            res.errcode = ErrorCode.FAIL;
                        }
                        #endregion
                        //if (dtGd.Rows.Count > 0)
                        //{
                        //    res.data = OrderStatus.CoGiaoDichChuaXacThuc;
                        //    res.errcode = ErrorCode.TURNDATA;
                        //    res.message = ErrorMessage.HaveTransaction;
                        //}
                        //else
                        //{

                        //}
                    }
                    else
                    {
                        res.data = OrderStatus.ChuaThanhToan;
                        res.message = string.Format(ErrorMessage.Fail, "Thanh toán");
                        res.errcode = ErrorCode.FAIL;
                    }
                    #endregion
                    break;
                case 5:
                    #region Thanh Toan qua tich diem VOLA

                    #endregion
                    break;
                case 6:
                    #region Thanh toan khi len xe
                    if (_insert)
                    {
                        #region Send Mail
                        //send mail
                        string strBody = "<html><body>\n";
                        strBody += "<h2>Xác thực giao dịch vé xe điện tử từ website " + CMSfunc._GetConst("_Domain") + "</h1><br>\n";
                        strBody += "Mã xác nhận của bạn là: <strong style='color: red'>" + ticketCode + "</strong><br>\n";
                        strBody += "Vui lòng ấn vào link dưới đây để xác thực: <br>\n";
                        strBody += "<a href=\"" + CMSfunc._GetConst("_Domain") + "/xac-thuc-thanh-toan.htm?mave=" + ticketCode + "\">Link xác nhận</a><br>\n";
                        strBody += "<span style='text-align: right'>Cảm ơn quý khách đã đặt vé tại " + CMSfunc._GetConst("_Domain") + "! </span>\n";
                        strBody += "</body></html>";

                        string fromEmail = HttpContext.Current.Session["Member_Email"].ToString().Trim();
                        string toEmail = HttpContext.Current.Session["Member_Email"].ToString();
                        string Name = HttpContext.Current.Session["Member_Name"].ToString().Trim();

                        string Subject = "XÁC THỰC ĐẶT VÉ XE ĐIỆN TỬ";
                        string Host = CMSfunc._GetConst("_Hostmail");
                        string EmailClient = CMSfunc._GetConst("_EmailClient");
                        string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                        int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                        try
                        {
                            bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                            if (_isSend)
                            {
                                res.data = OrderStatus.CoGiaoDichChuaXacThuc;
                                res.errcode = ErrorCode.TURNDATA;
                                res.message = ErrorMessage.HaveTransaction;
                            }
                            else
                            {
                                res.data = OrderStatus.ChuaGiaoDich;
                                res.errcode = ErrorCode.TURNDATA;
                                res.message = ErrorMessage.NoTransaction;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.data = OrderStatus.ChuaGiaoDich;
                            res.message = ex.Message;
                            res.errcode = ErrorCode.FAIL;
                        }
                        #endregion
                        //if (dtGd.Rows.Count > 0)
                        //{
                        //    res.data = OrderStatus.CoGiaoDichChuaXacThuc;
                        //    res.errcode = ErrorCode.TURNDATA;
                        //    res.message = ErrorMessage.HaveTransaction;
                        //}
                        //else
                        //{

                        //}
                    }
                    else
                    {
                        res.data = OrderStatus.ChuaThanhToan;
                        res.message = string.Format(ErrorMessage.Fail, "Thanh toán");
                        res.errcode = ErrorCode.FAIL;
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }
        else
        {
            res.data = OrderStatus.ChuaThanhToan;
            res.errcode = ErrorCode.UNAUTHORIZED;
            res.message = ErrorMessage.Unauthorized;
        }
        return res;
    }
    [WebMethod]
    public static Result<bool> CreateTransaction(string Mathe)
    {
        Result<bool> res = new Result<bool>();
        var MemberID = HttpContext.Current.Session["MemberID"];
        if (MemberID != null)
        {
            Hashtable tbTrans = new Hashtable();
            string magiaodich = "GD" + Value.GetTimestamp(DateTime.Now) + MemberID.ToString();
            tbTrans.Add("MaTheGiaoDich", Mathe);
            tbTrans.Add("MemberID", MemberID.ToString());
            tbTrans.Add("ThoiGianGiaoDich", DateTime.Now.ToString());
            tbTrans.Add("GiaTriGiaoDich", "0");
            tbTrans.Add("TrangThaiGiaodich", "1");
            tbTrans.Add("MaGiaodich", magiaodich);
            bool _insertTran = UpdateData.Insert("GiaoDich", tbTrans);
            if (_insertTran)
            {
                //Check transaction
                string sqlTrans = "Select * from GiaoDich Where TrangThaiGiaodich=1 AND MemberID=" + MemberID.ToString() + " ORDER BY ID DESC";
                DataTable tblTrans = UpdateData.UpdateBySql(sqlTrans).Tables[0];
                if (tblTrans.Rows.Count > 0)
                {
                    #region Send Mail
                    //send mail
                    string strBody = "<html><body>\n";
                    strBody += "<h2>Xác thực giao dịch vé xe điện tử từ website " + CMSfunc._GetConst("_Domain") + "</h1><br>\n";
                    strBody += "Mã xác nhận của bạn là: <strong style='color: red'>" + tblTrans.Rows[0]["MaGiaoDich"].ToString() + "</strong><br>\n";
                    strBody += "Vui lòng ấn vào link dưới đây để xác thực: <br>\n";
                    strBody += "<a href=\"" + CMSfunc._GetConst("_Domain") + "/xac-thuc-thanh-toan.htm?mave=" + tblTrans.Rows[0]["MaGiaoDich"].ToString() + "\">Link xác nhận</a><br>\n";
                    strBody += "<span style='text-align: right'>Cảm ơn quý khách đã đặt vé tại " + CMSfunc._GetConst("_Domain") + "! </span>\n";
                    strBody += "</body></html>";

                    string fromEmail = HttpContext.Current.Session["Member_Email"].ToString().Trim();
                    string toEmail = HttpContext.Current.Session["Member_Email"].ToString();
                    string Name = HttpContext.Current.Session["Member_Name"].ToString().Trim();

                    string Subject = "XÁC THỰC ĐẶT VÉ XE ĐIỆN TỬ";
                    string Host = CMSfunc._GetConst("_Hostmail");
                    string EmailClient = CMSfunc._GetConst("_EmailClient");
                    string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                    int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                    try
                    {
                        bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                        if (_isSend)
                        {
                            res.data = true;
                            res.message = string.Format(ErrorMessage.Success, "Tạo giao dịch");
                            res.errcode = ErrorCode.SUCCESS;
                        }
                        else
                        {
                            res.data = false;
                            res.message = string.Format(ErrorMessage.Fail, "Tạo giao dịch");
                            res.errcode = ErrorCode.FAIL;
                        }
                    }
                    catch (Exception ex)
                    {
                        res.data = false;
                        res.message = ex.Message;
                        res.errcode = ErrorCode.FAIL;
                    }
                    #endregion
                }
                else
                {
                    res.data = false;
                    res.errcode = ErrorCode.NODATA;
                    res.message = string.Format(ErrorMessage.NotFound, "Giao dịch");
                }
            }
            else
            {
                res.data = false;
                res.message = string.Format(ErrorMessage.Fail, "Tạo giao dịch");
                res.errcode = ErrorCode.FAIL;
            }
        }
        else
        {
            res.data = false;
            res.errcode = ErrorCode.UNAUTHORIZED;
            res.message = ErrorMessage.Unauthorized;
        }
        return res;
    }
    [WebMethod]
    public static Result<bool> VertifyTicket(string magiaodich)
    {
        Result<bool> res = new Result<bool>();
        var MemberId = HttpContext.Current.Session["MemberID"];
        if (MemberId != null)
        {
            #region Trường hợp đã đăng nhập
            string sqlOrder = "SELECT * FROM tbl_Order WHERE  Order_Code='" + magiaodich + "'";
            DataSet dsOrder = UpdateData.UpdateBySql(sqlOrder);
            DataTable dtOrder = dsOrder.Tables[0];
            if (dtOrder.Rows.Count > 0)
            {
                if (dtOrder.Rows[0]["Order_Status"].ToString() == "1")
                {
                    #region CheckOrderStatus =1
                    int MaChuyenXe = Convert.ToInt32(dtOrder.Rows[0]["MaChuyenXe"].ToString());
                    int NumOfVip = Convert.ToInt32(dtOrder.Rows[0]["Order_Vip"].ToString());
                    int NumOfThuong = Convert.ToInt32(dtOrder.Rows[0]["Order_Thuong"].ToString());
                    string query = "SELECT * FROM ChuyenXe WHERE MaChuyenXe=" + MaChuyenXe;
                    DataTable tblChuyenXe = UpdateData.UpdateBySql(query).Tables[0];
                    if (tblChuyenXe.Rows.Count > 0)
                    {
                        #region Update Chuyen Xe
                        int TongSoVeThuongConLai = int.Parse(tblChuyenXe.Rows[0]["VeThuongConLai"].ToString()) - NumOfThuong;
                        int TongSoVeVIPConLai = int.Parse(tblChuyenXe.Rows[0]["VeVIPConLai"].ToString()) - NumOfVip;
                        Hashtable tbUpdateCX = new Hashtable();
                        tbUpdateCX.Add("VeThuongConLai", TongSoVeThuongConLai.ToString());
                        tbUpdateCX.Add("VeVipConLai", TongSoVeVIPConLai.ToString());
                        bool _updateCX = UpdateData.Update("ChuyenXe", tbUpdateCX, "MaChuyenXe=" + MaChuyenXe);
                        #endregion
                        #region Update Order
                        Hashtable tbOrder = new Hashtable();
                        tbOrder.Add("Order_Status", "3");
                        bool _updateOrder = UpdateData.Update("tbl_Order", tbOrder, "Order_Id=" + dtOrder.Rows[0]["Order_Id"]);
                        #endregion
                        if (_updateCX && _updateOrder)
                        {
                            #region Insert into Order_detail
                            bool insertOrderDetail = false;
                            for (int i = 0; i < NumOfVip; i++)
                            {
                                Hashtable tbOrderDetail = new Hashtable();

                                tbOrderDetail.Add("Order_ID", dtOrder.Rows[0]["Order_ID"].ToString());
                                string orderid = int.Parse(dtOrder.Rows[0]["Order_ID"].ToString()) < 10 ? "0" + dtOrder.Rows[0]["Order_ID"].ToString() : dtOrder.Rows[0]["Order_ID"].ToString();
                                string machuyenxe = MaChuyenXe < 10 ? "0" + MaChuyenXe : MaChuyenXe.ToString();
                                string account = int.Parse(dtOrder.Rows[0]["Order_Account"].ToString()) < 10 ? "0" + dtOrder.Rows[0]["Order_Account"].ToString() : dtOrder.Rows[0]["Order_Account"].ToString();
                                tbOrderDetail.Add("MaVe", "V" + orderid + machuyenxe + account + (i + 1));
                                tbOrderDetail.Add("Type", "V");
                                tbOrderDetail.Add("UnitPrice", tblChuyenXe.Rows[0]["GiaVIP"].ToString());
                                insertOrderDetail = UpdateData.Insert("tbl_OrderDetail", tbOrderDetail);
                            }
                            for (int i = 0; i < NumOfThuong; i++)
                            {
                                Hashtable tbOrderDetail = new Hashtable();

                                tbOrderDetail.Add("Order_ID", dtOrder.Rows[0]["Order_ID"].ToString());
                                string orderid = int.Parse(dtOrder.Rows[0]["Order_ID"].ToString()) < 10 ? "0" + dtOrder.Rows[0]["Order_ID"].ToString() : dtOrder.Rows[0]["Order_ID"].ToString();
                                string machuyenxe = MaChuyenXe < 10 ? "0" + MaChuyenXe : MaChuyenXe.ToString();
                                string account = int.Parse(dtOrder.Rows[0]["Order_Account"].ToString()) < 10 ? "0" + dtOrder.Rows[0]["Order_Account"].ToString() : dtOrder.Rows[0]["Order_Account"].ToString();
                                tbOrderDetail.Add("MaVe", "TH" + orderid + machuyenxe + account + (i + 1));
                                tbOrderDetail.Add("Type", "TH");
                                tbOrderDetail.Add("UnitPrice", tblChuyenXe.Rows[0]["GiaThuong"].ToString());
                                insertOrderDetail = UpdateData.Insert("tbl_OrderDetail", tbOrderDetail);
                            }
                            if (insertOrderDetail)
                            {
                                #region Send Mail
                                string checkDetail = "SELECT * FROM tbl_OrderDetail WHERE Order_ID=" + dtOrder.Rows[0]["Order_ID"].ToString();
                                string sum = "SELECT Sum(UnitPrice) as TongTien FROM tbl_OrderDetail WHERE Order_ID=" + dtOrder.Rows[0]["Order_ID"].ToString();
                                DataRowCollection rowsDetail = UpdateData.UpdateBySql(checkDetail).Tables[0].Rows;
                                double TongTien = double.Parse(UpdateData.UpdateBySql(sum).Tables[0].Rows[0]["TongTien"].ToString());
                                //send mail
                                string strBody = "<html><body>\n";
                                strBody += "<h2>Chúc mừng bạn đã đặt vé thành công tại " + CMSfunc._GetConst("_Domain") + "</h2><br>\n";
                                strBody += "Thông tin vé xe: <br>\n";
                                strBody += "<table style='height: 34px; border-color: #0b6604; background-color: #167003; margin-left: auto; margin-right: auto;' border='1' width='784' cellspacing='0' cellpadding='0'><caption>&nbsp;</caption>";
                                strBody += "<tbody>";
                                strBody += "<tr style='height: 30px;'>";
                                strBody += "<td style='width: 780px; height: 30px;'><strong><span style='color: #ffcc00;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TH&Ocirc;NG TIN ĐẶT V&Eacute;</span></strong></td>";
                                strBody += "</tr>";
                                strBody += "</tbody>";
                                strBody += "</table>";
                                strBody += "<table style='height: 209px; margin-left: auto; margin-right: auto; width: 776px;' border='1' cellspacing='0' cellpadding='0'>";
                                strBody += "<tbody>";
                                strBody += "<tr style='height: 22px;'>";
                                strBody += "<td style='width: 772px; height: 22px;' colspan='3'><strong>1. Th&ocirc;ng tin v&eacute;</strong></td>";
                                strBody += "</tr>";
                                strBody += "<tr style='height: 15px;'>";
                                strBody += "<td style='width: 86px; height: 15px;text-align: center'><strong>M&atilde; V&eacute;</strong></td>";
                                strBody += "<td style='width: 347px; height: 15px;text-align: center'><strong>Loại&nbsp;v&eacute;</strong></td>";
                                strBody += "<td style='width: 335px; height: 15px;text-align: center'><strong>Gi&aacute; v&eacute;</strong></td>";
                                strBody += "</tr>";
                                foreach (DataRow item in rowsDetail)
                                {
                                    strBody += "<tr style='height: 15px;'>";
                                    strBody += "<td style='width: 86px; height: 15px;text-align: center'>" + item["MaVe"] + "</td>";
                                    strBody += "<td style='width: 347px; height: 15px;text-align: center'>" + item["Type"] + "</td>";
                                    strBody += "<td style='width: 335px; height: 15px;text-align: center'>" + item["UnitPrice"] + "</td>";
                                    strBody += "</tr>";
                                }
                                strBody += "<tr style='height: 15px;'>";
                                strBody += "<td style='width: 86px; height: 15px;'>Tổng tiền</td>";
                                strBody += "<td colspan=2 style='width: 347px; height: 15px; color: red; text-align:center'>" + TongTien + "</td>";
                                strBody += "</tr>";
                                strBody += "</tbody>";
                                strBody += "</table>";
                                strBody += "<span style='text-align: right'>Cảm ơn quý khách đã đặt vé tại " + CMSfunc._GetConst("_Domain") + "! </span>\n";
                                strBody += "</body></html>";

                                string fromEmail = HttpContext.Current.Session["Member_Email"].ToString().Trim();
                                string toEmail = HttpContext.Current.Session["Member_Email"].ToString();
                                string Name = HttpContext.Current.Session["Member_Name"].ToString().Trim();

                                string Subject = "THÔNG TIN ĐẶT VÉ XE ĐIỆN TỬ TẠI " + CMSfunc._GetConst("_Domain");
                                string Host = CMSfunc._GetConst("_Hostmail");
                                string EmailClient = CMSfunc._GetConst("_EmailClient");
                                string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                                int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                                try
                                {
                                    bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                                    if (_isSend)
                                    {
                                        res.data = true;
                                        res.message = string.Format(ErrorMessage.Success, "Hoàn tất đặt vé");
                                        res.errcode = ErrorCode.SUCCESS;
                                    }
                                    else
                                    {
                                        res.data = false;
                                        res.message = string.Format(ErrorMessage.Fail, "Đặt vé");
                                        res.errcode = ErrorCode.FAIL;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    res.data = false;
                                    res.message = ex.Message;
                                    res.errcode = ErrorCode.FAIL;
                                }
                                #endregion
                                res.data = true;
                                res.errcode = ErrorCode.SUCCESS;
                                res.message = string.Format(ErrorMessage.Success, "Xác thực đặt vé ");
                            }
                            else
                            {
                                res.data = false;
                                res.errcode = ErrorCode.FAIL;
                                res.message = string.Format(ErrorMessage.Fail, "Xác thực đặt vé ");
                            }
                            #endregion
                        }
                        else
                        {
                            res.data = false;
                            res.errcode = ErrorCode.FAIL;
                            res.message = string.Format(ErrorMessage.Fail, "Xác thực đặt vé ");
                        }
                    }
                    else
                    {
                        res.data = false;
                        res.errcode = ErrorCode.NODATA;
                        res.message = string.Format(ErrorMessage.NotFound, "Chuyến xe");
                    }
                    #endregion
                }
                else
                {
                    #region Check Status Of Order 0 OR 2
                    if (dtOrder.Rows[0]["Order_Status"].ToString() == "2")
                    {
                        #region Send Mail
                        string checkDetail = "SELECT * FROM tbl_OrderDetail WHERE Order_ID=" + dtOrder.Rows[0]["Order_ID"].ToString();
                        string sum = "SELECT Sum(UnitPrice) as TongTien FROM tbl_OrderDetail WHERE Order_ID=" + dtOrder.Rows[0]["Order_ID"].ToString();
                        DataRowCollection rowsDetail = UpdateData.UpdateBySql(checkDetail).Tables[0].Rows;
                        double TongTien = double.Parse(UpdateData.UpdateBySql(sum).Tables[0].Rows[0]["TongTien"].ToString());
                        //send mail
                        string strBody = "<html><body>\n";
                        strBody += "<h2>Chúc mừng bạn đã đặt vé thành công tại " + CMSfunc._GetConst("_Domain") + "</h1><br>\n";
                        strBody += "Thông tin vé xe: <br>\n";
                        strBody += "<table style='height: 34px; border-color: #0b6604; background-color: #167003; margin-left: auto; margin-right: auto;' border='1' width='784' cellspacing='0' cellpadding='0'><caption>&nbsp;</caption>";
                        strBody += "<tbody>";
                        strBody += "<tr style='height: 30px;'>";
                        strBody += "<td style='width: 780px; height: 30px;'><strong><span style='color: #ffcc00;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TH&Ocirc;NG TIN ĐẶT V&Eacute;</span></strong></td>";
                        strBody += "</tr>";
                        strBody += "</tbody>";
                        strBody += "</table>";
                        strBody += "<table style='height: 209px; margin-left: auto; margin-right: auto; width: 776px;' border='1' cellspacing='0' cellpadding='0'>";
                        strBody += "<tbody>";
                        strBody += "<tr style='height: 22px;'>";
                        strBody += "<td style='width: 772px; height: 22px;' colspan='3'><strong>1. Th&ocirc;ng tin v&eacute;</strong></td>";
                        strBody += "</tr>";
                        strBody += "<tr style='height: 15px;'>";
                        strBody += "<td style='width: 86px; height: 15px;'><strong>M&atilde; V&eacute;</strong></td>";
                        strBody += "<td style='width: 347px; height: 15px;'><strong>Loại&nbsp;v&eacute;</strong></td>";
                        strBody += "<td style='width: 335px; height: 15px;'><strong>Gi&aacute; v&eacute;</strong></td>";
                        strBody += "</tr>";
                        foreach (DataRow item in rowsDetail)
                        {
                            strBody += "<tr style='height: 15px;'>";
                            strBody += "<td style='width: 86px; height: 15px;'>" + item["MaVe"] + "</td>";
                            strBody += "<td style='width: 347px; height: 15px;'>" + item["Type"] + "</td>";
                            strBody += "<td style='width: 335px; height: 15px;'>" + item["UnitPrice"] + "</td>";
                            strBody += "</tr>";
                        }
                        strBody += "<tr style='height: 15px;'>";
                        strBody += "<td style='width: 86px; height: 15px;'>Tổng tiền</td>";
                        strBody += "<td colspan=2 style='width: 347px; height: 15px; color: red; text-align=center'>" + TongTien + "</td>";
                        strBody += "</tr>";
                        strBody += "</tbody>";
                        strBody += "</table>";
                        strBody += "<span style='text-align: right'>Cảm ơn quý khách đã đặt vé tại " + CMSfunc._GetConst("_Domain") + "! </span>\n";
                        strBody += "</body></html>";

                        string fromEmail = HttpContext.Current.Session["Member_Email"].ToString().Trim();
                        string toEmail = HttpContext.Current.Session["Member_Email"].ToString();
                        string Name = HttpContext.Current.Session["Member_Name"].ToString().Trim();

                        string Subject = "THÔNG TIN ĐẶT VÉ XE ĐIỆN TỬ TẠI " + CMSfunc._GetConst("_Domain");
                        string Host = CMSfunc._GetConst("_Hostmail");
                        string EmailClient = CMSfunc._GetConst("_EmailClient");
                        string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                        int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                        try
                        {
                            bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                            if (_isSend)
                            {
                                res.data = true;
                                res.message = string.Format(ErrorMessage.Success, "Hoàn tất đặt vé");
                                res.errcode = ErrorCode.SUCCESS;
                            }
                            else
                            {
                                res.data = false;
                                res.message = string.Format(ErrorMessage.Fail, "Đặt vé");
                                res.errcode = ErrorCode.FAIL;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.data = false;
                            res.message = ex.Message;
                            res.errcode = ErrorCode.FAIL;
                        }
                        #endregion
                    }
                    if (dtOrder.Rows[0]["Order_Status"].ToString() == "0")
                    {
                        res.data = false;
                        res.errcode = ErrorCode.TURNDATA;
                        res.message = ErrorMessage.NoVertification;
                    }
                    #endregion
                }

            }
            else
            {
                res.data = false;
                res.errcode = ErrorCode.TURNDATA;
                res.message = ErrorMessage.NoTransaction;
            }
            #endregion
        }
        else
        {
            #region Trường hợp chưa đăng nhập
            res.data = false;
            res.errcode = ErrorCode.UNAUTHORIZED;
            res.message = ErrorMessage.Unauthorized;
            #endregion
        }
        return res;
    }
    [WebMethod]
    public static string GetSessionMave()
    {
        return SessionUtil.GetValue("OrderID").ToString();
    }
    [WebMethod]
    public static string CheckTicket(string mave, string sdt)
    {
        string sql = "";
        if (!string.IsNullOrEmpty(mave))
        {
            sql = "select * from tbl_OrderDetail a, tbl_Order b, ChuyenXe c , Xe d, NhaXe e where c.Maxe=d.MaXe and e.ID=d.Nhaxe  and a.Order_ID=b.Order_ID and b.MaChuyenXe=c.MaChuyenXe and a.MaVe='" + Value._Replate(mave) + "'";
        }
        else
        {
            if (!string.IsNullOrEmpty(sdt))
            {
                sql = "select * from tbl_OrderDetail a, tbl_Member m, tbl_Order b, ChuyenXe c , Xe d, NhaXe e where m.Member_ID=b.Order_Account and c.Maxe=d.MaXe and e.ID=d.Nhaxe  and a.Order_ID=b.Order_ID and b.MaChuyenXe=c.MaChuyenXe and m.Member_Phone='" + Value._Replate(sdt) + "'";
            }
        }
        DataTable res = UpdateData.UpdateBySql(sql).Tables[0];

        return Newtonsoft.Json.JsonConvert.SerializeObject(res); ;
    }
    [WebMethod]
    public static Result<tbl_PromoteCode> CheckPromote(string makhuyenmai, double Tongtien)
    {
        Result<tbl_PromoteCode> res = new Result<tbl_PromoteCode>();
        tbl_PromoteCode pro = new PromoteRepository().SearchFor(o => o.Code == makhuyenmai).SingleOrDefault();
        if (pro != null)
        {
            if(Tongtien > pro.FromValue && Tongtien < pro.ToValue)
            {
                res.data = pro;
                res.errcode = ErrorCode.SUCCESS;
                res.message = string.Format(ErrorMessage.CanApply, "Mã này");
            }
            else
            {
                res.data = null;
                res.errcode = ErrorCode.NOT_EQUAL;
                res.message = string.Format(ErrorMessage.OutOfBound, "Giá trị của mã", "khuyến mãi");
            }
        }
        else
        {
            res.data = null;
            res.errcode = ErrorCode.NODATA;
            res.message = string.Format(ErrorMessage.NotFound, "Mã khuyến mãi");
        }
        return res;
    }
    [WebMethod]
    public static Result<bool> SaveYc(string from, string to, string startdate, string starttime, string more, string sdt)
    {
        Result<bool> res= new Result<bool>();
        Hashtable tbRequest = new Hashtable();
        tbRequest.Add("[From]", from);
        tbRequest.Add("[To]", to);
        tbRequest.Add("StartDate", startdate);
        tbRequest.Add("starttime", starttime);
        tbRequest.Add("more", more);
        tbRequest.Add("sdt", sdt);
        tbRequest.Add("isCancel", "0");
        tbRequest.Add("CreateDate", DateTime.Now.ToString());
        tbRequest.Add("Createby", SessionUtil.GetValue("MemberID"));
        bool _insert = UpdateData.Insert("RequestTravel", tbRequest);
        if (_insert)
        {
            res.data = true;
            res.errcode = ErrorCode.SUCCESS;
            res.message = "Yêu cầu của quý khách đã được lưu lại, vui lòng đợi phía nhà xe liên hệ lại.";
        }
        else
        {
            res.data = true;
            res.errcode = ErrorCode.SUCCESS;
            res.message = "Xin lỗi, có lỗi trong quá trình thực hiện. Quý khách vui lòng tải lại trang và thực hiện lại";
        }
        return res;
    }
    [WebMethod]
    public static Result<bool> HuyYC()
    {
        Result<bool> res = new Result<bool>();
        string MemID = HttpContext.Current.Session["MemberID"].ToString();
        Hashtable tbIn = new Hashtable();
        tbIn.Add("isCancel", "1");
        bool b = UpdateData.Update("RequestTravel", tbIn, "");
        if (b)
        {
            res.data = true;
            res.errcode = ErrorCode.SUCCESS;
            res.message = "Hủy yêu cầu thành công";
        }
        else
        {
            res.data = false;
            res.errcode = ErrorCode.FAIL;
            res.message = "Hủy yêu không thành công, xin thử lại.";
        }
        return res;
    }
}

