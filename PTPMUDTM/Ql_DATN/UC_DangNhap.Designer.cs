namespace GUI
{
    partial class UC_DangNhap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.mtxtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.mtxtMK = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(68, 318);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(341, 56);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.AnimateReadOnly = false;
            this.mtxtEmail.BackColor = System.Drawing.Color.White;
            this.mtxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtxtEmail.Depth = 0;
            this.mtxtEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtxtEmail.ForeColor = System.Drawing.Color.Black;
            this.mtxtEmail.LeadingIcon = null;
            this.mtxtEmail.Location = new System.Drawing.Point(68, 111);
            this.mtxtEmail.MaxLength = 50;
            this.mtxtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.mtxtEmail.Multiline = false;
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(341, 50);
            this.mtxtEmail.TabIndex = 7;
            this.mtxtEmail.Text = "";
            this.mtxtEmail.TrailingIcon = null;
            // 
            // mtxtMK
            // 
            this.mtxtMK.AnimateReadOnly = false;
            this.mtxtMK.BackColor = System.Drawing.Color.White;
            this.mtxtMK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtxtMK.Depth = 0;
            this.mtxtMK.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtxtMK.ForeColor = System.Drawing.Color.Black;
            this.mtxtMK.LeadingIcon = null;
            this.mtxtMK.Location = new System.Drawing.Point(68, 213);
            this.mtxtMK.MaxLength = 50;
            this.mtxtMK.MouseState = MaterialSkin.MouseState.OUT;
            this.mtxtMK.Multiline = false;
            this.mtxtMK.Name = "mtxtMK";
            this.mtxtMK.Size = new System.Drawing.Size(341, 50);
            this.mtxtMK.TabIndex = 8;
            this.mtxtMK.Text = "";
            this.mtxtMK.TrailingIcon = null;
            // 
            // UC_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.mtxtMK);
            this.Controls.Add(this.mtxtEmail);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UC_DangNhap";
            this.Size = new System.Drawing.Size(482, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnDangNhap;
        private MaterialSkin.Controls.MaterialTextBox mtxtEmail;
        private MaterialSkin.Controls.MaterialTextBox mtxtMK;
    }
}
