using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Search : System.Web.UI.UserControl
{
    public string strXuatphat, strDich, strNgaydi, strThoigiandi;
    public int p;
    public tbl_Member member = new tbl_Member();
    public RequestTravel rq = new RequestTravel();
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(u);
        ltrAdvertisment.Text = GetAdvertisment(p);

        if (Session["MemberID"] != null)
        {
            string memberID= Session["MemberID"].ToString();
            UpdateRequestTimeOut();
            rq = new RequestRepository().SearchFor(o => o.CreateBy == memberID && o.isCancel == false).OrderByDescending(o => o.CreateDate).FirstOrDefault();
            member = new MemberRepository().Find(int.Parse(Session["MemberID"].ToString()));
        }
    }
    protected string GetAdvertisment(int p)
    {
        StringBuilder adStr = new StringBuilder();
        string sql = "SELECT * FROM tbl_Skin WHERE Mod_Id=" + p +" AND Skin_status!=0 AND lang="+Session["vlang"] +" ORDER BY Skin_Pos";
        DataSet result = UpdateData.UpdateBySql(sql);
        if (result != null)
        {
            foreach (DataRow item in result.Tables[0].Rows)
            {
                adStr.Append("<a class='skin' href=\"" + item["Skin_Link"] + "\"><img class=\"img-responsive\" src=\"" + item["Skin_Url"] + "\" alt=\"" + item["Skin_Link"] + "\"></a>");
            }
        }
        return adStr.ToString();
    }
    protected bool? isRequestTimeOut()
    {
        var MemberID = Session["MemberID"];
        if (MemberID != null)
        {
            TimeSpan time = new TimeSpan(int.Parse(CMSfunc._GetConst("_AutoCancelTime")), 0,0);
            if(rq!=new RequestTravel())
            {
                if (rq.CreateDate.HasValue)
                {
                    TimeSpan timediff = Value.DiffTime(rq.CreateDate.Value.ToString(), DateTime.Now.ToString());
                    return time > timediff;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    protected void UpdateRequestTimeOut()
    {
        var MemberID = Session["MemberID"];
        if (isRequestTimeOut().HasValue)
        {
            if (isRequestTimeOut().Value)
            {
                Hashtable tbIn = new Hashtable();
                tbIn.Add("isCancel", 1);
                bool _update = UpdateData.Update("RequestTravel", tbIn, "ID=" + rq.ID);
                if (_update)
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }
    }
}