using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
    public class BLL_DoiMatKhau
    {
        private DAL_DoiMatKhau _DoiMatKhauDAL = new DAL_DoiMatKhau();

        // Kiểm tra xem có phải lần đầu đăng nhập không
        public bool LaLanDauDangNhap(string soDienThoai, string loaiTaiKhoan)
        {
            // Sử dụng phương thức kiểm tra mật khẩu mặc định
            return _DoiMatKhauDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan);
        }

        // Phương thức thực hiện đổi mật khẩu
        public bool ThucHienDoiMatKhau(
        string soDienThoai,
        string matKhauCu,
        string matKhauMoi,
        string loaiTaiKhoan,
        bool laLanDauDangNhap)
        {
            // Validate mật khẩu mới
            if (!ValidateMatKhau(matKhauMoi))
            {
                throw new Exception("Mật khẩu không đáp ứng các yêu cầu an toàn");
            }

            // Xử lý logic cho lần đầu đăng nhập
            if (laLanDauDangNhap)
            {
                // Kiểm tra xem có phải mật khẩu mặc định không
                if (!KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan))
                {
                    throw new Exception("Không phải lần đầu đăng nhập");
                }

                // Đổi mật khẩu lần đầu không cần kiểm tra mật khẩu cũ
                return _DoiMatKhauDAL.DoiMatKhauLanDau(soDienThoai, matKhauMoi, loaiTaiKhoan);
            }
            else
            {
                // Các lần đổi mật khẩu sau
                // Kiểm tra mật khẩu cũ
                if (string.IsNullOrWhiteSpace(matKhauCu))
                {
                    throw new Exception("Vui lòng nhập mật khẩu hiện tại");
                }

                return _DoiMatKhauDAL.DoiMatKhauThuong(
                    soDienThoai,
                    matKhauCu,
                    matKhauMoi,
                    loaiTaiKhoan
                );
            }
        }

        // Validate mật khẩu
        public bool ValidateMatKhau(string matKhau)
        {
            // Kiểm tra độ dài
            if (matKhau.Length < 8 || matKhau.Length > 100)
            {
                throw new Exception("Mật khẩu phải từ 8 đến 100 ký tự");
            }

            // Kiểm tra các điều kiện
            bool coKyTuDacBiet = matKhau.Any(c => !char.IsLetterOrDigit(c));
            bool coChữHoa = matKhau.Any(char.IsUpper);
            bool coChữThường = matKhau.Any(char.IsLower);
            bool coSo = matKhau.Any(char.IsDigit);

            if (!coKyTuDacBiet)
                throw new Exception("Mật khẩu phải chứa ít nhất một ký tự đặc biệt");

            if (!coChữHoa)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ hoa");

            if (!coChữThường)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ thường");

            if (!coSo)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ số");

            return true;
        }
        // Phương thức kiểm tra mật khẩu mặc định
        public bool KiemTraMatKhauMacDinh(string soDienThoai, string loaiTaiKhoan)
        {
            return _DoiMatKhauDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan);
        }
    }
}
