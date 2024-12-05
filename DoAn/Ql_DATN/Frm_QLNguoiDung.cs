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
    public partial class Frm_QLNguoiDung : Form
    {
        private string userRole;
        private QLNguoiDungBUS bus;
        public Frm_QLNguoiDung(string role)
        {
            InitializeComponent();
            bus = new QLNguoiDungBUS();
            dgvNgDung.CellClick += dgvNgDung_CellClick;
            LoadData();
            LoadVaiTro();
            userRole = role;
        }

        private void LoadData()
        {
            // Tạo đối tượng QLNguoiDungBUS để lấy dữ liệu
            QLNguoiDungBUS bus = new QLNguoiDungBUS();

            // Lấy danh sách người dùng từ phương thức LayDanhSachNguoiDung trong BUS
            var danhSachNguoiDung = bus.LayDanhSachNguoiDung();

            // Sử dụng DataGridView để hiển thị danh sách người dùng
            dgvNgDung.DataSource = danhSachNguoiDung;
            if (dgvNgDung.Columns["VaiTro"] != null)
            {
                dgvNgDung.Columns["VaiTro"].Visible = false;
            }
        }

        private void LoadVaiTro()
        {
            var danhSachVaiTro = bus.LayDanhSachVaiTro();
            cboMaVaiTro.DataSource = danhSachVaiTro;
            cboMaVaiTro.DisplayMember = "TenVaiTro";
            cboMaVaiTro.ValueMember = "MaVaiTro";
        }

        private void btnVeTrangChu_Click(object sender, EventArgs e)
        {
            // An Frm_QLNV khi quay lai trang chu
            this.Hide();

            // Truyền vai trò hiện tại khi mở lại Form1
            Form1 form1 = new Form1(userRole); // Biến userRole lưu vai trò, cần được truyền từ Form cha hoặc khi khởi tạo
            form1.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtHoTen.Text;
                string email = txtEmail.Text;
                string matKhau = txtMK.Text;
                string soDienThoai = txtSDT.Text;
                int maVaiTro = Convert.ToInt32(cboMaVaiTro.SelectedValue);
                DateTime ngayTao = DateTime.Now;


                QLNguoiDungBUS bus = new QLNguoiDungBUS();
                bool success = bus.ThemNguoiDung(hoTen, email, matKhau, soDienThoai, maVaiTro, ngayTao);

                if (success)
                {
                    MessageBox.Show("Thêm người dùng thành công!");
                    LoadData(); // Tải lại danh sách người dùng
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        private void dgvNgDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNgDung.Rows[e.RowIndex];

                txtMaND.Text = row.Cells["MaNguoiDung"].Value?.ToString() ?? string.Empty;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                txtMK.Text = row.Cells["MatKhau"].Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? string.Empty;
                if (int.TryParse(row.Cells["MaVaiTro"].Value?.ToString(), out int maVaiTro))
                {
                    cboMaVaiTro.SelectedValue = maVaiTro;
                }

                if (DateTime.TryParse(row.Cells["NgayTao"].Value?.ToString(), out DateTime ngayTao))
                {
                    dtpNgayTao.Value = ngayTao;
                }
                else
                {
                    dtpNgayTao.Value = DateTime.Now; // Giá trị mặc định
                }
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra nếu TextBox mã người dùng rỗng
            if (string.IsNullOrWhiteSpace(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã người dùng để xóa!");
                return;
            }

            // Kiểm tra nếu mã người dùng không phải số nguyên
            if (!int.TryParse(txtMaND.Text, out int maNguoiDung))
            {
                MessageBox.Show("Mã người dùng không hợp lệ!");
                return;
            }

            // Tạo đối tượng BUS và gọi hàm xóa
            QLNguoiDungBUS bus = new QLNguoiDungBUS();
            bool success = bus.XoaNguoiDung(maNguoiDung);

            // Hiển thị thông báo kết quả
            if (success)
            {
                MessageBox.Show("Xóa người dùng thành công!");
                LoadData(); // Cập nhật lại DataGridView
            }
            else
            {
                MessageBox.Show("Xóa người dùng thất bại! Người dùng có thể không tồn tại hoặc đang được liên kết trong cơ sở dữ liệu.");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            int maNguoiDung = int.Parse(txtMaND.Text);  // Lấy mã người dùng từ TextBox
            string hoTen = txtHoTen.Text;
            string email = txtEmail.Text;
            string matKhau = txtMK.Text;
            string soDienThoai = txtSDT.Text;
            int maVaiTro = Convert.ToInt32(cboMaVaiTro.SelectedValue);
            DateTime ngayTao = DateTime.Now;

            NguoiDung nguoiDung = new NguoiDung
            {
                MaNguoiDung = maNguoiDung,  // Gán mã người dùng cần sửa
                HoTen = hoTen,
                Email = email,
                MatKhau = matKhau,
                SoDienThoai = soDienThoai,
                MaVaiTro = maVaiTro,
                NgayTao = ngayTao
            };

            QLNguoiDungBUS bus = new QLNguoiDungBUS();
            bool success = bus.SuaNguoiDung(maNguoiDung, hoTen, email, matKhau, soDienThoai, maVaiTro, ngayTao);

            if (success)
            {
                MessageBox.Show("Sửa người dùng thành công!");
                LoadData(); // Tải lại danh sách người dùng
            }
            else
            {
                MessageBox.Show("Sửa người dùng thất bại!");
            }
        }
    }
}
