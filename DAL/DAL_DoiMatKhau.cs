using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DoiMatKhau
    {

        // Kiểm tra mật khẩu hiện tại
        public bool KiemTraMatKhauHienTai(string soDienThoai, string matKhauHienTai, string loaiTaiKhoan)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = loaiTaiKhoan == "NhanVien"
                        ? "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai"
                        : "SELECT MatKhau FROM BacSi WHERE SoDT = @SoDienThoai";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        object matKhauLuuTru = cmd.ExecuteScalar();

                        if (matKhauLuuTru == null)
                            return false;

                        // So sánh mật khẩu đã hash
                        return PasswordHasher.VerifyPassword(matKhauHienTai, matKhauLuuTru.ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Log exception here if necessary
                    return false;
                }
            }
        }

        // Kiểm tra mật khẩu mặc định
        public bool KiemTraMatKhauMacDinh(string soDienThoai, bool isBacSi)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = isBacSi
                    ? "SELECT MatKhau FROM BacSi WHERE SoDT = @SoDienThoai"
                    : "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    object matKhau = cmd.ExecuteScalar();
                    return matKhau != null && matKhau.ToString() == "1"; // Kiểm tra mật khẩu mặc định
                }
            }
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(string soDienThoai, string matKhauMoi, bool isBacSi)
        {
            string hashedPassword = PasswordHasher.HashPassword(matKhauMoi);
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = isBacSi
                    ? "UPDATE BacSi SET MatKhau = @MatKhau WHERE SoDT = @SoDienThoai"
                    : "UPDATE NhanVien SET MatKhau = @MatKhau WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MatKhau", hashedPassword);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
                }
            }
        }
    }
}