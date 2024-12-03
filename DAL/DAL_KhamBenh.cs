using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhamBenh
    {
        // Phương thức lấy tất cả lịch sử khám bệnh
        public List<DTO_KhamBenh> GetAllKhamBenh()
        {
            List<DTO_KhamBenh> listKhamBenh = new List<DTO_KhamBenh>();
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM LichSuKhamBenh";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                                {
                                    MaLSKB = (int)reader["MaLSKB"],
                                    MaBS = (int)reader["MaBS"],
                                    MaBN = (int)reader["MaBN"],
                                    NgayKham = (DateTime)reader["NgayKham"],
                                    ChuanDoan = reader["ChuanDoan"].ToString(),
                                    MaPK = (int)reader["MaPK"]
                                };
                                listKhamBenh.Add(khamBenh);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi
                    throw new Exception("Lỗi truy vấn danh sách khám bệnh: " + ex.Message);
                }
            }
            return listKhamBenh;
        }
        // Phương thức thêm lịch sử khám bệnh
        public bool AddKhamBenh(DTO_KhamBenh khamBenh)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {

                try
                {
                    conn.Open();

                    string query = "INSERT INTO LichSuKhamBenh (MaBS, MaBN, NgayKham, ChuanDoan, MaPK) VALUES (@MaBS, @MaBN, @NgayKham, @ChuanDoan, @MaPK)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBS", khamBenh.MaBS);
                        cmd.Parameters.AddWithValue("@MaBN", khamBenh.MaBN);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);
                        cmd.Parameters.AddWithValue("@MaPK", khamBenh.MaPK);
                        cmd.ExecuteNonQuery();
                    }

                    return true; // Thêm thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Phương thức xóa lịch sử khám bệnh
        public bool DeleteKhamBenh(int maLSKB)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM LichSuKhamBenh WHERE MaLSKB = @MaLSKB";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
                        cmd.ExecuteNonQuery();
                    }
                    return true; // Xóa thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Phương thức cập nhật lịch sử khám bệnh
        public bool UpdateKhamBenh(DTO_KhamBenh khamBenh)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE LichSuKhamBenh SET MaBS = @MaBS, MaBN = @MaBN, NgayKham = @NgayKham, ChuanDoan = @ChuanDoan, MaPK = @MaPK WHERE MaLSKB = @MaLSKB";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLSKB", khamBenh.MaLSKB);
                        cmd.Parameters.AddWithValue("@MaBS", khamBenh.MaBS);
                        cmd.Parameters.AddWithValue("@MaBN", khamBenh.MaBN);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);
                        cmd.Parameters.AddWithValue("@MaPK", khamBenh.MaPK);
                        cmd.ExecuteNonQuery();
                    }
                    return true; // Cập nhật thành công
                }
                catch (Exception)
                {
                    return false; // Có lỗi xảy ra
                }
            }
        }
        // Tìm kiếm lịch sử khám bệnh theo Mã Bệnh Nhân
        public List<DTO_QuanLyBenhNhan> SearchBenhNhanInLichHenBySDT(string soDT)
        {
            List<DTO_QuanLyBenhNhan> listBenhNhan = new List<DTO_QuanLyBenhNhan>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT DISTINCT 
                        BN.MaBN, 
                        BN.HoTenBN, 
                        BN.NgaySinh, 
                        BN.GioiTinh, 
                        BN.Email, 
                        BN.SoBHYT, 
                        BN.SoDT, 
                        BN.DiaChi,
                        LH.NgayHen,
                        LH.TinhTrang
                    FROM BenhNhan BN
                    INNER JOIN LichHen LH ON BN.MaBN = LH.MaBN
                    WHERE BN.SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDT", soDT);

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
                                listBenhNhan.Add(benhNhan);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi
                    throw new Exception("Lỗi truy vấn bệnh nhân trong Lịch Hẹn: " + ex.Message);
                }
            }

            return listBenhNhan;
        }
        public List<DTO_KhamBenh> SearchBenhNhanInKhamBenhBySDT(string soDT)
        {
            List<DTO_KhamBenh> listKhamBenh = new List<DTO_KhamBenh>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                KB.MaLSKB, 
                KB.MaBS, 
                KB.MaBN, 
                KB.NgayKham, 
                KB.ChuanDoan, 
                KB.MaPK
            FROM LichSuKhamBenh KB
            INNER JOIN BenhNhan BN ON KB.MaBN = BN.MaBN
            WHERE BN.SoDT = @SoDT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoDT", soDT);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                                {
                                    MaLSKB = Convert.ToInt32(reader["MaLSKB"]),
                                    MaBS = Convert.ToInt32(reader["MaBS"]),
                                    MaBN = Convert.ToInt32(reader["MaBN"]),
                                    NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                                    ChuanDoan = reader["ChuanDoan"].ToString(),
                                    MaPK = Convert.ToInt32(reader["MaPK"])
                                };
                                listKhamBenh.Add(khamBenh);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi
                    throw new Exception("Lỗi truy vấn lịch sử khám bệnh: " + ex.Message);
                }
            }

            return listKhamBenh;
        }
        //public bool IsLSKBIdExists(int maLSKB)
        //{
        //    bool exists = false;
        //    using (SqlConnection conn = SqlConnectionData.GetConnection())
        //    {
        //        conn.Open();
        //        string query = "SELECT COUNT(*) FROM LichSuKhamBenh WHERE MaLSKB = @MaLSKB";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
        //            exists = (int)cmd.ExecuteScalar() > 0;
        //        }
        //    }
        //    return exists;
        //}
        public List<DTO_KhamBenh> GetLichSuKhamBenhByNgay(DateTime ngayKham)
        {
            List<DTO_KhamBenh> danhSachLichSuKham = new List<DTO_KhamBenh>();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                            MaLSKB,
                            MaBS,
                            MaBN,
                            NgayKham,
                            ChuanDoan,
                            MaPK
                        FROM LichSuKhamBenh
                        WHERE CAST(NgayKham AS DATE) = @NgayKham";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayKham", ngayKham.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_KhamBenh lichSuKham = new DTO_KhamBenh
                            {
                                MaLSKB = Convert.ToInt32(reader["MaLSKB"]),
                                MaBS = Convert.ToInt32(reader["MaBS"]),
                                MaBN = Convert.ToInt32(reader["MaBN"]),
                                NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                                ChuanDoan = reader["ChuanDoan"].ToString(),
                                MaPK = Convert.ToInt32(reader["MaPK"])
                            };

                            danhSachLichSuKham.Add(lichSuKham);
                        }
                    }
                }

                SqlConnectionData.CloseConnection(conn);
            }

            return danhSachLichSuKham;
        }
        }
    
}
