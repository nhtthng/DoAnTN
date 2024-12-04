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
            label7 = new Label();
            DTPNgayLap = new DateTimePicker();
            btnReset = new Button();
            txtBoxMaCTSDDV = new TextBox();
            btnInChiDinh = new Button();
            cboMaLSKB = new ComboBox();
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
            label2.Size = new Size(90, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã CTSDDV";
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
            btnThem.Location = new Point(23, 319);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(209, 319);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(415, 319);
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
            label6.Size = new Size(67, 20);
            label6.TabIndex = 12;
            label6.Text = "Mã LSKB";
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
            // btnReset
            // 
            btnReset.Location = new Point(602, 319);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 16;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtBoxMaCTSDDV
            // 
            txtBoxMaCTSDDV.Location = new Point(108, 86);
            txtBoxMaCTSDDV.Name = "txtBoxMaCTSDDV";
            txtBoxMaCTSDDV.Size = new Size(150, 27);
            txtBoxMaCTSDDV.TabIndex = 22;
            // 
            // btnInChiDinh
            // 
            btnInChiDinh.Location = new Point(787, 319);
            btnInChiDinh.Name = "btnInChiDinh";
            btnInChiDinh.Size = new Size(94, 29);
            btnInChiDinh.TabIndex = 24;
            btnInChiDinh.Text = "In";
            btnInChiDinh.UseVisualStyleBackColor = true;
            btnInChiDinh.Click += btnInChiDinh_Click;
            // 
            // cboMaLSKB
            // 
            cboMaLSKB.FormattingEnabled = true;
            cboMaLSKB.Location = new Point(395, 181);
            cboMaLSKB.Name = "cboMaLSKB";
            cboMaLSKB.Size = new Size(151, 28);
            cboMaLSKB.TabIndex = 25;
            // 
            // ChiTietSuDungDV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 552);
            Controls.Add(cboMaLSKB);
            Controls.Add(btnInChiDinh);
            Controls.Add(txtBoxMaCTSDDV);
            Controls.Add(btnReset);
            Controls.Add(DTPNgayLap);
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
        private Label label7;
        private DateTimePicker DTPNgayLap;
        private Button btnReset;
        private TextBox txtBoxMaCTSDDV;
        private Button btnInChiDinh;
        private ComboBox cboMaLSKB;
    }
}