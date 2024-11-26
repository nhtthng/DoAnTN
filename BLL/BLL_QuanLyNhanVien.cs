using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyNhanVien
    {
        private DAL_QuanLyNhanVien dalNhanVien = new DAL_QuanLyNhanVien();

        // Lấy tất cả nhân viên
        public List<DTO_NhanVien> GetAllNhanVien()
        {
            return dalNhanVien.GetAllNhanVien();
        }
        // Thêm nhân viên mới với validate
        public bool AddNhanVien(DTO_NhanVien nhanVien)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống");
            }

            if (string.IsNullOrWhiteSpace(nhanVien.SoDT))
            {
                throw new ArgumentException("Số điện thoại không được để trống");
            }

            // Validate số điện thoại
            if (!IsValidPhoneNumber(nhanVien.SoDT))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            // Kiểm tra tuổi
            if (nhanVien.NgaySinh > DateTime.Now.AddYears(-18))
            {
                throw new ArgumentException("Nhân viên phải trên 18 tuổi");
            }

            // Kiểm tra trùng số điện thoại
            if (CheckDuplicatePhoneNumber(nhanVien.SoDT))
            {
                throw new ArgumentException("Số điện thoại đã tồn tại");
            }

            return dalNhanVien.AddNhanVien(nhanVien);
        }
        // Cập nhật nhân viên
        public bool UpdateNhanVien(DTO_NhanVien nhanVien)
        {
            // Validate dữ liệu
            if (nhanVien.MaNV <= 0)
            {
                throw new ArgumentException("Mã nhân viên không hợp lệ");
            }

            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống");
            }

            if (string.IsNullOrWhiteSpace(nhanVien.SoDT))
            {
                throw new ArgumentException("Số điện thoại không được để trống");
            }

            // Validate số điện thoại
            if (!IsValidPhoneNumber(nhanVien.SoDT))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            // Kiểm tra tuổi
            if (nhanVien.NgaySinh > DateTime.Now.AddYears(-18))
            {
                throw new ArgumentException("Nhân viên phải trên 18 tuổi");
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau) || nhanVien.MatKhau.Length < 6)
            {
                throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự");
            }

            return dalNhanVien.UpdateNhanVien(nhanVien);
        }
        // Xóa nhân viên
        public bool DeleteNhanVien(int maNV)
        {
            if (maNV <= 0)
            {
                throw new ArgumentException("Mã nhân viên không hợp lệ");
            }

            return dalNhanVien.DeleteNhanVien(maNV);
        }
        // Tìm kiếm nhân viên theo số điện thoại
        public List<DTO_NhanVien> SearchNhanVienBySDT(string soDT)
        {
            if (string.IsNullOrWhiteSpace(soDT))
            {
                throw new ArgumentException("Số điện thoại không được để trống");
            }

            return dalNhanVien.SearchNhanVienBySDT(soDT);
        }
        // Kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string soDT)
        {
            // Regex kiểm tra số điện thoại Việt Nam
            string pattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            return System.Text.RegularExpressions.Regex.IsMatch(soDT, pattern);
        }
        // Kiểm tra trùng số điện thoại
        private bool CheckDuplicatePhoneNumber(string soDT)
        {
            var nhanViens = dalNhanVien.SearchNhanVienBySDT(soDT);
            return nhanViens != null && nhanViens.Count > 0;
        }
    }
}
