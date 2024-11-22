using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DangNhap
    {
        public int Login(string tenDangNhap, string matKhau, bool isBacSi)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query;
                    if (isBacSi)
                    {
                        // Truy vấn cho Bác sĩ
                        query = @"
                        SELECT COUNT(*) 
                        FROM BacSi 
                        WHERE TenBS = @TenDangNhap 
                        AND MatKhau = @MatKhau";
                    }
                    else
                    {
                        // Truy vấn cho Nhân viên
                        query = @"
                        SELECT COUNT(*) 
                        FROM NhanVien 
                        WHERE HoTen = @TenDangNhap 
                        AND MatKhau = @MatKhau";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Trả về 1 nếu tìm thấy, 0 nếu không tìm thấy
                    return count > 0 ? 1 : 0;
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi
                    Console.WriteLine($"Lỗi đăng nhập: {ex.Message}");
                    return 0;
                }
            }
        }
    }
}
