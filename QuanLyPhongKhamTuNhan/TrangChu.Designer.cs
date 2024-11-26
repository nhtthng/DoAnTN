namespace GUI
{
    partial class TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            menuStrip1 = new MenuStrip();
            hệThongToolStripMenuItem = new ToolStripMenuItem();
            tàiKhoảnToolStripMenuItem1 = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            saoLưuToolStripMenuItem = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            thuốcToolStripMenuItem = new ToolStripMenuItem();
            danhMụcDịchVụToolStripMenuItem = new ToolStripMenuItem();
            phòngBanToolStripMenuItem = new ToolStripMenuItem();
            tiếpNhậnToolStripMenuItem = new ToolStripMenuItem();
            khámBệnhToolStripMenuItem = new ToolStripMenuItem();
            lịchHẹnToolStripMenuItem = new ToolStripMenuItem();
            KeThuocMenuItem1 = new ToolStripMenuItem();
            HoaDoaStripMenuItem1 = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(192, 255, 255);
            menuStrip1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThongToolStripMenuItem, danhMụcToolStripMenuItem, tiếpNhậnToolStripMenuItem, khámBệnhToolStripMenuItem, lịchHẹnToolStripMenuItem, KeThuocMenuItem1, HoaDoaStripMenuItem1, báoCáoToolStripMenuItem, thoátToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1312, 39);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // hệThongToolStripMenuItem
            // 
            hệThongToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tàiKhoảnToolStripMenuItem1, đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem, saoLưuToolStripMenuItem });
            hệThongToolStripMenuItem.Image = (Image)resources.GetObject("hệThongToolStripMenuItem.Image");
            hệThongToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            hệThongToolStripMenuItem.Name = "hệThongToolStripMenuItem";
            hệThongToolStripMenuItem.Size = new Size(153, 35);
            hệThongToolStripMenuItem.Text = "Hệ Thống";
            hệThongToolStripMenuItem.Click += tàiKhoảnToolStripMenuItem_Click;
            // 
            // tàiKhoảnToolStripMenuItem1
            // 
            tàiKhoảnToolStripMenuItem1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            tàiKhoảnToolStripMenuItem1.Name = "tàiKhoảnToolStripMenuItem1";
            tàiKhoảnToolStripMenuItem1.Size = new Size(224, 30);
            tàiKhoảnToolStripMenuItem1.Text = "Tài Khoản";
            tàiKhoảnToolStripMenuItem1.Click += tàiKhoảnToolStripMenuItem1_Click;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(224, 30);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật  Khẩu";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(224, 30);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // saoLưuToolStripMenuItem
            // 
            saoLưuToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            saoLưuToolStripMenuItem.Name = "saoLưuToolStripMenuItem";
            saoLưuToolStripMenuItem.Size = new Size(224, 30);
            saoLưuToolStripMenuItem.Text = "Sao Lưu";
            saoLưuToolStripMenuItem.Click += saoLưuToolStripMenuItem_Click;
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thuốcToolStripMenuItem, danhMụcDịchVụToolStripMenuItem, phòngBanToolStripMenuItem });
            danhMụcToolStripMenuItem.Image = (Image)resources.GetObject("danhMụcToolStripMenuItem.Image");
            danhMụcToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(134, 35);
            danhMụcToolStripMenuItem.Text = "Quản Lý";
            danhMụcToolStripMenuItem.Click += danhMụcToolStripMenuItem_Click;
            // 
            // thuốcToolStripMenuItem
            // 
            thuốcToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            thuốcToolStripMenuItem.Name = "thuốcToolStripMenuItem";
            thuốcToolStripMenuItem.Size = new Size(193, 30);
            thuốcToolStripMenuItem.Text = "Thuốc";
            thuốcToolStripMenuItem.Click += thuốcToolStripMenuItem_Click;
            // 
            // danhMụcDịchVụToolStripMenuItem
            // 
            danhMụcDịchVụToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            danhMụcDịchVụToolStripMenuItem.Name = "danhMụcDịchVụToolStripMenuItem";
            danhMụcDịchVụToolStripMenuItem.Size = new Size(193, 30);
            danhMụcDịchVụToolStripMenuItem.Text = "Dịch Vụ";
            danhMụcDịchVụToolStripMenuItem.Click += danhMụcDịchVụToolStripMenuItem_Click;
            // 
            // phòngBanToolStripMenuItem
            // 
            phòngBanToolStripMenuItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            phòngBanToolStripMenuItem.Name = "phòngBanToolStripMenuItem";
            phòngBanToolStripMenuItem.Size = new Size(193, 30);
            phòngBanToolStripMenuItem.Text = "Phòng Ban";
            phòngBanToolStripMenuItem.Click += phòngBanToolStripMenuItem_Click;
            // 
            // tiếpNhậnToolStripMenuItem
            // 
            tiếpNhậnToolStripMenuItem.Image = (Image)resources.GetObject("tiếpNhậnToolStripMenuItem.Image");
            tiếpNhậnToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            tiếpNhậnToolStripMenuItem.Name = "tiếpNhậnToolStripMenuItem";
            tiếpNhậnToolStripMenuItem.Size = new Size(158, 35);
            tiếpNhậnToolStripMenuItem.Text = "Tiếp Nhận";
            tiếpNhậnToolStripMenuItem.Click += tiếpNhậnToolStripMenuItem_Click;
            // 
            // khámBệnhToolStripMenuItem
            // 
            khámBệnhToolStripMenuItem.Image = (Image)resources.GetObject("khámBệnhToolStripMenuItem.Image");
            khámBệnhToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            khámBệnhToolStripMenuItem.Name = "khámBệnhToolStripMenuItem";
            khámBệnhToolStripMenuItem.Size = new Size(171, 35);
            khámBệnhToolStripMenuItem.Text = "Khám Bệnh";
            khámBệnhToolStripMenuItem.Click += khámBệnhToolStripMenuItem_Click;
            // 
            // lịchHẹnToolStripMenuItem
            // 
            lịchHẹnToolStripMenuItem.Image = (Image)resources.GetObject("lịchHẹnToolStripMenuItem.Image");
            lịchHẹnToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            lịchHẹnToolStripMenuItem.Name = "lịchHẹnToolStripMenuItem";
            lịchHẹnToolStripMenuItem.Size = new Size(142, 35);
            lịchHẹnToolStripMenuItem.Text = "Lịch Hẹn";
            lịchHẹnToolStripMenuItem.Click += lịchHẹnToolStripMenuItem_Click;
            // 
            // KeThuocMenuItem1
            // 
            KeThuocMenuItem1.Image = (Image)resources.GetObject("KeThuocMenuItem1.Image");
            KeThuocMenuItem1.Name = "KeThuocMenuItem1";
            KeThuocMenuItem1.Size = new Size(147, 35);
            KeThuocMenuItem1.Text = "Kê Thuốc";
            KeThuocMenuItem1.Click += KeThuocMenuItem1_Click;
            // 
            // HoaDoaStripMenuItem1
            // 
            HoaDoaStripMenuItem1.Image = (Image)resources.GetObject("HoaDoaStripMenuItem1.Image");
            HoaDoaStripMenuItem1.Name = "HoaDoaStripMenuItem1";
            HoaDoaStripMenuItem1.Size = new Size(143, 35);
            HoaDoaStripMenuItem1.Text = "Hóa Đơn";
            HoaDoaStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.Image = (Image)resources.GetObject("báoCáoToolStripMenuItem.Image");
            báoCáoToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(135, 35);
            báoCáoToolStripMenuItem.Text = "Báo Cáo";
            báoCáoToolStripMenuItem.Click += báoCáoToolStripMenuItem_Click;
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Image = (Image)resources.GetObject("thoátToolStripMenuItem.Image");
            thoátToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(110, 35);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(1312, 559);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // TrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 609);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TrangChu";
            Text = "TrangChu";
            Load += TrangChu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThongToolStripMenuItem;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem1;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem thuốcToolStripMenuItem;
        private ToolStripMenuItem danhMụcDịchVụToolStripMenuItem;
        private ToolStripMenuItem tiếpNhậnToolStripMenuItem;
        private ToolStripMenuItem khámBệnhToolStripMenuItem;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem lịchHẹnToolStripMenuItem;
        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem phòngBanToolStripMenuItem;
        private ToolStripMenuItem HoaDoaStripMenuItem1;
        private ToolStripMenuItem KeThuocMenuItem1;
        private ToolStripMenuItem saoLưuToolStripMenuItem;
    }
}