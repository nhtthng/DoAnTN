using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ToaThuoc
    {
        public int MaTT { get; set; }       // Mã Tờ Trình
        public int MaLSKB { get; set; }     // Mã Lịch Sử Khám Bệnh
        public DateTime NgayKeToa { get; set; } // Ngày Kê Toa
        public string LoiDanBS { get; set; }
    }
}
