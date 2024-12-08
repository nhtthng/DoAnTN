using DTO;
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

        public TrangChu(object nguoiDung, string loaiTaiKhoan)
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            //ConfigureMenu(); // Gọi phương thức để cấu hình menu
            // Nếu là nhân viên, kiểm tra phòng ban
            this.Tag = nguoiDung;
            if (nguoiDung is DTO_NhanVien nhanVien)
            {
                int maPB = nhanVien.MaPB;
                MessageBox.Show($"Mã phòng ban: {maPB}");

                CauHinhMenuNhanVien(maPB);
            }
            else if (loaiTaiKhoan == "BacSi")
            {
                HienThiMenuBacSi();
            }
            // Tạo MenuStrip
            //MenuStrip menuStrip = new MenuStrip();
            //this.MainMenuStrip = menuStrip; // Gán cho form
            //this.Controls.Add(menuStrip); // Thêm vào form

            // Tạo mục menu "Khám Bệnh"
            //ToolStripMenuItem khamBenhMenuItem = new ToolStripMenuItem("Khám Bệnh");

            //// Tạo menu con "CTSDDV"
            //ToolStripMenuItem ctSDDVMenuItem = new ToolStripMenuItem("CTSDDV");

            //// Thêm menu con vào mục "Khám Bệnh"
            //khámBệnhToolStripMenuItem.DropDownItems.Add(ctSDDVMenuItem);

            //// Thêm mục "Khám Bệnh" vào menuStrip
            ////menuStrip.Items.Add(khamBenhMenuItem);

            //// Xử lý sự kiện click cho CTSDDV
            //ctSDDVMenuItem.Click += (sender, e) =>
            //{
            //    ChiTietSuDungDV formChiTiet = new ChiTietSuDungDV();
            //    formChiTiet.Show(); // Mở form chi tiết
            //};
        }

        private void CauHinhMenuNhanVien(int maPB)
        {

            // Thêm dòng debug để kiểm tra giá trị maPB
            //MessageBox.Show($"Mã phòng ban: {maPB}");

            // Ẩn tất cả các menu trước
            HideAllMenus();

            switch (maPB)
            {
                case 1: // Phòng ban Quản lý
                    //MessageBox.Show("Đang gọi HienThiMenuQuanLy()");
                    HienThiMenuQuanLy();
                    break;

                case 2: // Phòng ban Kinh Doanh
                    //MessageBox.Show("Đang gọi HienThiMenuKinhDoanh()");
                    HienThiMenuKinhDoanh();
                    break;

                default:
                    MessageBox.Show($"Không xác định được phòng ban: {maPB}");
                    break;
            }
        }
        private void HideAllMenus()
        {
            // Ẩn tất cả các menu
            hệThongToolStripMenuItem.Enabled = false;
            danhMụcToolStripMenuItem.Enabled = false;
            tiếpNhậnToolStripMenuItem.Enabled = false;
            khámBệnhToolStripMenuItem.Enabled = false;
            lịchHẹnToolStripMenuItem.Enabled = false;
            KeThuocMenuItem1.Enabled = false;
            HoaDoaStripMenuItem1.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;
        }
        private void HienThiMenuBacSi()
        {
            danhMụcToolStripMenuItem.Enabled = false;
            tiếpNhậnToolStripMenuItem.Enabled = false;
            HoaDoaStripMenuItem1.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;

            hệThongToolStripMenuItem.Enabled = true;
            khámBệnhToolStripMenuItem.Enabled = true;
            //lịchHẹnToolStripMenuItem.Enabled = true;
            KeThuocMenuItem1.Enabled = true;
            saoLưuToolStripMenuItem.Enabled = false;
        }
        private void HienThiMenuKinhDoanh()
        {
            hệThongToolStripMenuItem.Enabled = true;
            báoCáoToolStripMenuItem.Enabled = true;
            saoLưuToolStripMenuItem.Enabled = false;
        }
        private void HienThiMenuQuanLy()
        {
            hệThongToolStripMenuItem.Enabled = true;
            danhMụcToolStripMenuItem.Enabled = true;
            báoCáoToolStripMenuItem.Enabled = true;
            HoaDoaStripMenuItem1.Enabled = true;
            KeThuocMenuItem1.Enabled = true;
            tiếpNhậnToolStripMenuItem.Enabled = true;
            lịchHẹnToolStripMenuItem.Enabled = true;
            khámBệnhToolStripMenuItem.Enabled = true;

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

            // Đặt form TrangChu ở chế độ toàn màn hình
            this.WindowState = FormWindowState.Maximized;






        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Nếu chọn Yes thì thoát hoàn toàn
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                Environment.Exit(0); // Đảm bảo thoát hoàn toàn
            }
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
            BaoCao bc = new BaoCao();
            bc.Show();
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

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có thông tin người dùng chưa
            if (this.Tag is DTO_NhanVien nhanVien)
            {
                // Nếu là nhân viên
                DoiMatKhau dmk = new DoiMatKhau(nhanVien.SoDT, "NhanVien", true);
                dmk.Show();
            }
            else if (this.Tag is DTO_QuanLyBacSi bacSi)
            {
                // Nếu là bác sĩ
                DoiMatKhau dmk = new DoiMatKhau(bacSi.SoDT, "BacSi", true);
                dmk.Show();
            }
            else
            {
                // Trường hợp không xác định được người dùng
                MessageBox.Show("Không thể xác định thông tin người dùng. Vui lòng đăng nhập lại.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cTSDDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietSuDungDV ctsddv = new ChiTietSuDungDV();
            ctsddv.Show();
        }

        private void khámBệnhToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cTSDDVToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChiTietSuDungDV ctsddv = new ChiTietSuDungDV();
            ctsddv.Show();
        }

        private void khámBệnhToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void lSKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhamBenh kb = new KhamBenh();
            kb.Show();
        }

        private void bácSĩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyBacSi qlbs = new QuanLyBacSi();
            qlbs.Show();
        }
    }
}
