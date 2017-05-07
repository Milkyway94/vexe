using System;
using System.Data;
using System.Web;
using System.Text;
using SMAC;
using System.Linq;
public partial class ucontrols_include_News : System.Web.UI.UserControl
{
    protected int p;
    protected static string m;
    protected int pageSize = 5;
    public string display = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = string.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        m = Request["nUrl"] != null ? Request["nUrl"].ToString() : "";
        p = ModControl.GetP_From_Code(u);
        ltrSidebar.Text = LoadSidebar(m);
        //ltrNews.Text = LoadListNews(m);
        ltrHotNew.Text = LoadListNews(m);
        ltrtdn.Text = LoadTdn();
        if (m != "")
        {
            ltrCss.Text = "<style>.lst-tdn{display:none}</style>";
            ltrContent.Text = LoadNewsDetail();
            ltrListRelated.Text = LoadListRelated();
            lbNavigation.Text = "<a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a> " + "<a href=\"/" + u + ".htm \">" + ModControl.GetName_From_Code(u) + "</a>";
        }
        else
        {
            ltrContent.Text = LoadContentNews(p);
            lbNavigation.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(u) + "</li>";
        };
    }
    protected string LoadTdn()
    {
        string sql = "SELECT TOP (1) * from tbl_Content WHERE  lang=" + Session["vlang"] + " and Mod_ID=" + p + " and Content_hot=1 Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("<div class=\"uk-child-width-1-2@m\" uk-grid>");
            str.Append("<div class=\"uk-inline hi-grid\">");
            str.Append("<img src=\"" + rows[0]["Content_img"] + "\" alt=\"" + rows[0]["Content_name"] + "\">");
            str.Append("<div class=\"uk-overlay uk-overlay-default uk-position-bottom\">");
            //str.Append("<h5>" + rows[0]["Content_name"] + "</h5>");
            str.Append("<a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[0]["Content_ID"].ToString())) + ".htm\"><h5>" + rows[0]["Content_Name"] + "</h5></a>");
            str.Append("</div></div></div>");
        }

        return str.ToString();
    }
    protected string LoadContentNews(int p)
    {
        string sql = "select * from tbl_Content where lang=" + Session["vlang"] + "and Mod_ID=" + p + "Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            int currentPage = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int totalpage = (int)rows.Count / pageSize + 1;
            int startrow = totalpage < 1 ? 0 : ((currentPage - 1) * pageSize);
            int endrow = 0;
            if (currentPage == totalpage)
            {
                endrow = rows.Count;
            }
            else
            {
                endrow = totalpage < 1 ? rows.Count : startrow + pageSize;
            }
            for (int i = startrow; i < endrow; i++)
            {
                string quote = rows[i]["Content_Intro"].ToString().Length > 200 ? rows[i]["Content_Intro"].ToString().Substring(0, 200) : rows[i]["Content_Intro"].ToString();
                string title = rows[i]["Content_name"].ToString();
                string datetime = rows[i]["Content_Date"].ToString();
                if (!string.IsNullOrEmpty(datetime))
                {
                    datetime = DateTime.Parse(datetime).ToString("dd/MM/yyyy");
                }
                str.Append("<div class=\"item_article\">");
                str.Append("<div class=\"article_content\">");
                str.Append("<div class=\"article_image\">");
                str.Append("<a href=\"" + quote + "\">");
                str.Append("<img class=\"img-responsive\" border=\"0\" src=\"" + rows[i]["Content_img"] + "\" alt=\"" + title + "\"></a></div>");
                str.Append("<div class=\"article_info\">");
                str.Append("<h3 class=\"title\"><a href = \"" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\">" + title + "</a></h3>");
                str.Append("<span><p>" + quote + "</p></span>");
                str.Append("<span class=\"datenewsl\"><i class=\"fa fa-calendar\"></i>&nbsp;" + datetime + "</span>");
                str.Append("</div></div></div>");
            }
            phantrang pages = new phantrang();
            if (rows.Count > pageSize)
            {
                str.Append("<span class=\"pull-right\">" + pages.pagelink((int)rows.Count / 5 + 1, currentPage, "?") + "</span>");
            }
        }
        else
        {
            display = "displaynone";
            return "<b class='text-danger'>Không có tin nào được đăng trong mục này.</b>";
        }
        return str.ToString();
    }
    protected string LoadSidebar(string pid)
    {
        string sql = "select * from tbl_Content where lang=" + Session["vlang"] + "and Mod_ID=" + p + "and Content_hot=1 Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i]["Content_Code"].ToString() == pid)
                {
                    str.Append("<li style=\"line-height:25px;\">");
                    str.Append("    <a class=\"active\" href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\"><i class=\"fa fa-angle-double-right\"></i>&nbsp;&nbsp;" + rows[i]["Content_Name"] + "</a>");
                    str.Append("</li>");
                }
                else
                {
                    str.Append("<li style=\"line-height:25px;\">");
                    str.Append("    <a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\"><i class=\"fa fa-angle-double-right\"></i>&nbsp;&nbsp;" + rows[i]["Content_Name"] + "</a>");
                    str.Append("</li>");
                }

            }
        }
        return str.ToString();
    }
    protected string LoadListNews(string pid)
    {
        string sql = "select TOP (5) * from tbl_Content where lang=" + Session["vlang"] + "and Mod_ID=" + p + "Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
            if (rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (rows[i]["Content_Code"].ToString() == pid)
                    {
                        str.Append("<li><a class=\"active\" href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\">" + rows[i]["Content_Name"].ToString() + "</a></li>");

                    }
                    else
                    {
                        str.Append("<li><a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows[i]["Content_ID"].ToString())) + ".htm\">" + rows[i]["Content_Name"] + "</a></li>");
                    }
                }

            }
        return str.ToString();
    }
    protected string LoadNewsDetail()
    {
        string sql = "select * from tbl_Content where lang=" + Session["vlang"] + " And Content_Code = '" + m + "'";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("<div class=\"Content_Detail w100 fl\">");
            str.Append("            <div class=\"date-author w100 fl\">");
            str.Append("            <h3>" + rows[0]["Content_Name"].ToString().ToUpperInvariant() + "</a></h3>");
            str.Append("            <span class=\"caption-date\"><i class=\"fa fa-calendar\"></i>&nbsp;Ngày đăng:" + rows[0]["Content_Date"] + "</span></div>");
            str.Append("        <div class=\"description img-responsive\">" + rows[0]["Content_Text"] + "</div>");
            str.Append("</div>");
        }
        return str.ToString();
    }
    protected string LoadTitleNews(int p)
    {
        //p = int.Parse(Request["Content_ID"]);
        string sql = "select * from tbl_Content where lang=" + Session["vlang"] + " And Content_ID = " + p + "Order By Content_Date DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        string str = "";
        if (rows.Count > 0)
        {
            str += "" + rows[0]["Content_Title"] + "";
        }
        return str;
    }
    protected string LoadListRelated()
    {
        string sql1 = ""; 
        sql1 = "select top 5 * from tbl_Content where lang=" + Session["vlang"] + "and Mod_ID=" + p + "Order By Content_Date DESC";
        DataSet ds1 = UpdateData.UpdateBySql(sql1);
        DataRowCollection rows1 = ds1.Tables[0].Rows;
        StringBuilder str1 = new StringBuilder();
        if (rows1.Count > 0)
        {
            //str1.Append("<div class=\"w100\"><div class=\"product-ref fl\"><div class=\"m-splq\"><div class=\"splq\"><span>Tin liên quan</span> ");
            //str1.Append("</div></div></div></div>");
            for (int i = 0; i < rows1.Count; i++)
            {
                if (int.Parse(rows1[i]["Content_ID"].ToString()) == p)
                {
                    str1.Append("<li style=\"line-height:25px;\">");
                    str1.Append("    <a class=\"active\" href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows1[i]["Content_ID"].ToString())) + ".htm\"><i class=\"fa fa-angle-double-right\"></i>" + rows1[i]["Content_Name"] + "</a>");
                    str1.Append("</li>");
                }
                else
                {
                    str1.Append("<li>");
                    str1.Append("<a href=\"/" + ModControl.GetModCode(p) + "/" + ContentControl.GetContentField("Code", int.Parse(rows1[i]["Content_ID"].ToString())) + ".htm\">" + rows1[i]["Content_Name"] + "</a>&nbsp;<span class=\"ApproveDate\">(" + rows1[i]["Content_Date"] + ")</span>");
                    str1.Append("</li>");
                }
            }
        }

        return str1.ToString();
    }
}