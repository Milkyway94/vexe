using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for EditProductFrm
/// </summary>
public class EditProductFrm: UserControl
{
    public int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }
}