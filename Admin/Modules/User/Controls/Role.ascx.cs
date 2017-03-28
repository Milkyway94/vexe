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

public partial class Administrator_Modules_Member_Controls_Role : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string id, pbid;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        pbid = Request["pbid"];
        if (!IsPostBack)
        {
            this.LoadData();
        }
    }
    public void LoadData()
    {
        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_Role");
        cblRole.DataSource = ds;
        cblRole.DataTextField = "Role_Name";
        cblRole.DataValueField = "Role_ID";
        cblRole.DataBind();

        DataSet dsForUser = UpdateData.UpdateBySql("SELECT * FROM tbl_RoleUser WHERE User_ID=" + id);
        DataRowCollection rows = dsForUser.Tables[0].Rows;
        for (int i = 0; i < cblRole.Items.Count; i++)
        {
            for (int j = 0; j < rows.Count; j++)
            {
                if (cblRole.Items[i].Value.Equals(rows[j]["Role_ID"].ToString()))
                {
                    cblRole.Items[i].Selected = true;
                }
            }
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"UserList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        UpdateData.Delete("tbl_RoleUser", "User_ID=" + id);
        for (int i = 0; i < cblRole.Items.Count; i++)
        {
            if (cblRole.Items[i].Selected == true)
            {
                string RoleID = cblRole.Items[i].Value;
                UpdateData.InsertBySql("INSERT INTO tbl_RoleUser(Role_ID,User_ID) VALUES(" + RoleID + "," + id + ")");
            }
        }
        Response.Write(sScritp);

    }
}
