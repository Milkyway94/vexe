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

public partial class Admin_Modules_Box_Controls_BoxtypeFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Request["id"];
        if (!IsPostBack)
        {
            if (act == "edit")
                ViewEdit(id);
        }
    }
    public void ViewEdit(string id)
    {
        string sql="SELECT * FROM tbl_Boxtype WHERE Boxtype_ID=" + id;
        DataSet dsPB = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = dsPB.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Boxtype_Name"].ToString();
            txtCode.Text = rows[0]["Boxtype_Code"].ToString();
            txtLimit.Text = rows[0]["Boxtype_Limit"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Boxtype_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"BoxList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Boxtype_Name", txtName.Text);
        tbIn.Add("Boxtype_Code", txtCode.Text);
        tbIn.Add("Boxtype_Limit", txtLimit.Text);
        tbIn.Add("Boxtype_Status", isUse);
        if (act == "add")
        {            
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Boxtype", tbIn);
        }
        if (act == "edit")
        {            
            bool _update = UpdateData.Update("tbl_Boxtype", tbIn, "Boxtype_ID=" + id);        
        }
        Response.Write(sScritp);
    }
}
