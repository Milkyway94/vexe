using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_NhaXe : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public NhaXe nx = new NhaXe();
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (string.IsNullOrEmpty(nurl))
        {
            lst.Visible = true;
            detail.Visible = false;

        }
        else
        {
            detail.Visible = true;
            lst.Visible = false;
            nx = new NhaxeRepository().Find(int.Parse(nurl));
        }
        if (!IsPostBack)
        {
            foreach (var item in getTinhHaveNhaxe())
            {
                ddlTinh.Items.Add(new ListItem(item.TenTinh, item.MaTinh.ToString()));
            }
            ddlTinh.DataBind();
        }
    }
    protected string lstNhaxe()
    {
        var lst=new List<NhaXe>();
        if (ddlTinh.SelectedIndex == 0)
        {
            lst=new NhaxeRepository().All().ToList();
        }
        else
        {
            int matinh = Convert.ToInt32(ddlTinh.SelectedValue);
            lst = new NhaxeRepository().SearchFor(o=>o.Tinh==matinh).ToList();
        }
        string str = "";
        foreach (var item in lst)
        {
            str += "<li><a href='/nha-xe/"+item.ID+".htm'>";
            str += "<div class=\"overlay\"><img src=\""+item.Anh+"\" alt=\"Nhà xe "+item.Tennhaxe+"\" /></div>";
            str += "<p>"+item.Tennhaxe+"</p>";
            str += "</a></li>";
        }
        return str;
    }
    protected List<TinhThanh> getTinhHaveNhaxe()
    {
        var lst = new List<TinhThanh>();
        string sql = "select top 10 MaTinh, TenTinh from nhaxe nx join TinhThanh tt on nx.Tinh=tt.MaTinh group by MaTinh, TenTinh";
        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = dt.Rows;
        foreach (DataRow item in rows)
        {
            lst.Add(new TinhThanh { MaTinh = int.Parse(item["MaTinh"].ToString()), TenTinh = item["TenTinh"].ToString() });
        }
        return lst;
    }
}