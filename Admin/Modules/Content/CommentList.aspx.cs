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
using QCMS_BUSSINESS.Repositories;
using System.Text;
using System.Web.Services;

public partial class Admin_Modules_Comment_CommentList : System.Web.UI.Page
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string nxid, nurl, url;


    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
        string CompanyId = Request.QueryString["CompanyId"];
        string createvote = Request.QueryString["Create"];
        if (!string.IsNullOrEmpty(CompanyId))
        {
            NhaXe NhaXe = new NhaXe();
            NhaXe = new NhaxeRepository().Find(Convert.ToInt32(CompanyId));
            namenhaxe.Text = NhaXe.Tennhaxe;

            StringBuilder str = new StringBuilder();
            string addva = "";
            addva += "<input type=\"hidden\" name=\"CompanyId\" id=\"CompanyId\" value=\"" + CompanyId + "\"/>";
            ltriph.Text = addva;
        }
        if (!string.IsNullOrEmpty(createvote))
        {
            string name = Request["firstName"];
            string email = Request["email"];
            string comment = Request["comment"];
            string CompId = Request["CompanyId"];

            string OverallRating = Request["OverallRating"];
            string VehicleQualityRating = Request["VehicleQualityRating"];
            string OnTimeRating = Request["OnTimeRating"];
            string ServiceRating = Request["ServiceRating"];

            int RatingAve = (Convert.ToInt32(OverallRating) + Convert.ToInt32(VehicleQualityRating) + Convert.ToInt32(OnTimeRating) + Convert.ToInt32(ServiceRating)) / 4;

            Hashtable tbIn = new Hashtable();

            tbIn.Add("CompanyId", CompId);
            tbIn.Add("OverallRating", OverallRating);
            tbIn.Add("QualityRating", VehicleQualityRating);
            tbIn.Add("OnTimeRating", OnTimeRating);
            tbIn.Add("ServiceRating", ServiceRating);
            tbIn.Add("RatingAverage", Convert.ToString(RatingAve));

            tbIn.Add("Comment_Content", comment);
            tbIn.Add("Comment_FullName", name);
            tbIn.Add("Comment_Email", email);

            bool _insert = UpdateData.Insert("tbl_Comment", tbIn);
            if (_insert)
            {
                Response.Redirect("/");
            }
        }
    }
    protected void BindData()
    {
        string sql = "SELECT Comment_Content as 'Nội dung', Comment_Name as 'Tên người BL', Comment_Tel as 'SĐT', Comment_Date as 'Ngày bình luận', OverallRating as 'Vote Tổng quan', QualityRating as 'Vote Chất lượng', OnTimeRating as 'Vote Đúng giờ', RatingAverage as 'Trung bình', Status as 'Trạng thái'   FROM tbl_Comment ORDER BY Comment_Date DESC";
        DataTable dtCmt = UpdateData.UpdateBySql(sql).Tables[0];
        //gvData.DataSource = dtCmt;
        //gvData.DataBind();
    }
    [WebMethod]
    public static string getAllCommentList(int nhaxe)
    {
        string sql = "GetCmtOfNhaxe";
        return Newtonsoft.Json.JsonConvert.SerializeObject(UpdateData.ExecStore(sql, nhaxe.ToString()).Tables[0]);
    }

    [WebMethod]
    public static bool ApproveComment(int cmtID)
    {
        string sql = "SELECT STATUS FROM tbl_Comment WHERE Comment_ID=" + cmtID;
        DataTable dtCmt = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = dtCmt.Rows;
        Hashtable tb = new Hashtable();
        if (rows.Count > 0) {
            foreach (DataRow item in rows)
            {
                if (item["Status"].ToString() == "1")
                {
                    tb.Add("Status", "0");
                }
                else
                {
                    tb.Add("Status", "1");
                }
            }
            bool b = UpdateData.Update("tbl_Comment", tb, "Comment_ID=" + cmtID);
            return b;
        }
        else return false;
    }
}