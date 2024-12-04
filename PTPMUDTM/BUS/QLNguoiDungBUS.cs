using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QLNguoiDungBUS
    {
        private ShopQuanAoDataContext db;

        // Constructor: Khởi tạo db (DataContext) với chuỗi kết nối thủ công
        public QLNguoiDungBUS()
        {
            // Chuỗi kết nối
            string connectionString = "Data Source=MSI;Initial Catalog=ShopQuanAo;User ID=sa;Password=123;TrustServerCertificate=True";

            // Khởi tạo context LINQ (DataContext) với chuỗi kết nối
            db = new ShopQuanAoDataContext(connectionString);
        }

        public List<NguoiDung> LayDanhSachNguoiDung()
        {
            // Truy vấn cơ sở dữ liệu để lấy danh sách người dùng
            var danhSach = db.NguoiDungs.ToList();
            return danhSach;
        }

        // Lấy danh sách vai trò từ bảng VaiTro
        public List<VaiTro> LayDanhSachVaiTro()
        {
            try
            {
                return db.VaiTros.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<VaiTro>();
            }
        }

        // Thêm người dùng mới
        public bool ThemNguoiDung(string hoTen, string email, string matKhau, string soDienThoai, int maVaiTro, DateTime ngayTao)
        {
            try
            {
                // Tạo đối tượng NguoiDung mới
                var nguoiDung = new NguoiDung
                {
                    HoTen = hoTen,
                    Email = email,
                    MatKhau = matKhau,
                    SoDienThoai = soDienThoai,
                    MaVaiTro = maVaiTro,
                    NgayTao = DateTime.Now
                };

                // Thêm vào bảng NguoiDung
                db.NguoiDungs.InsertOnSubmit(nguoiDung);
                db.SubmitChanges();

                return true; // Thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Thất bại
            }
        }

        // Xóa người dùng theo mã người dùng
        public bool XoaNguoiDung(int maNguoiDung)
        {
            try
            {
                // Tìm người dùng theo mã trong database
                var nguoiDung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == maNguoiDung);

                if (nguoiDung != null)
                {
                    db.NguoiDungs.DeleteOnSubmit(nguoiDung); // Xóa người dùng
                    db.SubmitChanges(); // Ghi thay đổi vào database
                    return true; // Xóa thành công
                }

                return false; // Không tìm thấy người dùng để xóa
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa người dùng: {ex.Message}");
                return false; // Xóa thất bại
            }
        }

        // Sửa thông tin người dùng
        public bool SuaNguoiDung(int maNguoiDung, string hoTen, string email, string matKhau, string soDienThoai, int maVaiTro, DateTime ngayTao)
        {
            try
            {
                // Tìm người dùng theo mã
                var nguoiDung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == maNguoiDung);
                if (nguoiDung != null)
                {
                    nguoiDung.HoTen = hoTen;
                    nguoiDung.Email = email;
                    nguoiDung.MatKhau = matKhau;
                    nguoiDung.SoDienThoai = soDienThoai;
                    nguoiDung.MaVaiTro = maVaiTro;
                    nguoiDung.NgayTao = ngayTao;

                    db.SubmitChanges();
                    return true; // Thành công
                }
                return false; // Không tìm thấy người dùng
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Thất bại
            }
        }
    }
}
