namespace GUI
{
    partial class QuanLyDichVu
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
            txtBoxTimKiemDV = new TextBox();
            btnTimKiemDV = new Button();
            label2 = new Label();
            txtBoxMaDV = new TextBox();
            label3 = new Label();
            txtBoxTenDV = new TextBox();
            label4 = new Label();
            txtGiaDV = new TextBox();
            DGVDV = new DataGridView();
            btnThemDV = new Button();
            btnXoaDV = new Button();
            btnSuaDV = new Button();
            errorProviderDV = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DGVDV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderDV).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 37);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm Kiếm";
            // 
            // txtBoxTimKiemDV
            // 
            txtBoxTimKiemDV.Location = new Point(158, 34);
            txtBoxTimKiemDV.Name = "txtBoxTimKiemDV";
            txtBoxTimKiemDV.Size = new Size(426, 27);
            txtBoxTimKiemDV.TabIndex = 1;
            // 
            // btnTimKiemDV
            // 
            btnTimKiemDV.Location = new Point(656, 33);
            btnTimKiemDV.Name = "btnTimKiemDV";
            btnTimKiemDV.Size = new Size(94, 29);
            btnTimKiemDV.TabIndex = 2;
            btnTimKiemDV.Text = "Tìm";
            btnTimKiemDV.UseVisualStyleBackColor = true;
            btnTimKiemDV.Click += btnTimKiemDV_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 110);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Dịch Vụ";
            // 
            // txtBoxMaDV
            // 
            txtBoxMaDV.Location = new Point(158, 107);
            txtBoxMaDV.Name = "txtBoxMaDV";
            txtBoxMaDV.Size = new Size(239, 27);
            txtBoxMaDV.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 183);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 0;
            label3.Text = "Tên Dịch Vụ";
            // 
            // txtBoxTenDV
            // 
            txtBoxTenDV.Location = new Point(158, 180);
            txtBoxTenDV.Name = "txtBoxTenDV";
            txtBoxTenDV.Size = new Size(239, 27);
            txtBoxTenDV.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 256);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 0;
            label4.Text = "Giá";
            // 
            // txtGiaDV
            // 
            txtGiaDV.Location = new Point(158, 253);
            txtGiaDV.Name = "txtGiaDV";
            txtGiaDV.Size = new Size(239, 27);
            txtGiaDV.TabIndex = 3;
            // 
            // DGVDV
            // 
            DGVDV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDV.Location = new Point(3, 316);
            DGVDV.Name = "DGVDV";
            DGVDV.RowHeadersWidth = 51;
            DGVDV.Size = new Size(807, 188);
            DGVDV.TabIndex = 4;
            DGVDV.CellClick += DGVDV_CellClick;
            // 
            // btnThemDV
            // 
            btnThemDV.Location = new Point(656, 110);
            btnThemDV.Name = "btnThemDV";
            btnThemDV.Size = new Size(94, 29);
            btnThemDV.TabIndex = 5;
            btnThemDV.Text = "Thêm";
            btnThemDV.UseVisualStyleBackColor = true;
            btnThemDV.Click += btnThemDV_Click;
            // 
            // btnXoaDV
            // 
            btnXoaDV.Location = new Point(656, 183);
            btnXoaDV.Name = "btnXoaDV";
            btnXoaDV.Size = new Size(94, 29);
            btnXoaDV.TabIndex = 5;
            btnXoaDV.Text = "Xóa";
            btnXoaDV.UseVisualStyleBackColor = true;
            btnXoaDV.Click += btnXoaDV_Click;
            // 
            // btnSuaDV
            // 
            btnSuaDV.Location = new Point(656, 252);
            btnSuaDV.Name = "btnSuaDV";
            btnSuaDV.Size = new Size(94, 29);
            btnSuaDV.TabIndex = 5;
            btnSuaDV.Text = "Sửa";
            btnSuaDV.UseVisualStyleBackColor = true;
            btnSuaDV.Click += btnSuaDV_Click;
            // 
            // errorProviderDV
            // 
            errorProviderDV.ContainerControl = this;
            // 
            // QuanLyDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 506);
            Controls.Add(btnSuaDV);
            Controls.Add(btnXoaDV);
            Controls.Add(btnThemDV);
            Controls.Add(DGVDV);
            Controls.Add(txtGiaDV);
            Controls.Add(txtBoxTenDV);
            Controls.Add(txtBoxMaDV);
            Controls.Add(btnTimKiemDV);
            Controls.Add(txtBoxTimKiemDV);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "QuanLyDichVu";
            Text = "QuanLyDichVu";
            ((System.ComponentModel.ISupportInitialize)DGVDV).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderDV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimKiemDV;
        private Button btnTimKiemDV;
        private Label label2;
        private TextBox txtBoxMaDV;
        private Label label3;
        private TextBox txtBoxTenDV;
        private Label label4;
        private TextBox txtGiaDV;
        private DataGridView DGVDV;
        private Button btnThemDV;
        private Button btnXoaDV;
        private Button btnSuaDV;
        private ErrorProvider errorProviderDV;
    }
}