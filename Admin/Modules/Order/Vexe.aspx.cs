using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using QCMS_BUSSINESS;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using QCMS_BUSSINESS.Repositories;
using System.Collections;
using System.Collections.ObjectModel;

public partial class Admin_Modules_Order_Vexe : System.Web.UI.Page
{
    private static OrderRepository orderRepo = new OrderRepository();
    private static NhaxeRepository nhaxeRepo = new NhaxeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string getVeByNgay(DateTime startDate, DateTime endDate)
    {
        string sql = "";
        //DateTime startDate, DateTime endDate
        sql = "select * from tbl_OrderDetail od, tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe=cx.MaChuyenXe and cx.MaXe=x.MaXe and x.Nhaxe=nx.ID and (o.Order_CreatedDate BETWEEN '" + startDate + "' and '" + endDate + "');";
        //sql = "select * from tbl_Order where Order_ID in (select o.Order_ID from tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe=cx.MaChuyenXe and cx.MaXe=x.MaXe and x.Nhaxe=nx.ID and (o.Order_CreatedDate BETWEEN '" + startDate + "' and '" + endDate + "'));";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(ds);
    }
    // Danh sách vé xe
    [WebMethod]
    public static string getAllVeXe()
    {
        string sql = "select * from tbl_OrderDetail od, tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where od.Order_ID = o.Order_ID and o.MaChuyenXe = cx.MaChuyenXe and cx.MaXe = x.MaXe and x.Nhaxe = nx.ID";
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    // Get ticket by id
    [WebMethod]
    public static string getTicketByMave(string mave)
    {
        string sql = "select * From tbl_Orderdetail where MaVe = '"+ mave +"'";
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    public void ResponseWrite(string msg)
    {
        HttpContext.Current.Response.Write(msg);
    }
    protected global::System.Web.UI.WebControls.Label lblmsg;
    private void Export(DateTime d1, DateTime d2, string searchkey)
    {
        //List<SMAC.OrderList> orders = OrderControls.GetOrderAndDetailByTime(d1, d2, searchkey);
        //try
        //{
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.ClearContent();
        //    HttpContext.Current.Response.ClearHeaders();
        //    HttpContext.Current.Response.Buffer = true;
        //    HttpContext.Current.Response.ContentType = "application/ms-excel";
        //    HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=DonHang_"+d1.ToString("dd/MM/yyyy")+"-"+ d2.ToString("dd/MM/yyyy") + ".xls");

        //    HttpContext.Current.Response.Charset = "utf-8";
        //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        //    HttpContext.Current.Response.Write("<table border='1' bgColor='#ffffff' " +
        //                  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
        //                  "style='font-size:11.0pt; font-family:Tahoma;'>");
        //    ResponseWrite("<tr>");
        //    ResponseWrite("<td colspan=\"4\" style=\"font-weight: bold; font-size:14.0pt\">DANH SÁCH ĐƠN HÀNG</td></tr>");
        //    ResponseWrite("<tr>");
        //    ResponseWrite("<td colspan=\"4\">Từ ngày "+d1.ToString("dd/MM/yyyy")+" đến ngày "+d2.ToString("dd/MM/yyyy")+" </td>");
        //    ResponseWrite("</tr>");
        //    ResponseWrite("<tr style=\"font-weight: bold;\">");
        //    ResponseWrite("<td style=' background: #ddd;'>Hàng hóa</td>");
        //    ResponseWrite("<td style=' background: #ddd;'>Giá</td>");
        //    ResponseWrite("<td style=' background: #ddd;'>SL</td>");
        //    ResponseWrite("<td style=' background: #ddd;'>Thành tiền</td>");
        //    ResponseWrite("</tr>");
        //    foreach (var item in orders)
        //    {
        //        ResponseWrite("<tr>");
        //        ResponseWrite("<td colspan=\"4\" style=\"background: yellow\">Khách hàng: " + item.Name + "- Địa chỉ: "+item.Address+" - Điện thoại: "+item.Phone+"</td>");
        //        ResponseWrite("</tr>");
        //        foreach (var j in item.OrderDetail)
        //        {
        //            ResponseWrite("<tr>");
        //            ResponseWrite("<td>"+ProductControl.GetProductByID(j.Product_ID).Name+"</td>");
        //            ResponseWrite("<td>"+j.UnitPrice+"</td>");
        //            ResponseWrite("<td>"+j.Quantity+"</td>");
        //            ResponseWrite("<td>"+j.Quantity*j.UnitPrice+"</td>");
        //            ResponseWrite("</tr>");
        //        }
        //        ResponseWrite("<tr>");
        //        ResponseWrite("<td colspan=\"3\"  style=\"background: green\">Tổng tiền</td>");
        //        ResponseWrite("<td  style=\"background: green\">" + item.Total+"</td>");
        //        ResponseWrite("</tr>");
        //    }
        //    ResponseWrite("<tr>");
        //    ResponseWrite("<td colspan=\"3\"  style=\"background: red\">Tổng cộng:</td>");
        //    ResponseWrite("<td  style=\"background: red\">" + OrderControls.GetTotalOrderList(orders)+"</td>");
        //    ResponseWrite("</tr>");
        //    HttpContext.Current.Response.Write("</table>");
        //    HttpContext.Current.Response.Flush();
        //    HttpContext.Current.Response.End();
        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
    }
}
