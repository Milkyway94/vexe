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
using System.Text;
using SMAC;
public partial class ucontrols_Video : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p;
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSfunc.checkURL();
        string url = Request.QueryString["url"];
        string nUrl = Request.QueryString["nUrl"];
        p = ModControl.GetP_From_Code(url);
        int op = p;
        if (ModControl.GetLevel(p) == 2) op = ModControl.GetOldP(p);
        if (ModControl.GetLevel(p) == 3) op = ModControl.GetOldP(ModControl.GetOldP(p));
        //Detail.Visible = false;
        //if (nUrl != null)
        //{
        //    List.Visible = false;
        //    Detail.Visible = true;
        //    int id = ModControl.GetID_From_Url(p, nUrl);
        //    ltrContent.Text = LoadDetail(id, op);
        //}
        //else
        //{
        ltrSubmod.Text = LoadSubmod(op, url);
        ltrListContent.Text = LoadListContent(p);
        //}
    }
    protected string LoadSubmod(int p, string url)
    {
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + p + " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < rows.Count; i++)
        {
            str.Append("<li><a href=\"" + ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm") + "\">" + rows[i]["Mod_Name"] + "</a></li>");
            string sql1 = "SELECT Mod_ID,Mod_Name,Mod_Img,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + rows[i]["Mod_ID"] + " ORDER BY Mod_Pos";
            DataSet ds1 = UpdateData.UpdateBySql(sql1);
            DataRowCollection rows1 = ds1.Tables[0].Rows;
            if (rows1.Count > 0)
            {
                str.Append("<ul class=\"direct-list\">");
                for (int j = 0; j < rows1.Count; j++)
                {
                    str.Append("<li class=\"sub\"><a href=\"" + ResolveUrl("~/" + rows1[j]["Mod_Code"] + ".htm") + "\"><i class=\"fa fa-angle-right\"></i> " + rows1[j]["Mod_Name"] + "</a></li>");
                }
                str.Append("</ul>");
            }
            str.Append("</li>");
        }
        return str.ToString();
    }
    protected string LoadListContent(int p)
    {
        string sql = "Select Content_Name,Content_Avata,Content_Img from tbl_Content where lang=" + Session["vlang"] + " AND Mod_ID=" + p + " AND Content_status=1";
        sql += " ORDER BY Content_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("<div class=\"custom-grid-row\">\n");
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<div class=\"col-1-2\">\n");
                str.Append("    <a href=\"" + uRoot + rows[i]["Content_Img"] + "\" class=\"zoom\">");
                str.Append("        <img src=\"" + uRoot + rows[i]["Content_Avata"] + "\" class=\"img-responsive wow zoomIn\" alt=\"" + rows[i]["Content_Name"] + "\">\n");
                str.Append("    </a>\n");
                str.Append("</div>\n");
                //if (i != 0 && i % 2 == 0) str.Append("</div><div class=\"custom-grid-row\">");
            }
            str.Append("</div>\n");
            //if (i != 0 && i % 2 == 0) str.Append("</div>");
        }
        return str.ToString();
    }
    protected string LoadDetail(int id, int op)
    {
        string sql = "Select Content_Name,Content_Img,Content_Intro,Content_Text,Content_Url,Content_Date from tbl_Content where lang=" + Session["vlang"] + " AND Content_ID=" + id + " AND Content_status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count>0)
        {
            str.Append("<div id=\"ajax-folio-item\" style=\"display: block;\">");
            str.Append("<div class=\"page-wrapper\">");
            str.Append("    <div class=\"page-side hidden-sm hidden-xs\">");
            str.Append("        <div class=\"inner-wrapper vcenter-wrapper\">");
            str.Append("            <div class=\"side-content vcenter\">");
            str.Append("                <h2 class=\"title\">" + rows[0]["Content_Name"] + "</h2>");
            //str.Append("                <div class=\"post-meta\">");
            //str.Append("                    <span class=\"date-span\">");
            //str.Append("                        <i class=\"fa fa-lg fa-clock-o\"></i>");
            //str.Append("                        <a href=\"#\">" + rows[0]["Content_Date"] + "</a>");
            //str.Append("                    </span>");
            //str.Append("                </div>");
            str.Append("                <p>" + rows[0]["Content_Intro"] + "</p>");
            str.Append("            </div>");
            str.Append("        </div>");
            str.Append("        <ul class=\"portfolio-nav\">");
            str.Append("            <li><a class=\"portfolio-prev\" href=\"javascript:history.back()\"><i class=\"fa fa-angle-left\"></i><span>Prev</span></a></li>");
            //.Append("            <li><a class=\"portfolio-close\" href=\"" + ResolveUrl("~/" + ModControl.GetModCode(op) + ".htm") + "\"><i class=\"fa fa-times\"></i><span>Close</span></a></li>");
            //str.Append("            <li><a class=\"portfolio-next\" href=\"" + ResolveUrl("~/" + ModControl.GetModCode(op) + ".htm") + "\"><i class=\"fa fa-angle-right\"></i><span>Next</span></a></li>");
            str.Append("        </ul>");
            str.Append("    </div>");
            str.Append("    <div class=\"page-main\">");
            str.Append("        <div class=\"inner-wrapper sync-width-parent\">");
            str.Append("            <div class=\"portfolio-md-detail visible-sm visible-xs\">");
            str.Append("                <ul class=\"portfolio-nav\">");
            str.Append("                    <li><a class=\"portfolio-prev\" href=\"javascript:history.back()\"><i class=\"fa fa-angle-left\"></i><span>Prev</span></a></li>");
            //str.Append("                    <li><a class=\"portfolio-close\" href=\"" + ResolveUrl("~/" + ModControl.GetModCode(op) + ".htm") + "\"><i class=\"fa fa-times\"></i><span>Close</span></a></li>");
            //str.Append("                    <li><a class=\"portfolio-next\" href=\"" + ResolveUrl("~/" + ModControl.GetModCode(op) + ".htm") + "\"><i class=\"fa fa-angle-right\"></i><span>Next</span></a></li>");
            str.Append("                </ul>");
            str.Append("            </div>");
            str.Append("            <div class=\"parallax-picture\">");
            str.Append(             LoadImages(id));
            str.Append("            </div>");
            str.Append("        </div>");
            str.Append("    </div>");
            str.Append("    </div>");
            str.Append("</div>");
        }
        return str.ToString();
    }
    protected string LoadImages(int id)
    {
        string sql = "SELECT File_ID,File_Name,File_Small,File_Larger FROM tbl_File WHERE Content_ID=" + id + " AND File_Status=1 ORDER BY File_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("<div class=\"custom-grid-row\">\n");
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("    <div class=\"col-1-2\">\n");
                str.Append("    <a href=\"" + rows[i]["File_Larger"] + "\" class=\"zoom\">");
                str.Append("        <img src=\"" + rows[i]["File_Small"] + "\" class=\"img-responsive wow zoomIn\" alt=\"" + rows[i]["File_Name"] + "\">\n");
                str.Append("    </a>\n");
                str.Append("    </div>\n");
                //if (i != 0 && i % 2 == 0) str.Append("</div><div class=\"custom-grid-row\">");
            }
            str.Append("</div>\n");
            //if (i != 0 && i % 2 == 0) str.Append("</div>");
        }
        return str.ToString();
    }
}