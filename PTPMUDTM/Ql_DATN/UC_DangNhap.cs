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
using Ql_DATN;

namespace GUI

{
    public partial class UC_DangNhap : UserControl
    {
        private DangNhapBUS dangNhapBUS = new DangNhapBUS();

        public UC_DangNhap()
        {
            InitializeComponent();
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = mtxtEmail.Text.Trim();
            string matKhau = mtxtMK.Text.Trim();

            DangNhapBUS dangNhapBUS = new DangNhapBUS();
            var (isSuccess, role) = dangNhapBUS.DangNhap(email, matKhau); // Kiểm tra đăng nhập từ BUS

            if (isSuccess)
            {
                // Đăng nhập thành công, mở Form1 với vai trò
                Form1 frmMain = new Form1(role);
                frmMain.Show();
                this.FindForm().Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Thông báo nếu đăng nhập thất bại
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
