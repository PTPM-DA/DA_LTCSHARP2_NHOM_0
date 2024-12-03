namespace Shop_QuanAo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DiaChiGiaoHang")]
    public class DiaChiGiaoHang
    {
        [Key]
        public int MaDiaChi { get; set; }

        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChiChiTiet { get; set; }

        [Required]
        [StringLength(100)]
        public string ThanhPho { get; set; }

        [StringLength(100)]
        public string QuanHuyen { get; set; }

        [StringLength(20)]
        public string MaBuuChinh { get; set; }

        [Required]
        [StringLength(100)]
        public string QuocGia { get; set; }

        [ForeignKey("MaNguoiDung")]
        public virtual NguoiDung NguoiDung { get; set; }
    }

}