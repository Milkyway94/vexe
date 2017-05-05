using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_ForgotPassword : System.Web.UI.UserControl
{
    public string alertType = "";
    public string display = "displaynone";
    protected void Page_Load(object sender, EventArgs e)
    {
        Div1.Visible = false;
        Div2.Visible = false;
        dverror_email.Visible = false;
    }

    protected void btnPassword_Click(object sender, EventArgs e)
    {
        Div1.Visible = false;
        if (string.IsNullOrEmpty(email.Text))
        {
            display = "";
            alertType = "danger";
            lberror_email.Text = "Bạn phải nhập email";
        }
        else
        {
            var members = new MemberRepository().SearchFor(o => o.Member_Email == email.Text);
            if (members == null || members.Count() == 0)
            {
                dverror_email.Visible = true;
                lberror_email.Text = "Email không thuộc về bất kỳ tài khoản nào, vui lòng kiểm tra lại.";
            }
            else
            {
                var newpass = Value.CreatePassword(6);
                tbl_Member member = members.SingleOrDefault();
                Hashtable tb = new Hashtable();
                tb.Add("Member_Password", ApplicationUtil.PasswordEncrypt(newpass));
                if (UpdateData.Update("tbl_Member", tb, "Member_ID=" + member.Member_ID))
                {
                    #region Send Mail
                    //send mail
                    string strBody = "<html><body>\n";
                    strBody += "<h2>Chào mừng đến với " + CMSfunc._GetConst("_Domain") + "</h1><br>\n";
                    strBody += "Mật khẩu mới của quý khách là: <strong style='color: red'>" + newpass + "</strong><br>\n";
                    strBody += "</body></html>";

                    string fromEmail = CMSfunc._GetConst("_EmailClient");
                    string toEmail = email.Text;
                    string Name = CMSfunc._GetConst("_Name");

                    string Subject = "THAY ĐỔI MẬT KHẨU ĐĂNG NHẬP";
                    string Host = CMSfunc._GetConst("_Hostmail");
                    string EmailClient = CMSfunc._GetConst("_EmailClient");
                    string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                    int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                    try
                    {
                        bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                        if (_isSend)
                        {
                            Div1.Visible = false;
                            Div2.Visible = true;
                            lbSuccess.Text = "Thay đổi mật khẩu thành công, mật khẩu mới đã được gửi về Email của bạn. Vui lòng kiểm tra email và đăng nhập lại.";
                        }
                        else
                        {
                            Div2.Visible = false;
                            Div1.Visible = true;
                            lbError.Text = "Thay đổi mật khẩu không thành công, vui lòng thử lại.";
                        }
                    }
                    catch (Exception ex)
                    {
                        Div2.Visible = false;
                        Div1.Visible = true;
                        lbError.Text = "Thay đổi mật khẩu không thành công, vui lòng thử lại.";
                    }
                    #endregion
                }

            }
        }
    }
}