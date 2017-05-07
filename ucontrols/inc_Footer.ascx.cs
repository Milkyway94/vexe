using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using SMAC;
using QCMS_BUSSINESS.Repositories;

public partial class ucontrols_inc_Footer : System.Web.UI.UserControl
{
    protected string uImg = ApplicationSetting.URLImages;
    protected string uRoot = ApplicationSetting.URLRoot;
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrContact.Text = LoadContact();
        ltrSupportMenu.Text = GetSupportMenu();
        ltrAboutMenu.Text = GetAboutMenu();
        ltrSocialIcon.Text = LoadSocial();
        Brand.Text = LoadBrand();
        CopyRight.Text = LoadCopyright();
        //this.VisitorCounter();
        //ltrKhachhang.Text = LoadKhachhang();
    }
    protected string LoadSocial()
    {
        string sql = "select * from tbl_Other where Other_Mod='social' and Other_Status=1 and lang=" + Session["vlang"];
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        str.Append("<ul id='icon'>");
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                string fa = rows[i]["Other_Name"].ToString();
                string link = rows[i]["Other_Content"].ToString();
                str.Append("<li class=\"" + fa + "\"><a href = \"" + link + "\" target=\"_blank\" ><span class='icon-social'><i class=\"fa fa-" + fa + "\"></i></span></a></li>");
            }
        }
        str.Append("</ul>");
        return str.ToString();
    }
    public string GetSupportMenu()
    {
        ModRepository modRepo = new ModRepository();
        StringBuilder str = new StringBuilder();
        str.Append("<ul>");
        foreach (var item in modRepo.GetModByBoxCode("SupportFooterMenu"))
        {
            str.Append("<li><a href=\"/" + item.Mod_Url + ".htm\">" + item.Mod_Name + "</a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    public string GetAboutMenu()
    {
        ModRepository modRepo = new ModRepository();
        StringBuilder str = new StringBuilder();
        str.Append("<ul>");
        foreach (var item in modRepo.GetModByBoxCode("ve-cong-ty-2"))
        {
            str.Append("<li><a href=\"/" + item.Mod_Url + ".htm\">" + item.Mod_Name + "</a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    public string LoadContact()
    {
        string sql = "select * from tbl_Other where Other_Mod='contact' AND lang=" + Session["vlang"];
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }
    public string LoadCopyright()
    {
        string sql = "select * from tbl_Other where Other_Mod='ftCopyright' AND lang=" + Session["vlang"];
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }
    public string LoadBrand()
    {
        string sql = "select * from tbl_Other where Other_Mod='ftNotify' AND lang=" + Session["vlang"];
        sql += "and Other_Status=1";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            string link = rows[0]["Other_Content"].ToString();
            str.Append(link);
        }
        return str.ToString();
    }
    //#region Online Visitor Counter
    //private void VisitorCounter()
    //{
    //    double _visitor = 0;
    //    TextReader tr = new StreamReader(Server.MapPath("~/visitor.txt"));
    //    _visitor = Convert.ToDouble(tr.ReadLine());
    //    tr.Close();
    //    tr.Dispose();
    //    try
    //    {
    //        if (Session["_vUser"] == null)
    //        {
    //            Session["_vUser"] = "true";
    //            _visitor++;
    //            TextWriter tw = new StreamWriter(Server.MapPath("~/visitor.txt"));
    //            tw.Write(_visitor);
    //            tw.Close();
    //            tw.Dispose();
    //        }
    //    }
    //    catch { }
    //    ltVisitor.Text = _visitor.ToString();
    //    ltOnline.Text = Application["visitors_online"].ToString();
    //}
    //#endregion
}