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
        public bool DaDoiMatKhau { get; private set; } = false;

        public DoiMatKhau(string soDienThoai, string loaiTaiKhoan, bool batBuocDoiMK = false)
        {
            InitializeComponent();
            _soDienThoai = soDienThoai;
            _loaiTaiKhoan = loaiTaiKhoan;
            _batBuocDoiMK = batBuocDoiMK;

            CauHinhFormDoiMatKhau();
            DangKyKienSuKien();
        }

        private void CauHinhFormDoiMatKhau()
        {
            bool laLanDauDangNhap = BLL_DoiMatKhau.LaLanDauDangNhap(_soDienThoai, _loaiTaiKhoan);

            if (laLanDauDangNhap || _batBuocDoiMK)
            {
                Text = "Đổi Mật Khẩu Bắt Buộc";
                txtBoxMatKhauCu.Enabled = !laLanDauDangNhap;
                txtBoxMatKhauCu.Visible = !laLanDauDangNhap;

                if (_batBuocDoiMK)
                {
                    ControlBox = false; // Vô hiệu hóa nút đóng
                }
            }
        }

        private void DangKyKienSuKien()
        {
            btnDoiMK.Click += btnDoiMK_Click;
        }

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

            bool laLanDauDangNhap = BLL_DoiMatKhau.LaLanDauDangNhap(_soDienThoai, _loaiTaiKhoan);
            bool ketQua;

            if (laLanDauDangNhap)
            {
                // Đổi mật khẩu lần đầu không cần mật khẩu cũ
                ketQua = BLL_DoiMatKhau.DoiMatKhauLanDau(_soDienThoai, txtBoxMatKhauMoi.Text, _loaiTaiKhoan == "BacSi");
            }
            else
            {
                // Kiểm tra mật khẩu hiện tại
                if (string.IsNullOrWhiteSpace(txtBoxMatKhauCu.Text))
                {
                    HienThiThongBaoLoi("Vui lòng nhập mật khẩu hiện tại");
                    return;
                }

                // Đổi mật khẩu thông thường
                ketQua = BLL_DoiMatKhau.DoiMatKhau(_soDienThoai, txtBoxMatKhauCu.Text, txtBoxMatKhauMoi.Text, _loaiTaiKhoan);
            }

            XuLyKetQuaDoiMatKhau(ketQua);
        }

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

        private void HienThiThongBaoLoi(string thongBao)
        {
            MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HienThiThongBaoThanhCong(string thongBao)
        {
            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool KiemTraXacNhanMatKhau(string matKhauMoi, string matKhauXacNhan)
        {
            return matKhauMoi == matKhauXacNhan;
        }

        private bool KiemTraMatKhau(string matKhau)
        {
            try
            {
                // Gọi phương thức ValidateMatKhau từ BLL_DoiMatKhau
                return BLL_DoiMatKhau.ValidateMatKhau(matKhau);
            }
            catch (Exception ex)
            {
                HienThiThongBaoLoi(ex.Message);
                return false;
            }
        }
    }
}