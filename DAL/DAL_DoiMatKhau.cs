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

        // Đổi mật khẩu lần đầu
        public bool DoiMatKhauLanDau(string soDienThoai, string matKhauMoi, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai"
                    : "UPDATE BacSi SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    // Mã hóa mật khẩu mới
                    string matKhauMoiMaHoa = PasswordHasher.HashPassword(matKhauMoi);

                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoiMaHoa);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    int ketQua = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return ketQua > 0;
                }
            }
            catch
            {
                transaction?.Rollback();
                return false;
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Đổi mật khẩu các lần sau
        public bool DoiMatKhauThuong(string soDienThoai, string matKhauCu, string matKhauMoi, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // Kiểm tra mật khẩu cũ
                if (!KiemTraMatKhauHienTai(soDienThoai, matKhauCu, loaiTaiKhoan))
                {
                    throw new Exception("Mật khẩu hiện tại không chính xác");
                }

                string query = loaiTaiKhoan == "NhanVien"
                    ? "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai"
                    : "UPDATE BacSi SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    // Mã hóa mật khẩu mới
                    string matKhauMoiMaHoa = PasswordHasher.HashPassword(matKhauMoi);

                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoiMaHoa);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    int ketQua = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return ketQua > 0;
                }
            }
            catch
            {
                transaction?.Rollback();
                return false;
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }

        // Kiểm tra mật khẩu hiện tại
        public bool KiemTraMatKhauHienTai(string soDienThoai, string matKhauHienTai, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
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
            catch
            {
                return false;
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }

        public bool ThucHienDoiMatKhau(string soDienThoai, string matKhauHienTai, string matKhauMoiMaHoa, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai"
                    : "UPDATE BacSi SET MatKhau = @MatKhauMoi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoiMaHoa);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    int ketQua = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return ketQua > 0;
                }
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return false;
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

                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai"
                    : "SELECT MatKhau FROM BacSi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    object matKhau = cmd.ExecuteScalar();

                    // So sánh với mật khẩu mặc định (ví dụ: mã hóa của "1")
                    return matKhau != null &&
                           matKhau.ToString() == /*PasswordHasher.HashPassword(*/"1"/*)*/;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        public bool KiemTraMatKhauMacDinhh(string soDienThoai)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT MatKhau FROM NhanVien WHERE SoDT = @SoDienThoai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    object matKhau = cmd.ExecuteScalar();
                    return matKhau != null && matKhau.ToString() == "1"; // Kiểm tra mật khẩu mặc định
                }
            }
        }
        public bool DoiMatKhau(string soDienThoai, string matKhauMoi)
        {
            string hashedPassword = PasswordHasher.HashPassword(matKhauMoi);
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "UPDATE NhanVien SET MatKhau = @MatKhau WHERE SoDT = @SoDienThoai";
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
