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
    
    public partial class TaiKhoan
    {
        public string nv_id { get; set; }
        public string tk_matkhau { get; set; }
        public int tk_quyen { get; set; }
        public Nullable<int> tk_trangthai { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
