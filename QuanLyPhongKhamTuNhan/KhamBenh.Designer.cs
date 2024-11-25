namespace GUI
{
    partial class KhamBenh
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtBoxTimLSKB = new TextBox();
            btnTimLSKB = new Button();
            label2 = new Label();
            txtBoxLSKB = new TextBox();
            label3 = new Label();
            cboMaBacSi = new ComboBox();
            label4 = new Label();
            cboMaBenhNhan = new ComboBox();
            label5 = new Label();
            DTPNgayKham = new DateTimePicker();
            label6 = new Label();
            cboMaPK = new ComboBox();
            label7 = new Label();
            txtBoxChuanDoan = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            DGVKB = new DataGridView();
            btnXoa = new Button();
            errorProviderKB = new ErrorProvider(components);
            label8 = new Label();
            txtBoxSDTBN = new TextBox();
            btnTimSDTBN = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVKB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderKB).BeginInit();
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
            // txtBoxTimLSKB
            // 
            txtBoxTimLSKB.Location = new Point(81, 6);
            txtBoxTimLSKB.Name = "txtBoxTimLSKB";
            txtBoxTimLSKB.Size = new Size(763, 27);
            txtBoxTimLSKB.TabIndex = 1;
            // 
            // btnTimLSKB
            // 
            btnTimLSKB.Location = new Point(866, 5);
            btnTimLSKB.Name = "btnTimLSKB";
            btnTimLSKB.Size = new Size(94, 29);
            btnTimLSKB.TabIndex = 2;
            btnTimLSKB.Text = "Tìm";
            btnTimLSKB.UseVisualStyleBackColor = true;
            btnTimLSKB.Click += btnTimLSKB_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 90);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã LSKB";
            // 
            // txtBoxLSKB
            // 
            txtBoxLSKB.Location = new Point(81, 87);
            txtBoxLSKB.Name = "txtBoxLSKB";
            txtBoxLSKB.Size = new Size(125, 27);
            txtBoxLSKB.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(328, 93);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "Mã bác sĩ";
            // 
            // cboMaBacSi
            // 
            cboMaBacSi.FormattingEnabled = true;
            cboMaBacSi.Location = new Point(406, 87);
            cboMaBacSi.Name = "cboMaBacSi";
            cboMaBacSi.Size = new Size(151, 28);
            cboMaBacSi.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(686, 90);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 6;
            label4.Text = "Mã bệnh nhân";
            // 
            // cboMaBenhNhan
            // 
            cboMaBenhNhan.FormattingEnabled = true;
            cboMaBenhNhan.Location = new Point(809, 87);
            cboMaBenhNhan.Name = "cboMaBenhNhan";
            cboMaBenhNhan.Size = new Size(151, 28);
            cboMaBenhNhan.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 158);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 3;
            label5.Text = "Ngày khám";
            // 
            // DTPNgayKham
            // 
            DTPNgayKham.Location = new Point(129, 153);
            DTPNgayKham.Name = "DTPNgayKham";
            DTPNgayKham.Size = new Size(250, 27);
            DTPNgayKham.TabIndex = 8;
            DTPNgayKham.ValueChanged += DTPNgayKham_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(686, 153);
            label6.Name = "label6";
            label6.Size = new Size(117, 20);
            label6.TabIndex = 3;
            label6.Text = "Mã phòng khám";
            // 
            // cboMaPK
            // 
            cboMaPK.FormattingEnabled = true;
            cboMaPK.Location = new Point(809, 150);
            cboMaPK.Name = "cboMaPK";
            cboMaPK.Size = new Size(151, 28);
            cboMaPK.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 288);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 3;
            label7.Text = "Chuẩn đoán";
            // 
            // txtBoxChuanDoan
            // 
            txtBoxChuanDoan.Location = new Point(106, 285);
            txtBoxChuanDoan.Name = "txtBoxChuanDoan";
            txtBoxChuanDoan.Size = new Size(854, 27);
            txtBoxChuanDoan.TabIndex = 10;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(106, 338);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(577, 338);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // DGVKB
            // 
            DGVKB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVKB.Location = new Point(3, 382);
            DGVKB.Name = "DGVKB";
            DGVKB.RowHeadersWidth = 51;
            DGVKB.Size = new Size(972, 211);
            DGVKB.TabIndex = 12;
            DGVKB.CellClick += DGVKB_CellClick;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(339, 338);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // errorProviderKB
            // 
            errorProviderKB.ContainerControl = this;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 220);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 14;
            label8.Text = "SDT Bệnh Nhân";
            // 
            // txtBoxSDTBN
            // 
            txtBoxSDTBN.Location = new Point(129, 217);
            txtBoxSDTBN.Name = "txtBoxSDTBN";
            txtBoxSDTBN.Size = new Size(250, 27);
            txtBoxSDTBN.TabIndex = 15;
            // 
            // btnTimSDTBN
            // 
            btnTimSDTBN.Location = new Point(406, 216);
            btnTimSDTBN.Name = "btnTimSDTBN";
            btnTimSDTBN.Size = new Size(94, 29);
            btnTimSDTBN.TabIndex = 16;
            btnTimSDTBN.Text = "Tìm";
            btnTimSDTBN.UseVisualStyleBackColor = true;
            btnTimSDTBN.Click += btnTimSDTBN_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(794, 338);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // KhamBenh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 592);
            Controls.Add(btnReset);
            Controls.Add(btnTimSDTBN);
            Controls.Add(txtBoxSDTBN);
            Controls.Add(label8);
            Controls.Add(btnXoa);
            Controls.Add(DGVKB);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtBoxChuanDoan);
            Controls.Add(cboMaPK);
            Controls.Add(DTPNgayKham);
            Controls.Add(cboMaBenhNhan);
            Controls.Add(label4);
            Controls.Add(cboMaBacSi);
            Controls.Add(txtBoxLSKB);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(btnTimLSKB);
            Controls.Add(txtBoxTimLSKB);
            Controls.Add(label1);
            Name = "KhamBenh";
            Text = "KhamBenh";
            ((System.ComponentModel.ISupportInitialize)DGVKB).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderKB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimLSKB;
        private Button btnTimLSKB;
        private Label label2;
        private TextBox txtBoxLSKB;
        private Label label3;
        private ComboBox cboMaBacSi;
        private Label label4;
        private ComboBox cboMaBenhNhan;
        private Label label5;
        private DateTimePicker DTPNgayKham;
        private Label label6;
        private ComboBox cboMaPK;
        private Label label7;
        private TextBox txtBoxChuanDoan;
        private Button btnThem;
        private Button btnSua;
        private DataGridView DGVKB;
        private Button btnXoa;
        private ErrorProvider errorProviderKB;
        private Button btnTimSDTBN;
        private TextBox txtBoxSDTBN;
        private Label label8;
        private Button btnReset;
    }
}