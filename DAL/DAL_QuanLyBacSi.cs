using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyBacSi
    {
        // Lấy tất cả bác sĩ
        public List<DTO_QuanLyBacSi> GetAllBacSi()
        {
            List<DTO_QuanLyBacSi> danhSachBacSi = new List<DTO_QuanLyBacSi>();

            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaBS, TenBS, GioiTinh, Email, SoDT, KinhNghiem, MatKhau, MaCK FROM BacSi";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_QuanLyBacSi bacSi = new DTO_QuanLyBacSi
                                {
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    TenBS = reader["TenBS"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    MaCK = Convert.ToInt32(reader["MaCK"])
                                };
                                danhSachBacSi.Add(bacSi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return danhSachBacSi;
        }
        // Thêm bác sĩ
        public bool AddBacSi(DTO_QuanLyBacSi bacSi)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO BacSi (MaBS, TenBS, GioiTinh, Email, SoDT, KinhNghiem, MatKhau, MaCK) VALUES (@MaBS, @TenBS, @GioiTinh, @Email, @SoDT, @KinhNghiem, @MatKhau, @MaCK)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBS", bacSi.MaBS); // Gán mã bác sĩ
                        cmd.Parameters.AddWithValue("@TenBS", bacSi.TenBS);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", bacSi.Email);
                        cmd.Parameters.AddWithValue("@SoDT", bacSi.SoDT);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem);
                        cmd.Parameters.AddWithValue("@MatKhau", bacSi.MatKhau);
                        cmd.Parameters.AddWithValue("@MaCK", bacSi.MaCK);

                        return cmd.ExecuteNonQuery() > 0; // Trả về true nếu thêm thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
        // Xóa bác sĩ
        public bool DeleteBacSi(int maBS)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM BacSi WHERE MaBS = @MaBS";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBS", maBS);
                        return cmd.ExecuteNonQuery() > 0; // Trả về true nếu xóa thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
        // Sửa bác sĩ
        public bool UpdateBacSi(DTO_QuanLyBacSi bacSi)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE BacSi SET TenBS = @TenBS, GioiTinh = @GioiTinh, Email = @Email, SoDT = @SoDT, KinhNghiem = @KinhNghiem, MatKhau = @MatKhau, MaCK = @MaCK WHERE MaBS = @MaBS";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBS", bacSi.MaBS);
                        cmd.Parameters.AddWithValue("@TenBS", bacSi.TenBS);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", bacSi.Email);
                        cmd.Parameters.AddWithValue("@SoDT", bacSi.SoDT);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem);
                        cmd.Parameters.AddWithValue("@MatKhau", bacSi.MatKhau);
                        cmd.Parameters.AddWithValue("@MaCK", bacSi.MaCK);

                        return cmd.ExecuteNonQuery() > 0; // Trả về true nếu sửa thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
        // Tìm kiếm bác sĩ
        public List<DTO_QuanLyBacSi> FindBacSiByMaBS(int maBS)
        {
            List<DTO_QuanLyBacSi> danhSachBacSi = new List<DTO_QuanLyBacSi>();

            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaBS, TenBS, GioiTinh, Email, SoDT, KinhNghiem, MatKhau, MaCK FROM BacSi WHERE MaBS = @MaBS";
                    

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                       
                        
                            cmd.Parameters.AddWithValue("@MaBS", maBS);
                        

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_QuanLyBacSi bacSi = new DTO_QuanLyBacSi
                                {
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    TenBS = reader["TenBS"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    MaCK = Convert.ToInt32(reader["MaCK"])
                                };
                                danhSachBacSi.Add(bacSi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return danhSachBacSi; // Trả về danh sách bác sĩ tìm thấy
        }
        public bool IsDoctorIdExists(int maBS)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM BacSi WHERE MaBS = @MaBS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBS);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
