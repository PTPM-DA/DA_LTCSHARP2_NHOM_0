namespace Ql_DATN
{
    partial class QL_DonHang
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvQLDH = new System.Windows.Forms.DataGridView();
            this.btnDuyetDon = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnVeTrangChu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 123);
            this.panel1.TabIndex = 3;
            // 
            // btnVeTrangChu
            // 
            this.btnVeTrangChu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeTrangChu.Location = new System.Drawing.Point(5, 4);
            this.btnVeTrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.btnVeTrangChu.Name = "btnVeTrangChu";
            this.btnVeTrangChu.Size = new System.Drawing.Size(193, 63);
            this.btnVeTrangChu.TabIndex = 4;
            this.btnVeTrangChu.Text = "Về trang chủ";
            this.btnVeTrangChu.UseVisualStyleBackColor = true;
            this.btnVeTrangChu.Click += new System.EventHandler(this.btnVeTrangChu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // dgvQLDH
            // 
            this.dgvQLDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLDH.Location = new System.Drawing.Point(12, 140);
            this.dgvQLDH.Name = "dgvQLDH";
            this.dgvQLDH.RowHeadersWidth = 51;
            this.dgvQLDH.RowTemplate.Height = 24;
            this.dgvQLDH.Size = new System.Drawing.Size(895, 410);
            this.dgvQLDH.TabIndex = 4;
            // 
            // btnDuyetDon
            // 
            this.btnDuyetDon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyetDon.Location = new System.Drawing.Point(382, 569);
            this.btnDuyetDon.Name = "btnDuyetDon";
            this.btnDuyetDon.Size = new System.Drawing.Size(157, 45);
            this.btnDuyetDon.TabIndex = 5;
            this.btnDuyetDon.Text = "Duyệt đơn";
            this.btnDuyetDon.UseVisualStyleBackColor = true;
            this.btnDuyetDon.Click += new System.EventHandler(this.btnDuyetDon_Click);
            // 
            // QL_DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 671);
            this.Controls.Add(this.btnDuyetDon);
            this.Controls.Add(this.dgvQLDH);
            this.Controls.Add(this.panel1);
            this.Name = "QL_DonHang";
            this.Text = "QL_DonHang";
            this.Load += new System.EventHandler(this.QL_DonHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVeTrangChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvQLDH;
        private System.Windows.Forms.Button btnDuyetDon;
    }
}