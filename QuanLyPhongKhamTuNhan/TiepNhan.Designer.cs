namespace GUI
{
    partial class TiepNhan
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
            btnTim = new Button();
            label2 = new Label();
            txtBoxMaTN = new TextBox();
            label3 = new Label();
            label4 = new Label();
            DTPNgayTiepNhan = new DateTimePicker();
            label5 = new Label();
            DTPGioTiepNhan = new DateTimePicker();
            label6 = new Label();
            txtBoxTrieuChung = new TextBox();
            DGVTiepNhan = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnReset = new Button();
            cboMaBenhNhan = new ComboBox();
            label7 = new Label();
            cboPhongKham = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVTiepNhan).BeginInit();
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
            txtBoxTimKiem.Location = new Point(90, 6);
            txtBoxTimKiem.Name = "txtBoxTimKiem";
            txtBoxTimKiem.Size = new Size(735, 27);
            txtBoxTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(851, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 102);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã tiếp nhận";
            // 
            // txtBoxMaTN
            // 
            txtBoxMaTN.Location = new Point(114, 99);
            txtBoxMaTN.Name = "txtBoxMaTN";
            txtBoxMaTN.Size = new Size(252, 27);
            txtBoxMaTN.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(565, 110);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 5;
            label3.Text = "Mã bệnh nhân";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(565, 175);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 5;
            label4.Text = "Ngày tiếp nhận";
            // 
            // DTPNgayTiepNhan
            // 
            DTPNgayTiepNhan.Location = new Point(695, 170);
            DTPNgayTiepNhan.Name = "DTPNgayTiepNhan";
            DTPNgayTiepNhan.Size = new Size(250, 27);
            DTPNgayTiepNhan.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 175);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 3;
            label5.Text = "Giờ tiếp nhận";
            // 
            // DTPGioTiepNhan
            // 
            DTPGioTiepNhan.Location = new Point(116, 170);
            DTPGioTiepNhan.Name = "DTPGioTiepNhan";
            DTPGioTiepNhan.Size = new Size(250, 27);
            DTPGioTiepNhan.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 243);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 3;
            label6.Text = "Triệu chứng";
            // 
            // txtBoxTrieuChung
            // 
            txtBoxTrieuChung.Location = new Point(116, 240);
            txtBoxTrieuChung.Name = "txtBoxTrieuChung";
            txtBoxTrieuChung.Size = new Size(250, 27);
            txtBoxTrieuChung.TabIndex = 7;
            // 
            // DGVTiepNhan
            // 
            DGVTiepNhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVTiepNhan.Location = new Point(2, 350);
            DGVTiepNhan.Name = "DGVTiepNhan";
            DGVTiepNhan.RowHeadersWidth = 51;
            DGVTiepNhan.Size = new Size(963, 231);
            DGVTiepNhan.TabIndex = 8;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(68, 299);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(297, 299);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(565, 299);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(785, 299);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // cboMaBenhNhan
            // 
            cboMaBenhNhan.FormattingEnabled = true;
            cboMaBenhNhan.Location = new Point(695, 102);
            cboMaBenhNhan.Name = "cboMaBenhNhan";
            cboMaBenhNhan.Size = new Size(250, 28);
            cboMaBenhNhan.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(566, 243);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 11;
            label7.Text = "Phòng Khám";
            // 
            // cboPhongKham
            // 
            cboPhongKham.FormattingEnabled = true;
            cboPhongKham.Location = new Point(695, 240);
            cboPhongKham.Name = "cboPhongKham";
            cboPhongKham.Size = new Size(250, 28);
            cboPhongKham.TabIndex = 12;
            // 
            // TiepNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 581);
            Controls.Add(cboPhongKham);
            Controls.Add(label7);
            Controls.Add(cboMaBenhNhan);
            Controls.Add(btnReset);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(DGVTiepNhan);
            Controls.Add(txtBoxTrieuChung);
            Controls.Add(DTPGioTiepNhan);
            Controls.Add(DTPNgayTiepNhan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtBoxMaTN);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnTim);
            Controls.Add(txtBoxTimKiem);
            Controls.Add(label1);
            Name = "TiepNhan";
            Text = "TiepNhan";
            ((System.ComponentModel.ISupportInitialize)DGVTiepNhan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimKiem;
        private Button btnTim;
        private Label label2;
        private TextBox txtBoxMaTN;
        private Label label3;
        private Label label4;
        private DateTimePicker DTPNgayTiepNhan;
        private Label label5;
        private DateTimePicker DTPGioTiepNhan;
        private Label label6;
        private TextBox txtBoxTrieuChung;
        private DataGridView DGVTiepNhan;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnReset;
        private ComboBox cboMaBenhNhan;
        private Label label7;
        private ComboBox cboPhongKham;
    }
}