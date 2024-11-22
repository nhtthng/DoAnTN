using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyChuyenKhoa
    {
        // Lấy tất cả chuyên khoa
        public List<DTO_QuanLyChuyenKhoa> GetAllChuyenKhoa()
        {
            List<DTO_QuanLyChuyenKhoa> listChuyenKhoa = new List<DTO_QuanLyChuyenKhoa>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaCK, TenCK FROM ChuyenKhoa"; // Giả sử tên bảng là ChuyenKhoa
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_QuanLyChuyenKhoa chuyenKhoa = new DTO_QuanLyChuyenKhoa
                            {
                                MaCK = Convert.ToInt32(reader["MaCk"]),
                                TenCK = reader["TenCK"].ToString()
                            };
                            listChuyenKhoa.Add(chuyenKhoa);
                        }
                    }
                }
            }
            return listChuyenKhoa;
        }
        // Thêm chuyên khoa
        public bool AddChuyenKhoa(DTO_QuanLyChuyenKhoa chuyenKhoa)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ChuyenKhoa (MaCK,TenCK) VALUES (@MaCK,@TenCK)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCK", chuyenKhoa.MaCK);
                    cmd.Parameters.AddWithValue("@TenCK", chuyenKhoa.TenCK);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Sửa chuyên khoa
        public bool UpdateChuyenKhoa(DTO_QuanLyChuyenKhoa chuyenKhoa)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "UPDATE ChuyenKhoa SET TenCK = @TenCK WHERE MaCK = @MaCK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCK", chuyenKhoa.MaCK);
                    cmd.Parameters.AddWithValue("@TenCK", chuyenKhoa.TenCK);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa chuyên khoa
        public bool DeleteChuyenKhoa(int maCK)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM ChuyenKhoa WHERE MaCK = @MaCK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCK", maCK);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // tìm kiếm chuyên khoa
        public List<DTO_QuanLyChuyenKhoa> GetChuyenKhoaByMaCK(int maCK)
        {
            List<DTO_QuanLyChuyenKhoa> danhSachChuyenKhoa = new List<DTO_QuanLyChuyenKhoa>();

            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaCK, TenCK FROM ChuyenKhoa WHERE MaCK = @MaCK";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCK", maCK);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var chuyenKhoa = new DTO_QuanLyChuyenKhoa
                                {
                                    MaCK = Convert.ToInt32(reader["MaCK"]),
                                    TenCK = reader["TenCK"].ToString()
                                };
                                danhSachChuyenKhoa.Add(chuyenKhoa);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return danhSachChuyenKhoa; // Trả về danh sách chuyên khoa
        }
        public bool IsCKIdExists(int maCK)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM ChuyenKhoa WHERE MaCK = @MaCK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCK", maCK);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
