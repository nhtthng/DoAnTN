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
            var patients = new List<DTO_QuanLyBenhNhan>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    // Tạo câu lệnh truy vấn
                    string query = "SELECT * FROM BenhNhan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thực hiện truy vấn và đọc dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_QuanLyBenhNhan patient = new DTO_QuanLyBenhNhan
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
                                patients.Add(patient);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần, ví dụ ghi log lỗi
                    Console.WriteLine("Lỗi khi load bệnh nhân: " + ex.Message);
                }
            }
            return patients;
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
                    string query = "INSERT INTO BenhNhan (MaBN,HoTenBN,NgaySinh,GioiTinh,Email,SoBHYT,SoDT,DiaChi) VALUES (@MaBN,@HoTenBN,@NgaySinh,@GioiTinh,@Email,@SoBHYT,@SoDT,@DiaChi)";
      
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
                    
                    using(SqlCommand cmd = new SqlCommand(query, conn))
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
                    using(SqlCommand cmd = new SqlCommand(query, conn))
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
        public DTO_QuanLyBenhNhan SearchPatientByMaBN(int maBN)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM BenhNhan WHERE MaBN = @MaBN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBN", maBN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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
                    // Xử lý ngoại lệ nếu cần, ví dụ ghi log lỗi
                    Console.WriteLine("Lỗi khi tìm bệnh nhân: " + ex.Message);
                }
            }
            return null; // Trả về null nếu không tìm thấy bệnh nhân
        }
    }
}
