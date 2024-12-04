namespace Ql_DATN
{
    partial class Frm_DangNhap
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
            this.uC_DangNhap1 = new GUI.UC_DangNhap();
            this.SuspendLayout();
            // 
            // uC_DangNhap1
            // 
            this.uC_DangNhap1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uC_DangNhap1.Location = new System.Drawing.Point(2, 1);
            this.uC_DangNhap1.Name = "uC_DangNhap1";
            this.uC_DangNhap1.Size = new System.Drawing.Size(482, 437);
            this.uC_DangNhap1.TabIndex = 0;
            // 
            // Frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 439);
            this.Controls.Add(this.uC_DangNhap1);
            this.Name = "Frm_DangNhap";
            this.Text = "Frm_DangNhap";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.UC_DangNhap uC_DangNhap1;
    }
}