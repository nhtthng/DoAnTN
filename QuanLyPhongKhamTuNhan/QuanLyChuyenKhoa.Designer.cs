namespace GUI
{
    partial class QuanLyChuyenKhoa
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
            txtBoxTimCK = new TextBox();
            btnTimCK = new Button();
            label2 = new Label();
            txtBoxMaCK = new TextBox();
            label3 = new Label();
            txtBoxTenCK = new TextBox();
            DGVCK = new DataGridView();
            btnThemCK = new Button();
            btnXoaCK = new Button();
            btnSuaCK = new Button();
            errorProviderCK = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DGVCK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCK).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 24);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm Kiếm";
            // 
            // txtBoxTimCK
            // 
            txtBoxTimCK.Location = new Point(82, 20);
            txtBoxTimCK.Name = "txtBoxTimCK";
            txtBoxTimCK.Size = new Size(587, 27);
            txtBoxTimCK.TabIndex = 1;
            // 
            // btnTimCK
            // 
            btnTimCK.Location = new Point(685, 20);
            btnTimCK.Name = "btnTimCK";
            btnTimCK.Size = new Size(94, 29);
            btnTimCK.TabIndex = 2;
            btnTimCK.Text = "Tìm";
            btnTimCK.UseVisualStyleBackColor = true;
            btnTimCK.Click += btnTimCK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 94);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Chuyên Khoa";
            // 
            // txtBoxMaCK
            // 
            txtBoxMaCK.Location = new Point(130, 91);
            txtBoxMaCK.Name = "txtBoxMaCK";
            txtBoxMaCK.Size = new Size(172, 27);
            txtBoxMaCK.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 172);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 0;
            label3.Text = "Tên Chuyên Khoa";
            // 
            // txtBoxTenCK
            // 
            txtBoxTenCK.Location = new Point(130, 169);
            txtBoxTenCK.Name = "txtBoxTenCK";
            txtBoxTenCK.Size = new Size(172, 27);
            txtBoxTenCK.TabIndex = 3;
            // 
            // DGVCK
            // 
            DGVCK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCK.Location = new Point(4, 290);
            DGVCK.Name = "DGVCK";
            DGVCK.RowHeadersWidth = 51;
            DGVCK.Size = new Size(792, 188);
            DGVCK.TabIndex = 4;
            DGVCK.CellClick += DGVCK_CellClick;
            // 
            // btnThemCK
            // 
            btnThemCK.Location = new Point(82, 232);
            btnThemCK.Name = "btnThemCK";
            btnThemCK.Size = new Size(94, 29);
            btnThemCK.TabIndex = 5;
            btnThemCK.Text = "Thêm";
            btnThemCK.UseVisualStyleBackColor = true;
            btnThemCK.Click += btnThemCK_Click;
            // 
            // btnXoaCK
            // 
            btnXoaCK.Location = new Point(357, 232);
            btnXoaCK.Name = "btnXoaCK";
            btnXoaCK.Size = new Size(94, 29);
            btnXoaCK.TabIndex = 5;
            btnXoaCK.Text = "Xóa";
            btnXoaCK.UseVisualStyleBackColor = true;
            btnXoaCK.Click += btnXoaCK_Click;
            // 
            // btnSuaCK
            // 
            btnSuaCK.Location = new Point(631, 232);
            btnSuaCK.Name = "btnSuaCK";
            btnSuaCK.Size = new Size(94, 29);
            btnSuaCK.TabIndex = 5;
            btnSuaCK.Text = "Sửa";
            btnSuaCK.UseVisualStyleBackColor = true;
            btnSuaCK.Click += btnSuaCK_Click;
            // 
            // errorProviderCK
            // 
            errorProviderCK.ContainerControl = this;
            // 
            // QuanLyChuyenKhoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(btnSuaCK);
            Controls.Add(btnXoaCK);
            Controls.Add(btnThemCK);
            Controls.Add(DGVCK);
            Controls.Add(txtBoxTenCK);
            Controls.Add(txtBoxMaCK);
            Controls.Add(btnTimCK);
            Controls.Add(txtBoxTimCK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "QuanLyChuyenKhoa";
            Text = "QuanLyChuyenKhoa";
            ((System.ComponentModel.ISupportInitialize)DGVCK).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCK).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimCK;
        private Button btnTimCK;
        private Label label2;
        private TextBox txtBoxMaCK;
        private Label label3;
        private TextBox txtBoxTenCK;
        private DataGridView DGVCK;
        private Button btnThemCK;
        private Button btnXoaCK;
        private Button btnSuaCK;
        private ErrorProvider errorProviderCK;
    }
}