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
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using SMAC;
using System.Runtime.InteropServices;

public partial class Admin_Modules_Order_Default : System.Web.UI.Page
{
    protected string cs = ConfigurationManager.ConnectionStrings["vexedtEntities"].ConnectionString;
    GridView GridView1 = new GridView();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public string GetStatus(string Status)
    {
        string str = "";
        ////UtilValue u = new UtilValue();
        //string sql = "SELECT * FROM UtilValue WHERE [Key]='OrderStatus'";
        //System.Data.DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        //DataRowCollection rows = ds.Rows;
        //if (rows.Count > 0)
        //{
        //    u.Key = rows[0]["Key"].ToString();
        //    u.Value = rows[0]["Value"].ToString();
        //}
        //string jsonString = u.Value;
        //JObject root = JObject.Parse(jsonString);
        //JArray items = (JArray)root["items"];
        //JObject item;
        //JToken jtoken;
        //for (int i = 0; i < items.Count; i++) //loop through rows
        //{
        //    item = (JObject)items[i];
        //    jtoken = item.First;
        //    while (jtoken != null)//loop through columns
        //    {
        //        if (((JProperty)jtoken).Name.ToString() == "key" && ((JProperty)jtoken).Value.ToString() == Status)
        //        {
        //            jtoken = jtoken.Next;
        //            str = ((JProperty)jtoken).Value.ToString();
        //            break;
        //        }
        //        jtoken = jtoken.Next;
        //    }
        //}
        return str;
    }
    //protected List<tbl_Order> LoadOrderList()
    //{
        //List<tbl_Order> lst = new List<tbl_Order>();
        //string sql;
        //if (string.IsNullOrEmpty(txtordersearch.Text))
        //{
        //    sql = "select * from tbl_Order where Order_Status>0 order by Order_CreatedDate DESC";
        //}
        //else
        //{
        //    sql = "SELECT * FROM tbl_Order WHERE Order_Status>0 AND Order_Ten like N'%" + txtordersearch.Text + "%' OR Order_Code LIKE '%" + txtordersearch.Text + "%' ";
        //    sql += "ORDER BY Order_CreatedDate DESC";
        //}
        //System.Data.DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        //DataRowCollection rows = ds.Rows;
        //if (rows.Count > 0)
        //{
        //    for (int i = 0; i < rows.Count; i++)
        //    {
        //        tbl_Order order = new tbl_Order();
        //        order.Order_ID = int.Parse(rows[i]["Order_ID"].ToString());
        //        order.Order_Ten = rows[i]["Order_Ten"].ToString();
        //        order.Order_Tel = rows[i]["Order_Tel"].ToString();
        //        order.Order_Status = int.Parse(rows[i]["Order_Status"].ToString());
        //        order.Order_isComplete = rows[i]["Order_isComplete"].ToString() == "True";
        //        order.Order_isRead = rows[i]["Order_isRead"].ToString() == "True";
        //        order.Order_Email = rows[i]["Order_Email"].ToString();
        //        order.Order_Tongtien = double.Parse(rows[i]["Order_Tongtien"].ToString());
        //        order.Order_Type = rows[i]["Order_Type"] != null ? int.Parse(rows[i]["Order_Type"].ToString()) : -1;
        //        order.Order_Content = rows[i]["Order_Content"].ToString();
        //        order.Order_CreatedDate = DateTime.Parse(rows[i]["Order_CreatedDate"].ToString());
        //        order.Order_File = rows[i]["Order_File"].ToString();
        //        order.Order_Code = rows[i]["Order_Code"].ToString();
        //        lst.Add(order);
        //    }
        //}
       // return lst;
   // }
    public void ResponseWrite(string msg)
    {
        HttpContext.Current.Response.Write(msg);
    }


    protected void btnOrderSearch_Click(object sender, EventArgs e)
    {
       // LoadOrderList();
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DateTime d1, d2;
        if (string.IsNullOrEmpty(txtd1.Text))
        {
            d1 = new DateTime(1953, 01, 01);
        }
        else
        {
            d1 = DateTime.Parse(txtd1.Text);
        }
        if (string.IsNullOrEmpty(txtd2.Text))
        {
            d2 = new DateTime(2100, 12, 31);
        }
        else
        {
           d2= DateTime.Parse(txtd2.Text);
        }
        Export(d1, d2, txtordersearch.Text);
    }
}
