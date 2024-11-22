namespace GUI
{
    partial class SearchThuoc
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
            panel1 = new Panel();
            dataGridViewThuoc = new DataGridView();
            btnTim = new Button();
            txtTenThuoc = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThuoc).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dataGridViewThuoc);
            panel1.Controls.Add(btnTim);
            panel1.Controls.Add(txtTenThuoc);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1027, 471);
            panel1.TabIndex = 0;
            // 
            // dataGridViewThuoc
            // 
            dataGridViewThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewThuoc.Location = new Point(16, 62);
            dataGridViewThuoc.Name = "dataGridViewThuoc";
            dataGridViewThuoc.RowHeadersWidth = 51;
            dataGridViewThuoc.Size = new Size(1005, 404);
            dataGridViewThuoc.TabIndex = 3;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(649, 19);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(89, 28);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(297, 19);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.Size = new Size(324, 27);
            txtTenThuoc.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(215, 22);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Thuốc";
            // 
            // SearchThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 495);
            Controls.Add(panel1);
            Name = "SearchThuoc";
            Text = "SearchThuoc";
            Load += SearchThuoc_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThuoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnTim;
        private TextBox txtTenThuoc;
        private DataGridView dataGridViewThuoc;
    }
}