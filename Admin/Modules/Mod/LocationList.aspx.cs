using System;
using System.Data;
using System.Web.UI.WebControls;
using SMAC;

public partial class Mod_LocationList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        TopicID = Convert.ToInt32(Request["TopicID"]);
        if (!IsPostBack)
        {
            BindData();            
            string url = "PopupWin.aspx?page=Location&act=add";
            hplAdd.NavigateUrl = "javascript:PopupWin('" + url + "',350, 180)";
        }
    }
    public void BindData()
    {
        string sql = "SELECT Location_ID,Location_Name,Location_Code,Location_Status,Location_Pos FROM tbl_Location WHERE lang=" + Session["lang"];
        if (TopicID == 0 || TopicID == -1)
            sql += " AND Location_Parent=0";
        else
            sql += " AND Location_Parent=" + TopicID;
        sql += " ORDER BY Location_Pos";
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "Location_ID" };
        gvData.DataKeyNames = arrKey01;
        gvData.DataBind(); 
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex >= 0)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor = \'lightblue\';");
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor = \'#F7F7F7\';");
            //============================================
            DataRowView drv = (DataRowView)e.Row.DataItem;
            int p = Convert.ToInt32(drv["Location_ID"]);
            HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");
            hplName.Text = drv["Location_Name"].ToString();
            //============================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=Location&act=edit&id=" + drv["Location_ID"];
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',350, 180)");
            //============================================
            TextBox txtOrder = (TextBox)e.Row.FindControl("txtOrder01");
            txtOrder.Text = drv["Location_Pos"].ToString();
            //============================================
            bool isUse = Convert.ToBoolean(drv["Location_Status"]);
            ImageButton imgUse = (ImageButton)e.Row.FindControl("imgUse");
            imgUse.ImageUrl = (isUse == true) ? tp + "yes.gif" : tp + "no.gif";           
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
                string iddel = e.CommandArgument.ToString();
                UpdateData.Delete("tbl_Location", "Location_ID=" + iddel);
                BindData();
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT Location_Status FROM tbl_Location WHERE Location_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["Location_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_Location SET Location_Status=0 WHERE Location_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Location SET Location_Status=1 WHERE Location_ID=" + id01);
                BindData();
                break;
        }
        if (e.CommandName == "Order01")
        {
            foreach (GridViewRow item in gvData.Rows)
            {
                int order = Convert.ToInt32(((TextBox)item.Cells[3].FindControl("txtOrder01")).Text.ToString());
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                string sql = "UPDATE tbl_Location SET Location_Pos=" + order + " WHERE Location_ID=" + id;
                UpdateData.UpdateOrder(sql);
            }
            BindData();
        }
    }
    protected void lbtDelAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvData.Rows)
        {
            CheckBox cbItem = (CheckBox)item.FindControl("cbItem");
            if (cbItem.Checked)
            {
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                UpdateData.Delete("tbl_Location", "Location_ID=" + id);
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
