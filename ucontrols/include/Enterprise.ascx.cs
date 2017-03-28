using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_Enterprise : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p, op;
    protected string cid, url, nUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        url = string.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        nUrl = string.IsNullOrEmpty(Request["nUrl"]) ? "" : Request["nUrl"].ToString();
        p = ModControl.GetP_From_Code(url);
        CMSfunc.checkURL();
        op = ModControl.GetOldP(p);
        ltrSidebar.Text = LoadSidebar(p);
        if (nUrl != "")
        {
            ltrContent.Text = LoadNLSX(p);
            lbNavigation.Text = "<a href=\"/\"><i class=\"fa fa-home fa-2x\"></i></a> >> <a href=\"/" + url + ".htm \">" + ModControl.GetName_From_Code(url) + "</a> >> " +ContentControl.GetFieldByCode("Name", nUrl);
        }
        else
        {
            ltrEnterprise.Text= LoadEnterprise(p);
            lbNavigation.Text = "<a href =\"/\"><i class=\"fa fa-home fa-2x\"></i></a> >> <a href=\"/" + url + ".htm \">"+ModControl.GetName_From_Code(url);
        }

    }
    protected string LoadNLSX(int p)
    {
        string sql = "select * from tbl_Content where lang =" + Session["vlang"] + "And Content_Code ='" + nUrl + "' Order by Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<div class=\"Content_Detail w100 fl\">");
                str.Append("            <div class=\"date-author w100 fl\">");
                str.Append("        <h2 style=\"font-weight:bold\">" + rows[i]["Content_Title"] + "</h2>");
                str.Append("            <span class=\"caption-date\"><i class=\"fa fa-calendar\"></i>&nbsp;Ngày đăng:" + rows[i]["Content_Date"] + "</span></div>");
                str.Append("        <div class=\"description\">" + rows[i]["Content_Text"] + "</div>");
                str.Append("</div>");
            }
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
                str.Append("<li style=\"padding:5px;\">");
                str.Append("    <a href=\"/" + ModControl.GetModCode(int.Parse(rows[i]["Mod_ID"].ToString())) + ".htm\"><i class=\"fa fa-angle-double-right\"></i>&nbsp;&nbsp;" + rows[i]["Mod_Name"] + "</a>");
                str.Append("</li>");
            }

        }
        str.Append("</ul>");
        return str.ToString();
    }
    protected string LoadEnterprise(int p)
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
            int currentPage = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int totalpage = (int)rows.Count / 5 + 1;
            int startrow = totalpage < 1 ? 0 : ((currentPage - 1) * 5);
            int endrow = 0;
            if (currentPage == totalpage)
            {
                endrow = rows.Count;
            }
            else
            {
                endrow = totalpage < 1 ? rows.Count : startrow + 5;
            }
            for (int i = startrow; i < endrow; i++)
            {
                str.Append("    <div class=\"w100 item fl\">");
                str.Append("        <div class=\"row\">");
                str.Append("            <div class=\"image content-left-dst tin-tucnews\">");
                str.Append("                <a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\"><img  class=\"img-responsive\" src=" + rows[i]["Content_img"] + "></a>");
                str.Append("            </div>");
                str.Append("        <div class=\"content-right-dst\">");
                str.Append("            <div class=\"date-author w100 fl\">");
                string name = rows[i]["Content_Name"].ToString().Length > 70 ? rows[i]["Content_Name"].ToString().Substring(0, 70) + "..." : rows[i]["Content_Name"].ToString();
                str.Append("        <div class=\"title\">");
                str.Append("        <h2><a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\">" + name + "</a></h2>");
                str.Append("            <span><i class=\"fa fa-calendar\"></i>&nbsp;Ngày đăng:" + rows[i]["Content_Date"] + "</span></div>");
                str.Append("        <div>");
                string quote = rows[i]["Content_Intro"].ToString().Length > 200 ? rows[i]["Content_Intro"].ToString().Substring(0, 200) : rows[i]["Content_Intro"].ToString();
                str.Append("        <div class=\"description\">" + quote + "...</div>");
                str.Append("            <div>");
                str.Append("        </div>");
                str.Append("</div></div></div></div></div>");
            }
            phantrang pages = new phantrang();
            if (rows.Count > 5)
            {
                str.Append("<span class=\"pull-right\">" + pages.pagelink((int)rows.Count / 5 + 1, currentPage, "?") + "</span>");
            }
        }
        return str.ToString();
    }
}
