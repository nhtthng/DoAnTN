using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyLichHen
    {
        public List<DTO_LichHen> GetAllLichHen()
        {
            List<DTO_LichHen> lichHenList = new List<DTO_LichHen>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaLH, MaBS, MaBN, ThoiGianHen, NgayHen, TinhTrang FROM LichHen";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_LichHen lichHen = new DTO_LichHen
                        {
                            MaLH = reader.GetInt32(0),
                            MaBS = reader.GetInt32(1),
                            MaBN = reader.GetInt32(2),
                            ThoiGianHen = reader.GetDateTime(3),
                            NgayHen = reader.GetDateTime(4),
                            TinhTrang = reader.GetString(5)
                        };
                        lichHenList.Add(lichHen);
                    }
                }
            }
            return lichHenList;
        }
        public bool AddLichHen(DTO_LichHen lichHen)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    string query = "INSERT INTO LichHen ( MaBS, MaBN, ThoiGianHen, NgayHen, TinhTrang) VALUES (@MaBS, @MaBN, @ThoiGianHen, @NgayHen, @TinhTrang)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBS", lichHen.MaBS);
                    cmd.Parameters.AddWithValue("@MaBN", lichHen.MaBN);
                    cmd.Parameters.AddWithValue("@ThoiGianHen", lichHen.ThoiGianHen);
                    cmd.Parameters.AddWithValue("@NgayHen", lichHen.NgayHen);
                    cmd.Parameters.AddWithValue("@TinhTrang", lichHen.TinhTrang);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true; // Thêm thành công
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return false; // Thêm không thành công
            }
        }
        // Sửa lịch hẹn
        public bool UpdateLichHen(DTO_LichHen updatedLichHen)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    string query = "UPDATE LichHen SET MaBS = @MaBS, MaBN = @MaBN, ThoiGianHen = @ThoiGianHen, NgayHen = @NgayHen, TinhTrang = @TinhTrang WHERE MaLH = @MaLH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLH", updatedLichHen.MaLH);
                    cmd.Parameters.AddWithValue("@MaBS", updatedLichHen.MaBS);
                    cmd.Parameters.AddWithValue("@MaBN", updatedLichHen.MaBN);
                    cmd.Parameters.AddWithValue("@ThoiGianHen", updatedLichHen.ThoiGianHen);
                    cmd.Parameters.AddWithValue("@NgayHen", updatedLichHen.NgayHen);
                    cmd.Parameters.AddWithValue("@TinhTrang", updatedLichHen.TinhTrang);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return false; // Cập nhật không thành công
            }
        }
        // Xóa lịch hẹn
        public bool DeleteLichHen(int maLH)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    string query = "DELETE FROM LichHen WHERE MaLH = @MaLH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLH", maLH);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return false; // Xóa không thành công
            }
        }
        public List<DTO_LichHen> GetLichHenBySDT(string soDT)
        {
            List<DTO_LichHen> danhSachLichHen = new List<DTO_LichHen>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = @"
            SELECT LH.MaLH, LH.MaBS, LH.MaBN, LH.ThoiGianHen, LH.NgayHen, LH.TinhTrang 
            FROM LichHen LH
            JOIN BenhNhan BN ON LH.MaBN = BN.MaBN
            WHERE BN.SoDT = @SoDT";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDT", soDT);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_LichHen lichHen = new DTO_LichHen
                        {
                            MaLH = reader.GetInt32(0),
                            MaBS = reader.GetInt32(1),
                            MaBN = reader.GetInt32(2),
                            ThoiGianHen = reader.GetDateTime(3),
                            NgayHen = reader.GetDateTime(4),
                            TinhTrang = reader.GetString(5)
                        };
                        danhSachLichHen.Add(lichHen);
                    }
                }
            }
            return danhSachLichHen;
        }
        // Hàm kiểm tra trùng lịch hẹn
        public bool KiemTraTrungLichHen(int maBS, int maBN, DateTime ngayHen, DateTime thoiGianHen)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = @"
        SELECT COUNT(*) 
        FROM LichHen 
        WHERE MaBS = @MaBS 
        AND NgayHen = @NgayHen 
        AND ThoiGianHen = @ThoiGianHen
        AND (MaBN = @MaBN OR 
             EXISTS (
                 SELECT 1 FROM LichHen 
                 WHERE MaBS = @MaBS 
                 AND NgayHen = @NgayHen 
                 AND ThoiGianHen = @ThoiGianHen
             ))";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBS", maBS);
                cmd.Parameters.AddWithValue("@MaBN", maBN);
                cmd.Parameters.AddWithValue("@NgayHen", ngayHen.Date);
                cmd.Parameters.AddWithValue("@ThoiGianHen", thoiGianHen);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public DTO_QuanLyBenhNhan GetBenhNhanBySDT(string soDT)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT * FROM BenhNhan WHERE SoDT = @SoDT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDT", soDT);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DTO_QuanLyBenhNhan
                        {
                            MaBN = reader.GetInt32(reader.GetOrdinal("MaBN")),
                            HoTenBN = reader.GetString(reader.GetOrdinal("HoTenBN")),
                            SoDT = reader.GetString(reader.GetOrdinal("SoDT"))
                            // Thêm các trường khác nếu cần
                        };
                    }
                }
            }
            return null;
        }
        public DTO_QuanLyBacSi GetBacSiBySDT(string soDT)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT * FROM BacSi WHERE SoDT = @SoDT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDT", soDT);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DTO_QuanLyBacSi
                        {
                            MaBS = reader.GetInt32(reader.GetOrdinal("MaBS")),
                            TenBS = reader.GetString(reader.GetOrdinal("TenBS")),
                            SoDT = reader.GetString(reader.GetOrdinal("SoDT"))
                            // Thêm các trường khác nếu cần
                        };
                    }
                }
            }
            return null;
        }
        public List<DTO_LichHen> GetLichHenByNgay(DateTime ngayHen)
        {
            List<DTO_LichHen> danhSachLichHen = new List<DTO_LichHen>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM LichHen 
                             WHERE CAST(NgayHen AS DATE) = @NgayHen";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayHen", ngayHen.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachLichHen.Add(new DTO_LichHen
                            {
                                MaLH = Convert.ToInt32(reader["MaLH"]),
                                MaBS = Convert.ToInt32(reader["MaBS"]),
                                MaBN = Convert.ToInt32(reader["MaBN"]),
                                ThoiGianHen = Convert.ToDateTime(reader["ThoiGianHen"]),
                                NgayHen = Convert.ToDateTime(reader["NgayHen"]),
                                TinhTrang = reader["TinhTrang"].ToString()
                            });
                        }
                    }
                }
            }

            return danhSachLichHen;
        }
    }
}
