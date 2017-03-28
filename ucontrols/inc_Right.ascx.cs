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
public partial class ucontrols_inc_Right : System.Web.UI.UserControl
{
    public string uRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        int p = ConvertUtil.ReplaceInt(Request["p"]);
        ltrVideo.Text = GetVideoGallery();
        ltrThuvien.Text = GetThuvien();
        //ltrSanpham.Text = GetSanpham();
        //ltrBaimoi.Text = GetMoinhat("");//GetComment("Y-kien-khach-hang");
        //ltSupport.Text = CMSfunc.LoadOther("Support");
    }
    protected string GetVideoGallery()
    {
        StringBuilder str = new StringBuilder();
        string sql = "Select top 5 Content_Name,Content_Code from tbl_Content c left join tbl_Mod m on c.Mod_ID=m.Mod_ID where c.lang=" + Session["vlang"] + " AND c.Content_status=1 AND m.Modtype_ID=13";
        sql += " ORDER BY Content_ID DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            str.Append("<iframe id=\"playVideo\" width=\"100%\" height=\"176px\" src=\"" + rows[0]["Content_Code"].ToString() + "\" frameborder=\"0\" allowfullscreen></iframe>");
            for (int i = 0; i < rows.Count; i++)
            {
                string n = rows[i]["Content_Name"].ToString();
                string url = rows[i]["Content_Code"].ToString();
                str.Append("<div class=\"i-video\"><a href=\"javascript:playVideo('" + url + "')\"><span class=\"glyphicon glyphicon-facetime-video\"></span> " + n + "</a></div>");
            }
        }
        return str.ToString();
    }
    protected string GetThuvien()
    {
        StringBuilder str = new StringBuilder();
        string sql = "SELECT top 5 M.Mod_ID,Mod_Code,Content_ID,Content_Img,Content_Name,Content_URL FROM tbl_Content as C, tbl_Mod as M ";
        sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=9) AND Content_Status=1 ORDER BY Content_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        str.Append("<ul class=\"left-thuvien\">");
        for (int i = 0; i < rows.Count; i++)
        {
            int p = Convert.ToInt32(rows[i]["Mod_ID"]);
            string n = rows[i]["Content_Name"].ToString();
            string c = rows[i]["Mod_Code"].ToString();
            string u = rows[i]["Content_URL"].ToString();
            string img = uRoot + rows[i]["Content_Img"].ToString();
            string url = ResolveUrl("~/" + c + "/" + u + ".htm");
            str.Append("<li><a href=\"" + url + "\" title=\"" + n + "\"><img src=\"" + img + "\" alt=\"" + n + "\" class=\"img-responsive\" /></a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    protected string GetSanpham()
    {
        StringBuilder str = new StringBuilder();
        string sql = "SELECT top 5 M.Mod_ID,Mod_Code,Content_ID,Content_Img,Content_Name,Content_URL FROM tbl_Content as C, tbl_Mod as M ";
        //sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=6) AND Content_Status=1 ORDER BY Content_Pos";
        sql += "WHERE C.lang=" + Session["vlang"] + " AND M.Mod_ID=C.Mod_ID AND M.Mod_ID in(SELECT Mod_ID from tbl_Mod WHERE Mod_Status=1 AND Mod_Code='san-pham') AND Content_Status=1 ORDER BY Content_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        str.Append("<ul class=\"left-products\">");
        for (int i = 0; i < rows.Count; i++)
        {
            int p = Convert.ToInt32(rows[i]["Mod_ID"]);
            string n = rows[i]["Content_Name"].ToString();
            string c = rows[i]["Mod_Code"].ToString();
            string u = rows[i]["Content_URL"].ToString();
            string img = uRoot + rows[i]["Content_Img"].ToString();
            string url = ResolveUrl("~/" + c + "/" + u + ".htm");

            str.Append("<li><a href=\"" + url + "\" title=\"" + n + "\"><img src=\"" + img + "\" alt=\"" + n + "\" class=\"img-responsive\" /></a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    protected string GetMoinhat(string mod)
    {
        StringBuilder str = new StringBuilder();
        //int cat = ModControl.GetP_From_Code(mod);
        //string sql = "SELECT top 10 Mod_ID,Content_ID,Content_Name,Content_Url FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID in(SELECT Mod_ID From tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=1) ORDER BY Content_ID DESC";
        string sql = "Select top 8 c.Mod_ID,Mod_Url,Content_ID,Content_Name,Content_Img,Content_Intro,Content_Url from tbl_Content c left join tbl_Mod m on c.Mod_ID=m.Mod_ID";
        sql += " WHERE c.lang=" + Session["vlang"] + " AND c.Content_Status=1";
        sql += " ORDER BY Content_ID DESC";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        //===================================================
        str.Append("<ul>");
        for (int i = 0; i < rows.Count; i++)
        {
            string n = rows[i]["Content_Name"].ToString();
            string url = ResolveUrl("~/" + rows[i]["Mod_Url"].ToString() + "/" + rows[i]["Content_Url"].ToString() + ".htm");
            str.Append("<li><a href=\"" + url + "\" title=\"" + n + "\">" + n + "</a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    
}