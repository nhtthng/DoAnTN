namespace GUI
{
    partial class HoaDon
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
            txtBoxTim = new TextBox();
            btnTim = new Button();
            label2 = new Label();
            DTPNgayLap = new DateTimePicker();
            label3 = new Label();
            cboNhanVien = new ComboBox();
            label4 = new Label();
            cboBenhNhan = new ComboBox();
            label5 = new Label();
            cboGiamGia = new ComboBox();
            DGVHD = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnCapNhat = new Button();
            btnReset = new Button();
            label6 = new Label();
            txtBoxMaHoaDon = new TextBox();
            label7 = new Label();
            txtBoxMaLSKB = new TextBox();
            label8 = new Label();
            cboPTTT = new ComboBox();
            btnInHoaDon = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVHD).BeginInit();
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
            // txtBoxTim
            // 
            txtBoxTim.Location = new Point(90, 6);
            txtBoxTim.Name = "txtBoxTim";
            txtBoxTim.Size = new Size(784, 27);
            txtBoxTim.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(892, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 107);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Ngày Lập";
            // 
            // DTPNgayLap
            // 
            DTPNgayLap.Location = new Point(90, 102);
            DTPNgayLap.Name = "DTPNgayLap";
            DTPNgayLap.Size = new Size(250, 27);
            DTPNgayLap.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(423, 107);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 3;
            label3.Text = "Mã nhân viên";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(531, 104);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(151, 28);
            cboNhanVien.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(735, 107);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 3;
            label4.Text = "Mã bệnh nhân";
            // 
            // cboBenhNhan
            // 
            cboBenhNhan.FormattingEnabled = true;
            cboBenhNhan.Location = new Point(844, 104);
            cboBenhNhan.Name = "cboBenhNhan";
            cboBenhNhan.Size = new Size(151, 28);
            cboBenhNhan.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 197);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 6;
            label5.Text = "Giảm giá";
            // 
            // cboGiamGia
            // 
            cboGiamGia.FormattingEnabled = true;
            cboGiamGia.Location = new Point(90, 194);
            cboGiamGia.Name = "cboGiamGia";
            cboGiamGia.Size = new Size(250, 28);
            cboGiamGia.TabIndex = 7;
            // 
            // DGVHD
            // 
            DGVHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVHD.Location = new Point(3, 374);
            DGVHD.Name = "DGVHD";
            DGVHD.RowHeadersWidth = 51;
            DGVHD.Size = new Size(998, 240);
            DGVHD.TabIndex = 8;
            DGVHD.CellClick += DGVHD_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(21, 321);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(184, 321);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(508, 321);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(677, 321);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(94, 29);
            btnCapNhat.TabIndex = 9;
            btnCapNhat.Text = "Cập Nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(869, 321);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(423, 197);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 6;
            label6.Text = "Mã hóa đơn";
            // 
            // txtBoxMaHoaDon
            // 
            txtBoxMaHoaDon.Location = new Point(531, 194);
            txtBoxMaHoaDon.Name = "txtBoxMaHoaDon";
            txtBoxMaHoaDon.Size = new Size(151, 27);
            txtBoxMaHoaDon.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(735, 197);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 6;
            label7.Text = "Mã LSKB";
            // 
            // txtBoxMaLSKB
            // 
            txtBoxMaLSKB.Location = new Point(844, 194);
            txtBoxMaLSKB.Name = "txtBoxMaLSKB";
            txtBoxMaLSKB.Size = new Size(151, 27);
            txtBoxMaLSKB.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 264);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 16;
            label8.Text = "PTTT";
            // 
            // cboPTTT
            // 
            cboPTTT.FormattingEnabled = true;
            cboPTTT.Items.AddRange(new object[] { "Chuyển khoản", "Tiền mặt" });
            cboPTTT.Location = new Point(90, 261);
            cboPTTT.Name = "cboPTTT";
            cboPTTT.Size = new Size(250, 28);
            cboPTTT.TabIndex = 17;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Location = new Point(352, 321);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(94, 29);
            btnInHoaDon.TabIndex = 18;
            btnInHoaDon.Text = "In";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // HoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 615);
            Controls.Add(btnInHoaDon);
            Controls.Add(cboPTTT);
            Controls.Add(label8);
            Controls.Add(txtBoxMaLSKB);
            Controls.Add(txtBoxMaHoaDon);
            Controls.Add(btnReset);
            Controls.Add(btnCapNhat);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(DGVHD);
            Controls.Add(cboGiamGia);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cboBenhNhan);
            Controls.Add(cboNhanVien);
            Controls.Add(DTPNgayLap);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnTim);
            Controls.Add(txtBoxTim);
            Controls.Add(label1);
            Name = "HoaDon";
            Text = "HoaDon";
            ((System.ComponentModel.ISupportInitialize)DGVHD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTim;
        private Button btnTim;
        private Label label2;
        private DateTimePicker DTPNgayLap;
        private Label label3;
        private ComboBox cboNhanVien;
        private Label label4;
        private ComboBox cboBenhNhan;
        private Label label5;
        private ComboBox cboGiamGia;
        private DataGridView DGVHD;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnCapNhat;
        private Button btnReset;
        private Label label6;
        private TextBox txtBoxMaHoaDon;
        private Label label7;
        private TextBox txtBoxMaLSKB;
        private Label label8;
        private ComboBox cboPTTT;
        private Button btnInHoaDon;
    }
}