//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThucUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucUong()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
    
        public int tu_id { get; set; }
        public string tu_ten { get; set; }
        public int tu_gia { get; set; }
        public Nullable<int> tu_trangthai { get; set; }
        public int dm_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}