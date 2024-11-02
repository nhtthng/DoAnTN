using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyChuyenKhoa
    {
        private DAL_QuanLyChuyenKhoa _QuanLyChuyenKhoaDAL = new DAL_QuanLyChuyenKhoa();
        // Hàm thêm chuyên khoa
        public bool AddChuyenKhoa(DTO_QuanLyChuyenKhoa chuyenKhoa)
        {
            if (chuyenKhoa == null || string.IsNullOrEmpty(chuyenKhoa.TenCK))
            {
                throw new ArgumentException("Thông tin chuyên khoa không hợp lệ.");
            }

            return _QuanLyChuyenKhoaDAL.AddChuyenKhoa(chuyenKhoa);
        }

        public bool DeleteChuyenKhoa(int maCK)
        {
            if (maCK <= 0)
            {
                throw new ArgumentException("Mã chuyên khoa không hợp lệ.");
            }

            return _QuanLyChuyenKhoaDAL.DeleteChuyenKhoa(maCK);
        }

        // Hàm sửa chuyên khoa
        public bool UpdateChuyenKhoa(DTO_QuanLyChuyenKhoa chuyenKhoa)
        {
            if (chuyenKhoa == null || chuyenKhoa.MaCK <= 0 || string.IsNullOrEmpty(chuyenKhoa.TenCK))
            {
                throw new ArgumentException("Thông tin chuyên khoa không hợp lệ.");
            }

            return _QuanLyChuyenKhoaDAL.UpdateChuyenKhoa(chuyenKhoa);
        }

        // Hàm tìm kiếm chuyên khoa bằng mã chuyên khoa
        public List<DTO_QuanLyChuyenKhoa> GetChuyenKhoaByMaCK(int maCK)
        {
            if (maCK <= 0)
            {
                throw new ArgumentException("Mã chuyên khoa không hợp lệ.");
            }

            return _QuanLyChuyenKhoaDAL.GetChuyenKhoaByMaCK(maCK);
        }
        // Hàm lấy tất cả chuyên khoa
        public List<DTO_QuanLyChuyenKhoa> GetAllChuyenKhoa()
        {
            return _QuanLyChuyenKhoaDAL.GetAllChuyenKhoa();
        }
        public bool CheckIdCK(int maCK)
        {
            if (_QuanLyChuyenKhoaDAL.IsCKIdExists(maCK) != false)
            {
                return false;
            }
            return true;
        }
    }
}
