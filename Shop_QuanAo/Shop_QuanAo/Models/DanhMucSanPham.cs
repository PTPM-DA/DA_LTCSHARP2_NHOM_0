namespace Shop_QuanAo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DanhMucSanPham")]
    public class DanhMucSanPham
    {
        [Key]
        public int MaDanhMuc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; }

        public int? MaDanhMucCha { get; set; }

        [ForeignKey("MaDanhMucCha")]
        public virtual DanhMucSanPham DanhMucCha { get; set; }
    }

}