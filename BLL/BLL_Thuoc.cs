using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Thuoc
    {
        private DAL_Thuoc _thuocDAL = new DAL_Thuoc();

        public List<DTO_Thuoc> GetAllThuoc()
        {
            return _thuocDAL.GetAllThuoc();
        }

        public bool AddThuoc(DTO_Thuoc thuoc)
        {
            try
            {
                _thuocDAL.AddThuoc(thuoc);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thuốc: " + ex.Message);
                return false;
            }
        }

        public bool DeleteThuoc(int maThuoc)
        {
            try
            {
                _thuocDAL.DeleteThuoc(maThuoc);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thuốc: " + ex.Message);
                return false;
            }
        }

        public bool UpdateThuoc(DTO_Thuoc thuoc)
        {
            try
            {
                _thuocDAL.UpdateThuoc(thuoc);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thuốc: " + ex.Message);
                return false;
            }
        }

        public List<DTO_Thuoc> FindThuoc(string keyword)
        {
            return _thuocDAL.FindThuoc(keyword);
        }
    }
}
