namespace Shop_QuanAo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaSanPham { get; set; }

        public int SoLuong { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDung NguoiDung { get; set; }

        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }
    }

}