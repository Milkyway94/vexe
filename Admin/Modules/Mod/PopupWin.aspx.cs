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
            case "Mod":
                _objControl = LoadControl("Controls/ModFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Product":
                _objControl = LoadControl("/Admin/Modules/ShopCategory/Controls/ModFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Modtype":
                _objControl = LoadControl("Controls/ModtypeFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Listtype":
                _objControl = LoadControl("Controls/ListModtype.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Chuyenkhoa":
                _objControl = LoadControl("Controls/ChuyenkhoaFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
            case "Location":
                _objControl = LoadControl("Controls/LocationFrm.ascx");
                OperationCell.Controls.Add(_objControl);
                break;
        }
        base.CreateChildControls();
	}		
}
