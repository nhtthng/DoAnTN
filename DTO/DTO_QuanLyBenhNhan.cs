using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_QuanLyBenhNhan
    {
        public int MaBN { get; set; }
        public string HoTenBN { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoBHYT { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public override string ToString()
        {
            return $"{MaBN} - {HoTenBN}"; // Ví dụ: Hiển thị Mã BN và Họ Tên
        }
    }

}
