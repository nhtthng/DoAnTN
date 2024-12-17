using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuenMatKhau
    {
        public bool CheckEmailInDatabase(string email)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM BacSi WHERE Email = @Email " +
                               "UNION ALL " +
                               "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = 0;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count += reader.GetInt32(0);
                        }
                    }

                    return count > 0; // Trả về true nếu email tồn tại, ngược lại false
                }
            }
        }

        public bool ResetPassword(string email, string newPassword)
        {
            // Mã hóa mật khẩu mới
            string hashedPassword = PasswordHasher.HashPassword(newPassword);

            // Kiểm tra xem email thuộc về nhân viên hay bác sĩ
            if (IsEmailOfEmployee(email))
            {
                // Nếu là nhân viên, thực hiện cập nhật mật khẩu
                return UpdateEmployeePassword(email, hashedPassword);
            }
            else if (IsEmailOfDoctor(email))
            {
                // Nếu là bác sĩ, thực hiện cập nhật mật khẩu
                return UpdateDoctorPassword(email, hashedPassword);
            }

            return false; // Trả về false nếu email không hợp lệ
        }

        // Phương thức kiểm tra email của nhân viên
        private bool IsEmailOfEmployee(string email)
        {
            using (var connection = new SqlConnection("connection_string"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Employees WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Nếu có ít nhất 1 bản ghi, email là của nhân viên
                }
            }
        }

        // Phương thức kiểm tra email của bác sĩ
        private bool IsEmailOfDoctor(string email)
        {
            using (var connection = new SqlConnection("connection_string"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Doctors WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Nếu có ít nhất 1 bản ghi, email là của bác sĩ
                }
            }
        }

        // Phương thức cập nhật mật khẩu cho nhân viên
        private bool UpdateEmployeePassword(string email, string newPassword)
        {
            using (var connection = new SqlConnection("connection_string"))
            {
                connection.Open();
                string query = "UPDATE Employees SET Password = @Password WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword); // Sử dụng mật khẩu đã mã hóa
                    command.Parameters.AddWithValue("@Email", email);
                    return command.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
                }
            }
        }

        // Phương thức cập nhật mật khẩu cho bác sĩ
        private bool UpdateDoctorPassword(string email, string newPassword)
        {
            using (var connection = new SqlConnection("connection_string"))
            {
                connection.Open();
                string query = "UPDATE Doctors SET Password = @Password WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword); // Sử dụng mật khẩu đã mã hóa
                    command.Parameters.AddWithValue("@Email", email);
                    return command.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
                }
            }
        }
    }
}
