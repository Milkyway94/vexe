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

public partial class Admin_Modules_Comment_Controls_CommentFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, cid, id, TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        TopicID = Request["TopicID"];
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
        string sql = "SELECT * FROM tbl_Comment WHERE Comment_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;          
        if (rows.Count > 0)
        {
            txtTitle.Text = rows[0]["Comment_Name"].ToString();
            txtName.Text = rows[0]["Comment_FullName"].ToString();
            txtEmail.Text = rows[0]["Comment_Email"].ToString();
            txtAddress.Text = rows[0]["Comment_Address"].ToString();
            txtTel.Text = rows[0]["Comment_Tel"].ToString();
            CKContent.Text = rows[0]["Comment_Content"].ToString();            
            txtPos.Text         = rows[0]["Comment_Pos"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Comment_Status"]) == true) ? true : false;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"ContentList.aspx?TopicID=" + TopicID + "\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        tbIn.Add("Comment_Name", txtTitle.Text);
        tbIn.Add("Comment_FullName", txtName.Text);
        tbIn.Add("Comment_Email", txtEmail.Text);
        tbIn.Add("Comment_Address", txtAddress.Text);
        tbIn.Add("Comment_Tel", txtTel.Text);
        tbIn.Add("Comment_Content", CKContent.Text);
        tbIn.Add("Comment_Pos", txtPos.Text);
        tbIn.Add("Comment_Status", isUse);
        if (act == "add")
        {
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Comment", tbIn);
            if(_insert)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm ", "Bài: " + txtName.Text);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Comment", tbIn, "Comment_ID=" + id);
            if(_update)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Bài: " + txtName.Text);
        }        
        Response.Write(sScritp);
    }
}
