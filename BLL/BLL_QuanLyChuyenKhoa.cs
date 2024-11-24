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
        public List<DTO_QuanLyChuyenKhoa> GetChuyenKhoaByTen(string tenCK)
        {
            // Validate đầu vào
            if (string.IsNullOrWhiteSpace(tenCK))
            {
                throw new ArgumentException("Tên chuyên khoa không được để trống.");
            }

            // Giới hạn độ dài tìm kiếm
            if (tenCK.Length > 100) // Điều chỉnh độ dài tối đa phù hợp với CSDL
            {
                throw new ArgumentException("Tên chuyên khoa quá dài.");
            }

            // Loại bỏ khoảng trắng thừa
            tenCK = tenCK.Trim();

            // Thực hiện tìm kiếm
            List<DTO_QuanLyChuyenKhoa> danhSachChuyenKhoa = _QuanLyChuyenKhoaDAL.GetChuyenKhoaByTen(tenCK);

            // Kiểm tra kết quả
            if (danhSachChuyenKhoa == null || danhSachChuyenKhoa.Count == 0)
            {
                throw new Exception($"Không tìm thấy chuyên khoa có tên: {tenCK}");
            }

            return danhSachChuyenKhoa;
        }
        // Hàm lấy tất cả chuyên khoa
        public List<DTO_QuanLyChuyenKhoa> GetAllChuyenKhoa()
        {
            return _QuanLyChuyenKhoaDAL.GetAllChuyenKhoa();
        }
        // Hàm kiểm tra tồn tại chuyên khoa theo tên
        public bool CheckTenCK(string tenCK)
        {
            // Validate đầu vào
            if (string.IsNullOrWhiteSpace(tenCK))
            {
                throw new ArgumentException("Tên chuyên khoa không được để trống.");
            }

            // Loại bỏ khoảng trắng thừa
            tenCK = tenCK.Trim();

            // Kiểm tra tồn tại
            return _QuanLyChuyenKhoaDAL.IsCKTenExists(tenCK);
        }
    }
}
