using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KeThuoc
    {
        public DataTable LayThongTinBenhNhan()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT LichSuKhamBenh.MaLSKB, benhnhan.MaBN, benhnhan.HoTenBN, LichSuKhamBenh.MaBS
        FROM LichSuKhamBenh
        INNER JOIN benhnhan ON LichSuKhamBenh.MaBN = benhnhan.MaBN";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open(); // Mở kết nối
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt); // Điền dữ liệu vào DataTable
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi (có thể log hoặc thông báo)
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return dt;
        }
        public string LuuToaThuoc(string maTT, string maLSKB, DateTime ngayKeToa, string loiDanBS)
        {
            string query = @"
        INSERT INTO ToaThuoc (MaTT, MaLSKB, NgayKeToa, LoiDanBS)
        VALUES (@MaTT, @MaLSKB, @NgayKeToa, @LoiDanBS)";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTT", maTT);
                    cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);
                    cmd.Parameters.AddWithValue("@NgayKeToa", ngayKeToa);
                    cmd.Parameters.AddWithValue("@LoiDanBS", loiDanBS);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return maTT; // Trả về MaTT để sử dụng cho việc lưu chi tiết
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null; // Trả về null nếu có lỗi
                    }
                }
            }
        }



        public bool LuuChiTietToaThuoc(string maTT, string maThuoc, string maBS, string cachDung, string lieuLuong, string maBN, string maLSKB)
        {
            string query = @"
        INSERT INTO ChiTietToaThuoc (MaTT, MaThuoc, MaBS, CachDung, LieuLuong, MaBN, MaLSKB)
        VALUES (@MaTT, @MaThuoc, @MaBS, @CachDung, @LieuLuong, @MaBN, @MaLSKB)";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTT", maTT);
                    cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                    cmd.Parameters.AddWithValue("@MaBS", maBS);
                    cmd.Parameters.AddWithValue("@CachDung", cachDung);
                    cmd.Parameters.AddWithValue("@LieuLuong", lieuLuong);
                    cmd.Parameters.AddWithValue("@MaBN", maBN);
                    cmd.Parameters.AddWithValue("@MaLSKB", maLSKB);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0; // Trả về true nếu lưu thành công
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false; // Trả về false nếu có lỗi
                    }
                }
            }
        }


        public DataTable LayDSToaThuoc()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            ToaThuoc.MaTT, 
            LichSuKhamBenh.MaBS, 
            benhnhan.MaBN, 
            benhnhan.HoTenBN, 
            Thuoc.TenThuoc, 
            Thuoc.BietDuoc, 
            ChiTietToaThuoc.LieuLuong, 
            ChiTietToaThuoc.CachDung, 
            ToaThuoc.LoiDanBS, 
            ToaThuoc.NgayKeToa,
            ChiTietToaThuoc.MaThuoc  -- Thêm MaThuoc vào truy vấn
        FROM 
            ToaThuoc
        INNER JOIN 
            LichSuKhamBenh ON ToaThuoc.MaLSKB = LichSuKhamBenh.MaLSKB
        INNER JOIN 
            benhnhan ON LichSuKhamBenh.MaBN = benhnhan.MaBN
        INNER JOIN 
            ChiTietToaThuoc ON ToaThuoc.MaTT = ChiTietToaThuoc.MaTT
        INNER JOIN 
            Thuoc ON ChiTietToaThuoc.MaThuoc = Thuoc.MaThuoc";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt); // Điền dữ liệu vào DataTable
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi (có thể log hoặc thông báo lỗi)
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public DataTable LayDSToaThuocByMaBN(string maBN)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            ToaThuoc.MaTT, 
            LichSuKhamBenh.MaBS, 
            benhnhan.MaBN, 
            benhnhan.HoTenBN, 
            Thuoc.TenThuoc, 
            Thuoc.BietDuoc, 
            ChiTietToaThuoc.LieuLuong, 
            ChiTietToaThuoc.CachDung, 
            ToaThuoc.LoiDanBS, 
            ToaThuoc.NgayKeToa,
            ChiTietToaThuoc.MaThuoc  -- Thêm MaThuoc vào truy vấn
        FROM 
            ToaThuoc
        INNER JOIN 
            LichSuKhamBenh ON ToaThuoc.MaLSKB = LichSuKhamBenh.MaLSKB
        INNER JOIN 
            benhnhan ON LichSuKhamBenh.MaBN = benhnhan.MaBN
        INNER JOIN 
            ChiTietToaThuoc ON ToaThuoc.MaTT = ChiTietToaThuoc.MaTT
        INNER JOIN 
            Thuoc ON ChiTietToaThuoc.MaThuoc = Thuoc.MaThuoc
        WHERE 
            benhnhan.MaBN = @MaBN"; // Thêm điều kiện để lọc theo MaBN

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBN", maBN); // Thêm tham số vào câu lệnh SQL
                    try
                    {
                        conn.Open(); // Mở kết nối
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt); // Điền dữ liệu vào DataTable
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi (có thể log hoặc thông báo)
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return dt; // Trả về DataTable chứa danh sách toa thuốc
        }

        public bool KiemTraMaTT(string maTT)
        {
            string query = "SELECT COUNT(*) FROM ToaThuoc WHERE MaTT = @MaTT";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTT", maTT);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Trả về true nếu mã toa thuốc đã tồn tại
                }
            }
        }
        public DataTable LayThongTinThuoc(string maThuoc)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        TenThuoc, 
        BietDuoc 
    FROM 
        Thuoc 
    WHERE 
        MaThuoc = @MaThuoc";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaThuoc", maThuoc); // Thêm tham số vào câu lệnh SQL
                    try
                    {
                        conn.Open(); // Mở kết nối
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt); // Điền dữ liệu vào DataTable
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi (có thể log hoặc thông báo)
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return dt; // Trả về DataTable chứa thông tin thuốc
        }

        public bool CapNhatToaThuocVaChiTiet(DTO_ToaThuoc toaThuoc, List<DTO_ChiTietToaThuoc> chiTietToaThuocs)
        {
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Cập nhật thông tin toa thuốc
                        string queryToaThuoc = @"
                UPDATE ToaThuoc
                SET MaLSKB = @MaLSKB, NgayKeToa = @NgayKeToa, LoiDanBS = @LoiDanBS
                WHERE MaTT = @MaTT";

                        using (SqlCommand cmdToaThuoc = new SqlCommand(queryToaThuoc, conn, transaction))
                        {
                            cmdToaThuoc.Parameters.AddWithValue("@MaTT", toaThuoc.MaTT);
                            cmdToaThuoc.Parameters.AddWithValue("@MaLSKB", toaThuoc.MaLSKB);
                            cmdToaThuoc.Parameters.AddWithValue("@NgayKeToa", toaThuoc.NgayKeToa);
                            cmdToaThuoc.Parameters.AddWithValue("@LoiDanBS", toaThuoc.LoiDanBS);
                            cmdToaThuoc.ExecuteNonQuery();
                        }

                        
                        string deleteChiTiet = "DELETE FROM ChiTietToaThuoc WHERE MaTT = @MaTT";
                        using (SqlCommand cmdDeleteChiTiet = new SqlCommand(deleteChiTiet, conn, transaction))
                        {
                            cmdDeleteChiTiet.Parameters.AddWithValue("@MaTT", toaThuoc.MaTT);
                            cmdDeleteChiTiet.ExecuteNonQuery();
                        }

                        // Thêm chi tiết toa thuốc mới
                        string queryChiTiet = @"
                INSERT INTO ChiTietToaThuoc (MaTT, MaThuoc, MaBS, CachDung, LieuLuong, MaBN, MaLSKB)
                VALUES (@MaTT, @MaThuoc, @MaBS, @CachDung, @LieuLuong, @MaBN, @MaLSKB)";

                        foreach (var chiTiet in chiTietToaThuocs)
                        {
                            using (SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, conn, transaction))
                            {
                                cmdChiTiet.Parameters.AddWithValue("@MaTT", chiTiet.MaTT);
                                cmdChiTiet.Parameters.AddWithValue("@MaThuoc", chiTiet.MaThuoc);
                                cmdChiTiet.Parameters.AddWithValue("@MaBS", chiTiet.MaBS);
                                cmdChiTiet.Parameters.AddWithValue("@CachDung", chiTiet.CachDung);
                                cmdChiTiet.Parameters.AddWithValue("@LieuLuong", chiTiet.LieuLuong);
                                cmdChiTiet.Parameters.AddWithValue("@MaBN", chiTiet.MaBN);
                                cmdChiTiet.Parameters.AddWithValue("@MaLSKB", chiTiet.MaLSKB);
                                cmdChiTiet.ExecuteNonQuery();
                            }
                        }

                        // Nếu tất cả thành công, commit giao dịch
                        transaction.Commit();
                        return true; // Trả về true nếu cập nhật thành công
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback giao dịch
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false; // Trả về false nếu có lỗi
                    }
                }
            }
        }



        public bool XoaToaThuocVaChiTiet(string maTT)
        {
            // Xóa các chi tiết toa thuốc trước
            string queryChiTiet = "DELETE FROM ChiTietToaThuoc WHERE MaTT = @MaTT";

            // Xóa toa thuốc
            string queryToaThuoc = "DELETE FROM ToaThuoc WHERE MaTT = @MaTT";

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                conn.Open();

                // Xóa chi tiết toa thuốc
                using (SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, conn))
                {
                    cmdChiTiet.Parameters.AddWithValue("@MaTT", maTT);
                    cmdChiTiet.ExecuteNonQuery();
                }

                // Xóa toa thuốc
                using (SqlCommand cmdToaThuoc = new SqlCommand(queryToaThuoc, conn))
                {
                    cmdToaThuoc.Parameters.AddWithValue("@MaTT", maTT);
                    cmdToaThuoc.ExecuteNonQuery();
                }
            }

            return true; // Hoặc kiểm tra và trả về kết quả xóa
        }
        public DataTable LayLichSuKhamBenhTheoNgay(DateTime selectedDate)
        {
            string query = @"
SELECT LichSuKhamBenh.MaLSKB, benhnhan.MaBN, benhnhan.HoTenBN, LichSuKhamBenh.MaBS
FROM LichSuKhamBenh
INNER JOIN benhnhan ON LichSuKhamBenh.MaBN = benhnhan.MaBN
WHERE LichSuKhamBenh.NgayKham = @NgayKham";


            var parameters = new Dictionary<string, object>
    {
        { "@NgayKham", selectedDate.ToString("yyyy-MM-dd") }
    };

            DataTable result = new DataTable();

            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return result;
        }

        public DataTable LayThongTinToaThuocVaChiTiet(string maTT)
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        ToaThuoc.MaTT, 
        LichSuKhamBenh.MaBS, 
        benhnhan.MaBN, 
        benhnhan.HoTenBN, 
        benhnhan.NgaySinh,  
        benhnhan.GioiTinh,  
        benhnhan.DiaChi,    
        Thuoc.TenThuoc, 
        Thuoc.BietDuoc, 
        ChiTietToaThuoc.LieuLuong, 
        ChiTietToaThuoc.CachDung, 
        ToaThuoc.LoiDanBS, 
        ToaThuoc.NgayKeToa,
        ChiTietToaThuoc.MaThuoc  
    FROM 
        ToaThuoc
    INNER JOIN 
        LichSuKhamBenh ON ToaThuoc.MaLSKB = LichSuKhamBenh.MaLSKB
    INNER JOIN 
        benhnhan ON LichSuKhamBenh.MaBN = benhnhan.MaBN
    INNER JOIN 
        ChiTietToaThuoc ON ToaThuoc.MaTT = ChiTietToaThuoc.MaTT
    INNER JOIN 
        Thuoc ON ChiTietToaThuoc.MaThuoc = Thuoc.MaThuoc
    WHERE 
        ToaThuoc.MaTT = @MaTT";

            try
            {
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@MaTT", SqlDbType.VarChar).Value = maTT;  // Chỉ rõ kiểu dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);  // Lấy dữ liệu vào DataTable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return dt;
        }




    }
}
