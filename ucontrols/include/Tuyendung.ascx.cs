using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Tuyendung : System.Web.UI.UserControl
{
    protected int p, lv2, lv3;
    protected string url, nUrl, tUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(url);
        nUrl = String.IsNullOrEmpty(Request.QueryString["nUrl"]) ? "" : Request["nUrl"].ToString();
        lv2 = ModControl.GetP_From_Code(nUrl);
        tUrl = String.IsNullOrEmpty(Request.QueryString["tUrl"]) ? "" : Request["tUrl"].ToString();
        ltrSidebar.Text = LoadSidebar(p);
        ltrEmail.Text = LoadEmail();
        ltrHotline.Text = LoadHotline();
        //btnApply.Text = Value.GetValue(Session["vlang"].ToString(), "btnSend");
        txtAddress.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phAddress"));
        txtName.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phName"));
        txtBirthYear.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phBirthday"));
        txtCurrentAddress.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phCurrentAddress"));
        txtPhone.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phPhone"));
        txtPos.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "lbPos"));
        txtEmail.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phEmail"));
        txtCapcha.Attributes.Add("placeholder", Value.GetValue(Session["vlang"].ToString(), "phCatpcha"));
        //btnApply.Text = Value.GetValue(Session["vlang"].ToString(), "lbApply");
        if (nUrl != "")
        {
            ltrContent.Text = LoadTDDetail();
            lbNavigation.Text = "<a href=\"/\"><i class=\"fa fa-home fa-2x\"></i></a> >> <a href=\"/" + url + ".htm \">" + ModControl.GetName_From_Code(url) + "</a> >> " + ContentControl.GetFieldByCode("Name", nUrl);
        }
        else
        {
            ltrContent.Text = LoadContent();
            lbNavigation.Text = "<a href =\"/\"><i class=\"fa fa-home fa-2x\"></i></a> >> " + ModControl.GetName_From_Code(url);
        }

    }
    protected string LoadContent()
    {
        int parent = ModControl.GetParent(p) != 0 ? ModControl.GetParent(p) : p;
        string sql = "select * from tbl_Content where lang=" + Session["vlang"];
        sql += " and Mod_ID=" + p;
        if (ModControl.GetParent(p) == 0)
        {
            sql += " OR Mod_ID in (SELECT Mod_ID FROM tbl_Mod WHERE Mod_Parent=" + p + ")";
        }
        sql += " Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<div class=\"td-item\">");
                str.Append("<div class=\"row\">");
                str.Append("<div class=\"td-item-left\">");
                str.Append("    <div class=\"col-sm-3 td-item-img\">");
                str.Append("        <img  class=\"img-responsive\" src=\"" + rows[i]["Content_img"] + "\">");
                str.Append("    </div>");
                str.Append("</div>");
                str.Append("<div class=\"td-item-right col-sm-9\">");
                str.Append("    <div class=\"td-content\">");
                str.Append("        <a href=\"/" + ModControl.GetModCode(p) + "/" + rows[i]["Content_Code"] + ".htm\"><h3>" + rows[i]["Content_Title"] + "</h3></a>");
                str.Append("        <span> Ngày đăng: " + rows[i]["Content_Date"] + "</span>");
                str.Append("        <div style=\"border-top: 1px solid #ccc; padding: 5px 0;\"></div>");
                string quote = rows[i]["Content_Intro"].ToString().Length > 500 ? rows[i]["Content_Intro"].ToString().Substring(0, 500) : rows[i]["Content_Intro"].ToString();
                str.Append("        <p>" + quote + "...</p>");
                str.Append("    </div>");
                str.Append("</div>");
                str.Append("</div>");
                str.Append("</div>");
            }

        }
        return str.ToString();
    }
    protected string LoadTDDetail()
    {
        string sql = "select * from tbl_Content where lang=" + Session["vlang"] + " And Content_Code = '" + nUrl + "' Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<div class=\"Content_Detail w100 fl\">");
                str.Append("        <h2 style=\"font-weight:bold\">" + rows[i]["Content_Title"].ToString().ToUpper() + "</h2>");
                str.Append("            <div class=\"date-author w100 fl\">");
                str.Append("            <span class=\"caption-date\"><i class=\"fa fa-calendar\"></i>&nbsp;Ngày đăng:" + rows[i]["Content_Date"] + "</span></div>");
                str.Append("        <div class=\"description\"><p>" + rows[i]["Content_Text"] + "</p></div>");
                str.Append("</div>");
                str.Append("<div class=\"td-bot\">");
                str.Append("    <h3 class=\"pull-right\"><button type =\"button\" class=\"btn btn-info btn-lg\" data-toggle=\"modal\" data-target=\"#myModal\">"+Value.GetValue(Session["vlang"].ToString(), "lbApply") + "</button></h3>");
                str.Append("</div>");
            }
        }
        return str.ToString();
    }
    public string LoadHotline()
    {
        string sql = "select * from tbl_Other where Other_ID=32 and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append(rows[0]["Other_Content"]);
        }
        return str.ToString();
    }
    public string LoadEmail()
    {
        string sql = "select * from tbl_Other where Other_ID=33 and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append(rows[0]["Other_Content"]);
        }
        return str.ToString();
    }
    protected string LoadSidebar(int p)
    {
        int parent = ModControl.GetParent(p) != 0 ? ModControl.GetParent(p) : p;
        string sql = "SELECT * FROM tbl_Mod WHERE lang=" + Session["vlang"] + "AND Mod_Parent=" + parent + " AND Mod_Status='true' ORDER BY Mod_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        str.Append("<ul>");
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<li>");
                str.Append("    <a href=\"/" + ModControl.GetModCode(int.Parse(rows[i]["Mod_ID"].ToString())) + ".htm\">" + rows[i]["Mod_Name"] + "</a>");
                str.Append("</li>");
            }

        }
        str.Append("</ul>");
        return str.ToString();
    }
  
    public bool Validate()
    {
        bool b = true;
        string Name = txtName.Text;
        string Email = txtEmail.Text;
        string Phone = txtPhone.Text;
        string Address = txtAddress.Text;
        string Capcha = txtCapcha.Text;
        string BirthDay = txtBirthYear.Text;
        string CurAddress = txtCurrentAddress.Text;
        if (Name == null || Email == null || Phone == null || Address == null || Capcha == null)
        {
            b = false;
            Response.Write("<script>alert(\"Mời bạn nhập đủ thông tin.\");document.getElementByID(\"login-box\").style.Display=\"block\";</script>");
        }
        else
        {
            if (Capcha != Session["Captcha"].ToString())
            {
                txtCapcha.Attributes.Add("PlaceHolder", "Mã xác nhận không đúng!");
                txtCapcha.ForeColor = System.Drawing.Color.Red;
                txtCapcha.BorderColor = System.Drawing.Color.Red;
                b = false;
            }
        }
        return b;
    }
}