namespace GUI
{
    partial class Quanlyphongkham
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
            txtBoxTimPK = new TextBox();
            btnTimPK = new Button();
            label2 = new Label();
            txtBoxMaPK = new TextBox();
            label3 = new Label();
            txtBoxTenPK = new TextBox();
            label4 = new Label();
            cboMaCK = new ComboBox();
            btnThemPK = new Button();
            btnXoaPK = new Button();
            btnSuaPK = new Button();
            DGVPK = new DataGridView();
            errorProviderPK = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DGVPK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPK).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã phòng khám";
            // 
            // txtBoxTimPK
            // 
            txtBoxTimPK.Location = new Point(135, 6);
            txtBoxTimPK.Name = "txtBoxTimPK";
            txtBoxTimPK.Size = new Size(736, 27);
            txtBoxTimPK.TabIndex = 1;
            // 
            // btnTimPK
            // 
            btnTimPK.Location = new Point(891, 4);
            btnTimPK.Name = "btnTimPK";
            btnTimPK.Size = new Size(94, 29);
            btnTimPK.TabIndex = 2;
            btnTimPK.Text = "Tìm";
            btnTimPK.UseVisualStyleBackColor = true;
            btnTimPK.Click += btnTimPK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 116);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã phòng khám";
            // 
            // txtBoxMaPK
            // 
            txtBoxMaPK.Location = new Point(135, 113);
            txtBoxMaPK.Name = "txtBoxMaPK";
            txtBoxMaPK.Size = new Size(139, 27);
            txtBoxMaPK.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 116);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 3;
            label3.Text = "Tên phòng khám";
            // 
            // txtBoxTenPK
            // 
            txtBoxTenPK.Location = new Point(491, 114);
            txtBoxTenPK.Name = "txtBoxTenPK";
            txtBoxTenPK.Size = new Size(139, 27);
            txtBoxTenPK.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(715, 116);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 3;
            label4.Text = "Mã chuyên khoa";
            // 
            // cboMaCK
            // 
            cboMaCK.FormattingEnabled = true;
            cboMaCK.Location = new Point(837, 113);
            cboMaCK.Name = "cboMaCK";
            cboMaCK.Size = new Size(151, 28);
            cboMaCK.TabIndex = 5;
            // 
            // btnThemPK
            // 
            btnThemPK.Location = new Point(68, 213);
            btnThemPK.Name = "btnThemPK";
            btnThemPK.Size = new Size(94, 29);
            btnThemPK.TabIndex = 6;
            btnThemPK.Text = "Thêm";
            btnThemPK.UseVisualStyleBackColor = true;
            btnThemPK.Click += btnThemPK_Click;
            // 
            // btnXoaPK
            // 
            btnXoaPK.Location = new Point(446, 213);
            btnXoaPK.Name = "btnXoaPK";
            btnXoaPK.Size = new Size(94, 29);
            btnXoaPK.TabIndex = 6;
            btnXoaPK.Text = "Xóa";
            btnXoaPK.UseVisualStyleBackColor = true;
            btnXoaPK.Click += btnXoaPK_Click;
            // 
            // btnSuaPK
            // 
            btnSuaPK.Location = new Point(821, 213);
            btnSuaPK.Name = "btnSuaPK";
            btnSuaPK.Size = new Size(94, 29);
            btnSuaPK.TabIndex = 6;
            btnSuaPK.Text = "Sửa";
            btnSuaPK.UseVisualStyleBackColor = true;
            btnSuaPK.Click += btnSuaPK_Click;
            // 
            // DGVPK
            // 
            DGVPK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPK.Location = new Point(5, 263);
            DGVPK.Name = "DGVPK";
            DGVPK.RowHeadersWidth = 51;
            DGVPK.Size = new Size(990, 238);
            DGVPK.TabIndex = 7;
            DGVPK.CellClick += DGVPK_CellClick;
            // 
            // errorProviderPK
            // 
            errorProviderPK.ContainerControl = this;
            // 
            // Quanlyphongkham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 503);
            Controls.Add(DGVPK);
            Controls.Add(btnSuaPK);
            Controls.Add(btnXoaPK);
            Controls.Add(btnThemPK);
            Controls.Add(cboMaCK);
            Controls.Add(txtBoxTenPK);
            Controls.Add(txtBoxMaPK);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnTimPK);
            Controls.Add(txtBoxTimPK);
            Controls.Add(label1);
            Name = "Quanlyphongkham";
            Text = "QuanLyPhongKham";
            ((System.ComponentModel.ISupportInitialize)DGVPK).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPK).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxTimPK;
        private Button btnTimPK;
        private Label label2;
        private TextBox txtBoxMaPK;
        private Label label3;
        private TextBox txtBoxTenPK;
        private Label label4;
        private ComboBox cboMaCK;
        private Button btnThemPK;
        private Button btnXoaPK;
        private Button btnSuaPK;
        private DataGridView DGVPK;
        private ErrorProvider errorProviderPK;
    }
}