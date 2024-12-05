using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InvoiceDetails
    {
        public DTO_HoaDon HoaDon { get; set; }
        public string HoTenBN { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDT { get; set; }
    }
}
