using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DoanhThu
    {
        private DAL_DoanhThu _DAL_DoanhThu = new DAL_DoanhThu();
        public DTO_BaoCaoDoanhThu LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            // Validate dữ liệu
            ValidateKhoangThoiGian(tuNgay, denNgay);
            return _DAL_DoanhThu.LayBaoCaoDoanhThu(tuNgay, denNgay);
        }
        public void XuatBaoCaoExcel(DTO_BaoCaoDoanhThu baoCao, string filePath)
        {
            ValidateBaoCao(baoCao, filePath);
            _DAL_DoanhThu.XuatBaoCaoExcel(baoCao, filePath);
        }
        public List<DTO_DoanhThu> LayChiTietDoanhThuTheoDichVu(DateTime tuNgay, DateTime denNgay)
        {
            ValidateKhoangThoiGian(tuNgay, denNgay);
            return _DAL_DoanhThu.LayChiTietDoanhThuTheoDichVu(tuNgay, denNgay);
        }

        // Các phương thức validate
        private void ValidateKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
            }

            if (tuNgay > DateTime.Now)
            {
                throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày hiện tại");
            }
        }
        private void ValidateBaoCao(DTO_BaoCaoDoanhThu baoCao, string filePath)
        {
            if (baoCao == null)
            {
                throw new ArgumentNullException(nameof(baoCao), "Báo cáo không được để trống");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Đường dẫn file không hợp lệ");
            }
        }
    }
}
