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

public partial class Administrator_Modules_User_Controls_RightAccess : System.Web.UI.UserControl
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
        DataSet ds = UpdateData.UpdateBySql("Select ModAdmin_ID, ModAdmin_Status, ModAdmin_Name,(SELECT count(*) from tbl_ModAdmin WHERE ModAdmin_Parent=Mod.ModAdmin_ID) childnodecount FROM tbl_ModAdmin Mod WHERE ModAdmin_Parent=0 order by ModAdmin_Pos");
        PopulateNodes(ds, TreeView1.Nodes);
    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        DataSet ds = UpdateData.UpdateBySql("Select ModAdmin_ID, ModAdmin_Status, ModAdmin_Name,(SELECT count(*) from tbl_ModAdmin WHERE ModAdmin_Parent=Mod.ModAdmin_ID) childnodecount from tbl_ModAdmin Mod WHERE ModAdmin_Parent=" + parentid + " order by ModAdmin_Pos");
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
            tn.Text = row[i]["ModAdmin_Name"].ToString();
            tn.Value = row[i]["ModAdmin_ID"].ToString();
            nodes.Add(tn);

            DataSet dsForUser = UpdateData.UpdateBySql("SELECT * FROM tbl_ModUser WHERE UserID=" + id);
            if (dsForUser.Tables.Count == 0)
            {
                break;
            }
            DataRowCollection rows = dsForUser.Tables[0].Rows;
            for (int j = 0; j < rows.Count; j++)
            {
                if (row[i]["ModAdmin_ID"].ToString() == rows[j]["ModAdmin_ID"].ToString())
                {
                    tn.Checked = true;
                }
            }

            tn.PopulateOnDemand = ((int)(row[i]["childnodecount"]) > 0);
        }
        
    }
    protected void lbtUpdate_Click(object sender, EventArgs e)
    {
        string sScritp = "<script>";
        sScritp += "var b = opener.parent.dhxLayout.cells(\"b\");";
        sScritp += "b.attachURL(\"UserList.aspx\");";
        sScritp += "window.close();";
        sScritp += "</script>";

        UpdateData.Delete("tbl_ModUser", "UserID=" + id);
        string ModuleID = "";
        for (int i = 0; i < TreeView1.CheckedNodes.Count; i++)
        {
            if (TreeView1.CheckedNodes[i].Checked == true)
            {
                ModuleID = this.TreeView1.CheckedNodes[i].Value;
                UpdateData.InsertBySql("INSERT INTO tbl_ModUser(ModAdmin_ID,UserID) VALUES(" + ModuleID + "," + id + ")");
            }
        }
        Response.Write(sScritp);
    }
}
