using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Thuoc
    {
        public List<DTO_Thuoc> GetAllThuoc()
        {
            List<DTO_Thuoc> danhSachThuoc = new List<DTO_Thuoc>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaThuoc, TenThuoc, BietDuoc, CongDung, LuuY, DonGia, DonViTinh, SoLuong FROM Thuoc";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_Thuoc thuoc = new DTO_Thuoc
                        {
                            MaThuoc = reader.GetInt32(0),
                            TenThuoc = reader.GetString(1),
                            BietDuoc = reader.GetString(2),
                            CongDung = reader.GetString(3),
                            LuuY = reader.GetString(4),
                            DonGia = reader.GetDecimal(5),
                            DonViTinh = reader.GetString(6),
                            SoLuong = reader.GetInt32(7)
                        };
                        danhSachThuoc.Add(thuoc);
                    }
                }
            }

            return danhSachThuoc;
        }
        public void AddThuoc(DTO_Thuoc thuoc)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                // Kiểm tra xem MaThuoc đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaThuoc", thuoc.MaThuoc);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu đã tồn tại, ném ngoại lệ hoặc xử lý thông báo
                    throw new Exception("Mã thuốc đã tồn tại. Vui lòng nhập mã thuốc khác.");
                }

                // Nếu không tồn tại, thực hiện thêm thuốc
                string query = "INSERT INTO Thuoc ( TenThuoc, BietDuoc, CongDung, LuuY, DonGia, DonViTinh, SoLuong) " +
                               "VALUES ( @TenThuoc, @BietDuoc, @CongDung, @LuuY, @DonGia, @DonViTinh, @SoLuong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@MaThuoc", thuoc.MaThuoc);
                cmd.Parameters.AddWithValue("@TenThuoc", thuoc.TenThuoc);
                cmd.Parameters.AddWithValue("@BietDuoc", thuoc.BietDuoc);
                cmd.Parameters.AddWithValue("@CongDung", thuoc.CongDung);
                cmd.Parameters.AddWithValue("@LuuY", thuoc.LuuY);
                cmd.Parameters.AddWithValue("@DonGia", thuoc.DonGia);
                cmd.Parameters.AddWithValue("@DonViTinh", thuoc.DonViTinh);
                cmd.Parameters.AddWithValue("@SoLuong", thuoc.SoLuong);

                cmd.ExecuteNonQuery();
            }
        }

        // Xóa thuốc
        public void DeleteThuoc(int maThuoc)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<DTO_Thuoc> FindThuoc(string keyword)
        {
            List<DTO_Thuoc> danhSachThuoc = new List<DTO_Thuoc>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                // Tìm kiếm thuốc theo mã thuốc, tên thuốc hoặc biệt dược
                string query = "SELECT MaThuoc, TenThuoc, BietDuoc, CongDung, LuuY, DonGia, DonViTinh, SoLuong " +
                               "FROM Thuoc " +
                               "WHERE MaThuoc LIKE @keyword OR TenThuoc LIKE @keyword OR BietDuoc LIKE @keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Sử dụng ký tự đại diện để tìm kiếm

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_Thuoc thuoc = new DTO_Thuoc
                        {
                            MaThuoc = reader.GetInt32(0),
                            TenThuoc = reader.GetString(1),
                            BietDuoc = reader.GetString(2),
                            CongDung = reader.GetString(3),
                            LuuY = reader.GetString(4),
                            DonGia = reader.GetDecimal(5),
                            DonViTinh = reader.GetString(6),
                            SoLuong = reader.GetInt32(7)
                        };
                        danhSachThuoc.Add(thuoc);
                    }
                }
            }

            return danhSachThuoc;
        }


        // Sửa thuốc
        public void UpdateThuoc(DTO_Thuoc thuoc)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "UPDATE Thuoc SET TenThuoc = @TenThuoc, BietDuoc = @BietDuoc, CongDung = @CongDung, " +
                               "LuuY = @LuuY, DonGia = @DonGia, DonViTinh = @DonViTinh, SoLuong = @SoLuong " +
                               "WHERE MaThuoc = @MaThuoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuoc", thuoc.MaThuoc);
                cmd.Parameters.AddWithValue("@TenThuoc", thuoc.TenThuoc);
                cmd.Parameters.AddWithValue("@BietDuoc", thuoc.BietDuoc);
                cmd.Parameters.AddWithValue("@CongDung", thuoc.CongDung);
                cmd.Parameters.AddWithValue("@LuuY", thuoc.LuuY);
                cmd.Parameters.AddWithValue("@DonGia", thuoc.DonGia);
                cmd.Parameters.AddWithValue("@DonViTinh", thuoc.DonViTinh);
                cmd.Parameters.AddWithValue("@SoLuong", thuoc.SoLuong);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
