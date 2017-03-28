<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="SMAC" %>

<%
    try
    {
        string _name = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["name"]));
        //string _email = HttpUtility.HtmlDecode(Request["email"]);
        string _phone = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["phone"]));
        string _date = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["date"]));
        string _message = ApplicationUtil.FormatSqlString(HttpUtility.HtmlDecode(Request["message"]));
        string _Domain = Request.ServerVariables["SERVER_NAME"];
        string strBody = "<style>.table th,.table td{border:1px solid #DDD; padding:10px;}.table th{background:#eae7e7; text-align:left; width:120px}</style>";
        strBody += "<h1>Liên hệ từ " + _Domain + "</h1>";
        strBody += "<table width=\"100%\" cellpadding=\"5\" cellspacing=\"5\" style=\"border-collapse:collapse;\" border=\"1\" class=\"table\">";
        strBody += "<tr><td>Họ tên</td><td>" + _name + "</td></tr>";
        strBody += "<tr><td>Điện thoại</td><td>" + _phone + "</td></tr>";
        //strBody += "<tr><td>Email</td><td>" + txtEmail + "</td></tr>";
        strBody += "<tr><td>Địa chỉ</td><td>" + _date + "</td></tr>";
        strBody += "<tr><td>Nội dung liên hệ</td><td>" + _message + "</td></tr>";
        strBody += "<tr><td>Thời gian gửi</td><td>" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</td></tr>";
        strBody += "</table>";        
        string fromEmail = "vuongnv@adcvietnam.net";
        string toEmail = CMSfunc._GetConst("_EmailAdmin");
        string Name = _name;
        string Subject = "Liên hệ từ apec.com.vn";
        string Host = CMSfunc._GetConst("_Hostmail");
        string EmailClient = CMSfunc._GetConst("_EmailClient");
        string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
        int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
        string SendSuccess = "";
        bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, SendSuccess, strBody);
        if (_isSend)
        {
            string alert = CMSfunc._Title("contact-success");
            Response.Write(alert);
        }
        else
        {
            string alert = CMSfunc._Title("contact-error-send-email");
            Response.Write(alert);
        }
    }
    catch
    {
        string alert = CMSfunc._Title("contact-error-send-email");
        Response.Write(alert);
    }
%>