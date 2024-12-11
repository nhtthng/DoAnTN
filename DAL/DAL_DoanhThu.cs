using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace DAL
{
    public class DAL_DoanhThu
    {
        public DTO_BaoCaoDoanhThu LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            DTO_BaoCaoDoanhThu baoCao = new DTO_BaoCaoDoanhThu
            {
                TuNgay = tuNgay,
                DenNgay = denNgay
            };

            SqlConnection conn = null;
            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT 
                    DV.MaDV,
                    DV.TenDV,
                    SUM(CTSDDV.SoLuong) as SoLuong,
                    SUM(CTSDDV.ThanhTien) as ThanhTien
                FROM CTSDDV 
                JOIN DichVu DV ON CTSDDV.MaDV = DV.MaDV
                WHERE CTSDDV.NgayLap BETWEEN @TuNgay AND @DenNgay
                GROUP BY DV.MaDV, DV.TenDV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_DoanhThu chiTiet = new DTO_DoanhThu
                            {
                                MaDV = Convert.ToInt32(reader["MaDV"]),
                                TenDichVu = reader["TenDV"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                            };

                            baoCao.ChiTietDoanhThu.Add(chiTiet);
                        }
                    }
                }

                // Tính tổng doanh thu
                baoCao.TongDoanhThu = baoCao.ChiTietDoanhThu.Sum(x => x.ThanhTien);

                return baoCao;
            }
            catch (Exception ex)
            {
                // Log lỗi
                throw new Exception("Lỗi truy xuất báo cáo doanh thu: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }
        public void XuatBaoCaoExcel(DTO_BaoCaoDoanhThu baoCao, string filePath)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Báo Cáo Doanh Thu");

                    // Tiêu đề
                    worksheet.Cells[1, 1].Value = "BÁO CÁO DOANH THU";
                    worksheet.Cells[2, 1].Value = $"Từ ngày: {baoCao.TuNgay:dd/MM/yyyy}";
                    worksheet.Cells[3, 1].Value = $"Đến ngày: {baoCao.DenNgay:dd/MM/yyyy}";

                    // Header
                    worksheet.Cells[5, 1].Value = "Mã DV";
                    worksheet.Cells[5, 2].Value = "Tên Dịch Vụ";
                    worksheet.Cells[5, 3].Value = "Số Lượng";
                    worksheet.Cells[5, 4].Value = "Thành Tiền";

                    // Dữ liệu
                    int row = 6;
                    foreach (var item in baoCao.ChiTietDoanhThu)
                    {
                        worksheet.Cells[row, 1].Value = item.MaDV;
                        worksheet.Cells[row, 2].Value = item.TenDichVu;
                        worksheet.Cells[row, 3].Value = item.SoLuong;
                        worksheet.Cells[row, 4].Value = item.ThanhTien;
                        row++;
                    }

                    // Tổng doanh thu
                    worksheet.Cells[row, 3].Value = "Tổng Doanh Thu:";
                    worksheet.Cells[row, 4].Value = baoCao.TongDoanhThu;

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xuất báo cáo Excel: " + ex.Message);
            }
        }
        // Phương thức hỗ trợ thống kê theo nhiều tiêu chí
        public List<DTO_DoanhThu> LayChiTietDoanhThuTheoDichVu(DateTime tuNgay, DateTime denNgay)
        {
            List<DTO_DoanhThu> danhSach = new List<DTO_DoanhThu>();
            SqlConnection conn = null;

            try
            {
                conn = SqlConnectionData.GetConnection();
                conn.Open();

                string query = @"
                SELECT 
                    DV.MaDV,
                    DV.TenDV,
                    COUNT(CTSDDV.MaDV) as SoLuong,
                    SUM(CTSDDV.ThanhTien) as TongTien
                FROM DichVu DV
                LEFT JOIN CTSDDV ON DV.MaDV = CTSDDV.MaDV
                WHERE CTSDDV.NgayLap BETWEEN @TuNgay AND @DenNgay
                GROUP BY DV.MaDV, DV.TenDV
                ORDER BY TongTien DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(new DTO_DoanhThu
                            {
                                MaDV = Convert.ToInt32(reader["MaDV"]),
                                TenDichVu = reader["TenDV"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                ThanhTien = Convert.ToDecimal(reader["TongTien"])
                            });
                        }
                    }
                }

                return danhSach;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết doanh thu: " + ex.Message);
            }
            finally
            {
                SqlConnectionData.CloseConnection(conn);
            }
        }

    }
}
