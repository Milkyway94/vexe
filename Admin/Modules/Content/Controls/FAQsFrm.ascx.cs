using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using SMAC;

public partial class Admin_Modules_Content_Controls_ProductsFrm : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string act, id, TopicID;
    protected void Page_Load(object sender, EventArgs e)
    { 
        TopicID = Request["TopicID"];
        act = Request["act"];
        id = Request["id"];
        //===============================   
        if (!IsPostBack)
        {
            GetChuyenmuc();
            GetChuyenkhoa();
            if (act == "edit")
                ViewEdit(id);
        }
        
    }
    protected void GetChuyenmuc()
    {
        //string sql = "SELECT Mod_ID,Mod_Name,Mod_Code,Mod_URL,Mod_Img FROM tbl_Mod WHERE Mod_Status=1";
        //sql += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menuleft'))";
        //sql += " ORDER BY Mod_Pos";
        string sql = "SELECT m.Mod_ID, m.Mod_Name, m.Mod_Parent, m.Mod_Code FROM tbl_Mod m LEFT JOIN ";
        sql += " tbl_ModBox mb on m.Mod_ID = mb.Mod_ID LEFT JOIN tbl_Box b on mb.Box_ID = b.Box_ID";
        sql += " WHERE m.lang=1 AND m.Mod_Status=1 AND b.Box_Code='MenuFAQs' AND b.lang=1";
        sql += " ORDER BY m.Mod_Pos";
        DataSet dsBox = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = dsBox.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            ddlChuyenmuc.Items.Insert(i, new ListItem(rows[i]["Mod_Name"].ToString(), rows[i]["Mod_ID"].ToString()));
        }
    }
    protected void GetChuyenkhoa()
    {
        string sql = "SELECT Chuyenkhoa_ID,Chuyenkhoa_Name FROM tbl_Chuyenkhoa WHERE Chuyenkhoa_Status=1 ORDER BY Chuyenkhoa_Pos";
        DataSet dsBox = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = dsBox.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            ddlChuyenkhoa.Items.Insert(i, new ListItem(rows[i]["Chuyenkhoa_Name"].ToString(), rows[i]["Chuyenkhoa_ID"].ToString()));
        }
    }
    public void ViewEdit(string id)
    {
        string sql = "SELECT * FROM tbl_Content WHERE Content_ID=" + id;
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;          
        if (rows.Count > 0)
        {
            CKTeaser.Text       = rows[0]["Content_Intro"].ToString();
            CKContent.Text      = rows[0]["Content_Text"].ToString();
            //txtName.Text        = rows[0]["Content_Code"].ToString();//Họ tên
            txtTile.Text        = rows[0]["Content_Name"].ToString();
            txtTel.Text         = rows[0]["Content_Avata"].ToString();
            //txtEmail.Text       = rows[0]["Content_URL"].ToString();
            txtCode.Text        = rows[0]["Content_Code"].ToString(); // liên quan
            txtKey.Text         = rows[0]["Content_Key"].ToString();
            txtTitle.Text       = rows[0]["Content_Title"].ToString();
            txtMeta.Text        = rows[0]["Content_Des"].ToString();
            txtTags.Text        = rows[0]["Content_Tags"].ToString();
            cbIsUse.Checked = (Convert.ToBoolean(rows[0]["Content_Status"]) == true) ? true : false;
            for (int i = 0; i < ddlChuyenkhoa.Items.Count; i++)
            {
                if (rows[0]["Chuyenkhoa_ID"].ToString() == ddlChuyenkhoa.Items[i].Value)
                    ddlChuyenkhoa.Items[i].Selected = true;
            }
            for (int i = 0; i < ddlChuyenmuc.Items.Count; i++)
            {
                if (rows[0]["Chuyenmuc_ID"].ToString() == ddlChuyenmuc.Items[i].Value)
                    ddlChuyenmuc.Items[i].Selected = true;
            }
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScript = "<script>";
        sScript += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScript += "b.attachURL(\"ContentList.aspx?TopicID=" + TopicID + "\");";
        sScript += "window.close();";
        sScript += "</script>";
        string sql = "SELECT Tag_Url FROM tbl_Tag";
        DataSet dsSQL = UpdateData.UpdateBySql(sql);
        DataRowCollection rowsSQL = dsSQL.Tables[0].Rows;
        ArrayList arrSQL = FunctionDB.GetRowAsArrayList(dsSQL, "Tag_Url");

        string[] mID = txtTags.Text.Split(',');
        for (int i = 0; i < mID.Length; i++)
        {
            if (mID[i] != "")
            {
                string nTag = mID[i].ToString().Trim();
                string uTag = ApplicationUtil.GetTitle(mID[i].ToString().Trim());
                Hashtable tbTag = new Hashtable();
                tbTag.Add("Tag_Name", nTag);
                tbTag.Add("Tag_Url", uTag);
                if (arrSQL.Contains(uTag))
                    UpdateData.Update("tbl_Tag", tbTag, "Tag_Url='" + uTag + "'");
                else
                {
                    UpdateData.Insert("tbl_Tag", tbTag);
                    arrSQL = FunctionDB.GetRowAsArrayList(dsSQL, "Tag_Url");
                }
            }
        }
        Hashtable tbIn = new Hashtable();
        string isUse = (cbIsUse.Checked == true) ? "1" : "0";
        //string url = txtURL.Text.Trim() == "" ? ApplicationUtil.GetTitle(txtName.Text.ToString()) : txtURL.Text.Trim();
        string urlTag = txtTags.Text.Trim() == "" ? ApplicationUtil.GetTitle(txtKey.Text.ToString()) : ApplicationUtil.GetTitle(txtTags.Text.Trim());
        tbIn.Add("Mod_ID", TopicID.ToString());
        tbIn.Add("Chuyenkhoa_ID", ddlChuyenkhoa.SelectedValue);
        tbIn.Add("Chuyenmuc_ID", ddlChuyenmuc.SelectedValue);
        tbIn.Add("User_ID", Session["UserID"].ToString());
        tbIn.Add("Content_Name", txtTile.Text);
        //tbIn.Add("Content_Code", txtName.Text); // ho ten
        tbIn.Add("Content_Code", txtCode.Text);
        tbIn.Add("Content_Title", txtTitle.Text);
        tbIn.Add("Content_Key", txtKey.Text);
        tbIn.Add("Content_Des", txtMeta.Text);
        tbIn.Add("Content_Tags", txtTags.Text);
        tbIn.Add("Content_UrlTags", urlTag);
        tbIn.Add("Content_Avata", txtTel.Text);
        //tbIn.Add("Content_URL", txtEmail.Text);
        tbIn.Add("Content_Intro", CKTeaser.Text);
        tbIn.Add("Content_Text", CKContent.Text);
        tbIn.Add("Content_Status", isUse);
        if (act == "add")
        {
            tbIn.Add("lang", Session["lang"].ToString());
            bool _insert = UpdateData.Insert("tbl_Content", tbIn);
            if(_insert)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Thêm ", "Câu hỏi: " + CKTeaser.Text);
        }
        if (act == "edit")
        {            
            bool _update = UpdateData.Update("tbl_Content", tbIn, "Content_ID=" + id);
            if (_update)
                FunctionDB.AddLog(Session["DepartID"].ToString(), Session["Username"].ToString(), "Sửa", "Câu hỏi: " + CKTeaser.Text);
        }        
        Response.Write(sScript);
    }
}