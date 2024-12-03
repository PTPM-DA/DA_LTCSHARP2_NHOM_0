namespace Shop_QuanAo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ThanhToan")]
    public class ThanhToan
    {
        [Key]
        public int MaThanhToan { get; set; }

        public int MaDonHang { get; set; }

        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [StringLength(50)]
        public string TrangThaiThanhToan { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        [ForeignKey("MaDonHang")]
        public virtual DonHang DonHang { get; set; }
    }

}