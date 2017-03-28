using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Search : System.Web.UI.UserControl
{
    public string strXuatphat, strDich, strNgaydi, strThoigiandi;
    public int p;
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(u);
        ltrAdvertisment.Text = GetAdvertisment(p);
    }
    protected string GetAdvertisment(int p)
    {
        StringBuilder adStr = new StringBuilder();
        string sql = "SELECT * FROM tbl_Skin WHERE Mod_Id=" + p +" AND Skin_status!=0 AND lang="+Session["vlang"] +" ORDER BY Skin_Pos";
        DataSet result = UpdateData.UpdateBySql(sql);
        if (result != null)
        {
            foreach (DataRow item in result.Tables[0].Rows)
            {
                adStr.Append("<a href=\"" + item["Skin_Link"] + "\"><img class=\"img-responsive\" src=\"" + item["Skin_Url"] + "\" alt=\"" + item["Skin_Link"] + "\">");
            }
        }
        return adStr.ToString();
    }
}