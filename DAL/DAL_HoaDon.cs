using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {

        // Thêm Hóa Đơn
        public int ThemHoaDon(DTO_HoaDon hoaDon)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
INSERT INTO HoaDon 
(NgayLapHD, MaNV, MaBN, TongTien, TrangThai, GiamGia,PhuongThucThanhToan) 
VALUES 
(@NgayLapHD, @MaNV, @MaBN, 0, 'CHUA_HOAN_THANH', @GiamGia,@PhuongThucThanhToan);
SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayLapHD", hoaDon.NgayLapHD);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                    cmd.Parameters.AddWithValue("@MaBN", (object)hoaDon.MaBN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                    cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        // Xóa Hóa Đơn
        public bool XoaHoaDon(int maHD)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Cập Nhật Hóa Đơn
        public bool CapNhatHoaDon(DTO_HoaDon hoaDon)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE HoaDon 
                SET MaLSKB = @MaLSKB, 
                MaBN = @MaBN, 
                NgayLapHD = @NgayLapHD, 
                MaNV = @MaNV, 
                TongTien = @TongTien,  
                GiamGia = @GiamGia, 
                PhuongThucThanhToan = @PhuongThucThanhToan
                WHERE MaHD = @MaHD";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    cmd.Parameters.AddWithValue("@MaLSKB", hoaDon.MaLSKB);
                    cmd.Parameters.AddWithValue("@MaBN", hoaDon.MaBN);
                    cmd.Parameters.AddWithValue("@NgayLapHD", hoaDon.NgayLapHD);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    //cmd.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai);
                    cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                    cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Phương thức lấy tất cả hóa đơn
        public List<DTO_HoaDon> LayTatCaHoaDon()
        {
            List<DTO_HoaDon> dsHoaDon = new List<DTO_HoaDon>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
SELECT 
    MaHD, 
    MaLSKB, 
    MaBN, 
    NgayLapHD, 
    MaNV, 
    TongTien, 
    TrangThai, 
    GiamGia, 
    PhuongThucThanhToan 
FROM HoaDon 
ORDER BY NgayLapHD DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dsHoaDon.Add(new DTO_HoaDon
                            {
                                MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                                MaLSKB = reader.IsDBNull(reader.GetOrdinal("MaLSKB")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaLSKB")),
                                MaBN = reader.IsDBNull(reader.GetOrdinal("MaBN")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaBN")),
                                NgayLapHD = reader.GetDateTime(reader.GetOrdinal("NgayLapHD")),
                                MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                                GiamGia = reader.GetDecimal(reader.GetOrdinal("GiamGia")),
                                PhuongThucThanhToan = reader.GetString(reader.GetOrdinal("PhuongThucThanhToan"))
                            });
                        }
                    }
                }
            }
            return dsHoaDon;
        }
        // Phương thức tìm kiếm hóa đơn theo mã trả về danh sách
        public List<DTO_HoaDon> TimHoaDonTheoMa(int maHD)
        {
            List<DTO_HoaDon> dsHoaDon = new List<DTO_HoaDon>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
        SELECT 
            MaHD, 
            NgayLapHD, 
            MaNV, 
            MaBN, 
            TongTien, 
            TrangThai, 
            GiamGia,
        FROM HoaDon 
        WHERE MaHD = @MaHD";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_HoaDon hoaDon = new DTO_HoaDon
                            {
                                MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                                NgayLapHD = reader.GetDateTime(reader.GetOrdinal("NgayLapHD")),
                                MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                                GiamGia = reader.GetInt32(reader.GetOrdinal("GiamGia"))
                            };

                            // Kiểm tra và gán MaBN nếu không phải null
                            if (!reader.IsDBNull(reader.GetOrdinal("MaBN")))
                            {
                                hoaDon.MaBN = reader.GetInt32(reader.GetOrdinal("MaBN"));
                            }

                            dsHoaDon.Add(hoaDon);
                        }
                    }
                }

                return dsHoaDon;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm hóa đơn theo mã: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        public bool CapNhatHoaDonHoanThanh(int maHD)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // Lấy thông tin hóa đơn để lấy giảm giá
                string queryHoaDon = @"
            SELECT GiamGia 
            FROM HoaDon 
            WHERE MaHD = @MaHD";

                int giamGia = 0;
                using (SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn, transaction))
                {
                    cmdHoaDon.Parameters.AddWithValue("@MaHD", maHD);
                    giamGia = Convert.ToInt32(cmdHoaDon.ExecuteScalar());
                }

                // Truy vấn tổng tiền từ CTSDDV
                string queryTongTien = @"
            SELECT COALESCE(SUM(ThanhTien), 0) AS TongTien 
            FROM CTSDDV 
            WHERE MaHD = @MaHD";

                decimal tongTien = 0;
                using (SqlCommand cmdTongTien = new SqlCommand(queryTongTien, conn, transaction))
                {
                    cmdTongTien.Parameters.AddWithValue("@MaHD", maHD);
                    tongTien = Convert.ToDecimal(cmdTongTien.ExecuteScalar());
                }

                // Tính toán tổng tiền sau giảm giá
                decimal tongTienSauGiam = tongTien - (tongTien * giamGia / 100m);

                // Kiểm tra xem có chi tiết sử dụng dịch vụ không
                string queryKiemTraCTSDDV = @"
            SELECT COUNT(*) 
            FROM CTSDDV 
            WHERE MaHD = @MaHD";

                int soLuongCTSDDV = 0;
                using (SqlCommand cmdKiemTra = new SqlCommand(queryKiemTraCTSDDV, conn, transaction))
                {
                    cmdKiemTra.Parameters.AddWithValue("@MaHD", maHD);
                    soLuongCTSDDV = Convert.ToInt32(cmdKiemTra.ExecuteScalar());
                }

                // Nếu có chi tiết sử dụng dịch vụ
                if (soLuongCTSDDV > 0)
                {
                    // Cập nhật tổng tiền và trạng thái
                    string queryCapNhat = @"
                UPDATE HoaDon 
                SET TongTien = @TongTienSauGiam, 
                    TrangThai = 'HOAN_THANH' 
                WHERE MaHD = @MaHD";

                    using (SqlCommand cmdCapNhat = new SqlCommand(queryCapNhat, conn, transaction))
                    {
                        cmdCapNhat.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCapNhat.Parameters.AddWithValue("@TongTienSauGiam", tongTienSauGiam);

                        int rowsAffected = cmdCapNhat.ExecuteNonQuery();
                        transaction.Commit();

                        return rowsAffected > 0;
                    }
                }
                else
                {
                    // Không có chi tiết sử dụng dịch vụ, không làm gì
                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
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
