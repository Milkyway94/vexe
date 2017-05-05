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
using System.Text;
using SMAC;
using System.Collections.Generic;
using System.Drawing;
using QCMS_BUSSINESS.Repositories;
using QCMS_BUSSINESS;
using System.Linq;

public partial class ucontrols_include_Home : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        string status = Request["status"] == null ? "" : Request["status"];
        ltrbanner.Text = LoadSlider(status);
        ltrListRequest.Text = LoadRequestTravel();
        CMSfunc.checkURL();
        if (IsPostBack)
        {
            
        }
    }
    protected string LoadSlider(string status)
    {
        StringBuilder str = new StringBuilder();
        string bncouter = "";
        string sql = "select * from tbl_Skin where Skintype_ID=1 and Skin_Status=1 and lang=" + Session["vlang"];
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if (rows.Count > 0)
        {
            bncouter += "<li data-target=\"#myCarousel\" data-slide-to=\"" + 0 + "\" class=\"active\"></li>";
            str.Append("<div class=\"item active\"><a target='_blank' href=\"" + rows[0]["Skin_Link"] + "\">");
            str.Append("<img alt=\"Banner\" class=\"img-responsive\" src=\"" + rows[0]["Skin_Url"] + "\"/>");
            str.Append("</a></div>");
            for (int i = 1; i < rows.Count; i++)
            {
                str.Append("<div class=\"item \"><a target='_blank' href=\"" + rows[i]["Skin_Link"] + "\">");
                str.Append("<img alt=\"Banner\" class=\"img-responsive\" src=\"" + rows[i]["Skin_Url"] + "\"/>");
                str.Append("</a></div>");
                bncouter += "<li data-target=\"#myCarousel\" data-slide-to=\"" + i + "\"></li>";
            }

            ltrbannercouter.Text = bncouter;
        }
        return str.ToString();
    }
    protected string LoadProvince()
    {
        ProvinceRepository prorepo = new ProvinceRepository();
        StringBuilder str = new StringBuilder("");
        foreach (var item in prorepo.All())
        {
            str.Append("<option value='"+item.MaTinh+"'>"+item.TenTinh+"</option>");
        }
        return str.ToString();
    }
    protected string LoadRequestTravel()
    {
        if (SessionUtil.GetValue("UserID") == "") return "";
        StringBuilder str = new StringBuilder();
        int memID = int.Parse(SessionUtil.GetValue("UserID"));
        string sql = "SELECT Diemdi, Diemden FROM tbl_User m join User_NhaXe un on m.User_ID=un.UserID join Nhaxe nx on nx.ID=un.NhaxeId join Xe xe on xe.Nhaxe=nx.ID join ChuyenXe cx on cx.MaXe=xe.MaXe WHERE m.User_ID="+memID;
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = dt.Rows;
        foreach (DataRow item in rows)
        {
            string diemdi = item["Diemdi"].ToString();
            string diemden = item["Diemden"].ToString();
            var rq = new RequestRepository().SearchFor(o => o.From.Contains(diemdi) || diemdi.Contains(o.From) && diemden.Contains(o.To) || o.To.Contains(diemden)).ToList();
            var i = 1;
            foreach (var item2 in rq)
            {
                str.Append("<tr>");
                str.Append("<td>" +i+ "</td>");
                str.Append("<td>" + diemdi + "</td>");
                str.Append("<td>" + diemden + "</td>");
                str.Append("<td>" + item2.Sdt + "</td>");
                str.Append("<td>" + item2.StartDate.Value.ToString("dd/MM/yyyy") + "</td>");
                str.Append("<td>" + item2.StartTime.Value.ToString("hh:mm") + "</td>");
                str.Append("<td>" + item2.More + "</td>");
                str.Append("</tr>");
                i++;
            }
        }
        return str.ToString();
    }
}