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

public partial class Admin_Modules_User_UserList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int pbID;
    protected void Page_Load(object sender, EventArgs e)
    {
        pbID = Convert.ToInt32(Request["pbID"]);
        if (!IsPostBack)
        {
            BindData();
            txtFind.Attributes.Add("onkeydown", String.Format("Search_Onclick(this,'{0}')", lbtSearch.ClientID));
            lbtDelAll.Attributes.Add("onclick", "javascript:return confirm('Bạn chắn chắn muốn xoá hết không ?')");
            string url = "PopupWin.aspx?page=User&act=add&pbID=" + pbID;
            hplAdd.NavigateUrl = url;

            string urlDepart = "PopupWin.aspx?page=Depart&act=add";
            hplAddDepart.NavigateUrl = urlDepart;
        }
    }
    public void BindData()
    {
        string act = Request["act"];
        string sql = "SELECT * FROM tbl_User WHERE 1=1 ";
        if (SessionUtil.GetValue("RoleID")!= "WebAdmin,")
            sql += " AND User_ID=" + SessionUtil.GetValue("UserID");
        if (pbID != 0)
            sql += " AND User_ID in (Select User_ID from tbl_User where User_Role=" + pbID + ")";
        if (act == "search")
        {
            string key = Request["key"];
            sql += " AND User_Name LIKE N'%" + key + "%' OR Username LIKE N'%" + key + "%'";
        }
        sql += " ORDER BY User_Date DESC";
        //Response.Write(SessionUtil.GetValue("RoleID")+sql);
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "User_ID" };
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
            int p = Convert.ToInt32(drv["User_ID"]);
            HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");
            hplName.Text = drv["User_Name"].ToString();
            //=======================================================
            Image AdminAccess = (Image)e.Row.FindControl("AdminAccess");
            string urlAdminAccess = "PopupWin.aspx?page=AdminAccess&id=" + drv["User_ID"] + "&pbID=" + pbID;
            AdminAccess.Attributes.Add("onclick", "javascript:PopupWin('" + urlAdminAccess + "',400,335)");
            //=======================================================
            Image SiteAccess = (Image)e.Row.FindControl("SiteAccess");
            string urlSiteAccess = "PopupWin.aspx?page=SiteAccess&id=" + drv["User_ID"] + "&pbID=" + pbID;
            SiteAccess.Attributes.Add("onclick", "javascript:PopupWin('" + urlSiteAccess + "',400,335)");
            ////=======================================================
            //Image Role = (Image)e.Row.FindControl("Role");
            //string urlRole = "PopupWin.aspx?page=Role&id=" + drv["User_ID"] + "&pbID=" + pbID;
            //Role.Attributes.Add("onclick", "javascript:PopupWin('" + urlRole + "',250,200)");
            //====================================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=User&act=edit&id=" + drv["User_ID"] + "&pbID=" + pbID;
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',550, 500)");
            //====================================================================
            bool isUse = Convert.ToBoolean(drv["User_Status"]);
            ImageButton imgUse = (ImageButton)e.Row.FindControl("imgUse");
            imgUse.ImageUrl = (isUse == true) ? tp + "yes.gif" : tp + "no.gif";
            //==============================================================     
            bool isSent = Convert.ToBoolean(drv["User_isSendInfo"]);
            ImageButton imgSent = (ImageButton)e.Row.FindControl("imgSent");
            imgSent.ImageUrl = (isSent == true) ? tp + "yes.gif" : tp + "no.gif";
            //=================================================================
            //ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
            //imgDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn xoá tin này không ?');");
        }
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sSc = "<script>\n";
        sSc += "alert('Đang tồn tại các dữ liệu liên quan đến user này!');\n";
        sSc += "</script>\n";
        switch (e.CommandName)
        {
            case "del":
                string id = e.CommandArgument.ToString();
                try
                {
                    if (UpdateData.Delete("tbl_User", "User_ID=" + id))
                    {
                        BindData();
                    }
                    else
                    {
                        Response.Write(sSc);
                    }
                }
                catch (Exception)
                {
                    Response.Write(sSc);
                }
               
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT User_Status FROM tbl_User WHERE User_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["User_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_User SET User_Status=0 WHERE User_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_User SET User_Status=1 WHERE User_ID=" + id01);
                BindData();
                break;
        }

    }
    protected void lbtSearch_Click(object sender, EventArgs e)
    {
        string key = ApplicationUtil.FormatString(txtFind.Value.Trim());
        Response.Redirect("UserList.aspx?act=search&key=" + key);
    }
    protected void lbtDelAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvData.Rows)
        {
            CheckBox cbItem = (CheckBox)item.FindControl("cbItem");
            if (cbItem.Checked)
            {
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                try
                {
                    if (UpdateData.Delete("tbl_ModsiteUser", "User_ID=" + id))
                    {
                        if (UpdateData.Delete("tbl_ModUser", "UserID=" + id))
                        {
                            UpdateData.Delete("tbl_User", "User_ID=" + id);
                        }
                    }
                }
                catch (Exception)
                {
                    string sSc = "<script>\n";
                    sSc += "alert('Đang tồn tại các dữ liệu liên quan đến user này!');\n";
                    sSc += "</script>\n";
                    Response.Write(sSc);
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
