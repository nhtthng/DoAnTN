namespace GUI
{
    partial class QuanLyBacSi
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
            txtBoxTimBS = new TextBox();
            btnTimBS = new Button();
            label2 = new Label();
            txtBoxEmailBS = new TextBox();
            label3 = new Label();
            txtBoxMaBS = new TextBox();
            label4 = new Label();
            cboGTBS = new ComboBox();
            label5 = new Label();
            txtBoxTenBS = new TextBox();
            label6 = new Label();
            txtBoxSDTBS = new TextBox();
            label8 = new Label();
            txtBoxKNBS = new TextBox();
            label9 = new Label();
            cboChuyenKhoaBS = new ComboBox();
            DGVBS = new DataGridView();
            btnThemBS = new Button();
            btnXoaBS = new Button();
            btnSuaBS = new Button();
            errorProviderBS = new ErrorProvider(components);
            btnReset = new Button();
            label7 = new Label();
            cboMaPhongKham = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVBS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderBS).BeginInit();
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
            // txtBoxTimBS
            // 
            txtBoxTimBS.Location = new Point(91, 6);
            txtBoxTimBS.Name = "txtBoxTimBS";
            txtBoxTimBS.Size = new Size(733, 27);
            txtBoxTimBS.TabIndex = 1;
            // 
            // btnTimBS
            // 
            btnTimBS.Location = new Point(830, 5);
            btnTimBS.Name = "btnTimBS";
            btnTimBS.Size = new Size(94, 29);
            btnTimBS.TabIndex = 2;
            btnTimBS.Text = "Tìm";
            btnTimBS.UseVisualStyleBackColor = true;
            btnTimBS.Click += btnTimBS_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 93);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã Bác Sĩ";
            // 
            // txtBoxEmailBS
            // 
            txtBoxEmailBS.Location = new Point(427, 91);
            txtBoxEmailBS.Name = "txtBoxEmailBS";
            txtBoxEmailBS.Size = new Size(182, 27);
            txtBoxEmailBS.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(637, 91);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 3;
            label3.Text = "Giới Tính";
            // 
            // txtBoxMaBS
            // 
            txtBoxMaBS.Location = new Point(102, 88);
            txtBoxMaBS.Name = "txtBoxMaBS";
            txtBoxMaBS.Size = new Size(211, 27);
            txtBoxMaBS.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 94);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // cboGTBS
            // 
            cboGTBS.FormattingEnabled = true;
            cboGTBS.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGTBS.Location = new Point(763, 90);
            cboGTBS.Name = "cboGTBS";
            cboGTBS.Size = new Size(151, 28);
            cboGTBS.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 189);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 3;
            label5.Text = "Tên Bác Sĩ";
            // 
            // txtBoxTenBS
            // 
            txtBoxTenBS.Location = new Point(102, 186);
            txtBoxTenBS.Name = "txtBoxTenBS";
            txtBoxTenBS.Size = new Size(211, 27);
            txtBoxTenBS.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(319, 189);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 3;
            label6.Text = "Số Điện Thoại";
            // 
            // txtBoxSDTBS
            // 
            txtBoxSDTBS.Location = new Point(427, 186);
            txtBoxSDTBS.Name = "txtBoxSDTBS";
            txtBoxSDTBS.Size = new Size(182, 27);
            txtBoxSDTBS.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 280);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 3;
            label8.Text = "Kinh Nghiệm";
            // 
            // txtBoxKNBS
            // 
            txtBoxKNBS.Location = new Point(102, 277);
            txtBoxKNBS.Name = "txtBoxKNBS";
            txtBoxKNBS.Size = new Size(155, 27);
            txtBoxKNBS.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(283, 280);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 3;
            label9.Text = "Chuyên khoa";
            // 
            // cboChuyenKhoaBS
            // 
            cboChuyenKhoaBS.FormattingEnabled = true;
            cboChuyenKhoaBS.Location = new Point(427, 272);
            cboChuyenKhoaBS.Name = "cboChuyenKhoaBS";
            cboChuyenKhoaBS.Size = new Size(182, 28);
            cboChuyenKhoaBS.TabIndex = 6;
            // 
            // DGVBS
            // 
            DGVBS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBS.Location = new Point(3, 411);
            DGVBS.Name = "DGVBS";
            DGVBS.RowHeadersWidth = 51;
            DGVBS.Size = new Size(940, 215);
            DGVBS.TabIndex = 7;
            DGVBS.CellClick += DGVBS_CellClick;
            // 
            // btnThemBS
            // 
            btnThemBS.Location = new Point(43, 353);
            btnThemBS.Name = "btnThemBS";
            btnThemBS.Size = new Size(94, 29);
            btnThemBS.TabIndex = 8;
            btnThemBS.Text = "Thêm";
            btnThemBS.UseVisualStyleBackColor = true;
            btnThemBS.Click += btnThemBS_Click;
            // 
            // btnXoaBS
            // 
            btnXoaBS.Location = new Point(309, 353);
            btnXoaBS.Name = "btnXoaBS";
            btnXoaBS.Size = new Size(94, 29);
            btnXoaBS.TabIndex = 8;
            btnXoaBS.Text = "Xóa";
            btnXoaBS.UseVisualStyleBackColor = true;
            btnXoaBS.Click += btnXoaBS_Click;
            // 
            // btnSuaBS
            // 
            btnSuaBS.Location = new Point(585, 353);
            btnSuaBS.Name = "btnSuaBS";
            btnSuaBS.Size = new Size(94, 29);
            btnSuaBS.TabIndex = 8;
            btnSuaBS.Text = "Sửa";
            btnSuaBS.UseVisualStyleBackColor = true;
            btnSuaBS.Click += btnSuaBS_Click;
            // 
            // errorProviderBS
            // 
            errorProviderBS.ContainerControl = this;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(820, 353);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(637, 189);
            label7.Name = "label7";
            label7.Size = new Size(91, 20);
            label7.TabIndex = 10;
            label7.Text = "Phòng khám";
            // 
            // cboMaPhongKham
            // 
            cboMaPhongKham.FormattingEnabled = true;
            cboMaPhongKham.Location = new Point(763, 181);
            cboMaPhongKham.Name = "cboMaPhongKham";
            cboMaPhongKham.Size = new Size(151, 28);
            cboMaPhongKham.TabIndex = 11;
            // 
            // QuanLyBacSi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 627);
            Controls.Add(cboMaPhongKham);
            Controls.Add(label7);
            Controls.Add(btnReset);
            Controls.Add(btnSuaBS);
            Controls.Add(btnXoaBS);
            Controls.Add(btnThemBS);
            Controls.Add(DGVBS);
            Controls.Add(cboChuyenKhoaBS);
            Controls.Add(cboGTBS);
            Controls.Add(txtBoxKNBS);
            Controls.Add(txtBoxTenBS);
            Controls.Add(txtBoxMaBS);
            Controls.Add(txtBoxSDTBS);
            Controls.Add(txtBoxEmailBS);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnTimBS);
            Controls.Add(txtBoxTimBS);
            Controls.Add(label1);
            Name = "QuanLyBacSi";
            Text = "QuanLyBacSi";
            KeyPress += QuanLyBacSi_KeyPress;
            ((System.ComponentModel.ISupportInitialize)DGVBS).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderBS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimBS;
        private Button btnTimBS;
        private Label label2;
        private TextBox txtBoxEmailBS;
        private Label label3;
        private TextBox txtBoxMaBS;
        private Label label4;
        private ComboBox cboGTBS;
        private Label label5;
        private TextBox txtBoxTenBS;
        private Label label6;
        private TextBox txtBoxSDTBS;
        private Label label8;
        private TextBox txtBoxKNBS;
        private Label label9;
        private ComboBox cboChuyenKhoaBS;
        private DataGridView DGVBS;
        private Button btnThemBS;
        private Button btnXoaBS;
        private Button btnSuaBS;
        private ErrorProvider errorProviderBS;
        private Button btnReset;
        private ComboBox cboMaPhongKham;
        private Label label7;
    }
}