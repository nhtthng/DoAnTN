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
        private string _soDienThoai;
        private string _loaiTaiKhoan;
        private bool _batBuocDoiMK;
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
            if (KiemTraLanDauDangNhap() || batBuocDoiMK)
            {
                this.Text = "Đổi Mật Khẩu Bắt Buộc";
                //txtBoxMatKhauCu.Enabled = false; // Vô hiệu hóa ô nhập mật khẩu cũ
                //this.ControlBox = false; // Vô hiệu hóa nút đóng
            }
        }
        private bool KiemTraMatKhau(string matKhau)
        {
            // Kiểm tra độ dài tối đa
            if (matKhau.Length > 100)
            {
                MessageBox.Show("Mật khẩu quá dài. Vui lòng chọn mật khẩu ngắn hơn.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra độ dài tối thiểu
            if (matKhau.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra các điều kiện về mật khẩu
            bool coKyTuDacBiet = matKhau.Any(c => !char.IsLetterOrDigit(c));
            bool coChữHoa = matKhau.Any(char.IsUpper);
            bool coChữThường = matKhau.Any(char.IsLower);
            bool coSo = matKhau.Any(char.IsDigit);

            // Chi tiết các yêu cầu về mật khẩu
            if (!coKyTuDacBiet)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một ký tự đặc biệt.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!coChữHoa)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ hoa.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!coChữThường)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ thường.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!coSo)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ số.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có phải lần đầu đăng nhập không
                bool laLanDauDangNhap = BLL_DoiMatKhau.LaLanDauDangNhap(_soDienThoai, _loaiTaiKhoan);

                if (laLanDauDangNhap)
                {
                    // Ẩn textbox mật khẩu cũ
                    txtBoxMatKhauCu.Visible = false;
                    //lblMatKhauCu.Visible = false;

                    // Bắt buộc nhập mật khẩu mới
                    if (string.IsNullOrWhiteSpace(txtBoxMatKhauMoi.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu mới");
                        return;
                    }

                    // Thực hiện đổi mật khẩu
                    bool ketQua = BLL_DoiMatKhau.ThucHienDoiMatKhau(
                        _soDienThoai,
                        "",
                        txtBoxMatKhauMoi.Text,
                        _loaiTaiKhoan,
                        true
                    );
                }
                else
                {
                    // Hiển thị textbox mật khẩu cũ
                    txtBoxMatKhauCu.Visible = true;
                    //lblMatKhauCu.Visible = true;

                    // Kiểm tra đầy đủ thông tin
                    if (string.IsNullOrWhiteSpace(txtBoxMatKhauCu.Text) ||
                        string.IsNullOrWhiteSpace(txtBoxMatKhauMoi.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                        return;
                    }

                    // Thực hiện đổi mật khẩu
                    bool ketQua = BLL_DoiMatKhau.ThucHienDoiMatKhau(
                        _soDienThoai,
                        txtBoxMatKhauCu.Text,
                        txtBoxMatKhauMoi.Text,
                        _loaiTaiKhoan,
                        false
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Phương thức kiểm tra lần đầu đăng nhập
        private bool KiemTraLanDauDangNhap()
        {
            try
            {
                // Kiểm tra xem đây có phải là lần đầu đăng nhập 
                // hoặc mật khẩu có phải là mật khẩu mặc định không
                return BLL_DoiMatKhau.KiemTraMatKhauMacDinh(_soDienThoai, _loaiTaiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show($"Lỗi kiểm tra mật khẩu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Ghi đè phương thức đóng form để kiểm soát việc đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Nếu là bắt buộc đổi mật khẩu nhưng chưa đổi
            if (_batBuocDoiMK && !DaDoiMatKhau)
            {
                e.Cancel = true;
                MessageBox.Show("Bạn phải đổi mật khẩu để sử dụng hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            base.OnFormClosing(e);
        }
    }
}
