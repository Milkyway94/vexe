//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QCMS_BUSSINESS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.Ghes = new HashSet<Ghe>();
            this.SoDienThoais = new HashSet<SoDienThoai>();
            this.ChuyenXes = new HashSet<ChuyenXe>();
        }
    
        public int MaXe { get; set; }
        public string Bienso { get; set; }
        public string Tenxe { get; set; }
        public Nullable<int> Nhaxe { get; set; }
        public string Gioithieungan { get; set; }
        public string Gioithieuchitiet { get; set; }
        public string Nguoitao { get; set; }
        public Nullable<System.DateTime> Ngaytao { get; set; }
        public Nullable<System.DateTime> Ngaysuacuoi { get; set; }
        public string Nguoisuacuoi { get; set; }
        public Nullable<bool> Daxoa { get; set; }
        public Nullable<int> TongSoGhe { get; set; }
        public Nullable<int> Hangxe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghe> Ghes { get; set; }
        public virtual NhaXe NhaXe1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoDienThoai> SoDienThoais { get; set; }
        public virtual Hangxe Hangxe1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenXe> ChuyenXes { get; set; }
    }
}