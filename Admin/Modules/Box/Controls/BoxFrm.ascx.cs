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

public partial class Admin_Modules_Box_Controls_BoxFrm: System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id, BoxID;
    protected void Page_Load(object sender, EventArgs e)
    {
        BoxID = Request["BoxID"];
        act = Request["act"];
        id = Request["id"];
        if (!IsPostBack)
        {
            DataSet dsBox = UpdateData.UpdateBySql("SELECT * FROM tbl_Boxtype WHERE lang=" + Session["lang"]);
            DataRowCollection rows = dsBox.Tables[0].Rows;
            ddlBoxtype.Items.Add(new ListItem("Mục gốc", "0"));
            for (int i = 0; i < rows.Count; i++)
            {
                ddlBoxtype.Items.Insert(i + 1, new ListItem(":.. " + rows[i]["Boxtype_Name"].ToString(), rows[i]["Boxtype_ID"].ToString()));
            }
            if (act == "edit")
            {
                ViewEdit(id);
            }
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Box WHERE Box_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["Box_Name"].ToString();
            txtCode.Text = rows[0]["Box_Code"].ToString();
            txtPos.Text = rows[0]["Box_Pos"].ToString();
            txtImg.Text = rows[0]["Box_Img"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Box_Status"]) == true) ? true : false;
            for (int i = 0; i < ddlBoxtype.Items.Count; i++)
            {
                if (rows[0]["Box_Type"].ToString() == ddlBoxtype.Items[i].Value)
                {                    
                    ddlBoxtype.Items[i].Selected = true;                 
                }
            }
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScript = "<script>";
        sScript += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScript += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScript += "a.attachURL(\"Tree.aspx\");";
        sScript += "b.attachURL(\"BoxList.aspx?BoxID=" + ddlBoxtype.SelectedValue + "\");";
        sScript += "window.close();";
        sScript += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Box_Type", ddlBoxtype.SelectedValue);
        tbIn.Add("Box_Name", txtName.Text);
        tbIn.Add("Box_Code", txtCode.Text);
        tbIn.Add("Box_Pos", txtPos.Text);
        tbIn.Add("Box_Img", txtImg.Text.Replace("/upload", "upload"));
        tbIn.Add("Box_Status", isUse);
        if (act == "add")
        {           
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Box", tbIn);
            if(_insert)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm", "Thành phần: " + txtName.Text);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Box", tbIn, "Box_ID=" + id);
            if(_update)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Thành phần: " + txtName.Text);
        }
        Response.Write(sScript);
    }
}
