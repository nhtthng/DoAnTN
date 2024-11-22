using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuanLyBenhNhan
    {
        private DAL_QuanLyBenhNhan _patientDAL = new DAL_QuanLyBenhNhan();
        public bool AddPatient(DTO_QuanLyBenhNhan patient)
        {
            return _patientDAL.AddPatient(patient);
        }
        public bool DeletePatient(int maBN)
        {
            return _patientDAL.DeletePatient(maBN);
        }
        public bool UpdatePatient(DTO_QuanLyBenhNhan patient)
        {
            return _patientDAL.UpDatePatient(patient);
        }
        public DTO_QuanLyBenhNhan SearchPatientByMaBN(int maBN)
        {
            return _patientDAL.SearchPatientByMaBN(maBN);
        }
        public List<DTO_QuanLyBenhNhan> GetAllPatients()
        {
            return _patientDAL.GetAllPatients();
        }
    }
}
