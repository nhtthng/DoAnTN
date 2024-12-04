using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietSuDungDV : Form
    {
        private BLL_ChiTietSuDungDV _CTSDDVBLL = new BLL_ChiTietSuDungDV();
        private List<DTO_ChiTietSuDungDV> danhSachChiTiet;
        public ChiTietSuDungDV()
        {
            InitializeComponent();
            LoadDanhSachChiTietSuDungDV();
            DGVCTSDDV.CellClick += DGVCTSDDV_CellClick;
            DataHelper dataHelper = new DataHelper();
            List<DTO_QuanLyDichVu> dichvuList = dataHelper.GetDichVuList();
            cboMaDichVu.DataSource = dichvuList;
            cboMaDichVu.DisplayMember = "TenDV";
            cboMaDichVu.ValueMember = "MaDV";
            List<int> MaLSKB = dataHelper.GetAllMaLSKB();
            cboMaLSKB.DataSource = MaLSKB;
            //cboMaLSKB.DisplayMember = "MaLSKB";
            //cboMaLSKB.ValueMember = "MaLSKB";
        }

        public void SetPatientId(int patientId)
        {
            //cboBenhNhan.SelectedValue = patientId;
            cboMaLSKB.SelectedItem = patientId;
        }

        // Load danh sách Chi Tiết Sử Dụng Dịch Vụ
        private void LoadDanhSachChiTietSuDungDV()
        {
            try
            {
                DGVCTSDDV.DataSource = _CTSDDVBLL.GetAllChiTietSuDungDV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra và thu thập dữ liệu từ các control
                DTO_ChiTietSuDungDV chiTiet = new DTO_ChiTietSuDungDV
                {
                    MaLSKB = Convert.ToInt32(cboMaLSKB.SelectedValue), // Chỉ định mã lịch khám
                    MaDV = Convert.ToInt32(cboMaDichVu.SelectedValue),
                    SoLuong = (int)numericSoLuong.Value,
                    Gia = decimal.Parse(txtBoxGia.Text),
                    NgayLap = DTPNgayLap.Value
                };

                // Gọi phương thức thêm từ BLL
                if (_CTSDDVBLL.ThemChiTietSuDungDV(chiTiet))
                {
                    MessageBox.Show("Thêm chi tiết sử dụng dịch vụ thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachChiTietSuDungDV();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaCTSDDV = int.Parse(txtBoxMaCTSDDV.Text);
            bool result = _CTSDDVBLL.XoaChiTietSuDungDV(MaCTSDDV);
            if (result)
            {
                MessageBox.Show("Xóa thành công!");
                LoadDanhSachChiTietSuDungDV();
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_ChiTietSuDungDV chiTiet = new DTO_ChiTietSuDungDV
            {
                MaChiTietSDDV = int.Parse(txtBoxMaCTSDDV.Text),
                MaLSKB = Convert.ToInt32(cboMaLSKB.SelectedValue),
                MaDV = Convert.ToInt32(cboMaDichVu.SelectedValue),
                SoLuong = (int)numericSoLuong.Value,
                Gia = decimal.Parse(txtBoxGia.Text),
                NgayLap = DTPNgayLap.Value
            };

            bool result = _CTSDDVBLL.SuaChiTietSuDungDV(chiTiet);
            if (result)
            {
                MessageBox.Show("Sửa thành công!");
                LoadDanhSachChiTietSuDungDV();
            }
            else
            {
                MessageBox.Show("Sửa không thành công!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtboxTimKiem.Text.Trim();

            if (!ValidatePhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<DTO_ChiTietSuDungDV> danhSachChiTiet = _CTSDDVBLL.TimChiTietSuDungDVTheoSDT(soDienThoai);

                if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chi tiết sử dụng dịch vụ nào cho số điện thoại này.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DGVCTSDDV.DataSource = danhSachChiTiet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVCTSDDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow row = DGVCTSDDV.Rows[e.RowIndex];

                // Gán giá trị vào các điều khiển
                txtBoxMaCTSDDV.Text = row.Cells["MaChiTietSDDV"].Value.ToString();
                cboMaLSKB.SelectedItem = row.Cells["MaLSKB"].Value; // Gán mã lịch khám vào ComboBox
                cboMaDichVu.SelectedValue = row.Cells["MaDV"].Value; // Gán mã dịch vụ vào ComboBox
                numericSoLuong.Value = (int)row.Cells["SoLuong"].Value; // Gán số lượng vào NumericUpDown
                txtBoxGia.Text = row.Cells["Gia"].Value.ToString(); // Gán giá vào TextBox
                DTPNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value); // Gán ngày lập
            }
        }

        private void cboMaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dịch vụ được chọn
            if (cboMaDichVu.SelectedItem != null)
            {
                DTO_QuanLyDichVu selectedDichVu = (DTO_QuanLyDichVu)cboMaDichVu.SelectedItem;
                txtBoxGia.Text = selectedDichVu.Gia.ToString("N0"); // Hiển thị giá, có thể định dạng theo kiểu tiền tệ
            }
        }
        private void ResetForm()
        {
            // Đặt lại các ComboBox về mục đầu tiên
            if (cboMaLSKB.Items.Count > 0) cboMaLSKB.SelectedIndex = 0;
            if (cboMaDichVu.Items.Count > 0) cboMaDichVu.SelectedIndex = 0;
            //if (cboBenhNhan.Items.Count > 0) cboBenhNhan.SelectedIndex = 0;

            // Đặt lại các control khác
            numericSoLuong.Value = numericSoLuong.Minimum;
            txtBoxGia.Clear();
            DTPNgayLap.Value = DateTime.Now;
            txtboxTimKiem.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDanhSachChiTietSuDungDV();
        }

        //private void btnTimSDTBN_Click(object sender, EventArgs e)
        //{
        //    // Lấy số điện thoại và loại bỏ khoảng trắng thừa
        //    string soDienThoai = txtBoxTimSDTBN.Text.Trim();

        //    // Kiểm tra tính hợp lệ của số điện thoại
        //    if (!ValidatePhoneNumber(soDienThoai))
        //    {
        //        MessageBox.Show("Số điện thoại không hợp lệ.",
        //            "Lỗi",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        // Gọi phương thức tìm kiếm từ BLL
        //        List<DTO_QuanLyBenhNhan> danhSachBenhNhan = _CTSDDVBLL.TimBenhNhanTrongLichHen(soDienThoai);

        //        // Kiểm tra nếu không tìm thấy bệnh nhân
        //        if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
        //        {
        //            MessageBox.Show("Không tìm thấy bệnh nhân nào với số điện thoại này.",
        //                "Thông Báo",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);

        //            // Làm sáng tỏ các trường liên quan
        //            cboBenhNhan.SelectedIndex = -1;  // Bỏ chọn combobox
        //            return;
        //        }

        //        // Trường hợp chỉ có 1 bệnh nhân
        //        if (danhSachBenhNhan.Count == 1)
        //        {
        //            // Lấy bệnh nhân đầu tiên
        //            DTO_QuanLyBenhNhan benhNhan = danhSachBenhNhan[0];
        //            DTO_HoaDon hoaDonChuaThanhToan = _CTSDDVBLL.LayHoaDonMoiNhatChuaThanhToan(benhNhan.MaBN);

        //            // Điền thông tin vào các control
        //            cboBenhNhan.SelectedValue = benhNhan.MaBN;

        //            cboMaHD.SelectedValue = hoaDonChuaThanhToan.MaHD;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý ngoại lệ chi tiết
        //        MessageBox.Show(
        //            $"Lỗi tìm kiếm bệnh nhân: {ex.Message}",
        //            "Lỗi",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);

        //        // Làm sáng tỏ các control
        //        cboBenhNhan.SelectedIndex = -1;
        //    }
        //}
        // Kiểm tra tính hợp lệ của số điện thoại
        private bool ValidatePhoneNumber(string soDienThoai)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.",
                    "Cảnh Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtboxTimKiem.Focus();
                return false;
            }

            // Kiểm tra định dạng số điện thoại (VN)
            // Có thể điều chỉnh regex cho phù hợp với quy tắc của bạn
            string phonePattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, phonePattern))
            {
                MessageBox.Show("Số điện thoại không đúng định dạng.",
                    "Cảnh Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtboxTimKiem.Focus();
                return false;
            }

            return true;
        }

        private void txtBoxTimSDTBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }

        private void btnInChiDinh_Click(object sender, EventArgs e)
        {
            if (DGVCTSDDV.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                var selectedRow = DGVCTSDDV.SelectedRows[0];
                int maCTSDDV = (int)selectedRow.Cells["MaChiTietSDDV"].Value;
                string maDichVu = selectedRow.Cells["MaDV"].Value.ToString();
                decimal gia = (decimal)selectedRow.Cells["Gia"].Value;
                int soLuong = (int)selectedRow.Cells["SoLuong"].Value;
                DateTime ngayLap = (DateTime)selectedRow.Cells["NgayLap"].Value;

                // Lấy mã bệnh nhân từ mã CTSDDV
                int maBN = _CTSDDVBLL.GetPatientIdFromCTSDDV(maCTSDDV);

                // Gọi phương thức in với mã bệnh nhân
                PrintServiceDetails(maCTSDDV, maDichVu, gia, soLuong, ngayLap, maBN);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PrintServiceDetails(int maCTSDDV, string maDichVu, decimal gia, int soLuong, DateTime ngayLap, int maBN)
        {
            // Truy vấn để lấy tên bác sĩ từ cơ sở dữ liệu
            string tenBS = _CTSDDVBLL.GetDoctorName(maCTSDDV); // Hàm này sẽ được định nghĩa bên dưới
            string tenDichVu = _CTSDDVBLL.GetServiceName(maDichVu); // Lấy tên dịch vụ từ cơ sở dữ liệu

            // Lấy thông tin bệnh nhân
            var patientInfo = _CTSDDVBLL.GetPatientInfo(maBN);
            string tenBN = patientInfo.tenBN;
            DateTime? ngaySinh = patientInfo.ngaySinh;
            string soDT = patientInfo.soDT;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font contentFont = new Font("Arial", 12);

                // Vẽ logo
                string logoPath = "D:\\DownLoad_gg\\Fun Illustration Hospital Logo _ Canva Template _ Logo Template.jpg";
                if (File.Exists(logoPath))
                {
                    using (Image logo = Image.FromFile(logoPath))
                    {
                        int logoWidth = 100;
                        int logoHeight = 100;
                        e.Graphics.DrawImage(logo, new Rectangle((e.MarginBounds.Width - logoWidth) / 2, 20, logoWidth, logoHeight));
                    }
                }

                // Căn giữa tiêu đề
                e.Graphics.DrawString("BỆNH VIỆN TPT", titleFont, Brushes.Black, new PointF((e.MarginBounds.Width - e.Graphics.MeasureString("BỆNH VIỆN TPT", titleFont).Width) / 2, 130));
                e.Graphics.DrawString("THÔNG TIN DỊCH VỤ", titleFont, Brushes.Black, new PointF((e.MarginBounds.Width - e.Graphics.MeasureString("THÔNG TIN DỊCH VỤ", titleFont).Width) / 2, 170));

                // Căn trái các thông tin chi tiết
                int startY = 220; // Vị trí bắt đầu cho thông tin
                int lineHeight = 30; // Chiều cao mỗi dòng

                e.Graphics.DrawString($"Mã CTSDDV: {maCTSDDV}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Mã Dịch Vụ: {maDichVu}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Tên Dịch Vụ: {tenDichVu}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Giá: {gia:C}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Số Lượng: {soLuong}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Ngày Lập: {ngayLap.ToShortDateString()}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Tên Bác Sĩ: {tenBS}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                // Thêm thông tin bệnh nhân
                e.Graphics.DrawString($"Tên Bệnh Nhân: {tenBN}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Ngày Sinh: {(ngaySinh.HasValue ? ngaySinh.Value.ToString("dd/MM/yyyy") : "Không có thông tin")}", contentFont, Brushes.Black, new PointF(100, startY));
                startY += lineHeight;

                e.Graphics.DrawString($"Số Điện Thoại: {soDT}", contentFont, Brushes.Black, new PointF(100, startY));
            };

            // Hiển thị hộp thoại in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
