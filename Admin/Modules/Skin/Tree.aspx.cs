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
        StringBuilder str = new StringBuilder();
        str.Append("<script>if (document.getElementById){");
        str.Append("var tree = new ADCTree('LGG Manager', '" + tp + "Tree/config.gif');");
        str.Append("tree.setBehavior('classic');");
        str.Append("var Type = new ADCTreeItem(\"<b>Theo vị trí</b>\", 0, 0,'" + tp + "tree/Langroot.gif', false);");
        str.Append("tree.add(Type);");
        DataSet ds = UpdateData.UpdateBySql("SELECT Skintype_ID,Skintype_Name FROM tbl_Skintype ORDER BY Skintype_Pos");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string CatID = rows[i]["Skintype_ID"].ToString();
            string CatName = rows[i]["Skintype_Name"].ToString();
            str.Append("var ModGroup" + CatID + " = new ADCTreeItem(\"" + CatName + "\", 1, " + CatID + ",'" + tp + "Tree/used.gif', false);");
            str.Append("tree.add(ModGroup" + CatID + ");");
        }
        //=========================MOD===========================
       
        //====================================================
        str.Append("document.write(tree);}</script>");
        lbTree.Text = str.ToString();
    }
}