using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMAC;

public partial class Admin_ReloadLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpCookie ht = AdminState.CheckUser();

        //DataTable dsUser = UpdateData.UpdateBySql("SELECT * FROM tbl_User WHERE User_ID='" + Session["UserID"].ToString() + "'");
        //DataRowCollection rows = dsUser.Rows;
        string userid = Session["UserID"] == null ? "" : Session["UserID"].ToString();
        DataSet dsUser = UpdateData.UpdateBySql("SELECT Pb_ID,User_ID,Username FROM tbl_User WHERE User_ID='" + userid + "'");
        DataRowCollection rows = dsUser.Tables[0].Rows;
        if (rows.Count >= 1)
        {
            string usn = rows[0]["username"].ToString();
            if ((usn == "adconline") || (usn == "admin"))
                Session["Admin"] = "admin";
            else
                Session["Admin"] = "";

            Session["UserID"] = rows[0]["User_ID"].ToString();
            Session["Username"] = rows[0]["Username"].ToString();
            Session["DepartID"] = rows[0]["Pb_ID"].ToString();

            Literal1.Text = Session["UserID"].ToString();
        }

    }
}