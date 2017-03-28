using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_subcontrol_Menu : System.Web.UI.UserControl
{
    public void Page_Load(object sender, EventArgs e)
    {
        Logo.Text = LoadLogo();
        MainMenu.Text = LoadMainMenu();
    }
    
    public string LoadLogo()
    {
        OtherRepository otherRepo = new OtherRepository();
        return otherRepo.GetOtherByCode("Logo").Other_Content;
    }
    public string LoadMainMenu()
    {
        ModRepository modRepo = new ModRepository();
        StringBuilder str = new StringBuilder();
        foreach (var item in modRepo.GetModByBoxCode("MainMenu"))
        {
            str.Append("<li><a href=\"/"+item.Mod_Url+".htm\">"+item.Mod_Name+"</a></li>");
        }
        return str.ToString();
    }
}