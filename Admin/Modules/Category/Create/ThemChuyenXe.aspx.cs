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

public partial class Admin_Modules_Category_Create_ThemChuyenXe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string machuyenxe = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(machuyenxe))
            {
                DataTable dtXe = UpdateData.ExecStore("SP_CCB_XE", "").Tables[0];
                DataTable dtTinh = UpdateData.ExecStore("SP_CCB_Tinh", "").Tables[0];
                Value.BindToDropdown(ddlXe, dtXe);
                Value.BindToDropdown(ddlDenTinh, dtTinh);
                Value.BindToDropdown(ddlDiTinh, dtTinh);
                ChuyenXe cx = new ChuyenXeRepository().Find(int.Parse(machuyenxe));
                txtGiaThuong.Text = cx.GiaThuong.ToString();
                txtGiaVip.Text = cx.GiaVIP.ToString();
                txtGiodi.Text = cx.Giokhoihanh.Value.ToString("hh:mm:ss");
                txtKhuyenMai.Text = cx.KhuyenMai.ToString();
                txtLotrinh.Text = cx.LoTrinh;
                txtNgaydi.Text = cx.Ngaydi.Value.ToString("dd/MM/yyyy");
                txtThoigiandiG.Text = cx.Thoigiandukien.Value.ToString("hh");
                txtThoigiandiP.Text = cx.Thoigiandukien.Value.ToString("mm");
                txtTongsove.Text = cx.TongVe.ToString();
                txtVethuong.Text = cx.TongSoVeThuong.ToString();
                txtVeVip.Text = cx.TongSoVeVIP.ToString();
                for (int i = 0; i < ddlDiTinh.Items.Count; i++)
                {
                    if (cx.DiTinh.ToString() == ddlDiTinh.Items[i].Value)
                    {
                        ddlDiTinh.Items[i].Selected = true;
                        DataTable dtDiHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", cx.DiTinh.ToString()).Tables[0];
                        Value.BindToDropdown(ddlDiHuyen, dtDiHuyen);
                        for (int j = 0; j < ddlDiHuyen.Items.Count; j++)
                        {
                            if (cx.DiHuyen.ToString() == ddlDiHuyen.Items[j].Value)
                            {
                                ddlDiHuyen.Items[i].Selected = true;
                            }
                        }
                    }

                }
                for (int i = 0; i < ddlDenTinh.Items.Count; i++)
                {
                    if (cx.DenTinh.ToString() == ddlDenTinh.Items[i].Value)
                    {
                        ddlDenTinh.Items[i].Selected = true;
                        DataTable dtDenHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", cx.DenTinh.ToString()).Tables[0];
                        Value.BindToDropdown(ddlDenHuyen, dtDenHuyen);
                        for (int j = 0; j < ddlDenHuyen.Items.Count; j++)
                        {
                            if (cx.DenHuyen.ToString() == ddlDenHuyen.Items[j].Value)
                            {
                                ddlDenHuyen.Items[j].Selected = true;
                            }
                        }
                    }

                }
            }
            else
            {
                DataTable dtXe = UpdateData.ExecStore("SP_CCB_XE", "").Tables[0];
                DataTable dtTinh = UpdateData.ExecStore("SP_CCB_Tinh", "").Tables[0];
                Value.BindToDropdown(ddlXe, dtXe);
                Value.BindToDropdown(ddlDenTinh, dtTinh);
                Value.BindToDropdown(ddlDiTinh, dtTinh);
                DataTable dtDiHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlDiTinh.SelectedValue).Tables[0];
                Value.BindToDropdown(ddlDiHuyen, dtDiHuyen);
                DataTable dtDenHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlDenTinh.SelectedValue).Tables[0];
                Value.BindToDropdown(ddlDenHuyen, dtDenHuyen);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string machuyenxe = Request.QueryString["id"];
        CultureInfo provider = CultureInfo.InvariantCulture;
        TimeSpan tsThoiGian = new TimeSpan(int.Parse(txtThoigiandiG.Text), int.Parse(txtThoigiandiP.Text), 0);

            int MaXe = int.Parse(ddlXe.SelectedValue);
        DateTime Ngaydi = DateTime.ParseExact(txtNgaydi.Text, "dd/MM/yyyy", provider);
        DateTime Giokhoihanh = DateTime.Parse(txtGiodi.Text);
        TimeSpan Thoigiandukien = tsThoiGian;
        string Diemdi = ddlDiHuyen.SelectedItem.Text + "-" + ddlDiTinh.SelectedItem.Text;
        string Diemden = ddlDenHuyen.SelectedItem.Text + "-" + ddlDenTinh.SelectedItem.Text;
        int DiHuyen = int.Parse(ddlDiHuyen.SelectedValue);
        int DiTinh = int.Parse(ddlDiTinh.SelectedValue);
        int DenTinh = int.Parse(ddlDenTinh.SelectedValue);
        int DenHuyen = int.Parse(ddlDenHuyen.SelectedValue);
        int TongSoVeThuong = int.Parse(txtVethuong.Text);
        int TongVe = int.Parse(txtTongsove.Text);
        int TongSoVeVIP = int.Parse(txtVethuong.Text);
        double GiaThuong = double.Parse(txtGiaThuong.Text);
        double GiaVIP = double.Parse(txtGiaVip.Text);
        string LoTrinh = txtLotrinh.Text;
        int KhuyenMai = int.Parse(txtKhuyenMai.Text);

        Hashtable tbCx = new Hashtable();
        tbCx.Add("MaXe", MaXe.ToString());
        tbCx.Add("Ngaydi", Ngaydi.ToString());
        tbCx.Add("Giokhoihanh", Giokhoihanh.ToString());
        tbCx.Add("Thoigiandukien", Thoigiandukien.ToString());
        tbCx.Add("Diemdi", Diemdi);
        tbCx.Add("Diemden", Diemden);
        tbCx.Add("TongSoVeThuong", TongSoVeThuong.ToString());
        tbCx.Add("TongVe", TongVe.ToString());
        tbCx.Add("TongSoVeVIP", TongSoVeVIP.ToString());
        tbCx.Add("GiaThuong", GiaThuong.ToString());
        tbCx.Add("GiaVIP", GiaVIP.ToString());
        tbCx.Add("VeVipConLai", TongSoVeVIP.ToString());
        tbCx.Add("VeThuongConLai", TongSoVeThuong.ToString());
        tbCx.Add("DiHuyen", DiHuyen.ToString());
        tbCx.Add("DiTinh", DiTinh.ToString());
        tbCx.Add("DenTinh", DenTinh.ToString());
        tbCx.Add("DenHuyen", DenHuyen.ToString());
        tbCx.Add("Lotrinh", LoTrinh);
        tbCx.Add("KhuyenMai", KhuyenMai.ToString());
        try
        {
            if (string.IsNullOrEmpty(machuyenxe))
            {
                try
                {
                    bool _insertCx = UpdateData.Insert("ChuyenXe", tbCx);
                    if (_insertCx)
                    {
                        string sql = "SELECT * FROM ChuyenXe ORder by MaChuyenXe DESC";
                        DataTable dt = UpdateData.UpdateBySql(sql).Tables[0];
                        string macx = dt.Rows[0]["Machuyenxe"].ToString();
                        string diemden = dt.Rows[0]["DiemDen"].ToString();
                        string diemdi = dt.Rows[0]["DiemDi"].ToString();
                        Hashtable dbUpdateUrl = new Hashtable();
                        dbUpdateUrl.Add("url", Value.CreateSlug(CMSfunc.VietnameseConvert.ChuyenTVKhongDau(diemdi) + "-" + CMSfunc.VietnameseConvert.ChuyenTVKhongDau(diemden) + "-" + macx));
                        UpdateData.Update("ChuyenXe", dbUpdateUrl, "Machuyenxe=" + macx);
                        ltrScript.Text = ("<script>parent.HideModal('#add-modal'); parent.window.location.reload();</script>");
                    }
                    else
                    {
                        Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Thêm mới chuyến xe "), AlertType.ERROR);
                    }
                }
                catch (Exception ex)
                {

                    ltrScript.Text = "<script>console.log('"+ex.ToString()+"')</script>";
                }
                
                
            }
            else
            {

                tbCx.Add("url", Value.CreateSlug(CMSfunc.VietnameseConvert.ChuyenTVKhongDau(Diemdi) + "-" + CMSfunc.VietnameseConvert.ChuyenTVKhongDau(Diemden) + "-" + machuyenxe));
                bool _updateCx = UpdateData.Update("ChuyenXe", tbCx, "MaChuyenXe=" + machuyenxe);
                if (_updateCx)
                {
                    ltrScript.Text = ("<script>parent.HideModal('#add-modal'); parent.window.location.reload();</script>");
                }
                else
                {
                    Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Sửa chuyến xe "), AlertType.ERROR);
                }
            }
        }
        catch (Exception)
        {

            Value.ShowMessage(ltrError, string.Format(ErrorMessage.Fail, "Thêm mới chuyến xe "), AlertType.ERROR);
        }
    }
    protected void ddlDiTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        var dtDiHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlDiTinh.SelectedValue).Tables[0];
        ddlDiHuyen.Items.Clear();
        Value.BindToDropdown(ddlDiHuyen, dtDiHuyen);
        ddlDiHuyen.Focus();
    }

    protected void ddlDenTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        var dtDenHuyen = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", ddlDenTinh.SelectedValue).Tables[0];
        ddlDenHuyen.Items.Clear();
        Value.BindToDropdown(ddlDenHuyen, dtDenHuyen);
        ddlDenHuyen.Focus();
    }
    [WebMethod]
    public static string GetHuyenByTinh(string matinh)
    {
        var obj = UpdateData.ExecStore("SP_CCB_Huyen_FROM_Tinh", matinh.ToString()).Tables[0];
        return JsonConvert.SerializeObject(obj);
    }
}