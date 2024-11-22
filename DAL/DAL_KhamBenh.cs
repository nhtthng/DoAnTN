using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhamBenh
    {
        // Phương thức lấy tất cả lịch sử khám bệnh
        public List<DTO_KhamBenh> GetAllKhamBenh()
        {
            List<DTO_KhamBenh> listKhamBenh = new List<DTO_KhamBenh>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM LichSuKhamBenh";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                                {
                                    MaLSKB = (int)reader["MaLSKB"],
                                    MaBS = (int)reader["MaBS"],
                                    MaBN = (int)reader["MaBN"],
                                    NgayKham = (DateTime)reader["NgayKham"],
                                    ChuanDoan = reader["ChuanDoan"].ToString(),
                                    MaPK = (int)reader["MaPK"]
                                };
                                listKhamBenh.Add(khamBenh);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            return listKhamBenh;
        }
        // Phương thức thêm lịch sử khám bệnh
        public bool AddKhamBenh(DTO_KhamBenh khamBenh)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {

                try
                {
                    conn.Open();

                    string query = "INSERT INTO LichSuKhamBenh (MaLSKB,MaBS, MaBN, NgayKham, ChuanDoan, MaPK) VALUES (@MaLSKB,@MaBS, @MaBN, @NgayKham, @ChuanDoan, @MaPK)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLSKB", khamBenh.MaLSKB);
                        cmd.Parameters.AddWithValue("@MaBS", khamBenh.MaBS);
                        cmd.Parameters.AddWithValue("@MaBN", khamBenh.MaBN);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);
                        cmd.Parameters.AddWithValue("@MaPK", khamBenh.MaPK);
                        cmd.ExecuteNonQuery();
                    }

                    return true; // Thêm thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Phương thức xóa lịch sử khám bệnh
        public bool DeleteKhamBenh(int maLSKB)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM LichSuKhamBenh WHERE MaLSKB = @MaLSKB";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
                        cmd.ExecuteNonQuery();
                    }
                    return true; // Xóa thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Phương thức cập nhật lịch sử khám bệnh
        public bool UpdateKhamBenh(DTO_KhamBenh khamBenh)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE LichSuKhamBenh SET MaBS = @MaBS, MaBN = @MaBN, NgayKham = @NgayKham, ChuanDoan = @ChuanDoan, MaPK = @MaPK WHERE MaLSKB = @MaLSKB";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLSKB", khamBenh.MaLSKB);
                        cmd.Parameters.AddWithValue("@MaBS", khamBenh.MaBS);
                        cmd.Parameters.AddWithValue("@MaBN", khamBenh.MaBN);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);
                        cmd.Parameters.AddWithValue("@MaPK", khamBenh.MaPK);
                        cmd.ExecuteNonQuery();
                    }
                    return true; // Cập nhật thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Tìm kiếm lịch sử khám bệnh theo Mã Bệnh Nhân
        public List<DTO_KhamBenh> SearchKhamBenhByMaBN(int maBN)
        {
            List<DTO_KhamBenh> listKhamBenh = new List<DTO_KhamBenh>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM LichSuKhamBenh WHERE MaBN = @MaBN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBN", maBN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                                {
                                    MaLSKB = (int)reader["MaLSKB"],
                                    MaBS = (int)reader["MaBS"],
                                    MaBN = (int)reader["MaBN"],
                                    NgayKham = (DateTime)reader["NgayKham"],
                                    ChuanDoan = reader["ChuanDoan"].ToString(),
                                    MaPK = (int)reader["MaPK"]
                                };
                                listKhamBenh.Add(khamBenh);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // Xử lý lỗi nếu cần
                }
            }
            return listKhamBenh;
        }
        public bool IsLSKBIdExists(int maLSKB)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM LichSuKhamBenh WHERE MaLSKB = @MaLSKB";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
