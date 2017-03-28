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

public partial class SkintypeList : DefaultAdmin
{
    public string tp = "../../Themes/";
    public string SkintypeID, ModID;
    protected void Page_Load(object sender, EventArgs e)
    {
        SkintypeID = Request["SkintypeID"];
        ModID = Request["ModID"];
        if (!IsPostBack)
        {
            BindData();
            lbtDelAll.Attributes.Add("onclick", "javascript:return confirm('Bạn chắn chắn muốn xoá hết không ?')");
            string url = "PopupWin.aspx?page=Skintype&act=add&SkintypeID=" + SkintypeID;
            hplAdd.NavigateUrl = "javascript:PopupWin('" + url + "',540, 180)";
        }
    }
    public void BindData()
    {
        string sql = "SELECT * FROM tbl_Skintype";
        sql += " ORDER BY Skintype_Pos";
        //Response.Write(sql);
        //Response.End();
        DataSet dsData = UpdateData.UpdateBySql(sql);
        Session["dsData"] = dsData;
        gvData.DataSource = dsData;
        string[] arrKey01 = { "Skintype_ID" };
        gvData.DataKeyNames = arrKey01;
        gvData.DataBind(); 
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex >= 0)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor = \'lightblue\';");
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor = \'#F7F7F7\';");
            //==================================================
            DataRowView drv = (DataRowView)e.Row.DataItem;
            int p = Convert.ToInt32(drv["Skintype_ID"]);
            HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");
            hplName.Text = drv["Skintype_Name"].ToString();
            //==================================================            
            HyperLink hplType = (HyperLink)e.Row.FindControl("hplType");
            bool view = Convert.ToBoolean(drv["Skintype_Viewtype"]);
            hplType.Text = (view == true) ? "Dọc" : "Ngang";
            //==================================================
            HyperLink hplWidth = (HyperLink)e.Row.FindControl("hplWidth");
            hplWidth.Text = drv["Skintype_Width"].ToString() + " px";
            //==================================================           
            HyperLink hplHeight = (HyperLink)e.Row.FindControl("hplHeight");
            hplHeight.Text = drv["Skintype_Height"].ToString() + " px";
            //==================================================
            Image imgEdit = (Image)e.Row.FindControl("imgEdit");
            string url = "PopupWin.aspx?page=Skintype&act=edit&id=" + drv["Skintype_ID"];
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',540, 180)");         
            //==================================================
            TextBox txtOrder = (TextBox)e.Row.FindControl("txtOrder01");
            txtOrder.Text = drv["Skintype_Pos"].ToString();            
            //==================================================
            bool isUse = Convert.ToBoolean(drv["Skintype_Status"]);
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
                UpdateData.Delete("tbl_Skintype", "Skintype_ID=" + iddel);
                BindData();
                break;
            case "isUse":
                string id01 = e.CommandArgument.ToString();
                DataSet dsU = UpdateData.UpdateBySql("SELECT Skintype_Status FROM tbl_Skintype WHERE Skintype_ID=" + id01);
                DataRowCollection rowsU = dsU.Tables[0].Rows;
                bool isUse = false;
                isUse = Convert.ToBoolean(rowsU[0]["Skintype_Status"]);
                if (isUse)
                    UpdateData.UpdateOrder("UPDATE tbl_Skintype SET Skintype_Status=0 WHERE Skintype_ID=" + id01);
                else
                    UpdateData.UpdateOrder("UPDATE tbl_Skintype SET Skintype_Status=1 WHERE Skintype_ID=" + id01);
                BindData();
                break;
        }
        if (e.CommandName == "Order01")
        {
            foreach (GridViewRow item in gvData.Rows)
            {
                int order = Convert.ToInt32(((TextBox)item.Cells[3].FindControl("txtOrder01")).Text.ToString());
                int id = Convert.ToInt32(gvData.DataKeys[item.RowIndex].Value.ToString());
                string sql = "UPDATE tbl_Skintype SET Skintype_Pos=" + order + " WHERE Skintype_ID=" + id;
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
                UpdateData.Delete("tbl_Skintype", "Skintype_ID=" + id);
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
