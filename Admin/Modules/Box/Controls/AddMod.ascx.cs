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

public partial class Adadmin_Modules_Box_Controls_AddMod : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_Mod WHERE lang=" + Session["lang"] + " ORDER BY Mod_Level");
        cblRight.DataSource = ds;
        cblRight.DataTextField = "Mod_Name";
        cblRight.DataValueField = "Mod_ID";
        cblRight.DataBind();

        DataSet dsForUser = UpdateData.UpdateBySql("SELECT * FROM tbl_ModBox WHERE Box_ID=" + id);
        DataRowCollection rows = dsForUser.Tables[0].Rows;
        for (int i = 0; i < cblRight.Items.Count; i++)
        {
            for (int j = 0; j < rows.Count; j++)
            {
                if (cblRight.Items[i].Value.Equals(rows[j]["Mod_ID"].ToString()))
                    cblRight.Items[i].Selected = true;
            }
        }
    }

    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"BoxList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";
        int selectedNum = 0;
        for (int i = 0; i < cblRight.Items.Count; i++)
        {
            if (cblRight.Items[i].Selected == true)
            {
                selectedNum++;
            }
        }
        if (id == "11")
        {
            if (selectedNum == 3)
            {
                UpdateData.Delete("tbl_ModBox", "Box_ID=" + id);
                for (int i = 0; i < cblRight.Items.Count; i++)
                {
                    if (cblRight.Items[i].Selected == true)
                    {
                        string ModID = cblRight.Items[i].Value;
                        UpdateData.InsertBySql("INSERT INTO tbl_ModBox(Mod_ID,Box_ID) VALUES(" + ModID + "," + id + ")");
                    }
                }
                Response.Write(sScritp);
            }
            else
            {
                Response.Write("<script>alert(\"Bạn phải chọn 3 mục.\")</script>");
            }
        }
        else
        {
            UpdateData.Delete("tbl_ModBox", "Box_ID=" + id);
            for (int i = 0; i < cblRight.Items.Count; i++)
            {
                if (cblRight.Items[i].Selected == true)
                {
                    string ModID = cblRight.Items[i].Value;
                    UpdateData.InsertBySql("INSERT INTO tbl_ModBox(Mod_ID,Box_ID) VALUES(" + ModID + "," + id + ")");
                }
            }
            Response.Write(sScritp);
        }
    }
}
