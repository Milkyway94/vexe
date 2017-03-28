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

public partial class Docs_FunFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];        
        id = Request["id"];
        if (!IsPostBack)
        {
            DataSet dsPB = UpdateData.UpdateBySql("SELECT DocsType_ID, DocsType_Name, DocsType_Parent FROM tbl_DocsType");
            DataRowCollection rows = dsPB.Tables[0].Rows;
            ddlGroup.Items.Add(new ListItem("- Mục gốc -", "0"));
            for (int i = 0; i < rows.Count; i++)
            {
                ddlGroup.Items.Add(new ListItem("--" + rows[i][1].ToString(), rows[i][0].ToString()));
            }
            if (act == "edit")
                ViewEdit(id);
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Documents WHERE Doc_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Doc_Name"].ToString();
            CKTeaser.Text = rows[0]["Doc_Content"].ToString();
            txtPos.Text = rows[0]["Doc_Pos"].ToString();
            txtPath.Text = rows[0]["Doc_File"].ToString();
            txtCode.Text = rows[0]["Doc_Code"].ToString();
            for (int i = 0; i < ddlGroup.Items.Count; i++)
            {
                if (ddlGroup.Items[i].Value == rows[0]["DocsType_ID"].ToString())
                    ddlGroup.Items[i].Selected = true;
            }
            bool isUse = Convert.ToBoolean(rows[0]["Doc_Status"]);
            cbIsUse.Checked = (isUse == true) ? true : false;           
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"DocsList.aspx?p=" + ddlGroup.SelectedValue + "\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("DocsType_Id", ddlGroup.SelectedValue);
        tbIn.Add("Doc_Name", txtName.Text);
        tbIn.Add("Doc_Content", CKTeaser.Text);
        tbIn.Add("Doc_Pos", txtPos.Text);
        tbIn.Add("Doc_Status", isUse);
        tbIn.Add("Doc_Code", txtCode.Text);
        tbIn.Add("Doc_File", txtPath.Text);
        Response.Write(ddlGroup.SelectedValue);
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_Documents", tbIn);
            if (_insert)
            {
                Response.Write(sScritp);
            }
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Documents", tbIn, "Doc_ID=" + id);
            if(_update)
            {
                Response.Write(sScritp);
            }
        }
    }
}
