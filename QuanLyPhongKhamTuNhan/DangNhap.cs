using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class DangNhap : Form
    {
        BLL_DangNhap _DangNhapBLL = new BLL_DangNhap();
        public DangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cấu hình ComboBox loại tài khoản
            cboLoaiTaiKhoan.Items.Add("NhanVien");
            cboLoaiTaiKhoan.Items.Add("BacSi");
            cboLoaiTaiKhoan.SelectedIndex = 0;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string soDienThoai = txtTaiKhoan.Text;
                string matKhau = txtMauKhau.Text;
                string loaiTaiKhoan = cboLoaiTaiKhoan.SelectedItem.ToString();

                // Kiểm tra đăng nhập
                bool dangNhapThanhCong = _DangNhapBLL.XacThucDangNhap(soDienThoai, matKhau, loaiTaiKhoan);

                if (dangNhapThanhCong)
                {
                    // Kiểm tra nếu là mật khẩu mặc định
                    if (_DangNhapBLL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan))
                    {
                        // Mở form đổi mật khẩu bắt buộc
                        DoiMatKhau frmDoiMK = new DoiMatKhau(soDienThoai, loaiTaiKhoan, true);
                        frmDoiMK.ShowDialog();

                        // Nếu không đổi mật khẩu thì không cho vào hệ thống
                        if (!frmDoiMK.DaDoiMatKhau)
                        {
                            MessageBox.Show("Bạn phải đổi mật khẩu để sử dụng hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Lấy thông tin người dùng
                    object nguoiDung = _DangNhapBLL.LayThongTinNguoiDung(soDienThoai, loaiTaiKhoan);

                    // Mở form chính
                    TrangChu frmTC = new TrangChu(nguoiDung, loaiTaiKhoan);
                    frmTC.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraMatKhauMacDinh(string soDienThoai, string loaiTaiKhoan)
        {
            try
            {
                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai"
                    : "SELECT MatKhau FROM BacSi WHERE SoDT = @SoDienThoai";

                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Kiểm tra nếu mật khẩu là "1" hoặc đã được hash của "1"
                            string matKhau = result.ToString();
                            return (matKhau == "1" || matKhau == PasswordHasher.HashPassword("1"));
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            KiemTraEmail kte = new KiemTraEmail();
            kte.ShowDialog();
        }
    }
}
