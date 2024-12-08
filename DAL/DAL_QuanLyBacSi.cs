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
                    string query = "INSERT INTO BacSi ( TenBS, GioiTinh, Email, SoDT, KinhNghiem, MatKhau, MaCK) VALUES ( @TenBS, @GioiTinh, @Email, @SoDT, @KinhNghiem, 1, @MaCK)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenBS", bacSi.TenBS);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", bacSi.Email);
                        cmd.Parameters.AddWithValue("@SoDT", bacSi.SoDT);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem);
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
                    string query = "UPDATE BacSi SET TenBS = @TenBS, GioiTinh = @GioiTinh, Email = @Email, SoDT = @SoDT, KinhNghiem = @KinhNghiem, MaCK = @MaCK WHERE MaBS = @MaBS";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBS", bacSi.MaBS);
                        cmd.Parameters.AddWithValue("@TenBS", bacSi.TenBS);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", bacSi.Email);
                        cmd.Parameters.AddWithValue("@SoDT", bacSi.SoDT);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem);
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
        public List<DTO_QuanLyBacSi> FindBacSiBySDT(string soDT)
        {
            List<DTO_QuanLyBacSi> danhSachBacSi = new List<DTO_QuanLyBacSi>();

            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaBS, TenBS, GioiTinh, Email, SoDT, KinhNghiem, MatKhau, MaCK FROM BacSi WHERE SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDT", soDT);

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
        // Hàm kiểm tra số điện thoại đã tồn tại
        public bool IsSoDTExists(string soDT)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM BacSi WHERE SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDT", soDT);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"Lỗi kiểm tra số điện thoại: {ex.Message}");
                return false;
            }
        }
        // Hàm kiểm tra email đã tồn tại
        public bool IsEmailExists(string email)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM BacSi WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // Hàm kiểm tra cấu trúc số điện thoại
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Regex kiểm tra số điện thoại (ví dụ: 10 số bắt đầu bằng 0)
            string phonePattern = @"^0\d{9}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, phonePattern);
        }
        // Hàm kiểm tra cấu trúc email
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex kiểm tra email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }

        // Lấy bác sĩ theo số điện thoại
        public DTO_QuanLyBacSi GetBacSiByPhone(string soDT)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM BacSi WHERE SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDT", soDT);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DTO_QuanLyBacSi
                                {
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    TenBS = reader["TenBS"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    MaCK = Convert.ToInt32(reader["MaCK"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        // Lấy bác sĩ theo email
        public DTO_QuanLyBacSi GetBacSiByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM BacSi WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DTO_QuanLyBacSi
                                {
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    TenBS = reader["TenBS"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    MaCK = Convert.ToInt32(reader["MaCK"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DTO_QuanLyBacSi GetBacSiByMaLSKB(int maLSKB)
        {
            DTO_QuanLyBacSi bacSi = null;
            string query = "SELECT B.* FROM BacSi B JOIN ChiTietToaThuoc CT ON B.MaBS = CT.MaBS WHERE CT.MaLSKB = @MaLSKB";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaLSKB", maLSKB);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bacSi = new DTO_QuanLyBacSi
                    {
                        MaBS = (int)reader["MaBS"],
                        TenBS = reader["TenBS"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        Email = reader["Email"].ToString(),
                        SoDT = reader["SoDT"].ToString(),
                        KinhNghiem = (int)reader["KinhNghiem"],
                        MaCK = (int)reader["MaCK"]
                    };
                }
            }
            return bacSi;
        }
    }
}
