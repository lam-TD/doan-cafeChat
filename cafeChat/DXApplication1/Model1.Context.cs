﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CafeDataBaseEntities : DbContext
    {
        public CafeDataBaseEntities()
            : base("name=CafeDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HoaDon_InThongKe2> HoaDon_InThongKe2 { get; set; }
        public virtual DbSet<HoaDon_InBaoCao> HoaDon_InBaoCao { get; set; }
        public virtual DbSet<HoaDon_InThongKe> HoaDon_InThongKe { get; set; }
        public virtual DbSet<HoaDon_ThongKeMaHD> HoaDon_ThongKeMaHD { get; set; }
    }
}
