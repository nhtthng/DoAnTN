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

        public bool DoiMatKhau(string soDienThoai, string matKhauCu, string matKhauMoi, string loaiTaiKhoan)
        {
            // Kiểm tra mật khẩu hiện tại nếu không phải lần đầu
            if (!string.IsNullOrWhiteSpace(matKhauCu))
            {
                bool kiemTraMatKhauCu = _DoiMatKhauDAL.KiemTraMatKhauHienTai(soDienThoai, matKhauCu, loaiTaiKhoan);
                if (!kiemTraMatKhauCu)
                {
                    return false; // Mật khẩu cũ không đúng
                }
            }

            // Thực hiện đổi mật khẩu
            return _DoiMatKhauDAL.DoiMatKhau(soDienThoai, matKhauMoi, loaiTaiKhoan == "BacSi");
        }

        // Kiểm tra xem có phải lần đầu đăng nhập không
        public bool LaLanDauDangNhap(string soDienThoai, string loaiTaiKhoan)
        {
            return _DoiMatKhauDAL.KiemTraMatKhauMacDinh(soDienThoai, loaiTaiKhoan == "BacSi");
        }

        // Phương thức đổi mật khẩu không cần mật khẩu cũ (dành cho lần đầu đăng nhập)
        public bool DoiMatKhauLanDau(string soDienThoai, string matKhauMoi, bool isBacSi)
        {
            return _DoiMatKhauDAL.DoiMatKhau(soDienThoai, matKhauMoi, isBacSi);
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
            bool coChuHoa = matKhau.Any(char.IsUpper);
            bool coChuThuong = matKhau.Any(char.IsLower);
            bool coSo = matKhau.Any(char.IsDigit);

            if (!coKyTuDacBiet)
                throw new Exception("Mật khẩu phải chứa ít nhất một ký tự đặc biệt");

            if (!coChuHoa)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ hoa");

            if (!coChuThuong)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ thường");

            if (!coSo)
                throw new Exception("Mật khẩu phải chứa ít nhất một chữ số");

            return true;
        }
    }
}