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
    
    public partial class tbl_Box
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Box()
        {
            this.tbl_Mod = new HashSet<tbl_Mod>();
        }
    
        public int Box_ID { get; set; }
        public string Box_Code { get; set; }
        public Nullable<int> Box_Type { get; set; }
        public string Box_Name { get; set; }
        public string Box_Img { get; set; }
        public string Box_Css { get; set; }
        public Nullable<int> Box_Pos { get; set; }
        public Nullable<bool> Box_Status { get; set; }
        public Nullable<int> lang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Mod> tbl_Mod { get; set; }
    }
}