using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_TD_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["act"] == "approve")
        {
            int id = int.Parse(Request["id"]);
            string sql = "update tbl_CV set CV_Status=2 where CV_ID="+id;
            UpdateData.UpdateBySql(sql);
        }
        if (Request["act"] == "dispass")
        {
            int id = int.Parse(Request["id"]);
            string sql = "update tbl_CV set CV_Status=0 where CV_ID=" + id;
            UpdateData.UpdateBySql(sql);
        }
        ltrTD.Text = LoadTDList();
    }
    protected string LoadTDList()
    {
        string sql;
        StringBuilder str = new StringBuilder();
        sql = "select * from tbl_CV where CV_Status!=0 ORDER BY CV_ApplyDate DESC";
        DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
        DataRowCollection rows = ds.Rows;
        if (rows.Count > 0)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                str.Append("<tr>");
                int j = i + 1;
                str.Append("<td>" + j + "</td>");
                str.Append("<td>" + rows[i]["CV_Name"] + "</td>");
                str.Append("<td> " + rows[i]["CV_Phone"] + "</td>");
                str.Append("<td>" + rows[i]["CV_Address"] + "</td>");
                str.Append("<td>" + rows[i]["CV_Email"] + "</td>");
                str.Append("<td>" + DateTime.Parse(rows[i]["CV_ApplyDate"].ToString()).ToShortDateString() + "</td>");
                str.Append("<td>"+ rows[i]["CV_Pos"] + "</td>");
                str.Append("<td><a href=\""+ ResolveUrl("~/"+rows[i]["CV_File"])+ "\"><i class=\"fa fa-download\"></i>Download</a></td>");
                if (rows[i]["CV_Status"].ToString() != "2")
                {
                    str.Append("<td><a id=\"lApprove\" href=\"?act=approve&id=" + rows[i]["CV_ID"] + "\" class=\"btn btn-success\"><i class=\"fa fa-check\"></i></a>&nbsp;<a id=\"lDispass\" runat=\"server\" class=\"btn btn-danger\" href=\"?act=dispass&id=" + rows[i]["CV_ID"] + "\"><i class=\"fa fa-times\"></i></a></td>");
                }
                else
                {
                    str.Append("<td><a id=\"lDispass\" runat=\"server\" class=\"btn btn-danger\" href=\"?act=dispass&id=" + rows[i]["CV_ID"] + "\"><i class=\"fa fa-times\"></i></a></td>");
                }
                str.Append("</tr>");
            }
        }
        return str.ToString();
    }
    public void btnApprove_Click(object sender, EventArgs e)
    {
        Response.Write("bca");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadTDList();
    }
}