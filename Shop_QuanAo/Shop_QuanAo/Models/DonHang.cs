namespace Shop_QuanAo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        public int MaNguoiDung { get; set; }

        public int? MaCuaHang { get; set; }

        [Required]
        public decimal TongTien { get; set; }

        [StringLength(50)]
        public string TrangThaiDonHang { get; set; }

        public DateTime? NgayTao { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDung NguoiDung { get; set; }

        [ForeignKey("MaCuaHang")]
        public virtual CuaHang CuaHang { get; set; }
    }

}