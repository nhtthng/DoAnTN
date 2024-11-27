using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DangNhap
    {
        private DAL_DangNhap _DangNhapDAL = new DAL_DangNhap();
        // Xác thực đăng nhập
        public bool XacThucDangNhap(string soDienThoai, string matKhau, string loaiTaiKhoan)
        {
            // Validate số điện thoại
            if (!KiemTraDinhDangSoDienThoai(soDienThoai))
            {
                throw new Exception("Số điện thoại không đúng định dạng");
            }

            // Kiểm tra đăng nhập theo loại tài khoản
            switch (loaiTaiKhoan)
            {
                case "NhanVien":
                    return _DangNhapDAL.KiemTraDangNhapNhanVien(soDienThoai, matKhau);
                case "BacSi":
                    return _DangNhapDAL.KiemTraDangNhapBacSi(soDienThoai, matKhau);
                default:
                    throw new Exception("Loại tài khoản không hợp lệ");
            }
        }
        // Kiểm tra mật khẩu mặc định
        public bool KiemTraMatKhauMacDinh(string soDienThoai, string loaiTaiKhoan)
        {
            return _DangNhapDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan);
        }

        // Lấy thông tin người dùng
        public object LayThongTinNguoiDung(string soDienThoai, string loaiTaiKhoan)
        {
            return _DangNhapDAL.LayThongTinNguoiDung(soDienThoai, loaiTaiKhoan);
        }
        // Validate định dạng số điện thoại
        private bool KiemTraDinhDangSoDienThoai(string soDienThoai)
        {
            // Regex kiểm tra số điện thoại Việt Nam
            string pattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            return System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, pattern);
        }
        // Kiểm tra số điện thoại đã tồn tại
        public bool KiemTraSoDienThoaiTonTai(string soDienThoai, string loaiTaiKhoan)
        {
            return _DangNhapDAL.KiemTraSoDienThoaiTonTai(soDienThoai, loaiTaiKhoan);
        }
        // Thêm phương thức mã hóa mật khẩu nếu cần
        public string MaHoaMatKhau(string matKhau)
        {
            // Sử dụng phương pháp mã hóa an toàn như MD5 hoặc BCrypt
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(matKhau);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi byte sang chuỗi hex
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
