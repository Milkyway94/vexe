using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SMAC;
public partial class OpenWin : DefaultAdmin
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
	}
    protected override void CreateChildControls()
    {
        string f = Request.QueryString["page"];
        Control objControl;
        f = f ?? "";
        switch (f)
        {
            case "About":
            case "Enterprise":
            case "Service":
            case "Concept":
            case "News":
                 objControl = LoadControl("Controls/NewsFrm.ascx");
                OperationCell.Controls.Add(objControl);
                break;
            case "Gallery":
                objControl = LoadControl("Controls/GalleryFrm.ascx");
                OperationCell.Controls.Add(objControl);
                break;
            case "File":
                objControl = LoadControl("Controls/FrmFile.ascx");
                OperationCell.Controls.Add(objControl);
                break;
        }
        base.CreateChildControls();
    }			
}
