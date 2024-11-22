using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLyPhongKham
    {
        // Thêm phòng khám
        public bool AddPhongKham(DTO_QuanLyPhongKham phongKham)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "INSERT INTO PhongKham (MaPK,TenPK, MaCK) VALUES (@MaPK,@TenPK, @MaCK)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPK", phongKham.MaPK);
                cmd.Parameters.AddWithValue("@TenPK", phongKham.TenPK);
                cmd.Parameters.AddWithValue("@MaCK", phongKham.MaCK);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Xóa phòng khám
        public bool DeletePhongKham(int maPK)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "DELETE FROM PhongKham WHERE MaPK = @MaPK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPK", maPK);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Sửa thông tin phòng khám
        public bool UpdatePhongKham(DTO_QuanLyPhongKham phongKham)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "UPDATE PhongKham SET TenPK = @TenPK, MaCK = @MaCK WHERE MaPK = @MaPK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPK", phongKham.MaPK);
                cmd.Parameters.AddWithValue("@TenPK", phongKham.TenPK);
                cmd.Parameters.AddWithValue("@MaCK", phongKham.MaCK);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Xuất tất cả phòng khám
        public List<DTO_QuanLyPhongKham> GetAllPhongKham()
        {
            List<DTO_QuanLyPhongKham> phongKhams = new List<DTO_QuanLyPhongKham>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaPK, TenPK, MaCK FROM PhongKham";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_QuanLyPhongKham phongKham = new DTO_QuanLyPhongKham
                    {
                        MaPK = (int)reader["MaPK"],
                        TenPK = reader["TenPK"].ToString(),
                        MaCK = (int)reader["MaCK"]
                    };
                    phongKhams.Add(phongKham);
                }
            }

            return phongKhams;
        }
        // Tìm kiếm phòng khám bằng mã phòng khám
        public DTO_QuanLyPhongKham GetPhongKhamByMaPK(int maPK)
        {
            DTO_QuanLyPhongKham phongKham = null;

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                string query = "SELECT MaPK, TenPK, MaCK FROM PhongKham WHERE MaPK = @MaPK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPK", maPK);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    phongKham = new DTO_QuanLyPhongKham
                    {
                        MaPK = (int)reader["MaPK"],
                        TenPK = reader["TenPK"].ToString(),
                        MaCK = (int)reader["MaCK"]
                    };
                }
            }

            return phongKham; // Trả về null nếu không tìm thấy
        }
        public bool IsClinicIdExists(int maPK)
        {
            bool exists = false;
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM PhongKham WHERE MaPK = @MaPK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPK", maPK);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return exists;
        }
    }
}
