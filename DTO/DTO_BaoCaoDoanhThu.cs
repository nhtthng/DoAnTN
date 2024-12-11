using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BaoCaoDoanhThu
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public decimal TongDoanhThu { get; set; }
        public List<DTO_DoanhThu> ChiTietDoanhThu { get; set; }

        public DTO_BaoCaoDoanhThu()
        {
            ChiTietDoanhThu = new List<DTO_DoanhThu>();
        }
    }
}
