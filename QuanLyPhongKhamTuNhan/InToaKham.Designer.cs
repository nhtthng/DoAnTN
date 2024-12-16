namespace GUI
{
    partial class InToaKham
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
            txtTenBS = new TextBox();
            label2 = new Label();
            txtTenBN = new TextBox();
            label3 = new Label();
            DTPNgayKham = new DateTimePicker();
            label4 = new Label();
            txtChuanDoan = new TextBox();
            label5 = new Label();
            btnInPhieu = new Button();
            label6 = new Label();
            RtxtBoxKetLuan = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 99);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Bác Sĩ";
            // 
            // txtTenBS
            // 
            txtTenBS.Location = new Point(161, 92);
            txtTenBS.Name = "txtTenBS";
            txtTenBS.Size = new Size(250, 27);
            txtTenBS.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 164);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên Bệnh Nhân";
            // 
            // txtTenBN
            // 
            txtTenBN.Location = new Point(161, 161);
            txtTenBN.Name = "txtTenBN";
            txtTenBN.Size = new Size(250, 27);
            txtTenBN.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 232);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày khám";
            // 
            // DTPNgayKham
            // 
            DTPNgayKham.Location = new Point(161, 225);
            DTPNgayKham.Name = "DTPNgayKham";
            DTPNgayKham.Size = new Size(250, 27);
            DTPNgayKham.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 295);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 6;
            label4.Text = "Chuẩn đoán";
            // 
            // txtChuanDoan
            // 
            txtChuanDoan.Location = new Point(161, 292);
            txtChuanDoan.Name = "txtChuanDoan";
            txtChuanDoan.Size = new Size(250, 27);
            txtChuanDoan.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 389);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 8;
            label5.Text = "Kết Luận";
            // 
            // btnInPhieu
            // 
            btnInPhieu.Location = new Point(270, 502);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(94, 29);
            btnInPhieu.TabIndex = 10;
            btnInPhieu.Text = "In Phiếu";
            btnInPhieu.UseVisualStyleBackColor = true;
            btnInPhieu.Click += btnInPhieu_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(217, 26);
            label6.Name = "label6";
            label6.Size = new Size(147, 35);
            label6.TabIndex = 11;
            label6.Text = "Phiếu Khám";
            // 
            // RtxtBoxKetLuan
            // 
            RtxtBoxKetLuan.Location = new Point(161, 342);
            RtxtBoxKetLuan.Name = "RtxtBoxKetLuan";
            RtxtBoxKetLuan.Size = new Size(410, 120);
            RtxtBoxKetLuan.TabIndex = 12;
            RtxtBoxKetLuan.Text = "";
            // 
            // InToaKham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 557);
            Controls.Add(RtxtBoxKetLuan);
            Controls.Add(label6);
            Controls.Add(btnInPhieu);
            Controls.Add(label5);
            Controls.Add(txtChuanDoan);
            Controls.Add(label4);
            Controls.Add(DTPNgayKham);
            Controls.Add(label3);
            Controls.Add(txtTenBN);
            Controls.Add(label2);
            Controls.Add(txtTenBS);
            Controls.Add(label1);
            Name = "InToaKham";
            Text = "InToaKham";
            Load += InToaKham_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenBS;
        private Label label2;
        private TextBox txtTenBN;
        private Label label3;
        private DateTimePicker DTPNgayKham;
        private Label label4;
        private TextBox txtChuanDoan;
        private Label label5;
        private Button btnInPhieu;
        private Label label6;
        private RichTextBox RtxtBoxKetLuan;
    }
}