using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KeThuoc
    {
        // Thêm chi tiết toa thuốc

        public List<DTO_Thuoc> GetAllThuocTheoTenThuoc()
        {
            List<DTO_Thuoc> danhSachThuoc = new List<DTO_Thuoc>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaThuoc, TenThuoc,BietDuoc FROM Thuoc ORDER BY TenThuoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DTO_Thuoc thuoc = new DTO_Thuoc
                            {
                                MaThuoc = reader.GetInt32(0),
                                TenThuoc = reader.GetString(1),
                                BietDuoc = reader.IsDBNull(2) ? null : reader.GetString(2)
                            };
                            danhSachThuoc.Add(thuoc);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể ghi log hoặc thông báo)
                    throw ex;
                }
                finally
                {
                    SqlConnectionData.CloseConnection(conn);
                }
            }
            return danhSachThuoc;
        }

        // Lấy tất cả chi tiết toa thuốc
        public List<DTO_ChiTietToaThuoc> GetAllChiTietToaThuoc()
        {
            List<DTO_ChiTietToaThuoc> chiTietList = new List<DTO_ChiTietToaThuoc>();
            string query = "SELECT MaLSKB, MaThuoc, CachDung, LieuLuong, NgayKeToa, LoiDanBS, MaBS FROM ChiTietToaThuoc";

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DTO_ChiTietToaThuoc chiTiet = new DTO_ChiTietToaThuoc
                        {
                            MaLSKB = reader.GetInt32(0),
                            MaThuoc = reader.GetInt32(1),
                            CachDung = reader.GetString(2),
                            LieuLuong = reader.GetString(3),
                            NgayKeToa = reader.GetDateTime(4),
                            LoiDanBS = reader.IsDBNull(5) ? null : reader.GetString(5),
                            MaBS = reader.GetInt32(6)
                        };
                        chiTietList.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine($"Lỗi khi lấy dữ liệu: {ex.Message}");
                }
            }

            return chiTietList;
        }

        // Kiểm tra xem đã tồn tại chi tiết toa thuốc với cùng MaLSKB, MaThuoc và NgayKeToa hay chưa
        // Phương thức kiểm tra sự tồn tại của chi tiết toa thuốc
    public bool IsChiTietToaThuocExists(int maLSKB, int maThuoc, DateTime ngayKeToa)
    {
        string query = "SELECT COUNT(*) FROM ChiTietToaThuoc WHERE MaLSKB = @MaLSKB AND MaThuoc = @MaThuoc AND NgayKeToa = @NgayKeToa";

        using (SqlConnection connection = SqlConnectionData.GetConnection())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaLSKB", maLSKB);
            command.Parameters.AddWithValue("@MaThuoc", maThuoc);
            command.Parameters.AddWithValue("@NgayKeToa", ngayKeToa);

            connection.Open();
            int count = (int)command.ExecuteScalar(); // Lấy số lượng bản ghi
            return count > 0; // Trả về true nếu có ít nhất một bản ghi
        }
    }

        // Thêm chi tiết toa thuốc
        public bool AddChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            string query = "INSERT INTO ChiTietToaThuoc (MaLSKB, MaThuoc, CachDung, LieuLuong, NgayKeToa, LoiDanBS, MaBS) " +
                           "VALUES (@MaLSKB, @MaThuoc, @CachDung, @LieuLuong, @NgayKeToa, @LoiDanBS, @MaBS)";

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", chiTietToaThuoc.MaLSKB);
                command.Parameters.AddWithValue("@MaThuoc", chiTietToaThuoc.MaThuoc);
                command.Parameters.AddWithValue("@CachDung", chiTietToaThuoc.CachDung);
                command.Parameters.AddWithValue("@LieuLuong", chiTietToaThuoc.LieuLuong);
                command.Parameters.AddWithValue("@NgayKeToa", chiTietToaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@LoiDanBS", (object)chiTietToaThuoc.LoiDanBS ?? DBNull.Value);
                command.Parameters.AddWithValue("@MaBS", chiTietToaThuoc.MaBS);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; // Trả về true nếu thêm thành công
            }
        }

        // Sửa chi tiết toa thuốc
        public bool UpdateChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            string query = "UPDATE ChiTietToaThuoc SET CachDung = @CachDung, LieuLuong = @LieuLuong, " +
                           "NgayKeToa = @NgayKeToa, LoiDanBS = @LoiDanBS, MaBS = @MaBS " +
                           "WHERE MaLSKB = @MaLSKB AND MaThuoc = @MaThuoc";

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", chiTietToaThuoc.MaLSKB);
                command.Parameters.AddWithValue("@MaThuoc", chiTietToaThuoc.MaThuoc);
                command.Parameters.AddWithValue("@CachDung", chiTietToaThuoc.CachDung);
                command.Parameters.AddWithValue("@LieuLuong", chiTietToaThuoc.LieuLuong);
                command.Parameters.AddWithValue("@NgayKeToa", chiTietToaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@LoiDanBS", (object)chiTietToaThuoc.LoiDanBS ?? DBNull.Value);
                command.Parameters.AddWithValue("@MaBS", chiTietToaThuoc.MaBS);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0; // Trả về true nếu sửa thành công
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine($"Lỗi khi sửa dữ liệu: {ex.Message}");
                    return false;
                }
            }
        }


        // Xóa chi tiết toa thuốc
        public bool DeleteChiTietToaThuoc(int maLSKB, int maThuoc)
        {
            string query = "DELETE FROM ChiTietToaThuoc WHERE MaLSKB = @MaLSKB AND MaThuoc = @MaThuoc";

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", maLSKB);
                command.Parameters.AddWithValue("@MaThuoc", maThuoc);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0; // Trả về true nếu xóa thành công
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine($"Lỗi khi xóa dữ liệu: {ex.Message}");
                    return false;
                }
            }
        }
        // Tìm kiếm thông tin chi tiết toa thuốc bằng số điện thoại của bệnh nhân
        public List<DTO_ChiTietToaThuoc> SearchChiTietToaThuocByPhone(string phoneNumber)
        {
            List<DTO_ChiTietToaThuoc> chiTietToaThuocs = new List<DTO_ChiTietToaThuoc>();
            int maBN = GetMaBNByPhone(phoneNumber);
            if (maBN == 0) return chiTietToaThuocs; // Nếu không tìm thấy bệnh nhân

            List<int> maLSKBs = GetMaLSKBsByMaBN(maBN);
            foreach (int maLSKB in maLSKBs)
            {
                chiTietToaThuocs.AddRange(GetChiTietToaThuocByMaLSKB(maLSKB));
            }

            return chiTietToaThuocs;
        }
        // Lấy Mã Bệnh Nhân từ số điện thoại
        private int GetMaBNByPhone(string phoneNumber)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaBN FROM BenhNhan WHERE SoDT = @SoDT";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDT", phoneNumber);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0; // Trả về 0 nếu không tìm thấy
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        // Lấy danh sách Mã Lịch Sử Khám Bệnh từ Mã Bệnh Nhân
        private List<int> GetMaLSKBsByMaBN(int maBN)
        {
            List<int> maLSKBs = new List<int>();
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaLSKB FROM LichSuKhamBenh WHERE MaBN = @MaBN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBN", maBN);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maLSKBs.Add(reader.GetInt32(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return maLSKBs;
        }
        // Lấy chi tiết toa thuốc từ Mã Lịch Sử Khám Bệnh
        private List<DTO_ChiTietToaThuoc> GetChiTietToaThuocByMaLSKB(int maLSKB)
        {
            List<DTO_ChiTietToaThuoc> chiTietToaThuocs = new List<DTO_ChiTietToaThuoc>();
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "SELECT * FROM ChiTietToaThuoc WHERE MaLSKB = @MaLSKB";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", maLSKB);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ChiTietToaThuoc chiTiet = new DTO_ChiTietToaThuoc
                            {
                                MaLSKB = reader.GetInt32(0),
                                MaThuoc = reader.GetInt32(1),
                                CachDung = reader.GetString(2),
                                LieuLuong = reader.GetString(3),
                                NgayKeToa = reader.GetDateTime(4),
                                LoiDanBS = reader.GetString(5),
                                MaBS = reader.GetInt32(6)
                            };
                            chiTietToaThuocs.Add(chiTiet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return chiTietToaThuocs;
        }
        // Lấy danh sách bệnh nhân từ lịch sử khám bệnh
        public List<DTO_QuanLyBenhNhan> GetAllBenhNhanFromLichSuKham()
        {
            List<DTO_QuanLyBenhNhan> danhSachBenhNhan = new List<DTO_QuanLyBenhNhan>();
            string query = @"
            SELECT BN.HoTenBN, BN.NgaySinh, BN.SoDT
            FROM BenhNhan BN
            JOIN LichSuKhamBenh LSKB ON BN.MaBN = LSKB.MaBN";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan
                                {
                                    HoTenBN = reader["HoTenBN"].ToString(),
                                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                    SoDT = reader["SoDT"].ToString()
                                };
                                danhSachBenhNhan.Add(benhNhan);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể ghi log hoặc ném ra ngoại lệ)
                    throw new Exception("Lỗi khi lấy danh sách bệnh nhân: " + ex.Message);
                }
            }

            return danhSachBenhNhan;
        }
        public List<DTO_LichSuBenhNhan> LayDanhSachBenhNhan()
        {
            List<DTO_LichSuBenhNhan> danhSachBenhNhan = new List<DTO_LichSuBenhNhan>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT lskb.MaLSKB, bn.MaBN, bn.HoTenBN, bn.NgaySinh, bn.SoDT
            FROM LichSuKhamBenh lskb
            JOIN BenhNhan bn ON lskb.MaBN = bn.MaBN";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachBenhNhan.Add(new DTO_LichSuBenhNhan
                            {
                                MaLSKB = reader.GetInt32(0),
                                MaBN = reader.GetInt32(1), // Lấy MaBN từ cột thứ 1
                                HoTenBN = reader.GetString(2),
                                NgaySinh = reader.GetDateTime(3),
                                SoDT = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return danhSachBenhNhan;
        }
        public List<DTO_ChiTietToaThuocFULL> GetChiTietToaThuocByMaLSKBIN(int maLSKB)
        {
            List<DTO_ChiTietToaThuocFULL> list = new List<DTO_ChiTietToaThuocFULL>();
            string query = @"
        SELECT CT.*, T.TenThuoc, T.BietDuoc 
        FROM ChiTietToaThuoc CT
        JOIN Thuoc T ON CT.MaThuoc = T.MaThuoc
        WHERE CT.MaLSKB = @MaLSKB";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaLSKB", maLSKB);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var chiTietToaThuoc = new DTO_ChiTietToaThuoc
                    {
                        MaLSKB = (int)reader["MaLSKB"],
                        MaThuoc = (int)reader["MaThuoc"],
                        CachDung = reader["CachDung"].ToString(),
                        LieuLuong = reader["LieuLuong"].ToString(),
                        NgayKeToa = (DateTime)reader["NgayKeToa"],
                        LoiDanBS = reader["LoiDanBS"].ToString(),
                        MaBS = (int)reader["MaBS"]
                    };

                    var chiTietFull = new DTO_ChiTietToaThuocFULL
                    {
                        ChiTietToaThuoc = chiTietToaThuoc,
                        TenThuoc = reader["TenThuoc"].ToString(),
                        BietDuoc = reader["BietDuoc"].ToString()
                    };

                    list.Add(chiTietFull);
                }
            }
            return list;
        }
    }
}

