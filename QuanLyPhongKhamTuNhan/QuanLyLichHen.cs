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
    public partial class QuanLyLichHen : Form
    {
        private DataHelper dataHelper = new DataHelper();
        private BLL_QuanLyLichHen _QuanLyLichHenBLL = new BLL_QuanLyLichHen();
        private List<DTO_LichHen> lichHenList;
        public QuanLyLichHen()
        {
            InitializeComponent();
            LoadComboBoxBacSi();
            LoadComboBoxBenhNhan();
            LoadLichHenList();
            DGVLichHen.CellClick += DGVLichHen_CellClick;
            errorProviderLH.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public void SetPatientId(int patientId)
        {
            cboMaBN.SelectedValue = patientId;
        }

        private void LoadComboBoxBacSi()
        {
            var bacSiList = dataHelper.GetBacSiList();
            cboMaBS.DataSource = bacSiList;
            cboMaBS.DisplayMember = "TenBS"; // Hiển thị tên bác sĩ
            cboMaBS.ValueMember = "MaBS"; // Giá trị là mã bác sĩ
        }
        private void LoadComboBoxBenhNhan()
        {
            var benhNhanList = dataHelper.GetBenhNhanList();
            cboMaBN.DataSource = benhNhanList;
            cboMaBN.DisplayMember = "HoTenBN"; // Hiển thị tên bệnh nhân
            cboMaBN.ValueMember = "MaBN"; // Giá trị là mã bệnh nhân
        }
        private void LoadLichHenList()
        {
            lichHenList = _QuanLyLichHenBLL.GetAllLichHen();
            DGVLichHen.DataSource = lichHenList;
        }

        private void ClearInputFields()
        {
            txtBoxMaLH.Clear();
            txtBoxSDTBN.Clear();
            txtBoxSDTBS.Clear();
            txtBoxTimMaLH.Clear();
            txtBoxTinhTrang.Clear();
            cboMaBS.SelectedIndex = -1;
            cboMaBN.SelectedIndex = -1;
            txtBoxTinhTrang.Clear();
            DTPThoiGianHen.Value = DateTime.Now;
            DTPNgayHen.Value = DateTime.Today;
            LoadLichHenList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;

            // Kiểm tra các trường bắt buộc
            if (cboMaBS.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBS, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBN.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBN, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTinhTrang.Text))
            {
                errorProviderLH.SetError(txtBoxTinhTrang, "Vui lòng nhập tình trạng.");
                isValid = false;
            }

            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return;
            }

            try
            {
                DTO_LichHen lichHen = new DTO_LichHen
                {
                    MaBS = (int)cboMaBS.SelectedValue,
                    MaBN = (int)cboMaBN.SelectedValue,
                    ThoiGianHen = DTPThoiGianHen.Value,
                    NgayHen = DTPNgayHen.Value,
                    TinhTrang = txtBoxTinhTrang.Text
                };

                if (_QuanLyLichHenBLL.AddLichHen(lichHen))
                {
                    MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                int maLH = int.Parse(txtBoxMaLH.Text);
                if (_QuanLyLichHenBLL.DeleteLichHen(maLH))
                {
                    MessageBox.Show("Xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            if (cboMaBS.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBS, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBN.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBN, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTinhTrang.Text))
            {
                errorProviderLH.SetError(txtBoxTinhTrang, "Vui lòng nhập tình trạng.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                DTO_LichHen lichHen = new DTO_LichHen
                {
                    MaLH = int.Parse(txtBoxMaLH.Text),
                    MaBS = (int)cboMaBS.SelectedValue,
                    MaBN = (int)cboMaBN.SelectedValue,
                    ThoiGianHen = DTPThoiGianHen.Value,
                    NgayHen = DTPNgayHen.Value,
                    TinhTrang = txtBoxTinhTrang.Text
                };

                if (_QuanLyLichHenBLL.UpdateLichHen(lichHen))
                {
                    MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Cập nhật lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVLichHen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = DGVLichHen.Rows[e.RowIndex];

                // Điền các giá trị vào các trường tương ứng
                txtBoxMaLH.Text = row.Cells["MaLH"].Value.ToString();
                cboMaBS.SelectedValue = row.Cells["MaBS"].Value; // Mã bác sĩ
                cboMaBN.SelectedValue = row.Cells["MaBN"].Value; // Mã bệnh nhân
                DTPThoiGianHen.Value = (DateTime)row.Cells["ThoiGianHen"].Value; // Thời gian hẹn
                DTPNgayHen.Value = (DateTime)row.Cells["NgayHen"].Value; // Ngày hẹn
                txtBoxTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString(); // Tình trạng
            }
        }

        private void btnTimLH_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtBoxTimMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxTimMaLH, "Vui lòng nhập số điện thoại bệnh nhân.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                // Lấy số điện thoại từ TextBox
                string soDT = txtBoxTimMaLH.Text.Trim();

                // Kiểm tra tính hợp lệ của số điện thoại
                if (string.IsNullOrWhiteSpace(soDT))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm kiếm lịch hẹn theo số điện thoại
                List<DTO_LichHen> searchResult = _QuanLyLichHenBLL.GetLichHenBySDT(soDT);

                // Kiểm tra kết quả tìm kiếm
                if (searchResult != null && searchResult.Count > 0)
                {
                    // Hiển thị kết quả tìm kiếm trong DataGridView
                    DGVLichHen.DataSource = searchResult;

                    // Hiển thị số lượng kết quả
                    MessageBox.Show($"Tìm thấy {searchResult.Count} lịch hẹn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lịch hẹn cho số điện thoại này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Tải lại danh sách đầy đủ
                    LoadLichHenList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tìm kiếm lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void btnTimSDTBN_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();

            // Lấy số điện thoại từ TextBox
            string soDT = txtBoxSDTBN.Text.Trim();

            try
            {
                // Sử dụng phương thức từ BLL để kiểm tra và lấy thông tin bệnh nhân
                var benhNhan = _QuanLyLichHenBLL.GetBenhNhanBySDT(soDT);

                if (benhNhan != null)
                {
                    // Tìm thấy bệnh nhân, điền vào ComboBox
                    int index = ((List<DTO_QuanLyBenhNhan>)cboMaBN.DataSource)
                        .FindIndex(bn => bn.MaBN == benhNhan.MaBN);

                    if (index != -1)
                    {
                        cboMaBN.SelectedIndex = index;
                        MessageBox.Show($"Tìm thấy bệnh nhân: {benhNhan.HoTenBN}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bệnh nhân trong danh sách.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân với số điện thoại này.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                // Xử lý lỗi số điện thoại không hợp lệ
                errorProviderLH.SetError(txtBoxSDTBN, ex.Message);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSDTBS_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();

            // Lấy số điện thoại từ TextBox
            string soDT = txtBoxSDTBS.Text.Trim();

            try
            {
                // Sử dụng phương thức từ BLL để kiểm tra và lấy thông tin bác sĩ
                var bacSi = _QuanLyLichHenBLL.GetBacSiBySDT(soDT);

                if (bacSi != null)
                {
                    // Tìm thấy bác sĩ, điền vào ComboBox
                    int index = ((List<DTO_QuanLyBacSi>)cboMaBS.DataSource)
                        .FindIndex(bs => bs.MaBS == bacSi.MaBS);

                    if (index != -1)
                    {
                        cboMaBS.SelectedIndex = index;
                        MessageBox.Show($"Tìm thấy bác sĩ: {bacSi.TenBS}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bác sĩ trong danh sách.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bác sĩ với số điện thoại này.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                // Xử lý lỗi số điện thoại không hợp lệ
                errorProviderLH.SetError(txtBoxSDTBS, ex.Message);
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxSDTBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển (Backspace, Delete, vv)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }

        private void txtBoxSDTBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }
    }
}
