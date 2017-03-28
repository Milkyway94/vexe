using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_Category_District : System.Web.UI.Page
{
    public static DistrictRepository distRepo = new DistrictRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    [WebMethod]
    public static List<QuanHuyen> GetAllDistrict()
    {
        var res= distRepo.All().OrderBy(o=>o.MaTinh).ToList();
        foreach (var item in res)
        {
            item.TinhThanh = null;
        }
        return res;
    }
    [WebMethod]
    public static QuanHuyen CreateDistrict(string TenHuyen, int MaTinh)
    {
        var rs= distRepo.Add(new QuanHuyen{
                TenHuyen=TenHuyen,
                MaTinh=MaTinh
        });
        distRepo.Save();
        return rs;
    }
    [WebMethod]
    public static QuanHuyen UpdateDistrict(int MaHuyen, string TenHuyen, int MaTinh)
    {
        var dist = distRepo.Find(MaHuyen);
        if (dist != null)
        {
            dist.TenHuyen = TenHuyen;
            dist.MaTinh = MaTinh;
        }
        distRepo.Save();
        return dist;
    }
    [WebMethod]
    public static QuanHuyen DeleteDistrict(int Id)
    {
        var dist = distRepo.Find(Id);
        var rs= distRepo.Remove(dist);
        distRepo.Save();
        return rs;
    }
}