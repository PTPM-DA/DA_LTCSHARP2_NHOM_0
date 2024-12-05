using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace Ql_DATN
{
    public partial class QL_DonHang : Form
    {
        private string userRole;
        private QLDonHangBUS donHangBUS = new QLDonHangBUS();
        public QL_DonHang(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQLDH.SelectedRows.Count > 0) // Kiểm tra có hàng nào được chọn
                {
                    // Lấy mã đơn hàng từ DataGridView
                    int maDonHang = Convert.ToInt32(dgvQLDH.SelectedRows[0].Cells["MaDonHang"].Value);


                    // Gọi BUS để cập nhật trạng thái
                    bool ketQua = donHangBUS.CapNhatTrangThaiDonHang(maDonHang);

                    if (ketQua)
                    {
                        MessageBox.Show("Đơn hàng đã được duyệt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDonHang(); // Tải lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng để duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachDonHang()
        {
            try
            {
                using (var context = new ShopQuanAoDataContext("Data Source=MSI;Initial Catalog=ShopQuanAo;User ID=sa;Password=123"))
                {
                    var danhSachDonHang = context.DonHangs.ToList();

                    // Hiển thị dữ liệu trên DataGridView
                    dgvQLDH.DataSource = danhSachDonHang.Select(dh => new
                    {
                        MaDonHang = dh.MaDonHang,
                        MaNguoiDung = dh.MaNguoiDung,
                        MaCuaHang = dh.MaCuaHang,
                        TongTien = dh.TongTien,
                        TrangThaiDonHang = dh.TrangThaiDonHang,
                        NgayTao = dh.NgayTao
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QL_DonHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonHang();
        }

        private void btnVeTrangChu_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Truyền vai trò hiện tại khi mở lại Form1
            Form1 form1 = new Form1(userRole); // Biến userRole lưu vai trò, cần được truyền từ Form cha hoặc khi khởi tạo
            form1.Show();
        }
    }
    
}
