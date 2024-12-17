namespace GUI
{
    partial class KiemTraEmail
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
            txtBoxEmail = new TextBox();
            label2 = new Label();
            txtBoxMa = new TextBox();
            btnGuiEmail = new Button();
            btnGuiMa = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 123);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập email của bạn";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(193, 120);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(294, 27);
            txtBoxEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 221);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Nhập mã";
            // 
            // txtBoxMa
            // 
            txtBoxMa.Location = new Point(193, 218);
            txtBoxMa.Name = "txtBoxMa";
            txtBoxMa.Size = new Size(294, 27);
            txtBoxMa.TabIndex = 3;
            // 
            // btnGuiEmail
            // 
            btnGuiEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuiEmail.Location = new Point(516, 119);
            btnGuiEmail.Name = "btnGuiEmail";
            btnGuiEmail.Size = new Size(94, 29);
            btnGuiEmail.TabIndex = 4;
            btnGuiEmail.Text = "Gửi";
            btnGuiEmail.UseVisualStyleBackColor = true;
            btnGuiEmail.Click += btnGuiEmail_Click;
            // 
            // btnGuiMa
            // 
            btnGuiMa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuiMa.Location = new Point(516, 217);
            btnGuiMa.Name = "btnGuiMa";
            btnGuiMa.Size = new Size(94, 29);
            btnGuiMa.TabIndex = 5;
            btnGuiMa.Text = "Gửi";
            btnGuiMa.UseVisualStyleBackColor = true;
            btnGuiMa.Click += btnGuiMa_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(224, 25);
            label3.Name = "label3";
            label3.Size = new Size(196, 35);
            label3.TabIndex = 6;
            label3.Text = "Xác Nhận Email";
            // 
            // KiemTraEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 358);
            Controls.Add(label3);
            Controls.Add(btnGuiMa);
            Controls.Add(btnGuiEmail);
            Controls.Add(txtBoxMa);
            Controls.Add(label2);
            Controls.Add(txtBoxEmail);
            Controls.Add(label1);
            Name = "KiemTraEmail";
            Text = "KiemTraEmail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxEmail;
        private Label label2;
        private TextBox txtBoxMa;
        private Button btnGuiEmail;
        private Button btnGuiMa;
        private Label label3;
    }
}