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
        ltrPioriryFrom.Text = LoadPiorityFrom();
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
            str.Append("<option value='" + item.MaTinh + "'>" + item.TenTinh + "</option>");
        }
        return str.ToString();
    }
    protected string LoadPiorityFrom()
    {
        StringBuilder strFr = new StringBuilder();


        DataTable dtfrom = UpdateData.ExecStore("SP_TUYENNOIBAT", "").Tables[0];
        DataRowCollection rows = dtfrom.Rows;
        if (rows.Count > 0)
        {
            strFr.Append("<ul class=\"nav nav-pills\">");
            for (int i = 0; i < rows.Count; i++)
            {
                string active = i == 0 ? "active" : "";
                strFr.Append("<li class=\"" + active + "\"><a data-toggle=\"pill\" href=\"#0\">" + rows[0]["TenTinh"] + "</a></li>");
            }
            strFr.Append("</ul>");
            strFr.Append("<div class=\"tab-content\">");
            for (int i = 0; i < rows.Count; i++)
            {
                string active = i == 0 ? "active" : "";
                strFr.Append("<div id=\"0\" class=\"tab-pane fade in " + active + "\">");
                strFr.Append("<div class=\"row\">");
                DataTable stChuyenxe = UpdateData.ExecStore("SP_GETCHUYENXEFROMDITINH", rows[i]["MaTinh"].ToString()).Tables[0];
                DataRowCollection rowcx = stChuyenxe.Rows;
                if (rowcx.Count > 0)
                {
                    for (int j = 0; j < rowcx.Count; j++)
                    {
                        strFr.Append("<div class=\"col-sm-6 popular\">");
                        strFr.Append("  <div class=\"col-sm-5 name\">");
                        strFr.Append("      <span class=\"diemdi\">" + rowcx[i]["TinhDi"] + "</span>");
                        strFr.Append("      <span class=\"fa fa-long-arrow-right muiten\"></span>");
                        strFr.Append("      <span class=\"diemden\">" + rowcx[i]["TinhDen"] + "</span>");
                        strFr.Append("  </div>");
                        strFr.Append("  <div class=\"col-sm-4 name\">");
                        strFr.Append("      <span class=\"gia\">" + double.Parse(rowcx[i]["Gia"].ToString()).ToString("N0") + " đ/vé</span>");
                        strFr.Append("  </div>");
                        strFr.Append("  <div class=\"col-sm-3 btn-area\">");
                        strFr.Append("      <a href = \"/tim-ve-xe.htm?Diemdi="+ rowcx[i]["TinhDi"] + "&Diemden="+ rowcx[i]["TinhDen"] + "&Giodi=\" class=\"btn btn-flat btn-datve\">Đặt vé</a>");
                        strFr.Append("  </div>");
                        strFr.Append("</div>");
                        
                    }
                }
               strFr.Append("</div>");
                strFr.Append("</div>");
                strFr.Append("</div>");
            }
        }

        return strFr.ToString();
    }
    protected string LoadPopularTravel()
    {
        StringBuilder str = new StringBuilder();
        DataTable dtfrom = UpdateData.ExecStore("SP_TUYENNOIBA6T", "").Tables[0];
        DataRowCollection rows = dtfrom.Rows;
        if (rows.Count > 0)
        {
            str.Append("<li class=\"active\"><a data-toggle=\"pill\" href=\"#0\">" + rows[0]["TenTinh"] + "</a></li>");
            for (int i = 1; i < rows.Count; i++)
            {
                str.Append("<li><a data-toggle=\"pill\" href=\"#" + i + "\">" + rows[0]["TenTinh"] + "</a></li>");
            }
        }
        return str.ToString();
    }
    protected List<NhaXe> lstNhaxe()
    {
        return new NhaxeRepository().All().ToList();
    } 
}