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

public partial class Administrator_Modules_User_Controls_DepartFrm : System.Web.UI.UserControl
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
            {
                ViewEdit(id);
            }            
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Role WHERE Role_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Role_Name"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Role_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "b.attachURL(\"RoleList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Role_Name", txtName.Text);
        tbIn.Add("Role_Status", isUse);
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_Role", tbIn);
            Response.Write(sScritp);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Role", tbIn, "Role_ID=" + id);
            Response.Write(sScritp);
        }
    }
}
