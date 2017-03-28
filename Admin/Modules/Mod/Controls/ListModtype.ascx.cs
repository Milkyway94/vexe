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
using System.Text;
using SMAC;

public partial class Adadmin_Modules_Mess_Controls_ToUser : System.Web.UI.UserControl
{
    public string tp = "../../../Images/";
    public string sRootAppPath = "../../";
    public string Modtype_Parent;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Modtype_Parent = Request["TopicID"];
            BindData();            
        }
    }
    public void BindData()
    {
        Modtype_Parent = Request["TopicID"];
        string act = Request["act"];
        string sql = "SELECT * FROM tbl_Modtype";
        
        sql += " ORDER BY Modtype_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        dgrModtype.DataSource = ds;
        dgrModtype.DataKeyField = "Modtype_ID";
        dgrModtype.DataBind();
    }
    protected void dgrModtype_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemIndex >= 0)
        {
            e.Item.Attributes.Add("OnMouseOver", "this.style.backgroundColor = \'lightblue\';");
            e.Item.Attributes.Add("OnMouseOut", "this.style.backgroundColor = \'#F7F7F7\';");
            e.Item.Style.Add("Cursor", "Pointer");
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string url = "PopupWin.aspx?page=Modtype&act=edit&id=" + drv["Modtype_ID"] + "&TopicID=" + Modtype_Parent;
            //==================================================================            
            HyperLink hplName = (HyperLink)e.Item.FindControl("hplName");
            hplName.Text = ConvertUtil.CutString(drv["Modtype_Name"].ToString(), 70);
            //==================================================================
            Image imgEdit = (Image)e.Item.FindControl("imgEdit");
            imgEdit.Attributes.Add("onclick", "javascript:PopupWin('" + url + "',360, 170)");            
            //==================================================================                        
            bool isUse = Convert.ToBoolean(drv["Modtype_Status"]);
            ImageButton imgIsUse = (ImageButton)e.Item.FindControl("imgIsUse");
            imgIsUse.ImageUrl = (isUse == true) ? tp + "icons/button_yes.gif" : "../../../Images/notChecked.gif";
            LinkButton lbtDel = (LinkButton)e.Item.FindControl("lbtDel");
            lbtDel.Text = "<img src='../../Images/icon_delete.gif' border=0>";
            lbtDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có chắc chắn xoá tin này không ?');");
        }
    }
    protected void dgrModtype_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
        {
            string sSc = "<script>\n";
            sSc += "alert('Bạn cần gỡ các module sử dụng định dạng này trước khi xoá!');\n";
            sSc += "</script>\n";
            string id = dgrModtype.DataKeys[e.Item.ItemIndex].ToString();
            switch (e.CommandName)
            {
                case "del":
                    string sql = "SELECT * FROM tbl_Mod WHERE Modtype_ID=" + id;
                    DataSet ds = UpdateData.UpdateBySql(sql);
                    DataRowCollection rows = ds.Tables[0].Rows;
                    if (rows.Count > 0)
                        Response.Write(sSc);
                    else
                        UpdateData.Delete("tbl_Modtype", "Modtype_ID=" + id);
                    dgrModtype.EditItemIndex = -1;
                    BindData();
                    break;
                case "isUse":
                    DataSet dsU = UpdateData.UpdateBySql("SELECT Modtype_Status FROM tbl_Modtype WHERE Modtype_ID=" + id);
                    DataRowCollection rowsU = dsU.Tables[0].Rows;
                    bool isHot = false;
                    isHot = Convert.ToBoolean(rowsU[0]["Modtype_Status"]);
                    if (isHot)
                        UpdateData.UpdateOrder("UPDATE tbl_Modtype SET Modtype_Status=0 WHERE Modtype_ID=" + id);
                    else
                        UpdateData.UpdateOrder("UPDATE tbl_Modtype SET Modtype_Status=1 WHERE Modtype_ID=" + id);
                    dgrModtype.EditItemIndex = -1;
                    BindData();
                    break;
            }
        }
    }
    protected void dgrModtype_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgrModtype.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
}
