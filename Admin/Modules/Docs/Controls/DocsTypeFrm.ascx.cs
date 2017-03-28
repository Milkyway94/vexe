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

public partial class DocsTypeFrm : System.Web.UI.UserControl
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
        string sql = "SELECT * FROM tbl_DocsType WHERE DocsType_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["DocsType_Name"].ToString();
            txtDes.Text = rows[0]["DocsType_Description"].ToString();
            txtPos.Text = rows[0]["DocsType_Order"].ToString();
            txtImg.Text = rows[0]["DocsType_Img"].ToString();
            txtTitle.Text = rows[0]["DocsType_Title"].ToString();
            for (int i = 0; i < ddlGroup.Items.Count; i++)
            {
                if (ddlGroup.Items[i].Value == rows[0]["DocsType_ID"].ToString())
                    ddlGroup.Items[i].Selected = true;
            }
            bool isUse = Convert.ToBoolean(rows[0]["DocsType_Status"]);
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
        tbIn.Add("DocsType_Parent", ddlGroup.SelectedValue);
        tbIn.Add("DocsType_Name", txtName.Text);
        tbIn.Add("DocsType_Description", txtDes.Text);
        tbIn.Add("DocsType_Order", txtPos.Text);
        tbIn.Add("DocsType_Status", isUse);
        tbIn.Add("DocsType_Title", txtTitle.Text);
        tbIn.Add("DocsType_Img", txtImg.Text);
        Response.Write(ddlGroup.SelectedValue);
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_DocsType", tbIn);
            if (_insert)
            {
                Response.Write(sScritp);
            }
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_DocsType", tbIn, "DocsType_ID=" + id);
            if (_update)
            {
                Response.Write(sScritp);
            }
        }
    }
}
