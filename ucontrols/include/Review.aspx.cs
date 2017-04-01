using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using System.Collections;

public partial class ucontrols_include_Review : Page
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string nxid, nurl, url;


    protected void Page_Load(object sender, EventArgs e)
    {
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
}