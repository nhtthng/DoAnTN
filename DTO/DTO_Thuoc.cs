using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Thuoc
    {
        public int MaThuoc { get; set; } // Mã thuốc
        public string TenThuoc { get; set; } // Tên thuốc
        public string BietDuoc { get; set; } // Biệt dược
        public string CongDung { get; set; } // Công dụng
        public string LuuY { get; set; } // Lưu ý
        public decimal DonGia { get; set; } // Đơn giá
        public string DonViTinh { get; set; } // Đơn vị tính
        public int SoLuong { get; set; }
    }
}
