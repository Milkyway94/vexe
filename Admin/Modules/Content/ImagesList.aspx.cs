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

public partial class ImagesList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public int p;
    protected void Page_Load(object sender, EventArgs e)
    {
        //CMSfunc.checkURL();
        if (Session["UserID"] == null)
            Response.Redirect(ApplicationSetting.URLRoot + "Admin/login.aspx");
        p = Convert.ToInt32(Request["p"]);
        if (!IsPostBack)
        {
            BindData();
            txtFind.Attributes.Add("onkeydown", String.Format("Search_Onclick(this,'{0}')", lbtSearch.ClientID));
            lbtDelAll.Attributes.Add("onclick", "javascript:return confirm('Bạn chắn chắn muốn xoá hết không ?')");
            string url = "PopupWin.aspx?page=File&act=add&p=" + p;
            hplAdd.NavigateUrl = "javascript:PopupWin('" + url + "',500,180)";
        }
    }
    public void BindData()
    {
        string act = Request["act"];
        string sql = "SELECT * FROM tbl_File WHERE 1=1";
        if (p != 0)
            sql += " AND Content_ID=" + p;
        sql += " ORDER BY File_Pos";
        //Response.Write(sql);
        //Response.End();
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "File_ID" };
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
            int p = Convert.ToInt32(drv["Content_ID"]);
            HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");
            hplName.Text = ConvertUtil.CutString(drv["File_Name"].ToString(), 70) + "&nbsp;<font color='#777777' style='font-style:italic; font-size:10px;'>(" + DateTimeUtil.DateFormat("{0}/{1}/{2}", Convert.ToDateTime(drv["File_Date"])) + ")</font>";
            //==================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=File&act=edit&p=" + p + "&id=" + drv["File_ID"];
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',500,180)");
            //==================================================
            Image imgDisplay = (Image)e.Row.FindControl("imgDisplay");
            if (drv["File_Small"].ToString().Trim().Length > 0)
                imgDisplay.ImageUrl = "~/" + drv["File_Small"].ToString();
            //==================================================
            TextBox txtOrder = (TextBox)e.Row.FindControl("txtOrder01");
            txtOrder.Text = drv["File_Pos"].ToString();            
            //============================================
            bool isUse = Convert.ToBoolean(drv["File_Status"]);
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
        sSc += "alert('Đang tồn tại thông tin khác trong bài này!');\n";
        sSc += "</script>\n";
        switch (e.CommandName)
        {
            case "del":
                string iddel = e.CommandArgument.ToString();
                UpdateData.Delete("tbl_File", "File_ID=" + iddel);
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Xoá", "Bài: " + FunctionDB.GetName("Content", iddel.ToString()));
                BindData();
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT File_Status FROM tbl_File WHERE File_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["File_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_File SET File_Status=0 WHERE File_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_File SET File_Status=1 WHERE File_ID=" + id01);
                BindData();
                break;
        }
        if (e.CommandName == "Order01")
        {
            foreach (GridViewRow item in gvData.Rows)
            {
                int order = Convert.ToInt32(((TextBox)item.Cells[3].FindControl("txtOrder01")).Text.ToString());
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                string sql = "UPDATE tbl_File SET File_Pos=" + order + " WHERE File_ID=" + id;
                UpdateData.UpdateOrder(sql);
            }
            BindData();
        }
    }
    protected void lbtSearch_Click(object sender, EventArgs e)
    {
        string key = ApplicationUtil.FormatString(txtFind.Value.Trim());
        Response.Redirect("ImagesList.aspx?act=search&key=" + key);
    }
    protected void lbtDelAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvData.Rows)
        {
            CheckBox cbItem = (CheckBox)item.FindControl("cbItem");
            if (cbItem.Checked)
            {
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                UpdateData.Delete("tbl_File", "File_ID=" + id);
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
