using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shop_QuanAo.Models
{
    public class ShopQuanAoContext: DbContext
    {
        public ShopQuanAoContext() : base("ShopQuanAoContext")
        {
        }
        public DbSet<VaiTro> VaiTro { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<CuaHang> CuaHang { get; set; }
        public DbSet<DanhMucSanPham> DanhMucSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<KhoHang> KhoHang { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public DbSet<ThanhToan> ThanhToan { get; set; }
        public DbSet<DiaChiGiaoHang> DiaChiGiaoHang { get; set; }
        public DbSet<VanChuyen> VanChuyen { get; set; }
        public DbSet<GioHang> GioHang { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}