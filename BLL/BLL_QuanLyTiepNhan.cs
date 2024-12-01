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
    public class BLL_QuanLyTiepNhan
    {
        private DAL_QuanLyTiepNhan _QuanLyTiepNhanDAL = new DAL_QuanLyTiepNhan();
        // Lấy tất cả các bệnh nhân đã tiếp nhận
        public List<DTO_QuanLyTiepNhan> GetAllTiepNhan()
        {
            return _QuanLyTiepNhanDAL.GetAllTiepNhan();
        }
        // Thêm một bệnh nhân mới
        public bool ThemTiepNhan(DTO_QuanLyTiepNhan tiepNhan)
        {
            // Kiểm tra các ràng buộc
            if (tiepNhan.MaBenhNhan <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ.");

            if (tiepNhan.NgayTiepNhan > DateTime.Now)
                throw new ArgumentException("Ngày tiếp nhận không hợp lệ.");

            if (string.IsNullOrEmpty(tiepNhan.TrieuChung))
                throw new ArgumentException("Triệu chứng không được để trống.");

            if (tiepNhan.MaPK <= 0)
                throw new ArgumentException("Mã phòng khám không hợp lệ.");

            return _QuanLyTiepNhanDAL.ThemTiepNhan(tiepNhan);
        }
        // Xóa một bệnh nhân
        public bool XoaTiepNhan(int maTiepNhan)
        {
            // Kiểm tra mã tiếp nhận
            if (maTiepNhan <= 0)
                throw new ArgumentException("Mã tiếp nhận không hợp lệ.");

            return _QuanLyTiepNhanDAL.XoaTiepNhan(maTiepNhan);
        }
        // Sửa thông tin một bệnh nhân
        public bool SuaTiepNhan(DTO_QuanLyTiepNhan tiepNhan)
        {
            // Kiểm tra các ràng buộc
            if (tiepNhan.MaTiepNhan <= 0)
                throw new ArgumentException("Mã tiếp nhận không hợp lệ.");

            if (tiepNhan.MaBenhNhan <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ.");

            if (tiepNhan.NgayTiepNhan > DateTime.Now)
                throw new ArgumentException("Ngày tiếp nhận không hợp lệ.");

            if (string.IsNullOrEmpty(tiepNhan.TrangThai))
                throw new ArgumentException("Trạng thái không được để trống.");

            if (string.IsNullOrEmpty(tiepNhan.TrieuChung))
                throw new ArgumentException("Triệu chứng không được để trống.");

            if (tiepNhan.MaPK <= 0)
                throw new ArgumentException("Mã phòng khám không hợp lệ.");

            return _QuanLyTiepNhanDAL.SuaTiepNhan(tiepNhan);
        }
        // Tìm kiếm thông tin tiếp nhận bệnh nhân theo số điện thoại
        public List<DTO_QuanLyTiepNhan> TimKiemThongTinTiepNhanTheoDienThoai(string soDienThoai)
        {
            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(soDienThoai))
                throw new ArgumentException("Số điện thoại không hợp lệ.");

            try
            {
                return _QuanLyTiepNhanDAL.TimKiemThongTinTiepNhanTheoDienThoai(soDienThoai);
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi tìm kiếm thông tin tiếp nhận bệnh nhân.", ex);
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }
    }
}
