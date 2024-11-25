using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            List<DTO_QuanLyBenhNhan> benhNhanList = dataHelper.GetBenhNhanListFromLichHen();
            cboBenhNhan.DataSource = benhNhanList;
            cboBenhNhan.DisplayMember = "HoTenBN";
            cboBenhNhan.ValueMember = "MaBN";
            List<DTO_HoaDon> hoaDonList = dataHelper.GetMaHoaDonList();
            cboMaHD.DataSource = hoaDonList;
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";
            List<DTO_QuanLyBacSi> bacSiList = dataHelper.GetBacSiList();
            cboMaBacSi.DataSource = bacSiList;
            cboMaBacSi.DisplayMember = "TenBS";
            cboMaBacSi.ValueMember = "MaBS";
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
                    MaHD = Convert.ToInt32(cboMaHD.SelectedValue),
                    MaDV = Convert.ToInt32(cboMaDichVu.SelectedValue),
                    SoLuong = (int)numericSoLuong.Value,
                    Gia = decimal.Parse(txtBoxGia.Text),
                    MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue),
                    NgayLap = DTPNgayLap.Value,
                    MaBS = Convert.ToInt32(cboMaBacSi.SelectedValue),
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
            int maHD, maDV, maBN;
            maHD = (int)cboMaHD.SelectedValue;
            maDV = (int)cboMaDichVu.SelectedValue;
            maBN = (int)cboBenhNhan.SelectedValue;
            bool result = _CTSDDVBLL.XoaChiTietSuDungDV(maHD, maDV, maBN);
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
                MaHD = Convert.ToInt32(cboMaHD.SelectedValue),
                MaDV = Convert.ToInt32(cboMaDichVu.SelectedValue),
                SoLuong = (int)numericSoLuong.Value,
                Gia = decimal.Parse(txtBoxGia.Text),
                MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue),
                NgayLap = DTPNgayLap.Value,
                MaBS = Convert.ToInt32(cboMaBacSi.SelectedValue)
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
            try
            {
                int maBN;
                if (!int.TryParse(txtboxTimKiem.Text, out maBN))
                {
                    MessageBox.Show("Vui lòng nhập mã bệnh nhân hợp lệ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DGVCTSDDV.DataSource = _CTSDDVBLL.TimChiTietSuDungDVTheoMaBN(maBN);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cboMaHD.SelectedValue = row.Cells["MaHD"].Value;
                cboMaDichVu.SelectedValue = row.Cells["MaDV"].Value; // Gán mã dịch vụ vào ComboBox
                numericSoLuong.Value = (int)row.Cells["SoLuong"].Value; // Gán số lượng vào NumericUpDown
                txtBoxGia.Text = row.Cells["Gia"].Value.ToString(); // Gán giá vào TextBox
                cboBenhNhan.SelectedValue = row.Cells["MaBN"].Value;
                DTPNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                cboMaBacSi.SelectedValue = row.Cells["MaBS"].Value;
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
            if (cboMaHD.Items.Count > 0) cboMaHD.SelectedIndex = 0;
            if (cboMaDichVu.Items.Count > 0) cboMaDichVu.SelectedIndex = 0;
            if (cboBenhNhan.Items.Count > 0) cboBenhNhan.SelectedIndex = 0;

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

        private void btnTimSDTBN_Click(object sender, EventArgs e)
        {
            // Lấy số điện thoại và loại bỏ khoảng trắng thừa
            string soDienThoai = txtBoxTimSDTBN.Text.Trim();

            // Kiểm tra tính hợp lệ của số điện thoại
            if (!ValidatePhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi phương thức tìm kiếm từ BLL
                List<DTO_QuanLyBenhNhan> danhSachBenhNhan = _CTSDDVBLL.TimBenhNhanTrongLichHen(soDienThoai);

                // Kiểm tra nếu không tìm thấy bệnh nhân
                if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân nào với số điện thoại này.",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Làm sáng tỏ các trường liên quan
                    cboBenhNhan.SelectedIndex = -1;  // Bỏ chọn combobox
                    return;
                }

                // Trường hợp chỉ có 1 bệnh nhân
                if (danhSachBenhNhan.Count == 1)
                {
                    // Lấy bệnh nhân đầu tiên
                    DTO_QuanLyBenhNhan benhNhan = danhSachBenhNhan[0];
                    DTO_HoaDon hoaDonChuaThanhToan = _CTSDDVBLL.LayHoaDonMoiNhatChuaThanhToan(benhNhan.MaBN);

                    // Điền thông tin vào các control
                    cboBenhNhan.SelectedValue = benhNhan.MaBN;

                    cboMaHD.SelectedValue = hoaDonChuaThanhToan.MaHD;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ chi tiết
                MessageBox.Show(
                    $"Lỗi tìm kiếm bệnh nhân: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Làm sáng tỏ các control
                cboBenhNhan.SelectedIndex = -1;
            }
        }
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
                txtBoxTimSDTBN.Focus();
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
                txtBoxTimSDTBN.Focus();
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
    }
}
