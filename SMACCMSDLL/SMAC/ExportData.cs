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

        public static void ExportToExcel(GridView gvMember, string filename)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename="+filename+".xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //Response.ContentType = "application/vnd.ms-excel";
            Response.BufferOutput = true;
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.Charset = "UTF-8";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            //Change the Header Row back to white color 
            gvMember.HeaderRow.Style.Add("background-color", "#ccc");
            gvMember.HeaderRow.Style.Add("Font", "Times New Roman");
            gvMember.HeaderRow.Font.Name = "Times New Roman";
            gvMember.HeaderRow.Font.Size = 12;

            gvMember.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
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
