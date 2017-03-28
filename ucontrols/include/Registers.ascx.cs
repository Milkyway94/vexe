using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        bool b = true;
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
