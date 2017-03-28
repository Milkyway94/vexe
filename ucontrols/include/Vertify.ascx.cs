using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Vertify : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM GiaoDich WHERE MemberID=" + Session["MemberID"];
        if (UpdateData.UpdateBySql(sql).Tables[0].Rows.Count > 0)
        {
            Hashtable tb = new Hashtable();
            tb.Add("Order_Status", "2");
            UpdateData.Update("tbl_Order", tb, "Order_Code='"+Session["OrderID"]+"'");
        }
    }
}