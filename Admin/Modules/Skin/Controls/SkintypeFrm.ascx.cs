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

public partial class Admin_Modules_Skin_Controls_SkintypeFrm : System.Web.UI.UserControl
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
        string sql = "SELECT * FROM tbl_Skintype WHERE Skintype_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text    = rows[0]["Skintype_Name"].ToString();
            txtCode.Text    = rows[0]["Skintype_Code"].ToString();
            txtLimit.Text   = rows[0]["Skintype_Limit"].ToString();
            txtHeight.Text  = rows[0]["Skintype_Height"].ToString();
            txtWidth.Text   = rows[0]["Skintype_Width"].ToString();
            txtHspace.Text  = rows[0]["Skintype_Hspace"].ToString();
            txtVspace.Text  = rows[0]["Skintype_Vspace"].ToString();
            string target = rows[0]["Skintype_Target"].ToString();
            if (Convert.ToBoolean(rows[0]["Skintype_Viewtype"]))
                ddlViewtype.Items[1].Selected = true;
            else
                ddlViewtype.Items[0].Selected = true;
            for (int i = 0; i < ddlTarget.Items.Count; i++)
            {
                if (target.Trim() == ddlTarget.Items[i].Value.ToString())
                    ddlTarget.Items[i].Selected = true;
            }
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"SkintypeList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        tbIn.Add("Skintype_Name", txtName.Text);
        tbIn.Add("Skintype_Code", txtCode.Text);
        tbIn.Add("Skintype_Limit", txtLimit.Text);
        tbIn.Add("Skintype_Height", txtHeight.Text);
        tbIn.Add("Skintype_Width", txtWidth.Text);
        tbIn.Add("Skintype_Hspace", txtHspace.Text);
        tbIn.Add("Skintype_Vspace", txtVspace.Text);
        tbIn.Add("Skintype_Viewtype", ddlViewtype.SelectedValue.ToString());
        tbIn.Add("Skintype_Target", ddlTarget.SelectedItem.ToString());
        if (act == "add")
        {            
            bool _insert = UpdateData.Insert("tbl_Skintype", tbIn);            
            Response.Write(sScritp);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Skintype", tbIn, "Skintype_ID=" + id);            
            Response.Write(sScritp);
        }
    }
}
