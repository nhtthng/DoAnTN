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
        private static readonly string strcon = @"Data Source=SANTA\SQLEXPRESS;Initial Catalog=QuanLyPKTN_Final_2;User ID=sa;Password=123";

        // Hàm lấy báo cáo theo khoảng thời gian
        public static System.Data.DataTable GetBaoCao(DateTime tungay, DateTime denngay)
        {
            // Tạo kết nối SQL
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn SQL với tham số ngày bắt đầu và kết thúc
                string query = @"
                    SELECT 
                        h.NgayLapHD AS Ngay,
                        SUM(ctd.Gia * ctd.SoLuong) AS TongTienDichVu,
                        SUM(thuoc.DonGia * cthd.SoLuong) AS TongTienThuoc,
                        (SUM(ctd.Gia * ctd.SoLuong) + SUM(thuoc.DonGia * cthd.SoLuong)) AS TongDoanhThu
                    FROM 
                        HoaDon h
                    JOIN 
                        CTSDDV ctd ON h.MaHD = ctd.MaHD
                    JOIN 
                        DichVu dv ON ctd.MaDV = dv.MaDV
                    LEFT JOIN 
                        CTHD cthd ON h.MaHD = cthd.MaHD
                    LEFT JOIN 
                        Thuoc thuoc ON cthd.MaThuoc = thuoc.MaThuoc
                    WHERE 
                        h.NgayLapHD BETWEEN @Tungay AND @Denngay
                    GROUP BY 
                        h.NgayLapHD
                    ORDER BY 
                        h.NgayLapHD;";

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
