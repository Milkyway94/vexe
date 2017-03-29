using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_Category_Xe : System.Web.UI.Page
{
    protected List<NhaXe> lstNhaXe = new List<NhaXe>();
    protected void Page_Load(object sender, EventArgs e)
    {
        lstNhaXe = LoadNhaXe();
    }
    protected List<NhaXe> LoadNhaXe()
    {
        NhaxeRepository nx = new NhaxeRepository();
        return nx.All().ToList();
    }
}