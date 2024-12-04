using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyNhanVien
    {
        // Lấy tất cả nhân viên
        public List<DTO_NhanVien> GetAllNhanVien()
        {
            List<DTO_NhanVien> danhSachNhanVien = new List<DTO_NhanVien>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT MaNV, HoTen, GioiTinh, NgaySinh, SoDT, MaPB, MatKhau 
                FROM NhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_NhanVien nhanVien = new DTO_NhanVien
                            {
                                MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                SoDT = reader.GetString(reader.GetOrdinal("SoDT")),
                                MaPB = reader.GetInt32(reader.GetOrdinal("MaPB")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                //Quyen = reader.GetInt32(reader.GetOrdinal("Quyen"))
                            };

                            danhSachNhanVien.Add(nhanVien);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return danhSachNhanVien;
        }
        // Thêm nhân viên mới
        public bool AddNhanVien(DTO_NhanVien nhanVien)
        {
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                INSERT INTO NhanVien 
                (HoTen, GioiTinh, NgaySinh, SoDT, MaPB, MatKhau) 
                VALUES 
                (@HoTen, @GioiTinh, @NgaySinh, @SoDT, @MaPB, 1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                    cmd.Parameters.AddWithValue("@SoDT", nhanVien.SoDT);
                    cmd.Parameters.AddWithValue("@MaPB", nhanVien.MaPB);
                    //cmd.Parameters.AddWithValue("@Quyen", nhanVien.Quyen);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(DTO_NhanVien nhanVien)
        {
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                UPDATE NhanVien 
                SET HoTen = @HoTen, 
                    GioiTinh = @GioiTinh, 
                    NgaySinh = @NgaySinh, 
                    SoDT = @SoDT, 
                    MaPB = @MaPB, 
                    MatKhau = @MatKhau 
                WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                    cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                    cmd.Parameters.AddWithValue("@SoDT", nhanVien.SoDT);
                    cmd.Parameters.AddWithValue("@MaPB", nhanVien.MaPB);
                    cmd.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);
                    //cmd.Parameters.AddWithValue("@Quyen", nhanVien.Quyen);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Xóa nhân viên
        public bool DeleteNhanVien(int maNV)
        {
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Tìm kiếm nhân viên theo số điện thoại
        public List<DTO_NhanVien> SearchNhanVienBySDT(string soDT)
        {
            List<DTO_NhanVien> danhSachNhanVien = new List<DTO_NhanVien>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT MaNV, HoTen, GioiTinh, NgaySinh, SoDT, MaPB, MatKhau
                FROM NhanVien 
                WHERE SoDT LIKE @SoDT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDT", $"%{soDT}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_NhanVien nhanVien = new DTO_NhanVien
                            {
                                MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                SoDT = reader.GetString(reader.GetOrdinal("SoDT")),
                                MaPB = reader.GetInt32(reader.GetOrdinal("MaPB")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                //Quyen = reader.GetInt32(reader.GetOrdinal("Quyen"))
                            };

                            danhSachNhanVien.Add(nhanVien);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return danhSachNhanVien;
        }

    }
}
