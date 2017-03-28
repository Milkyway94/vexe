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

public partial class Administrator_Modules_User_Controls_UserFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id, pbid;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Request["id"];
        pbid = Request["pbid"];
        if (!IsPostBack)
        {
            this.loadDepartment();
            this.LoadRole();
            if (act == "add")
            {
                for (int i = 0; i < ddlPb.Items.Count; i++)
                {
                    if (ddlPb.Items[i].Value == pbid)
                        ddlPb.Items[i].Selected = true;
                }
                for (int i = 0; i < dllRole.Items.Count; i++)
                {
                    if (dllRole.Items[i].Value == pbid)
                        dllRole.Items[i].Selected = true;
                }
            }
            if (act == "edit")      
            {
                txtUser.Enabled = false;
                ViewEdit(id);
            }
        }
    }
    public void loadDepartment()
    {
        DataSet dsPB = UpdateData.UpdateBySql("SELECT Department_ID,Department_Name FROM tbl_Department ORDER BY Department_Pos");
        DataRowCollection rows = dsPB.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            ddlPb.Items.Insert(i, new ListItem("--" + rows[i]["Department_Name"].ToString(), rows[i]["Department_ID"].ToString()));
        }
    }
    public void LoadRole()
    {
        DataSet dsPB = UpdateData.UpdateBySql("SELECT * FROM tbl_Role ORDER BY Role_ID");
        DataRowCollection rows = dsPB.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            dllRole.Items.Insert(i, new ListItem("--" + rows[i]["Role_Name"].ToString(), rows[i]["Role_ID"].ToString()));
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_User WHERE User_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text = rows[0]["User_Name"].ToString();
            txtAddress.Text = rows[0]["User_Address"].ToString();
            txtMobile.Text = rows[0]["User_Mobile"].ToString();
            txtInfo.Text = rows[0]["User_Info"].ToString();
            txtTel.Text = rows[0]["User_Tel"].ToString();
            txtUser.Text = rows[0]["username"].ToString();
            txtEmail.Text = rows[0]["User_Email"].ToString();
            txtOrder.Text = rows[0]["User_Pos"].ToString();
            txtImg.Text = rows[0]["User_Img"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["User_Status"]) == true) ? true : false; 
            for (int i = 0; i < ddlPb.Items.Count; i++)
            {
                if (ddlPb.Items[i].Value == rows[0]["pb_ID"].ToString())
                    ddlPb.Items[i].Selected = true;
            }
            for (int i = 0; i < dllRole.Items.Count; i++)
            {
                if (dllRole.Items[i].Value == rows[0]["User_Role"].ToString())
                    dllRole.Items[i].Selected = true;
            }
            bool sex = Convert.ToBoolean(rows[0]["User_Sex"]);
            rbSex.Items[0].Selected = (sex == true) ? true : false;
            rbSex.Items[1].Selected = (sex == false) ? true : false;            
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScript = "<script>";
        sScript += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScript += "b.attachURL(\"UserList.aspx?pbid=" + pbid + "\");";
        sScript += "window.close();";
        sScript += "</script>";

        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        string sex = ((rbSex.Items[0].Selected == true) ? "1" : "0");
        string pass = ApplicationUtil.PasswordEncrypt(txtPass.Text);
        string user = txtUser.Text;

        tbIn.Add("User_Email", txtEmail.Text);        
        tbIn.Add("pb_ID", ddlPb.SelectedValue);
        tbIn.Add("User_Name", txtName.Text);        
        tbIn.Add("User_Tel", txtTel.Text);
        tbIn.Add("User_Mobile", txtMobile.Text);
        tbIn.Add("User_Address", txtAddress.Text);
        tbIn.Add("User_Info", txtInfo.Text);
        tbIn.Add("User_Sex", sex);
        tbIn.Add("User_Status", isUse);
        tbIn.Add("User_Pos", txtOrder.Text);
        tbIn.Add("User_Img", txtImg.Text.Replace("/upload", "upload"));
        tbIn.Add("User_Role", dllRole.SelectedValue);
        if (act == "add")
        {
            if (!FunctionDB.CheckUser(user))
            {
                tbIn.Add("Username", user);
                tbIn.Add("User_Pass", pass.ToString());
                bool _insert = UpdateData.Insert("tbl_User", tbIn);
                if (_insert)
                    FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm ", "Thành viên: " + user);
            }
            else
            {
                lblMsg.Text = "Email của bạn đã tồn tại. Vui lòng chọn email khác!";
            }
        }
        if (act == "edit")
        {
            if (txtPass.Text != string.Empty)
                tbIn.Add("User_Pass", pass.ToString());
            bool _update = UpdateData.Update("tbl_User", tbIn, "User_ID=" + id);
            FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Thành viên: " + user);
        }
        Response.Write(sScript);
    }
}
