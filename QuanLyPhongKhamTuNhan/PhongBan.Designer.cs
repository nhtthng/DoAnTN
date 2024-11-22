namespace GUI
{
    partial class PhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhongBan));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtMaPhong = new TextBox();
            txtTenPhongBan = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtTenPhongBan);
            panel1.Controls.Add(txtMaPhong);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(559, 390);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(250, 31);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Phòng Ban";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 25);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Phòng Ban";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(207, 25);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 0;
            label3.Text = "Tên Phòng Ban";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(507, 252);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnThem
            // 
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(20, 75);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(105, 44);
            btnThem.TabIndex = 2;
            btnThem.Text = "      Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(230, 75);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(105, 44);
            btnSua.TabIndex = 2;
            btnSua.Text = "     Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(422, 75);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(105, 44);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "     Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new Point(131, 22);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new Size(60, 27);
            txtMaPhong.TabIndex = 3;
            // 
            // txtTenPhongBan
            // 
            txtTenPhongBan.Location = new Point(320, 22);
            txtTenPhongBan.Name = "txtTenPhongBan";
            txtTenPhongBan.Size = new Size(207, 27);
            txtTenPhongBan.TabIndex = 3;
            // 
            // PhongBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 423);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "PhongBan";
            Text = "PhongBan";
            Load += PhongBan_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtTenPhongBan;
        private TextBox txtMaPhong;
    }
}