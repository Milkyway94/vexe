using System;
using System.Data;
using System.Web.UI;
using System.Text;
using SMAC;
using System.Collections.Generic;

public partial class ucontrols_frm_frmContact : UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p;
    protected string cid, nurl, url;
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        p = ModControl.GetP_From_Code(url);
        if (nurl != null)
        {
            lbnav.Text = "<li><a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li> <li>" + ModControl.GetName_From_Code(nurl) + "</li>";
            int id = ModControl.GetP_From_Code(nurl);
            ltrListContent.Text = LoadDetail(id);
        }
        else
        {
            lbnav.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(url) + "</li>";
            ltrListContent.Text = LoadDetail(p);
        }
    }
    protected string GetLbByModID()
    {
        string sql = "select * from tbl_Mod where Mod_Parent = 233";
        sql += "and Mod_ID=" + p;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string name = rows[i]["Mod_Name"].ToString();
                str.Append("<i class=\"fa fa-angle-double-right\"></i><strong class=\"breadcrumb_last\">");
                str.Append(name);
            }
        }
        return str.ToString();
    }
    protected string LoadOrther()
    {
        string sql = "SELECT Mod_Name,Mod_Code,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_ID=" + p + " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str1 = new StringBuilder();
        if (rows.Count > 0)
        {
            DateTime today = DateTime.Now;
            str1.Append("<div class=\"title\">");
            str1.Append("        <h2>" + rows[0]["Mod_Name"] + "</h2>");
            str1.Append("            <div class=\"date-author w100 fl\">");
            str1.Append("            <span class=\"caption-date\"><i class=\"fa fa-calendar\"></i>&nbsp;Hôm nay:" + today + "</span></div>");
            str1.Append("</div>");
            str1.Append("<div class=\"content-editor\">" + rows[0]["Mod_Content"].ToString() + "</div>");
        }
        return str1.ToString();
    }

    protected string LoadListAbout(string cid)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        int parent = ModControl.GetParent(p) != 0 ? ModControl.GetParent(p) : p;
        string sql = "SELECT * FROM tbl_Mod WHERE Mod_Parent =" + parent + " AND Mod_Status=1 AND lang=" + Session["vlang"] + "ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string id = rows[i]["Mod_ID"].ToString();
                string name = rows[i]["Mod_Name"].ToString();
                if (id == ModControl.GetP_From_Code(nurl).ToString())
                {
                    str.Append("<li>");
                    str.Append("    <a class=\"active\" href=\"" + ResolveUrl("~/" + url) + "/" + ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm") + "\">" + name + "</a>");
                    str.Append("</li>");
                }
                else
                {
                    str.Append("<li>");
                    str.Append("    <a href=\"" + ResolveUrl("~/" + url + "/" + rows[i]["Mod_Code"] + ".htm") + "\">" + name + "</a>");
                    str.Append("</li>");
                }
            }
        }
        return str.ToString();
    }
    /* if (ModControl.GetLevel(p) == 2)
    {
        op = ModControl.GetOldP(p);
        LoadDetail(p);
    }
    else
        LoadAbout(p);
    LoadList(op, u);

} */
    /*  protected void LoadList(int p, string url)
      {
          string sql = "SELECT Mod_Name,Mod_Code,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + p + " ORDER BY Mod_Pos";
          DataSet ds = UpdateData.UpdateBySql(sql);
          DataRowCollection rows = ds.Tables[0].Rows;
          StringBuilder str = new StringBuilder();
          for (int i = 0; i < rows.Count; i++)
          {
              string css = (url == rows[i]["Mod_Code"].ToString()) ? " class=\"active\"" : "";
              //str.Append("<li><a href=\"#\" data-filter=\"." + rows[i]["Mod_Code"] + "\">" + rows[i]["Mod_Name"] + "</a></li>");
              str.Append("<li" + css + "><a href=\"" + ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm") + "\">" + rows[i]["Mod_Name"] + "</a></li>");
          }
          ltrSubmod.Text = ltrSubmoRes.Text = str.ToString();
      }
      */
    protected string LoadAbout(int p)
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
        return str1.ToString();
    }
    protected string LoadDetail(int p)
    {
        string sql = "SELECT Mod_Name,Mod_Code,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_ID=" + p;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str1 = new StringBuilder();
        if (rows.Count > 0)
        {
            DateTime today = DateTime.Now;
            str1.Append("<div class=\"title\">");
            //str1.Append("        <h2>" + rows[0]["Mod_Name"] + "</h2>");
            str1.Append("            <div class=\"date-author w100 fl\">");
            str1.Append("</div>");
            str1.Append("<div class=\"content-editor\">" + rows[0]["Mod_Content"].ToString() + "</div>");
        }
        return str1.ToString();
    }
}
