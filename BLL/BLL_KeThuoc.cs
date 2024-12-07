using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KeThuoc
    {
        private DAL_KeThuoc _KeThuocDAL = new DAL_KeThuoc();
        // Phương thức xác thực cho DTO_ChiTietToaThuoc
        public List<DTO_ChiTietToaThuoc> GetAllChiTietToaThuoc()
        {
            return _KeThuocDAL.GetAllChiTietToaThuoc();
        }
        private void ValidateChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            if (chiTietToaThuoc == null)
                throw new ArgumentNullException(nameof(chiTietToaThuoc), "Chi tiết toa thuốc không được null.");

            if (chiTietToaThuoc.MaLSKB <= 0)
                throw new ArgumentException("Mã lịch sử khám bệnh phải lớn hơn 0.", nameof(chiTietToaThuoc.MaLSKB));

            if (chiTietToaThuoc.MaThuoc <= 0)
                throw new ArgumentException("Mã thuốc phải lớn hơn 0.", nameof(chiTietToaThuoc.MaThuoc));

            if (string.IsNullOrWhiteSpace(chiTietToaThuoc.CachDung))
                throw new ArgumentException("Cách dùng không được để trống.", nameof(chiTietToaThuoc.CachDung));

            if (string.IsNullOrWhiteSpace(chiTietToaThuoc.LieuLuong))
                throw new ArgumentException("Liều lượng không được để trống.", nameof(chiTietToaThuoc.LieuLuong));

            if (chiTietToaThuoc.NgayKeToa == DateTime.MinValue)
                throw new ArgumentException("Ngày kê toa không hợp lệ.", nameof(chiTietToaThuoc.NgayKeToa));

            if (chiTietToaThuoc.MaBS <= 0)
                throw new ArgumentException("Mã bác sĩ phải lớn hơn 0.", nameof(chiTietToaThuoc.MaBS));
        }
        // Thêm chi tiết toa thuốc
        public bool AddChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            // Kiểm tra dữ liệu đầu vào
            ValidateChiTietToaThuoc(chiTietToaThuoc);
            return _KeThuocDAL.AddChiTietToaThuoc(chiTietToaThuoc);
        }
        // Sửa chi tiết toa thuốc
        public bool UpdateChiTietToaThuoc(DTO_ChiTietToaThuoc chiTietToaThuoc)
        {
            // Kiểm tra dữ liệu đầu vào
            ValidateChiTietToaThuoc(chiTietToaThuoc);
            return _KeThuocDAL.UpdateChiTietToaThuoc(chiTietToaThuoc);
        }
        // Xóa chi tiết toa thuốc
        public bool DeleteChiTietToaThuoc(int maLSKB, int maThuoc)
        {
            // Kiểm tra dữ liệu đầu vào
            if (maLSKB <= 0)
                throw new ArgumentException("Mã lịch sử khám bệnh phải lớn hơn 0.");
            if (maThuoc <= 0)
                throw new ArgumentException("Mã thuốc phải lớn hơn 0.");

            return _KeThuocDAL.DeleteChiTietToaThuoc(maLSKB, maThuoc);
        }
        // Tìm kiếm thông tin chi tiết toa thuốc bằng số điện thoại của bệnh nhân
        public List<DTO_ChiTietToaThuoc> SearchChiTietToaThuocByPhone(string phoneNumber)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Số điện thoại không được để trống.");

            return _KeThuocDAL.SearchChiTietToaThuocByPhone(phoneNumber);
        }
        // Lấy danh sách bệnh nhân từ lịch sử khám bệnh
        public List<DTO_QuanLyBenhNhan> GetAllBenhNhanFromLichSuKham()
        {
            return _KeThuocDAL.GetAllBenhNhanFromLichSuKham();
        }
    }
}
