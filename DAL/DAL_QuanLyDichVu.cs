using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyDichVu
    {
        public List<DTO_QuanLyDichVu> GetAllServices()
        {
            var services = new List<DTO_QuanLyDichVu>();

            // Mở kết nối
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                
                try
                {
                    conn.Open();
                    // Câu truy vấn lấy tất cả các dịch vụ
                    string query = "SELECT MaDV, TenDV, Gia FROM DichVu";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Ánh xạ dữ liệu vào DTO
                                DTO_QuanLyDichVu service = new DTO_QuanLyDichVu
                                {
                                    MaDV = Convert.ToInt32(reader["MaDV"]),
                                    TenDV = reader["TenDV"].ToString(),
                                    Gia = Convert.ToDecimal(reader["Gia"])
                                };
                                services.Add(service);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi lấy danh sách dịch vụ: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối
                    SqlConnectionData.CloseConnection(conn);
                }
            }

            return services;
        }
        public bool AddService(DTO_QuanLyDichVu service)
        {
            bool isAdded = false;

            // Mở kết nối
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                
                try
                {
                    conn.Open();
                    // Câu truy vấn thêm dịch vụ
                    string query = "INSERT INTO DichVu (MaDV,TenDV, Gia) VALUES (@MaDV,@TenDV, @Gia)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán giá trị cho các tham số
                        cmd.Parameters.AddWithValue("@MaDV", service.MaDV);
                        cmd.Parameters.AddWithValue("@TenDV", service.TenDV);
                        cmd.Parameters.AddWithValue("@Gia", service.Gia);

                        // Thực thi câu lệnh và kiểm tra số hàng bị ảnh hưởng
                        int rowsAffected = cmd.ExecuteNonQuery();
                        isAdded = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi thêm dịch vụ: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối
                    SqlConnectionData.CloseConnection(conn);
                }
            }
            return isAdded;
        }
        public bool DeleteService(int maDV)
        {
            bool isDeleted = false;

            // Mở kết nối
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                
                try
                {
                    conn.Open();
                    // Câu truy vấn xóa dịch vụ
                    string query = "DELETE FROM DichVu WHERE MaDV = @MaDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán giá trị cho tham số
                        cmd.Parameters.AddWithValue("@MaDV", maDV);

                        // Thực thi câu lệnh và kiểm tra số hàng bị ảnh hưởng
                        int rowsAffected = cmd.ExecuteNonQuery();
                        isDeleted = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi xóa dịch vụ: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối
                    SqlConnectionData.CloseConnection(conn);
                }
            }

            return isDeleted;
        }
        public bool UpdateService(DTO_QuanLyDichVu service)
        {
            bool isUpdated = false;

            // Mở kết nối
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                
                try
                {
                    conn.Open();
                    // Câu truy vấn cập nhật dịch vụ
                    string query = "UPDATE DichVu SET TenDV = @TenDV, Gia = @Gia WHERE MaDV = @MaDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán giá trị cho các tham số
                        cmd.Parameters.AddWithValue("@MaDV", service.MaDV);
                        cmd.Parameters.AddWithValue("@TenDV", service.TenDV);
                        cmd.Parameters.AddWithValue("@Gia", service.Gia);

                        // Thực thi câu lệnh và kiểm tra số hàng bị ảnh hưởng
                        int rowsAffected = cmd.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi cập nhật dịch vụ: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối
                    SqlConnectionData.CloseConnection(conn);
                }
            }

            return isUpdated;
        }
        public DTO_QuanLyDichVu FindServiceById(int maDV)
        {
            DTO_QuanLyDichVu service = null;

            // Mở kết nối
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                
                try
                {
                    conn.Open();
                    // Câu truy vấn tìm kiếm dịch vụ theo mã
                    string query = "SELECT MaDV, TenDV, Gia FROM DichVu WHERE MaDV = @MaDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán giá trị cho tham số
                        cmd.Parameters.AddWithValue("@MaDV", maDV);

                        // Thực thi câu lệnh và đọc dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo đối tượng DTO_QuanLyDichVu từ dữ liệu đọc được
                                service = new DTO_QuanLyDichVu
                                {
                                    MaDV = Convert.ToInt32(reader["MaDV"]),
                                    TenDV = reader["TenDV"].ToString(),
                                    Gia = Convert.ToDecimal(reader["Gia"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi tìm dịch vụ: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối
                    SqlConnectionData.CloseConnection(conn);
                }
            }
            return service;
        }
        public bool IsServiceIdExists(int maDV)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DichVu WHERE MaDV = @MaDV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDV", maDV);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
