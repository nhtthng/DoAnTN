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
        public bool ThucHienDoiMatKhau(string soDienThoai, string matKhauCu, string matKhauMoi, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai AND MatKhau = @MatKhauCu"
                    : "UPDATE BacSi SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai AND MatKhau = @MatKhauCu";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);
                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                    // Thực thi và kiểm tra số dòng bị ảnh hưởng
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Nếu không có dòng nào bị ảnh hưởng, nghĩa là mật khẩu cũ không đúng
                    if (rowsAffected == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // Commit giao dịch
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Rollback giao dịch nếu có lỗi
                transaction?.Rollback();
                throw new Exception($"Lỗi đổi mật khẩu: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Kiểm tra mật khẩu cũ có đúng không
        public bool KiemTraMatKhauCu(string soDienThoai, string matKhauCu, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT COUNT(*) FROM NhanVien WHERE SoDT = @SoDienThoai AND MatKhau = @MatKhauCu"
                    : "SELECT COUNT(*) FROM BacSi WHERE SoDT = @SoDienThoai AND MatKhau = @MatKhauCu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kiểm tra mật khẩu: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Thêm phương thức kiểm tra mật khẩu mặc định
        public bool KiemTraMatKhauMacDinh(string soDienThoai, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                // Truy vấn để lấy mật khẩu hiện tại
                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai"
                    : "SELECT MatKhau FROM BacSi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string matKhauHienTai = result.ToString();

                        // Danh sách mật khẩu mặc định 
                        string[] matKhauMacDinh = new string[]
                        {
                        "123456",           // Mật khẩu gốc
                        "12345678",
                        "password",
                         "1"   // Thêm các mật khẩu mặc định khác nếu cần
                        };

                        // Kiểm tra mật khẩu hiện tại có nằm trong danh sách mật khẩu mặc định không
                        return matKhauMacDinh.Contains(matKhauHienTai);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kiểm tra mật khẩu mặc định: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return false;
        }
    }
}
