using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using BLL;
using DAL;

namespace GUI
{
    public partial class DoiMatKhau : Form
    {
        private readonly string _soDienThoai;
        private readonly string _loaiTaiKhoan;
        private readonly bool _batBuocDoiMK;
        private BLL_DoiMatKhau BLL_DoiMatKhau = new BLL_DoiMatKhau();
        // Thuộc tính để kiểm tra đã đổi mật khẩu chưa
        public bool DaDoiMatKhau { get; private set; } = false;
        public DoiMatKhau(string soDienThoai, string loaiTaiKhoan, bool batBuocDoiMK = false)
        {
            InitializeComponent();
            _soDienThoai = soDienThoai;
            _loaiTaiKhoan = loaiTaiKhoan;
            _batBuocDoiMK = batBuocDoiMK;
            // Cấu hình form nếu là bắt buộc đổi mật khẩu
            //CauHinhFormDoiMatKhau();
            DangKyKienSuKien();
        }

        //private void CauHinhFormDoiMatKhau()
        //{
        //    bool laLanDauDangNhap = KiemTraLanDauDangNhap();

        //    if (laLanDauDangNhap || _batBuocDoiMK)
        //    {
        //        Text = "Đổi Mật Khẩu Bắt Buộc";
        //        txtBoxMatKhauCu.Enabled = !laLanDauDangNhap;
        //        txtBoxMatKhauCu.Visible = !laLanDauDangNhap;

        //        if (_batBuocDoiMK)
        //        {
        //            ControlBox = false; // Vô hiệu hóa nút đóng
        //        }
        //    }
        //}

        private void DangKyKienSuKien()
        {
            btnDoiMK.Click += btnDoiMK_Click;
            //txtBoxMatKhauMoi.TextChanged += txtBoxMatKhauMoi_TextChanged;
        }

        //private bool KiemTraMatKhau(string matKhau)
        //{
        //    try
        //    {
        //        return BLL_DoiMatKhau.ValidateMatKhau(matKhau);
        //    }
        //    catch (Exception ex)
        //    {
        //        HienThiThongBaoLoi(ex.Message);
        //        return false;
        //    }
        //}


        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            // Kiểm tra mật khẩu mới
            if (!KiemTraMatKhau(txtBoxMatKhauMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ.");
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (!KiemTraXacNhanMatKhau(txtBoxMatKhauMoi.Text, txtBoxXacNhanMKM.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            //DoiMatKhauBLL doiMatKhauBLL = new DoiMatKhauBLL();
            bool laLanDauDangNhap = BLL_DoiMatKhau.LaLanDauDangNhapp(_soDienThoai);

            if (laLanDauDangNhap)
            {
                // Nếu là lần đầu đăng nhập, bắt buộc đổi mật khẩu
                bool ketQua = BLL_DoiMatKhau.DoiMatKhau(_soDienThoai, txtBoxMatKhauMoi.Text);
                if (ketQua)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng thử lại.");
                }
            }
            else
            {
                // Nếu không phải lần đầu, chỉ cần thực hiện đổi mật khẩu
                bool ketQua = BLL_DoiMatKhau.DoiMatKhau(_soDienThoai, txtBoxMatKhauMoi.Text);
                if (ketQua)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng thử lại.");
                }
            }
        }

        private bool KiemTraXacNhanMatKhau()
        {
            if (txtBoxMatKhauMoi.Text != txtBoxXacNhanMKM.Text)
            {
                HienThiThongBaoLoi("Mật khẩu xác nhận không khớp!");
                return false;
            }
            return true;
        }

        //private bool ThucHienDoiMatKhau(bool laLanDauDangNhap)
        //{
        //    if (laLanDauDangNhap)
        //    {
        //        // Đổi mật khẩu lần đầu
        //        return BLL_DoiMatKhau.ThucHienDoiMatKhau(
        //            _soDienThoai,
        //            "",
        //            txtBoxMatKhauMoi.Text,
        //            _loaiTaiKhoan,
        //            true
        //        );
        //    }
        //    else
        //    {
        //        // Kiểm tra mật khẩu hiện tại
        //        if (string.IsNullOrWhiteSpace(txtBoxMatKhauCu.Text))
        //        {
        //            HienThiThongBaoLoi("Vui lòng nhập mật khẩu hiện tại");
        //            return false;
        //        }

        //        // Đổi mật khẩu các lần sau
        //        return BLL_DoiMatKhau.ThucHienDoiMatKhau(
        //            _soDienThoai,
        //            txtBoxMatKhauCu.Text,
        //            txtBoxMatKhauMoi.Text,
        //            _loaiTaiKhoan,
        //            false
        //        );
        //    }
        //}

        private void XuLyKetQuaDoiMatKhau(bool ketQua)
        {
            if (ketQua)
            {
                DaDoiMatKhau = true;
                HienThiThongBaoThanhCong("Đổi mật khẩu thành công!");
                Close();
            }
            else
            {
                HienThiThongBaoLoi("Đổi mật khẩu thất bại. Vui lòng thử lại.");
            }
        }

        // Phương thức kiểm tra lần đầu đăng nhập
        //private bool KiemTraLanDauDangNhap()
        //{
        //    try
        //    {
        //        return BLL_DoiMatKhau.KiemTraMatKhauMacDinh(_soDienThoai, _loaiTaiKhoan);
        //    }
        //    catch (Exception ex)
        //    {
        //        HienThiThongBaoLoi($"Lỗi kiểm tra mật khẩu: {ex.Message}");
        //        return false;
        //    }
        //}

        // Ghi đè phương thức đóng form để kiểm soát việc đóng form
        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (_batBuocDoiMK && !DaDoiMatKhau)
        //    {
        //        e.Cancel = true;
        //        HienThiThongBaoLoi("Bạn phải đổi mật khẩu để sử dụng hệ thống!");
        //    }
        //    base.OnFormClosing(e);
        //}

        //private void txtBoxMatKhauMoi_TextChanged(object sender, EventArgs e)
        //{
        //    KiemTraMatKhau(txtBoxMatKhauMoi.Text);
        //}
        // Các phương thức hỗ trợ hiển thị thông báo
        private void HienThiThongBaoLoi(string thongBao)
        {
            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void HienThiThongBaoThanhCong(string thongBao)
        {
            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Phương thức kiểm tra xác nhận mật khẩu
        private bool KiemTraXacNhanMatKhau(string matKhauMoi, string matKhauXacNhan)
        {
            return matKhauMoi == matKhauXacNhan;
        }

        // Phương thức kiểm tra tính hợp lệ của mật khẩu mới
        private bool KiemTraMatKhau(string matKhau)
        {
            // Kiểm tra độ dài hoặc quy tắc mật khẩu khác
            return matKhau.Length >= 6; // Ví dụ: mật khẩu phải có ít nhất 6 ký tự
        }
    }
}
