namespace Shop_QuanAo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhoHang")]
    public class KhoHang
    {
        [Key]
        public int MaKhoHang { get; set; }

        public int MaSanPham { get; set; }

        public int MaCuaHang { get; set; }

        public int SoLuong { get; set; }

        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }

        [ForeignKey("MaCuaHang")]
        public virtual CuaHang CuaHang { get; set; }
    }

}