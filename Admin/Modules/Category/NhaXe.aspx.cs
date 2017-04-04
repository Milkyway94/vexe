using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;
using System.IO;
using SMAC;

public partial class Admin_Modules_Category_NhaXe : System.Web.UI.Page
{
    private static NhaxeRepository nhaxeRepo = new NhaxeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected static void ExportTableToExcel(object dt)
    {
        //Create a dummy GridView
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = dt;
        GridView1.DataBind();

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition",
         "attachment;filename=DataTable.xls");
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //Apply text style to each Row
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Output.Write(sw.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    public static DataTable ToDataTable<T>(List<T> data)
    {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();

        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            //table.Columns.Add(prop.Name, prop.PropertyType);
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType); // to avoid nullable types
        }

        object[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }

            table.Rows.Add(values);
        }
        return table;
    }
    
    [WebMethod]
    public static string GetAllNhaXe()
    {
        return JsonConvert.SerializeObject(UpdateData.ExecStore("SP_GetAllNhaXe", SessionUtil.GetValue("UserID")).Tables[0]);
    }
    [WebMethod]
    public static NhaXe CreateNhaXe(string Tennhaxe, int Soluongxe, string Trusochinh, string Nguoidaidien, string Sodienthoai, string Gioithieungan, string Gioithieuchitiet)
    {
        var nx = nhaxeRepo.Add(new NhaXe
        {
            Tennhaxe = Tennhaxe,
            Sodienthoai = Sodienthoai,
            Trusochinh = Trusochinh,
            Soluongxe = Soluongxe,
            Nguoidaidien = Nguoidaidien,
            Gioithieuchitiet = Gioithieuchitiet,
            Gioithieungan = Gioithieungan
        });
        nhaxeRepo.Save();
        return nx;
    }
    [WebMethod]
    public static NhaXe DeleteNhaXe(int Id)
    {
        var nx = nhaxeRepo.Find(Id);
        var res = nhaxeRepo.Remove(nx);
        nhaxeRepo.Save();
        return res;
    }
    [WebMethod]
    public static NhaXe UpdateNhaXe(int Id, string Tennhaxe, int Soluongxe, string Trusochinh, string Nguoidaidien, string Sodienthoai, string Gioithieungan, string Gioithieuchitiet)
    {
        var nx = nhaxeRepo.Find(Id);
        if (nx != null)
        {
            nx.Tennhaxe = Tennhaxe;
            nx.Sodienthoai = Sodienthoai;
            nx.Trusochinh = Trusochinh;
            nx.Soluongxe = Soluongxe;
            nx.Nguoidaidien = Nguoidaidien;
            nx.Gioithieuchitiet = Gioithieuchitiet;
            nx.Gioithieungan = Gioithieungan;
        }
        nhaxeRepo.Save();
        return nx;
    }
    [WebMethod]
    public static string ExportToExcel(string nhaxes)
    {
        var obj = JsonConvert.DeserializeObject(nhaxes);
        ExportTableToExcel(obj);
        return nhaxes;
    }
}