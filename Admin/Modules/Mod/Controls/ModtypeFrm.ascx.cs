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

public partial class Admin_Modules_Mod_Controls_ModtypeFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Request["id"];
        if (!IsPostBack)
        {
            //==========================================================================
            if (act == "edit")
            {
                ViewEdit(id);
            }
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Modtype WHERE Modtype_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Modtype_Name"].ToString();
            txtCode.Text = rows[0]["Modtype_Code"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Modtype_Status"]) == true) ? true : false;            
        }
        //trBox.Visible = false;
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "b.attachURL(\"ModtypeList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        Hashtable tbIn = new Hashtable();
        tbIn.Add("Modtype_Name", txtName.Text);
        tbIn.Add("Modtype_Code", txtCode.Text);
        tbIn.Add("Modtype_Status", isUse);
        
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_Modtype", tbIn);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Modtype", tbIn, "Modtype_ID=" + id);
        }
        Response.Write(sScritp);
    }
}
