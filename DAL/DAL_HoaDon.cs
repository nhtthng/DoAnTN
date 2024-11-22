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
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
INSERT INTO HoaDon 
(NgayLapHD, MaNV, MaBN, TongTien, TrangThai, GiamGia) 
VALUES 
(@NgayLapHD, @MaNV, @MaBN, 0, 'CHUA_HOAN_THANH', @GiamGia);
SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayLapHD", hoaDon.NgayLapHD);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);

                    // Thêm tham số MaBN, cho phép NULL
                    if (hoaDon.MaBN > 0)
                    {
                        cmd.Parameters.AddWithValue("@MaBN", hoaDon.MaBN);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MaBN", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Xóa Hóa Đơn
        public bool XoaHoaDon(int maHD)
        {
            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                // Xóa chi tiết sử dụng dịch vụ trước
                string queryXoaCTSDDV = "DELETE FROM CTSDDV WHERE MaHD = @MaHD";

                // Xóa hóa đơn
                string queryXoaHoaDon = "DELETE FROM HoaDon WHERE MaHD = @MaHD";

                using (SqlCommand cmdCTSDDV = new SqlCommand(queryXoaCTSDDV, conn))
                {
                    cmdCTSDDV.Parameters.AddWithValue("@MaHD", maHD);
                    cmdCTSDDV.ExecuteNonQuery();
                }

                using (SqlCommand cmdHoaDon = new SqlCommand(queryXoaHoaDon, conn))
                {
                    cmdHoaDon.Parameters.AddWithValue("@MaHD", maHD);
                    return cmdHoaDon.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa hóa đơn: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Cập Nhật Hóa Đơn
        public bool CapNhatHoaDon(DTO_HoaDon hoaDon)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                transaction = conn.BeginTransaction();

                // Truy vấn tổng tiền từ CTSDDV
                string queryTongTien = @"
            SELECT COALESCE(SUM(ThanhTien), 0) AS TongTien 
            FROM CTSDDV 
            WHERE MaHD = @MaHD";

                decimal tongTien = 0;
                using (SqlCommand cmdTongTien = new SqlCommand(queryTongTien, conn, transaction))
                {
                    cmdTongTien.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    tongTien = Convert.ToDecimal(cmdTongTien.ExecuteScalar());
                }

                // Tính toán tổng tiền sau giảm giá
                decimal tongTienSauGiam = tongTien - (tongTien * hoaDon.GiamGia / 100m);

                // Câu truy vấn cập nhật
                string query = @"
            UPDATE HoaDon 
            SET NgayLapHD = @NgayLapHD, 
                MaNV = @MaNV, 
                MaBN = @MaBN,  
                GiamGia = @GiamGia,
                TongTien = @TongTien
            WHERE MaHD = @MaHD";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    cmd.Parameters.AddWithValue("@NgayLapHD", hoaDon.NgayLapHD);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);

                    // Kiểm tra và xử lý MaBN
                    if (hoaDon.MaBN != null && hoaDon.MaBN > 0)
                    {
                        cmd.Parameters.AddWithValue("@MaBN", hoaDon.MaBN);
                    }
                    else
                    {
                        // Nếu MaBN không có giá trị hoặc bằng 0, sử dụng DBNull
                        cmd.Parameters.AddWithValue("@MaBN", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                    cmd.Parameters.AddWithValue("@TongTien", tongTienSauGiam);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Commit transaction nếu cập nhật thành công
                    transaction.Commit();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi
                transaction?.Rollback();
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        // Phương thức lấy tất cả hóa đơn
        public List<DTO_HoaDon> LayTatCaHoaDon()
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
            COALESCE(MaNV, 0) AS MaNV, 
            COALESCE(MaBN, 0) AS MaBN, 
            TongTien, 
            TrangThai, 
            GiamGia 
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
                                NgayLapHD = reader.GetDateTime(reader.GetOrdinal("NgayLapHD")),
                                MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                                TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                                GiamGia = reader.GetInt32(reader.GetOrdinal("GiamGia"))
                            });
                        }
                    }
                }

                return dsHoaDon;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
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
            GiamGia 
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
