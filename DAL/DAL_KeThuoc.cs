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
        public List<DTO_ChiTietToaThuoc> GetAllChiTietToaThuoc()
        {
            List<DTO_ChiTietToaThuoc> listChiTietToaThuoc = new List<DTO_ChiTietToaThuoc>();

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "SELECT * FROM ChiTietToaThuoc"; // Thay đổi tên bảng theo cơ sở dữ liệu của bạn
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DTO_ChiTietToaThuoc chiTiet = new DTO_ChiTietToaThuoc
                    {
                        MaLSKB = reader.GetInt32(reader.GetOrdinal("MaLSKB")),
                        MaThuoc = reader.GetInt32(reader.GetOrdinal("MaThuoc")),
                        CachDung = reader.GetString(reader.GetOrdinal("CachDung")),
                        LieuLuong = reader.GetString(reader.GetOrdinal("LieuLuong")),
                        NgayKeToa = reader.GetDateTime(reader.GetOrdinal("NgayKeToa")),
                        MaBS = reader.GetInt32(reader.GetOrdinal("MaBS"))
                    };
                    listChiTietToaThuoc.Add(chiTiet);
                }
            }

            return listChiTietToaThuoc;
        }
        public bool AddChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "INSERT INTO ChiTietToaThuoc (MaLSKB, MaThuoc, CachDung, LieuLuong, NgayKeToa, LoiDanBS, MaBS) " +
                               "VALUES (@MaLSKB, @MaThuoc, @CachDung, @LieuLuong, @NgayKeToa, @LoiDanBS, @MaBS)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", chiTietToaThuoc.MaLSKB);
                command.Parameters.AddWithValue("@MaThuoc", chiTietToaThuoc.MaThuoc);
                command.Parameters.AddWithValue("@CachDung", chiTietToaThuoc.CachDung);
                command.Parameters.AddWithValue("@LieuLuong", chiTietToaThuoc.LieuLuong);
                command.Parameters.AddWithValue("@NgayKeToa", chiTietToaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@LoiDanBS", chiTietToaThuoc.LoiDanBS);
                command.Parameters.AddWithValue("@MaBS", chiTietToaThuoc.MaBS);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu thêm thành công
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể ghi log hoặc thông báo)
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Sửa chi tiết toa thuốc
        public bool UpdateChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "UPDATE ChiTietToaThuoc SET CachDung = @CachDung, LieuLuong = @LieuLuong, " +
                               "NgayKeToa = @NgayKeToa, LoiDanBS = @LoiDanBS, MaBS = @MaBS " +
                               "WHERE MaLSKB = @MaLSKB AND MaThuoc = @MaThuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", chiTietToaThuoc.MaLSKB);
                command.Parameters.AddWithValue("@MaThuoc", chiTietToaThuoc.MaThuoc);
                command.Parameters.AddWithValue("@CachDung", chiTietToaThuoc.CachDung);
                command.Parameters.AddWithValue("@LieuLuong", chiTietToaThuoc.LieuLuong);
                command.Parameters.AddWithValue("@NgayKeToa", chiTietToaThuoc.NgayKeToa);
                command.Parameters.AddWithValue("@LoiDanBS", chiTietToaThuoc.LoiDanBS);
                command.Parameters.AddWithValue("@MaBS", chiTietToaThuoc.MaBS);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu sửa thành công
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể ghi log hoặc thông báo)
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Xóa chi tiết toa thuốc
        public bool DeleteChiTietToaThuoc(int maLSKB, int maThuoc)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                string query = "DELETE FROM ChiTietToaThuoc WHERE MaLSKB = @MaLSKB AND MaThuoc = @MaThuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLSKB", maLSKB);
                command.Parameters.AddWithValue("@MaThuoc", maThuoc);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu xóa thành công
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể ghi log hoặc thông báo)
                    Console.WriteLine(ex.Message);
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
    }
}

