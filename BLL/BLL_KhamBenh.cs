using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhamBenh
    {
        private DAL_KhamBenh dalKhamBenh = new DAL_KhamBenh();
        private DAL_QuanLyLichHen dalLichHen = new DAL_QuanLyLichHen();
        private DAL_QuanLyBenhNhan dalBenhNhan = new DAL_QuanLyBenhNhan();
        private DAL_QuanLyTiepNhan dalTiepNhan = new DAL_QuanLyTiepNhan();
        // Validate thông tin khám bệnh
        private void ValidateKhamBenh(DTO_KhamBenh khamBenh)
        {
            // Kiểm tra các trường bắt buộc
            if (khamBenh == null)
            {
                throw new ArgumentNullException(nameof(khamBenh), "Thông tin khám bệnh không được null.");
            }

            if (khamBenh.MaBS <= 0)
            {
                throw new ArgumentException("Mã bác sĩ không hợp lệ.");
            }

            if (khamBenh.MaBN <= 0)
            {
                throw new ArgumentException("Mã bệnh nhân không hợp lệ.");
            }

            if (khamBenh.NgayKham > DateTime.Now)
            {
                throw new ArgumentException("Ngày khám không được lớn hơn ngày hiện tại.");
            }

            // Kiểm tra độ dài chuẩn đoán
            if (string.IsNullOrWhiteSpace(khamBenh.ChuanDoan))
            {
                throw new ArgumentException("Chuẩn đoán không được để trống.");
            }

            if (khamBenh.ChuanDoan.Length > 500) // Giả sử độ dài tối đa là 500 ký tự
            {
                throw new ArgumentException("Chuẩn đoán quá dài.");
            }
        }

        // Phương thức validate số điện thoại
        private bool ValidatePhoneNumber(string soDT)
        {
            // Kiểm tra null hoặc rỗng
            if (string.IsNullOrWhiteSpace(soDT))
            {
                throw new ArgumentException("Số điện thoại không được để trống.");
            }

            // Kiểm tra độ dài và định dạng
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDT, @"^0\d{9,10}$"))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ. Phải bắt đầu bằng 0 và có 10-11 chữ số.");
            }

            return true;
        }


        // Thêm lịch sử khám bệnh
        public bool AddKhamBenh(DTO_KhamBenh khamBenh)
        {
            try
            {
                // Validate trước khi thêm
                ValidateKhamBenh(khamBenh);

                // Thực hiện thêm
                return dalKhamBenh.AddKhamBenh(khamBenh);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw new Exception("Lỗi khi thêm lịch sử khám bệnh: " + ex.Message);
            }
        }
        // Xóa lịch sử khám bệnh
        public bool DeleteKhamBenh(int maLSKB)
        {
            return dalKhamBenh.DeleteKhamBenh(maLSKB);
        }
        // Cập nhật lịch sử khám bệnh
        public bool UpdateKhamBenh(DTO_KhamBenh khamBenh)
        {
            try
            {
                // Validate trước khi cập nhật
                ValidateKhamBenh(khamBenh);

                // Thực hiện cập nhật
                return dalKhamBenh.UpdateKhamBenh(khamBenh);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                throw new Exception("Lỗi khi cập nhật lịch sử khám bệnh: " + ex.Message);
            }
        }
        // Tìm kiếm lịch sử khám bệnh theo sdt bệnh nhân
        public List<DTO_QuanLyBenhNhan> SearchBenhNhanInLichHenBySDT(string soDT)
        {
            // Validate số điện thoại
            if (ValidatePhoneNumber(soDT))
            {
                // Thực hiện truy vấn
                List<DTO_QuanLyBenhNhan> danhSachBenhNhan = dalKhamBenh.SearchBenhNhanInLichHenBySDT(soDT);

                // Kiểm tra kết quả
                if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
                {
                    throw new Exception("Không tìm thấy bệnh nhân trong lịch hẹn.");
                }

                return danhSachBenhNhan;
            }

            // Nếu validate không thành công (không bao giờ xảy ra do đã throw exception)
            return new List<DTO_QuanLyBenhNhan>();
        }

        // Lấy tất cả lịch sử khám bệnh
        public List<DTO_KhamBenh> GetAllKhamBenh()
        {
            return dalKhamBenh.GetAllKhamBenh();
        }
        public List<DTO_KhamBenh> SearchBenhNhanInKhamBenhBySDT(string soDT)
        {
            try
            {
                // 1. Validate số điện thoại
                ValidatePhoneNumber(soDT);

                // 2. Thực hiện truy vấn từ DAL
                List<DTO_KhamBenh> danhSachBenhNhan =
                    dalKhamBenh.SearchBenhNhanInKhamBenhBySDT(soDT);

                // 3. Kiểm tra kết quả truy vấn
                if (danhSachBenhNhan == null)
                {
                    throw new Exception("Lỗi hệ thống khi truy vấn dữ liệu.");
                }

                // 4. Kiểm tra có bệnh nhân không
                if (danhSachBenhNhan.Count == 0)
                {
                    throw new Exception($"Không tìm thấy bệnh nhân có số điện thoại {soDT} trong lịch sử khám bệnh.");
                }

                // 5. Bổ sung thêm các logic kiểm tra khác nếu cần
                // Ví dụ: Lọc bệnh nhân theo điều kiện cụ thể

                // 6. Trả về danh sách bệnh nhân
                return danhSachBenhNhan;
            }
            catch (ArgumentException ex)
            {
                // Xử lý lỗi validate số điện thoại
                throw; // Ném lại exception để lớp gọi xử lý
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu có hệ thống logging)
                // Logger.Error($"Lỗi tìm kiếm bệnh nhân: {ex.Message}");

                // Ném exception để lớp gọi xử lý
                throw;
            }
        }

        public List<object> GetThongTinBenhNhanBySDT(DateTime ngayKham, string soDienThoai)
        {
            // Lấy danh sách bệnh nhân tiếp nhận trong ngày
            var danhSachTiepNhan = dalTiepNhan.GetAllTiepNhanByNgay(ngayKham);

            // Lấy danh sách lịch hẹn trong ngày
            var danhSachLichHen = dalLichHen.GetLichHenByNgay(ngayKham);

            // Lấy thông tin chi tiết bệnh nhân
            var danhSachBenhNhan = dalBenhNhan.GetAllPatients();

            // Tạo danh sách kết quả
            var danhSachKetQua = new List<object>();

            // Xử lý bệnh nhân từ lịch hẹn
            var benhNhanLichHen = danhSachLichHen.Where(lh =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == lh.MaBN);
                return benhNhan != null && benhNhan.SoDT == soDienThoai;
            }).Select(lh =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == lh.MaBN);
                return new
                {
                    MaBN = lh.MaBN,
                    HoTenBN = benhNhan?.HoTenBN ?? "Không xác định",
                    NgaySinh = benhNhan?.NgaySinh ?? DateTime.MinValue,
                    SoDT = benhNhan?.SoDT ?? "Không có",
                    TrieuChung = "Lịch hẹn khám",
                    NgayTiepNhan = lh.NgayHen,
                    GioTiepNhan = lh.ThoiGianHen.TimeOfDay
                };
            });

            // Xử lý bệnh nhân từ tiếp nhận
            var benhNhanTiepNhan = danhSachTiepNhan.Where(tn =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == tn.MaBenhNhan);
                return benhNhan != null && benhNhan.SoDT == soDienThoai;
            }).Select(tn =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == tn.MaBenhNhan);
                return new
                {
                    MaBN = tn.MaBenhNhan,
                    HoTenBN = benhNhan?.HoTenBN ?? "Không xác định",
                    NgaySinh = benhNhan?.NgaySinh ?? DateTime.MinValue,
                    SoDT = benhNhan?.SoDT ?? "Không có",
                    TrieuChung = tn.TrieuChung,
                    NgayTiepNhan = tn.NgayTiepNhan,
                    GioTiepNhan = tn.GioTiepNhan
                };
            });

            // Kết hợp và trả về danh sách
            danhSachKetQua.AddRange(benhNhanLichHen);
            danhSachKetQua.AddRange(benhNhanTiepNhan);

            // Loại bỏ các bản ghi trùng lặp nếu cần
            danhSachKetQua = danhSachKetQua
                .GroupBy(x => x.GetType().GetProperty("MaBN").GetValue(x))
                .Select(g => g.First())
                .ToList();

            return danhSachKetQua;
        }

        public List<object> GetDanhSachBenhNhanTrongNgay(DateTime ngayKham)
        {
            // Lấy danh sách bệnh nhân tiếp nhận trong ngày
            var danhSachTiepNhan = dalTiepNhan.GetAllTiepNhanByNgay(ngayKham);

            // Lấy danh sách lịch hẹn trong ngày
            var danhSachLichHen = dalLichHen.GetLichHenByNgay(ngayKham);

            // Lấy thông tin chi tiết bệnh nhân
            var danhSachBenhNhan = dalBenhNhan.GetAllPatients();

            // Lấy danh sách lịch sử khám bệnh
            var danhSachLichSuKham = dalKhamBenh.GetLichSuKhamBenhByNgay(ngayKham);

            // Tạo danh sách kết quả
            var danhSachKetQua = new List<object>();

            // Lấy danh sách mã bệnh nhân đã khám
            var maBenhNhanDaKham = new HashSet<int>(
                danhSachLichSuKham.Select(ls => ls.MaBN)
            );

            // Xử lý bệnh nhân từ lịch hẹn
            var benhNhanLichHen = danhSachLichHen.Where(lh => !maBenhNhanDaKham.Contains(lh.MaBN)).Select(lh =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == lh.MaBN);
                return new
                {
                    MaBN = lh.MaBN,
                    HoTenBN = benhNhan?.HoTenBN ?? "Không xác định",
                    NgaySinh = benhNhan?.NgaySinh ?? DateTime.MinValue,
                    SoDT = benhNhan?.SoDT ?? "Không có",
                    TrieuChung = lh.TinhTrang,
                    NgayTiepNhan = lh.NgayHen,
                    GioTiepNhan = lh.ThoiGianHen.TimeOfDay
                };
            });

            // Xử lý bệnh nhân từ tiếp nhận
            var benhNhanTiepNhan = danhSachTiepNhan.Where(tn => !maBenhNhanDaKham.Contains(tn.MaBenhNhan)).Select(tn =>
            {
                var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBN == tn.MaBenhNhan);
                return new
                {
                    MaBN = tn.MaBenhNhan,
                    HoTenBN = benhNhan?.HoTenBN ?? "Không xác định",
                    NgaySinh = benhNhan?.NgaySinh ?? DateTime.MinValue,
                    SoDT = benhNhan?.SoDT ?? "Không có",
                    TrieuChung = tn.TrieuChung,
                    NgayTiepNhan = tn.NgayTiepNhan,
                    GioTiepNhan = tn.GioTiepNhan
                };
            });

            // Kết hợp và trả về danh sách
            danhSachKetQua.AddRange(benhNhanLichHen);
            danhSachKetQua.AddRange(benhNhanTiepNhan);

            // Loại bỏ các bản ghi trùng lặp nếu cần
            danhSachKetQua = danhSachKetQua
                .GroupBy(x => x.GetType().GetProperty("MaBN").GetValue(x))
                .Select(g => g.First())
                .ToList();

            return danhSachKetQua;
        }

    }
}
