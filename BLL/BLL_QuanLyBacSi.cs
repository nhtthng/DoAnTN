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
            // Có thể thêm logic kiểm tra trước khi thêm
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
            // Có thể thêm logic kiểm tra trước khi sửa
            return _QuanLyBacSiDAL.UpdateBacSi(bacSi);
        }
        // Tìm kiếm bác sĩ theo mã bác sĩ
        public List<DTO_QuanLyBacSi> FindBacSiByMaBS(int maBS)
        {
            return _QuanLyBacSiDAL.FindBacSiByMaBS(maBS);
        }
        public bool checkIdDoctor(int id)
        {
            if (_QuanLyBacSiDAL.IsDoctorIdExists(id) != false)
            {
                return false;
            }
            return true;
        }
    }
}
