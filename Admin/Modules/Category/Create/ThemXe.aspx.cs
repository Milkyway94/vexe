using Newtonsoft.Json;
using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules_Category_Create_ThemXe : System.Web.UI.Page
{
    public string maxe;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Value.BindToDropdown(ddlNhaxe, NhaXe());
            Value.BindToDropdown(ddlHangXe, HangXe());
        }
        maxe = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(maxe))
        {
            Xe xe = new XeRepository().Find(int.Parse(maxe));
            txtAvartar.Text = xe.Avartar;
            txtBienSo.Text = xe.Bienso;
            txtChiTiet.Text = xe.Gioithieuchitiet;
            txtGioiThieu.Text = xe.Gioithieungan;
            txtSoGhe.Text = xe.TongSoGhe.ToString();
            txtTenXe.Text = xe.Tenxe;
            ckDel.Checked = !xe.Daxoa.Value;
            Value.BindToDropdown(ddlNhaxe, NhaXe());
            Value.BindToDropdown(ddlHangXe, HangXe());
            for (int i = 0; i < ddlHangXe.Items.Count; i++)
            {
                if (ddlHangXe.Items[i].Value == xe.Hangxe.Value.ToString())
                {
                    ddlHangXe.Items[i].Selected = true;
                }
            }
            for (int i = 0; i < ddlNhaxe.Items.Count; i++)
            {
                if (ddlNhaxe.Items[i].Value == xe.Nhaxe.Value.ToString())
                {
                    ddlNhaxe.Items[i].Selected = true;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Hashtable tbXe = new Hashtable();
        tbXe.Add("Bienso", txtBienSo.Text);
        tbXe.Add("TenXe", txtTenXe.Text);
        tbXe.Add("Nhaxe", ddlNhaxe.SelectedValue);
        tbXe.Add("Hangxe", ddlHangXe.SelectedValue);
        tbXe.Add("Gioithieungan", txtGioiThieu.Text);
        tbXe.Add("Gioithieuchitiet", txtChiTiet.Text);
        tbXe.Add("Daxoa", ckDel.Checked == true ? "0" : "1");
        tbXe.Add("Tongsoghe", txtSoGhe.Text);
        tbXe.Add("Avartar", txtAvartar.Text);
        if (string.IsNullOrEmpty(maxe))
        {
           tbXe.Add("NgayTao", DateTime.Now.ToString("MM/dd/yyyy"));
            tbXe.Add("Nguoitao", Session["UserName"].ToString());
            bool _insertXe = UpdateData.Insert("Xe", tbXe);
            if (_insertXe)
            {
                SessionUtil.SetKey("Message", string.Format(ErrorMessage.Success, "Thêm xe mới"));
                ltrScript.Text = ("<script>parent.window.location.reload();</script>");
            }
            else
            {
                Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Thêm mới xe"), AlertType.ERROR);
            }
        }
        else
        {
            bool _updateXe = UpdateData.Update("Xe", tbXe, "Maxe="+maxe);
            if (_updateXe)
            {
                ltrScript.Text = ("<script>parent.HideModal('#add-modal'); parent.window.location.reload();</script>");
            }
            else
            {
                Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Sửa xe"), AlertType.ERROR);
            }
        }
    }
    protected DataTable NhaXe()
    {
        if (SessionUtil.GetValue("UserID") != "")
        {
            return UpdateData.ExecStore("SP_CCB_NHAXE", SessionUtil.GetValue("UserID")).Tables[0];
        }
        else
            return new DataTable();
    }
    protected DataTable HangXe()
    {
        string sql = "SELECT  ID as id, name as text FROM Hangxe";
        return UpdateData.UpdateBySql(sql).Tables[0];
    }
}