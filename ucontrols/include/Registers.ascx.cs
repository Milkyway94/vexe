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
                if (member1!=null || member1.Count() > 0)
                {
                    ErrorSDT.Text = "Số điện thoại đã được đăng ký";
                    b = false;
                }
                else if(member2 != null || member2.Count() > 0)
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
            }
        }
    }

}
