using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyBacSi
    {
        private DAL_QuanLyBacSi _QuanLyBacSiDAL = new DAL_QuanLyBacSi();
        // Lấy tất cả bác sĩ
        public List<DTO_QuanLyBacSi> GetAllBacSi()
        {
            return _QuanLyBacSiDAL.GetAllBacSi();
        }
        // Thêm bác sĩ
        public bool AddBacSi(DTO_QuanLyBacSi bacSi)
        {
            // Kiểm tra tính hợp lệ của thông tin
            if (bacSi == null)
                throw new ArgumentNullException(nameof(bacSi), "Thông tin bác sĩ không được null");

            if (string.IsNullOrWhiteSpace(bacSi.TenBS))
                throw new ArgumentException("Tên bác sĩ không được để trống");

            if (bacSi.TenBS.Length > 100) // Giả sử độ dài tối đa là 100
                throw new ArgumentException("Tên bác sĩ quá dài");

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(bacSi.SoDT))
                throw new ArgumentException("Số điện thoại không được để trống");

            if (!_QuanLyBacSiDAL.ValidatePhoneNumber(bacSi.SoDT))
                throw new ArgumentException("Số điện thoại không hợp lệ");

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(bacSi.Email))
                throw new ArgumentException("Email không được để trống");

            if (!_QuanLyBacSiDAL.ValidateEmail(bacSi.Email))
                throw new ArgumentException("Email không hợp lệ");

            // Kiểm tra trùng lặp
            if (_QuanLyBacSiDAL.IsSoDTExists(bacSi.SoDT))
                throw new ArgumentException($"Số điện thoại {bacSi.SoDT} đã được sử dụng");

            if (_QuanLyBacSiDAL.IsEmailExists(bacSi.Email))
                throw new ArgumentException("Email đã được sử dụng");

            // Thực hiện thêm bác sĩ
            return _QuanLyBacSiDAL.AddBacSi(bacSi);
        }
        // Xóa bác sĩ
        public bool DeleteBacSi(int maBS)
        {
            // Có thể thêm logic kiểm tra trước khi xóa
            return _QuanLyBacSiDAL.DeleteBacSi(maBS);
        }
        // Sửa bác sĩ
        public bool UpdateBacSi(DTO_QuanLyBacSi bacSi)
        { 
            // Kiểm tra tính hợp lệ của thông tin
            if (string.IsNullOrWhiteSpace(bacSi.TenBS))
            {
                throw new ArgumentException("Tên bác sĩ không được để trống");
            }

            if (!_QuanLyBacSiDAL.ValidatePhoneNumber(bacSi.SoDT))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            if (!_QuanLyBacSiDAL.ValidateEmail(bacSi.Email))
            {
                throw new ArgumentException("Email không hợp lệ");
            }

            // Lấy thông tin bác sĩ hiện tại
            var currentBacSi = _QuanLyBacSiDAL.GetBacSiByPhone(bacSi.SoDT);

            // Kiểm tra trùng số điện thoại với các bác sĩ khác
            if (currentBacSi != null && currentBacSi.MaBS != bacSi.MaBS)
            {
                throw new ArgumentException("Số điện thoại đã được sử dụng bởi bác sĩ khác");
            }

            // Kiểm tra trùng email với các bác sĩ khác
            var existingBacSiByEmail = _QuanLyBacSiDAL.GetBacSiByEmail(bacSi.Email);
            if (existingBacSiByEmail != null && existingBacSiByEmail.MaBS != bacSi.MaBS)
            {
                throw new ArgumentException("Email đã được sử dụng bởi bác sĩ khác");
            }

            // Thực hiện cập nhật bác sĩ
            return _QuanLyBacSiDAL.UpdateBacSi(bacSi);
        }
        // Tìm kiếm bác sĩ theo mã bác sĩ
        public List<DTO_QuanLyBacSi> FindBacSiBySDT(string soDT)
        {
            // Kiểm tra định dạng số điện thoại trước khi tìm kiếm
            if (!_QuanLyBacSiDAL.ValidatePhoneNumber(soDT))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ");
            }

            return _QuanLyBacSiDAL.FindBacSiBySDT(soDT);
        }
        //public bool checkIdDoctor(int id)
        //{
        //    if (_QuanLyBacSiDAL.IsDoctorIdExists(id) != false)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
