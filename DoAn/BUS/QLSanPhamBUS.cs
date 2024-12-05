using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QLSanPhamBUS
    {
        private ShopQuanAoDataContext db;

        // Constructor: Khởi tạo db (DataContext) với chuỗi kết nối thủ công
        public QLSanPhamBUS()
        {
            // Chuỗi kết nối
            string connectionString = "Data Source=MSI;Initial Catalog=ShopQuanAo;User ID=sa;Password=123;TrustServerCertificate=True";

            // Khởi tạo context LINQ (DataContext) với chuỗi kết nối
            db = new ShopQuanAoDataContext(connectionString);
        }

        public bool ThemSanPham(string tenSanPham, string moTa, decimal gia, string hinhAnh, int maDanhMuc, DateTime ngayTao)
        {
            try
            {
                SanPham newProduct = new SanPham
                {
                    TenSanPham = tenSanPham,
                    MoTa = moTa,
                    Gia = gia,
                    HinhAnh = hinhAnh,
                    MaDanhMuc = maDanhMuc,
                    NgayTao = ngayTao
                };

                db.SanPhams.InsertOnSubmit(newProduct);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Xóa sản phẩm
        public bool XoaSanPham(int maSanPham)
        {
            try
            {
                var product = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == maSanPham);
                if (product != null)
                {
                    db.SanPhams.DeleteOnSubmit(product);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        // Sửa sản phẩm
        public bool SuaSanPham(int maSanPham, string tenSanPham, string moTa, decimal gia, string hinhAnh, int maDanhMuc, DateTime ngayTao)
        {
            try
            {
                var product = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == maSanPham);
                if (product != null)
                {
                    product.TenSanPham = tenSanPham;
                    product.MoTa = moTa;
                    product.Gia = gia;
                    product.HinhAnh = hinhAnh;
                    product.MaDanhMuc = maDanhMuc;
                    product.NgayTao = ngayTao;

                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public List<SanPham> LoadSanPham()
        {
            try
            {
                return db.SanPhams.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<SanPham>();
            }
        }

        public List<DanhMucSanPham> LoadDanhMucSanPham()
        {
            try
            {
                return db.DanhMucSanPhams.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<DanhMucSanPham>();
            }
        }
    }
}
