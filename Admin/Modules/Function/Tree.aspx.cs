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

public partial class Mod_Tree : DefaultAdmin
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
        sb.Append("var Type = new ADCTreeItem(\"<b>Chức năng quản trị</b>\", 0, 0,'" + tp + "tree/Langroot.gif', false);");
        sb.Append("tree.add(Type);");
        DataSet ds = UpdateData.UpdateBySql("SELECT ModAdmin_ID,ModAdmin_Name,ModAdmin_Status FROM tbl_ModAdmin WHERE ModAdmin_ID in(SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID=" + Session["UserID"] + ") AND ModAdmin_Parent=0 ORDER BY ModAdmin_Pos");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string sLocked = "";
            string L1 = rows[i]["ModAdmin_ID"].ToString();
            bool isUse = Convert.ToBoolean(rows[i]["ModAdmin_Status"]);
            string CatName = rows[i]["ModAdmin_Name"].ToString();
            //if (!isUse)
            //{
            //    sLocked = "&nbsp;<img border='0' src='" + tp + "Icons/button_security.gif'>";
            //}
            sb.Append("var Mod1" + L1 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 1, " + L1 + ",'" + tp + "Tree/folder.gif', false);");
            sb.Append("Type.add( Mod1" + L1 + ");");
        }
        //====================================================
        DataSet dsSub = UpdateData.UpdateBySql("SELECT ModAdmin_ID,ModAdmin_Parent,ModAdmin_Name,ModAdmin_Status FROM tbl_ModAdmin WHERE ModAdmin_ID in(SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID=" + Session["UserID"] + ") AND ModAdmin_Parent<>0 ORDER BY ModAdmin_Pos");
        DataRowCollection rowSub = dsSub.Tables[0].Rows;
        for (int i = 0; i < rowSub.Count; i++)
        {
            //string sLocked = "";
            string L1 = rowSub[i]["ModAdmin_Parent"].ToString();
            string L2 = rowSub[i]["ModAdmin_ID"].ToString();
            string CatName = rowSub[i]["ModAdmin_Name"].ToString();
            bool isUse = Convert.ToBoolean(rowSub[i]["ModAdmin_Status"]);
            string simgRep = tp + "Tree/free.gif";
            //if (!isUse)
            //{
            //    sLocked = "&nbsp;<img border='0' src='" + tp + "Icons/button_security.gif'>";
            //}
            sb.Append("var Mod2" + L2 + " = new ADCTreeItem(\"" + CatName + "\", 2, " + L2 + ",'" + tp + "Tree/" + simgRep + "');");
            sb.Append("Mod1" + L1 + ".add( Mod2" + L2 + ");");
        }
        sb.Append("document.write(tree);}</script>");
        lbTree.Text = sb.ToString();
    }
}
