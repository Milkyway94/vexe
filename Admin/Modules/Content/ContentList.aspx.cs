using System;
using System.Data;
using System.Web.UI.WebControls;
using SMAC;

public partial class Admin_Modules_Content_ContentList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        TopicID = Convert.ToInt32(Request["TopicID"]);
        if (!IsPostBack)
        {
            if (FunctionDB.GetModType(TopicID) == "Raovat")
                BindRaovat();
            else
                BindData();
            txtFind.Attributes.Add("onkeydown", String.Format("Search_Onclick(this,'{0}')", lbtSearch.ClientID));
            lbtDelAll.Attributes.Add("onclick", "javascript:return confirm('Bạn chắn chắn muốn xoá hết không ?')");
            string url = "PopupWin.aspx?page=" + FunctionDB.GetModType(TopicID) + "&act=add&TopicID=" + TopicID;
            hplHot.NavigateUrl = "ContentList.aspx?act=hot";
            switch (FunctionDB.GetModType(TopicID))
            {
                case "Enterprise":
                case "Concept":
                case "News":
                    //hplAdd.NavigateUrl = "javascript:PopupWin('" + url + "',900,100)";
                    hplAdd.NavigateUrl = url;
                    break;
                case "Gallery":
                    hplAdd.NavigateUrl = "javascript:PopupWin('" + url + "',600,250)";
                    break;
            }
        }
    }
    public void BindData()
    {
        string act = Request["act"];
        string sql = "SELECT top 500 Mod_ID,Content_ID,Content_Name,Content_Count,Content_Avata,Content_Pos,Content_Hot,Content_Status,Content_Date,Content_Home FROM tbl_Content WHERE lang=" + Session["lang"];
        if (TopicID != 0)
            sql += " AND Mod_ID=" + TopicID;
        if (act == "search")
        {
            string key = Request["key"];
            sql += " AND Content_Name LIKE N'%" + key + "%'";
        }
        if (act == "hot")
            sql += " AND Content_Hot=1";
        sql += " ORDER BY Content_ID DESC";
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "Content_ID" };
        gvData.DataKeyNames = arrKey01;
        gvData.DataBind(); 
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex >= 0)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor = \'lightblue\';");
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor = \'#F7F7F7\';");
            //=======================================================
            DataRowView drv = (DataRowView)e.Row.DataItem;
            int p = Convert.ToInt32(drv["Mod_ID"]);
            HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");
            hplName.Text = ConvertUtil.CutString(drv["Content_Name"].ToString(), 60);
            //==================================================
            HyperLink hplView = (HyperLink)e.Row.FindControl("hplView");
            hplView.Text = drv["Content_Count"].ToString();
            //==================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=" + FunctionDB.GetModType(p) + "&act=edit&TopicID=" + p + "&id=" + drv["Content_ID"];
            switch (FunctionDB.GetModType(p))
            {
                case "Enterprise":
                case "About":
                case "Service":
                case "Concept":
                case "News":
                    imgEdit.Attributes.Add("onclick", "javascript:window.location.href='"+ url+"'");
                    break;
                case "Gallery":
                    imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',600,250)");
                    break;
            }
            //==================================================
            //Image imgDisplay = (Image)e.Row.FindControl("imgDisplay");
            //imgDisplay.ImageUrl = (drv["Content_Avata"].ToString().Trim().Length > 0) ? tp + "yes.gif" : tp + "null.gif";
            TextBox txtOrder = (TextBox)e.Row.FindControl("txtOrder01");
            txtOrder.Text = drv["Content_Pos"].ToString();            
            //============================================
            bool isUse = Convert.ToBoolean(drv["Content_Status"]);
            ImageButton imgUse = (ImageButton)e.Row.FindControl("imgUse");
            imgUse.ImageUrl = (isUse == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================
            bool isHot = Convert.ToBoolean(drv["Content_Hot"]);
            ImageButton imgHot = (ImageButton)e.Row.FindControl("imgHot");
            imgHot.ImageUrl = (isHot == true) ? tp + "yes.gif" : tp + "no.gif";
            //==================================================
            Image imgAddPic = (Image)e.Row.FindControl("imgAddPic");
            string sql = "SELECT Content_ID FROM tbl_File WHERE Content_ID=" + drv["Content_ID"];
            DataSet ds = UpdateData.UpdateBySql(sql);
            DataRowCollection rows = ds.Tables[0].Rows;
            //imgAddPic.ImageUrl = (rows.Count > 0) ? tp + "chat.gif" : tp + "chatoff.gif";
            //imgAddPic.Attributes.Add("onclick", "javascript:LoadFile('" + drv["Content_ID"] + "')");
            //============================================         
            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
            imgDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn xoá tin này không ?');");
        }
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sSc = "<script>\n";
        sSc += "alert('Đang tồn tại thông tin khác trong bài này!');\n";
        sSc += "</script>\n";
        switch (e.CommandName)
        {
            case "del":
                string iddel = e.CommandArgument.ToString();
                UpdateData.Delete("tbl_Content", "Content_ID=" + iddel);
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Xoá", "Bài: " + FunctionDB.GetName("Content", iddel.ToString()));
                BindData();
                break;
            case "isHot":
                string id = e.CommandArgument.ToString();
                DataSet ds = UpdateData.UpdateBySql("SELECT Content_Hot FROM tbl_Content WHERE Content_ID=" + id);
                DataRowCollection rows = ds.Tables[0].Rows;
                bool isHot = false;
                isHot = Convert.ToBoolean(rows[0]["Content_Hot"]);
                if (isHot)
                    UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Hot=0 WHERE Content_ID=" + id);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Hot=1 WHERE Content_ID=" + id);
                BindData();
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT Content_Status FROM tbl_Content WHERE Content_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["Content_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Status=0 WHERE Content_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Status=1 WHERE Content_ID=" + id01);
                BindData();
                break;
            //case "isHome":
            //    string id02 = e.CommandArgument.ToString();
            //    DataSet dsHome = UpdateData.UpdateBySql("SELECT Content_Home FROM tbl_Content WHERE Content_ID=" + id02);
            //    DataRowCollection rowsHome = dsHome.Tables[0].Rows;
            //    bool isHome = false;
            //    isHome = Convert.ToBoolean(rowsHome[0]["Content_Home"]);
            //    if (isHome)
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Home=0 WHERE Content_ID=" + id02);
            //    else
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Home=1 WHERE Content_ID=" + id02);
            //    BindData();
            //    break;
            //case "isOK":
            //    string id03 = e.CommandArgument.ToString();
            //    DataSet dsOK = UpdateData.UpdateBySql("SELECT Content_OK FROM tbl_Content WHERE Content_ID=" + id03);
            //    DataRowCollection rowsOK = dsOK.Tables[0].Rows;
            //    bool isOK = false;
            //    isOK = Convert.ToBoolean(rowsOK[0]["Content_OK"]);
            //    if (isOK)
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_OK=0 WHERE Content_ID=" + id03);
            //    else
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_OK=1 WHERE Content_ID=" + id03);
            //    BindData();
            //    break;
            //case "isRSS":
            //    string id04 = e.CommandArgument.ToString();
            //    DataSet dsRSS = UpdateData.UpdateBySql("SELECT Content_RSS FROM tbl_Content WHERE Content_ID=" + id04);
            //    DataRowCollection rowsRSS = dsRSS.Tables[0].Rows;
            //    bool isRSS = false;
            //    isRSS = Convert.ToBoolean(rowsRSS[0]["Content_RSS"]);
            //    if (isRSS)
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_RSS=0 WHERE Content_ID=" + id04);
            //    else
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_RSS=1 WHERE Content_ID=" + id04);
            //    BindData();
            //    break;
            //case "isShare":
            //    int id05 = Convert.ToInt32(e.CommandArgument);
            //    DataSet dsShare = UpdateData.UpdateBySql("SELECT Content_Share FROM tbl_Content WHERE Content_ID=" + id05);
            //    DataRowCollection rowsShare = dsShare.Tables[0].Rows;
            //    bool isShare = false;
            //    isShare = Convert.ToBoolean(rowsShare[0]["Content_Share"]);
            //    if (isShare)
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Share=0 WHERE Content_ID=" + id05);
            //    else
            //        UpdateData.UpdateOrder("UPDATE tbl_Content SET Content_Share=1 WHERE Content_ID=" + id05);
            //    BindData();
            //    vn.edu.tdcbachmai.ArticleService service = new vn.edu.tdcbachmai.ArticleService();
            //    string n = ContentControl.GetContentField("Name", id05);
            //    string intro = ContentControl.GetContentField("Intro", id05);
            //    string text = ContentControl.GetContentField("Text", id05);
            //    service.InsertArticle(n, intro, text);  
            //    break;
        }
        if (e.CommandName == "Order01")
        {
            foreach (GridViewRow item in gvData.Rows)
            {
                int order = Convert.ToInt32(((TextBox)item.Cells[3].FindControl("txtOrder01")).Text.ToString());
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                string sql = "UPDATE tbl_Content SET Content_Pos=" + order + " WHERE Content_ID=" + id;
                UpdateData.UpdateOrder(sql);
            }
            BindData();
        }
    }
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet dsData = (DataSet)Session["dsData"];
        DataTable dtAccountData = dsData.Tables[0];
        if (dtAccountData != null)
        {
            DataView dataView = new DataView(dtAccountData);
            dataView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            gvData.DataSource = dataView;
            gvData.DataBind();
        }
    }
    protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["SortDirection"] == null)
            Session["SortDirection"] = "ASC";
        if (Session["SortExpression"] == null)
            Session["SortExpression"] = "1";
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int sortColumnIndex = GetSortColumnIndex();
            if (sortColumnIndex != -1)
            {
                AddSortImage(sortColumnIndex, e.Row);
            }
        }
    }
    int GetSortColumnIndex()
    {
        foreach (DataControlField field in gvData.Columns)
        {
            if (field.SortExpression == Session["SortExpression"].ToString())
            {
                return gvData.Columns.IndexOf(field);
            }
        }
        return 1;
    }
    private string GetSortDirection(string column)
    {
        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";
        // Retrieve the last column that was sorted.
        string sortExpression = Session["SortExpression"] as string;
        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = Session["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }
        // Save new values in ViewState.
        Session["SortDirection"] = sortDirection;
        Session["SortExpression"] = column;
        return sortDirection;
    }
    void AddSortImage(int columnIndex, GridViewRow headerRow)
    {
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        if (Session["SortDirection"].ToString() == "ASC")
        {
            sortImage.ImageUrl = tp + "down.gif";
            sortImage.AlternateText = "Ascending Order";
        }
        else
        {
            sortImage.ImageUrl = tp + "up.gif";
            sortImage.AlternateText = "Descending Order";
        }
        // Add the image to the appropriate header cell.
        headerRow.Cells[columnIndex].Controls.Add(sortImage);
    }
    protected void lbtSearch_Click(object sender, EventArgs e)
    {
        string key = ApplicationUtil.FormatString(txtFind.Value.Trim());
        Response.Redirect("ContentList.aspx?act=search&key=" + key);
    }
    protected void lbtDelAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvData.Rows)
        {
            CheckBox cbItem = (CheckBox)item.FindControl("cbItem");
            if (cbItem.Checked)
            {
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                UpdateData.Delete("tbl_Content", "Content_ID=" + id);
            }
        }
        BindData();
    }
    //==============Rao vat===================
    public void BindRaovat()
    {
        string act = Request["act"];
        string key = Request["key"];
        string sql = "SELECT top 200 Mod_ID,Raovat_ID,Raovat_Title,Raovat_Name,Raovat_Count,Raovat_Img,Raovat_Status,Raovat_Date,Raovat_VIP1,Raovat_VIP2 FROM tbl_Raovat WHERE 1=1";
        if (TopicID != 0)
            sql += " AND Mod_ID=" + TopicID;
        if (act == "search")
            sql += " AND Raovat_Title LIKE N'%" + key + "%'";
        sql += " ORDER BY Raovat_ID DESC";
        DataSet dsRaovat = UpdateData.UpdateBySql(sql);
        Session["dsRaovat"] = dsRaovat;
        gvRaovat.DataSource = dsRaovat;
        string[] arrKey01 = { "Raovat_ID" };
        gvRaovat.DataKeyNames = arrKey01;
        gvRaovat.DataBind();
    }
    protected void gvRaovat_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex >= 0)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor = \'lightblue\';");
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor = \'#F7F7F7\';");
            //=======================================================
            DataRowView drv = (DataRowView)e.Row.DataItem;
            int p = Convert.ToInt32(drv["Mod_ID"]);            
            //==================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=Raovat&act=edit&TopicID=" + p + "&id=" + drv["Raovat_ID"];
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',690,480)");
            //==================================================
            Image imgDisplay = (Image)e.Row.FindControl("imgDisplay");
            if (drv["Raovat_Img"].ToString().Trim().Length > 0)
                imgDisplay.ImageUrl = tp + "yes.gif";
            else
                imgDisplay.ImageUrl = tp + "null.gif";
            //============================================
            bool isUse = Convert.ToBoolean(drv["Raovat_Status"]);
            ImageButton imgUse = (ImageButton)e.Row.FindControl("imgUse");
            imgUse.ImageUrl = (isUse == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================
            bool isVIP1 = Convert.ToBoolean(drv["Raovat_VIP1"]);
            ImageButton imgVIP1 = (ImageButton)e.Row.FindControl("imgVIP1");
            imgVIP1.ImageUrl = (isVIP1 == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================
            bool isVIP2 = Convert.ToBoolean(drv["Raovat_VIP2"]);
            ImageButton imgVIP2 = (ImageButton)e.Row.FindControl("imgVIP2");
            imgVIP2.ImageUrl = (isVIP2 == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================            
            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
            imgDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn xoá tin này không ?');");
        }
    }
    protected void gvRaovat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sSc = "<script>\n";
        sSc += "alert('Đang tồn tại thông tin khác trong bài này!');\n";
        sSc += "</script>\n";
        switch (e.CommandName)
        {
            case "del":
                string iddel = e.CommandArgument.ToString();
                UpdateData.Delete("tbl_Raovat", "Raovat_ID=" + iddel);
                BindRaovat();
                break;            
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT Raovat_Status FROM tbl_Raovat WHERE Raovat_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["Raovat_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_Status=0 WHERE Raovat_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_Status=1 WHERE Raovat_ID=" + id01);
                BindRaovat();
                break;
            case "isVIP1":
                string idV1 = e.CommandArgument.ToString();
                DataSet dsV1 = UpdateData.UpdateBySql("SELECT Raovat_VIP1 FROM tbl_Raovat WHERE Raovat_ID=" + idV1);
                DataRowCollection rowsV1 = dsV1.Tables[0].Rows;
                bool isVIP1 = false;
                isVIP1 = Convert.ToBoolean(rowsV1[0]["Raovat_VIP1"]);
                if (isVIP1)
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_VIP1=0 WHERE Raovat_ID=" + idV1);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_VIP1=1 WHERE Raovat_ID=" + idV1);
                BindRaovat();
                break;
            case "isVIP2":
                string idV2 = e.CommandArgument.ToString();
                DataSet dsV2 = UpdateData.UpdateBySql("SELECT Raovat_VIP2 FROM tbl_Raovat WHERE Raovat_ID=" + idV2);
                DataRowCollection rowsV2 = dsV2.Tables[0].Rows;
                bool isVIP2 = false;
                isVIP2 = Convert.ToBoolean(rowsV2[0]["Raovat_VIP2"]);
                if (isVIP2)
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_VIP2=0 WHERE Raovat_ID=" + idV2);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Raovat SET Raovat_VIP2=1 WHERE Raovat_ID=" + idV2);
                BindRaovat();
                break;
        }
        
    }
    protected void gvRaovat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRaovat.PageIndex = e.NewPageIndex;
        BindRaovat();
    }
    protected void gvRaovat_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet dsRaovat = (DataSet)Session["dsRaovat"];
        DataTable dtAccountData = dsRaovat.Tables[0];
        if (dtAccountData != null)
        {
            DataView dataView = new DataView(dtAccountData);
            dataView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            gvRaovat.DataSource = dataView;
            gvRaovat.DataBind();
        }
    }
    protected void gvRaovat_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["SortDirection"] == null)
            Session["SortDirection"] = "ASC";
        if (Session["SortExpression"] == null)
            Session["SortExpression"] = "1";
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int sortColumnIndex = GetSortColumnIndex();
            if (sortColumnIndex != -1)
            {
                AddSortImage(sortColumnIndex, e.Row);
            }
        }
    }
}
