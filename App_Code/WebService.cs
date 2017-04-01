using Newtonsoft.Json;
using QCMS_BUSSINESS;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public void getAllOrder()
    {
        List<tbl_OrderDetail> lst = new List<tbl_OrderDetail>();
        string sql = "select * from tbl_OrderDetail";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            str.Append("[");
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("{");
                str.Append("\"Order_ID\":\"" + rows[i]["Order_ID"] + "\",\"MaVe\":\"" + rows[i]["Mave"] + "\",\"UnitPrice\":\"" + rows[i]["unitPrice"] + "\",\"Type\":\"" + rows[i]["Type"] + "\",\"isTimeOut\":\"" + rows[i]["isTimeOut"] + "\"");
                str.Append("}");
                if (i < rows.Count - 1)
                {
                    str.Append(",");
                }
            }
            str.Append("]");
        }
        string jsonData = JsonConvert.SerializeObject(str.ToString());
        HttpContext.Current.Response.Write(jsonData);
    }
}
