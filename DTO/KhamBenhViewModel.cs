using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhamBenhViewModel
    {
        public DTO_KhamBenh KhamBenh { get; set; }
        public DTO_QuanLyBenhNhan BenhNhan { get; set; }
        public DTO_QuanLyBacSi BacSi { get; set; }
        public string KetLuan { get; set; }
    }
}
