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

public partial class Admin_Modules_Skin_Controls_SkinFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id, SkintypeID, ModID;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];        
        id  = Request["id"];
        SkintypeID = Request["SkintypeID"];
        ModID = Request["ModID"];
        if (!IsPostBack)
        {
            bindToDropDown(ddlMod);
            this.LoadType();
            for (int i = 0; i < ddlSkintype.Items.Count; i++)
            {
                if (SkintypeID == ddlSkintype.Items[i].Value)
                    ddlSkintype.Items[i].Selected = true;
            }
            if (act == "edit")
                ViewEdit(id);
        }
    }
    public void bindToDropDown(DropDownList ddl)
    {
        string sql = "SELECT Mod_ID,Mod_Parent,Mod_Name,Mod_Level FROM tbl_Mod WHERE Mod_ID in(SELECT Mod_ID FROM tbl_ModsiteUser WHERE User_ID=" + Session["UserID"] + ") ORDER BY Mod_Pos";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            if (rows[i]["Mod_Parent"].ToString() == "0")
            {
                ListItem item = new ListItem();
                item.Text = rows[i]["Mod_Name"].ToString();
                item.Value = rows[i]["Mod_ID"].ToString();
                ddl.Items.Add(item);
                ddl.Attributes.Add("style", "color:#FF3300");
                GetChildItems(rows[i]["Mod_ID"].ToString(), ds, ddl);
            }
        }
        ListItem topitem = new ListItem();
        topitem.Text = "--------------Chọn nhóm--------------";
        topitem.Value = "-1";
        ddl.Items.Insert(0, topitem);
    }
    private void GetChildItems(string parentID, DataSet dtTemp, DropDownList ddl)
    {
        DataRowCollection rows = dtTemp.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string child = "";
            if (rows[i]["Mod_Parent"].ToString() == parentID.ToString())
            {
                for (int j = 0; j < Convert.ToInt32(rows[i]["Mod_Level"]); j++)
                {
                    child = child + "--";
                }
                ListItem chilitem = new ListItem();
                if (Convert.ToInt32(rows[i]["Mod_Parent"]) != 0)
                    chilitem.Attributes.Add("style", "color:#000");
                chilitem.Text = child + rows[i]["Mod_Name"].ToString();
                chilitem.Value = rows[i]["Mod_ID"].ToString();

                ddl.Items.Add(chilitem);
                GetChildItems(rows[i]["Mod_ID"].ToString(), dtTemp, ddl);
            }
        }
    } 
    public void LoadType()
    {
        DataSet dsT = UpdateData.UpdateBySql("SELECT Skintype_ID, Skintype_Name FROM tbl_Skintype");
        DataRowCollection rowsT = dsT.Tables[0].Rows;
        for (int i = 0; i < rowsT.Count; i++)
        {
            ddlSkintype.Items.Insert(i, new ListItem(".." + rowsT[i][1].ToString(), rowsT[i][0].ToString()));
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Skin WHERE Skin_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        if (rows.Count > 0)
        {
            txtName.Text    = rows[0]["Skin_Name"].ToString();
            txtLink.Text    = rows[0]["Skin_Link"].ToString();
            txtPos.Text     = rows[0]["Skin_Pos"].ToString();
            txtWidth.Text   = rows[0]["Skin_Width"].ToString();
            txtHeight.Text  = rows[0]["Skin_Height"].ToString();
            txtImg.Text     = rows[0]["Skin_Url"].ToString();
            CKTeaser.Text = rows[0]["Skin_Content"].ToString();
            //txtBackground.Text = rows[0]["Skin_Background"].ToString();
            bool isUse      = Convert.ToBoolean(rows[0]["Skin_Status"]);
            cbIsUse.Checked = (isUse == true) ? true : false;
            for (int i = 0; i < ddlSkintype.Items.Count; i++)
            {
                if (ddlSkintype.Items[i].Value == rows[0]["Skintype_ID"].ToString())
                    ddlSkintype.Items[i].Selected = true;
            }
            for (int i = 0; i < ddlMod.Items.Count; i++)
            {
                if (ddlMod.Items[i].Value == rows[0]["Mod_ID"].ToString())
                    ddlMod.Items[i].Selected = true;
            }
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"SkinList.aspx?SkintypeID=" + ddlSkintype.SelectedValue + "&ModID=" + ddlMod.SelectedValue + "\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        Hashtable tbIn = new Hashtable();
        tbIn.Add("Skintype_ID", ddlSkintype.SelectedValue);
        tbIn.Add("Mod_ID", ddlMod.SelectedValue);
        tbIn.Add("Skin_Url", txtImg.Text.Replace("/upload", "upload"));
        //tbIn.Add("Skin_Background", txtBackground.Text.Replace("/upload", "upload"));
        tbIn.Add("Skin_Name", txtName.Text);
        tbIn.Add("Skin_Link", txtLink.Text);
        tbIn.Add("Skin_Width", txtWidth.Text);
        tbIn.Add("Skin_Height", txtHeight.Text);
        tbIn.Add("Skin_Status", isUse);
        tbIn.Add("Skin_Pos", txtPos.Text);
        tbIn.Add("Skin_Content", CKTeaser.Text);
        if (act == "add")
        {
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Skin", tbIn);            
            Response.Write(sScritp);
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Skin", tbIn, "Skin_ID=" + id);            
            Response.Write(sScritp);
        }
    }
}
