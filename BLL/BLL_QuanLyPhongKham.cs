using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyPhongKham
    {
        private DAL_QuanLyPhongKham _QuanLyPhongKhamDAL = new DAL_QuanLyPhongKham();
        // Thêm phòng khám
        public bool AddPhongKham(DTO_QuanLyPhongKham phongKham)
        {
            // Có thể thêm các kiểm tra logic trước khi thêm vào cơ sở dữ liệu
            if (phongKham == null || string.IsNullOrEmpty(phongKham.TenPK))
            {
                throw new ArgumentException("Thông tin phòng khám không hợp lệ.");
            }

            return _QuanLyPhongKhamDAL.AddPhongKham(phongKham);
        }
        // Xóa phòng khám
        public bool DeletePhongKham(int maPK)
        {
            // Kiểm tra mã phòng khám hợp lệ
            if (maPK <= 0)
            {
                throw new ArgumentException("Mã phòng khám không hợp lệ.");
            }

            return _QuanLyPhongKhamDAL.DeletePhongKham(maPK);
        }
        // Sửa thông tin phòng khám
        public bool UpdatePhongKham(DTO_QuanLyPhongKham phongKham)
        {
            // Kiểm tra thông tin phòng khám hợp lệ
            if (phongKham == null || phongKham.MaPK <= 0 || string.IsNullOrEmpty(phongKham.TenPK))
            {
                throw new ArgumentException("Thông tin phòng khám không hợp lệ.");
            }

            return _QuanLyPhongKhamDAL.UpdatePhongKham(phongKham);
        }
        // Tìm kiếm phòng khám bằng mã phòng khám
        public DTO_QuanLyPhongKham GetPhongKhamByTenPK(string tenPK)
        {
            // Kiểm tra tên phòng khám hợp lệ
            if (string.IsNullOrWhiteSpace(tenPK))
            {
                throw new ArgumentException("Tên phòng khám không được để trống.");
            }

            return _QuanLyPhongKhamDAL.GetPhongKhamByTenPK(tenPK);
        }
        // Xuất tất cả phòng khám
        public List<DTO_QuanLyPhongKham> GetAllPhongKham()
        {
            return _QuanLyPhongKhamDAL.GetAllPhongKham();
        }
        public bool checkTenClinic(string tenPK)
        {
            // Trả về false nếu tên phòng khám đã tồn tại
            if (_QuanLyPhongKhamDAL.IsClinicNameExists(tenPK))
            {
                return false;
            }
            return true;
        }
    }
}
