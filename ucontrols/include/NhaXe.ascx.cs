using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
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
            lbnav.Text = "<li><a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li> <li>" + ModControl.GetName_From_Code(nurl) + "</li>";
            lst.Visible = true;
            detail.Visible = false;

        }
        else
        {
            detail.Visible = true;
            lst.Visible = false;
            lbnav.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(url) + "</li>";
            nx = new NhaxeRepository().Find(int.Parse(nurl));
        }
    }
    protected string lstNhaxe()
    {
        var lst= new NhaxeRepository().All().ToList();
        string str = "";
        foreach (var item in lst)
        {
            str += "<li><a href='/nha-xe/"+item.ID+".htm'>";
            str += "<img src=\""+item.Anh+"\" alt=\"Nhà xe "+item.Tennhaxe+"\" />";
            str += "<p>"+item.Tennhaxe+"</p>";
            str += "</a></li>";
        }
        return str;
    }
}