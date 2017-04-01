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

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    public string uRoot = ApplicationSetting.URLRoot;
    public string urlRoot = ApplicationSetting.URLRoot + "Admin";
    public string URLJs = ApplicationSetting.URLRoot + "Admin/js";
    public string URLJ_dhtmlx = ApplicationSetting.URLRoot + "Admin/dhtmlx";
    public string URLCss = ApplicationSetting.URLRoot + "Admin/css";
    public string uImg = ApplicationSetting.URLRoot + "Admin/images";
    public string urlThemes = ApplicationSetting.URLRoot + "Admin/Themes";

    public static string URLRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["lang"] == null)
            {
                Session["lang"] = 1;
            }
            for (int i = 0; i < ddlLang.Items.Count; i++)
            {
                if (Session["lang"].ToString() == ddlLang.Items[i].Value)
                {
                    ddlLang.Items[i].Selected = true;
                }
            }
            if (Session["UserID"] == null)
            {
                Response.Redirect(URLRoot + "Admin/" + "login.aspx");
            }
            else
            {
                lbMenuTop.Text = BuildMenuTop(Session["UserID"].ToString());
            }
        }
        LoadCss();
        LoadJs();
    }
    public string BuildMenuTop(string UserID)
    {
        FunctionDB db = new FunctionDB();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("");
        stringBuilder.Append("<ul class=\"nav navbar-nav pull-left\">");
        DataSet dataSet = UpdateData.UpdateBySql("SELECT * FROM tbl_ModAdmin WHERE ModAdmin_Parent=0 ORDER BY ModAdmin_Pos");
        DataRowCollection rows = dataSet.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string text = " AND tbl_ModAdmin.ModAdmin_ID IN (SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID='" + UserID + "')";
            string text2 = rows[i]["ModAdmin_ID"].ToString();
            if (db.HasChildren(text2, text))
            {
                string texti = rows[i]["ModAdmin_Icon"].ToString();
                stringBuilder.Append("\t<li class=\"dropdown messages-menu\">");
                stringBuilder.Append("   <a href=\"#\" class=\"text-center\"><i class=\"" + texti + " fa-2x\"></i><br>" + rows[i]["ModAdmin_Name"].ToString() + "</a>");
                string str = " ORDER BY ModAdmin_Pos ";
                text = string.Concat(new string[]
                {
                        " AND ModAdmin_Status=1 AND ModAdmin_Parent=",
                        text2,
                        " AND tbl_ModAdmin.ModAdmin_ID IN (SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID='",
                        UserID,
                        "')"
                });
                string sql = "SELECT * FROM tbl_ModAdmin WHERE 1=1" + text + str;
                DataSet dataSet2 = UpdateData.UpdateBySql(sql);
                DataRowCollection rows2 = dataSet2.Tables[0].Rows;
                stringBuilder.Append("<ul class=\"dropdown-menu\">");
                for (int j = 0; j < rows2.Count; j++)
                {
                    string text3 = rows2[j]["ModAdmin_ID"].ToString();
                    string text4 = rows2[j]["ModAdmin_Path"].ToString();
                    string text5 = FunctionDB.URLRoot + "Admin/" + rows2[j]["ModAdmin_Icon"].ToString();
                    string text10 = rows2[j]["ModAdmin_Icon"].ToString();
                    string text6 = rows2[j]["ModAdmin_Name"].ToString();
                    stringBuilder.Append(string.Concat(new string[]
                    {
                            "<li class=\"p\"><a href=\"",
                            FunctionDB.URLRoot,
                            "Admin/",
                            text4,
                            "#"+text3+"\"><i class=\""+text10+"\"></i> ",
                            text6,
                            "</a></li>"
                    }));
                }
                stringBuilder.Append("</ul>");
                stringBuilder.Append("</li>");
            }
        }
        stringBuilder.Append("</ul>");
        return stringBuilder.ToString();
    }
    public void LoadCss()
    {
        StringBuilder str = new StringBuilder();
        str.Append("<link href=\"" + uRoot + "resources/css/bootstrap.min.css \" rel =\"stylesheet\" />");
        str.Append("<link href=\"" + uRoot + "resources/css/font-awesome.min.css \" rel =\"stylesheet\" />");
        str.Append("<link href=\"" + urlRoot + "/Assets/admin-lte/select2/select2.min.css\" rel =\"stylesheet\" />");
        str.Append("<link rel=\"stylesheet\" href=\"" + URLCss + "/Style.css\" type=\"text/css\" />");
        str.Append("<link rel=\"stylesheet\" href=\"" + URLCss + "/MenuTop.css\" type=\"text/css\" />");
        str.Append("<link rel=\"stylesheet\" href=\"" + URLJ_dhtmlx + "/skins/layout_dhx_skyblue.css\" type=\"text/css\" />");
        str.Append("<link rel=\"stylesheet\" href=\"" + URLCss + "/Orders.css\" type=\"text/css\" />");
        ltCss.Text = str.ToString();
    }
    public void LoadJs()
    {
        StringBuilder str = new StringBuilder();
        str.Append("<script src = \"" + uRoot + "resources/js/jquery-2.2.4.min.js\"></script>");
        str.Append("<script src = \"" + uRoot + "resources/js/bootstrap.min.js\"></script>");
        //str.Append("<script src = \"" + urlRoot + "/Assets/admin-lte/js/app.min.js\"></script>");
        str.Append("<script type=\"text/javascript\"  src=\"" + URLJs + "/tooltip.js\"></script>");
        str.Append("<script type=\"text/javascript\"  src=\"" + URLJs + "/toolBarButton.js\"></script>");
        str.Append("<script type=\"text/javascript\"  src=\"" + URLJ_dhtmlx + "/common.js\"></script>");
        str.Append("<script type=\"text/javascript\"  src=\"" + URLJ_dhtmlx + "/layout.js\"></script>");
        str.Append("<script type=\"text/javascript\"  src=\"" + URLJ_dhtmlx + "/container.js\"></script>");
        ltJavascript.Text = str.ToString();
    }
    protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["lang"] = ddlLang.SelectedValue;
    }
}
