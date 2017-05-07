using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Document : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected int p;
    int role;
    protected void Page_Load(object sender, EventArgs e)
    {
        string u = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        p = ModControl.GetP_From_Code(u);
        dvsuccess.Visible = false;
        dverror_sdt.Visible = false;
        dverror_pass.Visible = false;
        dverror_verpass.Visible = false;
        dverror_email.Visible = false;
    }

    protected bool Validate()
    {
        ErrorEmail.Text = "";
        ErrorSDT.Text = "";
        ErrorPassword.Text = "";
        ErrorRepassword.Text = "";
        bool b = true;
        if (repassword.Text != password.Text)
        {
            ErrorRepassword.Text = "Mật khẩu không trùng khớp";
            b= false;
        }
        else if (string.IsNullOrEmpty(email.Text))
        {
            ErrorEmail.Text = "Bạn phải nhập Email";
            b = false;
        }
        else if (string.IsNullOrEmpty(phone.Text))
        {
            ErrorSDT.Text = "Bạn phải nhập Số điên thoại";
            b = false;
        }
        else if (string.IsNullOrEmpty(password.Text))
        {
            ErrorPassword.Text = "Bạn phải nhập mật khẩu";
            b = false;
        }
        else if (string.IsNullOrEmpty(repassword.Text))
        {
            ErrorRepassword.Text = "Bạn phải xác nhận mật khẩu";
            b = false;
        }
        else if(password.Text.Length<6)
        {
            ErrorPassword.Text = "Mật khẩu quá ngắn, giới hạn cho phép từ 6 đến 32 kí tự ";
            b = false;
        }
        else if (password.Text.Length > 32)
        {
            ErrorPassword.Text = "Mật khẩu quá dài, giới hạn cho phép từ 6 đến 32 kí tự ";
            b = false;
        }
        else if (phone.Text.Length < 10)
        {
            ErrorSDT.Text = "Số điện thoại phải có ít nhất 10 kí tự số";
            b = false;
        }
        else if (phone.Text.Length > 14)
        {
            ErrorSDT.Text = "Số điện thoại quá dài";
            b = false;
        }
        else
        {
            string pattern = @"^[0-9+]+$";
            if(!Regex.IsMatch(phone.Text, pattern))
            {
                ErrorSDT.Text = "Số điện thoại không hợp lệ";
                b = false;
            }
            else
            {
                var member1 = new MemberRepository().SearchFor(o => o.Member_Phone == phone.Text);
                var member2 = new MemberRepository().SearchFor(o => o.Member_Email == email.Text);
                if (member1.Count() > 0)
                {
                    ErrorSDT.Text = "Số điện thoại đã được đăng ký";
                    b = false;
                }
                else if(member2.Count() > 0)
                {
                    ErrorEmail.Text = "Email đã được đăng ký";
                    b = false;
                }
            }
        }
        return b;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            Hashtable tbIn = new Hashtable();
            tbIn.Add("Member_Status", "1");
            tbIn.Add("Member_Phone", phone.Text);
            tbIn.Add("Member_Email", email.Text);
            tbIn.Add("Member_Password", ApplicationUtil.PasswordEncrypt(CMSfunc._Replate(password.Text)));
            var res = UpdateData.Insert("tbl_Member", tbIn);
            if (res)
            {
                dvsuccess.Visible = true;
                lbError.Text = "Đăng ký thành công! Bạn có thể <a href='/login.htm' class='text-bold'>Đăng nhập.</a>";
                string fromEmail =email.Text;
                string toEmail = email.Text;
                string Name = CMSfunc._GetConst("_Name");

                string Subject = "ĐĂNG KÝ TÀI KHOẢN THÀNH CÔNG TẠI " + CMSfunc._GetConst("_Domain");
                string Host = CMSfunc._GetConst("_Hostmail");
                string EmailClient = CMSfunc._GetConst("_EmailClient");
                string PassEmailClient = CMSfunc._GetConst("_PassEmailClient");
                int Port = Convert.ToInt32(CMSfunc._GetConst("_Port"));
                string strBody = "<html><body><p><b>Quý khách đăng ký thành công tài khoản tại website "+CMSfunc._GetConst("_Domain")+ "</b></p><p><b>Thông tin tài khoản: </b></p><p>&nbsp;&nbsp;&nbsp;+ Số điện thoại: "+phone.Text+ "</p><p>&nbsp;&nbsp;&nbsp;+ Mật khẩu: " + password.Text + "</p><p>Quý khách vui lòng truy cập "+CMSfunc._GetConst("_Domain")+" chọn Đăng nhập để đặt vé xe điện tử. <br>Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi.</p></body></html>";
                try
                {
                    bool _isSend = SendMailClient.SendGMail(toEmail, fromEmail, Name, "", Subject, Host, Port, EmailClient, PassEmailClient, "Xác thực thành công", strBody);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }
    }

}
