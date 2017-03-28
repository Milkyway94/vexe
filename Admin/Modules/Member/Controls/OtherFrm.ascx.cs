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

public partial class Admin_Modules_Other_Controls_OtherFrm : System.Web.UI.UserControl
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
        string sql = "SELECT Other_Name,Other_Mod,Other_Content,Other_Status FROM tbl_Other WHERE Other_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;          
        if (rows.Count > 0)
        {
            txtName.Text    = rows[0]["Other_Name"].ToString();
            txtMod.Text     = rows[0]["Other_Mod"].ToString();
            CKContent.Text  = rows[0]["Other_Content"].ToString();            
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Other_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"OtherList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Other_Name", txtName.Text);
        tbIn.Add("Other_Mod", txtMod.Text);
        tbIn.Add("Other_Content", CKContent.Text);
        tbIn.Add("Other_Status", isUse);
        if (act == "add")
        {
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Other", tbIn);
            if(_insert)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm ", "Bài: " + txtName.Text);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Other", tbIn, "Other_ID=" + id);
            if(_update)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Bài: " + txtName.Text);
        }        
        Response.Write(sScritp);
    }
}
