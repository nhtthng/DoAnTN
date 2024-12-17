namespace GUI
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTaiKhoan = new TextBox();
            txtMauKhau = new TextBox();
            btnDangNhap = new Button();
            cboLoaiTaiKhoan = new ComboBox();
            btnQuenMK = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(12, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(204, 171);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(351, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 38);
            label1.TabIndex = 1;
            label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 86);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Tài Khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(236, 157);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(328, 79);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(237, 27);
            txtTaiKhoan.TabIndex = 3;
            // 
            // txtMauKhau
            // 
            txtMauKhau.Location = new Point(328, 150);
            txtMauKhau.Name = "txtMauKhau";
            txtMauKhau.Size = new Size(237, 27);
            txtMauKhau.TabIndex = 3;
            txtMauKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            btnDangNhap.FlatAppearance.MouseDownBackColor = Color.Cyan;
            btnDangNhap.FlatAppearance.MouseOverBackColor = Color.Black;
            btnDangNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.Image = (Image)resources.GetObject("btnDangNhap.Image");
            btnDangNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnDangNhap.Location = new Point(422, 274);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(143, 46);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "       Đăng Nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // cboLoaiTaiKhoan
            // 
            cboLoaiTaiKhoan.FormattingEnabled = true;
            cboLoaiTaiKhoan.Location = new Point(236, 208);
            cboLoaiTaiKhoan.Name = "cboLoaiTaiKhoan";
            cboLoaiTaiKhoan.Size = new Size(151, 28);
            cboLoaiTaiKhoan.TabIndex = 5;
            // 
            // btnQuenMK
            // 
            btnQuenMK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuenMK.Image = (Image)resources.GetObject("btnQuenMK.Image");
            btnQuenMK.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuenMK.Location = new Point(26, 274);
            btnQuenMK.Name = "btnQuenMK";
            btnQuenMK.Size = new Size(160, 46);
            btnQuenMK.TabIndex = 6;
            btnQuenMK.Text = "Quên mật khẩu";
            btnQuenMK.TextAlign = ContentAlignment.MiddleRight;
            btnQuenMK.UseVisualStyleBackColor = true;
            btnQuenMK.Click += btnQuenMK_Click;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 345);
            Controls.Add(btnQuenMK);
            Controls.Add(cboLoaiTaiKhoan);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMauKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "DangNhap";
            Text = "DangNhap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTaiKhoan;
        private TextBox txtMauKhau;
        private Button btnDangNhap;
        private ComboBox cboLoaiTaiKhoan;
        private Button btnQuenMK;
    }
}