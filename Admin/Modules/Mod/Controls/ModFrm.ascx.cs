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

public partial class Admin_Modules_Mod_Controls_ModFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, format;
    public int level, id, TopicID;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        id = Convert.ToInt32(Request["id"]);
        TopicID = Convert.ToInt32(Request["TopicID"]);
        if (!IsPostBack)
        {
            //CKEditor.NET.CKEditorConfig.toolbar = "Basic";
            bindToDropDown(ddlGroup);
            this.LoadType();
            //==========================================================================
            if (act == "edit")
            {
                ViewEdit(id);
            }
            if (act == "add")
            {
                for (int i = 0; i < ddlGroup.Items.Count; i++)
                {
                    if (TopicID.ToString() == ddlGroup.Items[i].Value)
                        ddlGroup.Items[i].Selected = true;
                }
            }
        }
    }
    public void bindToDropDown(DropDownList ddl)
    {
        string sql = "SELECT Mod_ID,Mod_Parent,Mod_Name,Mod_Level FROM tbl_Mod WHERE lang=" + Session["lang"];
        sql += " AND Mod_ID in(SELECT Mod_ID FROM tbl_ModsiteUser WHERE User_ID=" + Session["UserID"] + ") ORDER BY Mod_Pos";
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
        topitem.Text = "-------- Root ---------";
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
        DataSet dsType = UpdateData.UpdateBySql("SELECT Modtype_ID,Modtype_Name FROM tbl_Modtype WHERE Modtype_Status=1 ORDER BY Modtype_Pos");
        DataRowCollection rowsType = dsType.Tables[0].Rows;
        for (int i = 0; i < rowsType.Count; i++)
        {
            ddlModtype.Items.Insert(i, new ListItem(rowsType[i]["Modtype_Name"].ToString(), rowsType[i]["Modtype_ID"].ToString()));
        }
    }

    public void ViewEdit(int id)
    {
        string sql = "SELECT Mod_Name,Mod_Code,Mod_Content,Mod_Url,Mod_Pos,Mod_Title,Mod_Key,Mod_Des,Mod_Img,Mod_Status,Mod_Parent,Modtype_ID FROM tbl_Mod WHERE Mod_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;


        txtName.Text = rows[0]["Mod_Name"].ToString();
        txtCode.Text = rows[0]["Mod_Code"].ToString();
        txtURL.Text = rows[0]["Mod_URL"].ToString();
        CKContent.Text = rows[0]["Mod_Content"].ToString();
        txtTitle.Text = rows[0]["Mod_Title"].ToString();
        txtKey.Text = rows[0]["Mod_Key"].ToString();
        txtDes.Text = rows[0]["Mod_Des"].ToString();
        txtImg.Text = rows[0]["Mod_Img"].ToString();
        txtPos.Text = rows[0]["Mod_Pos"].ToString();
        cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Mod_Status"]) == true) ? true : false;
        for (int i = 0; i < ddlGroup.Items.Count; i++)
        {
            if (rows[0]["Mod_Parent"].ToString() == ddlGroup.Items[i].Value)
                ddlGroup.Items[i].Selected = true;
        }
        for (int i = 0; i < ddlModtype.Items.Count; i++)
        {
            if (rows[0]["Modtype_ID"].ToString() == ddlModtype.Items[i].Value)
                ddlModtype.Items[i].Selected = true;
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var a = opener.parent.dhxLayout.cells(\"a\");";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "a.attachURL(\"Tree.aspx\");";
        sScritp += "b.attachURL(\"/Admin/Modules/Mod/ModList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";
        //====================Lấy Level========================
        //string sql = "SELECT Mod_Level FROM tbl_Mod WHERE Mod_ID=" + ddlGroup.SelectedValue;
        //DataSet ds = UpdateData.UpdateBySql(sql);
        //DataRowCollection rows = ds.Tables[0].Rows;
        string group = ddlGroup.SelectedValue.ToString();
        if (Convert.ToInt32(ddlGroup.SelectedValue) == -1)
        {
            level = 1;
            group = "0";
        }
        else
            level = Convert.ToInt32(ModControl.GetModField("Level", Convert.ToInt32(ddlGroup.SelectedValue))) + 1;
        //============================================
        Hashtable tbIn = new Hashtable();
        Hashtable tbInCat = new Hashtable();
        int ModtypeID = Int32.Parse(ddlModtype.SelectedValue);
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        string code = txtCode.Text.Trim() == "" ? ApplicationUtil.GetTitle(txtName.Text.ToString()).ToLower() : txtCode.Text.Trim().ToLower();
        string url = txtURL.Text.Trim() == "" ? ApplicationUtil.GetTitle(txtName.Text.ToString()).ToLower() : txtURL.Text.Trim().ToLower();
        tbIn.Add("Mod_Parent", group);
        tbIn.Add("Modtype_ID", ddlModtype.SelectedValue);
        tbIn.Add("Mod_Img", txtImg.Text.Replace("/upload", "upload"));
        tbIn.Add("Mod_Name", txtName.Text);
        tbIn.Add("Mod_Code", code);
        tbIn.Add("Mod_URL", url);
        tbIn.Add("Mod_Des", txtDes.Text);
        tbIn.Add("Mod_Title", txtTitle.Text);
        tbIn.Add("Mod_Key", txtKey.Text);
        tbIn.Add("Mod_Content", CKContent.Text);
        tbIn.Add("Mod_Level", level.ToString());
        tbIn.Add("Mod_Pos", txtPos.Text);
        tbIn.Add("Mod_Status", isUse);
        //========================CAT===============================//
        tbInCat.Add("Name", txtName.Text);
        tbInCat.Add("Code", txtCode.Text);
        tbInCat.Add("Modtype_ID", ddlModtype.SelectedValue);
        tbInCat.Add("Description", txtDes.Text);
        tbInCat.Add("isPublish", isUse);
        if (act == "add")
        {
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Mod", tbIn);
            if (_insert)
            {
                string sql1 = "SELECT Mod_ID FROM tbl_Mod order by Mod_ID DESC";
                DataSet ds1 = UpdateData.UpdateBySql(sql1);
                DataRowCollection rows1 = ds1.Tables[0].Rows;
                UpdateData.InsertBySql("INSERT INTO tbl_ModsiteUser(Mod_ID,User_ID) VALUES(" + rows1[0]["Mod_ID"] + "," + Session["UserID"] + ")");
                if (Session["UserID"].ToString() != "56")
                {
                    UpdateData.InsertBySql("INSERT INTO tbl_ModsiteUser(Mod_ID,User_ID) VALUES(" + rows1[0]["Mod_ID"] + ",56)");
                }
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm", "Module:" + txtName.Text);
                Response.Redirect("/Admin/Modules/Mod/ModList.aspx?TopicId=" + TopicID);
            }
        }
        if (act == "edit")
        {
            bool _update = UpdateData.Update("tbl_Mod", tbIn, "Mod_ID=" + id);
            if (_update)
            {
                bool _updateCat = false;
                if (_updateCat)
                {
                    FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Module:" + txtName.Text);
                }
            }
        }
        Response.Write(sScritp);
    }
}
