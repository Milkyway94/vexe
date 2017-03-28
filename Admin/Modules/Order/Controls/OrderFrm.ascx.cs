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

public partial class Admin_Modules_Other_Controls_OrderFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Request["id"];
        if (!IsPostBack)
        {
            BindDropdownUser();
            DataSet ds = UpdateData.UpdateBySql("select * from tbl_ProductFactory");
            DataRowCollection rows = ds.Tables[0].Rows;
            if (act == "edit")
            {
                ViewEdit(id);
            }
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_ProductFactory WHERE PF_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtCode.Text = rows[0]["PF_Code"].ToString();
            txtName.Text = rows[0]["PF_Name"].ToString();
            txtTotal.Text = rows[0]["PF_Total"].ToString();
            txtBeginDate.Text = rows[0]["PF_StartDate"].ToString();
            txtDGQ.Text = rows[0]["PF_DeliveriedQuantity"].ToString();
            txtExpectedDate.Text = rows[0]["PF_ExpectedCompleteDate"].ToString();
        }
    }
    protected void BindDropdownUser()
    {
        string sql = "SELECT * FROM tbl_User where User_Role in (Select Role_ID from tbl_Role where Role_ID=1)";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            ddlUser.Items.Add(new ListItem(rows[i]["username"].ToString()+"(" + rows[i]["User_Name"].ToString() + ")", rows[i]["User_ID"].ToString()));
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "window.close();";
        sScritp += "window.location.hef=\"Admin/Modules/Order\"";
        sScritp += "</script>";
        Hashtable tbIn = new Hashtable();
        tbIn.Add("PF_Code", txtCode.Text);
        tbIn.Add("PF_Name", txtName.Text);
        tbIn.Add("PF_Total", txtTotal.Text);
        tbIn.Add("PF_StartDate", txtBeginDate.Text);
        tbIn.Add("PF_DeliveriedQuantity", txtDGQ.Text);
        tbIn.Add("PF_ExpectedCompleteDate", txtExpectedDate.Text);
        tbIn.Add("UserID", ddlUser.SelectedValue);
        tbIn.Add("PF_Status", "1");
        if (act == "add")
        {
            bool _insert = UpdateData.Insert("tbl_ProductFactory", tbIn);
            if (_insert)
            {
                Response.Write(sScritp);
            }
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_ProductFactory", tbIn, "PF_ID=" + id);
            if (_update)
            {
                Response.Write(sScritp);
            }
        }


        //   Hashtable tbIn = new Hashtable();
        //    string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        //    tbIn.Add("Other_Name", txtName.Text);
        //    tbIn.Add("Other_Mod", txtMod.Text);
        //    tbIn.Add("Other_Content", CKContent.Text);
        //    tbIn.Add("Other_Status", isUse);
        //if (act == "add")
        //    {
        //        tbIn.Add("lang", Session["lang"].ToString());
        //        bool _insert = UpdateData.Insert("tbl_Other", tbIn);
        //        if(_insert)
        //            FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm ", "Bài: " + txtName.Text);
        //    }
        //    if (act == "edit")
        //    {
        //        bool _update = UpdateData.Update("tbl_Other", tbIn, "Other_ID=" + id);
        //        if(_update)
        //            FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Bài: " + txtName.Text);
        //    }        
        //   Response.Write(sScritp);
    }
}
