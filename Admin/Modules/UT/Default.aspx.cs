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
using QCMS_BUSSINESS;

public partial class Admin_Modules_Content_Default : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int TopicID;

    protected void Page_Load(object sender, EventArgs e)
    {
        string nx = "SELECT * FROM tbl_ModAdmin WHERE ModAdmin_ID=" + 35;
        DataTable dtx = UpdateData.UpdateBySql(nx).Tables[0];
        if (dtx.Rows.Count > 0)
        {
            DataSet dsData = UpdateData.ExecStore(dtx.Rows[0]["OnLoad"].ToString(), "");
            Session["dsData"] = dsData;
            gvMember.DataSource = dsData.Tables[0];
            gvMember.DataBind();
        }
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
