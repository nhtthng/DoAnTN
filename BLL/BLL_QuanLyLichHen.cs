using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyLichHen
    {
        private DAL_QuanLyLichHen _QuanLyLichHen = new DAL_QuanLyLichHen();
        // Thêm lịch hẹn
        // Thêm lịch hẹn
        public bool AddLichHen(DTO_LichHen lichHen)
        {
            // Có thể thêm kiểm tra dữ liệu ở đây nếu cần
            return _QuanLyLichHen.AddLichHen(lichHen);
        }

        // Cập nhật lịch hẹn
        // Sửa lịch hẹn
        public bool UpdateLichHen(DTO_LichHen updatedLichHen)
        {
            // Có thể thêm kiểm tra dữ liệu ở đây nếu cần
            return _QuanLyLichHen.UpdateLichHen(updatedLichHen);
        }
        // Xóa lịch hẹn
        public bool DeleteLichHen(int maLH)
        {
            // Có thể thêm kiểm tra xem lịch hẹn có tồn tại hay không trước khi xóa
            return _QuanLyLichHen.DeleteLichHen(maLH);
        }

        // Lấy tất cả lịch hẹn
        public List<DTO_LichHen> GetAllLichHen()
        {
            return _QuanLyLichHen.GetAllLichHen();
        }
        // Tìm kiếm lịch hẹn theo mã lịch hẹn
        public DTO_LichHen GetLichHenByMaLH(int maLH)
        {
            return _QuanLyLichHen.GetLichHenByMaLH(maLH);
        }
        public bool checkIdAppointment(int id)
        {
            if (_QuanLyLichHen.IsAppointmentIdExists(id) != false)
            {
                return false;
            }
            return true;
        }
    }
}
