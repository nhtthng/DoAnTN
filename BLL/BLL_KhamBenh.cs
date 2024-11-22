using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhamBenh
    {
        private DAL_KhamBenh dalKhamBenh = new DAL_KhamBenh();
        // Thêm lịch sử khám bệnh
        public bool AddKhamBenh(DTO_KhamBenh khamBenh)
        {
            return dalKhamBenh.AddKhamBenh(khamBenh);
        }
        // Xóa lịch sử khám bệnh
        public bool DeleteKhamBenh(int maLSKB)
        {
            return dalKhamBenh.DeleteKhamBenh(maLSKB);
        }
        // Cập nhật lịch sử khám bệnh
        public bool UpdateKhamBenh(DTO_KhamBenh khamBenh)
        {
            return dalKhamBenh.UpdateKhamBenh(khamBenh);
        }
        // Tìm kiếm lịch sử khám bệnh theo mã bệnh nhân
        public List<DTO_KhamBenh> SearchKhamBenhByMaBN(int maBN)
        {
            return dalKhamBenh.SearchKhamBenhByMaBN(maBN);
        }

        // Lấy tất cả lịch sử khám bệnh
        public List<DTO_KhamBenh> GetAllKhamBenh()
        {
            return dalKhamBenh.GetAllKhamBenh();
        }
        public bool CheckIdLSKB(int ID)
        {
            if (dalKhamBenh.IsLSKBIdExists(ID) != false)
            {
                return false;
            }
            return true;
        }
    }
}
