using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using SMAC;
public partial class ucontrols_inc_Left : System.Web.UI.UserControl
{
    public string uRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        int p = ConvertUtil.ReplaceInt(Request["p"]);
        //ltrVideo.Text = GetVideoGallery();
        //ltrThuvien.Text = GetThuvien();
        //ltrSanpham.Text = GetSanpham();
        ltrWeblink.Text = GetWeblink();
        ltrMenu.Text = GetMenu(p);
    }
    protected string GetMenu(int p)
    {
        StringBuilder str = new StringBuilder();
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1";
        sql += " AND Mod_Level=1 AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
        sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menuleft' AND lang=" + Session["vlang"] + "))";
        sql += " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        //===================================================
        str.Append("<div class=\"content\">\n");
        //str.Append("<ul class=\"list-unstyled listSidebar\">\n");
        str.Append("<ul class=\"list-unstyled\">\n");
        for (int i = 0; i < rows.Count; i++)
        {
            int id = Convert.ToInt32(rows[i]["Mod_ID"]);
            string n = rows[i]["Mod_Name"].ToString();
            string c = rows[i]["Mod_Code"].ToString();
            string url = ResolveUrl("~/" + c + ".htm");
            //string css = (ContentControl.CheckGroup(id) == true) ? " <i class=\"fa fa-caret-right\"></i>" : "";
            str.Append("    <li><a class=\"menu-title\" href=\"" + url + "\" title=\"" + n + "\">" + n + "</a>\n");
            str.Append(GetSubMenu(id));
            str.Append("    </li>\n");
        }
        str.Append("</ul>\n");
        str.Append("</div>\n");
        return str.ToString();
    }
    protected string GetSubMenu(int cat)
    {
        StringBuilder str = new StringBuilder();
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + cat + " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        //===================================================
        if (rows.Count > 0)
        {
            str.Append("<ul>\n");
            for (int i = 0; i < rows.Count; i++)
            {
                int id = Convert.ToInt32(rows[i]["Mod_ID"]);
                string n = rows[i]["Mod_Name"].ToString();
                string c = rows[i]["Mod_Code"].ToString();
                string url = ResolveUrl("~/" + c + ".htm");
                //string css = (i == 0) ? " class=\"active\"" : "";
                str.Append("    <li><a href=\"" + url + "\" title=\"" + n + "\">" + n + "</a></li>\n");
            }
            str.Append("</ul>\n");
        }
        return str.ToString();
    }
    //protected string GetVideoGallery()
    //{
    //    StringBuilder str = new StringBuilder();
    //    string sql = "Select top 5 Content_Name,Content_Code from tbl_Content c left join tbl_Mod m on c.Mod_ID=m.Mod_ID where c.lang=" + Session["vlang"] + " AND c.Content_status=1 AND m.Modtype_ID=13";
    //    sql += " ORDER BY Content_ID DESC";
    //    DataSet ds = UpdateData.UpdateBySql(sql);
    //    DataRowCollection rows = ds.Tables[0].Rows;
    //    if (rows.Count > 0)
    //    {
    //        str.Append("<iframe id=\"playVideo\" width=\"100%\" height=\"176px\" src=\"" + rows[0]["Content_Code"].ToString() + "\" frameborder=\"0\" allowfullscreen></iframe>");
    //        for (int i = 0; i < rows.Count; i++)
    //        {
    //            string n = rows[i]["Content_Name"].ToString();
    //            string url = rows[i]["Content_Code"].ToString();
    //            str.Append("<div class=\"i-video\"><a href=\"javascript:playVideo('" + url + "')\"><span class=\"glyphicon glyphicon-facetime-video\"></span> " + n + "</a></div>");
    //        }
    //    }
    //    return str.ToString();
    //}
    //protected string GetThuvien()
    //{
    //    StringBuilder str = new StringBuilder();
    //    string sql = "SELECT top 5 M.Mod_ID,Mod_Code,Content_ID,Content_Img,Content_Name,Content_URL FROM tbl_Content as C, tbl_Mod as M ";
    //    sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=9) AND Content_Status=1 ORDER BY Content_Pos";
    //    DataSet ds = UpdateData.UpdateBySql(sql);
    //    DataRowCollection rows = ds.Tables[0].Rows;
    //    str.Append("<ul class=\"left-thuvien\">");
    //    for (int i = 0; i < rows.Count; i++)
    //    {
    //        int p = Convert.ToInt32(rows[i]["Mod_ID"]);
    //        string n = rows[i]["Content_Name"].ToString();
    //        string c = rows[i]["Mod_Code"].ToString();
    //        string u = rows[i]["Content_URL"].ToString();
    //        string img = uRoot + rows[i]["Content_Img"].ToString();
    //        string url = ResolveUrl("~/" + c + "/" + u + ".htm");
    //        str.Append("<li><a href=\"" + url + "\" title=\"" + n + "\"><img src=\"" + img + "\" alt=\"" + n + "\" class=\"img-responsive\" /></a></li>");
    //    }
    //    str.Append("</ul>");
    //    return str.ToString();
    //}
    //protected string GetSanpham()
    //{
    //    StringBuilder str = new StringBuilder();
    //    string sql = "SELECT top 5 M.Mod_ID,Mod_Code,Content_ID,Content_Img,Content_Name,Content_URL FROM tbl_Content as C, tbl_Mod as M ";
    //    //sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=6) AND Content_Status=1 ORDER BY Content_Pos";
    //    sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Mod_Code='san-pham') AND Content_Status=1 ORDER BY Content_Pos";
    //    DataSet ds = UpdateData.UpdateBySql(sql);
    //    DataRowCollection rows = ds.Tables[0].Rows;
    //    str.Append("<ul class=\"left-products\">");
    //    for (int i = 0; i < rows.Count; i++)
    //    {
    //        int p = Convert.ToInt32(rows[i]["Mod_ID"]);
    //        string n = rows[i]["Content_Name"].ToString();
    //        string c = rows[i]["Mod_Code"].ToString();
    //        string u = rows[i]["Content_URL"].ToString();
    //        string img = uRoot + rows[i]["Content_Img"].ToString();
    //        string url = ResolveUrl("~/" + c + "/" + u + ".htm");

    //        str.Append("<li><a href=\"" + url + "\" title=\"" + n + "\"><img src=\"" + img + "\" alt=\"" + n + "\" class=\"img-responsive\" /></a></li>");
    //    }
    //    str.Append("</ul>");
    //    return str.ToString();
    //}
    protected string GetWeblink()
    {
        StringBuilder str = new StringBuilder();
        int p = ModControl.GetP_From_Code("Weblink");
        string sql = "SELECT Mod_ID,Content_Name,Content_Img,Content_URL FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID=" + p + " ORDER BY Content_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        //===================================================
        str.Append("<select>");
        for (int i = 0; i < rows.Count; i++)
        {
            int id = Convert.ToInt32(rows[i]["Mod_ID"]);
            string n = rows[i]["Content_Name"].ToString();
            string url = rows[i]["Content_URL"].ToString();
            string img = uRoot + rows[i]["Content_Img"].ToString();
            str.Append("<option>" + n + "</option>");
        }
        str.Append("</select>");
        return str.ToString();
    }
}