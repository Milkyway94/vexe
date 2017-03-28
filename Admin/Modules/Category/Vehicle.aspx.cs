using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_Category_Vehicle : System.Web.UI.Page
{
    public static XeRepository xeRepo = new XeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<Xe> GetAll()
    {
        return xeRepo.All().ToList();
    }
    [WebMethod]
    public static Xe GetById(int Id)
    {
        return xeRepo.Find(Id);
    }
    [WebMethod]
    public static Xe Create(string Bienso, string Tenxe, int Nhaxe, string Gioithieungan, string Gioithieuchitiet, int Soghe, int? Hangxe)
    {
        var xe = new Xe {
            Bienso = Bienso,
            Tenxe = Tenxe,
            Nhaxe = Nhaxe,
            Gioithieuchitiet = Gioithieuchitiet,
            Gioithieungan = Gioithieungan,
            TongSoGhe = Soghe,
            Hangxe = Hangxe,
            Nguoitao = HttpContext.Current.Session["UserId"].ToString(),
            Ngaytao = DateTime.Now
        };
        var x = xeRepo.Add(xe);
        xeRepo.Save();
        return x;
    }
    [WebMethod]
    public static Xe Update(int Maxe, string Bienso, string Tenxe, int Nhaxe, string Gioithieungan, string Gioithieuchitiet, int Soghe, int? Hangxe)
    {
        Xe xe = xeRepo.Find(Maxe);
        xe.Bienso = Bienso;
        xe.Tenxe = Tenxe;
        xe.Nhaxe = Nhaxe;
        xe.Gioithieuchitiet = Gioithieuchitiet;
        xe.Gioithieungan = Gioithieungan;
        xe.Hangxe = Hangxe;
        xe.Ngaysuacuoi = DateTime.Now;
        xe.Nguoisuacuoi = HttpContext.Current.Session["UserId"].ToString();
        xe.Nhaxe = Nhaxe;
        xe.TongSoGhe = Soghe;
        xe.Tenxe = Tenxe;
        xeRepo.Save();
        return xe;
    }
    [WebMethod]
    public static Xe Delete(int Maxe)
    {
        var xe = xeRepo.Find(Maxe);
        xeRepo.Remove(xe);
        xeRepo.Save();
        return xe;
    }
}