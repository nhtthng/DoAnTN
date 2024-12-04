using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyBenhNhan
    {
        private DAL_QuanLyBenhNhan _patientDAL = new DAL_QuanLyBenhNhan();
        // Hàm thêm bệnh nhân với validate
        public bool ThemBenhNhan(DTO_QuanLyBenhNhan benhNhan)
        {
            // Validate số điện thoại (bắt buộc)
            if (!ValidateSoDienThoai(benhNhan.SoDT))
            {
                throw new Exception("Số điện thoại không đúng định dạng");
            }

            // Kiểm tra trùng số điện thoại
            if (_patientDAL.KiemTraTrungSoDienThoai(benhNhan.SoDT))
            {
                throw new Exception("Số điện thoại đã tồn tại");
            }

            // Validate email (nếu có)
            if (!string.IsNullOrWhiteSpace(benhNhan.Email))
            {
                if (!ValidateEmail(benhNhan.Email))
                {
                    throw new Exception("Email không đúng định dạng");
                }

                // Kiểm tra trùng email
                if (_patientDAL.KiemTraTrungEmail(benhNhan.Email))
                {
                    throw new Exception("Email đã tồn tại");
                }
            }

            // Validate số BHYT (nếu có)
            if (!string.IsNullOrWhiteSpace(benhNhan.SoBHYT))
            {
                if (!ValidateSoBHYT(benhNhan.SoBHYT))
                {
                    throw new Exception("Số BHYT không đúng định dạng");
                }

                // Kiểm tra trùng số BHYT
                if (_patientDAL.KiemTraTrungSoBHYT(benhNhan.SoBHYT))
                {
                    throw new Exception("Số BHYT đã tồn tại");
                }
            }

            // Nếu tất cả validate thành công, thực hiện thêm bệnh nhân
            return _patientDAL.AddPatient(benhNhan);
        }

        public bool DeletePatient(int maBN)
        {
            return _patientDAL.DeletePatient(maBN);
        }
        public bool UpdatePatient(DTO_QuanLyBenhNhan patient)
        {
            // Validate số điện thoại (bắt buộc)
            if (!ValidateSoDienThoai(patient.SoDT))
            {
                throw new Exception("Số điện thoại không đúng định dạng");
            }

            // Validate email (nếu có)
            if (!string.IsNullOrWhiteSpace(patient.Email))
            {
                if (!ValidateEmail(patient.Email))
                {
                    throw new Exception("Email không đúng định dạng");
                }
            }

            // Validate số BHYT (nếu có)
            if (!string.IsNullOrWhiteSpace(patient.SoBHYT))
            {
                if (!ValidateSoBHYT(patient.SoBHYT))
                {
                    throw new Exception("Số BHYT không đúng định dạng");
                }
            }

            // Thực hiện cập nhật
            return _patientDAL.UpDatePatient(patient);
        }

        public DTO_QuanLyBenhNhan SearchPatientBySDT(string sdtBN)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(sdtBN))
            {
                return null;
            }

            // Có thể thêm các logic validate số điện thoại nếu cần
            return _patientDAL.SearchPatientBySDT(sdtBN);
        }
        public List<DTO_QuanLyBenhNhan> GetAllPatients()
        {
            return _patientDAL.GetAllPatients();
        }
        public bool ValidateSoDienThoai(string soDienThoai)
        {
            // Kiểm tra null hoặc rỗng
            if (string.IsNullOrWhiteSpace(soDienThoai))
                return false;

            // Regex kiểm tra số điện thoại
            return Regex.IsMatch(soDienThoai, @"^(03|05|07|08|09|01[2689])\d{8}$");
        }
        public bool ValidateEmail(string email)
        {
            // Kiểm tra null hoặc rỗng
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex kiểm tra email
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public bool ValidateSoBHYT(string soBHYT)
        {
            // Kiểm tra null hoặc rỗng
            if (string.IsNullOrWhiteSpace(soBHYT))
                return false;

            // Regex kiểm tra số BHYT
            return Regex.IsMatch(soBHYT, @"^[A-Z]{2}\d{13}$");
        }
        public int GetLatestMedicalHistoryId(int patientId)
        {
            return _patientDAL.GetLatestMedicalHistoryId(patientId);
        }
    }
}
