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
                throw new Exception("Mật khẩu không đáp ứng yêu cầu an toàn");
            }

            // Nếu là lần đầu đăng nhập
            if (laLanDauDangNhap)
            {
                // Kiểm tra mật khẩu mặc định
                if (!_DoiMatKhauDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan))
                {
                    throw new Exception("Không được phép đổi mật khẩu");
                }

                // Mã hóa mật khẩu mới
                string matKhauMoiMaHoa = PasswordHasher.HashPassword(matKhauMoi);

                // Đổi mật khẩu với mật khẩu mặc định
                return _DoiMatKhauDAL.ThucHienDoiMatKhau(
                    soDienThoai,
                    "1",  // Mật khẩu mặc định 
                    matKhauMoiMaHoa,
                    loaiTaiKhoan
                );
            }
            // Các lần đăng nhập sau
            else
            {
                // Kiểm tra mật khẩu cũ
                if (!_DoiMatKhauDAL.KiemTraMatKhauCu(soDienThoai, matKhauCu, loaiTaiKhoan))
                {
                    throw new Exception("Mật khẩu cũ không chính xác");
                }

                // Mã hóa mật khẩu mới
                string matKhauMoiMaHoa = PasswordHasher.HashPassword(matKhauMoi);

                // Đổi mật khẩu
                return _DoiMatKhauDAL.ThucHienDoiMatKhau(
                    soDienThoai,
                    matKhauCu,
                    matKhauMoiMaHoa,
                    loaiTaiKhoan
                );
            }
        }
        // Validate mật khẩu
        private bool ValidateMatKhau(string matKhau)
        {
            // Kiểm tra độ dài
            if (matKhau.Length < 6)
            {
                return false;
            }

            // Kiểm tra có chứa ký tự hoa
            bool coKyTuHoa = matKhau.Any(char.IsUpper);

            // Kiểm tra có chứa ký tự số
            bool coKyTuSo = matKhau.Any(char.IsDigit);

            // Kiểm tra có ký tự đặc biệt
            bool coKyTuDacBiet = matKhau.Any(c => !char.IsLetterOrDigit(c));

            return coKyTuHoa && coKyTuSo && coKyTuDacBiet;
        }
        // Phương thức kiểm tra mật khẩu mặc định
        public bool KiemTraMatKhauMacDinh(string soDienThoai, string loaiTaiKhoan)
        {
            return _DoiMatKhauDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan);
        }
    }
}
