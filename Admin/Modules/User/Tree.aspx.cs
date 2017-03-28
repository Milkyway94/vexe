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
using System.Text;

public partial class User_Tree : DefaultAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateTree();
    }
    public void CreateTree()
    {
        string tp = "../../Themes/";
        StringBuilder sb = new StringBuilder();
        sb.Append("<script>if (document.getElementById){");
        sb.Append("var tree = new ADCTree('LGG Administrator', '" + tp + "Tree/config.gif');");
        sb.Append("tree.setBehavior('classic');");
        sb.Append("var Type = new ADCTreeItem(\"<b>Vai trò</b>\", 0, 0,'" + tp + "tree/Langroot.gif', false);");
        sb.Append("tree.add(Type);");
        DataSet ds = UpdateData.UpdateBySql("SELECT Role_ID,Role_Name FROM tbl_Role ORDER BY Role_Name");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string pbID = rows[i]["Role_ID"].ToString();
            string pbTen = rows[i]["Role_Name"].ToString();
            sb.Append("var Mod1" + pbID + " = new ADCTreeItem(\"" + pbTen + "\", 1, " + pbID + ",'" + tp + "tree/dept.gif', false);");
            sb.Append("Type.add( Mod1" + pbID + ");");
        }
        sb.Append("document.write(tree);}</script>");
        lbTree.Text = sb.ToString();
    }
}