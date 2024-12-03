namespace Shop_QuanAo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        public int MaVaiTro { get; set; }

        public DateTime NgayTao { get; set; }

        [ForeignKey("MaVaiTro")]
        public virtual VaiTro VaiTro { get; set; }
    }
}