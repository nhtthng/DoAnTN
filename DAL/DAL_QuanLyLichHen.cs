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
                    string query = "INSERT INTO LichHen (MaLH, MaBS, MaBN, ThoiGianHen, NgayHen, TinhTrang) VALUES (@MaLH, @MaBS, @MaBN, @ThoiGianHen, @NgayHen, @TinhTrang)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLH", lichHen.MaLH); // Thêm mã lịch hẹn
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
        public DTO_LichHen GetLichHenByMaLH(int maLH)
        {
            DTO_LichHen lichHen = null;

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaLH, MaBS, MaBN, ThoiGianHen, NgayHen, TinhTrang FROM LichHen WHERE MaLH = @MaLH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLH", maLH);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lichHen = new DTO_LichHen
                        {
                            MaLH = reader.GetInt32(0),
                            MaBS = reader.GetInt32(1),
                            MaBN = reader.GetInt32(2),
                            ThoiGianHen = reader.GetDateTime(3),
                            NgayHen = reader.GetDateTime(4),
                            TinhTrang = reader.GetString(5)
                        };
                    }
                }
            }
            return lichHen;
        }
        public bool IsAppointmentIdExists(int maLH)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM LichHen WHERE MaLH = @MaLH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLH", maLH);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
