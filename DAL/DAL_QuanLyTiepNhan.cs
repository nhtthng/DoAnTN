using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyTiepNhan
    {
        // Lấy tất cả các bệnh nhân đã tiếp nhận
        public List<DTO_QuanLyTiepNhan> GetAllTiepNhan()
        {
            List<DTO_QuanLyTiepNhan> danhSachTiepNhan = new List<DTO_QuanLyTiepNhan>();

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM TiepNhanBenhNhan";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DTO_QuanLyTiepNhan dto = new DTO_QuanLyTiepNhan
                    {
                        MaTiepNhan = (int)reader["MaTiepNhan"],
                        MaBenhNhan = (int)reader["MaBenhNhan"],
                        NgayTiepNhan = (DateTime)reader["NgayTiepNhan"],
                        GioTiepNhan = (TimeSpan)reader["GioTiepNhan"],
                        TrangThai = (string)reader["TrangThai"],
                        TrieuChung = (string)reader["TrieuChung"],
                        MaPK = (int)reader["MaPK"]
                    };
                    danhSachTiepNhan.Add(dto);
                }
                SqlConnectionData.CloseConnection(connection);
            }

            return danhSachTiepNhan;
        }
        // Thêm một bệnh nhân mới
        public bool ThemTiepNhan(DTO_QuanLyTiepNhan dto)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO TiepNhanBenhNhan (MaBenhNhan, NgayTiepNhan, GioTiepNhan, TrangThai, TrieuChung, MaPK) " +
                               "VALUES (@MaBenhNhan, @NgayTiepNhan, @GioTiepNhan, @TrangThai, @TrieuChung, @MaPK)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBenhNhan", dto.MaBenhNhan);
                command.Parameters.AddWithValue("@NgayTiepNhan", dto.NgayTiepNhan);
                command.Parameters.AddWithValue("@GioTiepNhan", dto.GioTiepNhan);
                command.Parameters.AddWithValue("@TrangThai", "Chưa hoàn thành");
                command.Parameters.AddWithValue("@TrieuChung", dto.TrieuChung);
                command.Parameters.AddWithValue("@MaPK", dto.MaPK);
                int rowsAffected = command.ExecuteNonQuery();
                SqlConnectionData.CloseConnection(connection);
                return rowsAffected > 0;
            }
        }
        // Xóa một bệnh nhân
        public bool XoaTiepNhan(int maTiepNhan)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM TiepNhanBenhNhan WHERE MaTiepNhan = @MaTiepNhan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaTiepNhan", maTiepNhan);
                int rowsAffected = command.ExecuteNonQuery();
                SqlConnectionData.CloseConnection(connection);
                return rowsAffected > 0;
            }
        }
        // Sửa thông tin một bệnh nhân
        public bool SuaTiepNhan(DTO_QuanLyTiepNhan dto)
        {
            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                connection.Open();
                string query = "UPDATE TiepNhanBenhNhan SET MaBenhNhan = @MaBenhNhan, NgayTiepNhan = @NgayTiepNhan, " +
                               "GioTiepNhan = @GioTiepNhan, TrangThai = @TrangThai, TrieuChung = @TrieuChung, MaPK = @MaPK " +
                               "WHERE MaTiepNhan = @MaTiepNhan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBenhNhan", dto.MaBenhNhan);
                command.Parameters.AddWithValue("@NgayTiepNhan", dto.NgayTiepNhan);
                command.Parameters.AddWithValue("@GioTiepNhan", dto.GioTiepNhan);
                command.Parameters.AddWithValue("@TrangThai", dto.TrangThai);
                command.Parameters.AddWithValue("@TrieuChung", dto.TrieuChung);
                command.Parameters.AddWithValue("@MaPK", dto.MaPK);
                command.Parameters.AddWithValue("@MaTiepNhan", dto.MaTiepNhan);
                int rowsAffected = command.ExecuteNonQuery();
                SqlConnectionData.CloseConnection(connection);
                return rowsAffected > 0;
            }
        }
        // Tìm kiếm thông tin tiếp nhận bệnh nhân theo số điện thoại
        public List<DTO_QuanLyTiepNhan> TimKiemThongTinTiepNhanTheoDienThoai(string soDienThoai)
        {
            List<DTO_QuanLyTiepNhan> danhSachTiepNhan = new List<DTO_QuanLyTiepNhan>();

            using (SqlConnection connection = SqlConnectionData.GetConnection())
            {
                connection.Open();
                string query = @"
                SELECT tn.MaTiepNhan, tn.MaBenhNhan, tn.NgayTiepNhan, tn.GioTiepNhan, tn.TrangThai, tn.TrieuChung, tn.MaPK, bn.SoDT
                FROM TiepNhanBenhNhan tn
                INNER JOIN BenhNhan bn ON tn.MaBenhNhan = bn.MaBN
                WHERE bn.SoDT = @SoDT
            ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDT", soDienThoai);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DTO_QuanLyTiepNhan dto = new DTO_QuanLyTiepNhan
                    {
                        MaTiepNhan = (int)reader["MaTiepNhan"],
                        MaBenhNhan = (int)reader["MaBenhNhan"],
                        NgayTiepNhan = (DateTime)reader["NgayTiepNhan"],
                        GioTiepNhan = (TimeSpan)reader["GioTiepNhan"],
                        TrangThai = (string)reader["TrangThai"],
                        TrieuChung = (string)reader["TrieuChung"],
                        MaPK = (int)reader["MaPK"]
                    };
                    danhSachTiepNhan.Add(dto);
                }
                SqlConnectionData.CloseConnection(connection);
            }

            return danhSachTiepNhan;
        }
        public List<DTO_QuanLyTiepNhan> GetAllTiepNhanByNgay(DateTime ngayTiepNhan)
        {
            List<DTO_QuanLyTiepNhan> danhSachTiepNhan = new List<DTO_QuanLyTiepNhan>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM TiepNhanBenhNhan
                        WHERE CAST(NgayTiepNhan AS DATE) = @NgayTiepNhan";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayTiepNhan", ngayTiepNhan.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachTiepNhan.Add(new DTO_QuanLyTiepNhan
                            {
                                MaTiepNhan = Convert.ToInt32(reader["MaTiepNhan"]),
                                MaBenhNhan = Convert.ToInt32(reader["MaBenhNhan"]),
                                NgayTiepNhan = Convert.ToDateTime(reader["NgayTiepNhan"]),
                                GioTiepNhan = TimeSpan.Parse(reader["GioTiepNhan"].ToString()),
                                TrangThai = reader["TrangThai"].ToString(),
                                TrieuChung = reader["TrieuChung"].ToString(),
                                MaPK = Convert.ToInt32(reader["MaPK"])
                            });
                        }
                    }
                }

                SqlConnectionData.CloseConnection(conn);
            }

            return danhSachTiepNhan;
        }
    }
}
