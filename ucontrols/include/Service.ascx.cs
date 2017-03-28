using System;
using System.Data;
using System.Web.UI.WebControls;
using SMAC;
using System.Text;
public partial class ucontrols_include_Products : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSfunc.checkURL();
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        int p = ModControl.GetP_From_Code(u);
        ltrAboutService.Text = ModControl.GetModField("Content", p);
        ltrListService.Text = LoadService(p);
    }
    protected string  LoadService(int p)
    {
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Img,Mod_Url,Mod_Content FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Parent=" + p;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < rows.Count; i++)
        {
            int cat = Convert.ToInt32(rows[i]["Mod_ID"]);
            str.Append("<li class=\"row\">");
            str.Append("    <div class=\"service-details col-sm-7 col-xs-12\">");
            str.Append("        <h3>" + rows[i]["Mod_Name"] + "</h3>");
            str.Append("        <p>" + rows[i]["Mod_Content"] + "</p>");
            str.Append("    </div>");
            str.Append("    <div class=\"service-img col-sm-5 col-xs-12\"><a href=\"" + uRoot + rows[i]["Mod_Img"] + "\" class=\"zoom\"><img src=\"" + uRoot + rows[i]["Mod_Img"] + "\" alt=\"\" /></a>");
            string sql1 = "SELECT Content_Img FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID=" + cat;
            DataSet ds1 = UpdateData.UpdateBySql(sql1);
            DataRowCollection rows1 = ds1.Tables[0].Rows;
            for (int j = 0; j < rows1.Count; j++)
            {
                str.Append("<a href=\"" + uRoot + rows1[j]["Content_Img"] + "\" class=\"zoom\"></a>");
            }
            str.Append("    </div>");
            str.Append("</li>");
        }
        return str.ToString();
    }
}