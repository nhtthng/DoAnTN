namespace GUI
{
    partial class DoiMatKhau
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
            txtBoxMatKhauCu = new TextBox();
            label2 = new Label();
            txtBoxMatKhauMoi = new TextBox();
            label3 = new Label();
            txtBoxXacNhanMKM = new TextBox();
            btnDoiMK = new Button();
            btnQuenMK = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập mật khẩu hiện tại";
            // 
            // txtBoxMatKhauCu
            // 
            txtBoxMatKhauCu.Location = new Point(182, 53);
            txtBoxMatKhauCu.Name = "txtBoxMatKhauCu";
            txtBoxMatKhauCu.Size = new Size(208, 27);
            txtBoxMatKhauCu.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 128);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 0;
            label2.Text = "Nhập mật khẩu mới";
            // 
            // txtBoxMatKhauMoi
            // 
            txtBoxMatKhauMoi.Location = new Point(182, 125);
            txtBoxMatKhauMoi.Name = "txtBoxMatKhauMoi";
            txtBoxMatKhauMoi.Size = new Size(208, 27);
            txtBoxMatKhauMoi.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 192);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 0;
            label3.Text = "Xác nhận mật khẩu mới";
            // 
            // txtBoxXacNhanMKM
            // 
            txtBoxXacNhanMKM.Location = new Point(182, 189);
            txtBoxXacNhanMKM.Name = "txtBoxXacNhanMKM";
            txtBoxXacNhanMKM.Size = new Size(208, 27);
            txtBoxXacNhanMKM.TabIndex = 1;
            // 
            // btnDoiMK
            // 
            btnDoiMK.Location = new Point(12, 269);
            btnDoiMK.Name = "btnDoiMK";
            btnDoiMK.Size = new Size(129, 29);
            btnDoiMK.TabIndex = 2;
            btnDoiMK.Text = "Đổi Mật Khẩu";
            btnDoiMK.UseVisualStyleBackColor = true;
            btnDoiMK.Click += btnDoiMK_Click;
            // 
            // btnQuenMK
            // 
            btnQuenMK.Location = new Point(244, 269);
            btnQuenMK.Name = "btnQuenMK";
            btnQuenMK.Size = new Size(129, 29);
            btnQuenMK.TabIndex = 3;
            btnQuenMK.Text = "Quên mật khẩu";
            btnQuenMK.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(466, 268);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 365);
            Controls.Add(btnReset);
            Controls.Add(btnQuenMK);
            Controls.Add(btnDoiMK);
            Controls.Add(txtBoxXacNhanMKM);
            Controls.Add(txtBoxMatKhauMoi);
            Controls.Add(txtBoxMatKhauCu);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DoiMatKhau";
            Text = "DoiMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxMatKhauCu;
        private Label label2;
        private TextBox txtBoxMatKhauMoi;
        private Label label3;
        private TextBox txtBoxXacNhanMKM;
        private Button btnDoiMK;
        private Button btnQuenMK;
        private Button btnReset;
    }
}