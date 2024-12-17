namespace GUI
{
    partial class TaoMatKhau
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
            label2 = new Label();
            txtBoxMatKhauMoi = new TextBox();
            label3 = new Label();
            txtBoxXacNhanMK = new TextBox();
            btnXacNhan = new Button();
            label4 = new Label();
            txtBoxEmail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(234, 26);
            label1.Name = "label1";
            label1.Size = new Size(178, 35);
            label1.TabIndex = 0;
            label1.Text = "Tạo Mật Khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 152);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập mật khẩu mới";
            // 
            // txtBoxMatKhauMoi
            // 
            txtBoxMatKhauMoi.Location = new Point(207, 149);
            txtBoxMatKhauMoi.Name = "txtBoxMatKhauMoi";
            txtBoxMatKhauMoi.Size = new Size(280, 27);
            txtBoxMatKhauMoi.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 225);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 3;
            label3.Text = "Xác nhận mật khẩu mới";
            // 
            // txtBoxXacNhanMK
            // 
            txtBoxXacNhanMK.Location = new Point(207, 222);
            txtBoxXacNhanMK.Name = "txtBoxXacNhanMK";
            txtBoxXacNhanMK.Size = new Size(280, 27);
            txtBoxXacNhanMK.TabIndex = 4;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXacNhan.Image = Properties.Resources.login;
            btnXacNhan.ImageAlign = ContentAlignment.MiddleLeft;
            btnXacNhan.Location = new Point(251, 294);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(114, 40);
            btnXacNhan.TabIndex = 5;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.TextAlign = ContentAlignment.MiddleRight;
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 80);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 6;
            label4.Text = "Email";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(207, 77);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(280, 27);
            txtBoxEmail.TabIndex = 7;
            // 
            // TaoMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 371);
            Controls.Add(txtBoxEmail);
            Controls.Add(label4);
            Controls.Add(btnXacNhan);
            Controls.Add(txtBoxXacNhanMK);
            Controls.Add(label3);
            Controls.Add(txtBoxMatKhauMoi);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TaoMatKhau";
            Text = "TaoMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtBoxMatKhauMoi;
        private Label label3;
        private TextBox txtBoxXacNhanMK;
        private Button btnXacNhan;
        private Label label4;
        private TextBox txtBoxEmail;
    }
}