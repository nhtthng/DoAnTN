using DocumentFormat.OpenXml.Math;
using DTO;
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
        // Thay đổi các phương thức kiểm tra đăng nhập để sử dụng mã hóa mật khẩu
        public bool KiemTraDangNhapNhanVien(string soDienThoai, string matKhau)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            SELECT MatKhau 
            FROM NhanVien 
            WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string matKhauTrongCSDL = result.ToString();
                        // So sánh mật khẩu đã mã hóa
                        return (matKhauTrongCSDL == matKhau ||
                                matKhauTrongCSDL == PasswordHasher.HashPassword(matKhau));
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đăng nhập nhân viên: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Tương tự cho KiemTraDangNhapBacSi
        public bool KiemTraDangNhapBacSi(string soDienThoai, string matKhau)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            SELECT MatKhau 
            FROM BacSi 
            WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string matKhauTrongCSDL = result.ToString();
                        // So sánh mật khẩu đã mã hóa
                        return (matKhauTrongCSDL == matKhau ||
                                matKhauTrongCSDL == PasswordHasher.HashPassword(matKhau));
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đăng nhập bác sĩ: {ex.Message}");
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

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string matKhau = result.ToString();
                        return (matKhau == "1" || matKhau == PasswordHasher.HashPassword("1"));
                    }
                    return false;
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
        }
        // Lấy thông tin người dùng bằng số điện thoại
        public object LayThongTinNguoiDung(string soDienThoai, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT * FROM NhanVien WHERE SoDT = @SoDienThoai"
                    : "SELECT * FROM BacSi WHERE SoDT = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (loaiTaiKhoan == "NhanVien")
                            {
                                // Thêm dòng debug để kiểm tra
                                Console.WriteLine($"Mã PB từ CSDL: {reader["MaPB"]}");

                                return new DTO_NhanVien
                                {
                                    MaNV = Convert.ToInt32(reader["MaNV"]),
                                    HoTen = reader["HoTen"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    // Quan trọng: Thêm dòng này để lấy MaPB
                                    MaPB = reader["MaPB"] != DBNull.Value
                                           ? Convert.ToInt32(reader["MaPB"])
                                           : 0
                                };
                            }
                            else
                            {
                                return new DTO_QuanLyBacSi
                                {
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    TenBS = reader["TenBS"].ToString(),
                                    SoDT = reader["SoDT"].ToString()
                                };
                            }
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Kiểm tra số điện thoại đã tồn tại chưa
        public bool KiemTraSoDienThoaiTonTai(string soDienThoai, string loaiTaiKhoan)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = loaiTaiKhoan == "NhanVien"
                    ? "SELECT COUNT(*) FROM NhanVien WHERE SoDT  = @SoDienThoai"
                    : "SELECT COUNT(*) FROM BacSi WHERE SoDT  = @SoDienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kiểm tra số điện thoại: {ex.Message}");
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }

    }
}
