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
        string _F = Request.QueryString["page"];
        Control _objControl;
        _F = _F == null ? "" : _F;
        switch (_F)
        {
            case "User":
                _objControl = LoadControl("Controls/UserFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Depart":
                _objControl = LoadControl("Controls/DepartFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "AdminAccess":
                _objControl = LoadControl("Controls/AdminAccess.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "SiteAccess":
                _objControl = LoadControl("Controls/SiteAccess.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Role":
                _objControl = LoadControl("Controls/Role.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
        }
        base.CreateChildControls();
	}		
}
