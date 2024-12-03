namespace Shop_QuanAo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CuaHang")]
    public class CuaHang
    {
        [Key]
        public int MaCuaHang { get; set; }

        [Required]
        [StringLength(100)]
        public string TenCuaHang { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}