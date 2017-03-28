using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.Security.AccessControl;

namespace SMAC
{
    public class ExportData
    {
        public static HttpResponse Response = HttpContext.Current.Response;
        public static void ExportToWord(System.Data.DataTable dt, string filename)
        {
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
                "attachment;filename=" + filename + ".doc");
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        //public static void ExportToExcel(string fileName, DateTime d1, DateTime d2, string serchkey)
        //{
        //    Microsoft.Office.Interop.Excel.Application oXL;
        //    Microsoft.Office.Interop.Excel._Workbook oWB;
        //    Microsoft.Office.Interop.Excel._Worksheet oSheet;
        //    object misvalue = System.Reflection.Missing.Value;
        //    try
        //    {
        //        List<OrderList> orders = OrderControls.GetOrderAndDetailByTime(d1, d2, serchkey);
        //        //Start Excel and get Application object.
        //        oXL = new Microsoft.Office.Interop.Excel.Application();
        //        oXL.Visible = true;

        //        //Get a new workbook.
        //        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
        //        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

        //        //Add table headers going cell by cell.
        //        var range = oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[4, 2]];
        //        range.Merge(true);
        //        range.Font.Bold = true;
        //        range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //        range.HorizontalAlignment = HorizontalAlign.Center;
        //        range.Merge(true);
        //        oSheet.Cells[2, 1] = "DANH SÁCH ĐƠN HÀNG";

        //        oSheet.Cells[3, 1] = "Từ ngày " + d1.ToString("dd/MM/yyyy") + " Đến ngày " + d2.ToString("dd/MM/yyyy");
        //        oSheet.Cells[5, 1] = "Hàng hóa";
        //        oSheet.Cells[5, 2] = "Giá";
        //        oSheet.Cells[5, 3] = "Số lượng";
        //        oSheet.Cells[5, 4] = "Thành tiền";
        //        int k = 6;
        //        for (int i = 0; i < orders.Count; i++)
        //        {
        //            var dtcount = orders[i].OrderDetail.Count;
        //            oSheet.Cells[k, 1] = "KH " + orders[i].Name + " - Địa chỉ: " + orders[i].Address + " - SĐT: " + orders[i].Name;
        //            oSheet.Range["A" + k, "D" + k].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
        //            for (int j = 0; j < dtcount; j++)
        //            {
        //                k++;
        //                oSheet.Cells[k, 1] = ProductControl.GetProductByID(orders[i].OrderDetail[j].Product_ID).Name;
        //                oSheet.Cells[k, 2] = orders[i].OrderDetail[j].UnitPrice;
        //                oSheet.Cells[k, 3] = orders[i].OrderDetail[j].Quantity;
        //                oSheet.Cells[k, 4] = orders[i].OrderDetail[j].UnitPrice * orders[i].OrderDetail[j].Quantity;
        //            }
        //            k++;
        //            oSheet.Cells[k, 1] = "Tổng tiền";
        //            oSheet.Cells[k, 2] = orders[i].Total;
        //            oSheet.Range["A" + k, "D" + k].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
        //            k++;
        //        }
        //        k++;
        //        oSheet.Cells[k, 1] = "Tổng cộng tất cả: ";
        //        oSheet.Cells[k, 2] = orders.Sum(o => o.Total);
        //        oSheet.Range["A" + k, "D" + k].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        //        oSheet.Range["A1", "D" + k].Borders.Color = System.Drawing.Color.Black;
        //        oSheet.Columns.AutoFit();
        //        oXL.UserControl = false;
        //        oXL.Visible = false;
        //        //oWB.SaveCopyAs(fileName);
        //        oWB.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
        //            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        //            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        oWB.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void ExportToPDF(DataTable dt, string filename)
        //{
        //    GridView GridView1 = new GridView();
        //    GridView1.AllowPaging = false;
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition",
        //        "attachment;filename=" + filename + ".pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.RenderControl(hw);
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}
    }
}
