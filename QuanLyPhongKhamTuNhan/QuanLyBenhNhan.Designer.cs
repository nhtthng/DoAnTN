namespace QuanLyPhongKham
{
    partial class QuanLyBenhNhan
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
            txtBoxTimKiemBN = new TextBox();
            btnTimBN = new Button();
            DGVBN = new DataGridView();
            label2 = new Label();
            txtboxMaBenhNhan = new TextBox();
            label3 = new Label();
            txtBoxHoTenBN = new TextBox();
            label4 = new Label();
            DTPNgaySinhBN = new DateTimePicker();
            label5 = new Label();
            cboGioiTinhBN = new ComboBox();
            label6 = new Label();
            txtBoxSDTBN = new TextBox();
            label7 = new Label();
            txtBoxDiaChiBN = new TextBox();
            label8 = new Label();
            txtBoxBHYTBN = new TextBox();
            label9 = new Label();
            txtBoxEmaiBN = new TextBox();
            btnThemBN = new Button();
            btnXoaBN = new Button();
            btnSuaBN = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVBN).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 20);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm Kiếm";
            // 
            // txtBoxTimKiemBN
            // 
            txtBoxTimKiemBN.Location = new Point(189, 16);
            txtBoxTimKiemBN.Name = "txtBoxTimKiemBN";
            txtBoxTimKiemBN.Size = new Size(762, 27);
            txtBoxTimKiemBN.TabIndex = 1;
            // 
            // btnTimBN
            // 
            btnTimBN.Location = new Point(988, 14);
            btnTimBN.Name = "btnTimBN";
            btnTimBN.Size = new Size(94, 29);
            btnTimBN.TabIndex = 2;
            btnTimBN.Text = "Tìm";
            btnTimBN.UseVisualStyleBackColor = true;
            btnTimBN.Click += btnTimBN_Click;
            // 
            // DGVBN
            // 
            DGVBN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBN.Location = new Point(6, 295);
            DGVBN.Name = "DGVBN";
            DGVBN.RowHeadersWidth = 51;
            DGVBN.Size = new Size(1184, 267);
            DGVBN.TabIndex = 3;
            DGVBN.CellClick += DGVBN_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 79);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 4;
            label2.Text = "Mã Bệnh Nhân";
            // 
            // txtboxMaBenhNhan
            // 
            txtboxMaBenhNhan.Location = new Point(132, 76);
            txtboxMaBenhNhan.Name = "txtboxMaBenhNhan";
            txtboxMaBenhNhan.Size = new Size(250, 27);
            txtboxMaBenhNhan.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 126);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 6;
            label3.Text = "Họ Tên";
            // 
            // txtBoxHoTenBN
            // 
            txtBoxHoTenBN.Location = new Point(132, 126);
            txtBoxHoTenBN.Name = "txtBoxHoTenBN";
            txtBoxHoTenBN.Size = new Size(250, 27);
            txtBoxHoTenBN.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 179);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 6;
            label4.Text = "Ngày Sinh";
            // 
            // DTPNgaySinhBN
            // 
            DTPNgaySinhBN.Location = new Point(132, 174);
            DTPNgaySinhBN.Name = "DTPNgaySinhBN";
            DTPNgaySinhBN.Size = new Size(250, 27);
            DTPNgaySinhBN.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 83);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 4;
            label5.Text = "Giới Tính";
            // 
            // cboGioiTinhBN
            // 
            cboGioiTinhBN.FormattingEnabled = true;
            cboGioiTinhBN.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinhBN.Location = new Point(507, 76);
            cboGioiTinhBN.Name = "cboGioiTinhBN";
            cboGioiTinhBN.Size = new Size(226, 28);
            cboGioiTinhBN.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(434, 129);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 4;
            label6.Text = "SĐT";
            // 
            // txtBoxSDTBN
            // 
            txtBoxSDTBN.Location = new Point(507, 129);
            txtBoxSDTBN.Name = "txtBoxSDTBN";
            txtBoxSDTBN.Size = new Size(226, 27);
            txtBoxSDTBN.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(434, 179);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 4;
            label7.Text = "Địa Chỉ";
            // 
            // txtBoxDiaChiBN
            // 
            txtBoxDiaChiBN.Location = new Point(507, 172);
            txtBoxDiaChiBN.Name = "txtBoxDiaChiBN";
            txtBoxDiaChiBN.Size = new Size(226, 27);
            txtBoxDiaChiBN.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(774, 79);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 4;
            label8.Text = "BHYT";
            // 
            // txtBoxBHYTBN
            // 
            txtBoxBHYTBN.Location = new Point(856, 76);
            txtBoxBHYTBN.Name = "txtBoxBHYTBN";
            txtBoxBHYTBN.Size = new Size(226, 27);
            txtBoxBHYTBN.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(774, 136);
            label9.Name = "label9";
            label9.Size = new Size(46, 20);
            label9.TabIndex = 4;
            label9.Text = "Email";
            // 
            // txtBoxEmaiBN
            // 
            txtBoxEmaiBN.Location = new Point(856, 129);
            txtBoxEmaiBN.Name = "txtBoxEmaiBN";
            txtBoxEmaiBN.Size = new Size(226, 27);
            txtBoxEmaiBN.TabIndex = 5;
            // 
            // btnThemBN
            // 
            btnThemBN.Location = new Point(123, 244);
            btnThemBN.Name = "btnThemBN";
            btnThemBN.Size = new Size(94, 29);
            btnThemBN.TabIndex = 2;
            btnThemBN.Text = "Thêm";
            btnThemBN.UseVisualStyleBackColor = true;
            btnThemBN.Click += btnThemBN_Click;
            // 
            // btnXoaBN
            // 
            btnXoaBN.Location = new Point(559, 244);
            btnXoaBN.Name = "btnXoaBN";
            btnXoaBN.Size = new Size(94, 29);
            btnXoaBN.TabIndex = 2;
            btnXoaBN.Text = "Xóa";
            btnXoaBN.UseVisualStyleBackColor = true;
            btnXoaBN.Click += btnXoaBN_Click;
            // 
            // btnSuaBN
            // 
            btnSuaBN.Location = new Point(988, 244);
            btnSuaBN.Name = "btnSuaBN";
            btnSuaBN.Size = new Size(94, 29);
            btnSuaBN.TabIndex = 2;
            btnSuaBN.Text = "Sửa";
            btnSuaBN.UseVisualStyleBackColor = true;
            btnSuaBN.Click += btnSuaBN_Click;
            // 
            // QuanLyBenhNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 565);
            Controls.Add(cboGioiTinhBN);
            Controls.Add(DTPNgaySinhBN);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtBoxDiaChiBN);
            Controls.Add(txtBoxEmaiBN);
            Controls.Add(txtBoxBHYTBN);
            Controls.Add(txtBoxSDTBN);
            Controls.Add(txtBoxHoTenBN);
            Controls.Add(txtboxMaBenhNhan);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(DGVBN);
            Controls.Add(btnSuaBN);
            Controls.Add(btnXoaBN);
            Controls.Add(btnThemBN);
            Controls.Add(btnTimBN);
            Controls.Add(txtBoxTimKiemBN);
            Controls.Add(label1);
            Name = "QuanLyBenhNhan";
            Text = "QuanLyBenhNhan";
            Load += QuanLyBenhNhan_Load;
            ((System.ComponentModel.ISupportInitialize)DGVBN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimKiemBN;
        private Button btnTimBN;
        private DataGridView DGVBN;
        private Label label2;
        private TextBox txtboxMaBenhNhan;
        private Label label3;
        private TextBox txtBoxHoTenBN;
        private Label label4;
        private DateTimePicker DTPNgaySinhBN;
        private Label label5;
        private ComboBox cboGioiTinhBN;
        private Label label6;
        private TextBox txtBoxSDTBN;
        private Label label7;
        private TextBox txtBoxDiaChiBN;
        private Label label8;
        private TextBox txtBoxBHYTBN;
        private Label label9;
        private TextBox txtBoxEmaiBN;
        private Button btnThemBN;
        private Button btnXoaBN;
        private Button btnSuaBN;
    }
}