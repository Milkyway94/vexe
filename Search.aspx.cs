using System;
using System.Web.UI;
using System.Text;
using SMAC;
using System.IO;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string url;
    protected int p, id;
    //protected override void Render(HtmlTextWriter writer)
    //{
    //    //html minifier & JS at bottom
    //    // not tested
    //    if (this.Request.Headers["X-MicrosoftAjax"] != "Delta=true")
    //    {
    //        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"<script[^>]*>[\w|\t|\r|\W]*?</script>");
    //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
    //        HtmlTextWriter hw = new HtmlTextWriter(sw);
    //        base.Render(hw);
    //        string html = sb.ToString();
    //        System.Text.RegularExpressions.MatchCollection mymatch = reg.Matches(html);
    //        html = reg.Replace(html, string.Empty);
    //        reg = new System.Text.RegularExpressions.Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}|(?=[\r])\s{2,}");
    //        html = reg.Replace(html, string.Empty);
    //        reg = new System.Text.RegularExpressions.Regex(@"</body>");
    //        string str = string.Empty;
    //        foreach (System.Text.RegularExpressions.Match match in mymatch)
    //        {
    //            str += match.ToString();
    //        }
    //        html = reg.Replace(html, str + "</body>");
    //        writer.Write(html);
    //    }
    //    else
    //        base.Render(writer);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSfunc.checkURL();
        string lang = Request.QueryString["lang"];
        if (!String.IsNullOrEmpty(lang) && lang != "1")
            Session["vlang"] = lang;
        if (Session["vlang"] == null || lang == "1")
            Session["vlang"] = "1";
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        string nUrl = String.IsNullOrEmpty(Request["nUrl"]) ? "" : Request["nUrl"].ToString();
        p = ModControl.GetP_From_Code(url);
        id = ModControl.GetID_From_Url(p, nUrl);
        string page = ConvertUtil.Nullcheck(Request.QueryString.Get("page"), "1");
        string pagesize = ConvertUtil.Nullcheck(Request.Form.Get("pagesizechange"), "10");
        LoadHeadTag(p, id);
        ltrMenutop.Text = LoadMenutop(0);
        ltrMenufooter.Text = GetMnFooter();
        string field = "Mod_ID,Content_Name,Content_Img,Content_Intro,Content_Url";
        string where = " lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID in(SELECT Mod_ID FROM tbl_Mod WHERE Mod_Status=1 AND Modtype_ID=1)";
        string k = ApplicationUtil.FormatSqlString(Request["k"]);
        if (k != "")
            where += " AND Content_Name like N'%" + k + "%'";
        string sqlorder = " ORDER BY Content_ID DESC";
        LoadNews(Convert.ToInt16(page), Convert.ToInt16(pagesize), field, where, sqlorder);
        VisitorCounter();
        lrtPath.Text = CMSfunc.LoadPath(ModControl.GetP_From_Code("tim-kiem"), 0);
    }
    private void LoadNews(int pagecurrent, int pagesize, string field, string where, string order)
    {
        phantrang pt = new phantrang();
        ContentControl ct = new ContentControl();
        pagecurrent = pagecurrent < 1 ? 1 : pagecurrent;
        DataTable dt = ct.dt_Contentsearch(pagecurrent, pagesize, field, where, order);
        DataRowCollection rows = dt.Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            int tongso = Convert.ToInt16(dt.Rows[0]["tongso"].ToString());
            int tem = (tongso >= pagesize) ? pagesize : tongso;
            tem = tongso >= pagesize * pagecurrent ? pagesize : tongso - pagesize * (pagecurrent - 1);
            //str.Append("<div class=\"box-main-left\">");
            for (int i = 0; i < tem; i++)
            {
                int p = Convert.ToInt32(rows[i]["Mod_ID"]);
                string n = rows[i]["Content_Name"].ToString();
                string img = rows[i]["Content_Img"].ToString();
                string intro = rows[i]["Content_intro"].ToString();
                string url = ResolveUrl("~/" + ModControl.GetModCode(p) + "/" + rows[i]["Content_Url"] + ".htm");
                str.Append(CMSfunc.LoadNewsItem(url, img, n, intro));
            }
            //str.Append("</div>");
            ltrListNews.Text = str.ToString();
            if ((((tongso - 1) / pagesize) + 1) > 1)
                ltrPhantrang.Text = pt.pagelinkNews(((tongso - 1) / pagesize) + 1, pagecurrent, Request.RawUrl);
        }
    }
    public void LoadHeadTag(int p, int id)
    {
        StringBuilder str = new StringBuilder();
        string CurrentURL = "http://apec.com.vn" + System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.Replace("Default.aspx", string.Empty);
        string sql = "";
        if (p != 0)
        {
            if (id != 0)
                sql += "SELECT Content_Name,Content_Title,Content_Key,Content_Des,Content_Img FROM tbl_Content Where Mod_ID=" + p + " AND Content_ID=" + id + " AND Content_Status=1";
            else
                sql += "SELECT Mod_Name,Mod_Title,Mod_Key,Mod_Des,Mod_Img FROM tbl_Mod Where Mod_ID=" + p + " AND Mod_Status=1";
            DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
            DataRowCollection rows = ds.Rows;
            if (rows.Count > 0)
            {
                int cm = ConvertUtil.ReplaceInt(Request["cm"]);
                int ck = ConvertUtil.ReplaceInt(Request["ck"]);
                string str1 = (cm != 0) ? " - " + ModControl.GetModField("Name", cm) : "";
                string str2 = (ck != 0) ? " - " + ModControl.GetModField("Name", ck) : "";
                ltrTitle.Text = rows[0][1].ToString() + str1 + str2;
                this.ltrHeadTags.Text += string.Format("<meta name='keywords' content='{0}' />", rows[0][2] + str1 + str2);
                this.ltrHeadTags.Text += string.Format("<meta name='description' content='{0}' />", rows[0][3] + str1 + str2);
                this.ltrHeadTags.Text += string.Format("<meta property='og:image' content='{0}' />", rows[0][4]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:title' content='{0}' />", rows[0][1]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:description' content='{0}' />", rows[0][3]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:site_name' content='{0}' />", rows[0][0]);
                this.ltrHeadTags.Text += string.Format("<meta property='og:url' content='{0}' />", CurrentURL);
            }
        }
        else
        {
            this.ltrHeadTags.Text += CMSfunc.LoadOther("Head-Tag-Home");
            ltrTitle.Text = CMSfunc._Title("title-home");
        }
        this.ltrHeadTags.Text += "<link rel=\"canonical\" href=\"" + CurrentURL + "\" />";
        //this.ltrHeadTags.Text += CMSfunc.LoadOther("HeadContent");
    }
    protected string LoadMenutop(int p)
    {
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1";
        sql += " AND Mod_Level=1 AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
        sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menutop' AND lang=" + Session["vlang"] + "))";
        sql += " ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        str.Append("<ul>");
        for (int i = 0; i < rows.Count; i++)
        {
            int idL1 = Convert.ToInt32(rows[i]["Mod_ID"]);
            string cL1 = rows[i]["Mod_Code"].ToString();
            //string nL1 = cL1 == "Home" ? " " : rows[i]["Mod_Name"].ToString();
            string nL1 = rows[i]["Mod_Name"].ToString();
            string urlL1 = cL1 == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + rows[i]["Mod_Code"] + ".htm");
            string css = i == 0 ? " class=\"active\"" : "";
            string sql2 = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Parent=" + idL1 + " AND lang=" + Session["vlang"] + " AND Mod_Status=1 ORDER BY Mod_Pos";
            DataSet ds2 = UpdateData.UpdateBySql(sql2);
            DataRowCollection rows2 = ds2.Tables[0].Rows;
            str.Append("<li><a" + css + " title=\"" + nL1 + "\" href=\"" + urlL1 + "\">" + nL1 + "</a>");
            //str.Append("<li><a href=\"" + urlL1 + "\" title=\"" + nL1 + "\">" + nL1 + "</a>");
            if (rows2.Count > 0)
            {
                str.Append("<ul class=\"sub-menu\">");
                for (int j = 0; j < rows2.Count; j++)
                {
                    int idL2 = Convert.ToInt32(rows2[j]["Mod_ID"]);
                    string nL2 = rows2[j]["Mod_Name"].ToString();
                    string urlL2 = ResolveUrl("~/" + rows2[j]["Mod_Code"] + ".htm");
                    str.Append("<li><a href=\"" + urlL2 + "\" title=\"" + nL2 + "\">" + nL2 + "</a></li>");
                }
                str.Append("</ul>");
            }
            str.Append("</li>");
        }
        str.Append("</ul>");

        return str.ToString();
    }
    public string GetMinitop()
    {
        int p;
        string n, c, sql;
        sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE lang=" + Session["vlang"] + " AND Mod_Status=1";
        sql += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
        sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Minitop' AND lang=" + Session["vlang"] + "))";
        sql += " ORDER BY Mod_Pos";
        //===================================================
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        //===================================================    
        for (int i = 0; i < rows.Count; i++)
        {
            p = Convert.ToInt32(rows[i]["Mod_ID"]);
            n = rows[i]["Mod_Name"].ToString();
            c = rows[i]["Mod_Code"].ToString();
            string url = c == "home" ? ResolveUrl("~/") : ResolveUrl("~/" + c + ".htm");
            str.Append("<a title=\"" + n + "\" href=\"" + url + "\">" + n + "</a>");
            if (i < rows.Count - 1) str.Append(" | ");
        }
        return str.ToString();
    }
    //protected string LoadTitle(int p, int id)
    //{
    //    StringBuilder str = new StringBuilder();
    //    if (p != 0)
    //    {
    //        if (id != 0)
    //            str.Append(ContentControl.GetContentField("Title", id));
    //        else
    //        {
    //            str.Append(ModControl.GetModField("Title", p));
    //            int cm = ConvertUtil.ReplaceInt(Request["cm"]);
    //            int ck = ConvertUtil.ReplaceInt(Request["ck"]);
    //            if (cm != 0)
    //                str.Append(" - " + ModControl.GetModField("Name", cm));
    //            if (ck != 0)
    //                str.Append(" - " + ModControl.GetModField("Name", ck));
    //        }

    //    }
    //    else
    //    {
    //        str.Append(ModControl.GetModField("Title", ModControl.GetP_From_Code("Home")));
    //    }

    //    return str.ToString();
    //}
    //protected string LoadKey(int p, int id)
    //{
    //    StringBuilder str = new StringBuilder();
    //    str.Append("<meta name=\"keywords\" content=\"");
    //    if (p != 0)
    //    {
    //        if (id != 0)
    //            str.Append(ContentControl.GetContentField("Key", id));
    //        else
    //            str.Append(ModControl.GetModField("Key", p));
    //        int cm = ConvertUtil.ReplaceInt(Request["cm"]);
    //        int ck = ConvertUtil.ReplaceInt(Request["ck"]);
    //        if (cm != 0)
    //            str.Append(" - " + ModControl.GetModField("Name", cm));
    //        if (ck != 0)
    //            str.Append(" - " + ModControl.GetModField("Name", ck));
    //    }
    //    else
    //        str.Append(ModControl.GetModField("Key", ModControl.GetP_From_Code("Home")));

    //    str.Append("\" />");
    //    return str.ToString();
    //}
    //protected string LoadDes(int p, int id)
    //{
    //    StringBuilder str = new StringBuilder();
    //    str.Append("<meta name=\"description\" content=\"");
    //    if (p != 0)
    //    {
    //        if (id != 0)
    //            str.Append(ContentControl.GetContentField("Meta", id));
    //        else
    //            str.Append(ModControl.GetModField("Meta", p));
    //        int cm = ConvertUtil.ReplaceInt(Request["cm"]);
    //        int ck = ConvertUtil.ReplaceInt(Request["ck"]);
    //        if (cm != 0)
    //            str.Append(" - " + ModControl.GetModField("Name", cm));
    //        if (ck != 0)
    //            str.Append(" - " + ModControl.GetModField("Name", ck));
    //    }
    //    else
    //        str.Append(ModControl.GetModField("Meta", ModControl.GetP_From_Code("Home")));

    //    str.Append("\" />");
    //    return str.ToString();
    //}
    protected string LoadSocial()
    {
        StringBuilder str = new StringBuilder();
        string uRoot = ApplicationSetting.URLRoot;
        str.Append("<span>Follow us</span>");
        str.Append("<span><a target=\"_blank\" href=\"" + CMSfunc._Title("urlFacebook") + "\"><img border=\"0\" align=\"absmiddle\" title=\"Facebook\" src=\"" + uRoot + "templates/sj_tech/images/icon-fb.png\"></a></span>&nbsp;");
        str.Append("<span><a target=\"_blank\" href=\"" + CMSfunc._Title("urlTwitter") + "\"><img border=\"0\" align=\"absmiddle\" title=\"Twitter\" src=\"" + uRoot + "templates/sj_tech/images/icon-tw.png\"></a></span>&nbsp;");
        str.Append("<span><a target=\"_blank\" href=\"" + CMSfunc._Title("urlGoogle") + "\"><img border=\"0\" align=\"absmiddle\" title=\"google plus\" src=\"" + uRoot + "templates/sj_tech/images/icon-gg.png\"></a></span>&nbsp;");
        str.Append("<span><a target=\"_blank\" href=\"" + CMSfunc._Title("urlYoutube") + "\"><img border=\"0\" align=\"absmiddle\" title=\"Youtube\" src=\"" + uRoot + "templates/sj_tech/images/icon-yt.png\"></a></span>&nbsp;");
        return str.ToString();

    }
    protected string GetMnFooter()
    {
        //string sql;
        //sql = "SELECT Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Status=1";
        //sql += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE";
        //sql += " Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menufooter'))";
        //sql += " ORDER BY Mod_Pos";
        string sql = "SELECT m.Mod_ID, m.Mod_Name,m.Mod_Code FROM tbl_Mod m LEFT JOIN ";
        sql += " tbl_ModBox mb on m.Mod_ID = mb.Mod_ID LEFT JOIN  ";
        sql += " tbl_Box b on mb.Box_ID = b.Box_ID";
        sql += " WHERE m.lang=1 AND m.Mod_Status=1 AND b.Box_Code='Menufooter'";
        sql += " ORDER BY m.Mod_Pos";
        //===================================================
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        //===================================================
        str.Append("<ul>");
        for (int i = 0; i < rows.Count; i++)
        {
            int p = Convert.ToInt32(rows[i][0]);
            string n = rows[i][1].ToString();
            string c = rows[i][2].ToString();
            string url = c == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + c + ".htm");
            str.Append("<li><a title=\"" + n + "\" href=\"" + url + "\">" + n + "</a></li>");
            //if (i < rows.Count - 1) str.Append("<a title=\"" + n + "\" href=\"#\">|</a>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    protected string GetSiteLink()
    {
        //string sql = "SELECT top 5 Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Level=1 AND lang=" + Session["vlang"] + " AND Mod_Status=1 AND Mod_Hot=1 ORDER BY Mod_Pos";
        string sql = "SELECT m.Mod_ID, m.Mod_Name,m.Mod_Code FROM tbl_Mod m LEFT JOIN ";
        sql += " tbl_ModBox mb on m.Mod_ID = mb.Mod_ID LEFT JOIN  ";
        sql += " tbl_Box b on mb.Box_ID = b.Box_ID";
        sql += " WHERE m.lang=1 AND m.Mod_Status=1 AND b.Box_Code='SiteLink'";
        sql += " ORDER BY m.Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        StringBuilder str = new StringBuilder();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int idL1 = Convert.ToInt32(dr["Mod_ID"]);
            string nL1 = dr["Mod_Name"].ToString();
            string cL1 = dr["Mod_Code"].ToString();
            string url = ResolveUrl("~/" + cL1 + "/" + idL1 + ".htm");
            str.Append("<div class=\"col-xs-12 col-sm-6 col-md-2 itemFooter\">");
            str.Append("    <h5><a href=\"" + url + "\" title=\"" + nL1 + "\">" + nL1 + "</a></h5>");
            string sql1 = "SELECT top 10 Mod_ID,Mod_Name,Mod_Code FROM tbl_Mod WHERE Mod_Parent=" + idL1 + " AND lang=" + Session["vlang"] + " AND Mod_Status=1 ORDER BY Mod_Pos";
            DataSet ds1 = UpdateData.UpdateBySql(sql1);
            DataRowCollection rows1 = ds1.Tables[0].Rows;
            if (rows1.Count > 0)
            {
                str.Append("<ul>");
                for (int i = 0; i < rows1.Count; i++)
                {
                    int idL2 = Convert.ToInt32(rows1[i]["Mod_ID"]);
                    string nL2 = rows1[i]["Mod_Name"].ToString();
                    string cL2 = rows1[i]["Mod_Code"].ToString();
                    string urlL2 = cL2 == "Home" ? ResolveUrl("~/") : ResolveUrl("~/" + cL2 + "/" + idL2 + ".htm");
                    str.Append("<li><a href=\"" + urlL2 + "\" title=\"" + nL2 + "\">" + nL2 + "</a></li>");
                }
                str.Append("</ul>");
            }
            str.Append("</div>");
        }
        return str.ToString();
    }
    public string LoadPartner()
    {
        StringBuilder str = new StringBuilder();
        DataSet ds = UpdateData.UpdateBySql("SELECT Content_Name,Content_Img,Content_URL FROM tbl_Content WHERE lang=" + Session["vlang"] + " AND Content_Status=1 AND Mod_ID in(SELECT Mod_ID FROM tbl_Mod WHERE Mod_Code='GiaiThuong') ORDER BY Content_Pos DESC");
        DataRowCollection rows = ds.Tables[0].Rows;
        str.Append("<ul class=\"bodySliderBottom\">");
        for (int i = 0; i < rows.Count; i++)
        {
            string n = rows[i]["Content_Name"].ToString();
            string img = ApplicationSetting.URLRoot + rows[i]["Content_Img"].ToString();
            string url = rows[i]["Content_URL"].ToString();
            str.Append("    <li><a href=\"" + url + "\" target=\"_blank\"><img src=\"" + img + "\" alt=\"" + n + "\" title=\"" + n + "\"/></a></li>");
        }
        str.Append("</ul>");
        return str.ToString();
    }
    #region Online Visitor Counter
    private void VisitorCounter()
    {
        double _visitor = 0;
        TextReader tr = new StreamReader(Server.MapPath("~/visitor.txt"));
        _visitor = Convert.ToDouble(tr.ReadLine());
        tr.Close();
        tr.Dispose();
        try
        {
            if (Session["_vUser"] == null)
            {
                Session["_vUser"] = "true";
                _visitor++;
                TextWriter tw = new StreamWriter(Server.MapPath("~/visitor.txt"));
                tw.Write(_visitor);
                tw.Close();
                tw.Dispose();
            }
        }
        catch { }
        ltrVisitor.Text = _visitor.ToString();
        ltrOnline.Text = Application["visitors_online"].ToString();
    }
    #endregion
}