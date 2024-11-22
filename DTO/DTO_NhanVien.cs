using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        public int MaNV { get; set; }      // Mã nhân viên
        public string HoTen { get; set; }     // Họ và tên
        public string GioiTinh { get; set; }   // Giới tính
        public DateTime NgaySinh { get; set; } // Ngày sinh
        public string SoDT { get; set; }       // Số điện thoại
        public int MaPB { get; set; }       // Mã phòng ban
        public string MatKhau { get; set; }    // Mật khẩu
        public int Quyen { get; set; }
    }
}
