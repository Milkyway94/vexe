<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="SMAC" %>

<%
    try
    {
        string _name = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["name"]));
        string _phone = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["phone"]));
        string _email = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["email"]));
        string _address = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["address"]));
        string _Domain = Request.ServerVariables["SERVER_NAME"];
        string[] d = HttpUtility.HtmlDecode(Request["date"]).Split('/');
        string _date = d[1] + "/" + d[0] + "/" + d[2];
        Hashtable tbIn = new Hashtable();
        tbIn.Add("Member_Name", _name.Trim());
        tbIn.Add("Member_Phone", _phone.Trim());
        tbIn.Add("Member_Email", _email.Trim());
        tbIn.Add("Member_Address", _address.Trim());
        tbIn.Add("Member_Date", _date.Trim());
        bool insert = UpdateData.Insert("tbl_Member", tbIn);
        if (insert)
        {
            string alert = CMSfunc._Title("register-success");
            Response.Write(alert);
        }
        else
        {
            string alert = CMSfunc._Title("register-error");
            Response.Write(alert);
        }
        //string strBody = "<style>.table th,.table td{border:1px solid #DDD; padding:10px;}.table th{background:#eae7e7; text-align:left; width:120px}</style>";
        //strBody += "<div>" + CMSfunc.LoadOther("top-register") + "</div>";
        //strBody += "<table width='100%' cellpadding='5' cellspacing='5' style='border-collapse:collapse;' border='1' class='table'>";
        //strBody += "<tr><td width='120'>Chúng tôi là</td><td>" + _ten + "</td></tr>";
        //strBody += "<tr><td>Chức vụ</td><td>" + _chucvu + "</td></tr>";
        //strBody += "<tr><td>Ngày thành lập cơ sở</td><td>" + _ngaythanhlap + "</td></tr>";
        //strBody += "<tr><td>Giấy phép số</td><td>" + _giayphepso + " - Cơ quan cấp " + _coquancap + "</td></tr>";
        //strBody += "<tr><td>Ngành nghề sản xuất hoặc kinh doanh, dịch vụ</td><td>" + _nganhnghe + "</td></tr>";
        //strBody += "<tr><td colspan='2'>Số lượng cán bộ công nhân viên làm việc trong cơ sở <strong>" + _sonhanvien + "</strong> người</td></tr>";
        //strBody += "<tr><td colspan='2'>Trong đó số người tàn tật làm việc trong cơ sở <strong>" + _sonhanvien + "</strong> người</td></tr>";
        //strBody += "<tr><td>Địa chỉ</td><td>" + _diachi + "</td></tr>";
        //strBody += "<tr><td>Điện thoại</td><td>" + _dienthoai + "</td></tr>";
        //strBody += "<tr><td>Fax</td><td>" + _fax + "</td></tr>";
        //strBody += "<tr><td>Email</td><td>" + _email + "</td></tr>";
        //strBody += "<tr><td>Thời gian gửi</td><td>" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</td></tr>";
        //strBody += "</table>";
        //strBody += "<div>" + CMSfunc.LoadOther("footer-register") + "</div>";
        //strBody = strBody.Replace("$_date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
        //string fromEmail = _email;
        //string toEmail = CMSfunc._GetConst("_EmailAdmin");
        //string Name = _ten;
        //string Subject = "Đăng ký hội viên website apec.com.vn";
        //string Host = CMSfunc._GetConst("_Hostmail");
        //string EmailClient = CMSfunc._GetConst("_EmailClient");
        //string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
        //int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
        //string SendSuccess = "";
        //bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, SendSuccess, strBody);            
        //if (_isSend)
        //{
        //    string alert = CMSfunc._Title("register-success");
        //    Response.Write(alert);
        //}
        //else
        //{
        //    string alert = CMSfunc._Title("register-error");
        //    Response.Write(alert);
        //}
    }
    catch
    {
        string alert = CMSfunc._Title("register-error");
        Response.Write(alert);
    }
%>