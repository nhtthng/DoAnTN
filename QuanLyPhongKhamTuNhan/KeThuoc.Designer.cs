namespace GUI
{
    partial class KeThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeThuoc));
            panelDSBenhNhan = new Panel();
            label14 = new Label();
            dateTimeNgayKham = new DateTimePicker();
            dataGridViewDSBenhNhan = new DataGridView();
            label1 = new Label();
            panelKeThuoc = new Panel();
            txtMaTT = new TextBox();
            dateTimeNgayKee = new DateTimePicker();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            txtTenBenhNhan = new TextBox();
            txtLieuLuong = new TextBox();
            txtBietDuoc = new TextBox();
            txtLoiDan = new TextBox();
            txtCachDung = new TextBox();
            txtMaThuoc = new TextBox();
            txtTenThuoc = new TextBox();
            txtMaBS = new TextBox();
            txtMaBenhNhan = new TextBox();
            dataGridViewDSToaThuoc = new DataGridView();
            label4 = new Label();
            label8 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label12 = new Label();
            label11 = new Label();
            label13 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnInToaThuoc = new Button();
            panelDSBenhNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDSBenhNhan).BeginInit();
            panelKeThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDSToaThuoc).BeginInit();
            SuspendLayout();
            // 
            // panelDSBenhNhan
            // 
            panelDSBenhNhan.BorderStyle = BorderStyle.FixedSingle;
            panelDSBenhNhan.Controls.Add(label14);
            panelDSBenhNhan.Controls.Add(dateTimeNgayKham);
            panelDSBenhNhan.Controls.Add(dataGridViewDSBenhNhan);
            panelDSBenhNhan.Location = new Point(12, 33);
            panelDSBenhNhan.Name = "panelDSBenhNhan";
            panelDSBenhNhan.Size = new Size(440, 485);
            panelDSBenhNhan.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(69, 39);
            label14.Name = "label14";
            label14.Size = new Size(84, 20);
            label14.TabIndex = 2;
            label14.Text = "Ngày khám";
            // 
            // dateTimeNgayKham
            // 
            dateTimeNgayKham.Location = new Point(174, 34);
            dateTimeNgayKham.Name = "dateTimeNgayKham";
            dateTimeNgayKham.Size = new Size(250, 27);
            dateTimeNgayKham.TabIndex = 1;
            dateTimeNgayKham.ValueChanged += dateTimeNgayKham_ValueChanged;
            // 
            // dataGridViewDSBenhNhan
            // 
            dataGridViewDSBenhNhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDSBenhNhan.Location = new Point(12, 78);
            dataGridViewDSBenhNhan.Name = "dataGridViewDSBenhNhan";
            dataGridViewDSBenhNhan.RowHeadersWidth = 51;
            dataGridViewDSBenhNhan.Size = new Size(412, 391);
            dataGridViewDSBenhNhan.TabIndex = 0;
            dataGridViewDSBenhNhan.CellClick += dataGridViewDSBenhNhan_CellClick;
            dataGridViewDSBenhNhan.CellContentClick += dataGridViewDSBenhNhan_CellContentClick;
            dataGridViewDSBenhNhan.SelectionChanged += dataGridViewDSBenhNhan_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(25, 18);
            label1.Name = "label1";
            label1.Size = new Size(355, 31);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Bệnh Nhân Đã Khám";
            // 
            // panelKeThuoc
            // 
            panelKeThuoc.BorderStyle = BorderStyle.FixedSingle;
            panelKeThuoc.Controls.Add(btnInToaThuoc);
            panelKeThuoc.Controls.Add(txtMaTT);
            panelKeThuoc.Controls.Add(dateTimeNgayKee);
            panelKeThuoc.Controls.Add(btnXoa);
            panelKeThuoc.Controls.Add(btnSua);
            panelKeThuoc.Controls.Add(btnLuu);
            panelKeThuoc.Controls.Add(txtTenBenhNhan);
            panelKeThuoc.Controls.Add(txtLieuLuong);
            panelKeThuoc.Controls.Add(txtBietDuoc);
            panelKeThuoc.Controls.Add(txtLoiDan);
            panelKeThuoc.Controls.Add(txtCachDung);
            panelKeThuoc.Controls.Add(txtMaThuoc);
            panelKeThuoc.Controls.Add(txtTenThuoc);
            panelKeThuoc.Controls.Add(txtMaBS);
            panelKeThuoc.Controls.Add(txtMaBenhNhan);
            panelKeThuoc.Controls.Add(dataGridViewDSToaThuoc);
            panelKeThuoc.Controls.Add(label4);
            panelKeThuoc.Controls.Add(label8);
            panelKeThuoc.Controls.Add(label10);
            panelKeThuoc.Controls.Add(label9);
            panelKeThuoc.Controls.Add(label7);
            panelKeThuoc.Controls.Add(label6);
            panelKeThuoc.Controls.Add(label12);
            panelKeThuoc.Controls.Add(label11);
            panelKeThuoc.Controls.Add(label13);
            panelKeThuoc.Controls.Add(label5);
            panelKeThuoc.Controls.Add(label3);
            panelKeThuoc.Location = new Point(478, 33);
            panelKeThuoc.Name = "panelKeThuoc";
            panelKeThuoc.Size = new Size(1085, 485);
            panelKeThuoc.TabIndex = 1;
            // 
            // txtMaTT
            // 
            txtMaTT.Location = new Point(67, 78);
            txtMaTT.Name = "txtMaTT";
            txtMaTT.Size = new Size(65, 27);
            txtMaTT.TabIndex = 5;
            // 
            // dateTimeNgayKee
            // 
            dateTimeNgayKee.Location = new Point(776, 131);
            dateTimeNgayKee.Name = "dateTimeNgayKee";
            dateTimeNgayKee.Size = new Size(277, 27);
            dateTimeNgayKee.TabIndex = 4;
            dateTimeNgayKee.ValueChanged += dateTimeNgayKee_ValueChanged;
            // 
            // btnXoa
            // 
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(569, 424);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(106, 45);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "    Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(402, 424);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(106, 45);
            btnSua.TabIndex = 3;
            btnSua.Text = "     Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(224, 424);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(106, 45);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "    Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtTenBenhNhan
            // 
            txtTenBenhNhan.Location = new Point(637, 31);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.ReadOnly = true;
            txtTenBenhNhan.Size = new Size(416, 27);
            txtTenBenhNhan.TabIndex = 2;
            txtTenBenhNhan.TextChanged += txtTenBenhNhan_TextChanged;
            // 
            // txtLieuLuong
            // 
            txtLieuLuong.Location = new Point(910, 78);
            txtLieuLuong.Name = "txtLieuLuong";
            txtLieuLuong.Size = new Size(143, 27);
            txtLieuLuong.TabIndex = 2;
            txtLieuLuong.TextChanged += txtLieuLuong_TextChanged;
            // 
            // txtBietDuoc
            // 
            txtBietDuoc.Location = new Point(669, 78);
            txtBietDuoc.Name = "txtBietDuoc";
            txtBietDuoc.Size = new Size(147, 27);
            txtBietDuoc.TabIndex = 2;
            txtBietDuoc.TextChanged += txtBietDuoc_TextChanged;
            // 
            // txtLoiDan
            // 
            txtLoiDan.Location = new Point(412, 135);
            txtLoiDan.Name = "txtLoiDan";
            txtLoiDan.Size = new Size(283, 27);
            txtLoiDan.TabIndex = 2;
            txtLoiDan.TextChanged += txtLoiDan_TextChanged;
            // 
            // txtCachDung
            // 
            txtCachDung.Location = new Point(106, 135);
            txtCachDung.Name = "txtCachDung";
            txtCachDung.Size = new Size(219, 27);
            txtCachDung.TabIndex = 2;
            txtCachDung.TextChanged += txtCachDung_TextChanged;
            // 
            // txtMaThuoc
            // 
            txtMaThuoc.Location = new Point(225, 78);
            txtMaThuoc.Name = "txtMaThuoc";
            txtMaThuoc.Size = new Size(100, 27);
            txtMaThuoc.TabIndex = 2;
            txtMaThuoc.TextChanged += txtTenThuoc_TextChanged;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(418, 78);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.Size = new Size(159, 27);
            txtTenThuoc.TabIndex = 2;
            txtTenThuoc.TextChanged += txtTenThuoc_TextChanged;
            // 
            // txtMaBS
            // 
            txtMaBS.Location = new Point(90, 31);
            txtMaBS.Name = "txtMaBS";
            txtMaBS.ReadOnly = true;
            txtMaBS.Size = new Size(150, 27);
            txtMaBS.TabIndex = 2;
            txtMaBS.TextChanged += txtMaBenhNhan_TextChanged;
            // 
            // txtMaBenhNhan
            // 
            txtMaBenhNhan.Location = new Point(387, 31);
            txtMaBenhNhan.Name = "txtMaBenhNhan";
            txtMaBenhNhan.ReadOnly = true;
            txtMaBenhNhan.Size = new Size(124, 27);
            txtMaBenhNhan.TabIndex = 2;
            txtMaBenhNhan.TextChanged += txtMaBenhNhan_TextChanged;
            // 
            // dataGridViewDSToaThuoc
            // 
            dataGridViewDSToaThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDSToaThuoc.Location = new Point(19, 180);
            dataGridViewDSToaThuoc.Name = "dataGridViewDSToaThuoc";
            dataGridViewDSToaThuoc.RowHeadersWidth = 51;
            dataGridViewDSToaThuoc.Size = new Size(1034, 227);
            dataGridViewDSToaThuoc.TabIndex = 1;
            dataGridViewDSToaThuoc.CellClick += dataGridViewDSToaThuoc_CellClick;
            dataGridViewDSToaThuoc.CellContentClick += dataGridViewDSToaThuoc_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(523, 34);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 0;
            label4.Text = "Tên Bệnh Nhân";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(822, 81);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 0;
            label8.Text = "Liều Lượng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(701, 136);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 0;
            label10.Text = "Ngày Kê ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(346, 138);
            label9.Name = "label9";
            label9.Size = new Size(60, 20);
            label9.TabIndex = 0;
            label9.Text = "Lời Dặn";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 138);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 0;
            label7.Text = "Cách Dùng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(583, 81);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 0;
            label6.Text = "Biệt Dược";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(10, 81);
            label12.Name = "label12";
            label12.Size = new Size(58, 20);
            label12.TabIndex = 0;
            label12.Text = "Mã Toa";
            label12.Click += label11_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 34);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 0;
            label11.Text = "Mã Bác Sĩ";
            label11.Click += label11_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(145, 81);
            label13.Name = "label13";
            label13.Size = new Size(74, 20);
            label13.TabIndex = 0;
            label13.Text = "Mã Thuốc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(331, 81);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 0;
            label5.Text = "Tên Thuốc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(275, 34);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 0;
            label3.Text = "Mã Bệnh Nhân";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(498, 18);
            label2.Name = "label2";
            label2.Size = new Size(113, 31);
            label2.TabIndex = 0;
            label2.Text = "Kê Thuốc";
            // 
            // btnInToaThuoc
            // 
            btnInToaThuoc.Image = (Image)resources.GetObject("btnInToaThuoc.Image");
            btnInToaThuoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnInToaThuoc.Location = new Point(745, 424);
            btnInToaThuoc.Name = "btnInToaThuoc";
            btnInToaThuoc.Size = new Size(106, 45);
            btnInToaThuoc.TabIndex = 6;
            btnInToaThuoc.Text = "       In Toa";
            btnInToaThuoc.UseVisualStyleBackColor = true;
            btnInToaThuoc.Click += btnInToaThuoc_Click;
            // 
            // KeThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1575, 532);
            Controls.Add(label2);
            Controls.Add(panelKeThuoc);
            Controls.Add(label1);
            Controls.Add(panelDSBenhNhan);
            Name = "KeThuoc";
            Text = "KeThuoc";
            Load += KeThuoc_Load;
            panelDSBenhNhan.ResumeLayout(false);
            panelDSBenhNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDSBenhNhan).EndInit();
            panelKeThuoc.ResumeLayout(false);
            panelKeThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDSToaThuoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDSBenhNhan;
        private DataGridView dataGridViewDSBenhNhan;
        private Label label1;
        private Panel panelKeThuoc;
        private Label label2;
        private DataGridView dataGridViewDSToaThuoc;
        private Label label4;
        private Label label8;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Button btnSua;
        private Button btnLuu;
        private TextBox txtTenBenhNhan;
        private TextBox txtLieuLuong;
        private TextBox txtBietDuoc;
        private TextBox txtLoiDan;
        private TextBox txtCachDung;
        private TextBox txtTenThuoc;
        private TextBox txtMaBenhNhan;
        private Button btnXoa;
        private Label label10;
        private DateTimePicker dateTimeNgayKee;
        private TextBox txtMaBS;
        private Label label11;
        private TextBox txtMaTT;
        private Label label12;
        private TextBox txtMaThuoc;
        private Label label13;
        private Label label14;
        private DateTimePicker dateTimeNgayKham;
        private Button btnInToaThuoc;
    }
}