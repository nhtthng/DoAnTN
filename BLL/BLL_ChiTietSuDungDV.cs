using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChiTietSuDungDV
    {
        private DAL_ChiTietSuDungDV _ChiTietSuDungDVDAL = new DAL_ChiTietSuDungDV();
        // Thêm Chi Tiết Sử Dụng Dịch Vụ
        public bool ThemChiTietSuDungDV(DTO_ChiTietSuDungDV chiTiet)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (chiTiet == null)
                throw new ArgumentNullException("Thông tin chi tiết sử dụng dịch vụ không được để trống");

            if (chiTiet.MaHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            if (chiTiet.MaDV <= 0)
                throw new ArgumentException("Mã dịch vụ không hợp lệ");

            if (chiTiet.SoLuong <= 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0");

            if (chiTiet.Gia < 0)
                throw new ArgumentException("Giá không được âm");

            if (chiTiet.MaBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            if (chiTiet.NgayLap == DateTime.MinValue)
                throw new ArgumentException("Ngày lập không hợp lệ");
            if (chiTiet.MaBS <= 0)
                throw new ArgumentException("Mã bác sĩ không hợp lệ");

            return _ChiTietSuDungDVDAL.AddChiTietSuDungDV(chiTiet);
        }

        // Xóa chi tiết sử dụng dịch vụ
        public bool XoaChiTietSuDungDV(int maHD, int maDV, int maBN)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (maHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            if (maDV <= 0)
                throw new ArgumentException("Mã dịch vụ không hợp lệ");

            if (maBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            return _ChiTietSuDungDVDAL.DeleteChiTietSuDungDV(maHD, maDV, maBN);
        }
        // Sửa chi tiết sử dụng dịch vụ
        // Sửa Chi Tiết Sử Dụng Dịch Vụ
        public bool SuaChiTietSuDungDV(DTO_ChiTietSuDungDV chiTiet)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (chiTiet == null)
                throw new ArgumentNullException("Thông tin chi tiết sử dụng dịch vụ không được để trống");

            if (chiTiet.MaHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            if (chiTiet.MaDV <= 0)
                throw new ArgumentException("Mã dịch vụ không hợp lệ");

            if (chiTiet.SoLuong <= 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0");

            if (chiTiet.Gia < 0)
                throw new ArgumentException("Giá không được âm");

            if (chiTiet.MaBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            if (chiTiet.NgayLap == DateTime.MinValue)
                throw new ArgumentException("Ngày lập không hợp lệ");

            return _ChiTietSuDungDVDAL.UpdateChiTietSuDungDV(chiTiet);
        }
        // Tìm kiếm Chi Tiết Sử Dụng Dịch Vụ theo Mã Bệnh Nhân
        public List<DTO_ChiTietSuDungDV> TimChiTietSuDungDVTheoMaBN(int maBN)
        {
            // Kiểm tra tính hợp lệ của mã bệnh nhân
            if (maBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            var danhSach = _ChiTietSuDungDVDAL.SearchChiTietSuDungDV(maBN);

            if (danhSach == null || danhSach.Count == 0)
                throw new Exception($"Không tìm thấy chi tiết sử dụng dịch vụ cho bệnh nhân có mã {maBN}");

            return danhSach;
        }
        // Lấy tất cả chi tiết sử dụng dịch vụ
        public List<DTO_ChiTietSuDungDV> GetAllChiTietSuDungDV()
        {
            return _ChiTietSuDungDVDAL.GetAllChiTietSuDungDV();
        }
        // Lấy hóa đơn mới nhất chưa hoàn thành của bệnh nhân
        public DTO_HoaDon LayHoaDonMoiNhatChuaThanhToan(int maBN)
        {
            // Kiểm tra tính hợp lệ của mã bệnh nhân
            if (maBN <= 0)
            {
                throw new ArgumentException("Mã bệnh nhân không hợp lệ.");
            }

            try
            {
                return _ChiTietSuDungDVDAL.LayHoaDonMoiNhatChuaThanhToan(maBN);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw new Exception($"Lỗi nghiệp vụ khi lấy hóa đơn: {ex.Message}", ex);
            }
        }
        // Tìm bệnh nhân trong lịch hẹn theo số điện thoại
        public List<DTO_QuanLyBenhNhan> TimBenhNhanTrongLichHen(string soDienThoai)
        {
            // Kiểm tra tính hợp lệ của số điện thoại
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                throw new ArgumentException("Số điện thoại không được để trống.");
            }

            // Kiểm tra định dạng số điện thoại (tùy theo quy tắc của bạn)
            if (!IsValidPhoneNumber(soDienThoai))
            {
                throw new ArgumentException("Số điện thoại không đúng định dạng.");
            }

            try
            {
                // Lấy danh sách bệnh nhân
                List<DTO_QuanLyBenhNhan> danhSachBenhNhan = _ChiTietSuDungDVDAL.TimBenhNhanTrongLichHen(soDienThoai);

                // Kiểm tra nếu không tìm thấy bệnh nhân
                if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
                {
                    throw new Exception("Không tìm thấy bệnh nhân nào với số điện thoại này.");
                }

                return danhSachBenhNhan;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw new Exception($"Lỗi nghiệp vụ khi tìm bệnh nhân: {ex.Message}", ex);
            }
        }
        // Hàm kiểm tra định dạng số điện thoại (tuỳ chỉnh theo quy tắc của bạn)
        private bool IsValidPhoneNumber(string soDienThoai)
        {
            // Ví dụ: Kiểm tra số điện thoại Việt Nam
            // Bạn có thể điều chỉnh regex theo quy tắc cụ thể của mình
            string pattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            return System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, pattern);
        }
    }
}
