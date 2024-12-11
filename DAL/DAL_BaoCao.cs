using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using ClosedXML.Excel;

namespace DAL
{
    public class DAL_BaoCao
    {
        // Hàm lấy báo cáo theo khoảng thời gian
        //private static readonly string strcon = @"Data Source=SANTA\SQLEXPRESS;Initial Catalog=QuanLyPKTN_Final_2;User ID=sa;Password=123";

        // Hàm lấy báo cáo theo khoảng thời gian
        public static System.Data.DataTable GetBaoCao(DateTime tungay, DateTime denngay)
        {
            // Tạo kết nối SQL
            using (SqlConnection conn = SqlConnectionData.GetConnection())
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn SQL với tham số ngày bắt đầu và kết thúc
                string query = @"
                    SELECT 
    CAST(h.NgayLapHD AS DATE) AS Ngay,
    -- Tổng tiền dịch vụ
    SUM(ISNULL(ctdv.ThanhTien, 0)) AS TongTienDichVu,
    -- Tổng tiền thuốc
    SUM(ISNULL(cthd.ThanhTien, 0)) AS TongTienThuoc,
    -- Tổng doanh thu
    SUM(ISNULL(ctdv.ThanhTien, 0) + ISNULL(cthd.ThanhTien, 0)) AS TongDoanhThu,
    
    -- Thống kê chi tiết
    COUNT(DISTINCT h.MaHD) AS SoLuongHoaDon,
    COUNT(DISTINCT ctdv.MaChiTietSDDV) AS SoLuongDichVu,
    COUNT(DISTINCT cthd.MaChiTietHD) AS SoLuongThuoc
FROM 
    HoaDon h
LEFT JOIN 
    LichSuKhamBenh lskb ON h.MaLSKB = lskb.MaLSKB
LEFT JOIN 
    CTSDDV ctdv ON lskb.MaLSKB = ctdv.MaLSKB
LEFT JOIN 
    CTHD cthd ON lskb.MaLSKB = cthd.MaLSKB
WHERE 
    h.NgayLapHD BETWEEN @TuNgay AND @DenNgay
GROUP BY 
    CAST(h.NgayLapHD AS DATE)
ORDER BY 
    Ngay;";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Tungay", tungay);
                    cmd.Parameters.AddWithValue("@Denngay", denngay);

                    // Tạo đối tượng DataTable để lưu kết quả
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        da.Fill(dt);  // Điền dữ liệu vào DataTable
                        return dt;  // Trả về DataTable chứa kết quả
                    }
                }
            }
        }
        public static void ExportToExcel(DataTable dt, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Report");

                // Thêm tiêu đề cột vào Excel
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                }

                // Thêm dữ liệu vào các ô của Excel
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 2, col + 1).Value = dt.Rows[row][col].ToString();
                    }
                }

                // Lưu tệp Excel
                workbook.SaveAs(filePath);
            }
        }
    }
}
