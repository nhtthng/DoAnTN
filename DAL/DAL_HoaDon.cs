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

                // Lấy tổng tiền từ bảng ChiTietSuDungDV theo MaLSKB
                decimal tongTien = 0;
                string queryTongTien = @"
            SELECT SUM(ThanhTien) 
            FROM CTSDDV 
            WHERE MaLSKB = @MaLSKB";

                using (SqlCommand cmdTongTien = new SqlCommand(queryTongTien, conn))
                {
                    cmdTongTien.Parameters.AddWithValue("@MaLSKB", hoaDon.MaLSKB);
                    var result = cmdTongTien.ExecuteScalar();
                    tongTien = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }

                // Áp dụng giảm giá
                decimal tongTienSauGiamGia = tongTien - (tongTien * (hoaDon.GiamGia / 100));

                string query = @"
INSERT INTO HoaDon 
(NgayLapHD, MaNV, MaBN, TongTien, TrangThai, GiamGia, PhuongThucThanhToan) 
VALUES 
(@NgayLapHD, @MaNV, @MaBN, @TongTien, 'CHUA_HOAN_THANH', @GiamGia, @PhuongThucThanhToan);
SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayLapHD", hoaDon.NgayLapHD);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                    cmd.Parameters.AddWithValue("@MaBN", (object)hoaDon.MaBN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TongTien", tongTienSauGiamGia);
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

                // Lấy tổng tiền từ bảng ChiTietSuDungDV theo MaLSKB
                decimal tongTien = 0;
                string queryTongTien = @"
            SELECT SUM(ThanhTien) 
            FROM CTSDDV 
            WHERE MaLSKB = @MaLSKB";

                using (SqlCommand cmdTongTien = new SqlCommand(queryTongTien, conn))
                {
                    cmdTongTien.Parameters.AddWithValue("@MaLSKB", hoaDon.MaLSKB);
                    var result = cmdTongTien.ExecuteScalar();
                    tongTien = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }

                // Áp dụng giảm giá
                decimal tongTienSauGiamGia = tongTien - (tongTien * (hoaDon.GiamGia / 100));

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
                    cmd.Parameters.AddWithValue("@TongTien", tongTienSauGiamGia);
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
        public InvoiceDetails GetInvoiceDetails(int maHD)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.HoaDon = new DTO_HoaDon();

            string query = @"
        SELECT 
            HD.MaHD,
            HD.MaBN,
            HD.MaNV,
            HD.NgayLapHD,
            HD.GiamGia,
            HD.TrangThai,
            HD.MaLSKB,
            (SELECT SUM(ThanhTien) FROM CTSDDV WHERE MaLSKB = HD.MaLSKB) + 
            (SELECT SUM(ThanhTien) FROM CTHD WHERE MaLSKB = HD.MaLSKB) AS TongTien,
            BN.HoTenBN,
            BN.NgaySinh,
            BN.SoDT
        FROM 
            HoaDon HD
        JOIN 
            BenhNhan BN ON HD.MaBN = BN.MaBN
        WHERE 
            HD.MaHD = @MaHD;";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        invoiceDetails.HoaDon.MaHD = Convert.ToInt32(reader["MaHD"]);
                        invoiceDetails.HoaDon.MaBN = Convert.ToInt32(reader["MaBN"]);
                        invoiceDetails.HoaDon.MaNV = Convert.ToInt32(reader["MaNV"]);
                        invoiceDetails.HoaDon.NgayLapHD = Convert.ToDateTime(reader["NgayLapHD"]);
                        invoiceDetails.HoaDon.GiamGia = Convert.ToDecimal(reader["GiamGia"]);
                        invoiceDetails.HoaDon.TrangThai = reader["TrangThai"].ToString();
                        invoiceDetails.HoaDon.MaLSKB = Convert.ToInt32(reader["MaLSKB"]);
                        //invoiceDetails.HoaDon.TongTien = Convert.ToDecimal(reader["TongTien"]);

                        // Lưu thông tin bệnh nhân
                        invoiceDetails.HoTenBN = reader["HoTenBN"].ToString();
                        invoiceDetails.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                        invoiceDetails.SoDT = reader["SoDT"].ToString();
                    }
                }
            }

            return invoiceDetails;
        }
        public DTO_HoaDon GetHoaDonById(int maHD)
        {
            DTO_HoaDon hoaDon = null;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT * FROM HoaDon WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hoaDon = new DTO_HoaDon
                    {
                        MaHD = (int)reader["MaHD"],
                        MaBN = (int)reader["MaBN"],
                        MaNV = (int)reader["MaNV"],
                        NgayLapHD = (DateTime)reader["NgayLapHD"],
                        GiamGia = (decimal)reader["GiamGia"],
                        PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString(),
                        MaLSKB = (int)reader["MaLSKB"],
                        TongTien = (decimal)reader["TongTien"]
                    };
                }
            }
            return hoaDon;
        }
        public (List<DTO_ChiTietSuDungDV> list, List<string> tenDichVuList) GetChiTietSuDungDVByMaLSKB(int maLSKB)
        {
            List<DTO_ChiTietSuDungDV> list = new List<DTO_ChiTietSuDungDV>();
            List<string> tenDichVuList = new List<string>();

            string query = "SELECT dv.MaDV, ctdv.SoLuong, ctdv.Gia, dv.TenDV FROM CTSDDV ctdv JOIN DichVu dv ON ctdv.MaDV = dv.MaDV WHERE ctdv.MaLSKB = @maLSKB";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@maLSKB", maLSKB);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DTO_ChiTietSuDungDV item = new DTO_ChiTietSuDungDV
                    {
                        MaDV = reader.GetInt32(0),
                        SoLuong = reader.GetInt32(1),
                        Gia = reader.GetDecimal(2)
                    };
                    list.Add(item);
                    tenDichVuList.Add(reader.GetString(3)); // Lưu tên dịch vụ vào danh sách tạm
                }
            }

            return (list, tenDichVuList);
        }
    }
}
