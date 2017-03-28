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
using System.Data.SqlClient;

public partial class Admin_Modules_Member_MemberList : System.Web.UI.Page
{
    public string tp = "../../Themes/";
    public int TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //int i = 0;
        //string sql = null;
        //string connetionString = "Data Source=.;Initial Catalog=apec_db;User ID=sa;Password=sql2012@#$";
        //sql = "select Member_ID,Member_Name,Member_Email,Member_Phone,Member_Address,Member_Date from tbl_Member";
        //SqlConnection connection = new SqlConnection(connetionString);
        //connection.Open();
        //SqlCommand command = new SqlCommand(sql, connection);
        //adapter.SelectCommand = command;
        //adapter.Fill(ds);
        //connection.Close();
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
        //string sql = "SELECT Member_ID,Member_Name,Member_Email,Member_Phone,Member_Address,Member_Date FROM tbl_Member";
        //DataSet dsData = UpdateData.UpdateBySql(sql);
        //Session["dsData"] = dsData;
        //gvMember.DataSource = dsData.Tables[0];
        //string[] arrKey01 = { "Member_ID" };
        //gvMember.DataKeyNames = arrKey01;
        //gvMember.DataBind();
    }
    //protected void btntoExcel_Click(object sender, EventArgs e)
    //{
    //    Response.ClearContent();
    //    Response.AddHeader("content-disposition", "attachment; filename=gvtoexcel.xls");
    //    Response.ContentType = "application/excel";
    //    System.IO.StringWriter sw = new System.IO.StringWriter();
    //    HtmlTextWriter htw = new HtmlTextWriter(sw);
    //    gvMember.RenderControl(htw);
    //    Response.Write(sw.ToString());
    //    Response.End();
    //}
    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }
}
