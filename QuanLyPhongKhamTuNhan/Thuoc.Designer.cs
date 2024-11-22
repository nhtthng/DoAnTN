namespace GUI
{
    partial class Thuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Thuoc));
            panel1 = new Panel();
            btnXoa = new Button();
            btnTim = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtLuuY = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            txtDVT = new TextBox();
            txtBietDuoc = new TextBox();
            txtCongDung = new TextBox();
            txtTenThuoc = new TextBox();
            txtMaThuoc = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label9 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridViewThuoc = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThuoc).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnTim);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(txtLuuY);
            panel1.Controls.Add(txtDonGia);
            panel1.Controls.Add(txtSoLuong);
            panel1.Controls.Add(txtDVT);
            panel1.Controls.Add(txtBietDuoc);
            panel1.Controls.Add(txtCongDung);
            panel1.Controls.Add(txtTenThuoc);
            panel1.Controls.Add(txtMaThuoc);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(17, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(929, 220);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnXoa
            // 
            btnXoa.FlatAppearance.CheckedBackColor = Color.Black;
            btnXoa.FlatAppearance.MouseDownBackColor = Color.Cyan;
            btnXoa.FlatAppearance.MouseOverBackColor = Color.Black;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(633, 163);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 40);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "    Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTim
            // 
            btnTim.FlatAppearance.CheckedBackColor = Color.Black;
            btnTim.FlatAppearance.MouseDownBackColor = Color.Cyan;
            btnTim.FlatAppearance.MouseOverBackColor = Color.Black;
            btnTim.Image = (Image)resources.GetObject("btnTim.Image");
            btnTim.ImageAlign = ContentAlignment.MiddleLeft;
            btnTim.Location = new Point(476, 163);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(114, 40);
            btnTim.TabIndex = 6;
            btnTim.Text = "   Tìm ";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnSua
            // 
            btnSua.FlatAppearance.CheckedBackColor = Color.Black;
            btnSua.FlatAppearance.MouseDownBackColor = Color.Cyan;
            btnSua.FlatAppearance.MouseOverBackColor = Color.Black;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(311, 163);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "    Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.FlatAppearance.CheckedBackColor = Color.Black;
            btnThem.FlatAppearance.MouseDownBackColor = Color.Cyan;
            btnThem.FlatAppearance.MouseOverBackColor = Color.Black;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(145, 163);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 40);
            btnThem.TabIndex = 6;
            btnThem.Text = "     Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtLuuY
            // 
            txtLuuY.Location = new Point(476, 58);
            txtLuuY.Name = "txtLuuY";
            txtLuuY.Size = new Size(434, 27);
            txtLuuY.TabIndex = 5;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(609, 104);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(301, 27);
            txtDonGia.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(323, 104);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(197, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(59, 104);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(170, 27);
            txtDVT.TabIndex = 4;
            // 
            // txtBietDuoc
            // 
            txtBietDuoc.Location = new Point(673, 11);
            txtBietDuoc.Name = "txtBietDuoc";
            txtBietDuoc.Size = new Size(237, 27);
            txtBietDuoc.TabIndex = 3;
            // 
            // txtCongDung
            // 
            txtCongDung.Location = new Point(106, 58);
            txtCongDung.Name = "txtCongDung";
            txtCongDung.Size = new Size(299, 27);
            txtCongDung.TabIndex = 3;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(335, 11);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.Size = new Size(231, 27);
            txtTenThuoc.TabIndex = 3;
            // 
            // txtMaThuoc
            // 
            txtMaThuoc.Location = new Point(94, 11);
            txtMaThuoc.Name = "txtMaThuoc";
            txtMaThuoc.Size = new Size(135, 27);
            txtMaThuoc.TabIndex = 3;
            txtMaThuoc.TextChanged += txtMaThuoc_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(540, 111);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 2;
            label8.Text = "Đơn Giá";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(245, 111);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 2;
            label7.Text = "Số Lượng";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(425, 61);
            label9.Name = "label9";
            label9.Size = new Size(45, 20);
            label9.TabIndex = 2;
            label9.Text = "Lưu Ý";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 107);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 2;
            label6.Text = "ĐVT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 61);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 1;
            label5.Text = "Công Dụng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(594, 14);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 1;
            label4.Text = "Biệt Dược";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 18);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên Thuốc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 18);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Thuốc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(34, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 31);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Thuốc";
            // 
            // dataGridViewThuoc
            // 
            dataGridViewThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewThuoc.Location = new Point(18, 258);
            dataGridViewThuoc.Name = "dataGridViewThuoc";
            dataGridViewThuoc.RowHeadersWidth = 51;
            dataGridViewThuoc.Size = new Size(929, 249);
            dataGridViewThuoc.TabIndex = 1;
            dataGridViewThuoc.CellClick += dataGridViewThuoc_CellClick;
            dataGridViewThuoc.CellContentClick += dataGridViewThuoc_CellContentClick;
            // 
            // Thuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 519);
            Controls.Add(dataGridViewThuoc);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Thuoc";
            Text = "Thuoc";
            Load += Thuoc_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThuoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtDonGia;
        private TextBox txtSoLuong;
        private TextBox txtDVT;
        private TextBox txtBietDuoc;
        private TextBox txtCongDung;
        private TextBox txtTenThuoc;
        private TextBox txtMaThuoc;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label6;
        private TextBox txtLuuY;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dataGridViewThuoc;
        private Button btnTim;
    }
}