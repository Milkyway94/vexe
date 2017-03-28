using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_Category_Province : System.Web.UI.Page
{
    public static ProvinceRepository proRepo = new ProvinceRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<TinhThanh> GetAllProvince()
    {
        var res= proRepo.All().ToList();
        foreach (var item in res)
        {
            item.QuanHuyens = new List<QuanHuyen>();
        }
        return res;
    }
    [WebMethod]
    public static TinhThanh GetProvinceById(int matinh)
    {
        var res= proRepo.Find(matinh);
        res.QuanHuyens = new List<QuanHuyen>();
        return res;
    }
}