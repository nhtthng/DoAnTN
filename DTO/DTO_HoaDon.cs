using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        public int MaHD {  get; set; }
        public DateTime NgayLapHD { get; set; }
        public int MaNV {  get; set; }
        public int MaBN { get; set; }
        public decimal TongTien {  get; set; }
        public string TrangThai { get; set; }
        public int GiamGia {  get; set; }
    }
}
