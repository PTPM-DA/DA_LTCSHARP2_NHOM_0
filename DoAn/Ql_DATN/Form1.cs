﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ql_DATN
{
    public partial class Form1 : Form
    {
        private string userRole;
        public Form1(string role)
        {
            InitializeComponent();
            userRole = role;
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            if (userRole == "Nhân viên")
            {
                // Ẩn hoặc vô hiệu hóa các chức năng không được phép
                btnQLND.Enabled = false; // Nhân viên không được phép truy cập
            }
            else if (userRole == "Admin")
            {
                // Admin có toàn quyền, không cần thay đổi gì
            }
            else
            {
                MessageBox.Show("Vai trò không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Thoát nếu vai trò không xác định
            }
        }

        private void btnQLND_Click(object sender, EventArgs e)
        {
            // Tao doi tuong Frm_QLNV
            Frm_QLNguoiDung frmQLND = new Frm_QLNguoiDung(userRole);

            // An Form1 khi chuyen sang Frm_QLNV
            this.Hide();  // An Form hien tai

            // Hien thi Frm_QLNV
            frmQLND.Show();
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            Frm_QLSanPham frmQLSP = new Frm_QLSanPham(userRole);

            this.Hide();

            frmQLSP.Show();
        }

        private void btnQLDonHang_Click(object sender, EventArgs e)
        {
            QL_DonHang frmQLDH = new QL_DonHang(userRole);
            this.Hide();
            frmQLDH.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Đóng Form hiện tại và quay lại màn hình đăng nhập
                this.Hide(); // Ẩn Form chính
                Frm_DangNhap loginForm = new Frm_DangNhap();
                loginForm.Show(); // Hiển thị lại Form đăng nhập
            }
        }
    }
}
