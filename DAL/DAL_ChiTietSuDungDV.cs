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
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                INSERT INTO CTSDDV 
                (MaLSKB, MaDV, SoLuong, Gia, NgayLap)
                VALUES 
                (@MaLSKB, @MaDV, @SoLuong, @Gia, @NgayLap)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLSKB", chiTiet.MaLSKB);
                    cmd.Parameters.AddWithValue("@MaDV", chiTiet.MaDV);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", chiTiet.Gia);
                    cmd.Parameters.AddWithValue("@NgayLap", chiTiet.NgayLap);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa chi tiết sử dụng dịch vụ
        public bool DeleteChiTietSuDungDV(int maChiTietSDDV)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                DELETE FROM CTSDDV 
                WHERE MaChiTietSDDV = @MaChiTietSDDV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietSDDV", maChiTietSDDV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Sửa chi tiết sử dụng dịch vụ
        public bool UpdateChiTietSuDungDV(DTO_ChiTietSuDungDV chiTiet)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE CTSDDV 
                SET SoLuong = @SoLuong, 
                    Gia = @Gia, 
                    NgayLap = @NgayLap
                WHERE MaChiTietSDDV = @MaChiTietSDDV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietSDDV", chiTiet.MaChiTietSDDV);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", chiTiet.Gia);
                    cmd.Parameters.AddWithValue("@NgayLap", chiTiet.NgayLap);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Tìm kiếm chi tiết sử dụng dịch vụ theo mã lịch khám
        public List<DTO_ChiTietSuDungDV> SearchChiTietSuDungDV(int maLSKB)
        {
            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    MaChiTietSDDV, 
                    MaLSKB, 
                    MaDV, 
                    SoLuong, 
                    Gia, 
                    NgayLap
                FROM CTSDDV 
                WHERE MaLSKB = @MaLSKB";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachChiTiet.Add(new DTO_ChiTietSuDungDV
                            {
                                MaChiTietSDDV = reader.GetInt32(reader.GetOrdinal("MaChiTietSDDV")),
                                MaLSKB = reader.GetInt32(reader.GetOrdinal("MaLSKB")),
                                MaDV = reader.GetInt32(reader.GetOrdinal("MaDV")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"))
                            });
                        }
                    }
                }
            }
            return danhSachChiTiet;
        }
        public List<DTO_ChiTietSuDungDV> GetAllChiTietSuDungDV()
        {
            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    MaChiTietSDDV, 
                    MaLSKB, 
                    MaDV, 
                    SoLuong, 
                    Gia, 
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
                                MaChiTietSDDV = reader.GetInt32(reader.GetOrdinal("MaChiTietSDDV")),
                                MaLSKB = reader.GetInt32(reader.GetOrdinal("MaLSKB")),
                                MaDV = reader.GetInt32(reader.GetOrdinal("MaDV")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"))
                            });
                        }
                    }
                }
            }
            return danhSachChiTiet;
        }
        // Lấy hóa đơn mới nhất của bệnh nhân chưa thanh toán
        public DTO_HoaDon LayHoaDonMoiNhatChuaThanhToan(int maBN)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT TOP 1 MaHD, MaBN, NgayLapHD 
                FROM HoaDon 
                WHERE MaBN = @MaBN AND TrangThai = 'CHUA_HOAN_THANH'
                ORDER BY NgayLapHD DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTO_HoaDon
                            {
                                MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                NgayLapHD = reader.GetDateTime(reader.GetOrdinal("NgayLapHD"))
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy hóa đơn mới nhất: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        public List<DTO_QuanLyBenhNhan> TimBenhNhanTrongLichHen(string soDienThoai)
        {
            List<DTO_QuanLyBenhNhan> danhSachBenhNhan = new List<DTO_QuanLyBenhNhan>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT DISTINCT bn.MaBN, bn.HoTenBN, bn.NgaySinh, bn.GioiTinh, 
                       bn.Email, bn.SoBHYT, bn.SoDT, bn.DiaChi
                FROM BenhNhan bn
                JOIN LichHen lh ON bn.MaBN = lh.MaBN
                WHERE bn.SoDT = @SoDT"; // Loại trừ lịch hẹn bị hủy

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDT", soDienThoai);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan
                            {
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                HoTenBN = reader.GetString(reader.GetOrdinal("HoTenBN")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                SoBHYT = reader.IsDBNull(reader.GetOrdinal("SoBHYT")) ? null : reader.GetString(reader.GetOrdinal("SoBHYT")),
                                SoDT = reader.GetString(reader.GetOrdinal("SoDT")),
                                DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi"))
                            };

                            danhSachBenhNhan.Add(benhNhan);
                        }
                    }
                }

                return danhSachBenhNhan;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm bệnh nhân trong lịch hẹn: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
    }
}
