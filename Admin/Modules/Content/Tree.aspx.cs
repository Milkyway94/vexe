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
        StringBuilder str = new StringBuilder();
        str.Append("<script>if (document.getElementById){");
        str.Append("var tree = new ADCTree('LGG Manager', '" + tp + "Tree/config.gif');");
        str.Append("tree.setBehavior('classic');");
        str.Append("var Type = new ADCTreeItem(\"<b>Cấu trúc Site</b>\", 0, 0,'" + tp + "Tree/Langroot.gif', false);");
        str.Append("tree.add(Type);");
        DataSet ds = UpdateData.UpdateBySql("SELECT Mod_Parent,Mod_ID,Mod_Name,Mod_Status FROM tbl_Mod WHERE lang=" + Session["lang"] + " AND Mod_Level=1 ORDER BY Mod_Pos");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string sLocked = "";
            string L1 = rows[i]["Mod_ID"].ToString();
            bool isUse = Convert.ToBoolean(rows[i]["Mod_Status"]);
            string CatName = rows[i]["Mod_Name"].ToString().Replace(@"""", "");
            CatName = CatName.Replace("<br>", "");            
            str.Append("var Mod1" + L1 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 1, " + L1 + ",'" + tp + "Tree/folder.gif', false);");
            str.Append("Type.add( Mod1" + L1 + ");");
        }
        //====================================================
        DataSet dsSub = UpdateData.UpdateBySql("SELECT Mod_Parent,Mod_ID,Mod_Name,Mod_Status FROM tbl_Mod WHERE lang=" + Session["lang"] + " AND Mod_Level=2 ORDER BY Mod_Pos");
        DataRowCollection rowSub = dsSub.Tables[0].Rows;
        for (int i = 0; i < rowSub.Count; i++)
        {
            string sLocked = "";
            string L1 = rowSub[i]["Mod_Parent"].ToString();
            string L2 = rowSub[i]["Mod_ID"].ToString();
            string CatName = rowSub[i]["Mod_Name"].ToString().Replace(@"""", "");
            bool isUse = Convert.ToBoolean(rowSub[i]["Mod_Status"]);
            string simgRep = tp + "Tree/free.gif";
            str.Append("var Mod2" + L2 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 2, " + L2 + ",'" + tp + "Tree/" + simgRep + "');");
            str.Append("Mod1" + L1 + ".add( Mod2" + L2 + ");");
        }
        //====================================================
        DataSet dsSub3 = UpdateData.UpdateBySql("SELECT Mod_Parent,Mod_ID,Mod_Name,Mod_Status FROM tbl_Mod WHERE lang=" + Session["lang"] + " AND Mod_Level=3 ORDER BY Mod_Pos");
        DataRowCollection rowSub3 = dsSub3.Tables[0].Rows;
        for (int i = 0; i < rowSub3.Count; i++)
        {
            string sLocked = "";
            string L2 = rowSub3[i]["Mod_Parent"].ToString();
            string L3 = rowSub3[i]["Mod_ID"].ToString();
            string CatName = rowSub3[i]["Mod_Name"].ToString().Replace(@"""", "");
            bool isUse = Convert.ToBoolean(rowSub3[i]["Mod_Status"]);
            string simgRep = tp + "Tree/free.gif";
            str.Append("var Mod3" + L3 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 3, " + L3 + ",'" + tp + "Tree/" + simgRep + "');");
            str.Append("Mod2" + L2 + ".add( Mod3" + L3 + ");");
        }//====================================================
        DataSet dsSub4 = UpdateData.UpdateBySql("SELECT Mod_Parent,Mod_ID,Mod_Name,Mod_Status FROM tbl_Mod WHERE lang=" + Session["lang"] + " AND Mod_Level=4 ORDER BY Mod_Pos");
        DataRowCollection rowSub4 = dsSub4.Tables[0].Rows;
        for (int i = 0; i < rowSub4.Count; i++)
        {
            string sLocked = "";
            string L3 = rowSub4[i]["Mod_Parent"].ToString();
            string L4 = rowSub4[i]["Mod_ID"].ToString();
            string CatName = rowSub4[i]["Mod_Name"].ToString().Replace(@"""", "");
            bool isUse = Convert.ToBoolean(rowSub4[i]["Mod_Status"]);
            string simgRep = tp + "Tree/free.gif";
            
            str.Append("var Mod4" + L4 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 4, " + L4 + ",'" + tp + "Tree/" + simgRep + "');");
            str.Append("Mod3" + L3 + ".add( Mod4" + L4 + ");");
        }
        //====================================================
        str.Append("document.write(tree);}</script>");
        lbTree.Text = str.ToString();
    }
}