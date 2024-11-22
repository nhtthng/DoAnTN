using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietToaThuoc
    {
        public int MaTT { get; set; }       // Mã Tờ Trình
        public int MaThuoc { get; set; }    // Mã Thuốc
        public int MaBS { get; set; }       // Mã Bác Sĩ
        public string CachDung { get; set; } // Cách Dùng
        public string LieuLuong { get; set; } // Liều Lượng
        public int MaBN { get; set; }       // Mã Bệnh Nhân
        public int MaLSKB { get; set; }
    }
}
