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
        // Tìm kiếm bệnh nhân theo số điện thoại
        public List<DTO_QuanLyBenhNhan> TimBenhNhanTheoSoDienThoai(string soDienThoai)
        {
            List<DTO_QuanLyBenhNhan> danhSachBenhNhan = new List<DTO_QuanLyBenhNhan>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    MaBN, HoTenBN, NgaySinh, GioiTinh, Email, SoBHYT, SoDT, DiaChi
                FROM BenhNhan
                WHERE SoDT = @SoDT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDT", soDienThoai);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachBenhNhan.Add(new DTO_QuanLyBenhNhan
                            {
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                HoTenBN = reader.GetString(reader.GetOrdinal("HoTenBN")),
                                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                                GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                SoBHYT = reader.IsDBNull(reader.GetOrdinal("SoBHYT")) ? null : reader.GetString(reader.GetOrdinal("SoBHYT")),
                                SoDT = reader.GetString(reader.GetOrdinal("SoDT")),
                                DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : reader.GetString(reader.GetOrdinal("DiaChi"))
                            });
                        }
                    }
                }
            }
            return danhSachBenhNhan;
        }
        // Tìm lịch sử khám bệnh của bệnh nhân
        public List<DTO_LichSuKhamBenh> GetLichSuKhamBenh(int maBN)
        {
            List<DTO_LichSuKhamBenh> lichSuKhamBenh = new List<DTO_LichSuKhamBenh>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    MaLSKB, MaBS, MaBN, NgayKham, ChuanDoan, MaPK, TrieuChung
                FROM LichSuKhamBenh
                WHERE MaBN = @MaBN";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lichSuKhamBenh.Add(new DTO_LichSuKhamBenh
                            {
                                MaLSKB = reader.GetInt32(reader.GetOrdinal("MaLSKB")),
                                MaBS = reader.GetInt32(reader.GetOrdinal("MaBS")),
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                NgayKham = reader.GetDateTime(reader.GetOrdinal("NgayKham")),
                                ChuanDoan = reader.IsDBNull(reader.GetOrdinal("ChuanDoan")) ? null : reader.GetString(reader.GetOrdinal("ChuanDoan")),
                                MaPK = reader.GetInt32(reader.GetOrdinal("MaPK")),
                                TrieuChung = reader.IsDBNull(reader.GetOrdinal("TrieuChung")) ? null : reader.GetString(reader.GetOrdinal("TrieuChung"))
                            });
                        }
                    }
                }
            }
            return lichSuKhamBenh;
        }
        // Tìm chi tiết sử dụng dịch vụ theo mã lịch khám
        public List<DTO_ChiTietSuDungDV> GetChiTietSuDungDVTheoMaLSKB(int maLSKB)
        {
            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    MaChiTietSDDV, MaLSKB, MaDV, SoLuong, Gia, NgayLap
                FROM ChiTietSuDungDV
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
        // Tìm chi tiết sử dụng dịch vụ theo số điện thoại
        public List<DTO_ChiTietSuDungDV> TimChiTietSuDungDVTheoSDT(string soDienThoai)
        {
            // Tìm bệnh nhân theo số điện thoại
            var danhSachBenhNhan = TimBenhNhanTheoSoDienThoai(soDienThoai);
            if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
            {
                throw new Exception("Không tìm thấy bệnh nhân nào với số điện thoại này.");
            }

            List<DTO_ChiTietSuDungDV> danhSachChiTiet = new List<DTO_ChiTietSuDungDV>();

            // Lặp qua danh sách bệnh nhân và tìm chi tiết sử dụng dịch vụ cho mỗi bệnh nhân
            foreach (var benhNhan in danhSachBenhNhan)
            {
                // Lấy lịch sử khám của bệnh nhân
                var lichSuKham = GetLichSuKhamBenh(benhNhan.MaBN);
                foreach (var lichKham in lichSuKham)
                {
                    // Tìm chi tiết sử dụng dịch vụ theo mã lịch khám
                    var chiTiet = GetChiTietSuDungDVTheoMaLSKB(lichKham.MaLSKB);
                    danhSachChiTiet.AddRange(chiTiet);
                }
            }

            return danhSachChiTiet;
        }
        public string GetDoctorName(int maLSKB)
        {
            string tenBS = string.Empty;

            // Giả sử bạn có một kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT b.TenBS " +
                               "FROM LichSuKhamBenh l " +
                               "JOIN BacSi b ON l.MaBS = b.MaBS " +
                               "WHERE l.MaLSKB = @MaLSKB";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        tenBS = result.ToString();
                    }
                }
            }

            return tenBS;
        }
        public string GetServiceName(string maDichVu)
        {
            string tenDichVu = string.Empty;

            // Câu lệnh kết nối cơ sở dữ liệu
            string connectionString = "your_connection_string_here"; // Thay thế bằng chuỗi kết nối của bạn

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                // Câu truy vấn SQL để lấy tên dịch vụ
                string query = "SELECT TenDV FROM DichVu WHERE MaDV = @MaDichVu";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Thêm tham số vào câu lệnh
                    command.Parameters.AddWithValue("@MaDichVu", maDichVu);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            tenDichVu = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ (nếu cần)
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }

            return tenDichVu;
        }
        public (string tenBN, DateTime? ngaySinh, string soDT) GetPatientInfo(int maBN)
        {
            string tenBN = string.Empty;
            DateTime? ngaySinh = null;
            string soDT = string.Empty;

            //string connectionString = "your_connection_string_here"; // Thay thế bằng chuỗi kết nối của bạn

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT HoTenBN, NgaySinh, SoDT FROM BenhNhan WHERE MaBN = @MaBN";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaBN", maBN);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tenBN = reader["HoTenBN"].ToString();
                                ngaySinh = reader["NgaySinh"] as DateTime?;
                                soDT = reader["SoDT"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ (nếu cần)
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }

            return (tenBN, ngaySinh, soDT);
        }
        public int GetPatientIdFromCTSDDV(int maCTSDDV)
        {
            int maBN = 0;

            //string connectionString = "your_connection_string_here"; // Thay thế bằng chuỗi kết nối của bạn

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = @"
                SELECT LichSuKhamBenh.MaBN 
                FROM CTSDDV 
                JOIN LichSuKhamBenh ON CTSDDV.MaLSKB = LichSuKhamBenh.MaLSKB 
                WHERE CTSDDV.MaChiTietSDDV = @MaCTSDDV";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaCTSDDV", maCTSDDV);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            maBN = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ (nếu cần)
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }

            return maBN;
        }
    }
}
