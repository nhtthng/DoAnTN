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
        private bool ValidateLogin(string hoTen, string password)
        {
            // Kiểm tra tên đăng nhập không được để trống
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống.");
            }

            // Kiểm tra mật khẩu không được để trống
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Mật khẩu không được để trống.");
            }

            // Kiểm tra độ dài tên đăng nhập
            if (hoTen.Length < 3 || hoTen.Length > 50)
            {
                throw new ArgumentException("Tên đăng nhập phải từ 3 đến 50 ký tự.");
            }

            // Kiểm tra độ dài mật khẩu
            if (password.Length < 6 || password.Length > 20)
            {
                throw new ArgumentException("Mật khẩu phải từ 6 đến 20 ký tự.");
            }

            return true;
        }
        // Phương thức đăng nhập chính
        public int Login(string hoTen, string password, bool isBacSi)
        {
            try
            {
                // Validate đầu vào
                if (!ValidateLogin(hoTen, password))
                {
                    return -1;
                }

                // Gọi phương thức từ DAL để thực hiện đăng nhập
                return _DangNhapDAL.Login(hoTen, password, isBacSi);
            }
            catch (ArgumentException ex)
            {
                // Xử lý các ngoại lệ validate
                Console.WriteLine($"Lỗi validate: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                Console.WriteLine($"Lỗi đăng nhập: {ex.Message}");
                return -1;
            }
        }
    }
}
