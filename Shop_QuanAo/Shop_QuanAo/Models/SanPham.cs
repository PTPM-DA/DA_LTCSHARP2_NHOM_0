namespace Shop_QuanAo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSanPham { get; set; }

        public string MoTa { get; set; }

        [Required]

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Gia { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        public int? MaDanhMuc { get; set; }

        public DateTime? NgayTao { get; set; }

        [ForeignKey("MaDanhMuc")]
        public virtual DanhMucSanPham DanhMucSanPham { get; set; }
    }

}