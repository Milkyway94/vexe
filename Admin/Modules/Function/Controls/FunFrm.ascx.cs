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

public partial class Function_FunFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];        
        id = Request["id"];
        if (!IsPostBack)
        {
            DataSet dsPB = UpdateData.UpdateBySql("SELECT ModAdmin_ID, ModAdmin_Name FROM tbl_ModAdmin WHERE ModAdmin_Parent=0");
            DataRowCollection rows = dsPB.Tables[0].Rows;
            ddlGroup.Items.Add(new ListItem("- Mục gốc -", "0"));
            for (int i = 0; i < rows.Count; i++)
            {
                ddlGroup.Items.Add(new ListItem("-- " + rows[i][1].ToString(), rows[i][0].ToString()));
            }
            if (act == "edit")
                ViewEdit(id);
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_ModAdmin WHERE ModAdmin_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["ModAdmin_Name"].ToString();
            txtInfo.Text = rows[0]["ModAdmin_Info"].ToString();
            txtPath.Text = rows[0]["ModAdmin_Path"].ToString();
            txtPos.Text = rows[0]["ModAdmin_Pos"].ToString();
            txtIcon.Text= rows[0]["ModAdmin_Icon"].ToString();
            for (int i = 0; i < ddlGroup.Items.Count; i++)
            {
                if (ddlGroup.Items[i].Value == rows[0]["ModAdmin_Parent"].ToString())
                    ddlGroup.Items[i].Selected = true;
            }
            bool isUse = Convert.ToBoolean(rows[0]["ModAdmin_Status"]);
            cbIsUse.Checked = (isUse == true) ? true : false;           
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"FunctionList.aspx?p=" + ddlGroup.SelectedValue + "\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("ModAdmin_Parent", ddlGroup.SelectedValue);
        tbIn.Add("ModAdmin_Name", txtName.Text);
        tbIn.Add("ModAdmin_Info", txtInfo.Text);
        tbIn.Add("ModAdmin_Status", isUse);
        tbIn.Add("ModAdmin_Path", txtPath.Text);
        tbIn.Add("ModAdmin_Pos", txtPos.Text);
        tbIn.Add("ModAdmin_Icon", txtIcon.Text);
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_ModAdmin", tbIn);
            if (_insert)
            {
                string sql1 = "SELECT * FROM tbl_ModAdmin ORDER BY ModAdmin_ID DESC";
                DataSet ds1 = UpdateData.UpdateBySql(sql1);
                DataRowCollection rows1 = ds1.Tables[0].Rows;
                UpdateData.InsertBySql("INSERT INTO tbl_ModUser(ModAdmin_ID,UserID) VALUES(" + rows1[0]["ModAdmin_ID"] + "," + Session["UserID"] + ")");
            }
            Response.Write(sScritp);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_ModAdmin", tbIn, "ModAdmin_ID=" + id);            
            Response.Write(sScritp);
        }
    }
}
