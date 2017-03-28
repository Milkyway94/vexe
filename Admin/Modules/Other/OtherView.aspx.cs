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
using SMAC;

public partial class Admin_Modules_Other_OtherList : DefaultAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["id"]);
        BindData(id);
    }
    public void BindData(int id)
    {
        string sql = "SELECT * FROM tbl_Other WHERE Other_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        string str = "";
        if (rows.Count > 0)
        {
            str += "<h1>" + rows[0]["Other_Name"].ToString() + "</h1>";
            str += "<h2>" + rows[0]["Other_Mod"].ToString() + "</h2>";
            str += "<div>" + rows[0]["Other_Content"].ToString() + "</div>";
        }
        views.Text = str.ToString();
    }
}
