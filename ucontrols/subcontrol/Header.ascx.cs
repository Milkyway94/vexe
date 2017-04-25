using QCMS_BUSSINESS;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QCMS_BUSSINESS.Repositories;
public partial class ucontrols_subcontrol_Header : System.Web.UI.UserControl
{
    private ModRepository repo = new ModRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuTopItem.Text=LoadMenuTop();
        lbSDT.Text = LoadSDT();
    }
    public string LoadMenuTop()
    {
        StringBuilder str = new StringBuilder();
        foreach (var item in repo.GetModByBoxCode("MenuTop"))
        {
            str.Append("<li><a href=\"/"+item.Mod_Url+ ".htm\">" + item.Mod_Name+"</a></li>");
            if(repo.GetModByBoxCode("MenuTop").IndexOf(item)!= repo.GetModByBoxCode("MenuTop").Count-1)
            {
                str.Append("<li><i>|</i><li>");
            }
        }
        return str.ToString();
    }
    public string LoadNhaXeMenu()
    {
        StringBuilder str = new StringBuilder();
        foreach (var item in repo.GetModByBoxCode("MenuNhaXe"))
        {
            str.Append("<li><a href=\"/" + item.Mod_Url + ".htm\"><i class=\"fa fa-star\"></i>" + item.Mod_Name + "</a></li>");
        }
        return str.ToString();
    }
    public string LoadKhachMenu()
    {
        StringBuilder str = new StringBuilder();
        foreach (var item in repo.GetModByBoxCode("MenuKhach"))
        {
            str.Append("<li><a href=\"/" + item.Mod_Url + ".htm\"><i class=\"fa fa-star\"></i>" + item.Mod_Name + "</a></li>");
        }
        return str.ToString();
    }
    public string LoadSDT()
    {
        OtherRepository otherRepo = new OtherRepository();
        return otherRepo.GetOtherByCode("Hotline").Other_Content;
    }
 
}