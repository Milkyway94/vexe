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

public partial class Administrator_Modules_Member_Controls_SiteAccess : System.Web.UI.UserControl
{
    public string sRootAppPath = "../../";
    public string id, pbid;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        pbid = Request["pbid"];
        if (!IsPostBack)
        {
            PopulateRootLevel();
            TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
        }
    }
    private void PopulateRootLevel()
    {
        DataSet ds = UpdateData.UpdateBySql("Select Mod_ID, Mod_Name,(SELECT count(*) from tbl_Mod WHERE Mod_Parent=Mod.Mod_ID) childnodecount FROM tbl_Mod Mod WHERE Mod_Parent=0 order by Mod_Pos");
        PopulateNodes(ds, TreeView1.Nodes);
    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        DataSet ds = UpdateData.UpdateBySql("Select Mod_ID, Mod_Name,(SELECT count(*) from tbl_Mod WHERE Mod_Parent=Mod.Mod_ID) childnodecount from tbl_Mod Mod WHERE Mod_Parent=" + parentid + " order by Mod_Pos");
        PopulateNodes(ds, parentNode.ChildNodes);
    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
    }
    private void PopulateNodes(DataSet ds, TreeNodeCollection nodes)
    {
        DataRowCollection row = ds.Tables[0].Rows;
        for (int i = 0; i < row.Count; i++)
        {
            TreeNode tn = new TreeNode();
            tn.Text = row[i]["Mod_Name"].ToString();
            tn.Value = row[i]["Mod_ID"].ToString();
            nodes.Add(tn);

            DataSet dsForUser = UpdateData.UpdateBySql("SELECT * FROM tbl_ModSiteUser WHERE User_ID=" + id);
            if (dsForUser.Tables.Count == 0)
            {
                break;
            }
            DataRowCollection rows = dsForUser.Tables[0].Rows;
            for (int j = 0; j < rows.Count; j++)
            {
                if (row[i]["Mod_ID"].ToString() == rows[j]["Mod_ID"].ToString())
                {
                    tn.Checked = true;
                }
            }

            tn.PopulateOnDemand = ((int)(row[i]["childnodecount"]) > 0);
        }
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScript = "<script>";
        sScript += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScript += "b.attachURL(\"UserList.aspx?pbid=" + pbid + "\");";
        sScript += "window.close();";
        sScript += "</script>";

        UpdateData.Delete("tbl_ModSiteUser", "User_ID=" + id);
        string ModuleID = "";
        for (int i = 0; i < TreeView1.CheckedNodes.Count; i++)
        {
            if (TreeView1.CheckedNodes[i].Checked == true)
            {
                ModuleID = this.TreeView1.CheckedNodes[i].Value;
                UpdateData.InsertBySql("INSERT INTO tbl_ModSiteUser(Mod_ID,User_ID) VALUES(" + ModuleID + "," + id + ")");
            }
        }
        Response.Write(sScript);
    }
}
