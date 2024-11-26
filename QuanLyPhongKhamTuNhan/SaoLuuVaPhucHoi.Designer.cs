namespace GUI
{
    partial class SaoLuuVaPhucHoi
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
            txtBoxDuongDan = new TextBox();
            btnChonTM = new Button();
            btnSaoLuu = new Button();
            btnPhucHoi = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Đường dẫn sao lưu";
            // 
            // txtBoxDuongDan
            // 
            txtBoxDuongDan.Enabled = false;
            txtBoxDuongDan.Location = new Point(154, 28);
            txtBoxDuongDan.Name = "txtBoxDuongDan";
            txtBoxDuongDan.Size = new Size(494, 27);
            txtBoxDuongDan.TabIndex = 1;
            // 
            // btnChonTM
            // 
            btnChonTM.Location = new Point(667, 27);
            btnChonTM.Name = "btnChonTM";
            btnChonTM.Size = new Size(121, 29);
            btnChonTM.TabIndex = 2;
            btnChonTM.Text = "Chọn thư mục";
            btnChonTM.UseVisualStyleBackColor = true;
            btnChonTM.Click += btnChonTM_Click;
            // 
            // btnSaoLuu
            // 
            btnSaoLuu.Location = new Point(67, 103);
            btnSaoLuu.Name = "btnSaoLuu";
            btnSaoLuu.Size = new Size(141, 29);
            btnSaoLuu.TabIndex = 3;
            btnSaoLuu.Text = "Sao Lưu CSDL";
            btnSaoLuu.UseVisualStyleBackColor = true;
            btnSaoLuu.Click += btnSaoLuu_Click;
            // 
            // btnPhucHoi
            // 
            btnPhucHoi.Location = new Point(536, 103);
            btnPhucHoi.Name = "btnPhucHoi";
            btnPhucHoi.Size = new Size(158, 29);
            btnPhucHoi.TabIndex = 3;
            btnPhucHoi.Text = "Phục hồi CSDL";
            btnPhucHoi.UseVisualStyleBackColor = true;
            btnPhucHoi.Click += btnPhucHoi_Click;
            // 
            // SaoLuuVaPhucHoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 228);
            Controls.Add(btnPhucHoi);
            Controls.Add(btnSaoLuu);
            Controls.Add(btnChonTM);
            Controls.Add(txtBoxDuongDan);
            Controls.Add(label1);
            Name = "SaoLuuVaPhucHoi";
            Text = "SaoLuuVaPhucHoi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxDuongDan;
        private Button btnChonTM;
        private Button btnSaoLuu;
        private Button btnPhucHoi;
    }
}