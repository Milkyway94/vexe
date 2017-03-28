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

public partial class Doc_Tree : DefaultAdmin
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
        sb.Append("var tree = new ADCTree('LGGVN Administrator', '" + tp + "Tree/config.gif');");
        sb.Append("tree.setBehavior('classic');");
        sb.Append("var Type = new ADCTreeItem(\"<b>Phân loại tài liệu</b>\", 0, 0,'" + tp + "tree/Langroot.gif', false);");
        sb.Append("tree.add(Type);");
        DataSet ds = UpdateData.UpdateBySql("SELECT DocsType_ID,DocsType_Name,DocsType_Status, DocsType_Parent  FROM tbl_DocsType ORDER BY DocsType_Order");
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            bool isUse = Convert.ToBoolean(rows[i]["DocsType_Status"].ToString());
            string sLocked = "";
            string L1 = rows[i]["DocsType_ID"].ToString();
            string CatName = rows[i]["DocsType_Name"].ToString();
            if (!isUse)
            {
                sLocked = "&nbsp;<img border='0' src='" + tp + "Icons/button_security.gif'>";
            }
            if(int.Parse(rows[i]["DocsType_Parent"].ToString())==0)
            {
                sb.Append("var Mod1" + L1 + " = new ADCTreeItem(\"" + CatName + sLocked + "\", 1, " + L1 + ",'" + tp + "Tree/folder.gif', false);");
                sb.Append("Type.add( Mod1" + L1 + ");");
            }
        }
        //====================================================
        DataSet dsSub = UpdateData.UpdateBySql("SELECT DocsType_ID,DocsType_Parent,DocsType_Name,DocsType_Status FROM tbl_DocsType ORDER BY DocsType_Order");
        DataRowCollection rowSub = dsSub.Tables[0].Rows;
        for (int i = 0; i < rowSub.Count; i++)
        {
            //string sLocked = "";
            string L1 = rowSub[i]["DocsType_Parent"].ToString();
            string L2 = rowSub[i]["DocsType_ID"].ToString();
            string CatName = rowSub[i]["DocsType_Name"].ToString();
            bool isUse = Convert.ToBoolean(rowSub[i]["DocsType_Status"]);
            string simgRep = tp + "Tree/free.gif";
            //if (!isUse)
            //{
            //    sLocked = "&nbsp;<img border='0' src='" + tp + "Icons/button_security.gif'>";
            //}
                
            if (int.Parse(L1)!=0)
            {
                sb.Append("var Mod2" + L2 + " = new ADCTreeItem(\"" + CatName + "\", 2, " + L2 + ",'" + tp + "Tree/" + simgRep + "');");
                sb.Append("Mod1" + L1 + ".add( Mod2" + L2 + ");");
            }
        }
        sb.Append("document.write(tree);}</script>");
        lbTree.Text = sb.ToString();
    }
}
