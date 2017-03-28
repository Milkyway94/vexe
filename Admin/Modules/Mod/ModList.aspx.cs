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

public partial class Admin_Modules_Mod_ModList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int TopicID, format;
    protected void Page_Load(object sender, EventArgs e)
    {

        TopicID = Convert.ToInt32(Request["TopicID"]);
        if (ModControl.GetModtypeFromModID(TopicID) != "")
        {
            format = int.Parse(ModControl.GetModtypeFromModID(TopicID));
        }
        if (!IsPostBack)
        {
            BindData();
            txtFind.Attributes.Add("onkeydown", String.Format("Search_Onclick(this,'{0}')", lbtSearch.ClientID));
            lbtDelAll.Attributes.Add("onclick", "javascript:return confirm('Bạn chắn chắn muốn xoá hết không ?')");
            string url = "";
            switch (format)
            {
                case 21:
                case 17:
                case 18:
                    url = "PopupWin.aspx?page=Product&act=add&TopicID=" + TopicID;
                    hplAdd.NavigateUrl = "javascript:window.location.href=\"" + url + "\"";
                    break;
                default:
                    url = "PopupWin.aspx?page=Mod&act=add&TopicID=" + TopicID;
                    hplAdd.NavigateUrl = "javascript:window.location.href=\"" + url + "\"";
                    break;
            }
            //if (TopicID != 1342 && ModControl.GetParent(TopicID)!=1342)
            //{
            //    string url = "PopupWin.aspx?page=Mod&act=add&TopicID=" + TopicID;
            //    hplAdd.NavigateUrl = "javascript:window.location.href="+ url;
            //}
            //else
            //{
            //    per = false;
            //}
            //if (per == false)
            //{
            //    Response.Write("<script>alert(\"Mời bạn truy cập vào phần Quản trị Danh mục sản phẩm để cập nhật.\")</script>");
            //}
        }
    }
    public void BindData()
    {
        string act = Request["act"];
        string sql = "SELECT Mod_ID,Mod_Name,Mod_Code,Mod_Img,Mod_Status,Mod_Hot,Mod_Pos, Modtype_ID FROM tbl_Mod WHERE lang=" + Session["lang"];
        if (TopicID == 0 || TopicID == -1)
            sql += " AND Mod_Parent=0";
        else
            sql += " AND Mod_Parent=" + TopicID;
        if (act == "search")
        {
            string key = Request["key"];
            sql += " AND Mod_Name LIKE N'%" + key + "%'";
        }
        sql += " ORDER BY Mod_Pos";
        //Response.Write(sql);
        //Response.End();
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "Mod_ID" };
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
            hplName.Text = drv["Mod_Name"].ToString();
            //==================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "";
            switch (format)
            {
                case 21:
                case 17:
                case 18:
                    url = "PopupWin.aspx?page=Product&act=edit&id=" + drv["Mod_ID"] + "&TopicID=" + TopicID;
                    imgEdit.Attributes.Add("onclick", "javascript: window.location.href=\"" + url + "\"");
                    break;
                default:
                    url = "PopupWin.aspx?page=Mod&act=edit&id=" + drv["Mod_ID"] + "&TopicID=" + TopicID;
                    imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',600, 520)");
                    break;
            }
            //if (TopicID != 1342 && ModControl.GetParent(TopicID) != 1342)
            //{
            //    string url = "PopupWin.aspx?page=Mod&act=edit&id=" + drv["Mod_ID"] + "&TopicID=" + TopicID;
            //    imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',600, 520)");
            //}
            //else
            //{
            //    per = false;
            //}
            //==================================================
            TextBox txtOrder = (TextBox)e.Row.FindControl("txtOrder01");
            txtOrder.Text = drv["Mod_Pos"].ToString();
            //==================================================
            HyperLink hplControl = (HyperLink)e.Row.FindControl("hplControl");
            hplControl.Text = ContentControl._LoadControl(Convert.ToInt32(drv["Mod_ID"]));
            //==================================================
            bool isUse = Convert.ToBoolean(drv["Mod_Status"]);
            ImageButton imgUse = (ImageButton)e.Row.FindControl("imgUse");
            imgUse.ImageUrl = (isUse == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================
            bool isHot = Convert.ToBoolean(drv["Mod_Hot"]);
            ImageButton imgHot = (ImageButton)e.Row.FindControl("imgHot");
            imgHot.ImageUrl = (isHot == true) ? tp + "yes.gif" : tp + "no.gif";
            //============================================      

            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
            imgDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn xoá tin này không ?');");

        }
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sSc = "<script>\n";
        sSc += "alert('Đang tồn tại module khác bên trong hoặc đã bài viết của module này!');\n";
        sSc += "</script>\n";
        switch (e.CommandName)
        {
            case "del":
                if (TopicID != 1342 && ModControl.GetParent(TopicID) != 1342)
                {
                    string iddel = e.CommandArgument.ToString();
                    string sql = "SELECT * FROM tbl_Mod WHERE Mod_Parent=" + iddel;
                    string sqlC = "SELECT * FROM tbl_Content WHERE Mod_ID=" + iddel;
                    DataSet ds = UpdateData.UpdateBySql(sql);
                    DataRowCollection rows = ds.Tables[0].Rows;
                    DataSet dsC = UpdateData.UpdateBySql(sqlC);
                    DataRowCollection rowsC = dsC.Tables[0].Rows;
                    if ((rows.Count > 0) || (rowsC.Count > 0))
                    {
                        Response.Write(sSc);
                    }
                    else
                    {
                        try
                        {
                            UpdateData.Delete("tbl_Mod", "Mod_ID=" + iddel);
                        }
                        catch (Exception)
                        {

                            Response.Write("<script>alert('Module đang được sở hữu bởi người khác, bạn không được xóa nó.')</script>");
                        }
                        

                        FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Xoá", "Module:" + FunctionDB.GetName("Mod", iddel));
                    }
                    BindData();
                }
                break;
            case "isHot":
                string id = e.CommandArgument.ToString();
                DataSet dsH = UpdateData.UpdateBySql("SELECT Mod_Hot FROM tbl_Mod WHERE Mod_ID=" + id);
                DataRowCollection rowsH = dsH.Tables[0].Rows;
                bool isHot = false;
                isHot = Convert.ToBoolean(rowsH[0]["Mod_Hot"]);
                if (isHot)
                    UpdateData.UpdateOrder("UPDATE tbl_Mod SET Mod_Hot=0 WHERE Mod_ID=" + id);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Mod SET Mod_Hot=1 WHERE Mod_ID=" + id);
                BindData();
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                int idcat = 0;
                //if (format == 17 || format == 18 || format == 21)
                //{
                //   idcat = ProductControl.GetShopFromMod(int.Parse(id01)).ShopCatID;
                //}
                DataSet dsU = UpdateData.UpdateBySql("SELECT Mod_Status FROM tbl_Mod WHERE Mod_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["Mod_Status"]);
                if (isUse)
                {
                    UpdateData.UpdateOrder("UPDATE tbl_Mod SET Mod_Status=0 WHERE Mod_ID=" + id01);
                    if (format == 17 || format == 18 || format == 21)
                    {
                        UpdateData.UpdateOrder("UPDATE Shop_Category SET isPublish=0 WHERE ID=" + idcat);
                    }
                }
                else
                {
                    UpdateData.UpdateOrder("UPDATE tbl_Mod SET Mod_Status=1 WHERE Mod_ID=" + id01);
                    if (format == 17 || format == 18 || format == 21)
                    {
                        UpdateData.UpdateOrder("UPDATE Shop_Category SET isPublish=0 WHERE ID=" + idcat);
                    }
                }

                BindData();
                break;
        }
        if (e.CommandName == "Order01")
        {
            foreach (GridViewRow item in gvData.Rows)
            {
                int order = Convert.ToInt32(((TextBox)item.Cells[3].FindControl("txtOrder01")).Text.ToString());
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                string sql = "UPDATE tbl_Mod SET Mod_Pos=" + order + " WHERE Mod_ID=" + id;
                UpdateData.UpdateOrder(sql);
            }
            BindData();
        }
    }
    protected void lbtSearch_Click(object sender, EventArgs e)
    {
        string key = ApplicationUtil.FormatString(txtFind.Value.Trim());
        Response.Redirect("ModList.aspx?act=search&key=" + key);
    }
    protected void lbtDelAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvData.Rows)
        {
            CheckBox cbItem = (CheckBox)item.FindControl("cbItem");
            if (cbItem.Checked)
            {
                int iddel = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                try
                {
                    if(AuthenticationMenu.CheckPermission(iddel, int.Parse(Session["UserId"].ToString())))
                    {
                        UpdateData.Delete("tbl_ModSiteUser", "User_Id=" + int.Parse(Session["UserID"].ToString()));
                    }
                    UpdateData.Delete("tbl_Mod", "Mod_ID=" + iddel);
                }
                catch (Exception)
                {

                    Response.Write("<script>alert('Module tại trong 1 module khác hoặc được sở hữu bởi 1 người khác, bạn không thể xóa nó');</script>");
                }
                
            }
        }
        BindData();
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
}
