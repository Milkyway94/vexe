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

public partial class FrmFile : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id, p;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Request["id"];
        p = Request["p"];
        if (!IsPostBack)
        {
            if (act == "edit")
                ViewEdit(id);
            if (Session["Admin"].ToString() != "admin")
            {
                cbIsUse.Enabled = false;
            }
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_File WHERE File_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["File_Name"].ToString();
            fpFileSmall.Text = rows[0]["File_Small"].ToString();
            fpFileLarger.Text = rows[0]["File_Larger"].ToString();
            txtPos.Text = rows[0]["File_Pos"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["File_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScript = "<script>";
        sScript += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScript += "b.attachURL(\"ImagesList.aspx?p=" + p + "\");";
        sScript += "window.close();";
        sScript += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("File_Name", txtName.Text);
        tbIn.Add("File_Small", fpFileSmall.Text.Replace("../", ""));
        tbIn.Add("File_Larger", fpFileLarger.Text.Replace("../", ""));
        tbIn.Add("File_Pos", txtPos.Text);
        tbIn.Add("Content_ID", p.ToString());
        tbIn.Add("File_Status", isUse);
        if (act == "add")
            UpdateData.Insert("tbl_File", tbIn);
        if (act == "edit")
            UpdateData.Update("tbl_File", tbIn, "File_ID=" + id);
        Response.Write(sScript);
    }
}
