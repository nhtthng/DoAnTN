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
        public List<DTO_QuanLyBacSi> GetBacSiList()
        {
            List<DTO_QuanLyBacSi> bacSiList = new List<DTO_QuanLyBacSi>();
            SqlConnection conn = SqlConnectionData.GetConnection(); // Lấy kết nối từ SqlConnectionData

            try
            {
                conn.Open();
                string query = "SELECT MaBS, TenBS FROM BacSi"; // Thay đổi tên bảng và cột nếu cần
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyBacSi bacSi = new DTO_QuanLyBacSi()
                        {
                            MaBS = reader.GetInt32(0), // Giả sử MaBS là cột đầu tiên
                            TenBS = reader.GetString(1) // Giả sử TenBS là cột thứ hai
                        };
                        bacSiList.Add(bacSi);
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

            return bacSiList;
        }
        public List<DTO_QuanLyBenhNhan> GetBenhNhanList()
        {
            List<DTO_QuanLyBenhNhan> benhNhanList = new List<DTO_QuanLyBenhNhan>();
            SqlConnection conn = SqlConnectionData.GetConnection(); // Lấy kết nối từ SqlConnectionData

            try
            {
                conn.Open();
                string query = "SELECT MaBN, HoTenBN FROM BenhNhan"; // Thay đổi tên bảng và cột nếu cần
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan()
                        {
                            MaBN = reader.GetInt32(0), // Giả sử MaBN là cột đầu tiên
                            HoTenBN = reader.GetString(1) // Giả sử HoTenBN là cột thứ hai
                        };
                        benhNhanList.Add(benhNhan);
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

            return benhNhanList;
        }
        public List<DTO_QuanLyPhongKham> GetPhongKhamList()
        {
            List<DTO_QuanLyPhongKham> phongKhamList = new List<DTO_QuanLyPhongKham>();
            SqlConnection conn = SqlConnectionData.GetConnection(); // Lấy kết nối từ SqlConnectionData

            try
            {
                conn.Open();
                string query = "SELECT MaPK, TenPK FROM PhongKham"; // Thay đổi tên bảng và cột nếu cần
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyPhongKham phongKham = new DTO_QuanLyPhongKham()
                        {
                            MaPK = reader.GetInt32(0), // Giả sử MaPK là cột đầu tiên
                            TenPK = reader.GetString(1) // Giả sử TenPK là cột thứ hai
                        };
                        phongKhamList.Add(phongKham);
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

            return phongKhamList;
        }
        public List<DTO_QuanLyDichVu> GetDichVuList()
        {
            List<DTO_QuanLyDichVu> dichVuList = new List<DTO_QuanLyDichVu>();
            SqlConnection conn = SqlConnectionData.GetConnection(); // Lấy kết nối từ SqlConnectionData

            try
            {
                conn.Open();
                string query = "SELECT MaDV, TenDV, Gia FROM DichVu"; // Thay đổi tên bảng và cột nếu cần
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyDichVu dichVu = new DTO_QuanLyDichVu()
                        {
                            MaDV = reader.GetInt32(0), // Giả sử MaDV là cột đầu tiên
                            TenDV = reader.GetString(1), // Giả sử TenDV là cột thứ hai
                            Gia = reader.GetDecimal(2) // Giả sử Gia là cột thứ ba
                        };
                        dichVuList.Add(dichVu);
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

            return dichVuList;
        }
        public List<DTO_NhanVien> GetNhanVienList()
        {
            List<DTO_NhanVien> nhanVienList = new List<DTO_NhanVien>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT MaNV, HoTen FROM NhanVien";
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_NhanVien nhanVien = new DTO_NhanVien()
                        {
                            MaNV = reader.GetInt32(0),
                            HoTen = reader.GetString(1)
                        };
                        nhanVienList.Add(nhanVien);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return nhanVienList;
        }
        public List<DTO_QuanLyBenhNhan> GetBenhNhanListFromCTSDDV()
        {
            List<DTO_QuanLyBenhNhan> benhNhanList = new List<DTO_QuanLyBenhNhan>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = @"
            SELECT DISTINCT BN.MaBN, BN.HoTenBN 
            FROM BenhNhan BN
            INNER JOIN CTSDDV CT ON BN.MaBN = CT.MaBN";

                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan()
                        {
                            MaBN = reader.GetInt32(0),
                            HoTenBN = reader.GetString(1)
                        };
                        benhNhanList.Add(benhNhan);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return benhNhanList;
        }
        public List<DTO_QuanLyBenhNhan> GetBenhNhanListFromLichHen()
        {
            List<DTO_QuanLyBenhNhan> benhNhanList = new List<DTO_QuanLyBenhNhan>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = @"
        SELECT DISTINCT BN.MaBN, BN.HoTenBN 
        FROM BenhNhan BN
        INNER JOIN LichHen LH ON BN.MaBN = LH.MaBN";

                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_QuanLyBenhNhan benhNhan = new DTO_QuanLyBenhNhan()
                        {
                            MaBN = reader.GetInt32(0),
                            HoTenBN = reader.GetString(1)
                        };
                        benhNhanList.Add(benhNhan);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return benhNhanList;
        }
        public List<DTO_HoaDon> GetMaHoaDonList()
        {
            List<DTO_HoaDon> hoaDonList = new List<DTO_HoaDon>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                // Lấy tất cả các mã hóa đơn từ bảng HoaDon
                string query = "SELECT MaHD FROM HoaDon";

                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_HoaDon hoaDon = new DTO_HoaDon()
                        {
                            MaHD = reader.GetInt32(0)
                        };
                        hoaDonList.Add(hoaDon);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return hoaDonList;
        }
        //public List<DTO_ChiTietSuDungDV> GetHoaDonByMaBN(int maBN)
        //{
        //    List<DTO_ChiTietSuDungDV> danhSachHoaDon = new List<DTO_ChiTietSuDungDV>();
        //    SqlConnection conn = SqlConnectionData.GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        string query = @"
        //    SELECT DISTINCT MaHD, MaBN, NgayLap 
        //    FROM CTSDDV 
        //    WHERE MaBN = @MaBN";

        //        SqlCommand command = new SqlCommand(query, conn);
        //        command.Parameters.AddWithValue("@MaBN", maBN);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                DTO_ChiTietSuDungDV chiTiet = new DTO_ChiTietSuDungDV()
        //                {
        //                    MaHD = reader.GetInt32(0),
        //                    MaBN = reader.GetInt32(1),
        //                    NgayLap = reader.GetDateTime(2)
        //                };
        //                danhSachHoaDon.Add(chiTiet);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //    finally
        //    {
        //        SqlConnectionData.CloseConnection(conn);
        //    }

        //    return danhSachHoaDon;
        //}
        public DTO_QuanLyBenhNhan GetThongTinBenhNhanByMaBN(int maBN)
        {
            DTO_QuanLyBenhNhan benhNhan = null;
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = @"
            SELECT SoDT 
            FROM BenhNhan 
            WHERE MaBN = @MaBN";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaBN", maBN);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        benhNhan = new DTO_QuanLyBenhNhan()
                        {
                            MaBN = maBN,
                            SoDT = reader.GetString(0)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return benhNhan;
        }
        public List<DTO_PhongBan> GetPhongBanList()
        {
            List<DTO_PhongBan> phongBanList = new List<DTO_PhongBan>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT MaPB, TenPB FROM PhongBan";
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_PhongBan phongBan = new DTO_PhongBan()
                        {
                            MaPB = reader.GetInt32(0),
                            TenPB = reader.GetString(1)
                        };
                        phongBanList.Add(phongBan);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return phongBanList;
        }
        public List<int> GetAllMaLSKB()
        {
            List<int> maLSKBList = new List<int>();
            SqlConnection conn = SqlConnectionData.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT MaLSKB FROM LichSuKhamBenh"; // Giả sử bảng KhamBenh có trường MaLSKB
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        maLSKBList.Add(reader.GetInt32(0)); // Lấy từng mã LSKB và thêm vào danh sách
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }

            return maLSKBList;
        }
    }
}
