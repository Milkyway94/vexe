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

public partial class Admin_Modules_Function_Controls_RightAccess : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string id, p;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        p = Request["p"];
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_User");        
        cblRight.DataSource = ds;
        cblRight.DataTextField = "User_Name";
        cblRight.DataValueField = "User_ID";
        cblRight.DataBind();

        DataSet dsForUser = UpdateData.UpdateBySql("SELECT * FROM tbl_ModUser WHERE ModAdmin_ID=" + id);
        DataRowCollection rows = dsForUser.Tables[0].Rows;
        for (int i = 0; i < cblRight.Items.Count; i++)
        {
            for (int j = 0; j < rows.Count; j++)
            {
                if (cblRight.Items[i].Value.Equals(rows[j]["UserID"].ToString()))
                {
                    cblRight.Items[i].Selected = true;
                }
            }
        }
    }

    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"FunctionList.aspx?p=" + p + "\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        UpdateData.Delete("tbl_ModUser", "ModAdmin_ID=" + id);
        for (int i = 0; i < cblRight.Items.Count; i++)
        {
            if (cblRight.Items[i].Selected == true)
            {
                string UserID = cblRight.Items[i].Value;
                UpdateData.InsertBySql("INSERT INTO tbl_ModUser(ModAdmin_ID,UserID) VALUES(" + id + "," + UserID + ")");
            }
        }
        Response.Write(sScritp);
    }
}
