namespace GUI
{
    partial class ChiTietSuDungDV
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
            txtboxTimKiem = new TextBox();
            btnTim = new Button();
            label2 = new Label();
            label3 = new Label();
            cboMaDichVu = new ComboBox();
            label4 = new Label();
            numericSoLuong = new NumericUpDown();
            label5 = new Label();
            txtBoxGia = new TextBox();
            DGVCTSDDV = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            label6 = new Label();
            cboBenhNhan = new ComboBox();
            label7 = new Label();
            DTPNgayLap = new DateTimePicker();
            cboMaHD = new ComboBox();
            btnReset = new Button();
            label8 = new Label();
            txtBoxTimSDTBN = new TextBox();
            btnTimSDTBN = new Button();
            label9 = new Label();
            cboMaBacSi = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVCTSDDV).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm";
            // 
            // txtboxTimKiem
            // 
            txtboxTimKiem.Location = new Point(84, 6);
            txtboxTimKiem.Name = "txtboxTimKiem";
            txtboxTimKiem.Size = new Size(705, 27);
            txtboxTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(820, 6);
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
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã hóa đơn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(687, 89);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "Số lượng";
            // 
            // cboMaDichVu
            // 
            cboMaDichVu.FormattingEnabled = true;
            cboMaDichVu.Location = new Point(395, 86);
            cboMaDichVu.Name = "cboMaDichVu";
            cboMaDichVu.Size = new Size(151, 28);
            cboMaDichVu.TabIndex = 6;
            cboMaDichVu.SelectedIndexChanged += cboMaDichVu_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(308, 89);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 5;
            label4.Text = "Mã dịch vụ";
            // 
            // numericSoLuong
            // 
            numericSoLuong.Location = new Point(762, 87);
            numericSoLuong.Name = "numericSoLuong";
            numericSoLuong.Size = new Size(150, 27);
            numericSoLuong.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 184);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 8;
            label5.Text = "Giá";
            // 
            // txtBoxGia
            // 
            txtBoxGia.Location = new Point(107, 181);
            txtBoxGia.Name = "txtBoxGia";
            txtBoxGia.Size = new Size(151, 27);
            txtBoxGia.TabIndex = 9;
            // 
            // DGVCTSDDV
            // 
            DGVCTSDDV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCTSDDV.Location = new Point(-6, 364);
            DGVCTSDDV.Name = "DGVCTSDDV";
            DGVCTSDDV.RowHeadersWidth = 51;
            DGVCTSDDV.Size = new Size(929, 188);
            DGVCTSDDV.TabIndex = 10;
            DGVCTSDDV.CellClick += DGVCTSDDV_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(84, 319);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(330, 319);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(562, 319);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(308, 184);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 12;
            label6.Text = "Bệnh Nhân";
            // 
            // cboBenhNhan
            // 
            cboBenhNhan.FormattingEnabled = true;
            cboBenhNhan.Location = new Point(392, 181);
            cboBenhNhan.Name = "cboBenhNhan";
            cboBenhNhan.Size = new Size(151, 28);
            cboBenhNhan.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(584, 184);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 12;
            label7.Text = "Ngày Lập";
            // 
            // DTPNgayLap
            // 
            DTPNgayLap.Location = new Point(664, 181);
            DTPNgayLap.Name = "DTPNgayLap";
            DTPNgayLap.Size = new Size(250, 27);
            DTPNgayLap.TabIndex = 14;
            // 
            // cboMaHD
            // 
            cboMaHD.FormattingEnabled = true;
            cboMaHD.Location = new Point(107, 86);
            cboMaHD.Name = "cboMaHD";
            cboMaHD.Size = new Size(151, 28);
            cboMaHD.TabIndex = 15;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(786, 319);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 16;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 256);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 17;
            label8.Text = "Tìm bệnh nhân";
            // 
            // txtBoxTimSDTBN
            // 
            txtBoxTimSDTBN.Location = new Point(125, 253);
            txtBoxTimSDTBN.Name = "txtBoxTimSDTBN";
            txtBoxTimSDTBN.Size = new Size(185, 27);
            txtBoxTimSDTBN.TabIndex = 18;
            txtBoxTimSDTBN.KeyPress += txtBoxTimSDTBN_KeyPress;
            // 
            // btnTimSDTBN
            // 
            btnTimSDTBN.Location = new Point(330, 251);
            btnTimSDTBN.Name = "btnTimSDTBN";
            btnTimSDTBN.Size = new Size(94, 29);
            btnTimSDTBN.TabIndex = 19;
            btnTimSDTBN.Text = "Tìm";
            btnTimSDTBN.UseVisualStyleBackColor = true;
            btnTimSDTBN.Click += btnTimSDTBN_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(584, 256);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 20;
            label9.Text = "Mã bác sĩ";
            // 
            // cboMaBacSi
            // 
            cboMaBacSi.FormattingEnabled = true;
            cboMaBacSi.Location = new Point(664, 253);
            cboMaBacSi.Name = "cboMaBacSi";
            cboMaBacSi.Size = new Size(248, 28);
            cboMaBacSi.TabIndex = 21;
            // 
            // ChiTietSuDungDV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 552);
            Controls.Add(cboMaBacSi);
            Controls.Add(label9);
            Controls.Add(btnTimSDTBN);
            Controls.Add(txtBoxTimSDTBN);
            Controls.Add(label8);
            Controls.Add(btnReset);
            Controls.Add(cboMaHD);
            Controls.Add(DTPNgayLap);
            Controls.Add(cboBenhNhan);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(DGVCTSDDV);
            Controls.Add(txtBoxGia);
            Controls.Add(label5);
            Controls.Add(numericSoLuong);
            Controls.Add(cboMaDichVu);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnTim);
            Controls.Add(txtboxTimKiem);
            Controls.Add(label1);
            Name = "ChiTietSuDungDV";
            Text = "ChiTietSuDungDV";
            ((System.ComponentModel.ISupportInitialize)numericSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVCTSDDV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtboxTimKiem;
        private Button btnTim;
        private Label label2;
        private Label label3;
        private ComboBox cboMaDichVu;
        private Label label4;
        private NumericUpDown numericSoLuong;
        private Label label5;
        private TextBox txtBoxGia;
        private DataGridView DGVCTSDDV;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Label label6;
        private ComboBox cboBenhNhan;
        private Label label7;
        private DateTimePicker DTPNgayLap;
        private ComboBox cboMaHD;
        private Button btnReset;
        private Label label8;
        private TextBox txtBoxTimSDTBN;
        private Button btnTimSDTBN;
        private Label label9;
        private ComboBox cboMaBacSi;
    }
}