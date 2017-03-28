using System;
using System.Data;
using System.Web.UI;
using System.Text;
using SMAC;
using System.Collections.Generic;

public partial class ucontrols_frm_frmContact : UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p, op;
    protected static string cid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(u);
        cid = Request["s"];
        op = p;
        CMSfunc.checkURL();
        op = ModControl.GetOldP(p);
        LoadDetail(p);
        ltrSidebar.Text = LoadSidebar();
        if (Request["s"] != null)
        {
            ltrListCustomer.Text = LoadSkinDetail();
            LbNavigation.Text = GetSkinNameByID();
        }
        else
        {
            ltrListCustomer.Text = LoadDetail(p);   
            LbNavigation.Text = ModControl.GetName_From_Code(u);
        }
    }
    protected string GetSkinNameByID()
    {
        int o = int.Parse(Request["s"]);
        string sql = "select * from tbl_SKin where Skintype_ID = 9";
        sql += "and Skin_ID=" +o;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string name = rows[i]["Skin_Name"].ToString();
                str.Append(name);
            }
        }
        return str.ToString();
    }
    protected List<Skin> LoadCustomer()
    {
        string sql = "select * from tbl_Skin where Skintype_ID=9 and Skin_Status=1 and lang=" + Session["vlang"];
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        List<Skin> skins = new List<Skin>();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                Skin skin = new Skin(int.Parse(rows[i]["Skin_ID"].ToString()), rows[i]["Skin_Name"].ToString(), rows[i]["Skin_Url"].ToString(), rows[i]["Skin_Link"].ToString(), int.Parse(rows[i]["Mod_ID"].ToString()), int.Parse(rows[i]["Skin_Status"].ToString()), int.Parse(rows[i]["Skin_Pos"].ToString()));
                skins.Add(skin);
            }
        }
        return skins;
    }
    protected string LoadSkinDetail()
    {
 
        int p = int.Parse(Request["s"]);
        string sql = "select * from tbl_Skin where Skintype_ID = 9";
        sql += " and Skin_ID=" + p;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                DateTime today = DateTime.Now;
                str.Append("<div class=\"Content_Detail w100 fl\">");
                str.Append("        <h2><a href=\"" + rows[i]["Skin_Link"] + "\">Website đối tác: " + rows[i]["Skin_Link"] + "</a></h2>");
                str.Append("            <div class=\"date-author w100 fl\">");
                str.Append("        <div class=\"description\">" + rows[i]["Skin_Content"] + "</div>");
                str.Append("</div>");
            }
        }
        return str.ToString();
    }
    protected string LoadSidebar()
    {
        StringBuilder str = new StringBuilder();
        string sql = "Select * from tbl_SKin where Skintype_ID = 9";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            for(int i=0; i<rows.Count; i++)
            {
                if(rows[i]["Skin_ID"].ToString() == cid)
                {
                    str.Append("<li>");
                    str.Append("    <a class=\"active\" href=\"?s=" + rows[i]["Skin_ID"] + "\"><i class=\"fa fa-flag-checkered\"></i>" + rows[i]["Skin_Name"] + "</a>");
                    str.Append("</li>");
                }
                else
                {
                    str.Append("<li>");
                    str.Append("    <a href=\"?s=" + rows[i]["Skin_ID"] + "\"><i class=\"fa fa-flag-checkered\"></i>" + rows[i]["Skin_Name"] + "</a>");
                    str.Append("</li>");
                }
            }
        }
        return str.ToString();
    }
    protected void LoadAbout(int p)
    {
        string sql = "SELECT Mod_Name,Mod_Code,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + p + " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        StringBuilder str1 = new StringBuilder();
        for (int i = 0; i < rows.Count; i++)
        {
            str1.Append("<div class=\"gp-item about-item " + rows[i]["Mod_Code"] + "\">");
            str1.Append("    <h3>" + rows[i]["Mod_Name"] + "</h3>");
            str1.Append("    <p>" + rows[i]["Mod_Content"] + "</p>");
            str1.Append("</div>");
        }
        ltrListCustomer.Text = str1.ToString();
    }
    protected string LoadDetail(int p)
    {
        string sql = "SELECT Mod_Name,Mod_Code,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_ID=" + p + " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str1 = new StringBuilder();
        if (rows.Count > 0)
        {
            DateTime today = DateTime.Now;
            str1.Append("<div class=\"title\">");
            //str1.Append("        <h2>" + rows[0]["Mod_Name"] + "</h2>");
            str1.Append("            <div class=\"date-author w100 fl\">");
            str1.Append("            <span class=\"caption-date\"><i class=\"fa fa-calendar\"></i>&nbsp;Hôm nay:" + today + "</span></div>");
            str1.Append("</div>");
            str1.Append("<div class=\"content-editor\">" + rows[0]["Mod_Content"] + "</div>");
        }
        return str1.ToString();
    }
}
/*protected string uRoot = ApplicationSetting.URLRoot;
protected int p;
protected void Page_Load(object sender, EventArgs e)
{
    string url = String.IsNullOrEmpty(Request["url"]) ? "home" : Request["url"];
    p = ModControl.GetP_From_Code(url);
    CMSfunc.checkURL();
}
protected string GetNews(string mod)
{
    StringBuilder str = new StringBuilder();
    int cat = ModControl.GetP_From_Code(mod);
    string sql = "SELECT top 3 Mod_ID,Content_Name,Content_Img,Content_Url,Content_Intro,Content_Date FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Mod_ID in(SELECT Mod_ID From tbl_Mod WHERE Modtype_ID=1 AND Mod_Status=1) AND Content_Status=1 ORDER BY Content_ID DESC";
    DataSet ds = UpdateData.UpdateBySql(sql);
    DataRowCollection rows = ds.Tables[0].Rows;
    //===================================================
    for (int i = 0; i < rows.Count; i++)
    {
        int p = Convert.ToInt32(rows[i]["Mod_ID"]);
        string n = rows[i]["Content_Name"].ToString();
        string img = ApplicationSetting.URLRoot + rows[i]["Content_Img"].ToString();
        string intro = CMSfunc.ClearHTMLTags(rows[i]["Content_Intro"].ToString());
        string url = ResolveUrl("~/" + mod + "/" + rows[i]["Content_Url"].ToString() + ".htm");
        DateTime d = Convert.ToDateTime(rows[i]["Content_Date"].ToString());
        str.Append("<h3>\n");
        str.Append("    <a href=\"" + url + "\">" + n + "</a>\n");
        str.Append("    <small>" + d.DayOfWeek + "<span>•</span><em>" + d.Date + "</em></small>\n");
        str.Append("</h3>\n");
    }
    return str.ToString();
}
}
*/
