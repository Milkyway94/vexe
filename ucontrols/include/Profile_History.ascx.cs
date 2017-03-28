
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Profile_History : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public DataTable dsVexe = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (nurl != null)
        {
            lbnav.Text = "<li><a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li> <li>" + ModControl.GetName_From_Code(nurl) + "</li>";
        }
        else
        {
            lbnav.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(url) + "</li>";
        }
        ltrDsVeXe.Text = GetHistory();
    }
    protected string GetHistory()
    {
        var Member = Session["MemberID"];
        if (Member != null)
        {
            StringBuilder str = new StringBuilder();
            string sql = "select * from tbl_Order o, NhaXe nx, Xe x, tbl_OrderDetail od, ChuyenXe cx, tbl_Member m where o.Order_Account=m.Member_ID and o.MaChuyenXe=cx.MaChuyenXe and x.Nhaxe=nx.ID and cx.MaXe=x.MaXe and m.Member_ID=" + Member.ToString();
            DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td>"+item["MaVe"]+"</td>");
                str.Append("<td>" + item["Diemdi"] + " <i class=\"fa fa-long-arrow-right\" aria-hidden=\"true\"></i> " + item["Diemden"] + "</td>");
                str.Append("<td>" + item["Tennhaxe"] + "</td>");
                str.Append("<td>" + DateTime.Parse(item["Order_CompleteDate"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                str.Append(" <td>" + DateTime.Parse(item["Giokhoihanh"].ToString()).ToString("hh/mm") + "-"+DateTime.Parse(item["Ngaydi"].ToString()).ToString("dd/MM/yyyy")+"</td>");
                str.Append("</tr>");
            }
            return str.ToString();
        }
        else
        {
            Value.ShowMessage(ltrErr, ErrorMessage.Unauthorized, AlertType.ERROR);
            return "";
        }
    }
}