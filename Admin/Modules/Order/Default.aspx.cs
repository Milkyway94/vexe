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

public partial class Admin_Modules_Order_Default : System.Web.UI.Page
{
    private static OrderRepository orderRepo = new OrderRepository();
    private static NhaxeRepository nhaxeRepo = new NhaxeRepository();
    protected string cs = ConfigurationManager.ConnectionStrings["vexedtEntities"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Test NhaXe
    [WebMethod]
    public static List<NhaXe> GetAllNhaXe()
    {
        return nhaxeRepo.All().ToList();
    }
    [WebMethod]
    public static string getOrderByDate(string tenNhaXe, string startDate, string endDate)
    {
        string sql = "";
        //DateTime startDate, DateTime endDate
        sql = "select * from tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe=cx.MaChuyenXe and cx.MaXe=x.MaXe and x.Nhaxe=nx.ID and nx.Tennhaxe like N'%"+ tenNhaXe + "%' and (o.Order_CreatedDate BETWEEN '" + startDate + "' and '" + endDate + "');";
        //sql = "select * from tbl_Order where Order_ID in (select o.Order_ID from tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe=cx.MaChuyenXe and cx.MaXe=x.MaXe and x.Nhaxe=nx.ID and (o.Order_CreatedDate BETWEEN '" + startDate + "' and '" + endDate + "'));";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
       
        return JsonConvert.SerializeObject(ds);
    }
    //Order Detail
    [WebMethod]
    public static string getOrderDetailByOID(int oid)
    {
        string sql = "select * From tbl_Orderdetail where Order_ID = " + oid;
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    [WebMethod]
    public static string getAllOrderDetail()
    {
        string sql = "select * from tbl_OrderDetail";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("[");
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("{");
                str.Append("\"Order_ID\":\"" + rows[i]["Order_ID"] + "\",\"MaVe\":\"" + rows[i]["Mave"] + "\",\"UnitPrice\":\"" + rows[i]["unitPrice"] + "\",\"Type\":\"" + rows[i]["Type"] + "\",\"isTimeOut\":\"" + rows[i]["isTimeOut"] + "\"");
                str.Append("}");
                if (i < rows.Count - 1)
                {
                    str.Append(",");
                }
            }
            str.Append("]");
        }
        return str.ToString();
    }
    //public static string getMemberByOID()
    //{
        
    //}
    //Order
    [WebMethod]
    public static List<tbl_Order> getAllOrder()
    {
        var rs= orderRepo.All().ToList();
        foreach (var item in rs)
        {
            item.tbl_Member = new tbl_Member(); 
        }
        return rs;
    }
    //Get  all order by sql
    [WebMethod]
    public static string getAllOrderBySql()
    {
        //string sql = "select * from tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe = cx.MaChuyenXe and cx.MaXe = x.MaXe and x.Nhaxe = nx.ID";
        //DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        DataTable dt = UpdateData.ExecStore("SP_GetOrderByNhaxe", SessionUtil.GetValue("UserID")).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    [WebMethod]
    public static string getNhaxeByMacx(int macx)
    {
        string sql = "select * from tbl_Order o, ChuyenXe cx, Xe x, NhaXe nx where o.MaChuyenXe = cx.MaChuyenXe and cx.MaXe = x.MaXe and x.Nhaxe = nx.ID";
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);

    }
    [WebMethod]
    public static string getMemberByOrderAcc(int accId)
    {
        string sql = "SELECT * FROM tbl_Member WHERE Member_ID=" + accId;
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    [WebMethod]
    public static string getTotal()
    {
        var rs = orderRepo.All().ToList();
        double Total = 0;
        foreach (var item in rs)
        {
            Total += double.Parse(item.Order_TongThanhToan.ToString());
        }
        return Total.ToString();
    }
    [WebMethod]
    public static string getTongTien()
    {
        string sql = "select Sum(Order_TongTien) as TongTien from tbl_Order;";
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(dt);
    }
    [WebMethod]
    public static tbl_Order DeleteOrderByID(int oid)
    {
        var od = orderRepo.Find(oid);
        var res = orderRepo.Remove(od);
        orderRepo.Save();
        return res;
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
