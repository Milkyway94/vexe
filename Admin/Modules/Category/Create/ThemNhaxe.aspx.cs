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

public partial class Admin_Modules_Category_Create_ThemNhaxe : System.Web.UI.Page
{
    private NhaXe nx = new NhaXe();
    private int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ID = Request.QueryString["id"]!=""? int.Parse(Request.QueryString["id"]):0;
        string sql = "SELECT matinh as id, tentinh as text from TinhThanh";
        Value.BindToDropdown(Tinh, UpdateData.UpdateBySql(sql).Tables[0]);
        nx = new NhaxeRepository().Find(ID);
        if (!IsPostBack)
        {
            Tennhaxe.Text = nx.Tennhaxe;
            Sodienthoai.Text = nx.Sodienthoai;
            Soluongxe.Text = nx.Soluongxe.ToString();
            Trusochinh.Text = nx.Trusochinh;
            Gioithieuchitiet.Text = nx.Gioithieuchitiet;
            Gioithieungan.Text = nx.Gioithieungan;
            Nguoidaidien.Text = nx.Nguoidaidien;
            txtImg.Text = nx.Anh;
            catimg.Src = nx.Anh;
            for (int i = 0; i < Tinh.Items.Count; i++)
            {
                if (Tinh.Items[i].Value == nx.Tinh.ToString())
                {
                    Tinh.Items[i].Selected = true;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        NhaxeRepository nhaxeRepo = new NhaxeRepository();
        vexedtEntities context = new vexedtEntities();
        try
        {
            if (nx != null)
            {
                nx.Tennhaxe = Tennhaxe.Text;
                nx.Sodienthoai = Sodienthoai.Text;
                nx.Trusochinh = Trusochinh.Text;
                nx.Soluongxe = int.Parse(Soluongxe.Text);
                nx.Nguoidaidien = Nguoidaidien.Text;
                nx.Gioithieuchitiet = Gioithieuchitiet.Text;
                nx.Gioithieungan = Gioithieungan.Text;
                nx.Anh = txtImg.Text;
                nx.Tinh = int.Parse(Tinh.SelectedValue);
            }
            nhaxeRepo.Save();
            Hashtable tb = new Hashtable();
            tb.Add("Tennhaxe", Tennhaxe.Text);
            tb.Add("Trusochinh", Trusochinh.Text);
            tb.Add("Soluongxe", Soluongxe.Text);
            tb.Add("Nguoidaidien", Nguoidaidien.Text);
            tb.Add("Gioithieuchitiet", Gioithieuchitiet.Text);
            tb.Add("Anh", txtImg.Text);
            tb.Add("Tinh", Tinh.SelectedValue);
            tb.Add("Sodienthoai", Sodienthoai.Text);
            UpdateData.Update("Nhaxe", tb, "ID=" + ID);
            ltrScript.Text = ("<script>parent.showMsg('"+string.Format(ErrorMessage.Success, "Sửa nhà xe")+ "'); parent.window.location.reload();</script>");
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}