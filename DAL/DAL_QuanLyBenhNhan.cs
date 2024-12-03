using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyBenhNhan
    {

        public List<DTO_QuanLyBenhNhan> GetAllPatients()
        {
            List<DTO_QuanLyBenhNhan> danhSachBenhNhan = new List<DTO_QuanLyBenhNhan>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                            MaBN,
                            HoTenBN,
                            NgaySinh,
                            GioiTinh,
                            Email,
                            SoBHYT,
                            SoDT,
                            DiaChi
                        FROM BenhNhan";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan
                            {
                                MaBN = Convert.ToInt32(reader["MaBN"]),
                                HoTenBN = reader["HoTenBN"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                Email = reader["Email"].ToString(),
                                SoBHYT = reader["SoBHYT"].ToString(),
                                SoDT = reader["SoDT"].ToString(),
                                DiaChi = reader["DiaChi"].ToString()
                            };

                            danhSachBenhNhan.Add(benhNhan);
                        }
                    }
                }

                SqlConnectionData.CloseConnection(conn);
            }

            return danhSachBenhNhan;
        }
        public bool AddPatient(DTO_QuanLyBenhNhan patient)
        {
            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    // Mở kết nối
                    conn.Open();
                    // Tạo câu lệnh truy vấn
                    string query = "INSERT INTO BenhNhan (HoTenBN,NgaySinh,GioiTinh,Email,SoBHYT,SoDT,DiaChi) VALUES (@HoTenBN,@NgaySinh,@GioiTinh,@Email,@SoBHYT,@SoDT,@DiaChi)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu lệnh
                        cmd.Parameters.AddWithValue("@HoTenBN", patient.HoTenBN);
                        cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", patient.Email);
                        cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);
                        cmd.Parameters.AddWithValue("@SoDT", patient.SoDT);
                        cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool DeletePatient(int maBN)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    // Mở kết nối
                    conn.Open();
                    // Tạo câu lệnh truy vấn
                    string query = "DELETE FROM BenhNhan WHERE MaBN = @MaBN";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu lệnh
                        cmd.Parameters.AddWithValue("@MaBN", maBN);
                        // Thực hiện truy vấn
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm bệnh nhân: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UpDatePatient(DTO_QuanLyBenhNhan patient)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    // Mở kết nối
                    conn.Open();
                    // Tạo câu lệnh truy vấn
                    string query = "UPDATE BenhNhan SET HoTenBN = @HoTenBN, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, Email = @Email, SoBHYT = @SoBHYT, SoDT = @SoDT, DiaChi = @DiaChi WHERE MaBN = @MaBN";
                    //SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu lệnh
                        cmd.Parameters.AddWithValue("@MaBN", patient.MaBN);
                        cmd.Parameters.AddWithValue("@HoTenBN", patient.HoTenBN);
                        cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
                        cmd.Parameters.AddWithValue("@Email", patient.Email);
                        cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);
                        cmd.Parameters.AddWithValue("@SoDT", patient.SoDT);
                        cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
                        // Thực hiện truy vấn
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;// Trả về true nếu có hàng bị cập nhật
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi sửa bệnh nhân: " + ex.Message);
                    return false;
                }
            }
        }
        public DTO_QuanLyBenhNhan SearchPatientBySDT(string soDienThoai)
        {
            // Validate số điện thoại (nếu cần)
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                return null;
            }

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Thay đổi câu truy vấn để tìm theo số điện thoại
                    string query = "SELECT * FROM BenhNhan WHERE SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số số điện thoại
                        cmd.Parameters.AddWithValue("@SoDT", soDienThoai);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo và trả về đối tượng DTO_QuanLyBenhNhan
                                return new DTO_QuanLyBenhNhan
                                {
                                    MaBN = Convert.ToInt32(reader["MaBN"]),
                                    HoTenBN = reader["HoTenBN"].ToString(),
                                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    SoBHYT = reader["SoBHYT"].ToString(),
                                    SoDT = reader["SoDT"].ToString(),
                                    DiaChi = reader["DiaChi"].ToString(),
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    Console.WriteLine("Lỗi khi tìm bệnh nhân theo số điện thoại: " + ex.Message);
                    // Hoặc throw để xử lý ở tầng gọi
                    // throw;
                }
            }
            return null; // Trả về null nếu không tìm thấy bệnh nhân
        }
        public bool KiemTraTrungSoDienThoai(string soDienThoai)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM BenhNhan WHERE SoDT = @SoDienThoai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool KiemTraTrungEmail(string email)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM BenhNhan WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool KiemTraTrungSoBHYT(string soBHYT)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM BenhNhan WHERE SoBHYT = @SoBHYT";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoBHYT", soBHYT);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}