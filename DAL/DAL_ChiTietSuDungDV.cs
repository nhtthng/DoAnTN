using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietSuDungDV
    {
        // Thêm chi tiết sử dụng dịch vụ
        public bool AddChiTietSuDungDV(DTO_ChiTietSuDungDV chiTiet)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            INSERT INTO CTSDDV 
            (MaHD, MaDV, SoLuong, Gia, MaBN, NgayLap) 
            VALUES 
            (@MaHD, @MaDV, @SoLuong, @Gia, @MaBN, @NgayLap)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", chiTiet.MaHD);
                    cmd.Parameters.AddWithValue("@MaDV", chiTiet.MaDV);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", chiTiet.Gia);
                    cmd.Parameters.AddWithValue("@MaBN", chiTiet.MaBN);
                    cmd.Parameters.AddWithValue("@NgayLap", chiTiet.NgayLap);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm chi tiết sử dụng dịch vụ: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Xóa chi tiết sử dụng dịch vụ
        public bool DeleteChiTietSuDungDV(int maHD, int maDV, int maBN)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            DELETE FROM CTSDDV 
            WHERE MaHD = @MaHD AND MaDV = @MaDV AND MaBN = @MaBN";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@MaDV", maDV);
                    cmd.Parameters.AddWithValue("@MaBN", maBN);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết sử dụng dịch vụ: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Sửa chi tiết sử dụng dịch vụ
        public bool UpdateChiTietSuDungDV(DTO_ChiTietSuDungDV chiTiet)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            UPDATE CTSDDV 
            SET SoLuong = @SoLuong, 
                Gia = @Gia, 
                NgayLap = @NgayLap 
            WHERE MaHD = @MaHD AND MaDV = @MaDV AND MaBN = @MaBN";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", chiTiet.MaHD);
                    cmd.Parameters.AddWithValue("@MaDV", chiTiet.MaDV);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", chiTiet.Gia);
                    cmd.Parameters.AddWithValue("@MaBN", chiTiet.MaBN);
                    cmd.Parameters.AddWithValue("@NgayLap", chiTiet.NgayLap);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi sửa chi tiết sử dụng dịch vụ: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Tìm kiếm chi tiết sử dụng dịch vụ theo mã hóa đơn
        public List<DTO_ChiTietSuDungDV> SearchChiTietSuDungDV(int maBN)
        {
            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            SELECT 
                MaHD, 
                MaDV, 
                SoLuong, 
                Gia, 
                MaBN, 
                NgayLap 
            FROM CTSDDV 
            WHERE MaBN = @MaBN";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachChiTiet.Add(new DTO_ChiTietSuDungDV
                            {
                                MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                                MaDV = reader.GetInt32(reader.GetOrdinal("MaDV")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"))
                            });
                        }
                    }
                }

                return danhSachChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm chi tiết sử dụng dịch vụ theo mã bệnh nhân: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        public List<DTO_ChiTietSuDungDV> GetAllChiTietSuDungDV()
        {
            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
            SELECT 
                MaHD, 
                MaDV, 
                SoLuong, 
                Gia, 
                MaBN, 
                NgayLap 
            FROM CTSDDV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachChiTiet.Add(new DTO_ChiTietSuDungDV
                            {
                                MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                                MaDV = reader.GetInt32(reader.GetOrdinal("MaDV")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"))
                            });
                        }
                    }
                }

                return danhSachChiTiet;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách chi tiết sử dụng dịch vụ: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
    }
}
