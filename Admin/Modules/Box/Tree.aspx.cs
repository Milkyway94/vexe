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

public partial class Box_Tree : DefaultAdmin
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
        sb.Append("var tree = new ADCTree('THÀNH PHẦN SITE', '" + tp + "Tree/config.gif');");
        sb.Append("tree.setBehavior('classic');");
        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_Boxtype WHERE lang=" + Session["lang"]);
        DataRowCollection rows = ds.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string sLocked = "";
            string sID = rows[i]["Boxtype_ID"].ToString();
            string Title = rows[i]["Boxtype_Name"].ToString();
            bool isUse = Convert.ToBoolean(rows[i]["Boxtype_Status"]);
            if (!isUse)
            {
                sLocked = "&nbsp;<img border=0 src=\"" + tp + "Tree/button_security.gif\">";
            }
            sb.Append("var cate" + sID + " = new ADCTreeItem(\"" + Title + sLocked + " \", 1, " + sID + ",'" + tp + "Tree/objFolder.gif', false);");
            sb.Append("tree.add(cate" + sID + ");");
        }
        sb.Append("document.write(tree);}</script>");
        lbTree.Text = sb.ToString();
    }
}