using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Profile_History : System.Web.UI.UserControl
{
    protected string uRoot = ApplicationSetting.URLRoot;
    protected string cid, nurl, url;
    public tbl_Member member = new tbl_Member();
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = String.IsNullOrEmpty(Request["url"]) ? "Home" : Request["url"].ToString();
        this.url = url;
        nurl = Request.QueryString["nUrl"];
        if (Session["MemberID"] != null)
        {
            this.member = new MemberRepository().Find(int.Parse(Session["MemberID"].ToString()));
        }
        else
        {
            Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, AlertType.ERROR);
            dvinfo.Visible = false;
        }
        Control _objControl = LoadControl("/ucontrols/subcontrol/ProfileSidebar.ascx");
        sidebar.Controls.Add(_objControl);
        if (!IsPostBack)
        {
            txtDiachi.Text = member.Member_Address;
            txtEmail.Text = member.Member_Email;
            txtName.Text = member.Member_Name;
            txtSdt.Text = member.Member_Phone;
            avartar.ImageUrl = string.IsNullOrEmpty(member.Member_Avarta) ? "/resources/img/icon/images.jpg" : member.Member_Avarta;
            DataTable dt = UpdateData.ExecStore("SP_CCB_Tinh","").Tables[0];
            Value.BindToDropdown(ddlTinh, dt);
            for (int i = 0; i < ddlTinh.Items.Count; i++)
            {
                if (member.Member_Tinh.HasValue)
                {
                    if (ddlTinh.Items[i].Value == member.Member_Tinh.ToString())
                    {
                        ddlTinh.Items[i].Selected=true;
                    }
                }
               
            }
            Value.BindToDropdown(ddlQuanHuyen, UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlTinh.SelectedValue).Tables[0]);
            for (int i = 0; i < ddlQuanHuyen.Items.Count; i++)
            {
                if (member.Member_QuanHuyen.HasValue)
                {
                    if (ddlQuanHuyen.Items[i].Value == member.Member_QuanHuyen.ToString())
                    {
                        ddlQuanHuyen.Items[i].Selected = true;
                    }
                }

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var memberid = Session["MemberID"];
        if (memberid != null)
        {
            string fileName="";
            Hashtable tbMem = new Hashtable();
            if (Page.IsValid && fAvartar.HasFile)
            {
                fileName = "/upload/" + fAvartar.FileName;
                string filePath = Server.MapPath(fileName);
                try
                {
                    fAvartar.SaveAs(filePath);
                    tbMem.Add("Member_Avarta", fileName);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            tbMem.Add("Member_Address", txtDiachi.Text);
            tbMem.Add("Member_Email", txtEmail.Text);
            tbMem.Add("Member_Name", txtName.Text);
            tbMem.Add("Member_Phone", txtSdt.Text);
            tbMem.Add("Member_Tinh", ddlTinh.SelectedValue);
            tbMem.Add("Member_QuanHuyen", ddlQuanHuyen.SelectedValue);
            try
            {
                bool _update = UpdateData.Update("tbl_Member", tbMem, "Member_ID=" + memberid.ToString());
                if (_update)
                {
                    SessionUtil.SetKey("Member_Name", txtName.Text);
                    SessionUtil.SetKey("Member_Email", txtEmail.Text);
                    SessionUtil.SetKey("Member_Phone", txtSdt.Text);
                    dvinfo.Visible = true;
                    avartar.ImageUrl = fileName;
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.Success, "Cập nhật"), AlertType.SUCCESS);
                }
                else
                {
                    dvinfo.Visible = true;
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Cập nhật"), AlertType.ERROR);
                }
            }
            catch (Exception)
            {
                Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Cập nhật"), AlertType.ERROR);
            }
        }
        else
        {
            Value.ShowMessage(ltrError, ErrorMessage.Unauthorized, AlertType.ERROR);
            dvinfo.Visible = false;
        }
    }

    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        Value.BindToDropdown(ddlQuanHuyen, UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlTinh.SelectedValue).Tables[0]);
    }

    protected void fAvartar_DataBinding(object sender, EventArgs e)
    {

    }
}