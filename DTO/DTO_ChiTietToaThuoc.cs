using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietToaThuoc
    {
        public int MaLSKB {  get; set; }
        public int MaThuoc { get; set; }
        public string CachDung {  get; set; }
        public string LieuLuong { get; set; }
        public DateTime NgayKeToa {  get; set; } 
        public string LoiDanBS { get; set; }
        public int MaBS { get; set; }
    }
}
