using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Model
{
    public class XeModel
    {
        public int MaXe { get; set; }
        public string Bienso { get; set; }
        public string Tenxe { get; set; }
        public string Gioithieungan { get; set; }
        public string Gioithieuchitiet { get; set; }
        public string Nguoitao { get; set; }
        public Nullable<System.DateTime> Ngaytao { get; set; }
        public Nullable<System.DateTime> Ngaysuacuoi { get; set; }
        public string Nguoisuacuoi { get; set; }
        public Nullable<bool> Daxoa { get; set; }
        public Nullable<int> TongSoGhe { get; set; }
        public Hangxe Hangxe { get; set; }
        public Ghe Ghes { get; set; }
        public NhaXe NhaXe { get; set; }

    }
}
