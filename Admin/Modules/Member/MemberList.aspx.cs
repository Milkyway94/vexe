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

public partial class Admin_Modules_Member_MemberList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "SELECT Member_ID,Member_Name,Member_Email,Member_Phone,Member_Address,Member_Date FROM tbl_Member";
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvMember.DataSource = dsData.Tables[0];
        string[] arrKey01 = { "Member_ID" };
        gvMember.DataKeyNames = arrKey01;
        gvMember.DataBind();
    }
    protected void btntoExcel_Click(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM tbl_Member";
        DataSet dsData = UpdateData.UpdateBySql(sql);
        SMAC.ExportData.ExportToExcel(gvMember, "member.xls");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }
}
