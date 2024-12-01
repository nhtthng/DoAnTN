using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_QuanLyTiepNhan
    {
        public int MaTiepNhan {  get; set; }
        public int MaBenhNhan { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public TimeSpan GioTiepNhan { get; set; }
        public string TrangThai { get; set; }
        public string TrieuChung { get; set; }
        public int MaPK {  get; set; }
    }
}
