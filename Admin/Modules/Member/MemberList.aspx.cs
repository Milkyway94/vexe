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
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=Member.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
        //Response.ContentType = "application/vnd.ms-excel";
        Response.BufferOutput = true;
        //Response.ContentEncoding = System.Text.Encoding.UTF8;
        //Response.Charset = "UTF-8";
        EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gvMember.AllowPaging = false;
        gvMember.DataBind();

        //Change the Header Row back to white color 
        gvMember.HeaderRow.Style.Add("background-color", "#ccc");
        gvMember.HeaderRow.Style.Add("Font", "Times New Roman");
        gvMember.HeaderRow.Font.Name = "Times New Roman";
        gvMember.HeaderRow.Font.Size = 12;

        gvMember.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }
}
