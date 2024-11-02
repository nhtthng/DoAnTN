using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataHelper
    {
        public List<DTO_QuanLyChuyenKhoa> GetChuyenKhoaList()
        {
            List<DTO_QuanLyChuyenKhoa> chuyenKhoaList = new List<DTO_QuanLyChuyenKhoa>();
            SqlConnection conn = SqlConnectionData.GetConnection(); // Lấy kết nối từ SqlConnectionData

            try
            {
                conn.Open();
                string query = "SELECT MaCK, TenCK FROM ChuyenKhoa"; // Thay đổi tên bảng và cột nếu cần
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyChuyenKhoa chuyenKhoa = new DTO_QuanLyChuyenKhoa()
                        {
                            MaCK = reader.GetInt32(0), // Giả sử MaCK là cột đầu tiên
                            TenCK = reader.GetString(1) // Giả sử TenCK là cột thứ hai
                        };
                        chuyenKhoaList.Add(chuyenKhoa);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (nếu cần thiết)
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn); // Đóng kết nối
            }

            return chuyenKhoaList;
        }
    }
}
