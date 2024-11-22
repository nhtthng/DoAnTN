using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LichSuKhamBenh
    {
        public int MaLSKB { get; set; }      // Mã lịch khám bệnh
        public int MaBS { get; set; }        // Mã bác sĩ
        public int MaBN { get; set; }        // Mã bệnh nhân
        public DateTime NgayKham { get; set; } // Ngày khám
        public string ChuanDoan { get; set; } // Chuẩn đoán
        public int MaPK { get; set; }        // Mã phòng khám
        public string TrieuChung { get; set; } // Triệu chứng
    }
}
