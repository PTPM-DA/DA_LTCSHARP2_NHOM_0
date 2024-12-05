using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QLDonHangBUS
    {
        public bool CapNhatTrangThaiDonHang(int maDonHang)
        {
            try
            {
                using (var context = new ShopQuanAoDataContext("Data Source=MSI;Initial Catalog=ShopQuanAo;User ID=sa;Password=123;TrustServerCertificate=True"))
                {
                    // Tìm đơn hàng cần cập nhật
                    var donHang = context.DonHangs.SingleOrDefault(dh => dh.MaDonHang == maDonHang);
                    if (donHang != null)
                    {
                        donHang.TrangThaiDonHang = "Đã duyệt"; // Cập nhật trạng thái
                        context.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                        return true;
                    }
                    return false; // Không tìm thấy đơn hàng
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái: {ex.Message}");
            }
        }
    }
}
