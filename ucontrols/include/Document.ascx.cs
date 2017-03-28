using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Document : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p;
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(u);
        if (Session["UserID"] == null)
        {
            Response.Redirect("/Admin/login.aspx");
        }
        else
        {
           
                ltrDocType.Text = LoadDocType();
                if (Request["dt"] == null)
                {
                    ltrDoc.Text = LoadDocs(10);
                }
                else
                {
                    ltrDoc.Text = LoadDocByDocType(10);
                }
        }
        if (Request["act"] == "search")
        {
            ltrDoc.Text = SearchDoc(10);
        }
    }
    public string SearchDoc(int pageSize=10)
    {
        string code = Request["txtCode"]!=null? Request["txtCode"]:"";
        string name = Request["txtName"]!=""?Request["txtName"] : "";
        string sdate = Request["txtSDate"]!=""?Request["txtSDate"] : DateTime.MinValue.ToShortDateString();
        string edate = Request["txtEDate"] != "" ? Request["txtEDate"] : DateTime.MaxValue.ToShortDateString();
        string sql = "";
        sql = "select * from tbl_Documents where Doc_Code like '%" + code + "%' and Doc_Name like N'%" + name + "%' and Doc_CreatedDate >'" + sdate + "' and Doc_CreatedDate <'" + edate+"'";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            int currentPage = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int totalpage = (int)rows.Count / pageSize;
            int startrow = totalpage < 1 ? 0 : ((currentPage-1) * pageSize);
            int endrow = totalpage < 1 ? rows.Count : startrow + pageSize;
            for (int i = startrow; i < endrow; i++)
            {
                str.Append("<tr>");
                str.Append("    <td align=center>" + i + "</td>");
                str.Append("    <td>" + rows[i]["Doc_Code"] + "</td>");
                str.Append("    <td class=\"text-center\"><a id=\"link-docname\" href=?dt=" + rows[i]["Doc_ID"] + ">" + rows[i]["Doc_Name"] + "</a></td>");
                str.Append("    <td class=\"doc-content\">" + rows[i]["Doc_Content"] + "</td>");
                str.Append("    <td>" + DateTime.Parse(rows[i]["Doc_CreatedDate"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                str.Append("<td><a class=\"text-center\" href=\"" + rows[i]["Doc_File"] + "\"><i class=\"fa fa-download\"></i>Tải về</a></td>");
                str.Append("</tr>");
            }
            phantrang pages = new phantrang();
            if (rows.Count > pageSize)
            {
                str.Append(pages.pagelink((int)rows.Count / 1, currentPage, "?"));
            }
        }
        return str.ToString();
    }
    public string LoadDocs(int pageSize=10)
    {
        StringBuilder str = new StringBuilder();
        string sql = "select Doc_ID,Doc_Avatar, Doc_Code, Doc_Staff, Doc_ViewCount, Doc_Name, Doc_Title, Doc_Content, Doc_File, Doc_CreatedDate, DocsType_ID, Doc_CreatedBy, Doc_Hot, Doc_Pos from tbl_Documents Order By Doc_CreatedDate DESC";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if (rows.Count > 0)
        {
            int currentPage = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int totalpage = (int)rows.Count / pageSize;
            int startrow = totalpage <1? 0 : (currentPage * pageSize);
            int endrow = totalpage < 1 ? rows.Count : startrow + pageSize;
            for (int i = startrow; i < endrow; i++)
            {
                str.Append("<tr>");
                str.Append("    <td align=center>" + i+ "</td>");
                str.Append("    <td>" + rows[i]["Doc_Code"] + "</td>");
                str.Append("    <td class=\"text-center\"><a id=\"link-docname\" href=?d="+rows[i]["Doc_ID"]+">"+ rows[i]["Doc_Name"]+ "</a></td>");
                str.Append("    <td class=\"doc-content\">" + rows[i]["Doc_Content"] + "</td>");
                str.Append("    <td>" + DateTime.Parse(rows[i]["Doc_CreatedDate"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                str.Append("<td><a class=\"text-center\" href=\"" + rows[i]["Doc_File"] + "\"><i class=\"fa fa-download\"></i>Tải về</a></td>");
                str.Append("</tr>");
            }
            phantrang pages = new phantrang();
            if (rows.Count>pageSize)
            {
                str.Append(pages.pagelink((int)rows.Count / 1, currentPage, "?"));
            }  
        }
        return str.ToString();
    }
    //public string LoadHotDocs()
    //{
    //    StringBuilder str = new StringBuilder();
    //    string sql = "select Doc_ID,Doc_Avatar,Doc_ViewCount, Doc_Name, Doc_Title, Doc_Content, Doc_File, Doc_CreatedDate, DocsType_ID, Doc_CreatedBy, Doc_Hot, Doc_Pos from tbl_Documents where Doc_Hot=1";
    //    DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
    //    DataRowCollection rows = ds.Rows;
    //    if (rows.Count > 0)
    //    {
    //        for (int i = 0; i < rows.Count; i++)
    //        {
    //            str.Append("<div class=\"col-sm-4 col-md-4 col-xs-12 col-lg-4 doc-item\">");
    //            str.Append("<div class=\"above\">");
    //            if (rows[i]["Doc_Avatar"].ToString() != "")
    //            {
    //                str.Append("<img src = \"" + rows[i]["Doc_Avatar"] + "\" width=100% height=200 />");
    //            }
    //            else
    //            {
    //                str.Append("<a href=\"?doc_id=" + rows[i]["Doc_ID"] + "\"><img src = \"resources/images/unnamed.png\" width=100% height=200 /></a>");
    //            }
    //            str.Append("</div>");
    //            str.Append("<div class=\"bot\">");
    //            if (rows[i]["Doc_Name"].ToString().Length > 30)
    //            {
    //                str.Append("<a href=\"?doc_id=" + rows[i]["Doc_ID"] + "\"><h5>" + rows[i]["Doc_Name"].ToString().Substring(0, 30) + "</h5></a>");
    //            }
    //            else
    //            {
    //                str.Append("<a href=\"?doc_id=" + rows[i]["Doc_ID"] + "\"><h5>" + rows[i]["Doc_Name"].ToString() + "</h5></a>");
    //            }
    //            str.Append("</div>");
    //            str.Append("<div class=\"cblock\">");
    //            str.Append("<div class=\"cdate\"><i class=\"fa fa-calendar\"></i>&nbsp;" + rows[i]["Doc_CreatedDate"] + "</div>");
    //            str.Append("<div class=\"crate\"><i class=\"fa fa-eye\"></i> " + rows[i]["Doc_ViewCount"] + "</div>");
    //            str.Append("<div class=\"cloc\">");
    //            str.Append("<i class=\"fa fa-user\"></i>&nbsp;");
    //            str.Append("<span class=\"user\">" + rows[i]["Doc_CreatedBy"] + "</span>");
    //            str.Append(" </div>");
    //            str.Append("<div class=\"cstat\"><a href = \"" + rows[i]["Doc_File"] + "\" ><i class=\"fa fa-download\"></i>Tải về</a></div>");
    //            str.Append("</div>");
    //            str.Append("</div>");
    //        }
    //    }
    //    return str.ToString();
    //}
    public string LoadNewDocs()
    {
        StringBuilder str = new StringBuilder();
        string sql = "select Top 10 Doc_ID,Doc_Avatar,Doc_ViewCount, Doc_Name, Doc_Title, Doc_Content, Doc_File, Doc_CreatedDate, DocsType_ID, Doc_CreatedBy, Doc_Hot, Doc_Pos from tbl_Documents Order By Doc_CreatedDate DESC";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<div class=\"col-sm-4 col-md-4 col-xs-12 col-lg-4 doc-item\">");
                str.Append("<div class=\"above\">");
                if (rows[i]["Doc_Avatar"].ToString() != "")
                {
                    str.Append("<img src = \"" + rows[i]["Doc_Avatar"] + "\" width=100% height=200 />");
                }
                else
                {
                    str.Append("<a href=\"?d=" + rows[i]["Doc_ID"] + "\"><img src = \"resources/images/unnamed.png\" width=100% height=200 /></a>");
                }
                str.Append("</div>");
                str.Append("<div class=\"bot\">");
                if (rows[i]["Doc_Name"].ToString().Length > 30)
                {
                    str.Append("<a href=\"?d=" + rows[i]["Doc_ID"] + "\"><h5>" + rows[i]["Doc_Name"].ToString().Substring(0, 30) + "</h5></a>");
                }
                else
                {
                    str.Append("<a href=\"?d=" + rows[i]["Doc_ID"] + "\"><h5>" + rows[i]["Doc_Name"].ToString() + "</h5></a>");
                }
                str.Append("</div>");
                str.Append("<div class=\"cblock\">");
                str.Append("<div class=\"cdate\"><i class=\"fa fa-calendar\"></i>&nbsp;" + rows[i]["Doc_CreatedDate"] + "</div>");
                str.Append("<div class=\"crate\"><i class=\"fa fa-eye\"></i> " + rows[i]["Doc_ViewCount"] + "</div>");
                str.Append("<div class=\"cloc\">");
                str.Append("<i class=\"fa fa-user\"></i>&nbsp;");
                str.Append("<span class=\"user\">" + rows[i]["Doc_CreatedBy"] + "</span>");
                str.Append(" </div>");
                str.Append("<div class=\"cstat\"><a href = \"" + rows[i]["Doc_File"] + "\" ><i class=\"fa fa-download\"></i>Tải về</a></div>");
                str.Append("</div>");
                str.Append("</div>");
            }
        }
        return str.ToString();
    }
    public string LoadDocType()
    {
        StringBuilder str = new StringBuilder();
        DataSet ds = UpdateData.UpdateBySql("SELECT DocsType_ID,DocsType_Name,DocsType_Status, DocsType_Parent  FROM tbl_DocsType ORDER BY DocsType_Order");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            int lP = int.Parse(rows[i]["DocsType_Parent"].ToString());
            if (lP == 0)
            {
                str.Append("<li>");
                str.Append("<a href=\"?dt="+rows[i]["DocsType_ID"]+"\" onclick=\"LoadDocContent(" + rows[i]["DocsType_ID"] + ")\">" + rows[i]["DocsType_Name"] + "</a>");
                str.Append(LoadSubDocType(int.Parse(rows[i]["DocsType_ID"].ToString())));
                str.Append("</li>");
            }
        }
        return str.ToString();
    }
    public string GetDocTypeNameByID(int doctype_id)
    {
        string str = "";
        string sql = "select * from tbl_DocsType where DocsType_ID=" + doctype_id.ToString();
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if(rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str += rows[i]["DocsType_Name"];
            }
        }
        return str;

    }
    protected string LoadSubDocType(int parent)
    {
        DataSet ds1 = UpdateData.UpdateBySql("SELECT DocsType_ID,DocsType_Name,DocsType_Status, DocsType_Parent  FROM tbl_DocsType where DocsType_Parent=" + parent + " ORDER BY DocsType_Order");
        DataRowCollection rows1 = ds1.Tables[0].Rows;
        StringBuilder str1 = new StringBuilder();
        if (rows1.Count > 0)
        {
            for (int i = 0; i < rows1.Count; i++)
            {
                str1.Append("<ul class=\"doc-sub-menu menu\">");
                str1.Append("<li>");
                str1.Append("<a href=\"?dt="+ rows1[i]["DocsType_ID"] + "\" onclick=\"LoadDocContent(" + rows1[i]["DocsType_ID"] + ")\">");
                str1.Append(rows1[i]["DocsType_Name"] + "</a>");
                str1.Append("</li>");
                str1.Append("</ul>");
                continue;
            }
        }
        return str1.ToString();
    }
    public string LoadDocByDocType(int pageSize=1)
    {
        StringBuilder str = new StringBuilder();
        int doctype_id = int.Parse(Request["dt"]);
        string sql = "select * from tbl_Documents where DocsType_ID=" + doctype_id;
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if (rows.Count > 0)
        {
            int currentPage = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int totalpage = (int)rows.Count / pageSize;
            int startrow = totalpage < 1 ? 0 : (currentPage * pageSize);
            int endrow = totalpage < 1 ? rows.Count : startrow + pageSize;
            for (int i = startrow; i < endrow; i++)
            {
                str.Append("<tr>");
                str.Append("    <td align=center>" + i + "</td>");
                str.Append("    <td>" + rows[i]["Doc_Code"] + "</td>");
                str.Append("    <td class=\"text-center\"><a id=\"link-docname\" href=?d=" + rows[i]["Doc_ID"] + ">" + rows[i]["Doc_Name"] + "</a></td>");
                str.Append("    <td class=\"doc-content\">" + rows[i]["Doc_Content"] + "</td>");
                str.Append("    <td>" + DateTime.Parse(rows[i]["Doc_CreatedDate"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                str.Append("<td><a class=\"text-center\" href=\"" + rows[i]["Doc_File"] + "\"><i class=\"fa fa-download\"></i>Tải về</a></td>");
                str.Append("</tr>");
            }
            phantrang pages = new phantrang();
            if (rows.Count > pageSize)
            {
                str.Append(pages.pagelink((int)rows.Count / 1, currentPage, "?"));
            }
        }
        return str.ToString();
    }
}