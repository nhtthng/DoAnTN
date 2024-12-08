using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_HoaDon
    {
        private DAL_HoaDon _dalHoaDonDAL = new DAL_HoaDon();
        private DAL_QuanLyBenhNhan dalBenhNhan = new DAL_QuanLyBenhNhan();
        private DAL_QuanLyNhanVien dalNhanVien = new DAL_QuanLyNhanVien();

        // Thêm Hóa Đơn
        // Thêm Hóa Đơn
        public int ThemHoaDon(DTO_HoaDon hoaDon)
        {
            if (hoaDon == null)
                throw new ArgumentNullException("Thông tin hóa đơn không được để trống");

            if (hoaDon.NgayLapHD == DateTime.MinValue)
                hoaDon.NgayLapHD = DateTime.Now;

            if (hoaDon.MaNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            if (hoaDon.MaBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            return _dalHoaDonDAL.ThemHoaDon(hoaDon);
        }

        // Xóa Hóa Đơn
        public bool XoaHoaDon(int maHD)
        {
            if (maHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            return _dalHoaDonDAL.XoaHoaDon(maHD);
        }
        // Cập Nhật Hóa Đơn
        public bool CapNhatHoaDon(DTO_HoaDon hoaDon)
        {
            if (hoaDon == null)
                throw new ArgumentNullException("Thông tin hóa đơn không được để trống");

            if (hoaDon.MaHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            if (hoaDon.MaNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            if (hoaDon.MaBN <= 0)
                throw new ArgumentException("Mã bệnh nhân không hợp lệ");

            return _dalHoaDonDAL.CapNhatHoaDon(hoaDon);
        }
        // Lấy tất cả hóa đơn
        public List<DTO_HoaDon> LayTatCaHoaDon()
        {
            return _dalHoaDonDAL.LayTatCaHoaDon();
        }
        // Tìm Hóa Đơn Theo Mã
        public List<DTO_HoaDon> TimHoaDonTheoMa(int maHD)
        {
            // Kiểm tra tính hợp lệ của mã hóa đơn
            if (maHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            return _dalHoaDonDAL.TimHoaDonTheoMa(maHD);
        }
        // Cập Nhật Hóa Đơn Hoàn Thành
        public bool CapNhatHoaDonHoanThanh(int maHD)
        {
            // Kiểm tra tính hợp lệ của mã hóa đơn
            if (maHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            return _dalHoaDonDAL.CapNhatHoaDonHoanThanh(maHD);
        }
        // Phương thức tính toán và áp dụng giảm giá
        public decimal TinhGiamGia(decimal tongTien, int phanTramGiamGia)
        {
            if (phanTramGiamGia < 0 || phanTramGiamGia > 30)
            {
                throw new ArgumentException("Phần trăm giảm giá không hợp lệ. Phải từ 0-30%.");
            }

            decimal giamGia = tongTien * (phanTramGiamGia / 100m);
            return Math.Round(giamGia, 2);
        }

        // Phương thức cập nhật hóa đơn với giảm giá
        public bool CapNhatHoaDonVoiGiamGia(int maHD, int phanTramGiamGia)
        {
            // Kiểm tra tính hợp lệ của mã hóa đơn
            if (maHD <= 0)
                throw new ArgumentException("Mã hóa đơn không hợp lệ");

            // Lấy thông tin hóa đơn
            var dsHoaDon = TimHoaDonTheoMa(maHD);
            if (dsHoaDon == null || dsHoaDon.Count == 0)
                throw new Exception("Không tìm thấy hóa đơn");

            var hoaDon = dsHoaDon[0];

            // Tính tổng tiền và giảm giá
            decimal tongTien = hoaDon.TongTien;
            decimal giamGia = TinhGiamGia(tongTien, phanTramGiamGia);

            // Cập nhật thông tin giảm giá
            hoaDon.GiamGia = phanTramGiamGia;

            // Gọi phương thức cập nhật hóa đơn
            return CapNhatHoaDon(hoaDon);
        }
        // Phương thức tính tổng tiền sau giảm giá
        //public decimal TinhTongTienSauGiamGia(int maHD)
        //{
        //    // Lấy thông tin hóa đơn
        //    var dsHoaDon = TimHoaDonTheoMa(maHD);
        //    if (dsHoaDon == null || dsHoaDon.Count == 0)
        //        throw new Exception("Không tìm thấy hóa đơn");

        //    var hoaDon = dsHoaDon[0];

        //    // Tính tổng tiền và giảm giá
        //    decimal tongTien = hoaDon.TongTien;
        //    decimal giamGia = TinhGiamGia(tongTien, hoaDon.GiamGia);

        //    return tongTien - giamGia;
        //}
        public List<DTO_QuanLyBenhNhan> TimBenhNhanTheoSDT(string soDienThoai)
        {
            // Kiểm tra tính hợp lệ của số điện thoại
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                throw new ArgumentException("Số điện thoại không được để trống.");
            }

            // Kiểm tra định dạng số điện thoại (tuỳ theo quy tắc của bạn)
            if (!KiemTraDinhDangSDT(soDienThoai))
            {
                throw new ArgumentException("Số điện thoại không đúng định dạng.");
            }

            try
            {
                // Gọi phương thức từ DAL
                List<DTO_QuanLyBenhNhan> danhSachBenhNhan = _dalHoaDonDAL.TimBenhNhanTrongLichHen(soDienThoai);

                // Các logic xử lý bổ sung nếu cần
                // Ví dụ: Sắp xếp, lọc, v.v.

                return danhSachBenhNhan;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw new Exception($"Lỗi tìm kiếm bệnh nhân: {ex.Message}", ex);
            }
        }
        // Phương thức kiểm tra định dạng số điện thoại
        private bool KiemTraDinhDangSDT(string soDienThoai)
        {
            // Ví dụ: Kiểm tra số điện thoại Việt Nam
            // Bạn có thể điều chỉnh regex cho phù hợp
            string pattern = @"^(0[1-9]|84[1-9])[0-9]{8}$";
            return System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, pattern);
        }
        public InvoiceDetails GetInvoiceDetails(int maHD)
        {
            // Gọi hàm từ lớp DAL
            InvoiceDetails invoiceDetails = _dalHoaDonDAL.GetInvoiceDetails(maHD);

            // Có thể thêm logic xử lý dữ liệu ở đây nếu cần

            return invoiceDetails;
        }
        public DTO_HoaDon GetHoaDonById(int maHD)
        {
            return _dalHoaDonDAL.GetHoaDonById(maHD);
        }

        public DTO_QuanLyBenhNhan GetBenhNhanById(int maBN)
        {
            return dalBenhNhan.GetBenhNhanById(maBN);
        }

        public DTO_NhanVien GetNhanVienById(int maNV)
        {
            return dalNhanVien.GetNhanVienById(maNV);
        }

        public (List<DTO_ChiTietSuDungDV> chiTietDichVuList, List<string> tenDichVuList) GetChiTietSuDungDVByMaLSKB(int maLSKB)
        {
            // Gọi phương thức DAL để lấy dữ liệu
            return _dalHoaDonDAL.GetChiTietSuDungDVByMaLSKB(maLSKB);
        }
    }
}
