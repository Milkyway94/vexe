using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Checkin : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public string displayDetail = "displaynone";
    public string mave, nguoimua, sdt, email, ngaymua, giave, loaive, diemdi, diemden, giodi, ngaydi, method, diachi;
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (nurl != null)
        {
            lbnav.Text = "<li><a href=\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li> <li>" + ModControl.GetName_From_Code(nurl) + "</li>";
        }
        else
        {
            lbnav.Text = "<li><a href =\"/\"><i class=\"fa fa-home fa-lg\"></i></a></li><li>  " + ModControl.GetName_From_Code(url) + "</li>";
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

    }

    protected void btnCheckIn_Click(object sender, EventArgs e)
    {
        string mave = txtMaVe.Text;
        if (string.IsNullOrEmpty(mave))
        {
            Value.ShowMessage(ltrError, string.Format(ErrorMessage.Required, "Mã vé"), "danger");
            return;
        }
        else
        {
            if (Session["UserID"] != null)
            {
                string sql = "SP_CHECKINTICKET";
                DataRowCollection rows = UpdateData.ExecStore(sql, SessionUtil.GetValue("UserID")+",'"+mave+"'").Tables[0].Rows;
                if (rows.Count > 0)
                {
                    bool isTimeout = rows[0]["isTimeOut"].ToString()=="1"?true:false;
                    if (isTimeout)
                    {
                        Value.ShowMessage(ltrError, string.Format(ErrorMessage.TimeOut, "Mã vé"), "danger");
                        displayDetail = "displaynone";
                    }
                    else
                    {
                        bool isDone = rows[0]["isDone"].ToString() == "1" ? true : false;
                        if (isDone)
                        {
                            Value.ShowMessage(ltrError, string.Format(ErrorMessage.TimeOut, "Mã vé"), "danger");
                            displayDetail = "displaynone";
                        }
                        else
                        {
                            Hashtable tb = new Hashtable();
                            tb.Add("isDone", "1");
                            bool update = UpdateData.Update("tbl_OrderDetail", tb, "Mave='" + mave + "'");
                            if (update)
                            {
                                Value.ShowMessage(ltrError, string.Format(ErrorMessage.Success, "Kiểm tra vé"), AlertType.SUCCESS);
                                displayDetail = "";
                                this.mave = mave;
                                this.loaive = rows[0]["Type"].ToString() == "TH" ? "Thường" : "VIP";
                                nguoimua = rows[0]["Order_Ten"].ToString() == null ? rows[0]["Member_Name"].ToString() : rows[0]["Order_Ten"].ToString();
                                sdt = rows[0]["Order_Tel"].ToString() == null ? rows[0]["Member_Phone"].ToString() : rows[0]["Order_Tel"].ToString();
                                email = rows[0]["Order_Email"].ToString() == null ? rows[0]["Member_Email"].ToString() : rows[0]["Order_Email"].ToString();
                                email = rows[0]["Order_Address"].ToString() == null ? rows[0]["Member_Address"].ToString() : rows[0]["Order_Address"].ToString();
                                ngaymua = DateTime.Parse(rows[0]["Order_CreatedDate"].ToString()).ToString("dd/MM/yyyy");

                                giave = double.Parse(rows[0]["UnitPrice"].ToString()).ToString("N0");
                                diemdi = rows[0]["Diemdi"].ToString();
                                diemden = rows[0]["Diemden"].ToString();
                                giodi = DateTime.Parse(rows[0]["Giokhoihanh"].ToString()).ToString("hh:mm");
                                ngaydi = DateTime.Parse(rows[0]["Ngaydi"].ToString()).ToString("dd/MM/yyyy");
                                method = rows[0]["Name"].ToString();
                            }
                            else
                            {
                                Value.ShowMessage(ltrError, ErrorMessage.UnknowError, AlertType.ERROR);
                                displayDetail = "";
                            }
                        }
                       
                    }
                }
                else
                {
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.NotFound, "Mã vé"), "danger");
                    displayDetail = "displaynone";
                }
            }
            else
            {
                Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, "danger");
                displayDetail = "displaynone";
            }
        }
    }
}