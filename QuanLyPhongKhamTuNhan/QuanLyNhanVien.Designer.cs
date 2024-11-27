namespace GUI
{
    partial class QuanLyNhanVien
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
            label1 = new Label();
            txtBoxTimKiem = new TextBox();
            btnTimKiem = new Button();
            label2 = new Label();
            txtBoxMaNV = new TextBox();
            label3 = new Label();
            txtBoxHoTen = new TextBox();
            label4 = new Label();
            cboGioiTinh = new ComboBox();
            label5 = new Label();
            DTPNgaySinh = new DateTimePicker();
            label6 = new Label();
            txtBoxSDT = new TextBox();
            label7 = new Label();
            cboMaPhongBan = new ComboBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnReset = new Button();
            DGVQuanLyNV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGVQuanLyNV).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm Kiếm";
            // 
            // txtBoxTimKiem
            // 
            txtBoxTimKiem.Location = new Point(94, 6);
            txtBoxTimKiem.Name = "txtBoxTimKiem";
            txtBoxTimKiem.Size = new Size(740, 27);
            txtBoxTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(859, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 106);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã Nhân Viên";
            // 
            // txtBoxMaNV
            // 
            txtBoxMaNV.Location = new Point(120, 103);
            txtBoxMaNV.Name = "txtBoxMaNV";
            txtBoxMaNV.Size = new Size(174, 27);
            txtBoxMaNV.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 102);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 5;
            label3.Text = "Họ Tên";
            // 
            // txtBoxHoTen
            // 
            txtBoxHoTen.Location = new Point(464, 99);
            txtBoxHoTen.Name = "txtBoxHoTen";
            txtBoxHoTen.Size = new Size(203, 27);
            txtBoxHoTen.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(724, 106);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 5;
            label4.Text = "Giới Tính";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.Location = new Point(823, 99);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(151, 28);
            cboGioiTinh.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 194);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 7;
            label5.Text = "Ngày Sinh";
            // 
            // DTPNgaySinh
            // 
            DTPNgaySinh.Location = new Point(94, 189);
            DTPNgaySinh.Name = "DTPNgaySinh";
            DTPNgaySinh.Size = new Size(250, 27);
            DTPNgaySinh.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(408, 194);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 7;
            label6.Text = "SDT";
            // 
            // txtBoxSDT
            // 
            txtBoxSDT.Location = new Point(464, 191);
            txtBoxSDT.Name = "txtBoxSDT";
            txtBoxSDT.Size = new Size(203, 27);
            txtBoxSDT.TabIndex = 9;
            txtBoxSDT.KeyPress += txtBoxSDT_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(712, 191);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 5;
            label7.Text = "Mã Phòng Ban";
            // 
            // cboMaPhongBan
            // 
            cboMaPhongBan.FormattingEnabled = true;
            cboMaPhongBan.Location = new Point(823, 186);
            cboMaPhongBan.Name = "cboMaPhongBan";
            cboMaPhongBan.Size = new Size(151, 28);
            cboMaPhongBan.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(38, 275);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(286, 275);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(584, 275);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(837, 275);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 10;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // DGVQuanLyNV
            // 
            DGVQuanLyNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVQuanLyNV.Location = new Point(2, 327);
            DGVQuanLyNV.Name = "DGVQuanLyNV";
            DGVQuanLyNV.RowHeadersWidth = 51;
            DGVQuanLyNV.Size = new Size(982, 232);
            DGVQuanLyNV.TabIndex = 11;
            // 
            // QuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 562);
            Controls.Add(DGVQuanLyNV);
            Controls.Add(btnReset);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(txtBoxSDT);
            Controls.Add(DTPNgaySinh);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cboMaPhongBan);
            Controls.Add(cboGioiTinh);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtBoxHoTen);
            Controls.Add(txtBoxMaNV);
            Controls.Add(label2);
            Controls.Add(btnTimKiem);
            Controls.Add(txtBoxTimKiem);
            Controls.Add(label1);
            Name = "QuanLyNhanVien";
            Text = "QuanLyNhanVien";
            ((System.ComponentModel.ISupportInitialize)DGVQuanLyNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimKiem;
        private Button btnTimKiem;
        private Label label2;
        private TextBox txtBoxMaNV;
        private Label label3;
        private TextBox txtBoxHoTen;
        private Label label4;
        private ComboBox cboGioiTinh;
        private Label label5;
        private DateTimePicker DTPNgaySinh;
        private Label label6;
        private TextBox txtBoxSDT;
        private Label label7;
        private ComboBox cboMaPhongBan;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnReset;
        private DataGridView DGVQuanLyNV;
    }
}