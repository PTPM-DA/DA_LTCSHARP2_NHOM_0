using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace Ql_DATN
{
    public partial class Frm_QLSanPham : Form
    {
        private string userRole;
        public Frm_QLSanPham(string role)
        {
            InitializeComponent();
            dgvSP.CellClick += dgvSP_CellClick;
            LoadData();
            userRole = role;

        }
        private void LoadData()
        {
            QLSanPhamBUS bus = new QLSanPhamBUS();
            var products = bus.LoadSanPham();
            dgvSP.DataSource = products;
            if (dgvSP.Columns["DanhMucSanPham"] != null)
            {
                dgvSP.Columns["DanhMucSanPham"].Visible = false;
            }

            var categories = bus.LoadDanhMucSanPham();
            cboDanhMuc.DataSource = categories;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Chỉ cho phép chọn hình ảnh

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị hình ảnh vào PictureBox
                ptbTaiAnh.Image = Image.FromFile(openFileDialog.FileName);

                // Lấy tên ảnh từ đường dẫn
                string imageName = Path.GetFileName(openFileDialog.FileName);  // Lấy tên ảnh

                // Lưu tên ảnh vào TextBox hoặc biến để sử dụng khi thêm/sửa sản phẩm
                txtHinhAnh.Text = imageName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            {
                string tenSanPham = txtTenSP.Text;
                string moTa = rtxtMoTa.Text;
                decimal gia = decimal.Parse(txtGia.Text);
                string hinhAnh = txtHinhAnh.Text;
                int maDanhMuc = (int)cboDanhMuc.SelectedValue;
                DateTime ngayTao = dtpNgayTao.Value;

                QLSanPhamBUS bus = new QLSanPhamBUS();
                bool success = bus.ThemSanPham(tenSanPham, moTa, gia, hinhAnh, maDanhMuc, ngayTao);

                if (success)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!");
                }
            }
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng đã chọn
                var row = dgvSP.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSanPham"].Value?.ToString() ?? string.Empty;
                txtTenSP.Text = row.Cells["TenSanPham"].Value?.ToString() ?? string.Empty;
                rtxtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? string.Empty;
                txtGia.Text = row.Cells["Gia"].Value?.ToString() ?? string.Empty;
                txtHinhAnh.Text = row.Cells["HinhAnh"].Value?.ToString() ?? string.Empty;
                if (row.Cells["MaDanhMuc"].Value != null)
                {
                    cboDanhMuc.SelectedValue = int.Parse(row.Cells["MaDanhMuc"].Value.ToString());
                }
                dtpNgayTao.Value = row.Cells["NgayTao"].Value != null ? (DateTime)row.Cells["NgayTao"].Value : DateTime.Now;

                // Tạo đường dẫn đầy đủ cho ảnh
                string imageDirectory = @"C:\Users\NGOC VIEN\Pictures\Screenshots";  // Thư mục chứa ảnh
                string imageName = row.Cells["HinhAnh"].Value?.ToString();  // Lấy tên ảnh từ DataGridView

                // Kết hợp thư mục và tên ảnh thành đường dẫn đầy đủ
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine(imageDirectory, imageName);

                    // Kiểm tra xem ảnh có tồn tại không
                    if (File.Exists(imagePath))
                    {
                        // Hiển thị hình ảnh vào PictureBox
                        ptbTaiAnh.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // Hiển thị ảnh mặc định nếu ảnh không tìm thấy
                        ptbTaiAnh.Image = Properties.Resources._default;
                    }
                }
                else
                {
                    ptbTaiAnh.Image = Properties.Resources._default; // Ảnh mặc định khi không có tên ảnh
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSanPham = int.Parse(txtMaSP.Text);

            QLSanPhamBUS bus = new QLSanPhamBUS();
            bool success = bus.XoaSanPham(maSanPham);

            if (success)
            {
                MessageBox.Show("Xóa sản phẩm thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int maSanPham = int.Parse(txtMaSP.Text);
                string tenSanPham = txtTenSP.Text;
                string moTa = rtxtMoTa.Text;
                decimal gia = decimal.Parse(txtGia.Text);
                string hinhAnh = txtHinhAnh.Text;
                int maDanhMuc = (int)cboDanhMuc.SelectedValue;
                DateTime ngayTao = dtpNgayTao.Value;

                // Gọi hàm sửa từ BUS
                QLSanPhamBUS bus = new QLSanPhamBUS();
                bool success = bus.SuaSanPham(maSanPham, tenSanPham, moTa, gia, hinhAnh, maDanhMuc, ngayTao);

                if (success)
                {
                    MessageBox.Show("Sửa sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại!");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi định dạng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVeTrangChu_Click(object sender, EventArgs e)
        {
            // An Frm_QLNV khi quay lai trang chu
            this.Hide();  // Ẩn Frm_QLNV

            // Hien thi lai Form1
            Form1 form1 = new Form1(userRole);
            form1.Show();
        }
    }
}
