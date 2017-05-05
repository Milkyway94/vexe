
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_doSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrPioriryFrom.Text = LoadPiorityFrom();
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
                        strFr.Append("      <span class=\"diemdi\">" + rowcx[j]["TinhDi"] + "</span>");
                        strFr.Append("      <span class=\"fa fa-long-arrow-right muiten\"></span>");
                        strFr.Append("      <span class=\"diemden\">" + rowcx[j]["TinhDen"] + "</span>");
                        strFr.Append("  </div>");
                        strFr.Append("  <div class=\"col-sm-4 name\">");
                        strFr.Append("      <span class=\"gia\">" + double.Parse(rowcx[j]["Gia"].ToString()).ToString("N0") + " đ/vé</span>");
                        strFr.Append("  </div>");
                        strFr.Append("  <div class=\"col-sm-3 btn-area\">");
                        strFr.Append("      <a href = \"/ket-qua-tim-kiem-ve-xe.htm?di-tu=" + rowcx[j]["TinhDi"] + "&den=" + rowcx[j]["TinhDen"] + "\" class=\"btn btn-flat btn-datve\">Đặt vé</a>");
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
}