using QCMS_BUSSINESS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Model
{
    public class ChuyenXeViewModel
    {
        public int MaChuyenXe { get; set; }
        public string Ngaydi { get; set; }
        public string Giokhoihanh { get; set; }
        public string Thoigiandukien { get; set; }
        public string Mota { get; set; }
        public string Chitiet { get; set; }
        public Nullable<int> TuyenDuong { get; set; }
        public string Diemdi { get; set; }
        public string Diemden { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public Nullable<double> GiaVIP { get; set; }
        public Nullable<double> GiaThuong { get; set; }
        public Nullable<int> TongVe { get; set; }
        public Nullable<int> VeThuongConLai { get; set; }
        public string SDT { get; set; }
        public Nullable<int> KhuyenMai { get; set; }
        public string LoTrinh { get; set; }
        public string url { get; set; }
        public Nullable<int> TongSoVeVIP { get; set; }
        public Nullable<int> TongSoVeThuong { get; set; }
        public Nullable<int> VeVipConLai { get; set; }
        public Xe Xe { get; set; }
        public NhaXe NhaXe { get; set; }
        public Hangxe HangXe { get; set; }
        public string Giotoi { get; set; }
        public ChuyenXeViewModel(ChuyenXe cx)
        {
            this.Giotoi = (cx.Giokhoihanh + cx.Thoigiandukien).Value.ToString("HH:mm");
            this.Xe = new XeRepository().Find(cx.MaXe.Value);
            this.NhaXe = new NhaxeRepository().Find(this.Xe.Nhaxe.Value);
            this.NhaXe.Xes = new List<Xe>();
            this.Xe.ChuyenXes = new List<ChuyenXe>();
            this.Thoigiandukien = cx.Thoigiandukien.Value.Hours.ToString() + " giờ " + cx.Thoigiandukien.Value.Minutes.ToString() +" phút";
            this.Ngaydi = cx.Ngaydi.Value.ToString("dd/MM/yyyy");
            this.Mota = cx.Mota;
            this.Chitiet = cx.Chitiet;
            this.Diemden = cx.Diemden;
            this.Diemdi = cx.Diemdi;
            this.Giokhoihanh = cx.Giokhoihanh.Value.ToString("HH:mm");
            this.MaChuyenXe = cx.MaChuyenXe;
            this.TongVe = cx.TongVe;
            this.TrangThai = cx.TrangThai;
            this.TuyenDuong = cx.TuyenDuong;
            this.url = cx.url;
            this.VeThuongConLai = cx.VeThuongConLai;
            this.VeVipConLai = cx.VeVipConLai;
            this.GiaThuong = cx.GiaThuong;
            this.GiaVIP = cx.GiaVIP;
            this.KhuyenMai = cx.KhuyenMai;
            this.TongSoVeThuong = cx.TongSoVeThuong;
            this.TongSoVeVIP = cx.TongSoVeVIP;
            this.SDT = cx.SDT;
            this.LoTrinh = cx.LoTrinh;

        }
    }
}
