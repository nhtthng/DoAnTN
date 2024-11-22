namespace GUI
{
    partial class QuanLyLichHen
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
            txtBoxTimMaLH = new TextBox();
            btnTimLH = new Button();
            label2 = new Label();
            txtBoxMaLH = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            DTPThoiGianHen = new DateTimePicker();
            label6 = new Label();
            DTPNgayHen = new DateTimePicker();
            label7 = new Label();
            txtBoxTinhTrang = new TextBox();
            cboMaBS = new ComboBox();
            cboMaBN = new ComboBox();
            DGVLichHen = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            errorProviderLH = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DGVLichHen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLH).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã lịch hẹn";
            // 
            // txtBoxTimMaLH
            // 
            txtBoxTimMaLH.Location = new Point(103, 5);
            txtBoxTimMaLH.Name = "txtBoxTimMaLH";
            txtBoxTimMaLH.Size = new Size(731, 27);
            txtBoxTimMaLH.TabIndex = 1;
            // 
            // btnTimLH
            // 
            btnTimLH.Location = new Point(859, 5);
            btnTimLH.Name = "btnTimLH";
            btnTimLH.Size = new Size(94, 29);
            btnTimLH.TabIndex = 2;
            btnTimLH.Text = "Tìm";
            btnTimLH.UseVisualStyleBackColor = true;
            btnTimLH.Click += btnTimLH_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã lịch hẹn";
            // 
            // txtBoxMaLH
            // 
            txtBoxMaLH.Location = new Point(103, 80);
            txtBoxMaLH.Name = "txtBoxMaLH";
            txtBoxMaLH.Size = new Size(125, 27);
            txtBoxMaLH.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 83);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 3;
            label3.Text = "Bác sĩ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(670, 83);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 3;
            label4.Text = "Bệnh nhân";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 181);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 3;
            label5.Text = "Thời gian hẹn";
            // 
            // DTPThoiGianHen
            // 
            DTPThoiGianHen.Location = new Point(117, 181);
            DTPThoiGianHen.Name = "DTPThoiGianHen";
            DTPThoiGianHen.Size = new Size(250, 27);
            DTPThoiGianHen.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(510, 181);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 3;
            label6.Text = "Ngày hẹn";
            // 
            // DTPNgayHen
            // 
            DTPNgayHen.Location = new Point(588, 176);
            DTPNgayHen.Name = "DTPNgayHen";
            DTPNgayHen.Size = new Size(250, 27);
            DTPNgayHen.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 275);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 3;
            label7.Text = "Tình trạng";
            // 
            // txtBoxTinhTrang
            // 
            txtBoxTinhTrang.Location = new Point(94, 272);
            txtBoxTinhTrang.Name = "txtBoxTinhTrang";
            txtBoxTinhTrang.Size = new Size(744, 27);
            txtBoxTinhTrang.TabIndex = 7;
            // 
            // cboMaBS
            // 
            cboMaBS.FormattingEnabled = true;
            cboMaBS.Location = new Point(408, 80);
            cboMaBS.Name = "cboMaBS";
            cboMaBS.Size = new Size(233, 28);
            cboMaBS.TabIndex = 8;
            // 
            // cboMaBN
            // 
            cboMaBN.FormattingEnabled = true;
            cboMaBN.Location = new Point(774, 80);
            cboMaBN.Name = "cboMaBN";
            cboMaBN.Size = new Size(222, 28);
            cboMaBN.TabIndex = 8;
            // 
            // DGVLichHen
            // 
            DGVLichHen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVLichHen.Location = new Point(5, 392);
            DGVLichHen.Name = "DGVLichHen";
            DGVLichHen.RowHeadersWidth = 51;
            DGVLichHen.Size = new Size(996, 244);
            DGVLichHen.TabIndex = 9;
            DGVLichHen.CellClick += DGVLichHen_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(94, 337);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(437, 337);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(774, 337);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // errorProviderLH
            // 
            errorProviderLH.ContainerControl = this;
            // 
            // QuanLyLichHen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 638);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(DGVLichHen);
            Controls.Add(cboMaBN);
            Controls.Add(cboMaBS);
            Controls.Add(txtBoxTinhTrang);
            Controls.Add(DTPNgayHen);
            Controls.Add(DTPThoiGianHen);
            Controls.Add(txtBoxMaLH);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnTimLH);
            Controls.Add(txtBoxTimMaLH);
            Controls.Add(label1);
            Name = "QuanLyLichHen";
            Text = "QuanLyLichHen";
            ((System.ComponentModel.ISupportInitialize)DGVLichHen).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimMaLH;
        private Button btnTimLH;
        private Label label2;
        private TextBox txtBoxMaLH;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker DTPThoiGianHen;
        private Label label6;
        private DateTimePicker DTPNgayHen;
        private Label label7;
        private TextBox txtBoxTinhTrang;
        private ComboBox cboMaBS;
        private ComboBox cboMaBN;
        private DataGridView DGVLichHen;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private ErrorProvider errorProviderLH;
    }
}