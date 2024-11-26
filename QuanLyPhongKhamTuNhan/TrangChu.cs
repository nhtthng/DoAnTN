using QuanLyPhongKham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TrangChu : Form
    {
        private int quyen; // Thêm biến để lưu quyền

        public TrangChu(int quyen)
        {
            InitializeComponent();
            this.quyen = quyen; // Gán quyền vào biến
            panel1.Dock = DockStyle.Fill;
            ConfigureMenu(); // Gọi phương thức để cấu hình menu

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

            // Đặt form TrangChu ở chế độ toàn màn hình
            this.WindowState = FormWindowState.Maximized;






        }

        private void ConfigureMenu()
        {
            if (quyen == 0) // Bác sĩ
            {
                HoaDoaStripMenuItem1.Visible = false;

            }
            else if (quyen == 1) // Nhân viên
            {


                danhMụcToolStripMenuItem.Visible = false; // Ẩn menu danh mục
                khámBệnhToolStripMenuItem.Visible = false;
                KeThuocMenuItem1.Visible = false;



            }
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiếpNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyBenhNhan quanLyBenhNhanForm = new QuanLyBenhNhan();

            // Hiển thị form QuanLyBenhNhan
            quanLyBenhNhanForm.StartPosition = FormStartPosition.CenterParent; // Đặt vị trí hiển thị
            quanLyBenhNhanForm.ShowDialog(); // Hiển thị dưới dạng hộp thoại

        }

        private void lịchHẹnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLichHen qllh = new QuanLyLichHen();
            qllh.Show();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ẩn form TrangChu
            this.Hide();

            // Mở lại form DangNhap
            DangNhap dangNhapForm = new DangNhap();
            dangNhapForm.StartPosition = FormStartPosition.CenterParent;
            dangNhapForm.ShowDialog(this); // Hiển thị DangNhap như một hộp thoại

            // Khi đóng form DangNhap, kiểm tra kết quả và đóng TrangChu nếu cần
            if (dangNhapForm.DialogResult != DialogResult.OK)
            {
                this.Close(); // Đóng TrangChu nếu không đăng nhập lại
            }
        }

        private void thuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thuoc thuocForm = new Thuoc();

            // Hiển thị form Thuoc
            thuocForm.StartPosition = FormStartPosition.CenterParent; // Đặt vị trí hiển thị
            thuocForm.FormClosed += (s, args) => this.Enabled = true; // Bật lại form hiện tại khi Thuoc đóng
            thuocForm.Show(); // Hiển thị form Thuoc

        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBan formPhongBan = new PhongBan();

            // Hiển thị form PhongBan
            formPhongBan.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
        }

        private void KeThuocMenuItem1_Click(object sender, EventArgs e)
        {
            KeThuoc keThuocForm = new KeThuoc();

            // Hiển thị form KeThuoc
            keThuocForm.Show(); // Dùng Show() nếu bạn muốn mở form không chặn (không ngăn chặn thao tác trên form chính)

        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void khámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhamBenh kb = new KhamBenh();
            kb.Show();
        }

        private void danhMụcDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDichVu qldv = new QuanLyDichVu();
            qldv.Show();
        }

        private void saoLưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaoLuuVaPhucHoi slph = new SaoLuuVaPhucHoi();
            slph.Show();
        }
    }
}
