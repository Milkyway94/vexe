using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMAC;
using System.Text;

public partial class Administrator_Modules_Weblink_Weblink : DefaultAdmin
{
    public string sRootAppPath = "../../";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HeadContent.Text = LoadOther("HeadContent");
            AddThis.Text = LoadOther("AddThis");
            Adsbottom.Text = LoadOther("Adsbottom");
            Adsleft.Text = LoadOther("Adsleft");
            Adsright.Text = LoadOther("Adsright");
            Adscontent.Text = LoadOther("Adscontent");
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        Hashtable tbIn0 = new Hashtable();
        tbIn0.Add("Other_Content", AddThis.Text.ToString());
        UpdateData.Update("tbl_Other", tbIn0, "Other_Mod='AddThis'");

        Hashtable tbIn = new Hashtable();
        tbIn.Add("Other_Content", HeadContent.Text.ToString());
        UpdateData.Update("tbl_Other", tbIn, "Other_Mod='HeadContent'");

        Hashtable tbIn1 = new Hashtable();
        tbIn1.Add("Other_Content", Adsbottom.Text);
        UpdateData.Update("tbl_Other", tbIn1, "Other_Mod='Adsbottom'");

        Hashtable tbIn2 = new Hashtable();
        tbIn2.Add("Other_Content", Adsleft.Text);
        UpdateData.Update("tbl_Other", tbIn2, "Other_Mod='Adsleft'");

        Hashtable tbIn3 = new Hashtable();
        tbIn3.Add("Other_Content", Adsright.Text);
        UpdateData.Update("tbl_Other", tbIn3, "Other_Mod='Adsright'");

        Hashtable tbIn4 = new Hashtable();
        tbIn4.Add("Other_Content", Adscontent.Text);
        UpdateData.Update("tbl_Other", tbIn4, "Other_Mod='Adscontent'");
        
        string alert = "<script>";
        alert += "alert('Thành công rồi :D!');";
        alert += "</script>";
        Response.Write(alert);
    }
    public string LoadOther(string strCode)
    {
        StringBuilder sb = new StringBuilder();
        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_Other where Other_Mod='" + strCode + "'");
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            sb.Append(rows[0]["Other_Content"].ToString());
        }
        return sb.ToString();
    }
}
