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
    public partial class KhamBenh : Form
    {
        private BLL_KhamBenh bllKhamBenh = new BLL_KhamBenh();
        public KhamBenh()
        {
            InitializeComponent();
            DGVKB.CellClick += DGVKB_CellClick;
            LoadKhamBenhData();
            DataHelper dataHelper = new DataHelper();
            List<DTO_QuanLyBacSi> bacsiList = dataHelper.GetBacSiList();
            cboMaBacSi.DataSource = bacsiList;
            cboMaBacSi.DisplayMember = "TenBS";
            cboMaBacSi.ValueMember = "MaBS";
            List<DTO_QuanLyBenhNhan> benhnhanList = dataHelper.GetBenhNhanList();
            cboMaBenhNhan.DataSource = benhnhanList;
            cboMaBenhNhan.DisplayMember = "HoTenBN";
            cboMaBenhNhan.ValueMember = "MaBN";
            List<DTO_QuanLyPhongKham> phongKhamList = dataHelper.GetPhongKhamList();

            cboMaPK.DataSource = phongKhamList;
            cboMaPK.DisplayMember = "TenPK";
            cboMaPK.ValueMember = "MaPK";
            errorProviderKB.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            DGVKB.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            DTPNgayKham.Format = DateTimePickerFormat.Custom;
            DTPNgayKham.CustomFormat = "dd/MM/yyyy HH:mm";
            DTPNgayKham.ShowUpDown = true;

            // Đặt giá trị mặc định là giờ hiện tại
            DTPNgayKham.Value = DateTime.Now;
        }
        private void LoadKhamBenhData()
        {
            DGVKB.DataSource = bllKhamBenh.GetAllKhamBenh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();

            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxChuanDoan.Text))
            {
                errorProviderKB.SetError(txtBoxChuanDoan, "Vui lòng nhập chuẩn đoán.");
                isValid = false;
            }
            if (cboMaBacSi.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBacSi, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBenhNhan.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBenhNhan, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (cboMaPK.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaPK, "Vui lòng chọn phòng khám.");
                isValid = false;
            }

            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }

            try
            {
                // Kiểm tra điều kiện ngày khám
                if (DTPNgayKham.Value > DateTime.Now)
                {
                    MessageBox.Show(
                        "Ngày khám không được lớn hơn ngày hiện tại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                {
                    MaBS = (int)cboMaBacSi.SelectedValue,
                    MaBN = (int)cboMaBenhNhan.SelectedValue,
                    NgayKham = DTPNgayKham.Value,
                    ChuanDoan = txtBoxChuanDoan.Text,
                    MaPK = (int)cboMaPK.SelectedValue
                };

                if (bllKhamBenh.AddKhamBenh(khamBenh))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhamBenhData();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt và hiển thị mọi ngoại lệ có thể xảy ra
                MessageBox.Show(
                    $"Lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxLSKB.Text))
            {
                errorProviderKB.SetError(txtBoxLSKB, "Vui lòng nhập mã lịch sử khám bệnh.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maLSKB = int.Parse(txtBoxLSKB.Text);
            bool isDeleted = bllKhamBenh.DeleteKhamBenh(maLSKB);
            if (isDeleted)
            {
                MessageBox.Show("Xóa thành công!");
                LoadKhamBenhData();
            }
            else
            {
                MessageBox.Show("Xóa không thành công.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxLSKB.Text))
            {
                errorProviderKB.SetError(txtBoxLSKB, "Vui lòng nhập mã lịch sử khám bệnh.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxChuanDoan.Text))
            {
                errorProviderKB.SetError(txtBoxChuanDoan, "Vui lòng nhập chuẩn đoán.");
                isValid = false;
            }
            if (cboMaBacSi.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBacSi, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBenhNhan.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBenhNhan, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (cboMaPK.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaPK, "Vui lòng chọn phòng khám.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            DTO_KhamBenh khamBenh = new DTO_KhamBenh
            {
                MaLSKB = int.Parse(txtBoxLSKB.Text),
                MaBS = (int)cboMaBacSi.SelectedValue,
                MaBN = (int)cboMaBenhNhan.SelectedValue,
                NgayKham = DTPNgayKham.Value,
                ChuanDoan = txtBoxChuanDoan.Text,
                MaPK = (int)cboMaPK.SelectedValue
            };

            if (bllKhamBenh.UpdateKhamBenh(khamBenh))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadKhamBenhData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
        }

        private void btnTimLSKB_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();

            // Kiểm tra và validate số điện thoại
            bool isValid = true;
            string soDienThoai = txtBoxTimLSKB.Text.Trim();

            try
            {
                // Validate số điện thoại
                if (string.IsNullOrWhiteSpace(soDienThoai))
                {
                    errorProviderKB.SetError(txtBoxTimLSKB, "Vui lòng nhập số điện thoại.");
                    isValid = false;
                }

                // Nếu không hợp lệ, dừng xử lý
                if (!isValid)
                {
                    return;
                }

                // Gọi phương thức tìm kiếm từ BLL
                List<DTO_KhamBenh> result = bllKhamBenh.SearchBenhNhanInKhamBenhBySDT(soDienThoai);

                // Kiểm tra và hiển thị kết quả
                if (result != null && result.Count > 0)
                {
                    // Cấu hình DataGridView
                    DGVKB.DataSource = null; // Xóa nguồn dữ liệu cũ
                    DGVKB.DataSource = result; // Gán nguồn dữ liệu mới


                    // Thông báo kết quả
                    MessageBox.Show($"Tìm thấy {result.Count} lịch sử khám bệnh!",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                // Xử lý lỗi validate số điện thoại
                errorProviderKB.SetError(txtBoxTimLSKB, ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                if (ex.Message.Contains("Không tìm thấy"))
                {
                    // Trường hợp không tìm thấy bệnh nhân
                    MessageBox.Show(ex.Message,
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // Tải lại dữ liệu gốc
                    LoadKhamBenhData();
                }
                else
                {
                    // Lỗi hệ thống
                    MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void DGVKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVKB.Rows[e.RowIndex];
                txtBoxLSKB.Text = row.Cells["MaLSKB"].Value.ToString();
                cboMaBacSi.SelectedValue = row.Cells["MaBS"].Value;
                cboMaBenhNhan.SelectedValue = row.Cells["MaBN"].Value;
                DTPNgayKham.Value = (DateTime)row.Cells["NgayKham"].Value;
                txtBoxChuanDoan.Text = row.Cells["ChuanDoan"].Value.ToString();
                cboMaPK.SelectedValue = row.Cells["MaPK"].Value;
            }
        }

        private void btnTimSDTBN_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra số điện thoại
                if (string.IsNullOrWhiteSpace(txtBoxSDTBN.Text))
                {
                    errorProviderKB.SetError(txtBoxSDTBN, "Vui lòng nhập số điện thoại.");
                    return;
                }

                // 2. Thực hiện tìm kiếm bệnh nhân trong lịch hẹn
                List<DTO_QuanLyBenhNhan> danhSachBenhNhanLichHen =
                    bllKhamBenh.SearchBenhNhanInLichHenBySDT(txtBoxSDTBN.Text.Trim());

                if (danhSachBenhNhanLichHen != null && danhSachBenhNhanLichHen.Count > 0)
                {
                    // Nạp danh sách bệnh nhân vào ComboBox
                    cboMaBenhNhan.DataSource = danhSachBenhNhanLichHen;
                    cboMaBenhNhan.DisplayMember = "HoTenBN";
                    cboMaBenhNhan.ValueMember = "MaBN";

                    // Hiển thị thông báo số lượng kết quả
                    MessageBox.Show($"Tìm thấy {danhSachBenhNhanLichHen.Count} bệnh nhân trong lịch hẹn.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nếu chỉ có 1 kết quả, tự động chọn
                    if (danhSachBenhNhanLichHen.Count == 1)
                    {
                        cboMaBenhNhan.SelectedIndex = 0;
                    }

                    return;
                }

                // 3. Nếu không tìm thấy bệnh nhân
                MessageBox.Show("Không tìm thấy bệnh nhân với số điện thoại này trong lịch hẹn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset ComboBox 
                ResetBenhNhanComboBox();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Phương thức reset ComboBox Bệnh Nhân
        private void ResetBenhNhanComboBox()
        {
            // Nạp lại danh sách bệnh nhân ban đầu
            DataHelper dataHelper = new DataHelper();
            var benhnhanList = dataHelper.GetBenhNhanList();

            cboMaBenhNhan.DataSource = benhnhanList;
            cboMaBenhNhan.DisplayMember = "HoTenBN";
            cboMaBenhNhan.ValueMember = "MaBN";

            // Bỏ chọn
            cboMaBenhNhan.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxTimLSKB.Clear();
            txtBoxSDTBN.Clear();
            txtBoxChuanDoan.Clear();
            txtBoxLSKB.Clear();
            txtBoxSDTBN.Clear();
            cboMaBacSi.SelectedIndex = -1;
            cboMaBenhNhan.SelectedIndex = -1;
            cboMaPK.SelectedIndex = -1;
            LoadKhamBenhData();
        }

        private void DTPNgayKham_ValueChanged(object sender, EventArgs e)
        {
            // Giữ nguyên giờ phút khi chọn ngày mới
            DateTime selectedDateTime = DTPNgayKham.Value;
            DateTime currentTime = DateTime.Now;

            selectedDateTime = new DateTime(
                selectedDateTime.Year,
                selectedDateTime.Month,
                selectedDateTime.Day,
                currentTime.Hour,
                currentTime.Minute,
                0
            );

            DTPNgayKham.Value = selectedDateTime;
        }
    }
}
