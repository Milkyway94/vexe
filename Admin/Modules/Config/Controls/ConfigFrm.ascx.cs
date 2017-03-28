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

public partial class Admin_Modules_Config_Controls_ConfigFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act;
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Convert.ToInt32(Request["id"]);
        if (!IsPostBack)
        {
            if (act == "edit")
                ViewEdit(id);
        }
    }
    public void ViewEdit(int id)
    {
        string sql = "SELECT * FROM tbl_Config WHERE Config_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Config_Name"].ToString();
            txtCode.Text = rows[0]["Config_Code"].ToString();
            txtValues.Text = rows[0]["Config_Values"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Config_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"ConfigList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Config_Name", txtName.Text);
        tbIn.Add("Config_Code", txtCode.Text);
        tbIn.Add("Config_Values", txtValues.Text);
        tbIn.Add("Config_Status", isUse);
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_Config", tbIn);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Config", tbIn, "Config_ID=" + id);
        }
        Response.Write(sScritp);
    }
}
