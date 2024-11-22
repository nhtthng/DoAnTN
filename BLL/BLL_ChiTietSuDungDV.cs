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
    }
}
