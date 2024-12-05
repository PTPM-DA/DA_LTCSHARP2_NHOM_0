using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DangNhapBUS
    {
        private ShopQuanAoDataContext db;

        // Constructor: Khởi tạo db (DataContext) với chuỗi kết nối thủ công
        public DangNhapBUS()
        {
            // Kết nối
            // Chuỗi kết nối
            string connectionString = "Data Source=MSI;Initial Catalog=ShopQuanAo;User ID=sa;Password=123;TrustServerCertificate=True";

            // Khởi tạo context LINQ (DataContext) với chuỗi kết nối
            db = new ShopQuanAoDataContext(connectionString);
        }

        public (bool isSuccess, string role) DangNhap(string email, string matKhau)
        {
            var nguoiDung = db.NguoiDungs
                .FirstOrDefault(nd => nd.Email == email && nd.MatKhau == matKhau);

            if (nguoiDung != null)
            {
                var vaiTro = db.VaiTros.FirstOrDefault(vt => vt.MaVaiTro == nguoiDung.MaVaiTro);
                return (true, vaiTro?.TenVaiTro);
            }

            return (false, null); // Đăng nhập thất bại
        }
    }
}
