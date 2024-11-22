using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhongBan
    {
        public bool ThemPhongBan(DTO_PhongBan phongBan)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO PhongBan (MaPB, TenPB) VALUES (@MaPB, @TenPB)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPB", phongBan.MaPB);
                    cmd.Parameters.AddWithValue("@TenPB", phongBan.TenPB);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding department: " + ex.Message);
                    return false;
                }
                finally
                {
                    SqlConnectionData.CloseConnection(conn);
                }
            }
        }

        // Method to delete a department by MaPB
        public bool XoaPhongBan(int maPB)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM PhongBan WHERE MaPB = @MaPB";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPB", maPB);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting department: " + ex.Message);
                    return false;
                }
                finally
                {
                    SqlConnectionData.CloseConnection(conn);
                }
            }
        }

        // Method to update an existing department
        public bool SuaPhongBan(DTO_PhongBan phongBan)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE PhongBan SET TenPB = @TenPB WHERE MaPB = @MaPB";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPB", phongBan.MaPB);
                    cmd.Parameters.AddWithValue("@TenPB", phongBan.TenPB);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating department: " + ex.Message);
                    return false;
                }
                finally
                {
                    SqlConnectionData.CloseConnection(conn);
                }
            }
        }

        // Method to retrieve all departments
        public List<DTO_PhongBan> GetPhongBanList()
        {
            List<DTO_PhongBan> phongBanList = new List<DTO_PhongBan>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaPB, TenPB FROM PhongBan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DTO_PhongBan phongBan = new DTO_PhongBan
                        {
                            MaPB = Convert.ToInt32(reader["MaPB"]),
                            TenPB = reader["TenPB"].ToString()
                        };
                        phongBanList.Add(phongBan);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving departments: " + ex.Message);
                }
                finally
                {
                    SqlConnectionData.CloseConnection(conn);
                }
            }
            return phongBanList;
        }
    }
}
