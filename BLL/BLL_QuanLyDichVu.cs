using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyDichVu
    {
        private DAL_QuanLyDichVu _QuanLyDichVuDAL = new DAL_QuanLyDichVu();
        public List<DTO_QuanLyDichVu> GetAllServices()
        {
            return _QuanLyDichVuDAL.GetAllServices();
        }

        // Thêm dịch vụ
        public bool AddService(DTO_QuanLyDichVu service)
        {
            if (service == null || string.IsNullOrEmpty(service.TenDV) || service.Gia <= 0)
            {
                Console.WriteLine("Thông tin dịch vụ không hợp lệ");
                return false;
            }
            //else if (_QuanLyDichVuDAL.IsServiceIdExists(service.MaDV) == false)
            //{
            //    Console.WriteLine("Trùng mã dịch vụ");
            //    return false;
            //}

            return _QuanLyDichVuDAL.AddService(service);
        }
        // check ID DV
        public bool CheckIdDv(int ID)
        {
            if (_QuanLyDichVuDAL.IsServiceIdExists(ID) != false)
            {
                return false;
            }
            return true;
        }
        // Xóa dịch vụ
        public bool DeleteService(int maDV)
        {
            if (maDV <= 0)
            {
                Console.WriteLine("Mã dịch vụ không hợp lệ");
                return false;
            }

            return _QuanLyDichVuDAL.DeleteService(maDV);
        }

        // Sửa dịch vụ
        public bool UpdateService(DTO_QuanLyDichVu service)
        {
            if (service == null || service.MaDV <= 0 || string.IsNullOrEmpty(service.TenDV) || service.Gia <= 0)
            {
                Console.WriteLine("Thông tin dịch vụ không hợp lệ");
                return false;
            }

            return _QuanLyDichVuDAL.UpdateService(service);
        }

        // Tìm kiếm dịch vụ theo mã
        public DTO_QuanLyDichVu FindServiceById(int maDV)
        {
            if (maDV <= 0)
            {
                Console.WriteLine("Mã dịch vụ không hợp lệ");
                return null;
            }

            return _QuanLyDichVuDAL.FindServiceById(maDV);
        }
    }
}
