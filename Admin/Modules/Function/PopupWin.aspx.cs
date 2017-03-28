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
            case "Fun":
                _objControl = LoadControl("Controls/FunFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Funtype":
                _objControl = LoadControl("Controls/FuntypeFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "RightAccess":
                _objControl = LoadControl("Controls/RightAccess.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
        }
        base.CreateChildControls();
	}		
}
