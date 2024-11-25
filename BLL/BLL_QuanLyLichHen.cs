using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyLichHen
    {
        private DAL_QuanLyLichHen _QuanLyLichHen = new DAL_QuanLyLichHen();
        // Thêm lịch hẹn
        // Kiểm tra tính hợp lệ của lịch hẹn trước khi thêm
        public DTO_QuanLyBenhNhan GetBenhNhanBySDT(string soDT)
        {
            // 1. Kiểm tra số điện thoại có hợp lệ không
            if (!IsValidPhoneNumber(soDT))
            {
                // Có thể log lỗi hoặc ném ngoại lệ
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            // 2. Kiểm tra số điện thoại có tồn tại trong hệ thống không
            DTO_QuanLyBenhNhan benhNhan = _QuanLyLichHen.GetBenhNhanBySDT(soDT);

            if (benhNhan == null)
            {
                // Có thể log hoặc xử lý khi không tìm thấy bệnh nhân
                return null; // hoặc throw new Exception("Không tìm thấy bệnh nhân");
            }

            // 3. Kiểm tra các điều kiện bổ sung về bệnh nhân nếu cần
            if (string.IsNullOrWhiteSpace(benhNhan.HoTenBN))
            {
                throw new InvalidOperationException("Thông tin bệnh nhân không đầy đủ");
            }

            return benhNhan;
        }
        public DTO_QuanLyBacSi GetBacSiBySDT(string soDT)
        {
            // 1. Kiểm tra số điện thoại có hợp lệ không
            if (!IsValidPhoneNumber(soDT))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            // 2. Kiểm tra số điện thoại có tồn tại trong hệ thống không
            DTO_QuanLyBacSi bacSi = _QuanLyLichHen.GetBacSiBySDT(soDT);

            if (bacSi == null)
            {
                // Có thể log hoặc xử lý khi không tìm thấy bác sĩ
                return null; // hoặc throw new Exception("Không tìm thấy bác sĩ");
            }

            // 3. Kiểm tra các điều kiện bổ sung về bác sĩ nếu cần
            if (string.IsNullOrWhiteSpace(bacSi.TenBS))
            {
                throw new InvalidOperationException("Thông tin bác sĩ không đầy đủ");
            }

            // 4. Kiểm tra trạng thái hoạt động của bác sĩ (nếu có)
            // Ví dụ: if (!bacSi.TrangThai) throw new Exception("Bác sĩ đã nghỉ việc");

            return bacSi;
        }
        private bool ValidateLichHen(DTO_LichHen lichHen)
        {
            // Kiểm tra các điều kiện cơ bản
            if (lichHen.MaBS <= 0 || lichHen.MaBN <= 0)
            {
                throw new ArgumentException("Mã bác sĩ hoặc mã bệnh nhân không hợp lệ.");
            }

            // Kiểm tra ngày hẹn không được là ngày quá khứ
            if (lichHen.NgayHen.Date < DateTime.Today)
            {
                throw new ArgumentException("Không thể đặt lịch hẹn trong quá khứ.");
            }

            // Kiểm tra giờ hẹn
            if (lichHen.ThoiGianHen.TimeOfDay < new TimeSpan(7, 0, 0) ||
                lichHen.ThoiGianHen.TimeOfDay > new TimeSpan(20, 0, 0))
            {
                throw new ArgumentException("Thời gian hẹn phải trong khoảng 7:00 - 20:00.");
            }

            return true;
        }
        public bool AddLichHen(DTO_LichHen lichHen)
        {
            // Kiểm tra tính hợp lệ của lịch hẹn
            ValidateLichHen(lichHen);

            // Kiểm tra trùng lịch hẹn
            if (_QuanLyLichHen.KiemTraTrungLichHen(lichHen.MaBS, lichHen.MaBN, lichHen.NgayHen, lichHen.ThoiGianHen))
            {
                throw new Exception("Lịch hẹn này đã tồn tại. Vui lòng chọn thời gian khác.");
            }

            // Nếu không trùng thì thực hiện thêm lịch hẹn
            return _QuanLyLichHen.AddLichHen(lichHen);
        }

        // Cập nhật lịch hẹn
        // Sửa lịch hẹn
        public bool UpdateLichHen(DTO_LichHen updatedLichHen)
        {
            // Kiểm tra tính hợp lệ của lịch hẹn
            ValidateLichHen(updatedLichHen);

            // Kiểm tra xem lịch hẹn có tồn tại không trước khi cập nhật
            var existingLichHen = _QuanLyLichHen.GetAllLichHen()
                .FirstOrDefault(lh => lh.MaLH == updatedLichHen.MaLH);

            if (existingLichHen == null)
            {
                throw new Exception("Lịch hẹn không tồn tại.");
            }

            return _QuanLyLichHen.UpdateLichHen(updatedLichHen);
        }
        // Xóa lịch hẹn
        public bool DeleteLichHen(int maLH)
        {
            // Kiểm tra xem lịch hẹn có tồn tại không
            var existingLichHen = _QuanLyLichHen.GetAllLichHen()
                .FirstOrDefault(lh => lh.MaLH == maLH);

            if (existingLichHen == null)
            {
                throw new Exception("Lịch hẹn không tồn tại.");
            }

            return _QuanLyLichHen.DeleteLichHen(maLH);
        }

        // Lấy tất cả lịch hẹn
        public List<DTO_LichHen> GetAllLichHen()
        {
            return _QuanLyLichHen.GetAllLichHen();
        }
        // Tìm kiếm lịch hẹn theo mã lịch hẹn
        public List<DTO_LichHen> GetLichHenBySDT(string soDT)
        {
            // Kiểm tra tính hợp lệ của số điện thoại
            if (string.IsNullOrWhiteSpace(soDT))
            {
                throw new ArgumentException("Số điện thoại không được để trống.");
            }

            return _QuanLyLichHen.GetLichHenBySDT(soDT);
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Loại bỏ các khoảng trắng
            phoneNumber = phoneNumber.Trim();

            // Kiểm tra các điều kiện:
            // 1. Không được để trống
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // 2. Chỉ chứa số và độ dài từ 10-11 ký tự
            // Regex cho số điện thoại Việt Nam
            string phonePattern = @"^(0[1-9][0-9]{8,9})$";

            // Sử dụng Regex để kiểm tra
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
    }
}
