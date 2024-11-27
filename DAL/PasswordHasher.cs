using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Mã hóa mật khẩu
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển đổi sang chuỗi hex
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        // Kiểm tra mật khẩu
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == storedHash;
        }
    }
}
