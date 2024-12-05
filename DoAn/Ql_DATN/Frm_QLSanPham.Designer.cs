namespace Ql_DATN
{
    partial class Frm_QLSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVeTrangChu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ptbTaiAnh = new System.Windows.Forms.PictureBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.rtxtMoTa = new System.Windows.Forms.RichTextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTaiAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnVeTrangChu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1412, 94);
            this.panel1.TabIndex = 2;
            // 
            // btnVeTrangChu
            // 
            this.btnVeTrangChu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeTrangChu.Location = new System.Drawing.Point(4, 4);
            this.btnVeTrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.btnVeTrangChu.Name = "btnVeTrangChu";
            this.btnVeTrangChu.Size = new System.Drawing.Size(193, 63);
            this.btnVeTrangChu.TabIndex = 18;
            this.btnVeTrangChu.Text = "Về trang chủ";
            this.btnVeTrangChu.UseVisualStyleBackColor = true;
            this.btnVeTrangChu.Click += new System.EventHandler(this.btnVeTrangChu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mô tả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(596, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 27);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày tạo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(651, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 27);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(552, 176);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Mã danh mục";
            // 
            // ptbTaiAnh
            // 
            this.ptbTaiAnh.Location = new System.Drawing.Point(1065, 101);
            this.ptbTaiAnh.Margin = new System.Windows.Forms.Padding(4);
            this.ptbTaiAnh.Name = "ptbTaiAnh";
            this.ptbTaiAnh.Size = new System.Drawing.Size(315, 246);
            this.ptbTaiAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTaiAnh.TabIndex = 9;
            this.ptbTaiAnh.TabStop = false;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(207, 126);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(320, 30);
            this.txtMaSP.TabIndex = 10;
            // 
            // rtxtMoTa
            // 
            this.rtxtMoTa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMoTa.Location = new System.Drawing.Point(207, 229);
            this.rtxtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtMoTa.Name = "rtxtMoTa";
            this.rtxtMoTa.Size = new System.Drawing.Size(320, 130);
            this.rtxtMoTa.TabIndex = 11;
            this.rtxtMoTa.Text = "";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(207, 176);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(320, 30);
            this.txtTenSP.TabIndex = 12;
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(723, 126);
            this.txtGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(303, 30);
            this.txtGia.TabIndex = 13;
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Location = new System.Drawing.Point(723, 225);
            this.dtpNgayTao.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(303, 30);
            this.dtpNgayTao.TabIndex = 15;
            // 
            // dgvSP
            // 
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Location = new System.Drawing.Point(16, 405);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.RowHeadersWidth = 51;
            this.dgvSP.Size = new System.Drawing.Size(1380, 314);
            this.dgvSP.TabIndex = 17;
            this.dgvSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(615, 343);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 41);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(764, 343);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 41);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(915, 343);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 41);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiAnh.Location = new System.Drawing.Point(1171, 354);
            this.btnTaiAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(100, 41);
            this.btnTaiAnh.TabIndex = 21;
            this.btnTaiAnh.Text = "Tải ảnh";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            this.btnTaiAnh.Click += new System.EventHandler(this.btnTaiAnh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(595, 276);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 27);
            this.label8.TabIndex = 22;
            this.label8.Text = "Hình ảnh";
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHinhAnh.Location = new System.Drawing.Point(723, 273);
            this.txtHinhAnh.Margin = new System.Windows.Forms.Padding(4);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(303, 30);
            this.txtHinhAnh.TabIndex = 23;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(723, 175);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(303, 30);
            this.cboDanhMuc.TabIndex = 19;
            // 
            // Frm_QLSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 734);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.txtHinhAnh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnTaiAnh);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.dtpNgayTao);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.rtxtMoTa);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.ptbTaiAnh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_QLSanPham";
            this.Text = "Frm_QLSanPham";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTaiAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox ptbTaiAnh;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.RichTextBox rtxtMoTa;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.Button btnVeTrangChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.ComboBox cboDanhMuc;
    }
}