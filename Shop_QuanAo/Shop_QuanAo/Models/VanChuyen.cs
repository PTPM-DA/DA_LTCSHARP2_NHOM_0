namespace Shop_QuanAo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VanChuyen")]
    public class VanChuyen
    {
        [Key]
        public int MaVanChuyen { get; set; }

        public int MaDonHang { get; set; }

        [StringLength(100)]
        public string NhaVanChuyen { get; set; }

        [StringLength(100)]
        public string MaVanDon { get; set; }

        [StringLength(50)]
        public string TrangThaiVanChuyen { get; set; }

        public DateTime? NgayGiaoDuKien { get; set; }

        [ForeignKey("MaDonHang")]
        public virtual DonHang DonHang { get; set; }
    }

}