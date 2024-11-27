namespace GUI
{
    partial class BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCao));
            panel1 = new Panel();
            btnInDoanhThu = new Button();
            btnXemDoanhThu = new Button();
            label3 = new Label();
            label2 = new Label();
            dateTimePickerDenNgay = new DateTimePicker();
            dateTimePickerTuNgay = new DateTimePicker();
            label1 = new Label();
            dataGridViewBaoCao = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBaoCao).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnInDoanhThu);
            panel1.Controls.Add(btnXemDoanhThu);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePickerDenNgay);
            panel1.Controls.Add(dateTimePickerTuNgay);
            panel1.Location = new Point(12, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 145);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_1;
            // 
            // btnInDoanhThu
            // 
            btnInDoanhThu.Image = (Image)resources.GetObject("btnInDoanhThu.Image");
            btnInDoanhThu.ImageAlign = ContentAlignment.MiddleLeft;
            btnInDoanhThu.Location = new Point(284, 85);
            btnInDoanhThu.Name = "btnInDoanhThu";
            btnInDoanhThu.Size = new Size(167, 41);
            btnInDoanhThu.TabIndex = 2;
            btnInDoanhThu.Text = "     In Doanh Thu";
            btnInDoanhThu.UseVisualStyleBackColor = true;
            btnInDoanhThu.Click += btnInDoanhThu_Click;
            // 
            // btnXemDoanhThu
            // 
            btnXemDoanhThu.Image = (Image)resources.GetObject("btnXemDoanhThu.Image");
            btnXemDoanhThu.ImageAlign = ContentAlignment.MiddleLeft;
            btnXemDoanhThu.Location = new Point(284, 22);
            btnXemDoanhThu.Name = "btnXemDoanhThu";
            btnXemDoanhThu.Size = new Size(167, 41);
            btnXemDoanhThu.TabIndex = 2;
            btnXemDoanhThu.Text = "       Xem Doanh Thu";
            btnXemDoanhThu.UseVisualStyleBackColor = true;
            btnXemDoanhThu.Click += btnXemDoanhThu_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F);
            label3.Location = new Point(13, 90);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 1;
            label3.Text = "Đến Ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F);
            label2.Location = new Point(13, 28);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 1;
            label2.Text = "Từ Ngày";
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerDenNgay.Format = DateTimePickerFormat.Short;
            dateTimePickerDenNgay.Location = new Point(107, 88);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(145, 31);
            dateTimePickerDenNgay.TabIndex = 0;
            dateTimePickerDenNgay.ValueChanged += dateTimePickerDenNgay_ValueChanged;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerTuNgay.Format = DateTimePickerFormat.Short;
            dateTimePickerTuNgay.Location = new Point(107, 26);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(145, 31);
            dateTimePickerTuNgay.TabIndex = 0;
            dateTimePickerTuNgay.ValueChanged += dateTimePickerTuNgay_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 31);
            label1.TabIndex = 1;
            label1.Text = "Báo Cáo Doanh Thu";
            // 
            // dataGridViewBaoCao
            // 
            dataGridViewBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBaoCao.Location = new Point(12, 195);
            dataGridViewBaoCao.Name = "dataGridViewBaoCao";
            dataGridViewBaoCao.RowHeadersWidth = 51;
            dataGridViewBaoCao.Size = new Size(465, 188);
            dataGridViewBaoCao.TabIndex = 2;
            dataGridViewBaoCao.CellContentClick += dataGridViewBaoCao_CellContentClick;
            // 
            // BaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 395);
            Controls.Add(dataGridViewBaoCao);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "BaoCao";
            Text = "BaoCao";
            Load += BaoCao_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DateTimePicker dateTimePickerTuNgay;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePickerDenNgay;
        private Button btnInDoanhThu;
        private Button btnXemDoanhThu;
        private DataGridView dataGridViewBaoCao;
    }
}